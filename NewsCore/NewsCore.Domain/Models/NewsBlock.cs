using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace NewsCore.Domain.Models
{
    public class NewsBlock
    {
        protected NewsBlock()
        {
            NewsContentList = new List<NewsContent>();
        }

        public NewsBlock(string title)
        {
            Title = title;
            NewsContentList = new List<NewsContent>();
        }

        public int ID { get; protected set; }
        public string Title { get; protected set; }
        protected List<NewsContent> NewsContentList { get; set;  }
        public IReadOnlyCollection<NewsContent> NewsContents => NewsContentList.AsReadOnly();

        public void AddNewsContents(IEnumerable<NewsContent> newsContents)
        {
            NewsContentList.AddRange(newsContents);
        }

        public class PropertyAccessExpressions
        {
            public static readonly Expression<Func<NewsBlock, IEnumerable<NewsContent>>> NewsContents = _ => _.NewsContentList;
        }
    }
}
