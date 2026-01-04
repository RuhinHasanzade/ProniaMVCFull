using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVCFull.ViewModels.ProductViewModels
{
    public class ProductCreateVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        public string? SKU { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select at least one tag.")]
        public List<int> TagIds { get; set; } = new List<int>();

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public string HoverImgUrl { get; set; }
    }

}
