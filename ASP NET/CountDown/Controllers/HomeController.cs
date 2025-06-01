using Microsoft.AspNetCore.Mvc;
using WebMessageApp.Models;

namespace WebMessageApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = new DateTime(2029, 12, 31, 7, 0, 0); 

            CountdownViewModel model = new CountdownViewModel
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeRemaining = endTime - startTime
            };

            return View(model);
        }
    }
}
