using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using LoginRegistrationProject.Models;

namespace LoginRegistrationProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyContext _context;
        public AccountController(MyContext context)
        {
            _context = context;
        }
        
        // GET: / or /Login
        [HttpGet("")]
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View(new LoginUser());
        }
        
        // GET: /Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        
        // POST: /Register
        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            // Check if email exists
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already in use.");
            }
            
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            
            // Hash the password
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);
            
            _context.Users.Add(newUser);
            _context.SaveChanges();
            
            // Set session with the new user's ID
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Success");
        }
        
        // POST: /Login
        [HttpPost("Login")]
        public IActionResult Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            
            var dbUser = _context.Users.FirstOrDefault(u => u.Email == loginUser.Email);
            if (dbUser == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Login");
            }
            
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("Password", "Invalid Email/Password");
                return View("Login");
            }
            
            // Save the user's ID in session
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            return RedirectToAction("Success");
        }
        
        // GET: /Success
        [HttpGet("Success")]
        public IActionResult Success()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            
            // Optionally, pass the user object to display a personalized message
            User currentUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
            return View(currentUser);
        }
        
        // POST: /Logout
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}