using System;
using System.Collections.Generic;
using System.Text;

namespace NewsCore.Domain.Models
{
    public class NewsContent
    {
        public enum NewsContentType
        {
            Text = 0,
            Picture = 1,
            Video = 2
        }

        public int ID { get; set; }
        public int NewsBlockID { get; set; }
        public NewsBlock NewsBlock { get; set; }
        public NewsContentType ContentType { get; set; }
        public string Detail { get; set; }
    }
}
