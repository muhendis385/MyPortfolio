using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;

namespace MyPortfolio.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        private readonly MyPortfolioDbContext _context;
        public _AboutComponentPartial(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.AboutTables.FirstOrDefault();
            return View(values);
        }
    }
}
