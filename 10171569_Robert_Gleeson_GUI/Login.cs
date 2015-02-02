using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _10171569_Robert_Gleeson_GUI
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        { 
            //Call HashCode class
            HashCode hs = new HashCode();

            //Username 'admin' and password is 'bandit' - genereted and checked  via SHA1
            string userName = "admin";
            string password = "1010222571875253404516994247219412521494146120148";

            string user = txtUserName.Text;
            //Local variable pass checked against PassHash
            string pass = hs.PassHash(txtPassword.Text);

            if (user == userName)
            {
                if (pass == password)
                {
                    MessageBox.Show("Hello, you are logged in", "SUCCESS");
                    AddPerson p = new AddPerson();
                    p.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "ERROR");
                }
            }
            else
            {
                MessageBox.Show("Incorrect Username", "ERROR");
            }           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
               
    }
}
