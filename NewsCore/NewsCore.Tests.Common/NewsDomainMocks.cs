using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsCore.Domain.Models;

namespace NewsCore.Tests.Common
{
    public static class NewsDomainMocks
    {
        public static NewsContent CreateNewsContent(int id = 1, string detail = "")
        {
            var newsContent = new NewsContent(detail);
            newsContent.Set(_ => _.ID, id);

            return newsContent;
        }

        public static NewsBlock CreateNewsBlock(string title, params string[] details)
        {
            var newsContents = details.Select((detail, i) => CreateNewsContent(i + 1, detail)).ToList();
            
            var newsBlock = new NewsBlock(title);
            newsBlock.Set("NewsContentList", newsContents);

            return newsBlock;
        }

        public static NewsBlock CreateNewsBlock(string title, List<NewsContent> newsContents = null)
        {
            var newsBlock  = new NewsBlock(title);
            newsBlock.Set("NewsContentList", newsContents);

            return newsBlock;
        }
    }
}
