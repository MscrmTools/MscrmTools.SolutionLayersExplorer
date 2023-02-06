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
        private readonly List<LayerExcelRow> _layers;
        public IOrganizationService Service { get; }
        public string FilePath { get; }


        public ExportToExcel(IOrganizationService service, string filePath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            Service = service;
            FilePath = filePath;
            _layers = new List<LayerExcelRow>();
        }


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

            int line = 0;
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

            foreach (LayerExcelRow row in _layers)
            {
                cell = 0;

                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.ComponentLayerId.ToString();
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.ComponentId.ToString();
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionComponentName;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionLayerName;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.SolutionVersion;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.PublisherName;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.OverWriteTime.ToString("u");
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.Order;
                ZeroBasedSheet.Cell(sheet, line, cell++).Value = row.Name;

                line++;
            }

            file.Save();
        }

        public void GetLayers(List<Guid> componentIds, ComponentType componentType, string progressMessage, BackgroundWorker bw)
        {
            var requests = componentIds.Select(i => new RetrieveMultipleRequest
            {
                Query = new QueryExpression("msdyn_componentlayer")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                            {
                                new ConditionExpression("msdyn_solutioncomponentname",ConditionOperator.Equal, componentType.ToString()),
                                new ConditionExpression("msdyn_componentid",ConditionOperator.Equal, i)
                            }
                    }
                }
            }).ToList();
            var bulkResponse = Execute(requests, progressMessage, bw);

            foreach (ExecuteMultipleResponseItem response in bulkResponse)
            {
                if (response.Response != null)
                {
                    var layerList = ((RetrieveMultipleResponse)response.Response).EntityCollection.Entities;

                    foreach (Entity layer in layerList)
                    {
                        _layers.Add(new LayerExcelRow
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
                        });
                    }
                }
                else if (response.Fault != null)
                {
                    var request = (OrganizationRequest)requests[response.RequestIndex];

                    _layers.Add(new LayerExcelRow
                    {
                        ComponentLayerId = Guid.Empty,
                        ComponentId = Guid.Empty,
                        SolutionComponentName = request.RequestName,
                        SolutionLayerName = string.Empty,
                        SolutionVersion = string.Empty,
                        PublisherName = string.Empty,
                        OverWriteTime = DateTime.UtcNow,
                        Order = 0,
                        Name = response.Fault.Message
                    });
                }
            }

            bw.ReportProgress(100, $"{progressMessage}: Done");
        }

        private List<ExecuteMultipleResponseItem> Execute(List<RetrieveMultipleRequest> executeMultipleRequests, string progressMessage, BackgroundWorker bw)
        {
            int batchSize = 500;
            int batchCount = 0;

            ExecuteMultipleRequest bulkRequest = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                }
            };

            List<ExecuteMultipleResponseItem> bulkResponse = new List<ExecuteMultipleResponseItem>();
            List<RetrieveMultipleRequest> batch = executeMultipleRequests.Take(batchSize).ToList();

            do
            {
                if (bw.CancellationPending) return bulkResponse;

                bw.ReportProgress(0, $@"{progressMessage} ({batchCount * batchSize + batch.Count}/{executeMultipleRequests.Count})...");

                bulkRequest.Requests.Clear();
                bulkRequest.Requests.AddRange(batch);

                var responses = ((ExecuteMultipleResponse)Service.Execute(bulkRequest)).Responses;
                bulkResponse.AddRange(responses);

                batch = executeMultipleRequests.Skip(++batchCount * batchSize).Take(batchSize).ToList();
            }
            while (batch.Count > 0);

            return bulkResponse;
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
