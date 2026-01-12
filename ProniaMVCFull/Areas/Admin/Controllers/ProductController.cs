using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVCFull.Context;
using ProniaMVCFull.ViewModels.ProductViewModels;

namespace ProniaMVCFull.Areas.Admin.Controllers;
[Area("Admin")]

public class ProductController(AppDbContext _context , IWebHostEnvironment _envoriement) : Controller
{
    public IActionResult Index()
    {
        var products = _context.Products.Include(p=> p.Category).ToList();
        return View(products);
    }




    [HttpGet]
    public IActionResult Create()
    {
        SendSelectedDataWithViewBag();
        return View();
    }


    [HttpPost]
    public IActionResult Create(ProductCreateVm productCreateDto)
    {
        if (ModelState.IsValid == false)
        {
            SendSelectedDataWithViewBag();
            return View(productCreateDto);
        }

        if(!productCreateDto.Image.ContentType.Contains("image"))
        {
            SendSelectedDataWithViewBag();
            ModelState.AddModelError("Image", "Yalniz sekil tipli data dagil etmek olar");
            return View(productCreateDto);
        }


        if(productCreateDto.Image.Length >  2 * Math.Pow(2,20))
        {
            SendSelectedDataWithViewBag();
            ModelState.AddModelError("Image", "Maximum 2 MB sekil yuklemek olar!");
            return View(productCreateDto);
        }

        foreach (var image in productCreateDto.Images)
        {
            //if (image.CheckImage("image"))
            //{

            //}
        }

        string uniqueFileName = Guid.NewGuid().ToString() + productCreateDto.Image.FileName;

        var product = new Product
        {
            Name = productCreateDto.Name,
            Price = productCreateDto.Price,
            Description = productCreateDto.Description,
            SKU = productCreateDto.SKU,
            CategoryId = productCreateDto.CategoryId,
            HoverImgUrl = productCreateDto.HoverImgUrl,
            MainImgUrl = uniqueFileName,
            ProductTags = []
        };

        

        //string folderPathMain = @$"C:\Users\ASUS\source\repos\ProniaMVCFull\ProniaMVCFull\wwwroot\assets\images\website-images\{uniqueFileName}";
        string folderPathMain = Path.Combine(_envoriement.WebRootPath, "assets", "images", "website-images", uniqueFileName);
        using FileStream stream = new(folderPathMain, FileMode.Create);
        productCreateDto.Image.CopyTo(stream);

        

        foreach (var tagId in productCreateDto.TagIds)
        {
            var isExistTag = _context.Tags.Any(x => x.Id == tagId);

            if (isExistTag is false)
            {
                SendSelectedDataWithViewBag();
                ModelState.AddModelError("", "Bu tag movcud deyl!!");
                return View(productCreateDto);
            }
            ProductTag productTag = new()
            {
                TagId = tagId,
                Product = product,
            };
            product.ProductTags.Add(productTag);
        }

        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _context.Products.Include(x=> x.ProductTags).FirstOrDefault(x=> x.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        SendSelectedDataWithViewBag();

        ProductUpdateVm vm = new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            SKU = product.SKU,
            TagIds = product.ProductTags.Select(x => x.TagId).ToList(),
        };
        return View(vm);
    }


    [HttpPost]
    public IActionResult Update(ProductUpdateVm vm)
    {
        var updateProduct = _context.Products
        .Include(p => p.ProductTags)
        .FirstOrDefault(p => p.Id == vm.Id);
        if (updateProduct == null)
        {
            return NotFound();
        }

        foreach (var tagId in vm.TagIds)
        {
            var isExistTag = _context.Tags.Any(x => x.Id == tagId);

            if (isExistTag is false)
            {
                SendSelectedDataWithViewBag();
                ModelState.AddModelError("", "Bu tag movcud deyl!!");
                return View(vm);
            }
            
        }


        updateProduct.Name = vm.Name;
        updateProduct.Description = vm.Description;
        updateProduct.SKU = vm.SKU;
        updateProduct.Price = vm.Price;
        updateProduct.CategoryId = vm.CategoryId;
        //updateProduct.MainImgUrl = vm.MainImage?.Name;
        //updateProduct.HoverImgUrl = vm.HoverImage;
        if (vm.MainImage != null)
            updateProduct.MainImgUrl = vm.MainImage.FileName;

        if (!string.IsNullOrEmpty(vm.HoverImage))
            updateProduct.HoverImgUrl = vm.HoverImage;

        _context.ProductTags.RemoveRange(updateProduct.ProductTags);
        foreach (var tagId in vm.TagIds)
        {
            ProductTag productTag = new ()
            {
                TagId = tagId,
                ProductId = updateProduct.Id
            };
            updateProduct.ProductTags.Add(productTag);
        }
        _context.Products.Update(updateProduct);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
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
        string filePth = Path.Combine(_envoriement.WebRootPath, "assets", "images", "website-images", product.MainImgUrl);
        
        if(System.IO.File.Exists(filePth)) 
           System.IO.File.Delete(filePth);

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Detail(int id)
    {
        var product = _context.Products.Select(x => new ProductGetVm()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            SKU = x.SKU,
            Price = x.Price,
            HoverImageUrl = x.HoverImgUrl,
            MainImageUrl = x.MainImgUrl,
            TagNames = x.ProductTags.Select(x => x.Tag.Name).ToList()
        }).FirstOrDefault(x=> x.Id == id);

        if(product == null)
        {
            return NotFound();
        }

        return View(product);

    }
    
    private void SendSelectedDataWithViewBag()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Tags = _context.Tags.ToList();
    } 
}
