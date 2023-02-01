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
    public partial class TransaksiForm : Form
    {
        public TransaksiForm()
        {
            InitializeComponent();
          
        }
        private void TransaksiForm_Load(object sender, EventArgs e)
        {

        }
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tinput frm = new Tinput();
            addUserControl(frm);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransPaket frm = new TransPaket();
            addUserControl(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransRiwayat frm = new TransRiwayat();
            addUserControl(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            frm.Show();
            this.Close();
        }
    }
}
