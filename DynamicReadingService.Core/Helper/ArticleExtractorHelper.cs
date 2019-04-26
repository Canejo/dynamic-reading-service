using DynamicReadingService.Core.Models.ArticleAggregate;
using NReadability;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Core.Helper
{
    public static class ArticleExtractorHelper
    {
        public static ArticleResult Run(string url)
        {
            var transcoder = new NReadabilityWebTranscoder();
            var input = new WebTranscodingInput(url);

            var result = transcoder.Transcode(input);
            var articleResult = new ArticleResult()
            {
                Content = result.ExtractedContent,
                Title = result.ExtractedTitle
            };
            return articleResult;
        }
    }
}
