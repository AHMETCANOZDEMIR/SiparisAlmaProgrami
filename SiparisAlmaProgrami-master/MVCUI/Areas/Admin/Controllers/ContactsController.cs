using System;
using System.Web.Mvc;
using BL;
using Entities;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        ContactManager manager = new ContactManager();
        // GET: Admin/Contacts
        public ActionResult Index()
        {
            return View(manager.GetAll()); ;
        }

        // GET: Admin/Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contacts/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                // TODO: Add insert logic here
                contact.CreateDate = DateTime.Now;
                manager.Add(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("","Hata Oluştu!");
            }
            return View(contact);
        }

        // GET: Admin/Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            var kayit = manager.Find(id);
            return View(kayit);
        }

        // POST: Admin/Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                // TODO: Add update logic here
                manager.Update(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(contact);
            }
        }

        // GET: Admin/Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            var kayit = manager.Find(id);
            return View(kayit);
        }

        // POST: Admin/Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                // TODO: Add delete logic here
                var kayit = manager.Find(id);
                manager.Delete(kayit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(contact);
            }
        }
    }
}
