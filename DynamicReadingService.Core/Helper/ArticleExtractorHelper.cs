using NReadability;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Core.Helper
{
    public static class ArticleExtractorHelper
    {
        public static string Run(string url)
        {
            var transcoder = new NReadabilityWebTranscoder();
            var input = new WebTranscodingInput(url);

            var result = transcoder.Transcode(input);
            return result.ExtractedContent;
        }
    }
}
