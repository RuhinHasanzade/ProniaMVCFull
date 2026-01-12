using Microsoft.AspNetCore.Mvc;

namespace ProniaMVCFull.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
