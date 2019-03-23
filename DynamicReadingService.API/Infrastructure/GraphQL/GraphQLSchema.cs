using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Infrastructure.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphQLQuery>();
            Mutation = resolver.Resolve<GraphQLMutation>();
        }
    }
}
