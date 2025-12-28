using Microsoft.AspNetCore.Mvc;

namespace ProniaMVCFull.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
