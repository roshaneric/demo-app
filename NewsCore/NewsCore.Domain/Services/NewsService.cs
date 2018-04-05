using System;
using System.Collections.Generic;
using System.Text;
using NewsCore.Domain.Interfaces;
using NewsCore.Domain.Models;

namespace NewsCore.Domain.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<NewsBlock> GetNewsBlocks()
        {
            var newsBlocks = _repository.GetNewsBlocks();
            return newsBlocks;
        }

        public void Save(NewsBlock newsBlock)
        {
            _repository.Save(newsBlock);
        }
    }
}
