using ContosoCrafts.WebSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _appDbContext.Products.ToList();
        }

        public void InsertRange(IEnumerable<Product> products)
        {
            _appDbContext.Products.AddRange(products);
            _appDbContext.SaveChanges();
        }

    }
}
