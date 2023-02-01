using Microsoft.Reporting.WinForms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            var st = from trns in db.Transaksis
                     join plg in db.Pelanggans on trns.idPelanggan equals plg.id
                     select new {id = trns.id, idPelanggan = plg.Nama, IdPegawai = trns.IdPegawai, TanggalTransaksi = trns.TanggalTransaksi, EstimasiSelesai = trns.EstimasiSelesai };
            ReportDataSource dataSource = new ReportDataSource("Transaksi", st);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }
    }
}
