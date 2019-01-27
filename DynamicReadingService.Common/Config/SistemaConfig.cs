using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Common.Config
{
    public class SistemaConfig
    {
        public string NomeSistema { get; set; }
        public string Versao { get; set; }
        public string Ambiente { get; set; }
        public string UrlWeb { get; set; }
        public string UrlWebApi { get; set; }
    }
}
