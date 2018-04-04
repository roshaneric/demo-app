using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsCore.Domain.Models
{
    public class NewsBlock
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public IEnumerable<NewsContent> NewsContents { get; set; }
    }
}
