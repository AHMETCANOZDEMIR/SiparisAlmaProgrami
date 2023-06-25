using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data.Entity.Migrations;

namespace BL
{
    public class UserManager
    {
        DatabaseContext context = new DatabaseContext(); // Kullanıcı işlemlerini yapabilmek için
        public List<User> GetAll() // Geriye kullanıcı listesi döndüren metot
        {
            return context.Users.ToList(); //DatabaseContext teki kullanıcı listesini döndür
        }
        public int Add(User user)
        {
            context.Users.Add(user); // context içindeki users tablosuna parametreyle gelen user ı ekledik
            return context.SaveChanges(); // ekleme işleminin veritabanına işlenmesi için
        }

        public User Find(int id)
        {
            return context.Users.Find(id);
        }

        public int Update(User user)
        {
            context.Users.AddOrUpdate(user);
            return context.SaveChanges();
        }

        public int Delete(User user)
        {
            context.Users.Remove(user);
            return context.SaveChanges();
        }

        public User GetUser(string username, string password)
        {
            return context.Users.FirstOrDefault(u => u.IsActive == true & u.UserName == username & u.Password == password); //FirstOrDefault metodu veritabanındaki ilk kaydı getirir
        }

    }
}
