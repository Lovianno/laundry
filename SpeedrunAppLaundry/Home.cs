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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if(Login.role == 2)
            {
                btnMaster.Visible = false;
            }
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            MasterForm FrmMaster = new MasterForm();
            FrmMaster.Show();
            this.Hide();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            TransaksiForm FrmMaster = new TransaksiForm();
            FrmMaster.Show();
            this.Hide();
        }
    }
}
