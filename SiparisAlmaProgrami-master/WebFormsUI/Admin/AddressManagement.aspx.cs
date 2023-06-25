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
    public partial class AddressManagement : System.Web.UI.Page
    {
        AddressManager manager = new AddressManager();
        CustomerManager customer = new CustomerManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) Yukle(); // eğer sayfa postback olmamışsa
        }
        void Yukle()
        {
            dgvAdresler.DataSource = manager.GetAll();
            dgvAdresler.DataBind(); // web tarafında verilerin grid view a yüklenmesi için bu metodu da eklememiz gerekli!
            cbCustomers.DataSource = customer.GetAll();
            cbCustomers.DataBind(); // ekrandaki drop down liste müşterileri doldur
            // Ön yüzdeki drop down liste sağ tıklayıp properties den append data bound items ı true yapmayı unutma!! yoksa seçili id alınamaz!
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOpenAddress.Text))
            {
                var sonuc = manager.Add(new Address
                {
                    CreateDate = DateTime.Now,
                    CustomerId = Convert.ToInt32(cbCustomers.SelectedValue),
                    OpenAddress = txtOpenAddress.Text,
                    Title = txtTitle.Text
                });
                if (sonuc > 0)
                {
                    Response.Redirect("AddressManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Adres Giriniz!')</script>");
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOpenAddress.Text))
            {
                int id = Convert.ToInt32(dgvAdresler.SelectedRow.Cells[1].Text);
                var sonuc = manager.Update(new Address
                {
                    Id = id,
                    CreateDate = DateTime.Now,
                    CustomerId = Convert.ToInt32(cbCustomers.SelectedValue),
                    OpenAddress = txtOpenAddress.Text,
                    Title = txtTitle.Text
                });
                if (sonuc > 0)
                {
                    Response.Redirect("AddressManagement.aspx");
                }
            }
            else Response.Write("<script>alert('Adres Giriniz!')</script>");
        }

        protected void dgvAdresler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvAdresler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);

            btnSil.Enabled = true;
            btnGuncelle.Enabled = true;

            txtTitle.Text = kayit.Title;
            txtOpenAddress.Text = kayit.OpenAddress;
            cbCustomers.SelectedValue = kayit.CustomerId.ToString();
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                id = Convert.ToInt32(dgvAdresler.SelectedRow.Cells[1].Text);
                if (id > 0)
                {
                    var kayit = manager.Find(id);
                    var sonuc = manager.Delete(kayit);
                    if (sonuc > 0)
                    {
                        Response.Redirect("AddressManagement.aspx");
                    }
                }
                else Response.Write("<script>alert('Listeden Kayıt Seçiniz!')</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Hata Oluştu!')</script>");
            }
        }
    }
}