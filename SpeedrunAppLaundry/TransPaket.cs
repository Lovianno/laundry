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
    public partial class TransPaket : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private int idPelanggan;
        DateTime currentTime = DateTime.Now;
        private DateTime est;
        private int idLayanan;
        private int waktu;
        public TransPaket()
        {
            InitializeComponent();
        }
        private void tampilPaket()
        {
            var st = from pkt in db.Pakets
                     join ly in db.Layanans on pkt.idLayanan equals ly.id
                     select new { ID_PAKET = pkt.id,NAMA_PAKET = pkt.Nama, LAYANAN = ly.Nama, JUMLAH = pkt.TotalUnit, HARGA = pkt.Harga, idly = pkt.idLayanan};

            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Columns[5].Visible = true;
        }
        private void estimasiSelesai()
        {
            var st = from ly in db.Layanans
                     where ly.id == idLayanan
                     select ly;

            foreach(var ly in st)
            {
                this.waktu = ly.EstimasiDurasi;
            }
        }

        private void TransPaket_Load(object sender, EventArgs e)
        {
            tampilPaket();
            var st = db.Layanans.OrderByDescending(x => x.id).FirstOrDefault();
            txtId.Text = (st.id+ 1).ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if(indexRow > 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                txtId.Text = row.Cells[0].Value.ToString();
                txtLayanan.Text = row.Cells[2].Value.ToString();
                txtHarga.Text = row.Cells[4].Value.ToString();
                this.idLayanan = Convert.ToInt32(row.Cells[5].Value);


            }
        }

        private void textTelp_TextChanged(object sender, EventArgs e)
        {
            var st = from plg in db.Pelanggans
                     where plg.Notelp.Contains(txtTelp.Text)
                     select plg;
            if (st.Any())
            {
                foreach (var plg in st)
                {
                    txtNama.Text = plg.Nama;
                    txtAlamat.Text = plg.Alamat;
                    this.idPelanggan = plg.id;
                };

            }
            else
            {
                MessageBox.Show("Tidak Ada Data yang ditemukan");
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TambahPelangganForm frm = new TambahPelangganForm();
            frm.Show();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "")
            {
                MessageBox.Show("Pilih Pelanggan Dahulu");
            }
            else
            {
                try
                {

                estimasiSelesai();
                var st = new Transaksi
                {
                    idPelanggan = this.idPelanggan,
                    IdPegawai = Login.idPegawai,
                    TanggalTransaksi = currentTime,
                    EstimasiSelesai = currentTime.AddHours(this.waktu)

                };
                    db.Transaksis.InsertOnSubmit(st);
                    db.SubmitChanges();

                    var stt = new DetailPaket
                    {
                        idPelanggan = idPelanggan,
                        idPaket = Convert.ToInt32(txtId.Text),
                        Harga = Convert.ToInt32(txtHarga.Text),
                        TanggalMulai = currentTime,
                        TanggalSelesai = st.EstimasiSelesai

                    };
                    db.DetailPakets.InsertOnSubmit(stt);
                    db.SubmitChanges();

                    txtNama.Text = stt.id.ToString();
                    var sttt = new DetailTransaksi
                    {
                        idTransaksi = st.id,
                        idLayanan = this.idLayanan,
                        idDetailPaket = stt.id,
                        HargaUnit = stt.Harga,
                        TotalUnit = 1,
                        TanggalSelesai = st.EstimasiSelesai

                    };
                    db.DetailTransaksis.InsertOnSubmit(sttt);
                    db.SubmitChanges();

                    MessageBox.Show("Success");

                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            txtNama.Text = idLayanan.ToString();
            estimasiSelesai();
            txtAlamat.Text = waktu.ToString(); 
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
