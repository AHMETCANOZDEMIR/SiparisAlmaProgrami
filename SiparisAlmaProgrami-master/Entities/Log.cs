using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Oluşan Hata")]
        public string Error { get; set; }
        [Display(Name = "Hata Oluşma Tarihi")]
        public DateTime? CreateDate { get; set; }
        [Display(Name = "Hata Bilgi")]
        public string ErrorInfo { get; set; }
    }
}
