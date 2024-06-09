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
    public partial class QLCa : Form
    {
        public QLCa()
        {
            InitializeComponent();
        }
        DataTable Cahoc;
        private void QLCa_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập trước khi sử dụng chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(); 
                return;

            }
            if (UserSession.ChucVu != "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            Class.Function.Connect();
            Load_DataGridView();
            txtMaCa.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            string query = "SELECT COUNT(*) FROM tblCahoc";
            SqlCommand command = new SqlCommand(query, Class.Function.Conn);
            int soCa = (int)command.ExecuteScalar();
            label4.Text = "Số ca thực hành có trong hệ thống:" + soCa;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblCahoc";
            Cahoc = Class.Function.GetDataToTable(sql);
            DataGridViewCa.DataSource = Cahoc;
            DataGridViewCa.Columns[0].HeaderText = "Mã ca";
            DataGridViewCa.Columns[1].HeaderText = "Tên ca";
            DataGridViewCa.Columns[2].HeaderText = "Mô tả";
            DataGridViewCa.AllowUserToAddRows = false;
            DataGridViewCa.EditMode = DataGridViewEditMode.EditProgrammatically;
            // Đặt chiều cao của header
            DataGridViewCa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGridViewCa.ColumnHeadersHeight = 50; // Đặt chiều cao là 50px
            // Đặt chiều cao của mỗi dòng
            DataGridViewCa.RowTemplate.Height = 30;
        }


        private void DataGridViewCa_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCa.Focus();
                return;

            }
            if (Cahoc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMaCa.Text = DataGridViewCa.CurrentRow.Cells["MaCa"].Value.ToString();
            txtTenCa.Text = DataGridViewCa.CurrentRow.Cells["TenCa"].Value.ToString();
            txtMoTa.Text = DataGridViewCa.CurrentRow.Cells["MoTa"].Value.ToString();
            btnSua.Enabled = true;
            btnBoQua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            txtTenCa.Focus();
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaCa.Text = "";
            txtTenCa.Text = "";
            txtMoTa.Text = "";
        }
        private string SinhMaCa()
        {
            string mamax = Class.Function.GetFieldValues("SELECT MAX(MaCa) FROM tblCahoc");

            if (string.IsNullOrEmpty(mamax))
            {
                return "CA001";
            }
            else
            {
                int masttmax = Convert.ToInt32(mamax.Substring(2));
                masttmax += 1;
                return "CA" + masttmax.ToString("000");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string maCa = SinhMaCa();
            if (txtTenCa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenCa.Focus();
                return;
            }
            sql = "INSERT INTO tblCahoc (MaCa, TenCa, MoTa) VALUES (N'" + maCa + "', N'" + txtTenCa.Text.Trim() + "', N'" + txtMoTa.Text.Trim() + "');";
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
            if (Cahoc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenCa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenCa.Focus();
                return;
            }
            string sql;
            sql = "UPDATE tblCahoc SET TenCa = N'" + txtTenCa.Text + "', MoTa = N'" + txtMoTa.Text + "' WHERE MaCa = N'" + txtMaCa.Text + "'";
            Class.Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (Cahoc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca học không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblCahoc WHERE MaCa=N'" + txtMaCa.Text + "'";
                Class.Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            string query = "SELECT COUNT(*) FROM tblCahoc";
            SqlCommand command = new SqlCommand(query, Class.Function.Conn);
            int soCa = (int)command.ExecuteScalar();
            label4.Text = "Số ca thực hành có trong hệ thống:" + soCa;
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

            string sql = "SELECT * FROM tblCahoc WHERE TenCa LIKE '%" + txtSearch.Text.Trim() + "%'";
            DataTable result = Class.Function.GetDataToTable(sql);

            if (result.Rows.Count > 0)
            {
                DataGridViewCa.DataSource = result;
                label4.Text = "Số kết quả: " + result.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy ca học nào phù hợp với từ khóa trên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewCa.DataSource = Cahoc;
                label4.Text = "Số kết quả: 0";
            }
        }

    }
}

 
