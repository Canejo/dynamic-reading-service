using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Core.Models.ArticleAggregate
{
    public class ArticleResult
    {
        public string Content { get; internal set; }
        public string Title { get; internal set; }
    }
}
