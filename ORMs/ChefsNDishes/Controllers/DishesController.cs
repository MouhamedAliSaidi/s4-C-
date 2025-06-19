using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

public class DishesController : Controller
{
    private readonly MyContext _context;

    public DishesController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/dishes")]
    public IActionResult Index()
    {
        var dishes = _context.Dishes.Include(d => d.Chef).ToList();
        return View("Index", dishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        ViewBag.Chefs = _context.Chefs.ToList();
        return View("New");
    }

    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Chefs = _context.Chefs.ToList();
            return View("New");
        }

        _context.Dishes.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
