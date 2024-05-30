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
            Class.Function.FillCombo("SELECT maca, tenca FROM tblcahoc", cboca, "maca", "tenca");
            cboca.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT magv, tengv FROM tblgiaovien", cbogiaovien, "magv", "tengv");
            cbogiaovien.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT malop, tenlop FROM tbllop", cbolop, "malop", "tenlop");
            cbolop.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT mamon, tenmon FROM tblmonthuchanh", cbomon, "mamon", "tenmon");
            cbomon.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT manv, tennv FROM tblnhanvien", cbonhanvien, "manv", "tennv");
            cbonhanvien.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT mapm, tenpm FROM tblphongmay", cbophongmay, "mapm", "tenpm");
            cbophongmay.SelectedIndex = -1;

            string[] thuList = { "hai", "ba", "tư", "năm", "sáu", "bảy", "Chủ Nhật" };
            cbothu.Items.AddRange(thuList);
            cbothu.SelectedIndex = -1;

            load_datagrid();

        }
        private void load_datagrid()
        {
            string sql;
            sql = "SELECT mastt,mapm,manv,magv,malop,mamon,maca,thu, ngaybd,ngaykt FROM tbllichthuchanh ";
            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
            dataGridView1.Columns[0].HeaderText = "Mã stt";
            dataGridView1.Columns[1].HeaderText = "Mã phòng máy";
            dataGridView1.Columns[2].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[3].HeaderText = "Mã giáo viên";
            dataGridView1.Columns[4].HeaderText = "Mã lớp";
            dataGridView1.Columns[5].HeaderText = "Mã môn";
            dataGridView1.Columns[6].HeaderText = "Mã ca";
            dataGridView1.Columns[7].HeaderText = "Thứ";
            dataGridView1.Columns[8].HeaderText = "Ngày bắt đầu";
            dataGridView1.Columns[9].HeaderText = "Ngày kết thúc";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            //string sql = "select lth.mastt, pm.tenpm, nv.tennv, gv.tengv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt from tbllichthuchanh lth JOIN tblphongmay pm on lth.mapm = pm.mapm " +
            //    "join tblnhanvien nv on lth.manv = nv.manv " +
            //    "join tblgiaovien gv on lth.magv = gv.magv " +
            //    "join tbllop lop on lth.malop = lop.malop " +
            //    "join tblmonthuchanh mon on lth.mamon = mon.mamon " +
            //    "join tblcahoc ca on lth.maca = ca.maca";

            //tbllth = Class.functions.GetDataToTable(sql);
            //dataGridView1.DataSource = tbllth;
            //dataGridView1.Columns[0].HeaderText = "Mã STT";
            //dataGridView1.Columns[1].HeaderText = "Phòng máy";
            //dataGridView1.Columns[2].HeaderText = "Nhân viên";
            //dataGridView1.Columns[3].HeaderText = "Giáo viên";
            //dataGridView1.Columns[4].HeaderText = "Lớp";
            //dataGridView1.Columns[5].HeaderText = "Môn";
            //dataGridView1.Columns[6].HeaderText = "Ca học";
            //dataGridView1.Columns[7].HeaderText = "Thứ";
            //dataGridView1.Columns[8].HeaderText = "Ngày bắt đầu";
            //dataGridView1.Columns[9].HeaderText = "Ngày kết thúc";
            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalue()
        {
            txtmastt.Text = "";
            cbophongmay.Text = "";
            cbonhanvien.Text = "";
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
            cbonhanvien.SelectedValue = dataGridView1.CurrentRow.Cells["manv"].Value.ToString();
            cbogiaovien.SelectedValue = dataGridView1.CurrentRow.Cells["magv"].Value.ToString();
            cbolop.SelectedValue = dataGridView1.CurrentRow.Cells["malop"].Value.ToString();
            cbomon.SelectedValue = dataGridView1.CurrentRow.Cells["mamon"].Value.ToString();
            cboca.SelectedValue = dataGridView1.CurrentRow.Cells["maca"].Value.ToString();
            cbothu.Text = dataGridView1.CurrentRow.Cells["thu"].Value.ToString();
            mskngaybatdau.Text = dataGridView1.CurrentRow.Cells["ngaybd"].Value.ToString();
            mskngayketthuc.Text = dataGridView1.CurrentRow.Cells["ngaykt"].Value.ToString();

            //txtmastt.Text = dataGridView1.CurrentRow.Cells["mastt"].Value.ToString();
            //string mastt = dataGridView1.CurrentRow.Cells["mastt"].Value.ToString();

            //string tenpm = dataGridView1.CurrentRow.Cells["tenpm"].Value.ToString();
            //cbophongmay.SelectedValue = Class.functions.getfieldvalues("select lth.mapm from tbllichthuchanh lth JOIN tblphongmay pm on lth.mapm = pm.mapm where lth.mastt = '" + mastt + "' and pm.tenpm = '" + tenpm + "'");

            //string tennv = dataGridView1.CurrentRow.Cells["tennv"].Value.ToString();
            //cbonhanvien.SelectedValue = Class.functions.getfieldvalues("select lth.manv from tbllichthuchanh lth join tblnhanvien nv on lth.manv = nv.manv where lth.mastt = '" + mastt + "' and nv.tennv = '" + tennv + "'");

            //string tengv = dataGridView1.CurrentRow.Cells["tengv"].Value.ToString();
            //cbogiaovien.SelectedValue = Class.functions.getfieldvalues("select lth.magv from tbllichthuchanh lth join tblgiaovien gv on lth.magv = gv.magv where lth.mastt = '" + mastt + "' and gv.tengv = '" + tengv + "'");

            //string tenlop = dataGridView1.CurrentRow.Cells["tenlop"].Value.ToString();
            //cbolop.SelectedValue = Class.functions.getfieldvalues("select lth.malop from tbllichthuchanh lth join tbllop lop on lth.malop = lop.malop where lth.mastt = '" + mastt + "' and lop.tenlop = '" + tenlop + "'");

            //string tenmon = dataGridView1.CurrentRow.Cells["tenmon"].Value.ToString();
            //cbomon.SelectedValue = Class.functions.getfieldvalues("select lth.mamon from tbllichthuchanh lth join tblmonthuchanh mon on lth.mamon = mon.mamon where lth.mastt = '" + mastt + "' and mon.tenmon = '" + tenmon + "'");

            //string tenca = dataGridView1.CurrentRow.Cells["tenca"].Value.ToString();
            //cboca.SelectedValue = Class.functions.getfieldvalues("select lth.maca from tbllichthuchanh lth join tblcahoc ca on lth.maca = ca.maca where lth.mastt = '" + mastt + "' and ca.tenca = '" + tenca + "'"); ;

            //cbothu.Text = dataGridView1.CurrentRow.Cells["thu"].Value.ToString();
            //mskngaybatdau.Text = dataGridView1.CurrentRow.Cells["ngaybd"].Value.ToString();
            //mskngayketthuc.Text = dataGridView1.CurrentRow.Cells["ngaykt"].Value.ToString();
        }

        private void rdomon_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT mastt,mapm,manv,magv,malop,lth.mamon,maca,thu, ngaybd,ngaykt from tbllichthuchanh lth join tblmonthuchanh mon on lth.mamon = mon.mamon where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (mon.mamon LIKE N'%" + keyword + "%' OR tenmon LIKE N'%" + keyword + "%' )";

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void rdolop_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT mastt,mapm,manv,magv,malop,lth.mamon,maca,thu, ngaybd,ngaykt from tbllichthuchanh lth join tbllop lop on lth.malop = lop.malop where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (lth.malop LIKE N'%" + keyword + "%' OR tenlop LIKE N'%" + keyword + "%' )";

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void rdophongmay_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT mastt,mapm,manv,magv,malop,lth.mamon,maca,thu, ngaybd,ngaykt from tbllichthuchanh lth JOIN tblphongmay pm on lth.mapm = pm.mapm where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (lth.mapm LIKE N'%" + keyword + "%' OR tenpm LIKE N'%" + keyword + "%' )";

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void rdogiaovien_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT mastt,mapm,manv,magv,malop,lth.mamon,maca,thu, ngaybd,ngaykt from tbllichthuchanh lth join tblgiaovien gv on lth.magv = gv.magv where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (lth.magv LIKE N'%" + keyword + "%' OR tengv LIKE N'%" + keyword + "%' )";

            tbllth = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = tbllth;
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            string sql;
            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            if (ngaybd > ngaykt)
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                sql = "select * from tbllichthuchanh where NOT ((ngaybd > '" + ngaykt.ToString("MM-dd-yyyy") + "') OR (ngaykt < '" + ngaybd.ToString("MM-dd-yyyy") + "')) ";
                tbllth = Class.Function.GetDataToTable(sql);
                dataGridView1.DataSource = tbllth;
            }

        }

        private void btnthietlaplai_Click(object sender, EventArgs e)
        {
            load_datagrid();
        }

        private void btnin_Click(object sender, EventArgs e)
        {

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];

            // Định dạng chung cho các ô
            COMExcel.Range exRange = exSheet.Cells[1, 1];
            //exRange.Range[exSheet.Cells[1, 1], exSheet.Cells[1, 365]].MergeCells = true;
            exRange.Range["A1:A1"].Font.Size = 16;
            exRange.Range["A1:A1"].Font.Name = "Times new roman";
            exRange.Range["A1:A1"].Font.Bold = true;
            exRange.Range["A1:A1"].Font.ColorIndex = 3; // Màu đỏ
            exRange.Range[exSheet.Cells[1, 1], exSheet.Cells[1, 365]].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["A1:A1"].Value = "LỊCH THỰC HÀNH";

            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[365, 2]].ColumnWidth = 15;
            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[365, 2]].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[3, 365]].ColumnWidth = 25;
            exSheet.Range[exSheet.Cells[2, 1], exSheet.Cells[3, 365]].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[3, 365]].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Range[exSheet.Cells[2, 3], exSheet.Cells[365, 365]].WrapText = true;

            DateTime ngaybd = dtpngaybd.Value;
            DateTime ngaykt = dtpngaykt.Value;
            if (ngaybd > ngaykt)
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy danh sách phòng máy
            string phongmay = "select tenpm from tblphongmay";
            System.Data.DataTable tblpm = Class.Function.GetDataToTable(phongmay);

            // Lấy danh sách ca học
            string cahoc = "select tenca from tblcahoc";
            System.Data.DataTable tblch = Class.Function.GetDataToTable(cahoc);

            // Lấy dữ liệu từ cơ sở dữ liệu
            string sql = "SELECT lth.mastt, pm.tenpm, nv.tennv, gv.tengv, lop.tenlop, mon.tenmon, ca.tenca, lth.thu, lth.ngaybd, lth.ngaykt " +
                         "FROM tbllichthuchanh lth " +
                         "JOIN tblphongmay pm on lth.mapm = pm.mapm " +
                         "JOIN tblnhanvien nv on lth.manv = nv.manv " +
                         "JOIN tblgiaovien gv on lth.magv = gv.magv " +
                         "JOIN tbllop lop on lth.malop = lop.malop " +
                         "JOIN tblmonthuchanh mon on lth.mamon = mon.mamon " +
                         "JOIN tblcahoc ca on lth.maca = ca.maca where NOT((ngaybd > '" + ngaykt.ToString("MM-dd-yyyy") + "') OR(ngaykt < '" + ngaybd.ToString("MM-dd-yyyy") + "')) ";
            System.Data.DataTable tbllth = Class.Function.GetDataToTable(sql);

            //Đổ dữ liệu
            int cotngay = 3; 
            for (DateTime date = ngaybd; date <= ngaykt; date = date.AddDays(1))
            {
                exSheet.Cells[2, cotngay].Value = GetDayOfWeekVN(date.DayOfWeek);
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
                        if (row["tenpm"].ToString() == tenpm && row["tenca"].ToString() == tenca)
                        {
                            for (DateTime date = ngaybd; date <= ngaykt; date = date.AddDays(1))
                            {
                                cotngay = (date - ngaybd).Days + 3;
                                exSheet.Cells[rowstart, cotngay].Value = "GV: " + row["tengv"] + ", Lớp: " + row["tenlop"] + ", Môn: " + row["tenmon"];
                            }
                        }
                    }
                    rowstart++;
                }
            }
            exApp.Visible = true;
        }

        private string GetDayOfWeekVN(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return "Thứ hai";
                case DayOfWeek.Tuesday: return "Thứ ba";
                case DayOfWeek.Wednesday: return "Thứ tư";
                case DayOfWeek.Thursday: return "Thứ năm";
                case DayOfWeek.Friday: return "Thứ sáu";
                case DayOfWeek.Saturday: return "Thứ bảy";
                case DayOfWeek.Sunday: return "Chủ nhật";
                default: return "";
            }
        }

    }
}
