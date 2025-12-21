using Microsoft.EntityFrameworkCore;
using ProniaMVCFull.Context;

namespace ProniaMVCFull
{
    public class Program
    {
        public static void Main(string[] args)  
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            app.MapDefaultControllerRoute();
            app.UseStaticFiles();
            app.Run();
        }
    }
}
