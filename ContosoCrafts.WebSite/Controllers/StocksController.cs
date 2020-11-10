using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IJsonFileStockService _stockService;

        public StocksController(IJsonFileStockService _stockService)
        {
            _stockService = _stockService;
        }


        // GET: <StocksController>
        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return _stockService.GetStocks();
        }

        // GET <StocksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <StocksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <StocksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <StocksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
