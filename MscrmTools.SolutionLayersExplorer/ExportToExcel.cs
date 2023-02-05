using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.SolutionLayersExplorer.AppCode;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace MscrmTools.SolutionLayersExplorer
{
    public class ExportToExcel
    {
        private List<LayerExcelRow> layers;

        public ExportToExcel(IOrganizationService service, string filePath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            Service = service;
            FilePath = filePath;
        }

        public IOrganizationService Service { get; }
        public string FilePath { get; }

        public void Export(BackgroundWorker worker = null)
        {
            var file = new ExcelPackage
            {
                File = new FileInfo(FilePath)
            };

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Exporting components layers...");
            }

            ExcelWorksheet sheet = file.Workbook.Worksheets.Add("Layers");

            int line = 1; 
            int cell = 0;

            // Header
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "Component Layer Id";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "Component Id";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "Solution Component Name";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "SolutionLayerName";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "SolutionVersion";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "PublisherName";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "OverWriteTime";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "Order";
            ZeroBasedSheet.Cell(sheet, line, cell++).Value = "Name";
            line++;

            foreach (LayerExcelRow row in layers)
            {
                cell = 0;

                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.ComponentLayerId.ToString();
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.ComponentId.ToString();
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionComponentName;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionLayerName;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionVersion;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.PublisherName;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.OverWriteTime.ToShortTimeString();
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.Order;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.Name;

                line++;
            }

            file.Save();
        }

        public void GetLayers(List<LayerItem> items, string componentType, BackgroundWorker bw)
        {
            ExecuteMultipleRequest bulkRequest = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                }
            };

            decimal progress = 0;
            int processed = 0;
            bool needPrecision = false;
            layers = new List<LayerExcelRow>();

            foreach (var item in items)
            {
                if (bw.CancellationPending) return;

                bulkRequest.Requests.Add(new RetrieveMultipleRequest
                {
                    Query = new QueryExpression("msdyn_componentlayer")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("msdyn_solutioncomponentname",ConditionOperator.Equal, ((ComponentType)item.Record.GetAttributeValue<OptionSetValue>("componenttype").Value).ToString()),
                                new ConditionExpression("msdyn_componentid",ConditionOperator.Equal, item.Record.GetAttributeValue<Guid>("objectid")),
                            }
                        }
                    }
                });

                processed++;
                progress = (decimal)processed / items.Count * 100;

                if (bulkRequest.Requests.Count == 200)
                {
                    if (progress < 100 || needPrecision)
                    {
                        bw.ReportProgress(Convert.ToInt32(progress), $"Loading active layers for {componentType} ({Convert.ToInt32(progress)}%)...");
                        needPrecision = true;
                    }

                    var bulkResp = (ExecuteMultipleResponse)Service.Execute(bulkRequest);

                    foreach (var response in bulkResp.Responses)
                    {
                        var request = (RetrieveMultipleRequest)bulkRequest.Requests[response.RequestIndex];
                        var objectId = (Guid)((QueryExpression)request.Query).Criteria.Conditions.Last().Values.First();

                        var objectItem = items.First(i => i.Record.GetAttributeValue<Guid>("objectid") == objectId);

                        objectItem.Layers = ((RetrieveMultipleResponse)response.Response).EntityCollection.Entities;
                    }

                    bulkRequest.Requests.Clear();
                }
            }

            if (bulkRequest.Requests.Count > 0)
            {
                if (progress < 100 || needPrecision)
                {
                    bw.ReportProgress(Convert.ToInt32(progress), $"Loading active layers for {componentType} ({Convert.ToInt32(progress)}%)...");
                    needPrecision = true;
                }

                var bulkResp = (ExecuteMultipleResponse)Service.Execute(bulkRequest);

                foreach (var response in bulkResp.Responses)
                {
                    var request = (RetrieveMultipleRequest)bulkRequest.Requests[response.RequestIndex];
                    var objectId = (Guid)((QueryExpression)request.Query).Criteria.Conditions.Last().Values.First();

                    var item = items.First(i => i.Record.GetAttributeValue<Guid>("objectid") == objectId);
                    var layerList = ((RetrieveMultipleResponse)response.Response).EntityCollection.Entities;

                    foreach (Entity layer in layerList)
                    {
                        layers.Add(new LayerExcelRow
                        {
                            ComponentLayerId = layer.GetAttributeValue<Guid>("msdyn_componentlayerid"),
                            ComponentId = layer.GetAttributeValue<Guid>("msdyn_componentid"),
                            SolutionComponentName = layer.GetAttributeValue<string>("msdyn_solutioncomponentname"),
                            SolutionLayerName = layer.GetAttributeValue<string>("msdyn_solutionname"),
                            SolutionVersion = layer.GetAttributeValue<string>("msdyn_solutionversion"),
                            PublisherName = layer.GetAttributeValue<string>("msdyn_publishername"),
                            OverWriteTime = layer.GetAttributeValue<DateTime>("msdyn_overwritetime"),
                            Order = layer.GetAttributeValue<int>("msdyn_order"),
                            Name = layer.GetAttributeValue<string>("msdyn_name")
                        }); ;
                    }
                }
            }
        }
    }

    internal class LayerExcelRow
    {
        public Guid ComponentLayerId { get; set; }
        public Guid ComponentId { get; set; }
        public string SolutionComponentName { get; set; }
        public string SolutionLayerName { get; set; }        
        public string SolutionVersion { get; set; }
        public string PublisherName { get; set; }
        public DateTime OverWriteTime { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }

    }
}
