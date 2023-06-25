using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Entities;

namespace WindowsFormsUI
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }
        UserManager manager = new UserManager();
        private void UserManagement_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSurName.Text = string.Empty;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text) & !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                int sonuc = manager.Add(
                new User
                {
                    CreateDate = DateTime.Now,
                    Email = txtEmail.Text,
                    IsActive = cbIsActive.Checked,
                    Name = txtName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text,
                    Phone = txtPhone.Text,
                    SurName = txtSurName.Text
                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                }
            }
            else MessageBox.Show("Kullanıcı adı ve Şifre boş geçilemez!");

        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);

            txtEmail.Text = kayit.Email;
            txtName.Text = kayit.Name;
            txtPassword.Text = kayit.Password;
            txtPhone.Text = kayit.Phone;
            txtSurName.Text = kayit.SurName;
            txtUserName.Text = kayit.UserName;
            cbIsActive.Checked = kayit.IsActive;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text) & !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
                int sonuc = manager.Update(
                    new User
                    {
                        Id = id,
                        CreateDate = DateTime.Now,
                        Email = txtEmail.Text,
                        IsActive = cbIsActive.Checked,
                        Name = txtName.Text,
                        Password = txtPassword.Text,
                        UserName = txtUserName.Text,
                        Phone = txtPhone.Text,
                        SurName = txtSurName.Text
                    });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                }
            }
            else MessageBox.Show("Kullanıcı adı ve Şifre boş geçilemez!");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
                var kayit = manager.Find(id);
                var sonuc = manager.Delete(kayit);
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Silindi!");
                }
            }
        }
    }
}
