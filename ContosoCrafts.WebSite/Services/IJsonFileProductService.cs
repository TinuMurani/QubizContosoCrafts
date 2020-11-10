using ContosoCrafts.WebSite.Models;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Services
{
    public interface IJsonFileProductService
    {
        void AddRating(int productId, int rating);
        IEnumerable<Product> GetProducts();
    }
}