using DynamicReadingService.API.Infrastructure.GraphQL;
using DynamicReadingService.Core.Config;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicReadingService.API.Type.Sistema
{
    public class SistemaType : ObjectGraphType<SistemaConfig>, IGraphQLType
    {
        public SistemaType()
        {
            Field(x => x.NomeSistema);
            Field(x => x.UrlWeb);
            Field(x => x.UrlWebApi);
            Field(x => x.Ambiente);
            Field(x => x.Versao);
        }
    }
}
