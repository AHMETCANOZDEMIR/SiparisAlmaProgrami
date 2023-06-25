using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUI.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        LoginManager manager = new LoginManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            var kullanici = manager.Get(kul => kul.UserName == txtKullaniciAdi.Text.Trim() & kul.Password == txtSifre.Text.Trim() & kul.IsActive);

            if (kullanici != null)
            {
                Session["admin"] = kullanici; // Eğer girilen bilgilere eşleşen bir kullanıcı varsa, bunu Session["admin"] nesnesine yükle
                Response.Redirect("/Admin/");  // Session ile sunucu üzerinde sayfalar arasında veri taşıyabiliriz
            }
            else
            {
                Response.Write("<script>alert('Giriş Başarısız!')</script>");
            }
        }
    }
}