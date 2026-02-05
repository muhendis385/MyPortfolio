using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class AdminCertificateController : Controller
    {
        private readonly MyPortfolioDbContext _context;

        public AdminCertificateController(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Certificates.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCertificate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCertificate(int id)
        {
            var values = _context.Certificates.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCertificate(Certificate certificate)
        {
            var values = _context.Certificates.Update(certificate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCertificate(int id)
        {
            var values = _context.Certificates.Find(id);
            _context.Certificates.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
