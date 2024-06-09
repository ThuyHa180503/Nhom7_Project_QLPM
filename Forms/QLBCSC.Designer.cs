namespace Nhom7_Project_QLPM.Forms
{
    partial class QLBCSC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtgvds = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtlop = new System.Windows.Forms.TextBox();
            this.dtgvct = new System.Windows.Forms.DataGridView();
            this.chartlichphong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartlichca = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHienthi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartlichphong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartlichca)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(452, 29);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1114, 54);
            this.label14.TabIndex = 48;
            this.label14.Text = "BÁO CÁO TÌNH HÌNH SỬ DỤNG PHÒNG MÁY THEO NGÀY";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(1455, 116);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(392, 50);
            this.dateTimePicker1.TabIndex = 51;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtgvds
            // 
            this.dtgvds.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgvds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvds.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvds.Location = new System.Drawing.Point(56, 228);
            this.dtgvds.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvds.Name = "dtgvds";
            this.dtgvds.RowHeadersWidth = 62;
            this.dtgvds.RowTemplate.Height = 28;
            this.dtgvds.Size = new System.Drawing.Size(761, 375);
            this.dtgvds.TabIndex = 0;
            this.dtgvds.Click += new System.EventHandler(this.dtgvds_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(474, 37);
            this.label2.TabIndex = 51;
            this.label2.Text = "Tổng số lớp học sử dụng phòng máy:";
            // 
            // txtlop
            // 
            this.txtlop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtlop.Location = new System.Drawing.Point(586, 170);
            this.txtlop.Margin = new System.Windows.Forms.Padding(4);
            this.txtlop.Name = "txtlop";
            this.txtlop.Size = new System.Drawing.Size(231, 39);
            this.txtlop.TabIndex = 52;
            // 
            // dtgvct
            // 
            this.dtgvct.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgvct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvct.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvct.Location = new System.Drawing.Point(991, 250);
            this.dtgvct.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvct.Name = "dtgvct";
            this.dtgvct.RowHeadersWidth = 62;
            this.dtgvct.RowTemplate.Height = 28;
            this.dtgvct.Size = new System.Drawing.Size(856, 368);
            this.dtgvct.TabIndex = 53;
            // 
            // chartlichphong
            // 
            chartArea1.Name = "ChartArea1";
            this.chartlichphong.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartlichphong.Legends.Add(legend1);
            this.chartlichphong.Location = new System.Drawing.Point(56, 689);
            this.chartlichphong.Margin = new System.Windows.Forms.Padding(4);
            this.chartlichphong.Name = "chartlichphong";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartlichphong.Series.Add(series1);
            this.chartlichphong.Size = new System.Drawing.Size(888, 400);
            this.chartlichphong.TabIndex = 54;
            this.chartlichphong.Text = "chart1";
            // 
            // chartlichca
            // 
            chartArea2.Name = "ChartArea1";
            this.chartlichca.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartlichca.Legends.Add(legend2);
            this.chartlichca.Location = new System.Drawing.Point(1067, 689);
            this.chartlichca.Margin = new System.Windows.Forms.Padding(4);
            this.chartlichca.Name = "chartlichca";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartlichca.Series.Add(series2);
            this.chartlichca.Size = new System.Drawing.Size(843, 391);
            this.chartlichca.TabIndex = 55;
            this.chartlichca.Text = "chart2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 653);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 37);
            this.label1.TabIndex = 56;
            this.label1.Text = "Tần suất sử dụng phòng máy trong ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1061, 653);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(620, 37);
            this.label3.TabIndex = 57;
            this.label3.Text = "Tần suất sử dụng phòng máy theo ca trong ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(985, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 37);
            this.label4.TabIndex = 58;
            this.label4.Text = "Chi tiết lớp học:";
            // 
            // btnHienthi
            // 
            this.btnHienthi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(149)))), ((int)(((byte)(161)))));
            this.btnHienthi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHienthi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnHienthi.ForeColor = System.Drawing.Color.White;
            this.btnHienthi.Image = global::Nhom7_Project_QLPM.Properties.Resources.icons8_reset_20__1_;
            this.btnHienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHienthi.Location = new System.Drawing.Point(1570, 184);
            this.btnHienthi.Margin = new System.Windows.Forms.Padding(4);
            this.btnHienthi.Name = "btnHienthi";
            this.btnHienthi.Padding = new System.Windows.Forms.Padding(10);
            this.btnHienthi.Size = new System.Drawing.Size(277, 63);
            this.btnHienthi.TabIndex = 59;
            this.btnHienthi.Text = "     Hiển thị";
            this.btnHienthi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHienthi.UseVisualStyleBackColor = false;
            this.btnHienthi.Click += new System.EventHandler(this.btnHienthi_Click);
            // 
            // QLBCSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1965, 1177);
            this.Controls.Add(this.btnHienthi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtlop);
            this.Controls.Add(this.dtgvct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartlichca);
            this.Controls.Add(this.dtgvds);
            this.Controls.Add(this.chartlichphong);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1965, 1177);
            this.MinimumSize = new System.Drawing.Size(1965, 1177);
            this.Name = "QLBCSC";
            this.Text = "QLBCSC";
            this.Load += new System.EventHandler(this.QLBCSC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartlichphong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartlichca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dtgvds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtlop;
        private System.Windows.Forms.DataGridView dtgvct;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartlichphong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartlichca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHienthi;
    }
}