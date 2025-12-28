using Microsoft.AspNetCore.Mvc;
using ProniaMVCFull.Context;

namespace ProniaMVCFull.Controllers
{
    public class ShopController(AppDbContext _context) : Controller
    {

        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
    }
}
