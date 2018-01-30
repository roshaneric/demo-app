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
        public static IWebHost SeedTestData(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<NewsContext>())
                {
                        context.NewsBlocks.AddRange(
                            new NewsBlock() { ID =1, Title = "Title 1", Content = "Content 1"},
                            new NewsBlock() { ID =2, Title = "Title 2", Content = "Content 2"});
                        context.SaveChanges();
                }
            }
            return webhost;
        }
    }
}
