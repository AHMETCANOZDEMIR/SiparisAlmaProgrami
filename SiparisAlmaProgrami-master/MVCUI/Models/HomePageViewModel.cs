using Entities;
using System.Collections.Generic;

namespace MVCUI.Models
{
    public class HomePageViewModel // Anasayfada kullanacağımız sayfa modelimiz
    {
        public List<Slider> Sliders { get; set; } // Anasayfada slider listesi kullanmak için
        public List<Product> Products { get; set; }// Anasayfada product listesi kullanmak için
    }
}