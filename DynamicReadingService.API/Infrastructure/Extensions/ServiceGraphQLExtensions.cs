using DynamicReadingService.API.Infrastructure.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Infrastructure.Extensions
{
    public static class ServiceGraphQLExtensions
    {
        public static IServiceCollection AddMyGraphQL(this IServiceCollection services)
        {
            var graphQLType = typeof(IGraphQLType);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => graphQLType.IsAssignableFrom(p) && p != graphQLType);

            foreach (var type in types)
            {
                services.AddSingleton(type);
            }

            services.AddResolverGraphQL();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<GraphQLQuery>();
            services.AddSingleton<GraphQLMutation>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            return services;
        }
    }
}
