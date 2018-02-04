using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
            var blocks = _context.NewsBlocks.Include(b => b.NewsContents).ToArray();
            return blocks;
        }

        public void Save(NewsBlock newsBlock)
        {
            _context.NewsBlocks.Add(newsBlock);
            _context.SaveChanges();
        }
    }
}
