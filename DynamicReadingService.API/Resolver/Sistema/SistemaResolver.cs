using DynamicReadingService.API.Infrastructure.GraphQL;
using DynamicReadingService.API.Type.Sistema;
using DynamicReadingService.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Resolver.Sistema
{
    public class SistemaResolver : ISistemaResolver
    {
        private readonly SistemaConfig _sistemaConfig;

        public SistemaResolver(SistemaConfig sistemaConfig)
        {
            _sistemaConfig = sistemaConfig;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<SistemaType>(
                "sistema",
                resolve: context => _sistemaConfig);
        }
    }
}
