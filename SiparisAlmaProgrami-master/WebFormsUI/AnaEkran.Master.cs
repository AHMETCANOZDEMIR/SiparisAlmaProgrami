using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUI
{
    public partial class AnaEkran : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null) // asp .net de oturum açtırma işlemlerini session ile yapabiliyoruz
            {
                Response.Redirect("/Admin/Login.aspx");
            }
            else
            {
                var kullanici = Session["admin"] as Entities.User; // Session["admin"] içerisinde kullanıcı bilgisi taşıdığımız için kullanici adında bir değişken oluşturup buna session içindeki kullanıcıyı as entities.user ile aktardık
                lblKullanici.Text = "Hoşgeldin " + kullanici.UserName;
            }
            
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("admin");
            Response.Redirect("/Admin/Login.aspx");
        }
    }
}