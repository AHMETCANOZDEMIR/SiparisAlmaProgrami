using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), EmailAddress]
        public string Email { get; set; }
        [DisplayName("Adı"), StringLength(50), Required]
        public string Name { get; set; }
        [DisplayName("Soyadı"), StringLength(50), Required]
        public string SurName { get; set; }
        [DisplayName("Telefon")]
        public string Phone { get; set; }
        [DisplayName("Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public Customer()
        {
            Addresses = new List<Address>();
        }
    }
}
