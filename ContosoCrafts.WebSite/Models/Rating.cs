using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int ProductRating { get; set; }
    }
}
