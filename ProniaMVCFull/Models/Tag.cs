using ProniaMVCFull.Models.Common;

namespace ProniaMVCFull.Models
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
