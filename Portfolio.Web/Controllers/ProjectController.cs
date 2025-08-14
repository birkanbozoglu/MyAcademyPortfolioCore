using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ProjectController(PortfolioContext context) : Controller
    {
        private void GetCategories()
        {
            ViewBag.Categories = context.Categories
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
        }

        public IActionResult Index()
        {
            var projects = context.Projects.Include(x => x.Category).ToList();
            return View(projects);
        }

        public IActionResult CreateProject()
        {
            GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                GetCategories();
                return View(project);
            }
            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
