using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Infrastructure.GraphQL
{
    public class GraphQLMutation : ObjectGraphType
    {
        public GraphQLMutation(IServiceProvider serviceProvider)
        {
            var type = typeof(IMutationResolver);
            var resolversTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var resolverType in resolversTypes)
            {
                var resolverTypeInterface = resolverType.GetInterfaces().Where(x => x != type).FirstOrDefault();
                if (resolverTypeInterface != null)
                {
                    if (serviceProvider.GetService(resolverTypeInterface) is IMutationResolver resolver)
                        resolver.Resolve(this);
                }
            }
        }
    }
}
