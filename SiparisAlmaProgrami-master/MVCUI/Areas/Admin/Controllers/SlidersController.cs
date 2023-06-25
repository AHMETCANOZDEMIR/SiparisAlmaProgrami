using System.Web;
using System.Web.Mvc;
using Entities;
using BL;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize]
    public class SlidersController : Controller
    {
        SliderManager manager = new SliderManager();
        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        [HttpPost]
        public ActionResult Create(Slider slider, HttpPostedFileBase Image)
        {
            try
            {
                // TODO: Add insert logic here
                if (Image != null) // Resim seçilmişse
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    slider.Image = Image.FileName;
                }
                manager.Add(slider);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(slider);
            }
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int id)
        {
            return View(manager.Find(id));
        }

        // POST: Admin/Sliders/Edit/5
        [HttpPost]
        public ActionResult Edit(Slider slider, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                try
                {
                    if (Image != null) // Resim seçilmişse
                    {
                        Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                        slider.Image = Image.FileName;
                    }
                    manager.Update(slider);
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("","Hata Oluştu!");
                }
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int id)
        {
            var slide = manager.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Slider slider)
        {
            try
            {
                // TODO: Add delete logic here
                var slide = manager.Find(id);
                manager.Delete(slide);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
