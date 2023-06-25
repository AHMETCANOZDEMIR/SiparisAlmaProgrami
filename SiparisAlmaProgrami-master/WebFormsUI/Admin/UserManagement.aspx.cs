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
    public partial class UserManagement : System.Web.UI.Page
    {
        UserManager manager = new UserManager();
        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
            dgvKullanicilar.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
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
                    Response.Redirect("UserManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Kullanıcı adı ve Şifre boş geçilemez!')</script>");
        }

        protected void dgvKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
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

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text) & !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                int id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
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
                    Response.Redirect("UserManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Kullanıcı adı ve Şifre boş geçilemez!')</script>");
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
                var kayit = manager.Find(id);
                var sonuc = manager.Delete(kayit);
                if (sonuc > 0) Response.Redirect("UserManagement.aspx");
            }
            catch (Exception hata)
            {
                Response.Write("<script>alert('Hata Oluştu!')</script>");
            }
        }
    }
}