using DynamicReadingService.API.Resolver.System;
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
            services.AddTransient<ISystemResolver, SystemResolver>();

            return services;
        }
    }
}
