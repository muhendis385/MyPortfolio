using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class _CertificateComponentPartial : ViewComponent
    {
        private readonly MyPortfolioDbContext _context;

        public _CertificateComponentPartial(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Certificates.ToList();
            return View(values);
        }
    }
}
