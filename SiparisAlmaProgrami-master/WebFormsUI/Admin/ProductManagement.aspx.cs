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
    public partial class ProductManagement : System.Web.UI.Page
    {
        ProductManager manager = new ProductManager();
        CategoryManager category = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) Yukle();
        }
        void Yukle()
        {
            dgvUrunler.DataSource = manager.GetAll();
            dgvUrunler.DataBind();
            cbKategoriler.DataSource = category.GetAll();
            cbKategoriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                var product = new Product
                {
                    CategoryId = Convert.ToInt32(cbKategoriler.SelectedValue),
                    CreateDate = DateTime.Now,
                    Description = txtDescription.Text,
                    IsActive = cbIsActive.Checked,
                    Name = txtName.Text,
                    Price = Convert.ToDecimal(txtPrice.Text.Trim()), // Trim metodu textbox a girilen değerin önündeki ve sonundaki boşlukları kaldırır
                    Stock = Convert.ToInt32(txtStock.Text.Trim())
                };                
                if (fuImage.HasFile)
                {
                    fuImage.SaveAs(Server.MapPath("/Images/" + fuImage.FileName));
                    product.Image = fuImage.FileName;
                }
                var sonuc = manager.Add(product);
                if (sonuc > 0)
                {
                    Response.Redirect("ProductManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Ürün Adı ve Fiyatı Boş Geçilemez!')</script>");
        }

        protected void dgvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;

            txtStock.Text = kayit.Stock.ToString();
            txtPrice.Text = kayit.Price.ToString();
            txtName.Text = kayit.Name;
            txtDescription.Text = kayit.Description;
            cbIsActive.Checked = kayit.IsActive;
            cbKategoriler.SelectedValue = kayit.CategoryId.ToString();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) & !string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                int id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
                var product = new Product
                {
                    Id = id,
                    CategoryId = Convert.ToInt32(cbKategoriler.SelectedValue),
                    CreateDate = DateTime.Now,
                    Description = txtDescription.Text,
                    IsActive = cbIsActive.Checked,
                    Name = txtName.Text,
                    Price = Convert.ToDecimal(txtPrice.Text.Trim()), // Trim metodu textbox a girilen değerin önündeki ve sonundaki boşlukları kaldırır
                    Stock = Convert.ToInt32(txtStock.Text.Trim())
                };
                if (fuImage.HasFile)
                {
                    fuImage.SaveAs(Server.MapPath("/Images/" + fuImage.FileName));
                    product.Image = fuImage.FileName;
                }
                var sonuc = manager.Update(product);
                if (sonuc > 0)
                {
                    Response.Redirect("ProductManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Ürün Adı ve Fiyatı Boş Geçilemez!')</script>");
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);
            var sonuc = manager.Delete(kayit);
            if (sonuc > 0)
            {
                Response.Redirect("ProductManagement.aspx");
            }
        }
    }
}