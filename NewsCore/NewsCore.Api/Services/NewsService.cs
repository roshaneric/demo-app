using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsCore.Api.Interfaces;
using NewsCore.Api.Models;

namespace NewsCore.Api.Services
{
    public class NewsService : INewsService
    {
        public IEnumerable<NewsBlock> GetNewsBlocks()
        {
            return new[]
            {
                new NewsBlock() { ID = 1, Title = "This is a title 1.", Content="This is content of title one."},
                new NewsBlock() { ID = 1, Title = "This is a title 2.", Content="This is content of title two."},
            };
        }
    }
}
