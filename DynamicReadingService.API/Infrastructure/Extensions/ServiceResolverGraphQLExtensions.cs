using DynamicReadingService.API.Resolver.Sistema;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Infrastructure.Extensions
{
    public static class ServiceResolverGraphQLExtensions
    {
        public static IServiceCollection AddResolverGraphQL(this IServiceCollection services)
        {
            services.AddTransient<ISistemaResolver, SistemaResolver>();

            return services;
        }
    }
}
