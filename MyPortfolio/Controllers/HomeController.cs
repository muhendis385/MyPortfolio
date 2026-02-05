using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using System.Diagnostics;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyPortfolioDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyPortfolioDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult SendMessage(Message model)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                model.IsRead = false;

                _context.Messages.Add(model);
                _context.SaveChanges();

                // Mesaj başarıyla kaydedildiğinde kullanıcıyı ana sayfaya geri atar
                return RedirectToAction("Index");
            }

            // Model geçersizse (boş alan varsa) yine ana sayfaya döner
            return RedirectToAction("Index");
        }
        
        
    }
}
