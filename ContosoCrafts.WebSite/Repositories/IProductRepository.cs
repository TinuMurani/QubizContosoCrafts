using ContosoCrafts.WebSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void InsertRange(IEnumerable<Product> products);
    }
}