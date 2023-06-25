using System;
using System.Web;
using System.Web.Mvc;
using Entities;
using BL;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        ProductManager manager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) // Modelin(product) durumu geçerliyse
                {
                    if (Image != null) // Resim seçilmişse
                    {
                        //var filename = Path.GetFileName(Image.FileName);
                        //var path = Path.Combine(Server.MapPath("/Images"), filename);
                        //Image.SaveAs(path); // Resmi sunucuya farklı kaydet yöntemiyle yükledik
                        Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                        product.Image = Image.FileName;
                    }
                    product.CreateDate = DateTime.Now;
                    manager.Add(product);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Eklenemedi!"); // Eğer hata oluşursa bunu modelstate e ekle ve kullanıcıya göster.
            }
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name");
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = manager.Find(id);
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", product.CategoryId); // SelectList e 4. parametre olarak product ın CategoryId sini gönderirsek ön yüzde seçili kategori bu gelir
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product, HttpPostedFileBase Image, bool cbResmiSil = false)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid) // Sayfa model classı geçerliyse
                {
                    if (cbResmiSil == true)
                    {
                        product.Image = string.Empty;
                    }
                    if (Image != null)
                    {
                        Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                        product.Image = Image.FileName;
                    }
                    //product.CreateDate = DateTime.Now;
                    manager.Update(product);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Güncellenemdi!");
            }
            ViewBag.CategoryId = new SelectList(categoryManager.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View(manager.Find(id));
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                manager.Delete(manager.Find(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }
    }
}
