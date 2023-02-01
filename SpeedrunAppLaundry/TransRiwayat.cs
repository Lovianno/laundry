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
    public partial class TransRiwayat : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public TransRiwayat()
        {
            InitializeComponent();
        }

        private void tampilTransaksi()
        {
            var st = from tr in db.Transaksis
                     join plg in db.Pelanggans on tr.idPelanggan equals plg.id
                     join pgw in db.Pegawais on tr.IdPegawai equals pgw.id
                     select new { ID = tr.id, id_pelanggan = tr.idPelanggan, nama_pelanggan = plg.Nama, nama_pegawai = pgw.Nama, tanggal_transaksi = tr.TanggalTransaksi, tanggal_selesai = tr.EstimasiSelesai };
            dataGridView1.DataSource = st;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void TransRiwayat_Load(object sender, EventArgs e)
        {
            tampilTransaksi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if(indexRow > 0)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                var st = from dtl in db.DetailTransaksis
                         where dtl.idTransaksi == Convert.ToInt32(row.Cells[0].Value)
                         join ly in db.Layanans on dtl.idLayanan equals ly.id
                         //join dtp in db.DetailPakets on dtl.idDetailPaket equals dtp.id
                         // , idPaket = dtp.idPaket
                         //select new { Nama_Layanan = ly.Nama, HargaPerUnit = dtl.HargaUnit, TotalUnit = dtl.TotalUnit, TanggalSelesai = dtl.TanggalSelesai };
                select new { NamaLayanan = ly.Nama, idDetailPaket = dtl.idDetailPaket, HargaUnit = dtl.HargaUnit, TotalUnit = dtl.TotalUnit, TanggalSelesai = dtl.TanggalSelesai };
                dataGridView2.DataSource = st;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            }
        }
    }
}
