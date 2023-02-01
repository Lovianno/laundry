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
    public partial class MPaket : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private bool dgClick = false;
        private bool metode = false;

        public MPaket()
        {
            InitializeComponent();
        }


        private void tampilPaket()
        {
            var st = from pkt in db.Pakets
                     join ly in db.Layanans on pkt.idLayanan equals ly.id
                     select new { ID_PAKET = pkt.id,NAMA_PAKET= pkt.Nama, LAYANAN = ly.Nama, JUMLAH = pkt.TotalUnit, HARGA = pkt.Harga };

            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void tampilLayanan()
        {
            var st = from ly in db.Layanans
                     select ly;

            cbLayanan.ValueMember = "id";
            cbLayanan.DisplayMember = "Nama";
            cbLayanan.DataSource = st;
        }
        private void nonAktif()
        {
            btnTambah.Enabled = true;
            btnUpdate.Enabled = true;
            btnHapus.Enabled = true;
            txtNama.Enabled = false;
            cbLayanan.Enabled = false;
            txtHarga.Enabled = false;
            txtJumlah.Enabled = false;
            btnSimpan.Enabled = false;
            btnReset.Enabled = false;
        }
        private void Aktif()
        {
            btnTambah.Enabled = false;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
            txtNama.Enabled = true;
            cbLayanan.Enabled = true;
            txtHarga.Enabled = true;
            txtJumlah.Enabled = true;
            btnSimpan.Enabled = true;
            btnReset.Enabled = true;
        }
        private void bersihkan()
        {
            txtId.Clear();
            txtNama.Text = "";
            cbLayanan.Text = "";
            txtHarga.Text = "";
            txtJumlah.Text = "";
            cbLayanan.SelectedIndex = 0;
          
        }
        private void MPaket_Load(object sender, EventArgs e)
        {
            tampilPaket();
            tampilLayanan();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            this.dgClick = true;
            this.metode = true;
            Aktif();
            bersihkan();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            nonAktif();
            bersihkan();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(this.metode == true)
            {
                var st = new Paket
                {
                    idLayanan = Convert.ToInt32(cbLayanan.SelectedValue),
                    TotalUnit = Convert.ToInt32(txtJumlah.Text),
                    Harga = Convert.ToInt32(txtHarga.Text),
                    Nama = txtNama.Text

                };
                db.Pakets.InsertOnSubmit(st);
                db.SubmitChanges();
                MessageBox.Show("Berhasil Tambah");
                bersihkan();

            }
            else
            {
                Paket pkt = db.Pakets.FirstOrDefault(pk1 => pk1.id.Equals(txtId.Text));
                pkt.idLayanan = Convert.ToInt32(cbLayanan.SelectedValue);
                pkt.TotalUnit = Convert.ToInt32(txtJumlah.Text);
                pkt.Harga = Convert.ToInt32(txtHarga.Text);
                pkt.Nama = txtNama.Text;
                db.SubmitChanges();
                MessageBox.Show("Berhasil Update");
            }
            
            tampilPaket();
            
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            var st = from pkt in db.Pakets
                     where pkt.Nama.Contains(txtCari.Text)
                     join ly in db.Layanans on pkt.idLayanan equals ly.id
                     select new { ID_PAKET = pkt.id, NAMA_PAKET = pkt.Nama, LAYANAN = ly.Nama, JUMLAH = pkt.TotalUnit, HARGA = pkt.Harga };

            dataGridView1.DataSource = st;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if(dgClick == false)
            {
                if (indexRow >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[indexRow];
                    txtId.Text = row.Cells[0].Value.ToString();
                    txtNama.Text = row.Cells[1].Value.ToString();
                    cbLayanan.Text = row.Cells[2].Value.ToString();
                    txtHarga.Text = row.Cells[4].Value.ToString();
                    txtJumlah.Text = row.Cells[3].Value.ToString();
                }
            }
            else
            {

            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        if(txtId.Text == "")
            {
                MessageBox.Show("Pilih Data Dahulu");
            }
            else
            {
                Aktif();

            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Pilih Data Dahulu");
            }
            else
            {
                if(MessageBox.Show("Apakah Anda Yakin ?","Konfirmasi",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Paket pkt = db.Pakets.FirstOrDefault(pkt1 => pkt1.id.Equals(txtId.Text));
                    db.Pakets.DeleteOnSubmit(pkt);
                    db.SubmitChanges();
                    MessageBox.Show("Berhasil Hapus");
                    tampilPaket();


                    bersihkan();
                }


            }
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
