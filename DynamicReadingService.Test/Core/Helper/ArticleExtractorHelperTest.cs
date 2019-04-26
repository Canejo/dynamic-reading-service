using DynamicReadingService.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Test.Core.Helper
{
    [TestClass]
    public class ArticleExtractorHelperTest
    {
        [TestMethod]
        public void ArticleExtractor_Success()
        {
            string url = "https://www.wuxiaworld.com/novel/lord-of-all-realms/chapter-1-an-unstable-situation";
            var result = ArticleExtractorHelper.Run(url);
            Assert.IsTrue(result != null && !string.IsNullOrWhiteSpace(result.Content));
        }
    }
}
