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
    public partial class CategoryManagement : Form
    {
        public CategoryManagement()
        {
            InitializeComponent();
        }
        CategoryManager manager = new CategoryManager();
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();
            foreach (var item in nesneler)
            {
                item.Clear();
            }
        }
        private void CategoryManagement_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                var sonuc = manager.Add(
                    new Category
                    {
                        Description = txtDescription.Text,
                        IsActive = cbIsActive.Checked,
                        Name = txtName.Text
                    });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                }
            }
            else MessageBox.Show("Kategori Adı Boş Geçilemez!");
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);

            btnSil.Enabled = true;
            btnGuncelle.Enabled = true;

            txtName.Text = kayit.Name;
            txtDescription.Text = kayit.Description;
            cbIsActive.Checked = kayit.IsActive;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                int id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                var sonuc = manager.Update(
                    new Category
                    {
                        Id = id,
                        Description = txtDescription.Text,
                        IsActive = cbIsActive.Checked,
                        Name = txtName.Text
                    });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                }
            }
            else MessageBox.Show("Kategori Adı Boş Geçilemez!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
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
