using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using NewsCore.Api.Interfaces;
using NewsCore.Api.Models;
using NewsCore.Domain.Models;

namespace NewsCore.Api.Services
{
    public class NewsService : INewsService
    {
        private readonly Domain.Interfaces.INewsService _service;

        public NewsService(Domain.Interfaces.INewsService service)
        {
            _service = service;
        }

        public IEnumerable<NewsBlockView> GetNewsBlocks()
        {
            var models =  _service.GetNewsBlocks().Select(_ => new NewsBlockView()
            {
                Title = _.Title,
                Contents = _.NewsContents.Select(c => c.Content)
            });

            return models;
        }
    }
}
