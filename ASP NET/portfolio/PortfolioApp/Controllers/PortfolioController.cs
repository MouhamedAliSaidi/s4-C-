using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Controllers
{
    public class PortfolioController : Controller
    {
        
        public IActionResult Index()
        {
            return Content("This is my Index!");
        }

    
        public IActionResult Projects()
        {
            return Content("These are my projects!");
        }

        
        public IActionResult Contact()
        {
            return Content("This is my Contact!");
        }
    }
}
