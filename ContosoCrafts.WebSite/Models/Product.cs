using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoCrafts.WebSite.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Maker { get; set; }

        public string Image { get; set; }
        public string Url { get; set; }
        
        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
