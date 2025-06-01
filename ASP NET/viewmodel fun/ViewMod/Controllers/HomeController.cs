using Microsoft.AspNetCore.Mvc;
using YourApp.Models;
using System.Collections.Generic;

namespace YourApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string message = "This is a simple message passed from the controller.";
            return View(model: message);
        }

        public IActionResult Numbers()
        {
            int[] numbers = { 1, 2, 10, 21, 8, 7, 3 };
            return View(numbers);
        }

        public IActionResult User()
        {
            var user = new User { FirstName = "NDa", LastName = "G" };
            return View(user);
        }

        public IActionResult Users()
        {
            var users = new List<User>
            {
                new User { FirstName = "Nda", LastName = "G" },
                new User { FirstName = "Terry", LastName = "P" },
                new User { FirstName = "Jane", LastName = "A" },
                new User { FirstName = "Steph", LastName = "K" },
                new User { FirstName = "Mary", LastName = "S" }
            };
            return View(users);
        }
    }
}
