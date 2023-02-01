
namespace SpeedrunAppLaundry
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMaster = new System.Windows.Forms.Button();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.topbar1 = new SpeedrunAppLaundry.Topbar();
            this.SuspendLayout();
            // 
            // btnMaster
            // 
            this.btnMaster.Location = new System.Drawing.Point(280, 113);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(145, 45);
            this.btnMaster.TabIndex = 0;
            this.btnMaster.Text = "MASTER";
            this.btnMaster.UseVisualStyleBackColor = true;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(198, 173);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(145, 45);
            this.btnTransaksi.TabIndex = 1;
            this.btnTransaksi.Text = "TRANSAKSI";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Location = new System.Drawing.Point(367, 173);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(145, 45);
            this.btnLaporan.TabIndex = 2;
            this.btnLaporan.Text = "LAPORAN";
            this.btnLaporan.UseVisualStyleBackColor = true;
            // 
            // topbar1
            // 
            this.topbar1.Location = new System.Drawing.Point(-3, -1);
            this.topbar1.Name = "topbar1";
            this.topbar1.Size = new System.Drawing.Size(711, 95);
            this.topbar1.TabIndex = 3;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 340);
            this.Controls.Add(this.topbar1);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.btnMaster);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NusaLaundry - Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.Button btnLaporan;
        private Topbar topbar1;
    }
}

