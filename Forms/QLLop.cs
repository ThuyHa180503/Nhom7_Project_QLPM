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
    public partial class QLLop : Form
    {
        DataTable Lop;

        public QLLop()
        {
            InitializeComponent();
        }

        private void QLLop_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            txtMalop.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();

        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblLop";
            Lop = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = Lop;
            dataGridView1.Columns[0].HeaderText = "Mã lớp";
            dataGridView1.Columns[1].HeaderText = "Tên lớp";
            dataGridView1.Columns[2].HeaderText = "Sĩ số";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;


        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled = false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMalop.Focus();
                return;

            }
            if (Lop.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMalop.Text = dataGridView1.CurrentRow.Cells["MaLop"].Value.ToString();
            txtTenlop.Text = dataGridView1.CurrentRow.Cells["TenLop"].Value.ToString();
            txtSiso.Text = dataGridView1.CurrentRow.Cells["SiSo"].Value.ToString();
            btnSua.Enabled = true;
            btnBoqua.Enabled = true;
            btnXoa.Enabled = true;

        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
        }

        private void ResetValues()
        {
            txtMalop.Text = "";
            txtTenlop.Text = "";
            txtSiso.Text = "";
        }
        private string SinhMalop()
        {
            int rowCount = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLop", Class.Function.Conn))
            {
                rowCount = (int)cmd.ExecuteScalar();
            }

            string maBCSC = "L" + (rowCount + 1).ToString("000");
            return maBCSC;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string maLop = SinhMalop();
            if (txtTenlop.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenlop.Focus();
                return;
            }
            if (txtSiso.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập sĩ số lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSiso.Focus();
                return;
            }
            int siso;
            if (!int.TryParse(txtSiso.Text.Trim(), out siso))
            {
                MessageBox.Show("Vui lòng nhập lại, Sĩ số phải là một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiso.Focus();
                return;
            }

            sql = "INSERT INTO tblLop (MaLop, TenLop, SiSo) VALUES (N'" + maLop + "', N'" + txtTenlop.Text.Trim() + "', N'" + txtSiso.Text.Trim() + "');";
            Class.Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Lop.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMalop.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenlop.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenlop.Focus();
                return;
            }
            if (txtSiso.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập sĩ số lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSiso.Focus();
                return;
            }
            int siso;
            if (!int.TryParse(txtSiso.Text.Trim(), out siso))
            {
                MessageBox.Show("Vui lòng nhập lại, Sĩ số phải là một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiso.Focus();
                return;
            }

            string sql;
            sql = "UPDATE tblLop SET TenLop = N'" + txtTenlop.Text + "', SiSo = N'" + txtSiso.Text + "' WHERE MaLop = N'" + txtMalop.Text + "'";
            Class.Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (Lop.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMalop.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblLop WHERE Machatlieu=N'" + txtMalop.Text + "'";
                Class.Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();


            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

            if (txtTimkiem.Text.Trim() =="")
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimkiem.Focus();
                return;
            }

            string sql = "SELECT * FROM tblLop WHERE TenLop LIKE '%" + txtTimkiem.Text.Trim() + "%'";

            DataTable result = Class.Function.GetDataToTable(sql);

            if (result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp học nào với từ khóa trên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = Lop; 
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
        }
    }
}
