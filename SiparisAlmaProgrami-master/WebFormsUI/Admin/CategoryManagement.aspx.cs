using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Entities;

namespace WebFormsUI
{
    public partial class CategoryManagement : System.Web.UI.Page
    {
        CategoryManager manager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
            dgvKategoriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
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
                    Response.Redirect("CategoryManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Kategori Adı Boş Geçilemez!')</script>");
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                int id = Convert.ToInt32(dgvKategoriler.SelectedRow.Cells[1].Text);
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
                    Response.Redirect("CategoryManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Kategori Adı Boş Geçilemez!')</script>");
        }

        protected void dgvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvKategoriler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);

            btnSil.Enabled = true;
            btnGuncelle.Enabled = true;

            txtName.Text = kayit.Name;
            txtDescription.Text = kayit.Description;
            cbIsActive.Checked = kayit.IsActive;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvKategoriler.SelectedRow.Cells[1].Text);
                var kayit = manager.Find(id);
                var sonuc = manager.Delete(kayit);
                if (sonuc > 0)
                {
                    Response.Redirect("CategoryManagement.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Hata Oluştu!')</script>");
            }
        }
    }
}