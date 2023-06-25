using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security; // Login işlemi için gerekli kütüphane
using System.Web.Mvc;
using BL;

namespace MVCUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        LoginManager manager = new LoginManager();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password, string ReturnUrl)
        {
            var kullanici = manager.Get(x => x.Email == email & x.Password == password & x.IsActive);
            if (kullanici != null)
            {
                Session["admin"] = kullanici;
                FormsAuthentication.SetAuthCookie(kullanici.UserName, true); // Giriş yapan kullanıcı adını kukide sakla
                return ReturnUrl == null ? RedirectToAction("Index", "Home") : (ActionResult)Redirect(ReturnUrl); // ReturnUrl adres çubuğunda boşsa default index sayfasına değilse ReturnUrl de yazan adrese git
            }
            else TempData["Mesaj"] = "<div class='alert alert-danger'>Giriş Başarısız! Kullanıcı Bulunamadı!</div>";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("admin"); // Giriş yaparken oluşturduğumuz admin isimli session ı sil
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}