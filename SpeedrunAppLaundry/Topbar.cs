using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedrunAppLaundry
{
    public partial class Topbar : UserControl
    {
        public Topbar()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            waktu.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() ;
        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void Topbar_Load(object sender, EventArgs e)
        {
            if(Login.nama == "")
            {
                name.Text = "Hi,";
            }
            else
            {
                name.Text = "Hi," + Login.nama;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
            Login frm = new Login();
            frm.Show();
        }
    }
}
