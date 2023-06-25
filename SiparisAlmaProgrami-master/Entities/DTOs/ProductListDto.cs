using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs
{
    public class ProductListDto
    {
        public int Id { get; set; }
        [DisplayName("Adı"), StringLength(150), Required]
        public string Name { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Stok")]
        public int Stock { get; set; }
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }
        [DisplayName("Resim"), StringLength(150)]
        public string Image { get; set; }
        [DisplayName("Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) kodu ekleme ve düzenleme sayfalarında eklenme tarihi için textbox oluşturulmasını engeller.
        public DateTime CreateDate { get; set; }
        [DisplayName("Kategori")]
        public string CategoryName { get; set; }
    }
}
