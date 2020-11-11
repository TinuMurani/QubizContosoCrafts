using ContosoCrafts.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _appDbContext;

        public RatingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Rating> GetRatingsOfProduct(int productId)
        {
            return _appDbContext.Ratings.ToList().FindAll(x => x.ProductId == productId);
        }

        public void AddRatingToProduct(int productId, int rating)
        {
            try
            {
                _appDbContext.Add(new Rating { ProductId = productId, ProductRating = rating });
                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
