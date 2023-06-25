using System;
using System.Web.Mvc;
using BL;
using Entities;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        CustomerManager manager = new CustomerManager();
        LogManager logManager = new LogManager();
        // GET: Admin/Customers
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) // Model kurallarına uyulmuşsa
                {
                    customer.CreateDate = DateTime.Now;
                    manager.Add(customer);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception hata) // Oluşan hatayı yakalamak için gerekli kod
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Eklenemedi!"); // Oluşan hatayı ekrana bastırıp görebilmek için
                logManager.Add(new Log { CreateDate = DateTime.Now, Error = hata.ToString(), ErrorInfo = "Customer Create" });
            }
            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) // eğer id gönderilmemişse
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest); // Geriye geçersiz istek hatası döndür.
            }
            Customer kayit = manager.Find(id.Value);
            return View(kayit);
        }

        // POST: Admin/Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    manager.Update(customer);
                }
                return RedirectToAction("Index");
            }
            catch (Exception hata) // Oluşan hatayı yakalamak için gerekli kod
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Güncellenemedi!");
                logManager.Add(new Log { CreateDate = DateTime.Now, Error = hata.ToString(), ErrorInfo = "Customer Edit" });
            }
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(manager.Find(id));
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                customer = manager.Find(id);
                manager.Delete(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
