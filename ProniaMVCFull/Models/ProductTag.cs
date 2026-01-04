using ProniaMVCFull.Models.Common;

namespace ProniaMVCFull.Models
{
    public class ProductTag : BaseEntity
    {
        public Tag Tag { get; set; }
        public int TagId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
