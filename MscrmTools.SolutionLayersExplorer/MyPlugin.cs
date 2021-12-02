using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.SolutionLayersExplorer
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Solution Layers Explorer"),
        ExportMetadata("Description", "Search for active layers for your managed solutions"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAGVUExURWBgYG1ZWaI6OuQSE2xaWrAxMukODv8AAGJfX3xQUL8oKPcFBWFgYIRMTMwgIPcFBmlbW5RCQtwXF/4BAWhcXKA7O+MSEv0BAXNVVq8yMvMJCeUTE8QmJvsDA8UmJmReXolISdcaGoVLTNAeHvoEBGNeXoVLS9IdHf0CAmFhYXZ2drS0tPXHx/5UVP8NDfTFxrCwsHNzdHp7e8LDw/Pz8//////8/P7Ozv5YWP8GBvHx8b6/v3d3d2VlZYqLi9LS0v39/f/c3P5hYf8SEvz8/M3OzoeHh2RkZMrLy//9/f/Y2P5mZ/8JCfv7+8TExOPj4//r693d3XJycrKys/X19XFxcWtrbK2tru7u76mqqvLy809VXSw9VRcyWHaGnd7i6P7+/kxSXCQ4UwglTQMiTBk1XHCCmuPn60ZPWxoyUQwqU2h7lNbb4v39/gkmThMwV2N2kNre5AonTjBAVggnUFNohVJXXSs9VVhaXi4/VgwoTlVZXltcXzJCVxArT1hbXjVDVw4pT11eXzhFVxMtUFpcXzpHWByndOwAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAGqSURBVDhPdc/3P0JRGMfxQyJJVHZGoczsi2xll70yQnVLNg17F3+3c07fcJX3T895Pq9ePZdIZGTKZJkZeKTKkmfnUNnyLCwkFLnKPJaZPGWuAuskVb66AJUrUOerkJhCjVaH8k2n1RQiFxWXlGIrUVpSXERzWXkFFmlUlJcRPeZ/6EllFca0qqpJjcGYcmCSzmiooVeoauvqsZGor6tNfqrJ3NCI7bfGBrMJmZCm5pZWSxsK12Zp7+hsQiZd3T2C0NvXb0XNsfb39QrCwOAQq8Mjo2NCwrjNzrLdNo7FxOTUNJmZwIuanXM4nY65WTyp+QWyiBGWljDAMllZXcOcxtrqOr1iY9OF9x+uzQ12JbW+tY3dL9tb7NcJO7vuvf0DBO5gf8+9u4Ps8fpEUfQHDhGpw4CfrnxeD83BIzpyxyenZ6yenZ4cYyUeBck5Rubi8koQri4v8GRCJBzCyEWi0QhGLhQm5PqGnZCW7+aaX3l7d4+NxP3dLc/Mg/SPmFD4ATHh8ekZhXt+ekT48fL6hiq+vb5gKfUei7Mcj71jkerjMx7//MCDIeQLBOKmIOEJrOIAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#606060"),
        ExportMetadata("PrimaryFontColor", "White"),
        ExportMetadata("SecondaryFontColor", "White")]
    public class MyPlugin : PluginBase, IPayPalPlugin
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        public string DonationDescription => "Donation for Solution Layers Explorer";

        public string EmailAccount => "tanguy92@hotmail.com";

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}