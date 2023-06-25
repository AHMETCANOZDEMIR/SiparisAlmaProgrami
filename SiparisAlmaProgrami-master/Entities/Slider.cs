using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Başlık"), StringLength(100)]
        public string Title { get; set; }
        [Display(Name = "Açıklama"), StringLength(400)]
        public string Description { get; set; }
        [Display(Name = "Resim Linki"), StringLength(100)]
        public string Link { get; set; }
        [Display(Name = "Resim"), StringLength(100), Required]
        public string Image { get; set; }
    }
}
