using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;
using System.Linq; // OrderBy ve Count için gerekli

namespace MyPortfolio.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly MyPortfolioDbContext _context;

        public AdminDashboardController(MyPortfolioDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // --- AKTİF MENÜ ÖZELLİĞİ BURADA TETİKLENİYOR ---
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Dashboard";

            // Mevcut İstatistiklerin
            ViewBag.totalProjects = _context.Projects.Count();
            ViewBag.totalCategories = _context.Categorys.Count();
            ViewBag.firstProject = _context.Projects.OrderBy(p => p.ProjectId).Select(p => p.Name).FirstOrDefault();
            ViewBag.lastProject = _context.Projects.OrderByDescending(p => p.ProjectId).Select(p => p.Name).FirstOrDefault();

            var mostUsedCategoryId = _context.Projects
                .GroupBy(p => p.CategoryId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            ViewBag.MostUsedCategoryName = _context.Categorys
                .Where(c => c.CategoryId == mostUsedCategoryId)
                .Select(c => c.CategoryName)
                .FirstOrDefault();

            ViewBag.firstExperience = _context.Experiences.OrderBy(e => e.ExperienceId).Select(e => e.Title).FirstOrDefault();
            ViewBag.totalCertificates = _context.Certificates.Count();
            ViewBag.firstUniversity = _context.Educations.OrderBy(e => e.EducationId).Select(e => e.Name).FirstOrDefault();
            ViewBag.bestSkill = _context.Skills.OrderByDescending(s => s.Level).Select(s => s.Name).FirstOrDefault();

            // İletişim mesajlarını listeleme
            var messages = _context.Messages.OrderByDescending(x => x.Date).ToList();

            return View(messages);
        }

        public IActionResult MessageDetails(int id)
        {
            // Detay sayfasındayken de Dashboard menüsünün aktif kalmasını istiyorsan:
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Mesaj Detayı";

            var value = _context.Messages.Find(id);

            if (value == null) return RedirectToAction("Index");

            value.IsRead = true;
            _context.SaveChanges();

            return View(value);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Mesaj kalıcı olarak silindi.";
            }
            return RedirectToAction("Index");
        }
    }
}