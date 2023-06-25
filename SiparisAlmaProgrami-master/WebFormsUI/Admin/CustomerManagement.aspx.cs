using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUI
{
    public partial class CustomerManagement : System.Web.UI.Page
    {
        CustomerManager manager = new CustomerManager();
        void Yukle(string kelime = "")
        {
            dgvMusteriler.DataSource = manager.GetAll(k => k.Name.Contains(kelime) | k.SurName.Contains(kelime));
            dgvMusteriler.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
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
                    Response.Redirect("CustomerManagement.aspx");
                }
            }
            else Response.Write("<script>alert('İsim Soyisim Boş Geçilemez!')</script>");// MessageBox.Show("");
        }

        protected void dgvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvMusteriler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);

            txtEmail.Text = kayit.Email;
            txtName.Text = kayit.Name;
            txtPhone.Text = kayit.Phone;
            txtSurName.Text = kayit.SurName;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtSurName.Text))
            {
                int id = Convert.ToInt32(dgvMusteriler.SelectedRow.Cells[1].Text);
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
                    Response.Redirect("CustomerManagement.aspx");
                }
            }
            else Response.Write("<script>alert('İsim Soyisim Boş Geçilemez!')</script>");
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMusteriler.SelectedRow.Cells[1].Text);
                var kayit = manager.Find(id);
                var sonuc = manager.Delete(kayit);
                if (sonuc > 0)
                {
                    Response.Redirect("CustomerManagement.aspx");
                }
            }
            catch (Exception hata)
            {
                Response.Write("<script>alert('Hata Oluştu!')</script>");
            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            Yukle(txtAra.Text.Trim()); // Trim metodu textbox ın içindeki değerin önüne ve sonuna eklenen boşluk karakterlerini kaldırır
        }
    }
}