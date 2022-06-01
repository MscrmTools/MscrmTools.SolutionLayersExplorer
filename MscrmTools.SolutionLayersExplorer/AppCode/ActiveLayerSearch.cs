using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    internal class ActiveLayerSearch
    {
        private readonly ExecuteMultipleRequest _bulk;
        private readonly CrmServiceClient _service;

        public ActiveLayerSearch(CrmServiceClient service)
        {
            _service = service;

            _bulk = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                }
            };
        }

        public void GetActiveLayers(List<LayerItem> items, BackgroundWorker bw, string componentType)
        {
            _bulk.Requests = new OrganizationRequestCollection();

            decimal progress = 0;
            int processed = 0;
            foreach (var item in items)
            {
                if (bw.CancellationPending) return;

                _bulk.Requests.Add(new RetrieveMultipleRequest
                {
                    Query = new QueryExpression("msdyn_componentlayer")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("msdyn_solutionname",ConditionOperator.Equal, "Active"),
                                new ConditionExpression("msdyn_solutioncomponentname",ConditionOperator.Equal, ((ComponentType)item.Record.GetAttributeValue<OptionSetValue>("componenttype").Value).ToString()),
                                new ConditionExpression("msdyn_componentid",ConditionOperator.Equal, item.Record.GetAttributeValue<Guid>("objectid")),
                            }
                        }
                    }
                });

                processed++;
                progress = (decimal)processed / items.Count * 100;

                bw.ReportProgress(Convert.ToInt32(progress), $"Loading active layers for {componentType}");

                if (_bulk.Requests.Count == 500)
                {
                    var bulkResp = (ExecuteMultipleResponse)_service.Execute(_bulk);
                    foreach (var response in bulkResp.Responses)
                    {
                        var request = (RetrieveMultipleRequest)_bulk.Requests[response.RequestIndex];
                        var objectId = (Guid)((QueryExpression)request.Query).Criteria.Conditions.Last().Values.First();

                        items.First(i => i.Record.GetAttributeValue<Guid>("objectid") == objectId).ActiveLayer = ((RetrieveMultipleResponse)response.Response).EntityCollection.Entities.FirstOrDefault();
                    }

                    _bulk.Requests.Clear();
                }
            }

            if (_bulk.Requests.Count > 0)
            {
                var bulkResp = (ExecuteMultipleResponse)_service.Execute(_bulk);
                foreach (var response in bulkResp.Responses)
                {
                    var request = (RetrieveMultipleRequest)_bulk.Requests[response.RequestIndex];
                    var objectId = (Guid)((QueryExpression)request.Query).Criteria.Conditions.Last().Values.First();

                    items.First(i => i.Record.GetAttributeValue<Guid>("objectid") == objectId).ActiveLayer = ((RetrieveMultipleResponse)response.Response).EntityCollection.Entities.FirstOrDefault();
                }
            }
        }
    }
}