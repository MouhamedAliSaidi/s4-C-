using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class DishesController : Controller
{
    private MyContext _context;

    public DishesController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/dishes")]
    public IActionResult Index()
    {
        var allDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View("Index", allDishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("New");
    }

    [HttpGet("/dishes/{id}")]
    public IActionResult Details(int id)
    {
        Dish oneDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (oneDish == null) return RedirectToAction("Index");
        return View("Details", oneDish);
    }

    [HttpGet("/dishes/{id}/edit")]
    public IActionResult Edit(int id)
    {
        Dish dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        return View("Edit", dishToEdit);
    }

    [HttpPost("/dishes/{id}/update")]
    public IActionResult Update(int id, Dish updatedDish)
    {
        if (ModelState.IsValid)
        {
            Dish dbDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
            if (dbDish == null) return RedirectToAction("Index");

            dbDish.Name = updatedDish.Name;
            dbDish.Chef = updatedDish.Chef;
            dbDish.Tastiness = updatedDish.Tastiness;
            dbDish.Calories = updatedDish.Calories;
            dbDish.Description = updatedDish.Description;
            dbDish.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Details", new { id = dbDish.DishId });
        }
        return View("Edit", updatedDish);
    }

    [HttpPost("/dishes/{id}/delete")]
    public IActionResult Delete(int id)
    {
        Dish dishToDelete = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (dishToDelete != null)
        {
            _context.Dishes.Remove(dishToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
