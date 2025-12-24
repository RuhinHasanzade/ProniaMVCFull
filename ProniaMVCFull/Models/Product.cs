using Microsoft.EntityFrameworkCore;
using ProniaMVCFull.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVCFull.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Precision(10,2)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public string? MainImgUrl { get; set; }

        [Required]
        public string? HoverImgUrl { get; set; }


    }
}
