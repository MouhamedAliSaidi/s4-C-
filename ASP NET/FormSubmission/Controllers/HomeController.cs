using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new UserForm());
        }

        [HttpPost("submit")]
        public IActionResult Submit(UserForm user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            return View("Result", user);
        }
    }
}
