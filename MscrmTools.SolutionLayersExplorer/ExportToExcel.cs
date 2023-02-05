using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Deployment;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MscrmTools.SolutionLayersExplorer.AppCode;
using System.Web.Services.Description;

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
                worker.ReportProgress(0, "Exporting entities translations...");
            }

            ExcelWorksheet sheet = file.Workbook.Worksheets.Add("Layers");
            //var et = new EntityTranslation();
            //et.Export(emds, lcids, sheet, settings);
            //StyleMutator.FontDefaults(sheet);

            int line = 1;

            foreach (LayerExcelRow row in layers)
            {
                int cell = 0;

                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionLayerName;

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
                            SolutionComponentName = layer.GetAttributeValue<string>("msdyn_solutioncomponentname"),
                            SolutionLayerName = layer.GetAttributeValue<string>("msdyn_solutionname"),
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
    }
}
