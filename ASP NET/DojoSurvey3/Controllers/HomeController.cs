using Microsoft.AspNetCore.Mvc;
using DojoSurvey3.Models;

namespace DojoSurvey2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            return View("Result", survey);
        }

    }
}
