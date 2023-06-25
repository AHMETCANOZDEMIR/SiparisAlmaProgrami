using System.Web.Mvc;
using Entities;
using BL;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        CategoryManager manager = new CategoryManager();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                manager.Add(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View(manager.Find(id));
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                // TODO: Add update logic here
                manager.Update(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View(manager.Find(id));
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                // TODO: Add delete logic here
                category = manager.Find(id);
                manager.Delete(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }
    }
}
