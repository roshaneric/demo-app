using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NewsCore.Data;
using NewsCore.Domain.Models;

namespace NewsCore.Api.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<NewsContext>())
                {
                    context.NewsBlocks.AddRange(
                        new NewsBlock()
                        {
                            ID = 1,
                            Title = "Title 1",
                            NewsContents = new[]
                            {
                                new NewsContent()
                                {
                                    ID = 1,
                                    ContentType = NewsContent.NewsContentType.Text,
                                    Content = "Some Text Content 01."
                                },
                                new NewsContent()
                                {
                                    ID = 2,
                                    ContentType = NewsContent.NewsContentType.Text,
                                    Content = "Some Text Content 02."
                                }
                            }
                        },
                        new NewsBlock()
                        {
                            ID = 2,
                            Title = "Title 2",
                            NewsContents = new[]
                            {
                                new NewsContent()
                                {
                                    ID = 3,
                                    ContentType = NewsContent.NewsContentType.Text,
                                    Content = "Some Text Content 03."
                                }
                            }
                        }
                    );
                    context.SaveChanges();
                }
            }
            return webhost;
        }
    }
}
