using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsCore.Domain.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NewsCore.Tests.Common;

namespace NewsCore.Data.Tests
{
    [TestClass]
    public class NewsRepositoryTests
    {
        [TestMethod]
        public void GetNewsBlocks()
        {
            //using (var context = Helpers.GetNewsContext())
            //{
            //    context.Add(new NewsBlock()
            //    {
            //        ID = 1,
            //        Title = "x1",
            //        NewsContents = new[]
            //        {
            //            new NewsContent() { ContentType = NewsContent.NewsContentType.Text, ID =  1, Detail = "x1"}
            //        }
            //    });
            //    context.SaveChanges();
            //    var repo = new NewsRepository(context);

            //    var newsBlocks = repo.GetNewsBlocks();
            //    newsBlocks.Should().HaveCount(1);
            //}
        }

        [TestMethod]
        public void SaveNewsBlocks()
        {
            var newsBlock = CreateNewsBlock();
            var mockContext = CreateMockContext();
            var repo = new NewsRepository(mockContext.Object);

            repo.Save(newsBlock);

            mockContext.Object.NewsBlocks.Should().HaveCount(1);
        }

        private NewsBlock CreateNewsBlock()
        {
            var newsBlock = NewsDomainMocks.CreateNewsBlock("Title 01", "Detail01", "Detail02");

            return newsBlock;
        }

        private Mock<NewsContext> CreateMockContext()
        {
            var data = new List<NewsBlock>()
            {
                CreateNewsBlock()
            }.AsQueryable();

            var mockSet = new Mock<DbSet<NewsBlock>>();
            mockSet.As<IQueryable<NewsBlock>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<NewsBlock>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<NewsBlock>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<NewsBlock>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NewsContext>();
            mockContext.Setup(_ => _.NewsBlocks).Returns(mockSet.Object);

            return mockContext;
        }
    }
}
