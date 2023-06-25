using BL;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        UserManager manager = new UserManager();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            var user = manager.GetUser(username: txtUsername.Text.Trim(), password: txtPassword.Text.Trim());

            if (user != null)
            {
                AnaEkran anaEkran = new AnaEkran();
                this.Hide();
                anaEkran.Show();
            }
            else MessageBox.Show("Giriş Başarısız! Tekrar Deneyin..");
        }
    }
}
