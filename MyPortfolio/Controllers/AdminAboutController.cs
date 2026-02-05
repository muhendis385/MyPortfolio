using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly MyPortfolioDbContext _context;

        public AdminAboutController(MyPortfolioDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.AboutTables.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.AboutTables.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = _context.AboutTables.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            var values = _context.AboutTables.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            var values = _context.AboutTables.Find(id);
            _context.AboutTables.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
