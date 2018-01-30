using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using NewsCore.Api.Interfaces;
using NewsCore.Api.Models;

namespace NewsCore.Api.Services
{
    public class NewsService : INewsService
    {
        private readonly Domain.Interfaces.INewsService _service;

        public NewsService(Domain.Interfaces.INewsService service)
        {
            _service = service;
        }

        public IEnumerable<NewsBlock> GetNewsBlocks()
        {
            return _service.GetNewsBlocks().Select(_ => new NewsBlock()
            {
               ID = _.ID, Title = _.Title, Content = _.Content
            });
        }
    }
}
