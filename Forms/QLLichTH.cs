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

            txttimkiem.Enabled = false;
            txtmastt.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmastt.Text = taomastt();
            txttimkiem.Enabled = true;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            cbophongmay.Text = "";
            cbogiaovien.Text = "";
            cbolop.Text = "";
            cbomon.Text = "";
            cboca.Text = "";
            cbothu.Text = "";
            mskngaybatdau.Text = "";
            mskngayketthuc.Text = "";
        }
        private string taomastt()
        {
            string mamax = Class.Function.GetFieldValues("select max(mastt) from tbllich ");
            if (mamax == "")
            {
                return "001";
            }
            else
            {
                int masttmax = Convert.ToInt32(mamax);
                masttmax += 1;
                if (masttmax < 10)
                    return "00" + masttmax;
                else if (masttmax < 100)
                    return "0" + masttmax;
                else
                    return masttmax.ToString();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (tbllth.Rows.Count == 0)
            {
                MessageBox.Show("Không có lịch thực hành nào!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(btnthem.Enabled == false)
            {
                MessageBox.Show("Bạn đang thêm mới!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
            txttimkiem.Enabled = true;

        }

        private void rdophongmay_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT mapm, tenpm,somay, diadiem, dienthoai FROM tblphongmay where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (mapm LIKE N'%" + keyword + "%' OR tenpm LIKE N'%" + keyword + "%' )";

            tbltk = Class.Function.GetDataToTable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void rdogiaovien_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT manv, tennv,dienthoai FROM tblnhanvien where chucvu ='Giáo viên'";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (manv LIKE N'%" + keyword + "%' OR tennv LIKE N'%" + keyword + "%')";

            tbltk = Class.Function.GetDataToTable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void rdomon_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT mamon, tenmon FROM tblmonthuchanh where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (mamon LIKE N'%" + keyword + "%' OR tenmon LIKE N'%" + keyword + "%' )";

            tbltk = Class.Function.GetDataToTable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void rdolop_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "SELECT malop, tenlop FROM tbllop where 1=1";
            string keyword = txttimkiem.Text.Trim();
            sql += "AND (malop LIKE N'%" + keyword + "%' OR tenlop LIKE N'%" + keyword + "%')";

            tbltk = Class.Function.GetDataToTable(sql);
            dataGridView2.DataSource = tbltk;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (tbltk.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!!!!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cbophongmay.SelectedValue = dataGridView2.CurrentRow.Cells["mapm"].Value.ToString();
            }
            else if (rdogiaovien.Checked) 
            {
                cbogiaovien.SelectedValue = dataGridView2.CurrentRow.Cells["manv"].Value.ToString();
            }
            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (cbomon.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin môn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboca.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin ca!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbothu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin thứ!!!", "Thông báo", MessageBoxButtons.OK  , MessageBoxIcon.Information);
                return;
            }
            if (mskngaybatdau.Text == "  /  /")
            {
                MessageBox.Show("Vui lòng nhập thông tin ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (mskngayketthuc.Text == "  /  /")
            {
                MessageBox.Show("Vui lòng nhập thông tin ngày kết thúc!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbophongmay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin phòng máy!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbogiaovien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin giáo viên!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbolop.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin lớp!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Class.Function.isdate(mskngaybatdau.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Class.Function.isdate(mskngayketthuc.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày kết thúc!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDateTime(mskngaybatdau.Text) > Convert.ToDateTime(mskngayketthuc.Text))
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check phòng học đã có lớp chưa
            string phong ="select * from tbllich where (mapm = '"+cbophongmay.SelectedValue.ToString()+"') and (maca ='"+cboca.SelectedValue.ToString() + "') and NOT ((ngaybd > '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "') OR (ngaykt < '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "')) and (thu = N'"+cbothu.Text+ "')";
            if (Class.Function.CheckKey(phong))
            {
                MessageBox.Show("Phòng máy đã có lớp đăng ký, bạn cần chọn phòng máy khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check sĩ số 
            string somay = Class.Function.GetFieldValues("select somay from tblphongmay where mapm = '" + cbophongmay.SelectedValue.ToString() + "'");
            string siso = Class.Function.GetFieldValues("select siso from tbllop where malop = '" + cbolop.SelectedValue.ToString() + "'");
            if (checksiso(somay, siso) == 1)
            {
                MessageBox.Show("Phòng máy không đủ máy!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbophongmay.SelectedValue = "";
                return;
            }
            //check lớp
            string lichlopQuery = "SELECT * FROM tbllich WHERE (malop = '" + cbolop.SelectedValue.ToString() + "') AND (thu = N'" + cbothu.Text + "') AND (maca = '" + cboca.SelectedValue.ToString() + "') AND NOT ((ngaybd > '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "') OR (ngaykt < '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "')) ";
            if (Class.Function.CheckKey(lichlopQuery))
            {
                MessageBox.Show("Lớp đã có lịch thực hành môn học khác vào thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check giáo viên
            string giaovienlich = "SELECT * FROM tbllich WHERE (magv = '" + cbogiaovien.SelectedValue.ToString() + "') AND (thu = N'" + cbothu.Text + "') AND (maca = '" + cboca.SelectedValue.ToString() + "')AND NOT ((ngaybd > '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "') OR (ngaykt < '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "'))  ";
            if (Class.Function.CheckKey(giaovienlich))
            {
                MessageBox.Show("Giáo viên đã có lớp học khác vào thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "insert into tbllich(mastt,mapm,magv,malop,mamon,maca,thu, ngaybd,ngaykt)values('" + txtmastt.Text + "','" + cbophongmay.SelectedValue.ToString() + "','" + cbogiaovien.SelectedValue.ToString() + "','" + cbolop.SelectedValue.ToString() + "','" + cbomon.SelectedValue.ToString() + "','" + cboca.SelectedValue.ToString() + "',N'" + cbothu.Text + "', '"+ Class.Function.convertdatetime(mskngaybatdau.Text)+ "','"+ Class.Function.convertdatetime(mskngayketthuc.Text)+"')";
            Class.Function.RunSql(sql);
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
            int intSomay = Convert.ToInt32(somay);
            int intSiso = Convert.ToInt32(siso); 
            if ((intSomay*2) < intSiso)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmastt.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lịch thưc hành!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbomon.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin môn!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboca.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin ca!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbothu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin thứ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (mskngaybatdau.Text == "  /  /")
            {
                MessageBox.Show("Vui lòng nhập thông tin ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (mskngayketthuc.Text == "  /  /")
            {
                MessageBox.Show("Vui lòng nhập thông tin ngày kết thúc!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbophongmay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin phòng máy!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbogiaovien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin giáo viên!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbolop.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin lớp!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Class.Function.isdate(mskngayketthuc.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày kết thúc!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDateTime(mskngaybatdau.Text) > Convert.ToDateTime(mskngayketthuc.Text))
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDateTime(mskngaybatdau.Text) > Convert.ToDateTime(mskngayketthuc.Text))
            {
                MessageBox.Show("Ngày kết thúc cần lớn hơn ngày bắt đầu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check phòng học đã có lớp chưa
            string phong = "select * from tbllich where (mapm = '" + cbophongmay.SelectedValue.ToString() + "') and (maca ='" + cboca.SelectedValue.ToString() + "')and not (magv='"+cbogiaovien.SelectedValue.ToString()+"') and NOT ((ngaybd > '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "') OR (ngaykt < '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "')) and (thu = N'" + cbothu.Text + "')";
            if (Class.Function.CheckKey(phong))
            {
                MessageBox.Show("Phòng máy đã có lớp đăng ký, bạn cần chọn phòng máy khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            //check sĩ số 
            string somay = Class.Function.GetFieldValues("select somay from tblphongmay where mapm = '" + cbophongmay.SelectedValue.ToString() + "'");
            string siso = Class.Function.GetFieldValues("select siso from tbllop where malop = '" + cbolop.SelectedValue.ToString() + "'");
            if (checksiso(somay, siso) == 1)
            {
                MessageBox.Show("Phòng máy không đủ máy!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbophongmay.SelectedValue = "";
                return;
            }
            //check lớp
            string lichlopQuery = "SELECT * FROM tbllich WHERE (malop = '" + cbolop.SelectedValue.ToString() + "') AND (thu = N'" + cbothu.Text + "') AND (maca = '" + cboca.SelectedValue.ToString() + "') AND NOT ((ngaybd > '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "') OR (ngaykt < '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "')) AND mastt != '" + txtmastt.Text + "'";
            if (Class.Function.CheckKey(lichlopQuery))
            {
                MessageBox.Show("Lớp đã có lịch thực hành môn học khác vào thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check giáo viên
            string giaovienlich = "SELECT * FROM tbllich WHERE (magv = '" + cbogiaovien.SelectedValue.ToString() + "') AND (thu = N'" + cbothu.Text + "') AND (maca = '" + cboca.SelectedValue.ToString() + "') AND NOT ((ngaybd > '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "') OR (ngaykt < '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "'))  AND mastt != '" + txtmastt.Text + "'";
            if (Class.Function.CheckKey(giaovienlich))
            {
                MessageBox.Show("Giáo viên đã có lớp học khác vào thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "update tbllich set mapm = '" + cbophongmay.SelectedValue.ToString() + "', magv = '"+cbogiaovien.SelectedValue.ToString()+"', malop = '" + cbolop.SelectedValue.ToString() + "', mamon = '" + cbomon.SelectedValue.ToString() + "',maca = '" + cboca.SelectedValue.ToString() + "',thu = N'" + cbothu.Text + "', ngaybd = '" + Class.Function.convertdatetime(mskngaybatdau.Text) + "', ngaykt = '" + Class.Function.convertdatetime(mskngayketthuc.Text) + "' where mastt ='" + txtmastt.Text + "' ";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(txtmastt.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lịch thưc hành!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql;
            if (MessageBox.Show("Bạn có muốn xóa lịch thực hành này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete tbllich where mastt=N'" + txtmastt.Text + "'";
                Class.Function.RunSql(sql);
                load_datagrid();
                resetvalue();
                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnluu.Enabled = false;
                btnboqua.Enabled = false;
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            resetvalue();
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
