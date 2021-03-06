﻿using System;
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

        public IEnumerable<NewsBlockDto> GetNewsBlocks()
        {
            var models =  _service.GetNewsBlocks().Select(_ => new NewsBlockDto()
            {
                Title = _.Title,
                Contents = _.NewsContents.Select(c => new NewsContentDto() { Detail = c.Detail})
            });

            return models;
        }

        public void Save(NewsBlockDto dto)
        {
            var newsBlock = new NewsBlock(dto.Title);
            newsBlock.AddNewsContents(dto.Contents.Select(_ => new NewsContent(_.Detail)).ToArray());
            _service.Save(newsBlock);
        }
    }
}
