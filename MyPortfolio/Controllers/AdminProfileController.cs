using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio;
using MyPortfolio.Data;

namespace PortfolyoSitem.Controllers
{
    public class AdminProfileController : Controller
    {
        private readonly MyPortfolioDbContext _context;

        public AdminProfileController(MyPortfolioDbContext context)
        {
            _context = context;
        }

        // Ana sayfa: Eğer veri varsa düzenleme formuna, yoksa oluşturma formuna yönlendirir.
        public IActionResult Index()
        {
            var value = _context.Profiles.FirstOrDefault();

            if (value == null)
            {
                // Veri yoksa Create sayfasına git
                return RedirectToAction("CreateProfile");
            }

            // Veri varsa direkt Update sayfasını aç (ID'yi otomatik gönderir)
            return RedirectToAction("UpdateProfile", new { id = value.ProfileId });
        }

        [HttpGet]
        public IActionResult CreateProfile()
        {
            // Eğer kazara zaten bir kayıt varken buraya gelinirse engelle
            if (_context.Profiles.Any()) return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProfile(Profile model)
        {
            if (_context.Profiles.Any()) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Profiles.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Profil başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            var value = _context.Profiles.Find(id);
            if (value == null) return RedirectToAction("Index");

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(Profile model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                // Tablodaki tek kaydı güncelle
                _context.Profiles.Update(model);
                _context.SaveChanges();

                TempData["Success"] = "Profil başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                // Eğer veritabanındaki kayıt o esnada silindiyse hatayı yakala
                TempData["Error"] = "Güncellenecek kayıt bulunamadı.";
                return RedirectToAction("Index");
            }
        }
    }
}