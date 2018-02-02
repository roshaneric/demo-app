using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsCore.Domain.Models;
using FluentAssertions;

namespace NewsCore.Data.Tests
{
    [TestClass]
    public class NewsRepositoryTests
    {
        [TestMethod]
        public void GetNewsBlocks()
        {
            using (var context = Helpers.GetNewsContext())
            {
                context.Add(new NewsBlock() { ID =1, Title = "x1", NewsContents = new[]
                {
                    new NewsContent() { ContentType = NewsContent.NewsContentType.Text, ID =  1, Detail = "x1"}
                }});
                context.SaveChanges();
                var repo = new NewsRepository(context);

                var newsBlocks = repo.GetNewsBlocks();
                newsBlocks.Should().HaveCount(1);
            }
        }
    }
}
