using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
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

        public void GetActiveLayers(List<LayerItem> items)
        {
            _bulk.Requests = new OrganizationRequestCollection();

            foreach (var item in items)
            {
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
            }

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