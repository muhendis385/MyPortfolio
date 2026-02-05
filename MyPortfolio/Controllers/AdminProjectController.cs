using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class AdminProjectController : Controller
    {
        private readonly MyPortfolioDbContext _context;

        public AdminProjectController(MyPortfolioDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Projects.Include(x => x.Category).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            List<SelectListItem> categoryValues = (from x in _context.Categorys.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            List<SelectListItem> categoryValues = (from x in _context.Categorys.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;
            var values = _context.Projects.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            var values = _context.Projects.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(int id)
        {
            var values = _context.Projects.Find(id);
            _context.Projects.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
