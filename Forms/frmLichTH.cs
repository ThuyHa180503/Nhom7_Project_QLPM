using Microsoft.Office.Interop.Excel;
using Nhom7_Project_QLPM.Class;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class frmLichTH : Form
    {
        public frmLichTH()
        {
            InitializeComponent();
        }
        System.Data.DataTable tbllth;
        private void frmLichTH_Load(object sender, EventArgs e)
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

            Class.Function.FillCombo("SELECT maca, tenca FROM tblcahoc", cboca, "maca", "tenca");
            cboca.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT manv, tennv FROM tblnhanvien WHERE chucvu ='Giáo viên'", cbogiaovien, "manv", "tennv");
            cbogiaovien.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT malop, tenlop FROM tbllop", cbolop, "malop", "tenlop");
            cbolop.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT mamon, tenmon FROM tblmonthuchanh", cbomon, "mamon", "tenmon");
            cbomon.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT mapm, tenpm FROM tblphongmay", cbophongmay, "mapm", "tenpm");
            cbophongmay.SelectedIndex = -1;

            string[] thuList = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
            cbothu.Items.AddRange(thuList);
            cbothu.SelectedIndex = -1;

            load_datagrid();
            txtmastt.Enabled = false;
            cbophongmay.Enabled = false;
            cbogiaovien.Enabled = false;
            cbolop.Enabled = false;
            cbomon.Enabled = false;
            cboca.Enabled = false;
            cbothu.Enabled = false;
            mskngaybatdau.Enabled = false;
            mskngayketthuc.Enabled = false;

        }
        private void load_datagrid()
        {
            string sql = "select lth.mastt, pm.tenpm, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt,lth.mapm,lth.magv,lth.malop,lth.mamon,lth.maca from tbllich lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
               "join tblnhanvien nv on lth.magv = nv.manv " +
               "join tbllop lop on lth.malop = lop.malop " +
               "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
               "join tblcahoc ca on lth.maca = ca.maca";

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
            dataGridView1.Columns[0].HeaderText = "Mã STT";
            dataGridView1.Columns[1].HeaderText = "Phòng máy";
            dataGridView1.Columns[2].HeaderText = "Giáo viên";
            dataGridView1.Columns[3].HeaderText = "Lớp";
            dataGridView1.Columns[4].HeaderText = "Môn";
            dataGridView1.Columns[5].HeaderText = "Ca học";
            dataGridView1.Columns[6].HeaderText = "Thứ";
            dataGridView1.Columns[7].HeaderText = "Ngày bắt đầu";
            dataGridView1.Columns[8].HeaderText = "Ngày kết thúc";
            dataGridView1.Columns[9].HeaderText = "Mã phòng máy";
            dataGridView1.Columns[10].HeaderText = "Mã giáo viên";
            dataGridView1.Columns[11].HeaderText = "Mã lớp";
            dataGridView1.Columns[12].HeaderText = "Mã môn";
            dataGridView1.Columns[13].HeaderText = "Mã ca học";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalue()
        {
            txtmastt.Text = "";
            cbophongmay.Text = "";
            cbogiaovien.Text = "";
            cbolop.Text = "";
            cbomon.Text = "";
            cboca.Text = "";
            cbothu.Text = "";
            mskngaybatdau.Text = "";
            mskngayketthuc.Text = "";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (tbllth.Rows.Count == 0)
            {
                MessageBox.Show("Không có lịch thực hành nào!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtmastt.Text = dataGridView1.CurrentRow.Cells["mastt"].Value.ToString();
            cbophongmay.SelectedValue = dataGridView1.CurrentRow.Cells["mapm"].Value.ToString();
            cbogiaovien.SelectedValue = dataGridView1.CurrentRow.Cells["magv"].Value.ToString();
            cbolop.SelectedValue = dataGridView1.CurrentRow.Cells["malop"].Value.ToString();
            cbomon.SelectedValue = dataGridView1.CurrentRow.Cells["mamon"].Value.ToString();
            cboca.SelectedValue = dataGridView1.CurrentRow.Cells["maca"].Value.ToString();
            cbothu.Text = dataGridView1.CurrentRow.Cells["thu"].Value.ToString();
            mskngaybatdau.Text = dataGridView1.CurrentRow.Cells["ngaybd"].Value.ToString();
            mskngayketthuc.Text = dataGridView1.CurrentRow.Cells["ngaykt"].Value.ToString();
        }

        private void rdomon_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            string keyword = txttimkiem.Text.Trim();
            string sql = "select lth.mastt, pm.tenpm, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt,lth.mapm,lth.magv,lth.malop,lth.mamon,lth.maca from tbllich lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
               "join tblnhanvien nv on lth.magv = nv.manv " +
               "join tbllop lop on lth.malop = lop.malop " +
               "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
               "join tblcahoc ca on lth.maca = ca.maca where 1=1";
            sql += "AND (mon.mamon LIKE N'%" + keyword + "%' OR tenmon LIKE N'%" + keyword + "%' )";
            if (btnloc.Enabled == false)
            {
                sql += "AND NOT ((ngaybd > '" + ngaykt.ToString("dd-MM-yyyy") + "') OR (ngaykt < '" + ngaybd.ToString("dd-MM-yyyy") + "')) ";
            }

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void rdolop_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql;
            string keyword = txttimkiem.Text.Trim();
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            sql = "select lth.mastt, pm.tenpm, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt,lth.mapm,lth.magv,lth.malop,lth.mamon,lth.maca from tbllich lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
                "join tblnhanvien nv on lth.magv = nv.manv " +
                "join tbllop lop on lth.malop = lop.malop " +
                "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
                "join tblcahoc ca on lth.maca = ca.maca where 1=1";
             
            sql += "AND (lth.malop LIKE N'%" + keyword + "%' OR tenlop LIKE N'%" + keyword + "%' )";

            if (btnloc.Enabled == false)
            {
                sql += "AND NOT ((ngaybd > '" + ngaykt.ToString("dd-MM-yyyy") + "') OR (ngaykt < '" + ngaybd.ToString("dd-MM-yyyy") + "')) ";
            }

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void rdophongmay_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql;
            string keyword = txttimkiem.Text.Trim();
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            sql = "select lth.mastt, pm.tenpm, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt,lth.mapm,lth.magv,lth.malop,lth.mamon,lth.maca from tbllich lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
               "join tblnhanvien nv on lth.magv = nv.manv " +
               "join tbllop lop on lth.malop = lop.malop " +
               "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
               "join tblcahoc ca on lth.maca = ca.maca where 1=1";
             
            sql += "AND (lth.mapm LIKE N'%" + keyword + "%' OR tenpm LIKE N'%" + keyword + "%' )";
            if (btnloc.Enabled == false)
            {
                sql += "AND NOT ((ngaybd > '" + ngaykt.ToString("dd-MM-yyyy") + "') OR (ngaykt < '" + ngaybd.ToString("dd-MM-yyyy") + "')) ";
            }

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void rdogiaovien_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql;
            string keyword = txttimkiem.Text.Trim();
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            sql = "select lth.mastt, pm.tenpm, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt,lth.mapm,lth.magv,lth.malop,lth.mamon,lth.maca from tbllich lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
               "join tblnhanvien nv on lth.magv = nv.manv " +
               "join tbllop lop on lth.malop = lop.malop " +
               "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
               "join tblcahoc ca on lth.maca = ca.maca where 1=1";
            sql += "AND (lth.magv LIKE N'%" + keyword + "%' OR tennv LIKE N'%" + keyword + "%' )";
            if (btnloc.Enabled == false)
            {
                sql += "AND NOT ((ngaybd > '" + ngaykt.ToString("dd-MM-yyyy") + "') OR (ngaykt < '" + ngaybd.ToString("dd-MM-yyyy") + "')) ";
            }

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            string sql;
            string keyword = txttimkiem.Text.Trim();
            if (ngaybd > ngaykt)
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "select lth.mastt, pm.tenpm, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt,lth.mapm,lth.magv,lth.malop,lth.mamon,lth.maca from tbllich lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
            "join tblnhanvien nv on lth.magv = nv.manv " +
            "join tbllop lop on lth.malop = lop.malop " +
            "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
            "join tblcahoc ca on lth.maca = ca.maca where NOT ((ngaybd > '" + ngaykt.ToString("dd-MM-yyyy") + "') OR (ngaykt < '" + ngaybd.ToString("dd-MM-yyyy") + "')) ";
            if(rdogiaovien.Checked == true)
            {
                sql += "AND (lth.magv LIKE N'%" + keyword + "%' OR tennv LIKE N'%" + keyword + "%' )";
            }
            else if (rdolop.Checked == true)
            {
                sql += "AND (lth.malop LIKE N'%" + keyword + "%' OR tenlop LIKE N'%" + keyword + "%' )";
            }
            else if (rdomon.Checked == true)
            {
                sql += "AND (mon.mamon LIKE N'%" + keyword + "%' OR tenmon LIKE N'%" + keyword + "%' )";
            }
            else if (rdophongmay.Checked == true)
            {
                sql += "AND (lth.mapm LIKE N'%" + keyword + "%' OR tenpm LIKE N'%" + keyword + "%' )";
            }

            btnloc.Enabled = false;
            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void btnthietlaplai_Click(object sender, EventArgs e)
        {
            load_datagrid();
            btnloc.Enabled = true;
            rdomon.Checked = false;
            rdolop.Checked = false;
            rdophongmay.Checked = false;
            rdogiaovien.Checked = false;
            txttimkiem.Text = "";
            resetvalue();
            dtpngaybd.Value = DateTime.Today;
            dtpngaykt.Value = DateTime.Today;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            if (ngaybd > ngaykt)
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cot = (ngaykt - ngaybd).Days + 3;

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];

            // Định dạng chung cho các ô

            COMExcel.Range exRange = exSheet.Cells[1, 1];
            //định dạng chung
            exRange.Range[exSheet.Cells[1, 1], exSheet.Cells[1, cot]].RowHeight = 30;
            exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[28, cot]].Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[28, cot]].Font.Name = "Times new roman";
            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[28, 2]].RowHeight = 25;
            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[28, 2]].ColumnWidth = 15;
            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[28, cot+3]].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range[exSheet.Cells[1, 1], exSheet.Cells[28, cot+3]].VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[3, cot]].ColumnWidth = 25;
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[28, cot]].WrapText = true;

            //định dạng cho dòng thứ nhất
            exRange.Range[exSheet.Cells[1, 1], exSheet.Cells[1, cot]].MergeCells = true;
            exRange.Range["A1:A1"].Font.Size = 16;
            exRange.Range["A1:A1"].Font.Bold = true;
            exRange.Range["A1:A1"].Font.ColorIndex = 3;
            exRange.Range[exSheet.Cells[1, 1], exSheet.Cells[1, cot]].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["A1:A1"].Value = "LỊCH THỰC HÀNH";

            //định dạng cho dòng thứ 2 và 3
            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[28, 2]].ColumnWidth = 15; //độ rộng 2 cột đầu 
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[28, cot]].ColumnWidth = 25; //độ rộng từ cột thứ 3
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[28, cot]].Font.Size = 11;
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[3, cot]].Font.Bold = true;
            

            // Lấy danh sách phòng máy
            string phongmay = "select tenpm from tblphongmay";
            System.Data.DataTable tblpm = Class.Function.GetDataToTable(phongmay);

            // Lấy danh sách ca học
            string cahoc = "select tenca from tblcahoc";
            System.Data.DataTable tblch = Class.Function.GetDataToTable(cahoc);

            // Lấy dữ liệu từ cơ sở dữ liệu
            string sql = "select lth.mastt, pm.tenpm, nv.tennv, nv.tennv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt " +
                         "from tbllich lth " +
                         "join tblphongmay pm on lth.mapm = pm.mapm " +
                         "join tblnhanvien nv on lth.magv = nv.manv " +
                         "join tbllop lop on lth.malop = lop.malop " +
                         "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
                         "join tblcahoc ca on lth.maca = ca.maca where NOT((ngaybd > '" + ngaykt.ToString("dd-MM-yyyy") + "') OR(ngaykt < '" + ngaybd.ToString("dd-MM-yyyy") + "')) ";
            System.Data.DataTable tbllth = Class.Function.GetDataToTable(sql);
            //Đổ dữ liệu
            int cotngay = 3;
            for (DateTime date = ngaybd; date <= ngaykt; date = date.AddDays(1))
            {
                exSheet.Cells[2, cotngay].Value = thutrongtuan(date.DayOfWeek);
                exSheet.Cells[3, cotngay].Value = date.ToString("MM/dd/yyyy");
                cotngay++;
            }
            int rowstart = 4;
            foreach (DataRow phong in tblpm.Rows)
            {
                string tenpm = phong["tenpm"].ToString();

                foreach (DataRow ca in tblch.Rows)
                {
                    string tenca = ca["tenca"].ToString();
                    exSheet.Cells[rowstart, 1].Value = tenpm;
                    exSheet.Cells[rowstart, 2].Value = tenca;
                    
                    foreach (DataRow row in tbllth.Rows)
                    {
                        for (DateTime date = ngaybd; date <= ngaykt; date = date.AddDays(1))
                        {

                            cotngay = (date - ngaybd).Days + 3;
                            string thu = thutrongtuan(date.DayOfWeek);
                            if (row["thu"].ToString() == thu && row["tenpm"].ToString() == tenpm && row["tenca"].ToString() == tenca)
                            {
                                DateTime lthNgaybd = Convert.ToDateTime(row["ngaybd"].ToString());
                                DateTime lthNgaykt = Convert.ToDateTime(row["ngaykt"].ToString());
                                if (date >= lthNgaybd && date <= lthNgaykt)
                                {
                                    exSheet.Cells[rowstart, cotngay].Value = "GV: " + row["tennv"] + ", Lớp: " + row["tenlop"] + ", Môn: " + row["tenmon"];
                                }
                            }
                        }
                    }
                    rowstart++;
                }
            }

            exApp.Visible = true;
        }

        private string thutrongtuan(DayOfWeek ngay)
        {
            switch (ngay)
            {
                case DayOfWeek.Monday: return "Thứ Hai";
                case DayOfWeek.Tuesday: return "Thứ Ba";
                case DayOfWeek.Wednesday: return "Thứ Tư";
                case DayOfWeek.Thursday: return "Thứ Năm";
                case DayOfWeek.Friday: return "Thứ Sáu";
                case DayOfWeek.Saturday: return "Thứ Bảy";
                case DayOfWeek.Sunday: return "Chủ Nhật";
                default: return "";
            }
        }

    }
}
