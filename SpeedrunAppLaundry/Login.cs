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
    public partial class Login : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static string nama;
        public static int idPegawai;
        public static int role;
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var st = from pg in db.Pegawais
                     where pg.Email == txtUsername.Text &&
                     pg.Password == txtPassword.Text
                     select pg;

            if (st.Any())
            {
                foreach (var item in st)
                {
                    nama = item.Nama;
                    role = item.idJabatan;
                   idPegawai = item.id;


                }
                Home FrmHm = new Home();
                this.Hide();
                FrmHm.Show();


            }
            else
            {
                MessageBox.Show("“Maaf email atau password anda salah, hubungi admin");
            }
        }

      


        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void RESET_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
