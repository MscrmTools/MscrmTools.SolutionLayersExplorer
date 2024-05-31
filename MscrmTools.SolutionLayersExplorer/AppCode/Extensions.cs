using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    public static class Extensions
    {
        public static List<ListViewItem> GetCheckedOrSelectedItems(this ListView listView)
        {
            var checkedItems = listView.CheckedItems.Cast<ListViewItem>().ToList();
            if (checkedItems.Count > 0) return checkedItems;

            return listView.SelectedItems.Cast<ListViewItem>().ToList();
        }

        public static List<EntityMetadata> GetTablesById(this IOrganizationService service, Guid[] metadataIds, string[] entitiesProperties, string[] attributeProperties, string[] relationshipProperties)
        {
            var query = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression(entitiesProperties),
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression(attributeProperties),
                },
                RelationshipQuery = new RelationshipQueryExpression
                {
                    Properties = new MetadataPropertiesExpression(relationshipProperties)
                },
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("MetadataId", MetadataConditionOperator.In, metadataIds)
                    }
                }
            };

            var response = (RetrieveMetadataChangesResponse)service.Execute(new RetrieveMetadataChangesRequest { Query = query });

            return response.EntityMetadata.ToList();
        }

        /// <summary>
        /// Break a list of items into chunks of a specific size
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            if (chunksize <= 0) throw new ArgumentException("Chunk size must be greater than zero.", "chunksize");
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }

    }
}