using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Repositories;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductRepository _productRepository;

        //private readonly IJsonFileProductService _productService;

        //public IJsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IProductRepository productRepository)//, IJsonFileProductService productService)
        {
            _logger = logger;
            _productRepository = productRepository;
            //_productService = productService;
        }

        public void OnGet()
        {
            Products = _productRepository.GetProducts();
        }
    }
}
