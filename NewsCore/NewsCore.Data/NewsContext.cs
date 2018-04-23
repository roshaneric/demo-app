using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NewsCore.Domain.Models;

namespace NewsCore.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options)
         : base(options)
        { }

        public virtual DbSet<NewsBlock> NewsBlocks { get; set; }
        public virtual DbSet<NewsContent> NewsContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsBlock>(entity =>
            {
                entity.HasKey(_ => _.ID);
                entity.Ignore(_ => _.NewsContents);
                entity.HasMany(NewsBlock.PropertyAccessExpressions.NewsContents).WithOne().HasForeignKey(_ => _.NewsBlockID);
            });

            modelBuilder.Entity<NewsContent>(entity =>
            {
                entity.HasKey(_ => _.ID);
            });
        }
    }
}
