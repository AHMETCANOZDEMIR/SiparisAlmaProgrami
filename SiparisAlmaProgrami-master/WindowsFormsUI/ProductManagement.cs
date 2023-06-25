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
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
        }
        ProductManager manager = new ProductManager();
        CategoryManager category = new CategoryManager();
        void Yukle()
        {
            //dgvUrunler.DataSource = manager.GetAll();
            dgvUrunler.DataSource = manager.GetProducts();
            cbKategoriler.DataSource = category.GetAll();
        }
        void Temizle()
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();
            foreach (var item in nesneler)
            {
                item.Clear();
            }
        }
        private void ProductManagement_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                var sonuc = manager.Add(new Product
                {
                    CategoryId = (int)cbKategoriler.SelectedValue,
                    CreateDate = DateTime.Now,
                    Description = txtDescription.Text,
                    IsActive = cbIsActive.Checked,
                    Name = txtName.Text,
                    Price = Convert.ToDecimal(txtPrice.Text.Trim()), // Trim metodu textbox a girilen değerin önündeki ve sonundaki boşlukları kaldırır
                    Stock = Convert.ToInt32(txtStock.Text.Trim())
                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                }
            }
            else MessageBox.Show("Ürün Adı ve Fiyatı Boş Geçilemez!");
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;

            txtStock.Text = kayit.Stock.ToString();
            txtPrice.Text = kayit.Price.ToString();
            txtName.Text = kayit.Name;
            txtDescription.Text = kayit.Description;
            cbIsActive.Checked = kayit.IsActive;
            cbKategoriler.SelectedValue = kayit.CategoryId;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var sonuc = manager.Update(new Product
                {
                    Id = id,
                    CategoryId = (int)cbKategoriler.SelectedValue,
                    CreateDate = DateTime.Now,
                    Description = txtDescription.Text,
                    IsActive = cbIsActive.Checked,
                    Name = txtName.Text,
                    Price = Convert.ToDecimal(txtPrice.Text.Trim()), // Trim metodu textbox a girilen değerin önündeki ve sonundaki boşlukları kaldırır
                    Stock = Convert.ToInt32(txtStock.Text.Trim())
                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                }
            }
            else MessageBox.Show("Ürün Adı ve Fiyatı Boş Geçilemez!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            var urunler = manager.GetAll(u => u.Name.Contains(txtArama.Text.Trim()));
            dgvUrunler.DataSource = urunler;
        }
    }
}
