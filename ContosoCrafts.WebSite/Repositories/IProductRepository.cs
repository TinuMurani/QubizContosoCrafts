using ContosoCrafts.WebSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void InsertRange(IEnumerable<Product> products);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}