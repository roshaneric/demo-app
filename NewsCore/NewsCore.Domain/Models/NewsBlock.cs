using System;
using System.Collections.Generic;
using System.Text;

namespace NewsCore.Domain.Models
{
    public class NewsBlock
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public IEnumerable<NewsContent> NewsContents { get; set; }
    }
}
