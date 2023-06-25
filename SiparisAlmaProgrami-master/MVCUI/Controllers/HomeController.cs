using System.Web.Mvc;
using BL;
using Entities;
using MVCUI.Models;

namespace MVCUI.Controllers
{
    public class HomeController : Controller
    {
        ProductManager manager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();
        ContactManager contactManager = new ContactManager();
        SliderManager sliderManager = new SliderManager();
        public ActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Sliders = sliderManager.GetAll(),
                Products = manager.GetAll()
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda";

            return View();
        }

        [Route("iletisim")] // adres çubuğuna site adından sonra iletisim yazınca home/contact sayfası açılsın
        public ActionResult Contact()
        {
            return View();
        }
        [Route("iletisim"), HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid) // Contact sınıfındaki zorunlu alanları kontrol et
            {
                try
                {
                    contact.CreateDate = System.DateTime.Now;
                    var sonuc = contactManager.Add(contact);
                    if (sonuc > 0)
                    {
                        TempData["Message"] = "<div class='alert alert-success'>Teşekkürler.. Mesajınız Bize Ulaştı..</div>";
                        return Redirect("iletisim");
                    }
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu! Mesajınız Gönderilemedi!");
                }
            }
            return View(contact);
        }
        public PartialViewResult _PartialMenu()
        {
            return PartialView(categoryManager.GetAll());
        }

        [Route("Search")] // Route Adres çubuğunda /Search sayfası çağrıldığında aşağıdaki actionun çalışmasını sağlar
        public ActionResult Search(string search)
        {
            ViewBag.Message = "Kelime " + search;

            var liste = manager.GetAll(p => p.Name.Contains(search)); // liste değişkeni oluştur ve bu listeye getall metodunun 2. kullanımıyla search değişkeninden gelen kelimeyi içeren ürünleri ekle

            return View(liste); // filtrelenmiş ürün listesini sayfaya model olarak gönder
        }

    }
}