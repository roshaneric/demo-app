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

        protected NewsContent()
        {
        }

        public NewsContent(string detail)
        {
            ContentType = NewsContentType.Text;
            Detail = detail;
        }

        public int ID { get; protected set; }
        public int NewsBlockID { get; protected set; }
        public NewsContentType ContentType { get; protected set; }
        public string Detail { get; protected set; }
    }
}
