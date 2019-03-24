using DynamicReadingService.API.Infrastructure.GraphQL;
using DynamicReadingService.Core.Config;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Type.System
{
    public class SystemType : ObjectGraphType<SystemConfig>, IGraphQLType
    {
        public SystemType()
        {
            Field(x => x.Name);
            Field(x => x.UrlWeb);
            Field(x => x.UrlWebApi);
            Field(x => x.Environment);
            Field(x => x.Version);
            Field(x => x.PocketKey); 
        }
    }
}
