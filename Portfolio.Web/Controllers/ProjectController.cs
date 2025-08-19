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

        public IActionResult UpdateProject(int id)
        {
            GetCategories();
            var project = context.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            GetCategories();
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            context.Projects.Update(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(int id)
        {
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
