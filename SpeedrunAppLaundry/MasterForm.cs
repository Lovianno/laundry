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
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MPegawai frm = new MPegawai();
            addUserControl(frm);
        }

        private void btnMLayanan_Click(object sender, EventArgs e)
        {
            MLayanan frm = new MLayanan();
            addUserControl(frm);
        }

        private void btnMPaket_Click(object sender, EventArgs e)
        {
            MPaket frm = new MPaket();
            addUserControl(frm);
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            frm.Show();
            this.Hide();
        }
    }
}
