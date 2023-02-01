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
    public partial class MLayanan : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public bool method = false;
        public bool validasiCellClick = false;
        public MLayanan()
        {
            InitializeComponent();
        }

        private void tampilLayanan()
        {
            var st = from dl in db.Layanans
                     join sat in db.Units on dl.idUnit equals sat.id
                     join kat in db.Kategoris on dl.idKategori equals kat.id
                     select new { ID_LAYANAN=dl.id, NAMA_LAYANAN=dl.Nama, KATEGORI=kat.Nama, SATUAN = sat.Nama, HARGA=dl.HargaUnit, ESTIMASI=dl.EstimasiDurasi};
            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void tampilKategori()
        {
            var st = from kt in db.Kategoris
                     select kt;

            cbKategori.ValueMember = "id";
            cbKategori.DisplayMember = "Nama";
            cbKategori.DataSource = st;
        }

        private void tampilUnit()
        {
            var st = from ut in db.Units
                     select ut;

            cbSatuan.ValueMember = "id";
            cbSatuan.DisplayMember = "Nama";
            cbSatuan.DataSource = st;
        }

        private void aktif()
        {
            txtNama.Enabled = true;
            cbKategori.Enabled = true;
            cbSatuan.Enabled = true;
            txtHarga.Enabled = true;
            txtEstimasi.Enabled = true;
            btnSimpan.Enabled = true;
            btnReset.Enabled = true;
        }
        private void nonaktif()
        {
            txtNama.Enabled = false;
            cbKategori.Enabled = false;
            cbSatuan.Enabled = false;
            txtHarga.Enabled = false;
            txtEstimasi.Enabled = false;
            btnSimpan.Enabled = false;
            btnReset.Enabled = false;
        }
        private void bersihkan()
        {
            txtId.Text = "";
            txtNama.Text = "";
            cbKategori.Text = "";
            cbSatuan.Text = "";
            txtHarga.Text = "0";
            txtEstimasi.Text = "0";

        }
        private void btnNonaktif()
        {
            btnTambah.Enabled = false;
            btnUpdate.Enabled = false;
            btnHapus.Enabled = false;
        }
        private void btnAktif()
        {
            btnTambah.Enabled = true;
            btnUpdate.Enabled = true;
            btnHapus.Enabled = true;
        }
        private void MLayanan_Load(object sender, EventArgs e)
        {
            tampilLayanan();
            tampilKategori();
            tampilUnit();
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            this.method = false;
            this.validasiCellClick = true;
            bersihkan();
            aktif();
            btnNonaktif();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.validasiCellClick = false ;

            nonaktif();
            bersihkan();
            btnAktif();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.method = true;
            btnNonaktif();
            aktif();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var st = from dl in db.Layanans
                         where dl.Nama.Contains(txtCari.Text)
                         join sat in db.Units on dl.idUnit equals sat.id
                         join kat in db.Kategoris on dl.idKategori equals kat.id
                         select new { ID_LAYANAN=dl.id, NAMA_LAYANAN=dl.Nama, KATEGORI=kat.Nama, SATUAN = sat.Nama, HARGA=dl.HargaUnit, ESTIMASI=dl.EstimasiDurasi};

                dataGridView1.DataSource = st;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if(this.validasiCellClick == false)
            {

            if (indexRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                txtId.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value.ToString();
                cbKategori.Text = row.Cells[2].Value.ToString();
                cbSatuan.Text = row.Cells[3].Value.ToString();
                txtHarga.Text = row.Cells[4].Value.ToString();
                txtEstimasi.Text = row.Cells[5].Value.ToString();

            }
            }
            else
            {

            }

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(this.method == false)
            {
                var st = new Layanan { 
                    Nama = txtNama.Text,
                    idKategori = Convert.ToInt32(cbKategori.SelectedValue),
                    idUnit = Convert.ToInt32(cbSatuan.SelectedValue),
                    HargaUnit = Convert.ToInt32(txtHarga.Text),
                    EstimasiDurasi = Convert.ToInt32(txtEstimasi.Text)
                };
                db.Layanans.InsertOnSubmit(st);
                db.SubmitChanges();
                MessageBox.Show("Berhasil Tambah");
                tampilLayanan();

            }
            else
            {
                Layanan ly = db.Layanans.FirstOrDefault(ly1 => ly1.id.Equals(txtId.Text));
                ly.Nama = txtNama.Text;
                ly.idKategori = Convert.ToInt32(cbKategori.SelectedValue);
                ly.idUnit = Convert.ToInt32(cbSatuan.SelectedValue);
                ly.HargaUnit = Convert.ToInt32(txtHarga.Text);
                ly.EstimasiDurasi = Convert.ToInt32(txtEstimasi.Text);
                db.SubmitChanges();
                MessageBox.Show("Berhasil Update");
                tampilLayanan();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "")
            {
                MessageBox.Show("Pilih Data Dahulu");

            }
            else
            {

            if (MessageBox.Show("Apakah Anda Yakin akan Menghapus", "Konfirmasi", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                  
                Layanan ly = db.Layanans.FirstOrDefault(ly1 => ly1.id.Equals(txtId.Text));
                db.Layanans.DeleteOnSubmit(ly);
                db.SubmitChanges();
                MessageBox.Show("Berhasil Hapus");
                tampilLayanan();
                bersihkan();
                nonaktif();
            }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
