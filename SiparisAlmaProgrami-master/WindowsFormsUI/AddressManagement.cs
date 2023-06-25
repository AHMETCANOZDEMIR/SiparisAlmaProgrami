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
    public partial class AddressManagement : Form
    {
        public AddressManagement()
        {
            InitializeComponent();
        }
        AddressManager manager = new AddressManager();
        CustomerManager customer = new CustomerManager();
        private void AddressManagement_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvAdresler.DataSource = manager.GetAll();
            cbCustomers.DataSource = customer.GetAll();
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
            if (!string.IsNullOrWhiteSpace(txtOpenAddress.Text))
            {
                var sonuc = manager.Add(new Address
                {
                    CreateDate = DateTime.Now,
                    CustomerId = (int)cbCustomers.SelectedValue,
                    OpenAddress = txtOpenAddress.Text,
                    Title = txtTitle.Text
                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                }
            }
            else MessageBox.Show("Adres Giriniz!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOpenAddress.Text))
            {
                int id = Convert.ToInt32(dgvAdresler.CurrentRow.Cells[0].Value);
                var sonuc = manager.Update(new Address
                {
                    Id = id,
                    CreateDate = DateTime.Now,
                    CustomerId = (int)cbCustomers.SelectedValue,
                    OpenAddress = txtOpenAddress.Text,
                    Title = txtTitle.Text
                });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                }
            }
            else MessageBox.Show("Adres Giriniz!");
        }

        private void dgvAdresler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvAdresler.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);

            btnSil.Enabled = true;
            btnGuncelle.Enabled = true;

            txtTitle.Text = kayit.Title;
            txtOpenAddress.Text = kayit.OpenAddress;
            cbCustomers.SelectedValue = kayit.CustomerId;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvAdresler.CurrentRow.Cells[0].Value);
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
