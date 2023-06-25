using Entities;
using System.Data.Entity;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
            // Eğer veritabanı model classlarında bir değişiklik yaptıktan sonra veri kaybı olmadan veritabanını güncellemek istersek Entity framework migration yapısını kullanmamız gerekir!!!
            // Bu yapıyı kullanmak için Package manager console ekranını açıp (Eğer visual studio ekranında package manager console ekranı yoksa üst menüden Tools > Nuget package manager > Package manager console menüsüne tıklayarak açabiliriz) Default Project kısmından DAL projesini seçmeliyiz!
            // Sonrasında kod yazma kısmına tıklayıp enable-migrations komutunu yazıp enter ile çalıştırmalıyız.
            // Migrationu bu şekilde aktif ettikten sonra yeni bir değişiklik yaparsak artık sadece add-migration migrationismi komutu ile bu değişiklikler için migration oluşturabiliriz enable-migration sadece ilk seferinde gerekli!
            // son olarak classlardaki bu değişikliği veritabanına yansıtmak için update-database komutunu yazıp enter diyerek çalıştırmalıyız.
            // Eğer bir hata çıkarsa ekranda yazacaktır çıkmazsa done PM şeklinde komut satırı gelecektir.
            // Eğer proje classlarında sonradan bir değişiklik yaparasak
            // Her yeni ekleme veya değişiklikte yeniden Package manager console ekranını açıp DAL projesini seçip add-migration yapilanDegisiklikİsmi komutunu yazıp enter ile yeni bir migration eklemeliyiz
            // Migration başarıyla eklendikten sonra yeniden update-database komutu ile veritabanını güncellemeliyiz!
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
