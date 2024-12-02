using graph.Entities;
using HotChocolate.Data.Projections.Context;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using repository.Models;
using System.Linq.Dynamic.Core;

namespace graph.QueryTypes
{
    public class QueryBase
    {
        protected Connection<T> AggregateData<T>(IResolverContext context, AdventureworksContext dbContext, IQueryable<ICommon> query) where T : new()
        {
            // check if the request is values (NO Nodes!)
            var query_fields = CheckAggregationData(context);

            // apply filter
            query = query.Filter(context);

            // row level security
            var queryFinal = query;

            // select requested fields
            string select_fields = $"new {{ Id, {string.Join(",", query_fields)}}}";

            // get the data
            var dataset = queryFinal
                            .Select(typeof(T), select_fields)
                            .ToDynamicList<T>();

            // prepate the connection without pagination
            var edges = new List<Edge<T>>();
            foreach (var row in dataset)
            {
                var edge = new Edge<T>(row, "Id");
                edges.Add(edge);
            }

            var pageInfo = new ConnectionPageInfo(false, false, null, null);
            var connection = new Connection<T>(edges, pageInfo, 0);

            return connection;
        }

        private static List<string> validOperations = new List<string>() { "sum", "avg", "min", "max" };

        private IEnumerable<string> CheckAggregationData(IResolverContext context)
        {
            var fields = new List<string>();
            var selectedFields = context.GetSelectedField();

            foreach (FieldNode item in selectedFields.Selection.SelectionSet.Selections)
            {
                var nodeName = item.Name.Value;
                if (validOperations.Contains(nodeName))
                {
                    var requestedSummaryFields = (List<IValueNode>)(item.Arguments[0].Value.Value);
                    foreach (var requestedSummaryField in requestedSummaryFields)
                    {
                        fields.Add(requestedSummaryField.Value.ToString());
                    }
                }
                else if (string.Compare(nodeName, "Nodes", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    throw new ArgumentException("Invalid nodes fields: only aggregates allowed");
                }
            }

            return fields.Distinct();
        }
    }
}
