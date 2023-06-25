using System.Web.Mvc;
using BL;

namespace MVCUI.Controllers
{
    public class ProductsController : Controller
    {
        ProductManager manager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();
        // GET: Products
        public ActionResult Index(int? id) // adres çubuğundan gelecek id değerini yakalar
        {
            if (id != null) // Eğer adres çubuğundan id değeri gönderilmişse
            {
                ViewBag.KategoriAdi = categoryManager.Find(id.Value).Name; // Adres çubuğundan gönderilen kategori id sine ait kategoriyi categoryManager find metoduyla bul ve bulunan kategorinin adını(Name) ViewBag.KategoriAdi ile sayfa ön yüzüne yolla
                return View(manager.GetAll(p => p.CategoryId == id)); // Ürünlerden CategoryId si adres çubuğundan gönderilen kategori id ile eşleşenleri sayfaya gönder
            }
            ViewBag.KategoriAdi = "Tüm Ürünler";
            return View(manager.GetAll()); // eğer adres çubuğundan kategori id gönderilmemişse sayfaya tüm ürünleri gönder
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(manager.Find(id.Value));
        }

    }
}