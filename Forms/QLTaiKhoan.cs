using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;


namespace Nhom7_Project_QLPM.Forms
{
    public partial class QLTaiKhoan : Form
    {
        public QLTaiKhoan()
        {
            InitializeComponent();
        }
        DataTable tblnv;
        private void QLTaiKhoan_Load(object sender, EventArgs e)
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


            Class.Function.Connect();
            string[] chucvuList = { "Nhân viên", "Giáo viên" };
            cbochucvu.Items.AddRange(chucvuList);
            cbochucvu.SelectedIndex = -1;
            txtmanv.Enabled = false;
            txtac.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Class.Function.FillCombo("SELECT MaTinh, TenTinh FROM tblTinh", cbotinh, "maTinh", "TenTinh");
            cbotinh.SelectedIndex = -1;
            load_datagrid();
            resetvalue();
        }


        private void load_datagrid()
        {

            string sql;
            sql = "select MaNV,TenNV,NamSinh,GioiTinh,ChucVu,DienThoai,Accountid,Image,MaTinh from tblNhanVien";
            tblnv = Function.GetDataToTable(sql);
            dgridnv.DataSource = tblnv;
            dgridnv.Columns[0].HeaderText = "Mã nhân viên";
            dgridnv.Columns[1].HeaderText = "Tên nhân viên";
            dgridnv.Columns[2].HeaderText = "Năm sinh";
            dgridnv.Columns[3].HeaderText = "Giới tính";
            dgridnv.Columns[4].HeaderText = "Chức vụ";
            dgridnv.Columns[5].HeaderText = "Điện thoại";
            dgridnv.Columns[6].HeaderText = "Accountid";
            dgridnv.Columns[7].HeaderText = "Hình ảnh";
            dgridnv.Columns[8].HeaderText = "Mã Tỉnh";
            dgridnv.AllowUserToAddRows = false;
            dgridnv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridnv_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtmanv.Text = dgridnv.CurrentRow.Cells["MaNV"].Value.ToString();
            txttennv.Text = dgridnv.CurrentRow.Cells["TenNV"].Value.ToString();
            txtac.Text = dgridnv.CurrentRow.Cells["Accountid"].Value.ToString();
            cbotinh.SelectedValue = dgridnv.CurrentRow.Cells["MaTinh"].Value.ToString();
            cbochucvu.Text = dgridnv.CurrentRow.Cells["ChucVu"].Value.ToString();
            masksdt.Text = dgridnv.CurrentRow.Cells["DienThoai"].Value.ToString();
            maskns.Text = dgridnv.CurrentRow.Cells["NamSinh"].Value.ToString();
            txtAvt.Text = dgridnv.CurrentRow.Cells["Image"].Value.ToString();
            picAvt.Image = Image.FromFile(txtAvt.Text);
            if (dgridnv.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
                chkgt.Checked = true;
            else
                chkgt.Checked = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void resetvalue()
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            txtac.Text = "";
            maskns.Text = "";
            chkgt.Text = "";
            masksdt.Text = "";
            txtmk.Text = "";
            chkgt.Checked = false;
            cbochucvu.Text = "";
            cbotinh.Text = "";
            txtAvt.Text = "";
            picAvt.Image = null;
            txtmk.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = false;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            txttennv.Focus();
            resetvalue();

            // Tạo mã nhân viên mới
            txtmanv.Text = sinhmanv();
        }
        private string sinhmanv()
        {
            // Lấy mã cao nhất hiện tại từ cơ sở dữ liệu
            string mamax = Class.Function.GetFieldValues("SELECT MAX(MaNV) FROM tblNhanVien");

            // Nếu không có mã nào tồn tại, bắt đầu với 001
            if (string.IsNullOrEmpty(mamax))
            {
                return "001";
            }
            else
            {
                // Lấy phần số của mã cao nhất
                int maNVMax = Convert.ToInt32(mamax);
                maNVMax += 1;

                // Trả về mã mới với định dạng xxx
                return maNVMax.ToString("000");
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennv.Focus();
                return;
            }
            if (masksdt.Text == "(   )     ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                masksdt.Focus();
                return;
            }
            if (maskns.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskns.Focus();
                return;
            }
            if (!Function.isdate(maskns.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskns.Text = "";
                maskns.Focus();
                return;
            }

            if (cbotinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tỉnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbotinh.Focus();
                return;
            }

            if (cbochucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbochucvu.Focus();
                return;
            }

            string gt;
            if (chkgt.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            string dienThoai = masksdt.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            sql = "INSERT INTO tblAccount(Accountid,password) VALUES(N'" + txtac.Text.Trim() + "',N'" + txtmk.Text.Trim() + "')";
            Function.RunSql(sql);

            sql = "INSERT INTO tblNhanvien(MaNV,TenNV, Namsinh, Gioitinh,MaTinh, DienThoai,ChucVu,Accountid,Image) VALUES(N'" + txtmanv.Text.Trim() + "',N'" + txttennv.Text.Trim() + "','" + Function.convertdatetime(maskns.Text) + "', N'" + gt + "', N'" + cbotinh.SelectedValue.ToString() + "', '" + dienThoai + "',N'" + cbochucvu.SelectedItem + "',N'" + txtac.Text.Trim() + "', '" + txtAvt.Text + "')";
            Function.RunSql(sql);
            load_datagrid();
            resetvalue();

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmanv.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE FROM tblNhanVien WHERE MaNV=N'" + txtmanv.Text + "'";
                Function.RunSql(sql);
                sql = "DELETE FROM tblAccount WHERE Accountid=N'" + txtac.Text + "'";
                Function.RunSql(sql);

                load_datagrid();
                resetvalue();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennv.Focus();
                return;
            }
            if (masksdt.Text == "(   )   -    ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                masksdt.Focus();
                return;
            }
            if (maskns.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskns.Focus();
                return;
            }
            if (!Function.isdate(maskns.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskns.Text = "";
                maskns.Focus();
                return;
            }
            if (cbotinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tỉnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbotinh.Focus();
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin này không?", "Xác nhận sửa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return; // Dừng xử lý nếu người dùng chọn "No"
            }

            string gt;
            if (chkgt.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            string dienThoai = masksdt.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            string sql;
            sql = "UPDATE tblNhanvien SET  TenNV = N'" + txttennv.Text.Trim().ToString() + "',DienThoai='" + dienThoai + "',NamSinh='" + Function.convertdatetime(maskns.Text) + "',Gioitinh=N'" + gt + "',MaTinh=N'" + cbotinh.SelectedValue.ToString() + "', Image= '" + txtAvt.Text + "' WHERE MaNV=N'" + txtmanv.Text + "'";
            Function.RunSql(sql);

            load_datagrid();
            resetvalue();
            btnboqua.Enabled = true;
        }
        private void btnboqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmanv.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttimkiem.Focus();
                return;
            }

            sql = "select MaNV,TenNV,NamSinh,GioiTinh,ChucVu,DienThoai,Accountid,Image,MaTinh from tblNhanVien where 1=1";

            string keyword = txttimkiem.Text.Trim();
            string sdt = xoakytusdt(keyword);

            if (txttimkiem.Text != "")
            {
                sql += " AND (MaNV LIKE N'%" + keyword + "%' OR TenNV LIKE N'%" + keyword + "%' or NamSinh LIKE N'%" + keyword + "%' OR ChucVu LIKE N'%" + keyword + "%' OR " + "REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(DienThoai, '(', ''), ')', ''), '-', ''), ' ', ''), '.', '') LIKE N'%" + sdt + "%' or Accountid LIKE N'%" + keyword + "%')";
            }

            tblnv = Function.GetDataToTable(sql);
            if (tblnv.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + tblnv.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgridnv.DataSource = tblnv;
            resetvalue();

        }
        //Loại bỏ các ký tự đặc biệt: (, ), -, ' ', và . trong sdt
        private string xoakytusdt(string phoneNumber)
        {
            return phoneNumber.Replace("(", "")
                              .Replace(")", "")
                              .Replace("-", "")
                              .Replace(" ", "")
                              .Replace(".", "");
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            load_datagrid();
            resetvalue();
        }

        private void btnThayTheAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            dlgOpen.InitialDirectory = "D:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAvt.Image = Image.FromFile(dlgOpen.FileName);
                txtAvt.Text = dlgOpen.FileName;
            }

        }

        private void txtmanv_TextChanged(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                if (txtmanv.Text == "")
                {
                    txtac.Text = "";
                }
                else
                {
                    txtac.Text = txtmanv.Text;
                    txtmk.Text = txtmanv.Text;
                }
            }
        }
    }
}
