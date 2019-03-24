using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Core.Config
{
    public class SystemConfig
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public string UrlWeb { get; set; }
        public string UrlWebApi { get; set; }
        public string PocketKey { get; set; }
    }
}
