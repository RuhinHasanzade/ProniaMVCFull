
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

        
        if (ModelState.IsValid == false)
        {
            return View();
        }

       
        _context.Benefits.Add(benefit);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        Benefit benefit = _context.Benefits.Find(id);

        if (benefit is null)
        {
            return NotFound();
        }

        _context.Benefits.Remove(benefit);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
