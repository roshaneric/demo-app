﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsCore.Domain.Interfaces;
using NewsCore.Domain.Models;

namespace NewsCore.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context;

        public NewsRepository(NewsContext context)
        {
            _context = context;
        }

        public IEnumerable<NewsBlock> GetNewsBlocks()
        {
            return _context.NewsBlocks.ToArray();
        }
    }
}
