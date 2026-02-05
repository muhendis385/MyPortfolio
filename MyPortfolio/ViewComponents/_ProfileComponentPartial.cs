using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyPortfolio.ViewComponents
{
    public class _ProfileComponentPartial : ViewComponent
    {
        private readonly MyPortfolioDbContext _context;

        public _ProfileComponentPartial(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Profiles.FirstOrDefault();
            return View(values);
           
        }
        
    }
}
