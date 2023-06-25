namespace DAL.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // Migrationda olası data kaybına izin ver
            ContextKey = "DAL.DatabaseContext";
        }

        protected override void Seed(DAL.DatabaseContext context)
        {
            //  Migrationsu aktif ettikten sonra artık buradaki seed metodu geçerlidir

            //  Varsayılan kullanıcı ekleme işlemini artık burada yapmalıyız

            if (!context.Users.Any()) //eğer veritabanında hiç kullanıcı yoksa
            {
                context.Users.Add(
                    new User
                    {
                        CreateDate = DateTime.Now,
                        Email = "admin@siparistakip.com",
                        IsActive = true,
                        Name = "admin",
                        Password = "123456",
                        UserName = "admin"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
