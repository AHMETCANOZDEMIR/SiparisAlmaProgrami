using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Adı"), StringLength(50), Required]
        public string Name { get; set; }
        [DisplayName("Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
    }
}
