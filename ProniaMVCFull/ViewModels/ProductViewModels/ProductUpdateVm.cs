using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVCFull.ViewModels.ProductViewModels
{
    public class ProductUpdateVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Precision(10,2)]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? SKU { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; } = [];
        public IFormFile? MainImage { get; set; }

        public string? HoverImage { get; set; }
    }
}
