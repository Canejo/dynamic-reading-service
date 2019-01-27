using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Business.Config
{
    public class TokenConfig
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Days { get; set; }
        public string Key { get; set; }
    }
}
