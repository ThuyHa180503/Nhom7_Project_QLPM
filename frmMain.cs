using Nhom7_Project_QLPM.Class;
using Nhom7_Project_QLPM.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Nhom7_Project_QLPM
{
    public partial class frmMain : Form
    {
        private string userId;
        private string chucVu;
        public frmMain()
        {
            InitializeComponent();
            if (UserSession.IsLoggedIn())
            {
                label_welcom.Text = $"Chào mừng, {UserSession.ChucVu} ({UserSession.AccountId})";
                if (UserSession.ChucVu == "Giáo viên")
                {
                    menuQuanLy.Visible = false;

                    btnQLLop.Visible = false;
                    btnQLMon.Visible = false;
                    btnQLCa.Visible = false;
                    btnQLLichTH.Visible = false;
                    btnQLPhongMay.Visible = false;
                    btnQLMayTinh.Visible = false;
                    btnQLBaoCao.Visible = false;
                    btnQLTaiKhoan.Visible = false;
                        pnPhongTH.Hide();
                        pnBCSC.Hide();
                    
                }
                else if (UserSession.ChucVu == "Nhân viên")
                {
                    menuQuanLy.Visible = true;
                    btnQLLop.Visible = true;
                    btnQLMon.Visible = true;
                    btnQLCa.Visible = true;
                    btnQLLichTH.Visible = true;
                    btnQLPhongMay.Visible = true;
                    btnQLMayTinh.Visible = true;
                    btnQLBaoCao.Visible = true;
                    btnQLTaiKhoan.Visible = true;
                }
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
                label7.Text = "" + soPhongMay;
                label5.Text = "" + soBaoCao;
                label3.Text = "" + tongSoPhongMay;
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        public frmMain(string userId, string chucVu)
        {
            InitializeComponent();
            this.userId = userId;
            this.chucVu = chucVu;
        }
        //sidebar
        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 0)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    pnHome.Width = sidebar.Width;
                    pnPhongMay.Width = sidebar.Width;
                    pnLichTH.Width = sidebar.Width;
                    menuQuanLy.Width = sidebar.Width;
                    menuCaNhan.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 135
                    )
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    pnHome.Width = sidebar.Width;
                    pnPhongMay.Width = sidebar.Width;
                    pnLichTH.Width = sidebar.Width;
                    menuQuanLy.Width = sidebar.Width;
                    menuCaNhan.Width = sidebar.Width;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        //MenuquanLy
        bool menuExpand = false;
        private void menuTransition0_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuQuanLy.Height += 10;
                if (menuQuanLy.Height >= 280)
                {
                    menuTransition0.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuQuanLy.Height -= 10;
                if (menuQuanLy.Height <= 34)
                {
                    menuTransition0.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            menuTransition0.Start();
        }
        //MenuCaNhan
        bool menuExpand1 = false;

        private void menuTransition1_Tick(object sender, EventArgs e)
        {
            if (menuExpand1 == false)
            {
                menuCaNhan.Height += 10;
                if (menuCaNhan.Height >= 180)
                {
                    menuTransition1.Stop();
                    menuExpand1 = true;
                }
            }
            else
            {
                menuCaNhan.Height -= 10;
                if (menuCaNhan.Height <= 35)
                {
                    menuTransition1.Stop();
                    menuExpand1 = false;
                }
            }
        }
        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            menuTransition1.Start();
        }
        //open form
        //click
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ResetButtonStyles()
        {
            // Đặt lại màu của nút và màu chữ về trạng thái mặc định
            btnXuLyBCSC.BackColor = Color.WhiteSmoke;
            btnXuLyBCSC.ForeColor = Color.Black;
            btnHome.BackColor = Color.WhiteSmoke;
            btnHome.ForeColor = Color.Black;
            btnPhongMay.BackColor = Color.WhiteSmoke;
            btnPhongMay.ForeColor = Color.Black;
            btnLichTH.BackColor = Color.WhiteSmoke;
            btnLichTH.ForeColor = Color.Black;
            btnQLBaoCao.BackColor = Color.WhiteSmoke;
            btnQLBaoCao.ForeColor = Color.Black;
            btnQLLichTH.BackColor = Color.WhiteSmoke;
            btnQLLichTH.ForeColor = Color.Black;
            btnQLMon.BackColor = Color.WhiteSmoke;
            btnQLMon.ForeColor = Color.Black;
            btnQLLop.BackColor = Color.WhiteSmoke;
            btnQLLop.ForeColor = Color.Black;
            btnQLCa.BackColor = Color.WhiteSmoke;
            btnQLCa.ForeColor = Color.Black;
            btnQLMayTinh.BackColor = Color.WhiteSmoke;
            btnQLMayTinh.ForeColor = Color.Black;
            btnQLPhongMay.BackColor = Color.WhiteSmoke;
            btnQLPhongMay.ForeColor = Color.Black;
            btnQLTaiKhoan.BackColor = Color.WhiteSmoke;
            btnQLTaiKhoan.ForeColor = Color.Black;
            btnCaNhanBCSC.BackColor = Color.WhiteSmoke;
            btnCaNhanBCSC.ForeColor = Color.Black;
            btnCaNhanLichTH.BackColor = Color.WhiteSmoke;
            btnCaNhanLichTH.ForeColor = Color.Black;
            btnCaNhanTK.BackColor = Color.WhiteSmoke;
            btnCaNhanTK.ForeColor = Color.Black;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.frmHome());
            label2.Text = btnHome.Text;
            btnHome.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnHome.ForeColor = Color.White;
        }

        private void btnPhongMay_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.frmPhongMay());
            label2.Text = btnPhongMay.Text;
            btnPhongMay.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnPhongMay.ForeColor = Color.White;
        }

        private void btnLichTH_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.frmLichTH());
            label2.Text=btnLichTH.Text;
        }

        private void btnQLLop_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLLop());
            label2.Text=btnQLLop.Text;
            btnQLLop.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLLop.ForeColor = Color.White;
        }

        private void btnQLMon_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLMon());
            label2.Text = btnQLMon.Text;
            btnQLMon.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLMon.ForeColor = Color.White;
        }

        private void btnQLCa_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLCa());
            label2.Text = btnQLCa.Text;
            btnQLCa.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLCa.ForeColor = Color.White;
        }

        private void btnQLLichTH_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLLichTH());
            label2.Text = btnQLLichTH.Text;
            btnQLLichTH.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLLichTH.ForeColor = Color.White;
        }

        private void btnQLPhongMay_Click(object sender, EventArgs e)
        {   
            ResetButtonStyles();
            OpenChildForm(new Forms.QLPhongMay());
            label2.Text = btnQLPhongMay.Text;
            btnQLPhongMay.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLPhongMay.ForeColor = Color.White;
        }

        private void btnQLMayTinh_Click(object sender, EventArgs e)
        {
           ResetButtonStyles();
            OpenChildForm(new Forms.QLMayTinh());
            label2.Text = btnQLMayTinh.Text;
            btnQLMayTinh.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLMayTinh.ForeColor = Color.White;
        }

        private void btnQLBaoCao_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLBCSC());
            label2.Text = btnQLBaoCao.Text;
            btnQLBaoCao.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLBaoCao.ForeColor = Color.White;
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLTaiKhoan());
            label2.Text = btnQLTaiKhoan.Text;
            btnQLTaiKhoan.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnQLTaiKhoan.ForeColor = Color.White;
        }

        private void btnCaNhanLichTH_Click(object sender, EventArgs e)
        {
                ResetButtonStyles();
            OpenChildForm(new Forms.CaNhanLichTH());
            label2.Text = btnCaNhanLichTH.Text;
            btnCaNhanLichTH.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnCaNhanLichTH.ForeColor = Color.White;
        }

        private void btnCaNhanBCSC_Click(object sender, EventArgs e)
        {
                ResetButtonStyles();
            OpenChildForm(new Forms.CaNhanBCSC());
            label2.Text = btnCaNhanBCSC.Text;
            btnCaNhanBCSC.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnCaNhanBCSC.ForeColor = Color.White;
        }

        private void btnCaNhanTK_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.CaNhanToi());
            label2.Text = btnCaNhanTK.Text;
            btnCaNhanTK.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnCaNhanTK.ForeColor = Color.White;
        }

       

        private void menuQuanLy_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXuLyBCSC_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.QLXuLyBCSC());
            label2.Text = btnXuLyBCSC.Text;
            btnXuLyBCSC.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnXuLyBCSC.ForeColor = Color.White;
        }
       
    


        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.EndSession();

            Forms.frmLogin loginForm = new frmLogin();
            loginForm.Show();
            
        }

        private void Chart2_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

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

        private void cboLocPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadColumnChart2();
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

        private void cboThoiGianSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadColumnChart2();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboLocPM.SelectedIndex = -1;
            LoadColumnChart2();
        }

        private void pnBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_welcom_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            OpenChildForm(new Forms.CaNhanToi());
            label2.Text = btnCaNhanTK.Text;
            btnCaNhanTK.BackColor = ColorTranslator.FromHtml("#8295A1");
            btnCaNhanTK.ForeColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
