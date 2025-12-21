using Microsoft.AspNetCore.Mvc;
using ProniaMVCFull.Context;

namespace ProniaMVCFull.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var benefits = _context.Benefits.ToList();

            ViewBag.Benefits = benefits;
            return View();
        }
    }
}
