using Microsoft.AspNetCore.Mvc;
using WebMessageApp.Models;

namespace WebMessageApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(UserSubmission user)
        {
            // Store in TempData to use in redirected view (Level 2)
            TempData["Name"] = user.Name;
            TempData["Dojo"] = user.DojoLocation;
            TempData["Language"] = user.FavoriteLanguage;
            TempData["Comment"] = string.IsNullOrWhiteSpace(user.Comment) ? "No comment" : user.Comment;

            return RedirectToAction("Results");
        }

        [HttpGet("results")]
        public IActionResult Results()
        {
            return View();
        }
    }
}
