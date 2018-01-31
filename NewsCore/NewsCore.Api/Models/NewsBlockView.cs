using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCore.Api.Models
{
    public class NewsBlockView
    {
        public string Title { get; set; }
        public IEnumerable<string> Contents { get; set; }
    }
}
