using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class QLLichTH : Form
    {
        public QLLichTH()
        {
            InitializeComponent();
        }
        DataTable tbllth;
        DataTable tbltk;

        private void QLLichTH_Load(object sender, EventArgs e)
        {
            Class.functions.fillcombo("SELECT maca, tenca FROM tblcahoc", cboca, "maca", "tenca");
            cboca.SelectedIndex = -1;
            Class.functions.fillcombo("SELECT magv, tengv FROM tblgiaovien", cbogiaovien, "magv", "tengv");
            cbogiaovien.SelectedIndex = -1;
            Class.functions.fillcombo("SELECT malop, tenlop FROM tbllop", cbolop, "malop", "tenlop");
            cbolop.SelectedIndex = -1;
            Class.functions.fillcombo("SELECT mamon, tenmon FROM tblmonthuchanh", cbomon, "mamon", "tenmon");
            cbomon.SelectedIndex = -1;
            Class.functions.fillcombo("SELECT manv, tennv FROM tblnhanvien", cbonhanvien, "manv", "tennv");
            cbonhanvien.SelectedIndex = -1;
            Class.functions.fillcombo("SELECT mapm, tenpm FROM tblphongmay", cbophongmay, "mapm", "tenpm");
            cbophongmay.SelectedIndex = -1;

            string[] thuList = { "hai", "ba", "tư", "năm", "sáu", "bảy", "Chủ Nhật" };
            cbothu.Items.AddRange(thuList);
            cbothu.SelectedIndex = -1;

            load_datagrid();
            txttimkiem.Enabled = false;
            txtmastt.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
        }
        private void load_datagrid()
        {
            string sql;
            sql = "SELECT mastt,mapm,manv,magv,malop,mamon,maca,thu, ngaybd,ngaykt FROM tbllichthuchanh ";
            tbllth = Class.functions.getdatatotable(sql);
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmastt.Text = Class.functions.CreateMastt();
            txttimkiem.Enabled = true;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (tbllth.Rows.Count == 0)
            {
                MessageBox.Show("Không có lịch thực hành nào!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if(btnthem.Enabled == false)
            {
                MessageBox.Show("Bạn đang thêm mới!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
        }

        private void rdophongmay_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            //if (cbolop.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập thông tin lớp trước!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    return;
            //}
            sql = "SELECT mapm, tenpm,somay, diadiem, dienthoai FROM tblphongmay where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (mapm LIKE N'%" + keyword + "%' OR tenpm LIKE N'%" + keyword + "%' )";

            tbltk = Class.functions.getdatatotable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void rdogiaovien_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            //if (cbolop.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập thông tin lớp trước!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    return;
            //}
            sql = "SELECT magv, tengv,dienthoaigv FROM tblgiaovien where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (magv LIKE N'%" + keyword + "%' OR tengv LIKE N'%" + keyword + "%')";

            tbltk = Class.functions.getdatatotable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void rdomon_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT mamon, tenmon FROM tblmonthuchanh where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (mamon LIKE N'%" + keyword + "%' OR tenmon LIKE N'%" + keyword + "%' )";

            tbltk = Class.functions.getdatatotable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void rdolop_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            sql = "SELECT malop, tenlop FROM tbllop where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (malop LIKE N'%" + keyword + "%' OR tenlop LIKE N'%" + keyword + "%')";

            tbltk = Class.functions.getdatatotable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (tbltk.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!!!!", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (rdomon.Checked)
            {
                cbomon.SelectedValue = dataGridView2.CurrentRow.Cells["mamon"].Value.ToString();
            }
            else if (rdolop.Checked)
            {
               cbolop.SelectedValue = dataGridView2.CurrentRow.Cells["malop"].Value.ToString();
            }
            else if (rdophongmay.Checked)
            {
                string maphongmay = dataGridView2.CurrentRow.Cells["mapm"].Value.ToString();
                cbophongmay.SelectedValue = maphongmay;
                cbonhanvien.SelectedValue = Class.functions.getfieldvalues("select manv from tblnhanvien where mapm = '" + maphongmay + "'");
            }
            else if (rdogiaovien.Checked) 
            {
                cbogiaovien.SelectedValue = dataGridView2.CurrentRow.Cells["magv"].Value.ToString();
            }
            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (cbomon.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin môn!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (cboca.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin ca!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (cbothu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin thứ!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (mskngaybatdau.Text == "  /  /")
            {
                MessageBox.Show("Vui lòng nhập thông tin ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (mskngayketthuc.Text == "  /  /")
            {
                MessageBox.Show("Vui lòng nhập thông tin ngày kết thúc!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (cbophongmay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin phòng máy!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (cbogiaovien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin giáo viên!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            if (cbolop.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin lớp!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            //check sĩ số 
            string somay = Class.functions.getfieldvaluesint("select somay from tblphongmay where mapm = '" + cbophongmay.SelectedValue.ToString() + "'");
            string siso = Class.functions.getfieldvaluesint("select siso from tbllop where malop = '" + cbolop.SelectedValue.ToString() + "'");
            if (checksiso(somay, siso) == 0)
            {
                MessageBox.Show("Phòng máy không đủ máy!!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                cbophongmay.SelectedValue = "";
                return;
            }
            string lichlop = Class.functions.getfieldvaluesint("SELECT COUNT(*) FROM tbllichthuchanh WHERE (malop = '" + cbolop.SelectedValue.ToString() + "') and (thu = N'" + cbothu.Text + "') AND (maca = '" + cboca.SelectedValue.ToString() + "') AND (ngaybd >= '" + Class.functions.convertdatetime(mskngaybatdau.Text) + "' AND ngaykt <= '" + Class.functions.convertdatetime(mskngayketthuc.Text) + "')");
            int lichlopint;
            if (int.TryParse(lichlop, out lichlopint) && lichlopint > 0)
            {
                MessageBox.Show("Lớp đã có lịch thực hành môn học khác vào thời gian này!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            string giaovienlich = Class.functions.getfieldvaluesint("SELECT COUNT(*) FROM tbllichthuchanh WHERE (magv = '" + cbogiaovien.SelectedValue.ToString() + "') AND (thu = N'" + cbothu.Text + "') AND (maca = '" + cboca.SelectedValue.ToString() + "') AND (ngaybd >= '" + Class.functions.convertdatetime(mskngaybatdau.Text) + "' AND ngaykt <= '" + Class.functions.convertdatetime(mskngayketthuc.Text) + "')");
            int giaovienlichint;
            bool parseSuccessGV = int.TryParse(giaovienlich, out giaovienlichint);
            if (parseSuccessGV && giaovienlichint > 0)
            {
                MessageBox.Show("Giáo viên đã có lớp học khác vào thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "insert into tbllichthuchanh(mastt,mapm,manv,magv,malop,mamon,maca,thu, ngaybd,ngaykt)values('" + txtmastt.Text + "','" + cbophongmay.SelectedValue.ToString() + "','" + cbonhanvien.SelectedValue.ToString() + "','" + cbogiaovien.SelectedValue.ToString() + "','" + cbolop.SelectedValue.ToString() + "','" + cbomon.SelectedValue.ToString() + "','" + cboca.SelectedValue.ToString() + "',N'" + cbothu.Text + "', '"+ Class.functions.convertdatetime(mskngaybatdau.Text)+ "','"+ Class.functions.convertdatetime(mskngayketthuc.Text)+"')";
            Class.functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
        }
        private int checksiso ( string somay, string siso)
        {
            int intSomay, intSiso;
            if (!int.TryParse(somay, out intSomay) || !int.TryParse(siso, out intSiso))
            {
                return -1;
            }
            if (intSomay < 2 * intSiso)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
    }
}
