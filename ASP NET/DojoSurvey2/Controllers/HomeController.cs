using Microsoft.AspNetCore.Mvc;
using DojoSurvey2.Models;

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
            return View("Result", survey);
        }
    }
}
