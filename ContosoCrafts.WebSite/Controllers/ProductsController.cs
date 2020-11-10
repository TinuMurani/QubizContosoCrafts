using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Repositories;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductRepository productRepository, IRatingRepository ratingRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _ratingRepository = ratingRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //using (var jsonFileReader = System.IO.File.OpenText(Path.Combine(_webHostEnvironment.WebRootPath, "data", "products.json")))
            //{
            //    var productsFromJson = JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
            //        new JsonSerializerOptions
            //        {
            //            PropertyNameCaseInsensitive = true
            //        });

            //    var formattedProducts = new List<Product>();

            //    foreach (var product in productsFromJson)
            //    {
            //        formattedProducts.Add(new Product() { Maker = product.Maker, Title = product.Title, Description = product.Description, Image = product.Image, Url = product.Url });
            //    }

            //    _productRepository.InsertRange(formattedProducts);
            //}

            return _productRepository.GetProducts();
        }

        [HttpGet]
        [Route("Rate")]
        public ActionResult Get(
            [FromQuery] int ProductId,
            [FromQuery] int Rating)
        {
            _ratingRepository.AddRatingToProduct(ProductId, Rating);

            return Ok();
        }
    }
}
