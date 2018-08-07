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
            var testBuilder = new TestBuilder();
            var testData = testBuilder.CreateNewsBlocks();

            var repo = testBuilder.SetupMockData(testData).Build();
            var newsBlocks = repo.GetNewsBlocks();
            newsBlocks.Should().BeEquivalentTo(testData);
        }

        [TestMethod]
        public void SaveNewsBlocks()
        {
            var testBuilder = new TestBuilder();
            var repo = testBuilder.SetupMockData(new List<NewsBlock>()).Build();

            var newsBlock = testBuilder.CreateNewsBlock();
            repo.Save(newsBlock);

            testBuilder.MockSet.Verify(_ => _.Add(newsBlock), Times.Once());
            testBuilder.MockContext.Verify(_ => _.SaveChanges(), Times.Once);
        }

        private class TestBuilder
        {
            public Mock<NewsContext> MockContext { get; }
            public Mock<DbSet<NewsBlock>> MockSet { get; }

            public TestBuilder()
            {
                MockSet = new Mock<DbSet<NewsBlock>>();
                MockContext = new Mock<NewsContext>();
            }

            public List<NewsBlock> CreateNewsBlocks()
            {
                return new List<NewsBlock>()
                {
                    CreateNewsBlock()
                };
            }
            
            public NewsBlock CreateNewsBlock()
            {
                var newsBlock = NewsDomainMocks.CreateNewsBlock("Title 01", "Detail01", "Detail02");

                return newsBlock;
            }

            public TestBuilder SetupMockData(List<NewsBlock> data)
            {
                data = data ?? new List<NewsBlock>()
                {
                    CreateNewsBlock()
                };

                var queryableData = data.AsQueryable();

                MockSet.As<IQueryable<NewsBlock>>().Setup(m => m.Provider).Returns(queryableData.Provider);
                MockSet.As<IQueryable<NewsBlock>>().Setup(m => m.Expression).Returns(queryableData.Expression);
                MockSet.As<IQueryable<NewsBlock>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
                MockSet.As<IQueryable<NewsBlock>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());

                MockContext.Setup(_ => _.NewsBlocks).Returns(MockSet.Object);

                return this;
            }

            public NewsRepository Build()
            {
                return new NewsRepository(MockContext.Object);
            }
        }
    }
}
