using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace SpeedrunAppLaundry
{
    public partial class MPegawai : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public bool method = false;
        public MPegawai()
        {
            InitializeComponent();
        }

       public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public void bersihkan()
        {
            txtId.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtTelp.Text = "";
            //cbJabatan.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbJabatan.SelectedIndex = 0;
            
        }
        public void nonAktif()
        {
            txtNama.Enabled = false;
            txtAlamat.Enabled = false;
            txtTelp.Enabled = false;
            cbJabatan.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnSimpan.Enabled = false;
            btnReset.Enabled = false;
            btnTambah.Enabled = true;
            btnUpdate.Enabled = true;
            btnHapus.Enabled = true;
        }
        public void Aktif()
        {
            txtNama.Enabled = true;
            txtAlamat.Enabled = true;
            txtTelp.Enabled = true;
            cbJabatan.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnSimpan.Enabled = true;
            btnReset.Enabled = true;
          
        }
        public void tampilPegawai()
        {
            var st = from pg in db.Pegawais
                     join jb in db.Jabatans on pg.idJabatan equals jb.id
                     select new { ID_PEGAWAI=pg.id, NAMA=pg.Nama, ALAMAT=pg.Alamat,NoTelp=pg.Notelp, JABATAN = jb.NamaJabatan, USERNAME=pg.Email, PASSWORD=pg.Password};
            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void tampilJabatan()
        {
            var st = from jb in db.Jabatans
                     select new { id = jb.id, NamaJabatan = jb.NamaJabatan };
            cbJabatan.DisplayMember = "NamaJabatan";
            cbJabatan.ValueMember = "id";
            cbJabatan.DataSource = st;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MPegawai_Load(object sender, EventArgs e)
        {
            tampilPegawai();
            tampilJabatan();
            nonAktif();
            string password = sha256("123");
            txtAlamat.Text = password;


        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            Aktif();
            bersihkan();
            btnTambah.Enabled = false;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
            this.method = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Aktif();

            btnTambah.Enabled = false;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;

            this.method = true;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show("Pilih Data Dahulu!!");
            }
            else
            {


                if (MessageBox.Show("Apakah Anda Yakin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    Pegawai pg = db.Pegawais.FirstOrDefault(p1 => p1.id.Equals(txtId.Text));
                    db.Pegawais.DeleteOnSubmit(pg);
                    db.SubmitChanges();
                    MessageBox.Show("Berhasil Menghapus");
                    tampilPegawai();
                    nonAktif();
                    bersihkan();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            nonAktif();
            bersihkan();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            var st = from pg in db.Pegawais
                     where pg.Nama.Contains(txtCari.Text) || pg.Notelp.Contains(txtCari.Text) || pg.Email.Contains(txtCari.Text)
                     join jb in db.Jabatans on pg.idJabatan equals jb.id
                     select new { ID_PEGAWAI = pg.id, NAMA = pg.Nama, ALAMAT = pg.Alamat, NoTelp = pg.Notelp, JABATAN = jb.NamaJabatan, USERNAME = pg.Email, PASSWORD = pg.Password };

            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            if(RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value.ToString();
                txtAlamat.Text = row.Cells[2].Value.ToString();
                txtTelp.Text = row.Cells[3].Value.ToString();
                cbJabatan.Text = row.Cells[4].Value.ToString();
                txtUsername.Text = row.Cells[5].Value.ToString();
                txtPassword.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" || txtNama.Text.Trim() == "" || txtUsername.Text.Trim() == "" || txtAlamat.Text.Trim() == "" || txtTelp.Text.Trim() == "" || cbJabatan.Text.Trim() == "")
            {
                MessageBox.Show("Tidak Boleh Ada Data yang Kosong!!");
            }
            else
            {

            if(this.method == false)
            {
                    string password = sha256(txtPassword.Text);
                var st = new Pegawai
                {
                    Nama = txtNama.Text,
                    Alamat = txtAlamat.Text,
                    Notelp = txtTelp.Text,
                    idJabatan = Convert.ToInt32(cbJabatan.SelectedValue),
                    Email = txtUsername.Text,
                    Password = password
                };
                db.Pegawais.InsertOnSubmit(st);
                db.SubmitChanges();
                MessageBox.Show("Berhasil Tambah");
                tampilPegawai();
            }
            else
            {
                Pegawai pg = db.Pegawais.FirstOrDefault(pg1 => pg1.id.Equals(txtId.Text));
                pg.Nama = txtNama.Text;
                pg.Alamat = txtAlamat.Text;
                pg.Notelp = txtTelp.Text;
                pg.idJabatan = Convert.ToInt32(cbJabatan.SelectedValue);
                pg.Email = txtUsername.Text;
                pg.Password = txtPassword.Text;
                db.SubmitChanges();
                MessageBox.Show("Berhasil Update");
                tampilPegawai();
            }

            }


        }
    }
}
