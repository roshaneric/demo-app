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
            // TODO: Remove this after moving to SQL Server
            var maxBlockId = _context.NewsBlocks.Max(_ => _.ID);
            var maxContentId = _context.NewsContents.Max(_ => _.ID);
            newsBlock.ID = maxBlockId + 1;
            foreach (var content in newsBlock.NewsContents)
            {
                content.ID = maxContentId + 1;
            }

            _context.NewsBlocks.Add(newsBlock);
            _context.SaveChanges();
        }
    }
}
