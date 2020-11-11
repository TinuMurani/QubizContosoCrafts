using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;

        public StocksController(IStockRepository stockRepository, IProductRepository productRepository)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
        }


        // GET: <StocksController>
        [HttpGet]
        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockRepository.GetAllStocks();
        }

        // GET <StocksController>/5
        [HttpGet("{id}")]
        public double GetStocksById(int productId)
        {
            return _stockRepository.GetStocksForProduct(productId);
        }

        // POST <StocksController>
        [HttpPost]
        public ActionResult SubmitStocksForProduct(Stock stock)
        {
            if (stock is null)
            {
                return NotFound();
            }

            try
            {
                _stockRepository.SubmitStockForProduct(stock);
            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
