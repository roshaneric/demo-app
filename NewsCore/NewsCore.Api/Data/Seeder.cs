using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NewsCore.Data;
using NewsCore.Domain.Models;

namespace NewsCore.Api.Data
{
    public static class Seeder
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var newsBlocks = new[]
            {
                new NewsBlock()
                {
                    Title = "Title 1",
                    NewsContents = new[]
                    {
                        new NewsContent()
                        {
                            ContentType = NewsContent.NewsContentType.Text,
                            Detail = "Some Text Content 01."
                        },
                        new NewsContent()
                        {
                            ContentType = NewsContent.NewsContentType.Text,
                            Detail = "Some Text Content 02."
                        }
                    }
                },
                new NewsBlock()
                {
                    Title = "Title 2",
                    NewsContents = new[]
                    {
                        new NewsContent()
                        {
                            ContentType = NewsContent.NewsContentType.Text,
                            Detail = "Some Text Content 03."
                        }
                    }
                }
            };

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<NewsContext>();

                if (!context.NewsBlocks.Any())
                {
                    context.NewsBlocks.AddRange(newsBlocks);
                    context.SaveChanges();
                }
            }
        }
    }
}
