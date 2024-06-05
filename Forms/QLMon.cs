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

namespace Nhom7_Project_QLPM.Forms
{
    public partial class QLMon : Form
    {
        public QLMon()
        {
            InitializeComponent();
        }
        DataTable MonThucHanh;
        private void QLMon_Load(object sender, EventArgs e)
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
            Class.Function.Connect();
            txtMaMon.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            Load_DataGridView();
            string query = "SELECT COUNT(*) FROM tblMonThucHanh";
            SqlCommand command = new SqlCommand(query, Class.Function.Conn);
            int soMonTH = (int)command.ExecuteScalar();
            label4.Text = "Số môn thực hành có trong hệ thống:" + soMonTH;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblMonThucHanh";
            MonThucHanh = Class.Function.GetDataToTable(sql);
            DataGridViewMon.DataSource = MonThucHanh;
            DataGridViewMon.Columns[0].HeaderText = "Mã môn";
            DataGridViewMon.Columns[1].HeaderText = "Tên môn";
            DataGridViewMon.Columns[2].HeaderText = "Mô tả";
            DataGridViewMon.AllowUserToAddRows = false;
            DataGridViewMon.EditMode = DataGridViewEditMode.EditProgrammatically;
            // Đặt chiều cao của header
            DataGridViewMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGridViewMon.ColumnHeadersHeight = 30; // Đặt chiều cao là 30px
        }


        private void DataGridViewMon_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMon.Focus();
                return;

            }
            if (MonThucHanh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMaMon.Text = DataGridViewMon.CurrentRow.Cells["MaMon"].Value.ToString();
            txtTenMon.Text = DataGridViewMon.CurrentRow.Cells["TenMon"].Value.ToString();
            txtMoTa.Text = DataGridViewMon.CurrentRow.Cells["MoTa"].Value.ToString();
            btnSua.Enabled = true;
            btnBoQua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtMoTa.Text = "";
        }
        private string SinhMaMon()
        {
            int rowCount = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblMonThucHanh", Class.Function.Conn))
            {
                rowCount = (int)cmd.ExecuteScalar();
            }

            string maMon = "M" + (rowCount + 1).ToString("000");
            return maMon;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string maMon = SinhMaMon();
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMon.Focus();
                return;
            }

            sql = "INSERT INTO tblMonThucHanh (MaMon, TenMon, MoTa) VALUES (N'" + maMon + "', N'" + txtTenMon.Text.Trim() + "', N'" + txtMoTa.Text.Trim() + "');";
            Class.Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MonThucHanh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMon.Focus();
                return;
            }


            string sql;
            sql = "UPDATE tblMonThucHanh SET TenMon = N'" + txtTenMon.Text + "', MoTa = N'" + txtMoTa.Text + "' WHERE MaMon = N'" + txtMaMon.Text + "'";
            Class.Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MonThucHanh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblMonThucHanh WHERE MaMon=N'" + txtMaMon.Text + "'";
                Class.Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            string sql = "SELECT * FROM tblMonThucHanh WHERE TenMon LIKE '%" + txtSearch.Text.Trim() + "%'";
            DataTable result = Class.Function.GetDataToTable(sql);

            if (result.Rows.Count > 0)
            {
                DataGridViewMon.DataSource = result;

                // Hiển thị số lượng kết quả ra label4
                label4.Text = "Số kết quả: " + result.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp học nào với từ khóa trên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewMon.DataSource = MonThucHanh;

                // Nếu không có kết quả, đặt label4 về giá trị mặc định
                label4.Text = "Số kết quả: 0";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
        }

        private void txtMaMon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
