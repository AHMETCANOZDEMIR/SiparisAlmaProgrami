using System;
using System.Web.Mvc;
using Entities; // CRUD için gerekli
using BL; // CRUD için gerekli

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize] // Bu attribute admindeki AddressesController a gelecek isteklerde login kontrolü yapar
    public class AddressesController : Controller
    {
        AddressManager manager = new AddressManager();
        CustomerManager customer = new CustomerManager();
        LogManager logManager = new LogManager();
        // GET: Admin/Addresses
        public ActionResult Index() // Veri listelem sayfası
        {
            return View(manager.GetAddressByCustomers()); // View içerisine bu şekilde veritabanından çektiğimiz adres listesini göndermemiz gerekiyor aksi taktirde sayfada model boş olduğu için hata alırız!
        }

        // GET: Admin/Addresses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Addresses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(customer.GetAll(), "Id", "Name"); // Ön yüzdeki drop down list e müşteri listesini gönderdik
            return View();
        }

        // POST: Admin/Addresses/Create
        [HttpPost]
        public ActionResult Create(Address address) // Sayfa ön yüzünden bize adres nesnesi gelecek
        {
            try
            {
                // TODO: Add insert logic here
                address.CreateDate = DateTime.Now;
                manager.Add(address);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.CustomerId = new SelectList(customer.GetAll(), "Id", "Name");
                return View(address);
            }
        }

        // GET: Admin/Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var adres = manager.Find(id.Value);
            ViewBag.CustomerId = new SelectList(customer.GetAll(), "Id", "Name", adres.CustomerId);
            return View(adres);
        }

        // POST: Admin/Addresses/Edit/5
        [HttpPost]
        public ActionResult Edit(Address address)
        {
            try
            {
                // TODO: Add update logic here
                manager.Update(address);
                return RedirectToAction("Index");
            }
            catch (Exception hata) // Oluşan hatayı yakalamak için gerekli kod
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Güncellenemedi!"); // Oluşan hatayı ekrana bastırıp görebilmek için
                logManager.Add(new Log { CreateDate = DateTime.Now, Error = hata.ToString(), ErrorInfo = "Customer Create" });
            }
            ViewBag.CustomerId = new SelectList(customer.GetAll(), "Id", "Name");
            return View(address);
        }

        // GET: Admin/Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(manager.Find(id));
        }

        // POST: Admin/Addresses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                // TODO: Add delete logic here
                address = manager.Find(id);
                manager.Delete(address);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(address);
            }
        }
    }
}
