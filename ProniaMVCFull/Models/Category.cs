using ProniaMVCFull.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVCFull.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
