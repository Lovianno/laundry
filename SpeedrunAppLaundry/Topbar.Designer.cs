
namespace SpeedrunAppLaundry
{
    partial class Topbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.waktu = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nusantara\r\nLaundry";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(534, 27);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(71, 13);
            this.name.TabIndex = 1;
            this.name.Text = "Hi, Username";
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // waktu
            // 
            this.waktu.AutoSize = true;
            this.waktu.Location = new System.Drawing.Point(534, 54);
            this.waktu.Name = "waktu";
            this.waktu.Size = new System.Drawing.Size(95, 13);
            this.waktu.TabIndex = 2;
            this.waktu.Text = "10 JANUARI 2020";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Topbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.waktu);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Name = "Topbar";
            this.Size = new System.Drawing.Size(711, 95);
            this.Load += new System.EventHandler(this.Topbar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label waktu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}
