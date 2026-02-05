using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MyPortfolio.ViewComponents
{
    public class _EducationComponentPartial : ViewComponent
    {
        private readonly MyPortfolioDbContext _context;

        public _EducationComponentPartial(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }
    }
}
