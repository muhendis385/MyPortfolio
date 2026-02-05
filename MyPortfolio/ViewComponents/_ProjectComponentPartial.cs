using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class _ProjectComponentPartial : ViewComponent
    {
        private readonly MyPortfolioDbContext _context;

        public _ProjectComponentPartial(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Projects.ToList();
            return View(values);
        }
    }
}
