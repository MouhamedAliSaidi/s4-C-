using Microsoft.AspNetCore.Mvc;
using PetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PetApp.Controllers;

public class PetsController : Controller
{
    private readonly MyContext _context;

    public PetsController(MyContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Pets.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pet pet)
    {
        if (!ModelState.IsValid)
            return View(pet);

        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // Add Edit, Delete, and Details if you want
}
