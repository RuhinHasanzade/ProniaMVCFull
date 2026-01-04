using Microsoft.EntityFrameworkCore;

namespace ProniaMVCFull.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<Benefit> Benefits {  get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ProductTag> ProductTags { get; set; }

    }

}
