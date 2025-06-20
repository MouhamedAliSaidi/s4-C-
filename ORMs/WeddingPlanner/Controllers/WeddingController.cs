using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

public class WeddingController : Controller
{
    private MyContext _context;
    public WeddingController(MyContext context) { _context = context; }

    private int? uid => HttpContext.Session.GetInt32("UserId");

    [HttpGet("weddings")]
    public IActionResult Dashboard()
    {
        if (uid == null) return RedirectToAction("Index", "Home");

        var weddings = _context.Weddings
            .Include(w => w.Guests)
            .ThenInclude(r => r.User)
            .Include(w => w.Planner)
            .ToList();

        ViewBag.UserId = uid;
        return View(weddings);
    }

    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        if (uid == null) return RedirectToAction("Index", "Home");
        return View("NewWedding");
    }

    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding wedding)
    {
        wedding.UserId = (int)uid;
        _context.Weddings.Add(wedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpPost("weddings/{id}/rsvp")]
    public IActionResult RSVP(int id)
    {
        if (uid == null) return RedirectToAction("Index", "Home");

        _context.RSVPs.Add(new RSVP { UserId = (int)uid, WeddingId = id });
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpPost("weddings/{id}/unrsvp")]
    public IActionResult UnRSVP(int id)
    {
        if (uid == null) return RedirectToAction("Index", "Home");

        var rsvp = _context.RSVPs
            .FirstOrDefault(r => r.UserId == uid && r.WeddingId == id);

        if (rsvp != null)
        {
            _context.RSVPs.Remove(rsvp);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }

    [HttpPost("weddings/{id}/delete")]
    public IActionResult Delete(int id)
    {
        if (uid == null) return RedirectToAction("Index", "Home");

        var wedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == id && w.UserId == uid);
        if (wedding != null)
        {
            _context.Weddings.Remove(wedding);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }

    [HttpGet("weddings/{id}")]
    public IActionResult ViewWedding(int id)
    {
        if (uid == null) return RedirectToAction("Index", "Home");

        var wedding = _context.Weddings
            .Include(w => w.Guests).ThenInclude(r => r.User)
            .Include(w => w.Planner)
            .FirstOrDefault(w => w.WeddingId == id);

        if (wedding == null) return RedirectToAction("Dashboard");

        return View(wedding);
    }
}
