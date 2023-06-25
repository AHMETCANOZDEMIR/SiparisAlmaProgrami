using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class CustomerManagement : Form
    {
        public CustomerManagement()
        {
            InitializeComponent();
        }
        CustomerManager manager = new CustomerManager();
        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvMusteriler.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();
            foreach (var item in nesneler)
            {
                item.Clear();
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtSurName.Text))
            {
                var sonuc = manager.Add(new Customer
                {
                    CreateDate = DateTime.Now,
                    Email = txtEmail.Text,
                    Name = txtName.Text,
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
            else MessageBox.Show("İsim Soyisim Boş Geçilemez!");
        }

        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);

            txtEmail.Text = kayit.Email;
            txtName.Text = kayit.Name;
            txtPhone.Text = kayit.Phone;
            txtSurName.Text = kayit.SurName;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtSurName.Text))
            {
                int id = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value);
                var sonuc = manager.Update(new Customer
                {
                    Id = id,
                    CreateDate = DateTime.Now,
                    Email = txtEmail.Text,
                    Name = txtName.Text,
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
            else MessageBox.Show("İsim Soyisim Boş Geçilemez!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value);
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
