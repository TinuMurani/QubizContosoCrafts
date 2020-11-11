using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public Product GetProduct(int? id)
        {
            if (_productRepository.GetProduct(id.Value) is null)
            {
                return new Product();
            }

            return _productRepository.GetProduct(id.Value);
        }

        [HttpPost]
        public ActionResult PostProduct([Bind("Maker,Image,Url,Title,Description")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _productRepository.AddProduct(product);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct([Bind("Id,Maker,Image,Url,Title,Description")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int? id)
        {
            if (_productRepository.GetProducts().ToList().Find(x => x.Id == id.Value) is null)
            {
                return BadRequest();
            }

            _productRepository.DeleteProduct(_productRepository.GetProduct(id.Value));

            return Ok();
        }

        [HttpPost]
        [Route("Rate")]
        public ActionResult AddRating(int productId, int rating)
        {
            if (_productRepository.GetProduct(productId) is null)
            {
                return NotFound();
            }

            try
            {
                _ratingRepository.AddRatingToProduct(productId, rating);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("Rate")]
        public IEnumerable<Rating> GetRatingByProductId(int productId)
        {
            if (_productRepository.GetProduct(productId) is null)
            {
                return new List<Rating>();
            }

            return _ratingRepository.GetRatingsOfProduct(productId);
        }
    }
}
