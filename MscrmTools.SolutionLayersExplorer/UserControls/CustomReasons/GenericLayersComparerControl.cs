using Diff.Net;
using Menees.Diffs;
using Microsoft.Xrm.Sdk;
using MscrmTools.SolutionLayersExplorer.AppCode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    internal enum CompareType
    {
        Auto,
        Text,
        Xml,
        Binary,
    }

    internal enum DiffType
    {
        File,
        Directory,
        Text,
    }

    public partial class GenericLayersComparerControl : UserControl
    {
        private readonly LayerItem _item;

        public GenericLayersComparerControl(LayerItem item)
        {
            InitializeComponent();

            _item = item;

            FillLayers();
        }

        public event EventHandler OnFullScreenRequested;

        private static void GetTextLines(string textA, string textB, out IList<string> a, out IList<string> b)
        {
            a = null;
            b = null;
            CompareType compareType = Options.CompareType;
            bool isAuto = compareType == CompareType.Auto;

            if (compareType == CompareType.Xml || isAuto)
            {
                a = TryGetXmlLines(DiffUtility.GetXmlTextLinesFromXml, "the left side text", textA, !isAuto);

                // If A failed to parse with Auto, then there's no reason to try B.
                if (a != null)
                {
                    b = TryGetXmlLines(DiffUtility.GetXmlTextLinesFromXml, "the right side text", textB, !isAuto);
                }

                // If we get here and the compare type was XML, then both
                // inputs parsed correctly, and both lists should be non-null.
                // If we get here and the compare type was Auto, then one
                // or both lists may be null, so we'll fallthrough to the text
                // handling logic.
            }

            if (a == null || b == null)
            {
                a = DiffUtility.GetStringTextLines(textA);
                b = DiffUtility.GetStringTextLines(textB);
            }
        }

        private static IList<string> TryGetXmlLines(Func<string, bool, IList<string>> converter, string name, string input, bool throwOnError)
        {
            IList<string> result = null;
            try
            {
                result = converter(input, Options.IgnoreXmlWhitespace);
            }
            catch (XmlException ex)
            {
                if (throwOnError)
                {
                    StringBuilder sb = new StringBuilder("An XML comparison was attempted, but an XML exception occurred while parsing ");
                    sb.Append(name).AppendLine(".").AppendLine();
                    sb.AppendLine("Exception Message:").Append(ex.Message);
                    throw new XmlException(sb.ToString(), ex);
                }
            }

            return result;
        }

        private void cbbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAttributes();
            cbbProperties_SelectedIndexChanged(sender, e);
        }

        private void cbbProperties_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            string text = ((ComboBox)sender).Items[e.Index].ToString();

            Brush brush;
            if (text.EndsWith("*") && !chkShowOnlyDiff.Checked)// compare  date with your list.
            {
                brush = Brushes.Red;
            }
            else
            {
                brush = Brushes.Black;
            }

            // Draw the text
            e.Graphics.DrawString(text.ToString().Replace(" *", ""), ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void cbbProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbProperties.SelectedIndex < 0
                || cbbLayers.SelectedIndex < 0
                || cbbLayers2.SelectedIndex < 0) return;

            var json1 = ((Layer)cbbLayers.SelectedItem).Record.GetAttributeValue<string>("msdyn_componentjson");
            var json2 = ((Layer)cbbLayers2.SelectedItem).Record.GetAttributeValue<string>("msdyn_componentjson");

            var propertyName = cbbProperties.SelectedItem.ToString().Replace(" *", "");

            try
            {
                var jo1 = JObject.Parse(json1);
                var jo2 = JObject.Parse(json2);

                var attrsLayer1 = (JArray)jo1["Attributes"];
                var attrLayer1 = ((JObject)attrsLayer1.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == propertyName))?.GetValue("Value");
                if (attrLayer1 == null)
                {
                    attrLayer1 = ((JObject)attrsLayer1.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == cbbProperties.SelectedItem.ToString()))?.GetValue("Value");
                    if (attrLayer1 == null)
                    {
                        throw new Exception($"Unable to find properties {cbbProperties.SelectedItem} in first layer");
                    }
                }

                var attrsLayer2 = (JArray)jo2["Attributes"];
                var attrLayer2 = ((JObject)attrsLayer2.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == propertyName))?.GetValue("Value");
                if (attrLayer2 == null)
                {
                    attrLayer2 = ((JObject)attrsLayer1.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == cbbProperties.SelectedItem.ToString()))?.GetValue("Value");
                    if (attrLayer2 == null)
                    {
                        throw new Exception($"Unable to find properties {cbbProperties.SelectedItem} in second layer");
                    }
                }

                if (((Layer)cbbLayers.SelectedItem).Record.GetAttributeValue<string>("msdyn_solutioncomponentname") == "WebResource" && propertyName == "content")
                {
                    attrLayer1 = GetBase64StringContent(attrLayer1.ToString());
                    attrLayer2 = GetBase64StringContent(attrLayer2.ToString());
                }

                Compare(attrLayer1.ToString(), attrLayer2.ToString(), ((Layer)cbbLayers.SelectedItem).ToString(), ((Layer)cbbLayers2.SelectedItem).ToString());

                diffControl.Visible = true;

                OnFullScreenRequested?.Invoke(this, new EventArgs());
            }
            catch (Exception error)
            {
                MessageBox.Show(this, $"An error occured when parsing content: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowOnlyDiff_CheckedChanged(object sender, EventArgs e)
        {
            FillAttributes();
        }

        private void Compare(string contentA, string contentB, string titleA, string titleB)
        {
            IList<string> a, b;
            int leadingCharactersToIgnore = 0;

            contentA = TryFormatJson(contentA, out bool isJsonA);
            contentB = TryFormatJson(contentB, out bool isJsonB);

            GetTextLines(contentA, contentB, out a, out b);

            bool isBinaryCompare = leadingCharactersToIgnore > 0;
            bool ignoreCase = !isBinaryCompare && Options.IgnoreCase;
            bool ignoreTextWhitespace = !isBinaryCompare && Options.IgnoreTextWhitespace;
            TextDiff diff = new TextDiff(Options.HashType, ignoreCase, ignoreTextWhitespace, leadingCharactersToIgnore, !Options.ShowChangeAsDeleteInsert);
            EditScript script = diff.Execute(a, b);

            this.diffControl.SetData(a, b, script, titleA, titleB, ignoreCase, ignoreTextWhitespace, isBinaryCompare);

            if (Options.LineDiffHeight != 0)
            {
                this.diffControl.LineDiffHeight = Options.LineDiffHeight;
            }
        }

        private void FillAttributes()
        {
            if (cbbProperties.Items.Count > 0)
            {
                ShowDifferences();
                return;
            }
            if (cbbLayers.SelectedItem == null) return;

            var layer = ((Layer)cbbLayers.SelectedItem).Record;

            var jo = JObject.Parse(layer.GetAttributeValue<string>("msdyn_componentjson"));
            foreach (JObject attr in ((JArray)jo["Attributes"]))
            {
                cbbProperties.Items.Add(attr.Value<string>("Key"));
            }

            cbbProperties.Sorted = true;
        }

        private void FillLayers()
        {
            cbbLayers.Items.AddRange(_item.Layers.Select(l => new Layer(l)).ToArray());
            cbbLayers.SelectedIndex = 0;
            cbbLayers2.Items.AddRange(_item.Layers.Select(l => new Layer(l)).ToArray());
            cbbLayers2.SelectedIndex = 1;
        }

        private string GetBase64StringContent(string content)
        {
            byte[] binary = Convert.FromBase64String(content);
            string resourceContent = Encoding.UTF8.GetString(binary);
            string byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (resourceContent.StartsWith("\""))
            {
                resourceContent = resourceContent.Remove(0, byteOrderMarkUtf8.Length);
            }

            return resourceContent;
        }

        private void ShowDifferences()
        {
            var layer1 = ((Layer)cbbLayers.SelectedItem).Record;
            var layer2 = ((Layer)cbbLayers2.SelectedItem).Record;

            var jo1 = JObject.Parse(layer1.GetAttributeValue<string>("msdyn_componentjson"));
            var jo2 = JObject.Parse(layer2.GetAttributeValue<string>("msdyn_componentjson"));

            cbbProperties.SelectedIndexChanged -= cbbProperties_SelectedIndexChanged;

            int selectedIndex = cbbProperties.SelectedIndex;
            cbbProperties.Items.Clear();

            foreach (JObject attr1 in ((JArray)jo1["Attributes"]))
            {
                foreach (JObject attr2 in ((JArray)jo2["Attributes"]))
                {
                    if (attr1.Value<string>("Key") == attr2.Value<string>("Key"))
                    {
                        var value1 = attr1.GetValue("Value");
                        var value2 = attr2.GetValue("Value");

                        if (JToken.DeepEquals(value1, value2))
                        {
                            if (!chkShowOnlyDiff.Checked)
                            {
                                cbbProperties.Items.Add(attr1.Value<string>("Key"));
                            }
                        }
                        else
                        {
                            cbbProperties.Items.Add(attr1.Value<string>("Key") + " *");
                        }
                    }
                }
            }
            cbbProperties.SelectedIndex = selectedIndex;
            cbbProperties.SelectedIndexChanged += cbbProperties_SelectedIndexChanged;
        }

        private string TryFormatJson(string s, out bool isJson)
        {
            try
            {
                JObject json = JObject.Parse(s);
                isJson = true;
                return json.ToString();
            }
            catch
            {
                isJson = false;
                return s;
            }
        }
    }

    public class Layer
    {
        private readonly Entity _record;

        public Layer(Entity record)
        {
            _record = record;
        }

        public Entity Record => _record;

        public override string ToString()
        {
            return $"{_record.GetAttributeValue<int>("msdyn_order")} - {_record.GetAttributeValue<string>("msdyn_solutionname")}";
        }
    }
}