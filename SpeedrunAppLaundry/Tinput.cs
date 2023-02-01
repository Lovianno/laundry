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
    public partial class Tinput : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private DataTable dt;
        private int idPelanggan;
        private int estimasiWaktu;
        private int idLayanan;
        private int GrandTotal;
        DateTime estot = new DateTime();
        DateTime currentTime = DateTime.Now;
        private int rowKeranjang;


        public Tinput()
        {
            InitializeComponent();
        }
        private void tampilLayanan()
        {
            var st = from ly in db.Layanans
                     join sat in db.Units on ly.idUnit equals sat.id
                     select new {ID_LAYANAN = ly.id, NAMA_LAYANAN = ly.Nama, SATUAN = sat.Nama, HARGA=ly.HargaUnit, ESTIMASI = ly.EstimasiDurasi };
            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        
        }
        private void tampilKeranjang()
        {
            dt = new DataTable();
            dt.Columns.Add("ID LAYANAN");
            dt.Columns.Add("NAMA LAYANAN");
            dt.Columns.Add("QTY");
            dt.Columns.Add("HARGA");
            dt.Columns.Add("ESTIMASI SELESAI");


            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void perhitungan()
        {
            this.GrandTotal = 0;
            int waktu = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                this.GrandTotal += Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value.ToString());
                waktu += Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value.ToString());

            }
            txtTotal.Text = this.GrandTotal.ToString();
            this.estot = currentTime.AddHours(waktu);
        }
        private void bersihkan()
        {
            txtTelp.Text = "";
            txtNamaPlg.Text = "";
            txtAlamat.Text = "";
        }
        private void Tinput_Load(object sender, EventArgs e)
        {
            tampilLayanan();
            tampilKeranjang();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var st = from plg in db.Pelanggans
                         where plg.Notelp.Contains(txtTelp.Text)
                         select plg;
                if (st.Any())
                {
                    foreach (var plg in st)
                    {
                        txtNamaPlg.Text = plg.Nama;
                        txtAlamat.Text = plg.Alamat;
                        this.idPelanggan = plg.id;
                    }
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data yang Ditemukan!!");
                    bersihkan();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TambahPelangganForm frm = new TambahPelangganForm();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow > 0)
            {

                DataGridViewRow row = dataGridView1.Rows[indexRow];
                txtLayanan.Text = row.Cells[1].Value.ToString();
                txtHarga.Text = row.Cells[3].Value.ToString();
                this.idLayanan = Convert.ToInt32(row.Cells[0].Value);
                this.estimasiWaktu = Convert.ToInt32(row.Cells[4].Value);
                txtQty.Text = "1";


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var st = from ly in db.Layanans
                         where ly.Nama.Contains(txtCari.Text)
                         join sat in db.Units on ly.idUnit equals sat.id
                         select new { ID_LAYANAN = ly.id, NAMA_LAYANAN = ly.Nama, SATUAN = sat.Nama, HARGA = ly.HargaUnit, ESTIMASI = ly.EstimasiDurasi };
                if (st.Any())
                {
                    dataGridView1.DataSource = st;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang ditemukan");

                }
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if(txtQty.Value == 0 || txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Quantity Tidak Boleh Kosong");
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr[0] = this.idLayanan;
                dr[1] = txtLayanan.Text;
                dr[2] = txtQty.Value;
                dr[3] = txtQty.Value * Convert.ToInt32(txtHarga.Text);
                dr[4] = this.estimasiWaktu;

                dt.Rows.Add(dr);

                // Perhitungan 
                perhitungan();
            }
          



        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(txtNamaPlg.Text == "")
            {
                MessageBox.Show("Pilih Pelanggan Dahulu");
            }
            else
            {

            var st = new Transaksi
            {
                idPelanggan = this.idPelanggan,
                IdPegawai = Login.idPegawai,
                TanggalTransaksi = currentTime,
                EstimasiSelesai = estot
            };
            db.Transaksis.InsertOnSubmit(st);
            db.SubmitChanges();

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                var stat = new DetailTransaksi
                {
                    idTransaksi = st.id,
                    idLayanan = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value),
                    HargaUnit = Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value) / Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value),
                    TotalUnit = Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value),
                    TanggalSelesai = estot
                };
                db.DetailTransaksis.InsertOnSubmit(stat);
                db.SubmitChanges();
            }
            MessageBox.Show("Transaksi Berhasil");
            tampilKeranjang();
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowKeranjang = e.RowIndex;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count > 0)
            {

            dataGridView2.Rows.RemoveAt(this.rowKeranjang);
                perhitungan();
            }
            else
            {
                MessageBox.Show("Keranjang Kosong");
            }

        }
    }
}
