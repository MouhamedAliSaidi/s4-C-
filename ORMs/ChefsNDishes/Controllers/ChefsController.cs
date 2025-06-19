using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

public class ChefsController : Controller
{
    private readonly MyContext _context;

    public ChefsController(MyContext context)
    {
        _context = context;
    }


    [HttpGet("/chefs")]
    public IActionResult Index()
    {
        var chefs = _context.Chefs.Include(c => c.CreatedDishes).ToList();
        return View("Index", chefs);
    }


    [HttpGet("/chefs/new")]
    public IActionResult New() => View("New");

    [HttpPost("/chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if (!ModelState.IsValid)
            return View("New");

        _context.Chefs.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
