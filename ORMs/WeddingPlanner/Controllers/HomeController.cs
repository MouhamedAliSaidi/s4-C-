using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class HomeController : Controller
{
    private readonly MyContext _context;

    public HomeController(MyContext context) { _context = context; }

    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            return RedirectToAction("Dashboard", "Wedding");
        }
        return View();
}


    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email))
            ModelState.AddModelError("Email", "Email already taken.");

        if (!ModelState.IsValid) return View("Index");

        PasswordHasher<User> hasher = new();
        user.Password = hasher.HashPassword(user, user.Password);

        _context.Users.Add(user);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("UserId", user.UserId);
        return RedirectToAction("Dashboard", "Wedding");
    }

    [HttpPost("login")]
    public IActionResult Login(string Email, string Password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == Email);
        if (user == null)
        {
            ModelState.AddModelError("Email", "Invalid Login");
            return View("Index");
        }

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.Password, Password);
        if (result == 0)
        {
            ModelState.AddModelError("Email", "Invalid Login");
            return View("Index");
        }

        HttpContext.Session.SetInt32("UserId", user.UserId);
        return RedirectToAction("Dashboard", "Wedding");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
