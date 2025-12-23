
using Microsoft.AspNetCore.Mvc;
using ProniaMVCFull.Context;

[Area("Admin")]
public class BenefitController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var benefits = _context.Benefits.ToList();
        return View(benefits);   
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Benefit benefit)
    {
        _context.Benefits.Add(benefit);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
