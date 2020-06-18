namespace GameTimHinh
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtNhapSo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTaoHinh = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtNhapSo
            // 
            this.txtNhapSo.Location = new System.Drawing.Point(115, 12);
            this.txtNhapSo.Name = "txtNhapSo";
            this.txtNhapSo.Size = new System.Drawing.Size(176, 22);
            this.txtNhapSo.TabIndex = 0;
            this.txtNhapSo.TextChanged += new System.EventHandler(this.txtNhapSo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhap so hinh :";
            // 
            // btnTaoHinh
            // 
            this.btnTaoHinh.Location = new System.Drawing.Point(354, 13);
            this.btnTaoHinh.Name = "btnTaoHinh";
            this.btnTaoHinh.Size = new System.Drawing.Size(75, 23);
            this.btnTaoHinh.TabIndex = 2;
            this.btnTaoHinh.Text = "Tao hinh";
            this.btnTaoHinh.UseVisualStyleBackColor = true;
            this.btnTaoHinh.Click += new System.EventHandler(this.btnTaoHinh_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBatDau.Location = new System.Drawing.Point(494, 13);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(75, 23);
            this.btnBatDau.TabIndex = 3;
            this.btnBatDau.Text = "Bat Dau";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 60);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(736, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 538);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.btnTaoHinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNhapSo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNhapSo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTaoHinh;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

