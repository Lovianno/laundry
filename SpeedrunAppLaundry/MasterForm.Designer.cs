
namespace SpeedrunAppLaundry
{
    partial class MasterForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMPaket = new System.Windows.Forms.Button();
            this.btnMLayanan = new System.Windows.Forms.Button();
            this.btnMPegawai = new System.Windows.Forms.Button();
            this.btnKembali = new System.Windows.Forms.Button();
            this.panelControl = new System.Windows.Forms.Panel();
            this.topbar1 = new SpeedrunAppLaundry.Topbar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMPaket);
            this.panel1.Controls.Add(this.btnMLayanan);
            this.panel1.Controls.Add(this.btnMPegawai);
            this.panel1.Controls.Add(this.btnKembali);
            this.panel1.Location = new System.Drawing.Point(32, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 202);
            this.panel1.TabIndex = 0;
            // 
            // btnMPaket
            // 
            this.btnMPaket.Location = new System.Drawing.Point(3, 137);
            this.btnMPaket.Name = "btnMPaket";
            this.btnMPaket.Size = new System.Drawing.Size(121, 23);
            this.btnMPaket.TabIndex = 3;
            this.btnMPaket.Text = "Master Paket";
            this.btnMPaket.UseVisualStyleBackColor = true;
            this.btnMPaket.Click += new System.EventHandler(this.btnMPaket_Click);
            // 
            // btnMLayanan
            // 
            this.btnMLayanan.Location = new System.Drawing.Point(3, 108);
            this.btnMLayanan.Name = "btnMLayanan";
            this.btnMLayanan.Size = new System.Drawing.Size(121, 23);
            this.btnMLayanan.TabIndex = 2;
            this.btnMLayanan.Text = "Master Layanan";
            this.btnMLayanan.UseVisualStyleBackColor = true;
            this.btnMLayanan.Click += new System.EventHandler(this.btnMLayanan_Click);
            // 
            // btnMPegawai
            // 
            this.btnMPegawai.Location = new System.Drawing.Point(3, 79);
            this.btnMPegawai.Name = "btnMPegawai";
            this.btnMPegawai.Size = new System.Drawing.Size(121, 23);
            this.btnMPegawai.TabIndex = 1;
            this.btnMPegawai.Text = "Master Pegawai";
            this.btnMPegawai.UseVisualStyleBackColor = true;
            this.btnMPegawai.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(3, 16);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(121, 23);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(191, 115);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(542, 404);
            this.panelControl.TabIndex = 2;
            // 
            // topbar1
            // 
            this.topbar1.Location = new System.Drawing.Point(12, 12);
            this.topbar1.Name = "topbar1";
            this.topbar1.Size = new System.Drawing.Size(711, 95);
            this.topbar1.TabIndex = 3;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 549);
            this.Controls.Add(this.topbar1);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panel1);
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMPaket;
        private System.Windows.Forms.Button btnMLayanan;
        private System.Windows.Forms.Button btnMPegawai;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Panel panelControl;
        private Topbar topbar1;
    }
}