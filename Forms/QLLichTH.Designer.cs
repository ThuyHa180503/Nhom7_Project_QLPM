namespace Nhom7_Project_QLPM.Forms
{
    partial class QLLichTH
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
            this.pnSidebar = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rdomon = new System.Windows.Forms.RadioButton();
            this.rdolop = new System.Windows.Forms.RadioButton();
            this.rdogiaovien = new System.Windows.Forms.RadioButton();
            this.rdophongmay = new System.Windows.Forms.RadioButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.mskngayketthuc = new System.Windows.Forms.MaskedTextBox();
            this.mskngaybatdau = new System.Windows.Forms.MaskedTextBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbothu = new System.Windows.Forms.ComboBox();
            this.cboca = new System.Windows.Forms.ComboBox();
            this.cbomon = new System.Windows.Forms.ComboBox();
            this.cbolop = new System.Windows.Forms.ComboBox();
            this.cbogiaovien = new System.Windows.Forms.ComboBox();
            this.cbonhanvien = new System.Windows.Forms.ComboBox();
            this.cbophongmay = new System.Windows.Forms.ComboBox();
            this.txtmastt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnSidebar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnSidebar
            // 
            this.pnSidebar.Controls.Add(this.groupBox1);
            this.pnSidebar.Location = new System.Drawing.Point(-1, 2);
            this.pnSidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnSidebar.Name = "pnSidebar";
            this.pnSidebar.Size = new System.Drawing.Size(556, 1149);
            this.pnSidebar.TabIndex = 0;
            this.pnSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnSidebar_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.rdomon);
            this.groupBox1.Controls.Add(this.rdolop);
            this.groupBox1.Controls.Add(this.rdogiaovien);
            this.groupBox1.Controls.Add(this.rdophongmay);
            this.groupBox1.Location = new System.Drawing.Point(17, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(527, 571);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm thông tin điền";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(41, 206);
            this.txttimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(440, 31);
            this.txttimkiem.TabIndex = 4;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 266);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(527, 279);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // rdomon
            // 
            this.rdomon.AutoSize = true;
            this.rdomon.Location = new System.Drawing.Point(41, 42);
            this.rdomon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdomon.Name = "rdomon";
            this.rdomon.Size = new System.Drawing.Size(85, 29);
            this.rdomon.TabIndex = 3;
            this.rdomon.TabStop = true;
            this.rdomon.Text = "Môn";
            this.rdomon.UseVisualStyleBackColor = true;
            this.rdomon.Click += new System.EventHandler(this.rdomon_Click);
            // 
            // rdolop
            // 
            this.rdolop.AutoSize = true;
            this.rdolop.Location = new System.Drawing.Point(41, 80);
            this.rdolop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdolop.Name = "rdolop";
            this.rdolop.Size = new System.Drawing.Size(79, 29);
            this.rdolop.TabIndex = 2;
            this.rdolop.TabStop = true;
            this.rdolop.Text = "Lớp";
            this.rdolop.UseVisualStyleBackColor = true;
            this.rdolop.Click += new System.EventHandler(this.rdolop_Click);
            // 
            // rdogiaovien
            // 
            this.rdogiaovien.AutoSize = true;
            this.rdogiaovien.Location = new System.Drawing.Point(41, 155);
            this.rdogiaovien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdogiaovien.Name = "rdogiaovien";
            this.rdogiaovien.Size = new System.Drawing.Size(134, 29);
            this.rdogiaovien.TabIndex = 1;
            this.rdogiaovien.TabStop = true;
            this.rdogiaovien.Text = "Giáo viên";
            this.rdogiaovien.UseVisualStyleBackColor = true;
            this.rdogiaovien.Click += new System.EventHandler(this.rdogiaovien_Click);
            // 
            // rdophongmay
            // 
            this.rdophongmay.AutoSize = true;
            this.rdophongmay.Location = new System.Drawing.Point(41, 118);
            this.rdophongmay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdophongmay.Name = "rdophongmay";
            this.rdophongmay.Size = new System.Drawing.Size(151, 29);
            this.rdophongmay.TabIndex = 0;
            this.rdophongmay.TabStop = true;
            this.rdophongmay.Text = "Phòng máy";
            this.rdophongmay.UseVisualStyleBackColor = true;
            this.rdophongmay.Click += new System.EventHandler(this.rdophongmay_Click);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.mskngayketthuc);
            this.pnMain.Controls.Add(this.mskngaybatdau);
            this.pnMain.Controls.Add(this.btndong);
            this.pnMain.Controls.Add(this.btnboqua);
            this.pnMain.Controls.Add(this.btnluu);
            this.pnMain.Controls.Add(this.btnxoa);
            this.pnMain.Controls.Add(this.btnsua);
            this.pnMain.Controls.Add(this.btnthem);
            this.pnMain.Controls.Add(this.dataGridView1);
            this.pnMain.Controls.Add(this.cbothu);
            this.pnMain.Controls.Add(this.cboca);
            this.pnMain.Controls.Add(this.cbomon);
            this.pnMain.Controls.Add(this.cbolop);
            this.pnMain.Controls.Add(this.cbogiaovien);
            this.pnMain.Controls.Add(this.cbonhanvien);
            this.pnMain.Controls.Add(this.cbophongmay);
            this.pnMain.Controls.Add(this.txtmastt);
            this.pnMain.Controls.Add(this.label6);
            this.pnMain.Controls.Add(this.label7);
            this.pnMain.Controls.Add(this.label8);
            this.pnMain.Controls.Add(this.label9);
            this.pnMain.Controls.Add(this.label10);
            this.pnMain.Controls.Add(this.label5);
            this.pnMain.Controls.Add(this.label4);
            this.pnMain.Controls.Add(this.label3);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Controls.Add(this.label1);
            this.pnMain.Location = new System.Drawing.Point(552, 2);
            this.pnMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1456, 1149);
            this.pnMain.TabIndex = 1;
            // 
            // mskngayketthuc
            // 
            this.mskngayketthuc.Location = new System.Drawing.Point(1124, 166);
            this.mskngayketthuc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskngayketthuc.Mask = "00/00/0000";
            this.mskngayketthuc.Name = "mskngayketthuc";
            this.mskngayketthuc.Size = new System.Drawing.Size(316, 31);
            this.mskngayketthuc.TabIndex = 29;
            this.mskngayketthuc.ValidatingType = typeof(System.DateTime);
            // 
            // mskngaybatdau
            // 
            this.mskngaybatdau.Location = new System.Drawing.Point(1124, 94);
            this.mskngaybatdau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskngaybatdau.Mask = "00/00/0000";
            this.mskngaybatdau.Name = "mskngaybatdau";
            this.mskngaybatdau.Size = new System.Drawing.Size(316, 31);
            this.mskngaybatdau.TabIndex = 28;
            this.mskngaybatdau.ValidatingType = typeof(System.DateTime);
            // 
            // btndong
            // 
            this.btndong.Location = new System.Drawing.Point(1189, 884);
            this.btndong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(188, 48);
            this.btndong.TabIndex = 26;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            // 
            // btnboqua
            // 
            this.btnboqua.Location = new System.Drawing.Point(969, 884);
            this.btnboqua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(188, 48);
            this.btnboqua.TabIndex = 25;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = true;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(748, 884);
            this.btnluu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(188, 48);
            this.btnluu.TabIndex = 24;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(527, 884);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(188, 48);
            this.btnxoa.TabIndex = 23;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(308, 884);
            this.btnsua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(188, 48);
            this.btnsua.TabIndex = 22;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(91, 884);
            this.btnthem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(188, 48);
            this.btnthem.TabIndex = 21;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 328);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1425, 499);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // cbothu
            // 
            this.cbothu.FormattingEnabled = true;
            this.cbothu.Location = new System.Drawing.Point(1124, 28);
            this.cbothu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbothu.Name = "cbothu";
            this.cbothu.Size = new System.Drawing.Size(316, 33);
            this.cbothu.TabIndex = 17;
            // 
            // cboca
            // 
            this.cboca.FormattingEnabled = true;
            this.cboca.Location = new System.Drawing.Point(592, 166);
            this.cboca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboca.Name = "cboca";
            this.cboca.Size = new System.Drawing.Size(316, 33);
            this.cboca.TabIndex = 16;
            // 
            // cbomon
            // 
            this.cbomon.FormattingEnabled = true;
            this.cbomon.Location = new System.Drawing.Point(592, 94);
            this.cbomon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbomon.Name = "cbomon";
            this.cbomon.Size = new System.Drawing.Size(316, 33);
            this.cbomon.TabIndex = 15;
            // 
            // cbolop
            // 
            this.cbolop.FormattingEnabled = true;
            this.cbolop.Location = new System.Drawing.Point(592, 29);
            this.cbolop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbolop.Name = "cbolop";
            this.cbolop.Size = new System.Drawing.Size(316, 33);
            this.cbolop.TabIndex = 14;
            // 
            // cbogiaovien
            // 
            this.cbogiaovien.FormattingEnabled = true;
            this.cbogiaovien.Location = new System.Drawing.Point(167, 241);
            this.cbogiaovien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbogiaovien.Name = "cbogiaovien";
            this.cbogiaovien.Size = new System.Drawing.Size(316, 33);
            this.cbogiaovien.TabIndex = 13;
            // 
            // cbonhanvien
            // 
            this.cbonhanvien.FormattingEnabled = true;
            this.cbonhanvien.Location = new System.Drawing.Point(167, 165);
            this.cbonhanvien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbonhanvien.Name = "cbonhanvien";
            this.cbonhanvien.Size = new System.Drawing.Size(316, 33);
            this.cbonhanvien.TabIndex = 12;
            // 
            // cbophongmay
            // 
            this.cbophongmay.FormattingEnabled = true;
            this.cbophongmay.Location = new System.Drawing.Point(167, 92);
            this.cbophongmay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbophongmay.Name = "cbophongmay";
            this.cbophongmay.Size = new System.Drawing.Size(316, 33);
            this.cbophongmay.TabIndex = 11;
            this.cbophongmay.SelectedValueChanged += new System.EventHandler(this.cbophongmay_SelectedValueChanged);
            // 
            // txtmastt
            // 
            this.txtmastt.Location = new System.Drawing.Point(167, 29);
            this.txtmastt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmastt.Name = "txtmastt";
            this.txtmastt.Size = new System.Drawing.Size(316, 31);
            this.txtmastt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(932, 168);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ngày kết thúc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(936, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ngày bắt đầu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(932, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thứ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 175);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ca";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(497, 102);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Môn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 251);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giáo viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng máy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã STT";
            // 
            // QLLichTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2009, 1152);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnSidebar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QLLichTH";
            this.Text = "QLLichTH";
            this.Load += new System.EventHandler(this.QLLichTH_Load);
            this.pnSidebar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSidebar;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbothu;
        private System.Windows.Forms.ComboBox cboca;
        private System.Windows.Forms.ComboBox cbomon;
        private System.Windows.Forms.ComboBox cbolop;
        private System.Windows.Forms.ComboBox cbogiaovien;
        private System.Windows.Forms.ComboBox cbonhanvien;
        private System.Windows.Forms.ComboBox cbophongmay;
        private System.Windows.Forms.TextBox txtmastt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdomon;
        private System.Windows.Forms.RadioButton rdolop;
        private System.Windows.Forms.RadioButton rdogiaovien;
        private System.Windows.Forms.RadioButton rdophongmay;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.MaskedTextBox mskngayketthuc;
        private System.Windows.Forms.MaskedTextBox mskngaybatdau;
    }
}