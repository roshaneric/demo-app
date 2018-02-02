using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsCore.Api.Models;
using NewsCore.Domain.Models;

namespace NewsCore.Api.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsBlockDto> GetNewsBlocks();
    }
}
