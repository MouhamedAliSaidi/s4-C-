using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            return View("Success", person);
        }
    }
}
