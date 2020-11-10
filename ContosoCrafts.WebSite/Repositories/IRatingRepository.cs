using ContosoCrafts.WebSite.Models;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Repositories
{
    public interface IRatingRepository
    {
        void AddRatingToProduct(int productId, int rating);
        IEnumerable<Rating> GetRatingsOfProduct(int productId);
    }
}