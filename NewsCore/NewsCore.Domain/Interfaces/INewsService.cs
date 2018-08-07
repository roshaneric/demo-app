using System;
using System.Collections.Generic;
using System.Text;
using NewsCore.Domain.Models;

namespace NewsCore.Domain.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsBlock> GetNewsBlocks();
        void Save(NewsBlock newsBlock);
    }
}
