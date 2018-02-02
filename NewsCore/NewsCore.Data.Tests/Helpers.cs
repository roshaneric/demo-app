using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsCore.Data.Tests
{
    internal class Helpers
    {
        public static NewsContext GetNewsContext()
        {
            var dbOptions = new DbContextOptionsBuilder<NewsContext>()
                .UseInMemoryDatabase("news-db").Options;
            return new NewsContext(dbOptions);
        }
    }
}
