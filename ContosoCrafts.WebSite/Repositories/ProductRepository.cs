using ContosoCrafts.WebSite.Models;
using Microsoft.Data.SqlClient;
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

        public Product GetProduct(int id)
        {
            return _appDbContext.Products.Find(id);
        }

        public void InsertRange(IEnumerable<Product> products)
        {
            _appDbContext.Products.AddRange(products);
            _appDbContext.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _appDbContext.Products.Update(product);
                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
