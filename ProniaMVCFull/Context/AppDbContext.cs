using Microsoft.EntityFrameworkCore;

namespace ProniaMVCFull.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<Benefit> Benefits {  get; set; }
    }

}
