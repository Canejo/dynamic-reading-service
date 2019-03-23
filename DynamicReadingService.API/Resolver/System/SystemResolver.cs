using DynamicReadingService.API.Infrastructure.GraphQL;
using DynamicReadingService.API.Type.System;
using DynamicReadingService.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Resolver.System
{
    public class SystemResolver : ISystemResolver
    {
        private readonly SystemConfig _sistemaConfig;

        public SystemResolver(SystemConfig sistemaConfig)
        {
            _sistemaConfig = sistemaConfig;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            NewMethod(graphQLQuery);
        }

        private void NewMethod(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<SystemType>(
                "system",
                resolve: context => _sistemaConfig);
        }
    }
}
