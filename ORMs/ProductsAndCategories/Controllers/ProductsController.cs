using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

public class ProductsController : Controller
{
    private readonly MyContext _context;

    public ProductsController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    [HttpGet("products")]
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    [HttpPost("products/create")]
    public IActionResult Create(Product newProduct)
    {
        if (!ModelState.IsValid)
            return Index();

        _context.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("products/{id}")]
    public IActionResult Details(int id)
    {
        var product = _context.Products
            .Include(p => p.CategoriesLink)
            .ThenInclude(a => a.Category)
            .FirstOrDefault(p => p.ProductId == id);

        if (product == null) return RedirectToAction("Index");

        var associatedCategoryIds = product.CategoriesLink.Select(a => a.CategoryId);
        ViewBag.AvailableCategories = _context.Categories
            .Where(c => !associatedCategoryIds.Contains(c.CategoryId)).ToList();

        return View(product);
    }

    [HttpPost("products/addcategory")]
    public IActionResult AddCategory(int ProductId, int CategoryId)
    {
        bool exists = _context.Associations.Any(a => a.ProductId == ProductId && a.CategoryId == CategoryId);
        if (!exists)
        {
            _context.Associations.Add(new Association { ProductId = ProductId, CategoryId = CategoryId });
            _context.SaveChanges();
        }
        return RedirectToAction("Details", new { id = ProductId });
    }
}
