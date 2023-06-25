using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Başlık"), StringLength(50), Required] // StringLength(50) kodu title alanının veritabanında 50 karakterle sınırlanmasını sağlar bunu vermezsek nvarchar max yapar
        public string Title { get; set; }
        [DisplayName("Açık Adres"), Required, DataType(DataType.MultilineText)]
        public string OpenAddress { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Müşteri")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
