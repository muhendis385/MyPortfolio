using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly MyPortfolioDbContext _context;

        public AdminContactController(MyPortfolioDbContext context)
        {
            _context = context;
        }

        // Menü buraya gelir, kayıt yoksa Create'e, varsa Update'e gider
        public IActionResult Index()
        {
            var contact = _context.Contacts.FirstOrDefault();

            if (contact == null)
                return RedirectToAction(nameof(CreateContact));

            return RedirectToAction(nameof(UpdateContact), new { id = contact.ContactId });
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            // Tek kayıt kuralı: varsa Create yaptırma
            var existing = _context.Contacts.FirstOrDefault();
            if (existing != null)
                return RedirectToAction(nameof(UpdateContact), new { id = existing.ContactId });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(Contact contact)
        {
            // Tek kayıt kuralı
            if (_context.Contacts.Any())
            {
                var existing = _context.Contacts.First();
                return RedirectToAction(nameof(UpdateContact), new { id = existing.ContactId });
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null) return RedirectToAction(nameof(CreateContact));

            return View(value);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public IActionResult UpdateContact(Contact contact)
        //{
        //    var value = _context.Contacts.Find(contact.ContactId);
        //    if (value == null) return RedirectToAction(nameof(CreateContact));

        //    // TÜM ALANLARI EŞİTLEMEN LAZIM:
        //    value.Name = contact.Name;           // Bu satırı ekledik
        //    value.Email = contact.Email;         // Bu satırı ekledik
        //    value.Description = contact.Description;

        //    _context.SaveChanges();

        //    TempData["Success"] = "İletişim bilgileri başarıyla güncellendi.";
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(Contact contact)
        {
            // Veritabanındaki mevcut kaydı buluyoruz
            var value = _context.Contacts.Find(contact.ContactId);

            if (value != null)
            {
                // ÖNEMLİ: Her bir alanı tek tek eşlemelisin
                value.Name = contact.Name;
                value.Email = contact.Email;
                value.Description = contact.Description;

                _context.SaveChanges();
                TempData["Success"] = "Bilgiler başarıyla güncellendi.";
            }

            return RedirectToAction("Index");
        }



        // Tek kayıt olduğu için Delete'i istersen kapat
        //public IActionResult DeleteContact(int id)
        //{
        //    var value = _context.Contacts.Find(id);
        //    if (value != null)
        //    {
        //        _context.Contacts.Remove(value);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
