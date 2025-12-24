using ProniaMVCFull.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVCFull.Models
{
    public class ProductImage:BaseEntity
    {
        public int ProductId { get; set; }
        public Product product { get; set; }

        [Required]
        [MaxLength(512)]
        public string ImageUrl { get; set; }
    }
}
