using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVCFull.Context;

namespace ProniaMVCFull.Areas.Admin.Controllers;
[Area("Admin")]

public class ProductController(AppDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var products = _context.Products.Include(p=> p.Category).ToList();
        return View(products);
    }




    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }


    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid == false)
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }


    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }



    
}
