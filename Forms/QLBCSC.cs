using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Nhom7_Project_QLPM.Forms
{
    public partial class QLBCSC : Form
    {
        public QLBCSC()
        {
            InitializeComponent();
        }

        DataTable dslp; //danh sách số lớp theo phòng máy theo ngày

        DataTable dslichca; //danh sách số lớp theo ca theo ngày

        DataTable dsct; //danh sách chi tiết lớp theo ca theo phòng theo ngày

        private void QLBCSC_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập trước khi sử dụng chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Chuyển đến trang đăng nhập
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(); // Mở form đăng nhập dưới dạng dialog để chặn tương tác với các form khác
                return;

            }
            // Kiểm tra chức vụ của người dùng
            if (UserSession.ChucVu != "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Đóng form nếu không có quyền truy cập
                return;
            }

            loadca();
            loadbieudoca();
            load();
            loadbieudopm();

            txtlop.Enabled = false;
            int tonglop = 0;
            foreach (DataRow row in dslp.Rows)
            {
                tonglop += Convert.ToInt32(row["SoLuongLopHoc"]);
            }
            txtlop.Text = tonglop.ToString();
        }

        //load biểu đồ tần suất sử dụng phòng máy theo ngày
        private void loadbieudopm()
        {
            chartlichphong.Series.Clear(); //xóa series để thay bằng số lịch theo phòng
            Series series = new Series("Số lớp")
            {
                ChartType = SeriesChartType.Column
            };
            chartlichphong.Series.Add(series);

            foreach (DataRow row in dslp.Rows)
            {
                string tenpm = row["TenPM"].ToString();
                int solop = Convert.ToInt32(row["SoLuongLopHoc"]);
                series.Points.AddXY(tenpm, solop);

            }
            // Gán số lượng máy tính làm giá trị của cột
            foreach (DataPoint point in series.Points)
            {
                point.Label = point.YValues[0].ToString(); // Hiển thị số lượng máy tính trực tiếp trên mỗi cột
            }
            chartlichphong.ChartAreas[0].AxisX.Title = "";
            chartlichphong.ChartAreas[0].AxisY.Title = "Số lớp";
            chartlichphong.ChartAreas[0].RecalculateAxesScale();

            chartlichphong.ChartAreas[0].AxisX.MajorGrid.Enabled = false; // Tắt lưới trên trục X
            chartlichphong.ChartAreas[0].AxisY.MajorGrid.Enabled = false; // Tắt lưới trên trục Y
            chartlichphong.ChartAreas[0].AxisY.Interval = 1; // Chia trục Y theo số nguyên
        }

        //load biểu đồ tần suất sử dụng phòng máy theo các ca
        private void loadbieudoca()
        {
            chartlichca.Series.Clear(); //xóa series để thay bằng số lịch theo phòng
            Series series1 = new Series("Số lớp")
            {
                ChartType = SeriesChartType.Column
            };
            chartlichca.Series.Add(series1);

            foreach (DataRow row in dslichca.Rows)
            {
                string tenca = row["TenCa"].ToString();
                int solop = Convert.ToInt32(row["SoLuongLopHoc"]);
                series1.Points.AddXY(tenca, solop);

            }
            foreach (DataPoint point in series1.Points)
            {
                point.Label = point.YValues[0].ToString();
            }
            chartlichca.ChartAreas[0].AxisX.Title = "";
            chartlichca.ChartAreas[0].AxisY.Title = "Số lớp";
            chartlichca.ChartAreas[0].RecalculateAxesScale();

            chartlichca.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartlichca.ChartAreas[0].AxisY.MajorGrid.Enabled = false; 
            chartlichca.ChartAreas[0].AxisY.Interval = 1;
        }

        //load số lượng ca học theo ngày
        private void loadca()
        {
            string ngay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string sql;
            sql = @"SELECT 
                        tblCahoc.TenCa,
                        COUNT(L.MaSTT) AS SoLuongLopHoc
                    FROM 
                        tblCahoc 
                    Left JOIN 
                        tblLich L ON tblCahoc.MaCa = L.MaCa 
                        AND CONVERT(date, '" + ngay + @"') BETWEEN CONVERT(date, L.NgayBD) AND CONVERT(date, L.NgayKT)
                        AND L.Thu = CASE 
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 2 THEN N'Thứ Hai'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 3 THEN N'Thứ Ba'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 4 THEN N'Thứ Tư'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 5 THEN N'Thứ Năm'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 6 THEN N'Thứ Sáu'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 7 THEN N'Thứ Bảy'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 1 THEN N'Chủ Nhật'
                                     END
                    GROUP BY 
                        tblCahoc.TenCa";
            dslichca = Class.Function.GetDataToTable(sql);
        }

        //load danh sách số lượng lớp học theo phòng máy theo ngày
        private void load()
        {
            string ngay = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string sql = @"SELECT 
                        PM.TenPM,
                        COUNT(L.MaSTT) AS SoLuongLopHoc
                        FROM tblPhongMay PM LEFT JOIN tblLich L ON PM.MaPM = L.MaPM
                        AND CONVERT(date, '" + ngay + @"') BETWEEN CONVERT(date, L.NgayBD) AND CONVERT(date, L.NgayKT)
                        AND L.Thu = CASE
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 2 THEN N'Thứ Hai'
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 3 THEN N'Thứ Ba'
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 4 THEN N'Thứ Tư'
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 5 THEN N'Thứ Năm'
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 6 THEN N'Thứ Sáu'
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 7 THEN N'Thứ Bảy'
                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 1 THEN N'Chủ Nhật'
                        END
                        GROUP BY PM.TenPM";

            dslp = Class.Function.GetDataToTable(sql);
            dtgvds.DataSource = dslp;

            dtgvds.Columns[0].HeaderText = "Tên phòng máy";
            dtgvds.Columns[1].HeaderText = "Số lượng lớp";

            dtgvds.Columns[0].Width = 120;
            dtgvds.Columns[1].Width = 130;

            dtgvds.AllowUserToAddRows = false;
            dtgvds.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //click danh sách số lượng lớp theo phòng máy theo ngày
        private void dtgvds_Click(object sender, EventArgs e)
        {
            if (dslp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            loaddanhsachsoluonglptheocadp();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            load();
            loaddanhsachsoluonglptheocadp();

            txtlop.Enabled = false;
            int tonglop = 0;
            foreach (DataRow row in dslp.Rows)
            {
                tonglop += Convert.ToInt32(row["SoLuongLopHoc"]);
            }
            txtlop.Text = tonglop.ToString();

            loadca();
            loadbieudoca();
            loadbieudopm();
        }

        //load thông tin các ca theo từng phòng theo ngày
        private void loaddanhsachsoluonglptheocadp()
        {
            string ngay = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string tenpm = dtgvds.CurrentRow.Cells["TenPM"].Value.ToString();
            string sql;
            sql = @"SELECT 
                    L.mastt,tblCahoc.TenCa, nv.tennv, lop.tenlop, mon.tenmon
                    FROM tblCahoc JOIN tblLich L ON tblCahoc.MaCa = L.MaCa 
                        AND CONVERT(date, '" + ngay + @"') BETWEEN CONVERT(date, L.NgayBD) AND CONVERT(date, L.NgayKT)
                        AND L.Thu = CASE 
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 2 THEN N'Thứ Hai'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 3 THEN N'Thứ Ba'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 4 THEN N'Thứ Tư'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 5 THEN N'Thứ Năm'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 6 THEN N'Thứ Sáu'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 7 THEN N'Thứ Bảy'
                                        WHEN DATEPART(WEEKDAY, '" + ngay + @"') = 1 THEN N'Chủ Nhật'
                                     END
                    join  tblnhanvien nv on l.magv = nv.manv
	                join  tbllop lop on L.malop = lop.malop
	                join tblmonthuchanh mon on L.mamon = mon.mamon
                    WHERE 
                        tblCahoc.MaCa IN (SELECT MaCa FROM tblLich WHERE MaPM = (SELECT MaPM FROM tblPhongMay WHERE TenPM ='" + tenpm + @"'))
                        and L.MaPM = (SELECT MaPM FROM tblPhongMay WHERE TenPM ='" + tenpm + @"')";
            dsct = Class.Function.GetDataToTable(sql);
            dtgvct.DataSource = dsct;

            dtgvct.Columns[0].HeaderText = "STT";
            dtgvct.Columns[1].HeaderText = "Tên ca";
            dtgvct.Columns[2].HeaderText = "Giáo viên";
            dtgvct.Columns[3].HeaderText = "Lớp";
            dtgvct.Columns[4].HeaderText = "Môn";

            dtgvct.Columns[0].Width = 100;
            dtgvct.Columns[1].Width = 100;
            dtgvct.Columns[2].Width = 150;
            dtgvct.Columns[3].Width = 150;
            dtgvct.Columns[4].Width = 150;

            dtgvct.AllowUserToAddRows = false;
            dtgvct.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            loaddanhsachsoluonglptheocadp();
        }
    }
}
