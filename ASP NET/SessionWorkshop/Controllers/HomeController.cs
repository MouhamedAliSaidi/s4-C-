using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private static int value = 22;

    public IActionResult Index() => View(value);

    [HttpPost]
    public IActionResult Update(string operation)
    {
        switch (operation)
        {
            case "+1": value += 1; break;
            case "-1": value -= 1; break;
            case "x2": value *= 2; break;
            case "random": value += new Random().Next(1, 11); break;
            case "reset": value = 22; break;
        }
        return RedirectToAction("Index");
    }
}