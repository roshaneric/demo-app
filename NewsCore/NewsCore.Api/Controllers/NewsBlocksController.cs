using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsCore.Api.Interfaces;
using NewsCore.Api.Models;

namespace NewsCore.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/news-blocks")]
    public class NewsBlocksController : Controller
    {
        private readonly INewsService _newsService;

        public NewsBlocksController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/news-block
        [HttpGet]
        public IEnumerable<NewsBlock> Get()
        {
            return _newsService.GetNewsBlocks();
        }

        // GET: api/news-blocks/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/news-blocks
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/news-blocks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
