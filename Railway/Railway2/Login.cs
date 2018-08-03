using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string user = bunifuTextbox1.text;
            string pass = bunifuTextbox2.text;
            if (user.Equals("user") && pass.Equals("user"))
            {
                Form1 f2 = new Form1();
                this.Hide();
                f2.Show();
                //Createschedule cs = new Createschedule();
                //cs.Show();
                
            }
            if (user.Equals("admin") && pass.Equals("admin"))
            {
                Createschedule cs = new Createschedule();
                
                this.Dispose();
                cs.Show();
                
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        }
    }

