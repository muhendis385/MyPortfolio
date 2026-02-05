using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;

namespace MyPortfolio.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        private readonly MyPortfolioDbContext _context;

        public _ContactComponentPartial(MyPortfolioDbContext context)
        {
            _context = context;
        }
        //public IViewComponentResult Invoke()
        //{
        //    var values = _context.Contacts.FirstOrDefault();
        //    return View(values);
        //}
        public IViewComponentResult Invoke()
        {
            // Senin bilgilerini çekiyoruz
            var myInfo = _context.Contacts.FirstOrDefault();

            // Bilgileri ViewBag'e mühürlüyoruz
            ViewBag.MyContactInfo = myInfo;

            // View'a BOŞ bir model gönderiyoruz (Böylece sağdaki form boş kalır)
            return View(new Contact());
        }

    }
}
