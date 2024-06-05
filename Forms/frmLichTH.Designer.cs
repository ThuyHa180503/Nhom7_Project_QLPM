namespace Nhom7_Project_QLPM.Forms
{
    partial class frmLichTH
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
            this.mskngayketthuc = new System.Windows.Forms.MaskedTextBox();
            this.mskngaybatdau = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbothu = new System.Windows.Forms.ComboBox();
            this.cboca = new System.Windows.Forms.ComboBox();
            this.cbomon = new System.Windows.Forms.ComboBox();
            this.cbolop = new System.Windows.Forms.ComboBox();
            this.cbogiaovien = new System.Windows.Forms.ComboBox();
            this.cbophongmay = new System.Windows.Forms.ComboBox();
            this.txtmastt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pnSidebar = new System.Windows.Forms.Panel();
            this.btnin = new System.Windows.Forms.Button();
            this.btnthietlaplai = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnloc = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpngaykt = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpngaybd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdomon = new System.Windows.Forms.RadioButton();
            this.rdolop = new System.Windows.Forms.RadioButton();
            this.rdogiaovien = new System.Windows.Forms.RadioButton();
            this.rdophongmay = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnMain.SuspendLayout();
            this.pnSidebar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mskngayketthuc
            // 
            this.mskngayketthuc.Location = new System.Drawing.Point(1019, 129);
            this.mskngayketthuc.Mask = "00/00/0000";
            this.mskngayketthuc.Name = "mskngayketthuc";
            this.mskngayketthuc.Size = new System.Drawing.Size(222, 26);
            this.mskngayketthuc.TabIndex = 29;
            this.mskngayketthuc.ValidatingType = typeof(System.DateTime);
            // 
            // mskngaybatdau
            // 
            this.mskngaybatdau.Location = new System.Drawing.Point(1019, 70);
            this.mskngaybatdau.Mask = "00/00/0000";
            this.mskngaybatdau.Name = "mskngaybatdau";
            this.mskngaybatdau.Size = new System.Drawing.Size(222, 26);
            this.mskngaybatdau.TabIndex = 28;
            this.mskngaybatdau.ValidatingType = typeof(System.DateTime);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1241, 693);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // cbothu
            // 
            this.cbothu.FormattingEnabled = true;
            this.cbothu.Location = new System.Drawing.Point(1019, 27);
            this.cbothu.Name = "cbothu";
            this.cbothu.Size = new System.Drawing.Size(222, 28);
            this.cbothu.TabIndex = 17;
            // 
            // cboca
            // 
            this.cboca.FormattingEnabled = true;
            this.cboca.Location = new System.Drawing.Point(563, 131);
            this.cboca.Name = "cboca";
            this.cboca.Size = new System.Drawing.Size(238, 28);
            this.cboca.TabIndex = 16;
            // 
            // cbomon
            // 
            this.cbomon.FormattingEnabled = true;
            this.cbomon.Location = new System.Drawing.Point(563, 79);
            this.cbomon.Name = "cbomon";
            this.cbomon.Size = new System.Drawing.Size(238, 28);
            this.cbomon.TabIndex = 15;
            // 
            // cbolop
            // 
            this.cbolop.FormattingEnabled = true;
            this.cbolop.Location = new System.Drawing.Point(563, 30);
            this.cbolop.Name = "cbolop";
            this.cbolop.Size = new System.Drawing.Size(238, 28);
            this.cbolop.TabIndex = 14;
            // 
            // cbogiaovien
            // 
            this.cbogiaovien.FormattingEnabled = true;
            this.cbogiaovien.Location = new System.Drawing.Point(185, 129);
            this.cbogiaovien.Name = "cbogiaovien";
            this.cbogiaovien.Size = new System.Drawing.Size(238, 28);
            this.cbogiaovien.TabIndex = 13;
            // 
            // cbophongmay
            // 
            this.cbophongmay.FormattingEnabled = true;
            this.cbophongmay.Location = new System.Drawing.Point(185, 78);
            this.cbophongmay.Name = "cbophongmay";
            this.cbophongmay.Size = new System.Drawing.Size(238, 28);
            this.cbophongmay.TabIndex = 11;
            // 
            // txtmastt
            // 
            this.txtmastt.Location = new System.Drawing.Point(185, 29);
            this.txtmastt.Name = "txtmastt";
            this.txtmastt.Size = new System.Drawing.Size(238, 26);
            this.txtmastt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(879, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ngày kết thúc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(879, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thứ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(505, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ca";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(505, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Môn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(505, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giáo viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng máy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã STT";
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.mskngayketthuc);
            this.pnMain.Controls.Add(this.mskngaybatdau);
            this.pnMain.Controls.Add(this.dataGridView1);
            this.pnMain.Controls.Add(this.cbothu);
            this.pnMain.Controls.Add(this.cboca);
            this.pnMain.Controls.Add(this.cbomon);
            this.pnMain.Controls.Add(this.cbolop);
            this.pnMain.Controls.Add(this.cbogiaovien);
            this.pnMain.Controls.Add(this.cbophongmay);
            this.pnMain.Controls.Add(this.txtmastt);
            this.pnMain.Controls.Add(this.label11);
            this.pnMain.Controls.Add(this.label6);
            this.pnMain.Controls.Add(this.label8);
            this.pnMain.Controls.Add(this.label9);
            this.pnMain.Controls.Add(this.label10);
            this.pnMain.Controls.Add(this.label5);
            this.pnMain.Controls.Add(this.label4);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Controls.Add(this.label1);
            this.pnMain.Location = new System.Drawing.Point(415, 2);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1306, 1036);
            this.pnMain.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(879, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Ngày bắt đầu";
            // 
            // pnSidebar
            // 
            this.pnSidebar.Controls.Add(this.btnin);
            this.pnSidebar.Controls.Add(this.btnthietlaplai);
            this.pnSidebar.Controls.Add(this.groupBox2);
            this.pnSidebar.Controls.Add(this.groupBox1);
            this.pnSidebar.Location = new System.Drawing.Point(0, 2);
            this.pnSidebar.Name = "pnSidebar";
            this.pnSidebar.Size = new System.Drawing.Size(417, 1033);
            this.pnSidebar.TabIndex = 2;
            // 
            // btnin
            // 
            this.btnin.BackColor = System.Drawing.SystemColors.Window;
            this.btnin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnin.Image = global::Nhom7_Project_QLPM.Properties.Resources.save;
            this.btnin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnin.Location = new System.Drawing.Point(15, 533);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(394, 49);
            this.btnin.TabIndex = 31;
            this.btnin.Text = "In lịch thực hành";
            this.btnin.UseVisualStyleBackColor = false;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btnthietlaplai
            // 
            this.btnthietlaplai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthietlaplai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnthietlaplai.Image = global::Nhom7_Project_QLPM.Properties.Resources.refresh;
            this.btnthietlaplai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthietlaplai.Location = new System.Drawing.Point(13, 468);
            this.btnthietlaplai.Name = "btnthietlaplai";
            this.btnthietlaplai.Size = new System.Drawing.Size(394, 49);
            this.btnthietlaplai.TabIndex = 30;
            this.btnthietlaplai.Text = "Thiết lập lại";
            this.btnthietlaplai.UseVisualStyleBackColor = true;
            this.btnthietlaplai.Click += new System.EventHandler(this.btnthietlaplai_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnloc);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dtpngaykt);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.dtpngaybd);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 206);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc theo thời gian";
            // 
            // btnloc
            // 
            this.btnloc.BackColor = System.Drawing.SystemColors.Window;
            this.btnloc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloc.Image = global::Nhom7_Project_QLPM.Properties.Resources.filter;
            this.btnloc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloc.Location = new System.Drawing.Point(32, 144);
            this.btnloc.Name = "btnloc";
            this.btnloc.Size = new System.Drawing.Size(113, 42);
            this.btnloc.TabIndex = 9;
            this.btnloc.Text = "Lọc";
            this.btnloc.UseVisualStyleBackColor = false;
            this.btnloc.Click += new System.EventHandler(this.btnloc_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Đến";
            // 
            // dtpngaykt
            // 
            this.dtpngaykt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpngaykt.Location = new System.Drawing.Point(74, 97);
            this.dtpngaykt.Name = "dtpngaykt";
            this.dtpngaykt.Size = new System.Drawing.Size(289, 26);
            this.dtpngaykt.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "Từ";
            // 
            // dtpngaybd
            // 
            this.dtpngaybd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpngaybd.Location = new System.Drawing.Point(74, 44);
            this.dtpngaybd.Name = "dtpngaybd";
            this.dtpngaybd.Size = new System.Drawing.Size(289, 26);
            this.dtpngaybd.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdomon);
            this.groupBox1.Controls.Add(this.rdolop);
            this.groupBox1.Controls.Add(this.rdogiaovien);
            this.groupBox1.Controls.Add(this.rdophongmay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 216);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(31, 165);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(331, 30);
            this.txttimkiem.TabIndex = 4;
            // 
            // rdomon
            // 
            this.rdomon.AutoSize = true;
            this.rdomon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdomon.Location = new System.Drawing.Point(31, 34);
            this.rdomon.Name = "rdomon";
            this.rdomon.Size = new System.Drawing.Size(68, 24);
            this.rdomon.TabIndex = 3;
            this.rdomon.TabStop = true;
            this.rdomon.Text = "Môn";
            this.rdomon.UseVisualStyleBackColor = true;
            this.rdomon.Click += new System.EventHandler(this.rdomon_Click);
            // 
            // rdolop
            // 
            this.rdolop.AutoSize = true;
            this.rdolop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdolop.Location = new System.Drawing.Point(31, 64);
            this.rdolop.Name = "rdolop";
            this.rdolop.Size = new System.Drawing.Size(64, 24);
            this.rdolop.TabIndex = 2;
            this.rdolop.TabStop = true;
            this.rdolop.Text = "Lớp";
            this.rdolop.UseVisualStyleBackColor = true;
            this.rdolop.Click += new System.EventHandler(this.rdolop_Click);
            // 
            // rdogiaovien
            // 
            this.rdogiaovien.AutoSize = true;
            this.rdogiaovien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdogiaovien.Location = new System.Drawing.Point(31, 124);
            this.rdogiaovien.Name = "rdogiaovien";
            this.rdogiaovien.Size = new System.Drawing.Size(109, 24);
            this.rdogiaovien.TabIndex = 1;
            this.rdogiaovien.TabStop = true;
            this.rdogiaovien.Text = "Giáo viên";
            this.rdogiaovien.UseVisualStyleBackColor = true;
            this.rdogiaovien.Click += new System.EventHandler(this.rdogiaovien_Click);
            // 
            // rdophongmay
            // 
            this.rdophongmay.AutoSize = true;
            this.rdophongmay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdophongmay.Location = new System.Drawing.Point(31, 94);
            this.rdophongmay.Name = "rdophongmay";
            this.rdophongmay.Size = new System.Drawing.Size(122, 24);
            this.rdophongmay.TabIndex = 0;
            this.rdophongmay.TabStop = true;
            this.rdophongmay.Text = "Phòng máy";
            this.rdophongmay.UseVisualStyleBackColor = true;
            this.rdophongmay.Click += new System.EventHandler(this.rdophongmay_Click);
            // 
            // frmLichTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1733, 1050);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnSidebar);
            this.MinimumSize = new System.Drawing.Size(1670, 1018);
            this.Name = "frmLichTH";
            this.Text = "frmLichTH";
            this.Load += new System.EventHandler(this.frmLichTH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.pnSidebar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskngayketthuc;
        private System.Windows.Forms.MaskedTextBox mskngaybatdau;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbothu;
        private System.Windows.Forms.ComboBox cboca;
        private System.Windows.Forms.ComboBox cbomon;
        private System.Windows.Forms.ComboBox cbolop;
        private System.Windows.Forms.ComboBox cbogiaovien;
        private System.Windows.Forms.ComboBox cbophongmay;
        private System.Windows.Forms.TextBox txtmastt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnSidebar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnloc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpngaykt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpngaybd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdomon;
        private System.Windows.Forms.RadioButton rdolop;
        private System.Windows.Forms.RadioButton rdogiaovien;
        private System.Windows.Forms.RadioButton rdophongmay;
        private System.Windows.Forms.Button btnthietlaplai;
        private System.Windows.Forms.Button btnin;
    }
}