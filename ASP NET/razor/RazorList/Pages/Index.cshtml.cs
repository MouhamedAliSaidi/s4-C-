using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorListDemo.Pages
{
    public class IndexModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        public List<string> Items { get; private set; } = new();

        public void OnGet()
        {
            Items = new()
            {
                "Applie Pie",
                "Pizza",
                "Cinamon Rolls",
                "Lasagna",
                "Donutgs",
                "Chocolate Cake",
                "Burritos"
            };
        }
    }
}

