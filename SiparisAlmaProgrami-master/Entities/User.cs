using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Kullanıcı Adı"), StringLength(50), Required]
        public string UserName { get; set; }
        [DisplayName("Şifre"), StringLength(150), Required]
        public string Password { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [DisplayName("Adı"), StringLength(50)]
        public string Name { get; set; }
        [DisplayName("Soyadı"), StringLength(50)]
        public string SurName { get; set; }
        [DisplayName("Telefon"), StringLength(15)]
        public string Phone { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
    }
}
