using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

public class CategoriesController : Controller
{
    private readonly MyContext _context;

    public CategoriesController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    [HttpPost("categories/create")]
    public IActionResult Create(Category newCategory)
    {
        if (!ModelState.IsValid)
            return Index();

        _context.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("categories/{id}")]
    public IActionResult Details(int id)
    {
        var category = _context.Categories
            .Include(c => c.ProductsLink)
            .ThenInclude(a => a.Product)
            .FirstOrDefault(c => c.CategoryId == id);

        if (category == null) return RedirectToAction("Index");

        var associatedProductIds = category.ProductsLink.Select(a => a.ProductId);
        ViewBag.AvailableProducts = _context.Products
            .Where(p => !associatedProductIds.Contains(p.ProductId)).ToList();

        return View(category);
    }

    [HttpPost("categories/addproduct")]
    public IActionResult AddProduct(int CategoryId, int ProductId)
    {
        bool exists = _context.Associations.Any(a => a.ProductId == ProductId && a.CategoryId == CategoryId);
        if (!exists)
        {
            _context.Associations.Add(new Association { ProductId = ProductId, CategoryId = CategoryId });
            _context.SaveChanges();
        }
        return RedirectToAction("Details", new { id = CategoryId });
    }
}
