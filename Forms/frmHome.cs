using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
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
            if (UserSession.ChucVu == "Giáo viên")
            {
                pnPhongTH.Hide();
                pnBCSC.Hide();
            }

            Class.Function.Connect();
                // Truy vấn SQL để đếm số phòng máy
                string query = "SELECT COUNT(*) FROM tblPhongMay";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                // Truy vấn SQL để đếm số BCSC chưa được xử lý
                string query1 = "SELECT COUNT(*) FROM tblBaoCaoSuCo WHERE TrangThai = 0";
                SqlCommand command1 = new SqlCommand(query1, Class.Function.Conn);
            // Truy vấn SQL để đếm số phòng máy trong hôm nay
            string query2 = "SELECT COUNT(DISTINCT MaPM) FROM tblLich WHERE NgayBD <= GETDATE() AND NgayKT >= GETDATE()";
            SqlCommand command2 = new SqlCommand(query2, Class.Function.Conn);
                // Thực thi truy vấn và lấy kết quả
                int soPhongMay = (int)command.ExecuteScalar();
                int soBaoCao = (int)command1.ExecuteScalar();
            int tongSoPhongMay = (int)command2.ExecuteScalar();
            // Hiển thị kết quả trong Label
            label2.Text = "" + soPhongMay;
                label5.Text = "" + soBaoCao;
                label3.Text = "" + tongSoPhongMay;
            //BIỂU ĐỒ
            LoadColumnChart();
            LoadPieChart();

            cboThoiGianSC.Items.Add("7 ngày qua");
            cboThoiGianSC.Items.Add("30 ngày qua");
            cboThoiGianSC.Items.Add("1 năm qua");
            cboThoiGianSC.SelectedIndex = 0;

            Class.Function.FillCombo("SELECT MaPM, TenPM FROM tblPhongmay", cboLocPM, "MaPM", "TenPM");
            cboLocPM.SelectedIndex = -1;

            LoadColumnChart2();
        }

        private void LoadColumnChart()
        {
            string sql = "SELECT MaPM, COUNT(*) AS SoLuongSuCo FROM tblBaoCaoSuCo GROUP BY MaPM";
            System.Data.DataTable dt = Function.GetDataToTable(sql);

            Chart1.ChartAreas[0].AxisX.Title = "Phòng máy";
            Chart1.ChartAreas[0].AxisY.Title = "Số lượng sự cố";
            Chart1.Series.Clear();
            Chart1.Series.Add("Sự cố");
            Chart1.Series["Sự cố"].ChartType = SeriesChartType.Column;
            Chart1.ChartAreas[0].AxisY.Interval = 1;
            foreach (DataRow row in dt.Rows)
            {
                Chart1.Series["Sự cố"].Points.AddXY(row["MaPM"], row["SoLuongSuCo"]);
            }
        }
        private void LoadColumnChart2()
        {
            if (cboThoiGianSC.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn khoảng thời gian để lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime endDate = DateTime.Now.Date;
            DateTime startDate = DateTime.Now.Date;
            string selectedTimeFrame = cboThoiGianSC.SelectedItem.ToString();

            if (selectedTimeFrame == "7 ngày qua")
            {
                startDate = endDate.AddDays(-6);
            }
            else if (selectedTimeFrame == "30 ngày qua")
            {
                startDate = endDate.AddDays(-29);
            }
            else if (selectedTimeFrame == "1 năm qua")
            {
                startDate = endDate.AddYears(-1);
            }

            string filterByMaPM = cboLocPM.SelectedIndex != -1 ? $" AND MaPM = '{cboLocPM.SelectedValue}'" : "";

            // Tạo điều kiện lọc theo khoảng ngày
            string filterByDateRange = $" CONVERT(date, NgayBCSC) BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}'";

            string sql = $@"
                SELECT 
                    {(selectedTimeFrame == "1 năm qua" ? "FORMAT(NgayBCSC, 'yyyy-MM')" : "CONVERT(date, NgayBCSC)")} AS NgayBC, 
                    COUNT(*) AS SoLuongSuCo
                FROM tblBaoCaoSuCo
                WHERE {filterByDateRange} {filterByMaPM}
                GROUP BY {(selectedTimeFrame == "1 năm qua" ? "FORMAT(NgayBCSC, 'yyyy-MM')" : "CONVERT(date, NgayBCSC)")}
                ORDER BY NgayBC ASC";

            System.Data.DataTable dt = Function.GetDataToTable(sql);

            var dataDict = new Dictionary<string, int>();

            // Khởi tạo với các ngày trong khoảng thời gian được chọn
            if (selectedTimeFrame == "1 năm qua")
            {
                for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
                {
                    string monthKey = date.ToString("yyyy-MM");
                    dataDict[monthKey] = 0;
                }
            }
            else
            {
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    string dayKey = date.ToString("dd-MM-yyyy");
                    dataDict[dayKey] = 0;
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                string ngayBC = selectedTimeFrame == "1 năm qua" ? row["NgayBC"].ToString() : DateTime.Parse(row["NgayBC"].ToString()).ToString("dd-MM-yyyy");
                int soLuongSuCo = (int)row["SoLuongSuCo"];
                dataDict[ngayBC] = soLuongSuCo;
            }

            int maxSoLuongSuCo = dataDict.Values.Max();

            // Thiết lập biểu đồ
            if (Chart2 != null)
            {
                Chart2.ChartAreas[0].AxisX.Title = selectedTimeFrame == "1 năm qua" ? "Tháng" : "Ngày báo cáo";
                Chart2.ChartAreas[0].AxisY.Title = "Số lượng sự cố";
                Chart2.Series.Clear();
                Chart2.Series.Add("Sự cố");
                Chart2.Series["Sự cố"].ChartType = SeriesChartType.Column;

                foreach (var kvp in dataDict)
                {
                    Chart2.Series["Sự cố"].Points.AddXY(kvp.Key, kvp.Value);
                }

                Chart2.ChartAreas[0].AxisY.Minimum = 0;
                Chart2.ChartAreas[0].AxisY.Maximum = maxSoLuongSuCo + 1;
                Chart2.ChartAreas[0].AxisY.Interval = 1;

                // Thiết lập định dạng và góc cho nhãn trục x dựa trên khoảng thời gian được chọn
                if (selectedTimeFrame == "7 ngày qua" || selectedTimeFrame == "30 ngày qua")
                {
                    Chart2.ChartAreas[0].AxisX.Interval = 1;
                    Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
                    Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = selectedTimeFrame == "30 ngày qua" ? -45 : 0;
                }
                else if (selectedTimeFrame == "1 năm qua")
                {
                    Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "MM-yyyy";
                    Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
                }
            }

        }
        private void LoadPieChart()
        {
            string sql = "SELECT TrangThai, COUNT(*) AS SoLuongSuCo FROM tblBaoCaoSuCo GROUP BY TrangThai";
            System.Data.DataTable dt = Function.GetDataToTable(sql);

            Chart3.Series.Clear();
            Chart3.Series.Add("Trạng thái");
            Chart3.Series["Trạng thái"].ChartType = SeriesChartType.Pie;
            Chart3.Series["Trạng thái"].IsValueShownAsLabel = true;
            Chart3.Series["Trạng thái"]["PieLabelStyle"] = "Inside";

            int total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToInt32(row["SoLuongSuCo"]);
            }

            foreach (DataRow row in dt.Rows)
            {
                int trangThai = Convert.ToInt32(row["TrangThai"]);
                int count = Convert.ToInt32(row["SoLuongSuCo"]);
                double percentage = (double)count / total * 100.0;
                string trangThaiName = "";
                switch (trangThai)
                {
                    case 0:
                        trangThaiName = "Chưa xử lý";
                        break;
                    case 1:
                        trangThaiName = "Đang xử lý";
                        break;
                    case 2:
                        trangThaiName = "Đã xử lý";
                        break;
                }
                Chart3.Series["Trạng thái"].Points.AddXY(trangThaiName, percentage);
            }


        }

        private void cboLocPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadColumnChart2();
        }

        private void cboThoiGianSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadColumnChart2();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboLocPM.SelectedIndex = -1;
            LoadColumnChart2();
        }

    }
}
