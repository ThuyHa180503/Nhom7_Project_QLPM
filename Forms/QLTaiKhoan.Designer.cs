namespace Nhom7_Project_QLPM.Forms
{
    partial class QLTaiKhoan
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
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.txtac = new System.Windows.Forms.TextBox();
            this.dgridnv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkgt = new System.Windows.Forms.CheckBox();
            this.masksdt = new System.Windows.Forms.MaskedTextBox();
            this.maskns = new System.Windows.Forms.MaskedTextBox();
            this.cbochucvu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.cbotinh = new System.Windows.Forms.ComboBox();
            this.txtAvt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.picAvt = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnThayTheAnh = new System.Windows.Forms.Button();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvt)).BeginInit();
            this.SuspendLayout();
            // 
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(191, 138);
            this.txtmanv.Margin = new System.Windows.Forms.Padding(4);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(281, 31);
            this.txtmanv.TabIndex = 0;
            this.txtmanv.TextChanged += new System.EventHandler(this.txtmanv_TextChanged);
            // 
            // txttennv
            // 
            this.txttennv.Location = new System.Drawing.Point(191, 201);
            this.txttennv.Margin = new System.Windows.Forms.Padding(4);
            this.txttennv.Name = "txttennv";
            this.txttennv.Size = new System.Drawing.Size(281, 31);
            this.txttennv.TabIndex = 1;
            // 
            // txtac
            // 
            this.txtac.Location = new System.Drawing.Point(191, 265);
            this.txtac.Margin = new System.Windows.Forms.Padding(4);
            this.txtac.Name = "txtac";
            this.txtac.Size = new System.Drawing.Size(281, 31);
            this.txtac.TabIndex = 2;
            // 
            // dgridnv
            // 
            this.dgridnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridnv.Location = new System.Drawing.Point(40, 481);
            this.dgridnv.Margin = new System.Windows.Forms.Padding(4);
            this.dgridnv.Name = "dgridnv";
            this.dgridnv.RowHeadersWidth = 62;
            this.dgridnv.RowTemplate.Height = 28;
            this.dgridnv.Size = new System.Drawing.Size(1833, 491);
            this.dgridnv.TabIndex = 6;
            this.dgridnv.Click += new System.EventHandler(this.dgridnv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1045, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chức vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 210);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 268);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Accountid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Họ và tên";
            // 
            // chkgt
            // 
            this.chkgt.AutoSize = true;
            this.chkgt.Location = new System.Drawing.Point(1185, 142);
            this.chkgt.Margin = new System.Windows.Forms.Padding(4);
            this.chkgt.Name = "chkgt";
            this.chkgt.Size = new System.Drawing.Size(88, 29);
            this.chkgt.TabIndex = 14;
            this.chkgt.Text = "Nam";
            this.chkgt.UseVisualStyleBackColor = true;
            // 
            // masksdt
            // 
            this.masksdt.Location = new System.Drawing.Point(689, 136);
            this.masksdt.Margin = new System.Windows.Forms.Padding(4);
            this.masksdt.Mask = "(999) 000-0000";
            this.masksdt.Name = "masksdt";
            this.masksdt.Size = new System.Drawing.Size(265, 31);
            this.masksdt.TabIndex = 15;
            // 
            // maskns
            // 
            this.maskns.Location = new System.Drawing.Point(689, 204);
            this.maskns.Margin = new System.Windows.Forms.Padding(4);
            this.maskns.Mask = "00/00/0000";
            this.maskns.Name = "maskns";
            this.maskns.Size = new System.Drawing.Size(265, 31);
            this.maskns.TabIndex = 16;
            this.maskns.ValidatingType = typeof(System.DateTime);
            // 
            // cbochucvu
            // 
            this.cbochucvu.FormattingEnabled = true;
            this.cbochucvu.Location = new System.Drawing.Point(688, 328);
            this.cbochucvu.Margin = new System.Windows.Forms.Padding(4);
            this.cbochucvu.Name = "cbochucvu";
            this.cbochucvu.Size = new System.Drawing.Size(265, 33);
            this.cbochucvu.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1219, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Nam";
            // 
            // txtmk
            // 
            this.txtmk.Location = new System.Drawing.Point(191, 329);
            this.txtmk.Margin = new System.Windows.Forms.Padding(4);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(281, 31);
            this.txtmk.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 338);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 278);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 25);
            this.label10.TabIndex = 29;
            this.label10.Text = "Mã tỉnh";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(40, 409);
            this.txttimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(367, 31);
            this.txttimkiem.TabIndex = 32;
            // 
            // cbotinh
            // 
            this.cbotinh.FormattingEnabled = true;
            this.cbotinh.Location = new System.Drawing.Point(689, 274);
            this.cbotinh.Margin = new System.Windows.Forms.Padding(4);
            this.cbotinh.Name = "cbotinh";
            this.cbotinh.Size = new System.Drawing.Size(265, 33);
            this.cbotinh.TabIndex = 33;
            //this.cbotinh.SelectedIndexChanged += new System.EventHandler(this.cbotinh_SelectedIndexChanged);
            // 
            // txtAvt
            // 
            this.txtAvt.Location = new System.Drawing.Point(1185, 204);
            this.txtAvt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAvt.Name = "txtAvt";
            this.txtAvt.Size = new System.Drawing.Size(265, 31);
            this.txtAvt.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1045, 210);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 25);
            this.label12.TabIndex = 38;
            this.label12.Text = "Ảnh";
            // 
            // picAvt
            // 
            this.picAvt.AutoRoundedCorners = true;
            this.picAvt.BackColor = System.Drawing.Color.Transparent;
            this.picAvt.BorderRadius = 99;
            this.picAvt.FillColor = System.Drawing.Color.WhiteSmoke;
            this.picAvt.Image = global::Nhom7_Project_QLPM.Properties.Resources.avt_girl_11;
            this.picAvt.ImageRotate = 0F;
            this.picAvt.Location = new System.Drawing.Point(1533, 136);
            this.picAvt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvt.Name = "picAvt";
            this.picAvt.ShadowDecoration.BorderRadius = 100;
            this.picAvt.ShadowDecoration.Color = System.Drawing.SystemColors.ActiveCaption;
            this.picAvt.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvt.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(100);
            this.picAvt.Size = new System.Drawing.Size(200, 200);
            this.picAvt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvt.TabIndex = 36;
            this.picAvt.TabStop = false;
            // 
            // btnThayTheAnh
            // 
            this.btnThayTheAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnThayTheAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThayTheAnh.Font = new System.Drawing.Font("Segoe UI", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThayTheAnh.ForeColor = System.Drawing.Color.White;
            this.btnThayTheAnh.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_upload_201;
            this.btnThayTheAnh.Location = new System.Drawing.Point(1487, 368);
            this.btnThayTheAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThayTheAnh.Name = "btnThayTheAnh";
            this.btnThayTheAnh.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.btnThayTheAnh.Size = new System.Drawing.Size(300, 60);
            this.btnThayTheAnh.TabIndex = 35;
            this.btnThayTheAnh.Text = "  THAY THẾ ẢNH";
            this.btnThayTheAnh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThayTheAnh.UseVisualStyleBackColor = false;
            this.btnThayTheAnh.Click += new System.EventHandler(this.btnThayTheAnh_Click);
            // 
            // btnhienthi
            // 
            this.btnhienthi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnhienthi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhienthi.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnhienthi.ForeColor = System.Drawing.Color.White;
            this.btnhienthi.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_eye_202;
            this.btnhienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhienthi.Location = new System.Drawing.Point(1655, 994);
            this.btnhienthi.Margin = new System.Windows.Forms.Padding(4);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnhienthi.Size = new System.Drawing.Size(218, 63);
            this.btnhienthi.TabIndex = 34;
            this.btnhienthi.Text = "    Hiển thị ";
            this.btnhienthi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnhienthi.UseVisualStyleBackColor = false;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btntimkiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntimkiem.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btntimkiem.ForeColor = System.Drawing.Color.White;
            this.btntimkiem.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_search_204;
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(464, 392);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btntimkiem.Size = new System.Drawing.Size(232, 65);
            this.btntimkiem.TabIndex = 30;
            this.btntimkiem.Text = "    Tìm kiếm";
            this.btntimkiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthoat.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnthoat.ForeColor = System.Drawing.Color.White;
            this.btnthoat.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_logout_201;
            this.btnthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthoat.Location = new System.Drawing.Point(1533, 1089);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnthoat.Size = new System.Drawing.Size(200, 63);
            this.btnthoat.TabIndex = 23;
            this.btnthoat.Text = "    Thoát";
            this.btnthoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnboqua
            // 
            this.btnboqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnboqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnboqua.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnboqua.ForeColor = System.Drawing.Color.White;
            this.btnboqua.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_cancel_202;
            this.btnboqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnboqua.Location = new System.Drawing.Point(1264, 1089);
            this.btnboqua.Margin = new System.Windows.Forms.Padding(4);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnboqua.Size = new System.Drawing.Size(250, 63);
            this.btnboqua.TabIndex = 22;
            this.btnboqua.Text = "    Bỏ qua";
            this.btnboqua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnboqua.UseVisualStyleBackColor = false;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxoa.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnxoa.ForeColor = System.Drawing.Color.White;
            this.btnxoa.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_delete_20__1_;
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(619, 1089);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnxoa.Size = new System.Drawing.Size(200, 63);
            this.btnxoa.TabIndex = 21;
            this.btnxoa.Text = "    Xóa";
            this.btnxoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnsua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsua.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnsua.ForeColor = System.Drawing.Color.White;
            this.btnsua.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_edit_20__1_3;
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(837, 1089);
            this.btnsua.Margin = new System.Windows.Forms.Padding(4);
            this.btnsua.Name = "btnsua";
            this.btnsua.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnsua.Size = new System.Drawing.Size(200, 63);
            this.btnsua.TabIndex = 20;
            this.btnsua.Text = "    Sửa";
            this.btnsua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnluu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnluu.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnluu.ForeColor = System.Drawing.Color.White;
            this.btnluu.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_save_20;
            this.btnluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnluu.Location = new System.Drawing.Point(1051, 1089);
            this.btnluu.Margin = new System.Windows.Forms.Padding(4);
            this.btnluu.Name = "btnluu";
            this.btnluu.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnluu.Size = new System.Drawing.Size(200, 63);
            this.btnluu.TabIndex = 19;
            this.btnluu.Text = "    Lưu";
            this.btnluu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnthem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthem.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnthem.ForeColor = System.Drawing.Color.White;
            this.btnthem.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_add_20__1_3;
            this.btnthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthem.Location = new System.Drawing.Point(399, 1089);
            this.btnthem.Margin = new System.Windows.Forms.Padding(4);
            this.btnthem.Name = "btnthem";
            this.btnthem.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnthem.Size = new System.Drawing.Size(200, 63);
            this.btnthem.TabIndex = 18;
            this.btnthem.Text = "    Thêm";
            this.btnthem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(704, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(433, 54);
            this.label13.TabIndex = 39;
            this.label13.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // QLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1965, 1177);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAvt);
            this.Controls.Add(this.picAvt);
            this.Controls.Add(this.btnThayTheAnh);
            this.Controls.Add(this.btnhienthi);
            this.Controls.Add(this.cbotinh);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.cbochucvu);
            this.Controls.Add(this.maskns);
            this.Controls.Add(this.masksdt);
            this.Controls.Add(this.chkgt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgridnv);
            this.Controls.Add(this.txtac);
            this.Controls.Add(this.txttennv);
            this.Controls.Add(this.txtmanv);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1965, 1177);
            this.MinimumSize = new System.Drawing.Size(1965, 1177);
            this.Name = "QLTaiKhoan";
            this.Text = "QLTaiKhoan";
            this.Load += new System.EventHandler(this.QLTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.TextBox txtac;
        private System.Windows.Forms.DataGridView dgridnv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkgt;
        private System.Windows.Forms.MaskedTextBox masksdt;
        private System.Windows.Forms.MaskedTextBox maskns;
        private System.Windows.Forms.ComboBox cbochucvu;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.ComboBox cbotinh;
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.TextBox txtAvt;
        private Guna.UI2.WinForms.Guna2PictureBox picAvt;
        private System.Windows.Forms.Button btnThayTheAnh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}