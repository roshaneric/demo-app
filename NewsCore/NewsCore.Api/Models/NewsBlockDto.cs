using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCore.Api.Models
{
    public class NewsBlockDto
    {
        public string Title { get; set; }
        public IEnumerable<NewsContentDto> Contents { get; set; }
    }

    public class NewsContentDto
    {
        public string Detail { get; set; }
    }
}
