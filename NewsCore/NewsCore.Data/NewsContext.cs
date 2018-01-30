using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NewsCore.Domain.Models;

namespace NewsCore.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext()
        {}

        public NewsContext(DbContextOptions<NewsContext> options)
         : base(options)
        {}

        public DbSet<NewsBlock> NewsBlocks { get; set; }
    }
}
