using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Infrastructure.GraphQL
{
    public class GraphQLQuery : ObjectGraphType
    {
        public GraphQLQuery(IServiceProvider serviceProvider)
        {
            var type = typeof(IQueryResolver);
            var resolversTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var resolverType in resolversTypes)
            {
                var resolverTypeInterface = resolverType.GetInterfaces().Where(x => x != type).FirstOrDefault();
                if (resolverTypeInterface != null)
                {
                    if (serviceProvider.GetService(resolverTypeInterface) is IQueryResolver resolver)
                        resolver.Resolve(this);
                }
            }
        }
    }
}
