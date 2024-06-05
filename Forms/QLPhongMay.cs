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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Data.SqlClient;


namespace Nhom7_Project_QLPM.Forms
{
    public partial class QLPhongMay : Form
    {
        public QLPhongMay()
        {
            InitializeComponent();
        }

        DataTable qlpm;
        DataTable dsmt;

        private void QLPhongMay_Load(object sender, EventArgs e)
        {
            load();
            ResetValues();
            txtmapm.Enabled = false;
            txtsomay.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void load()
        {
            string sql;
            sql = "SELECT MaPM, TenPM, SoMay, DiaDiem, DienThoai FROM tblPhongMay";

            qlpm = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = qlpm;

            dataGridView1.Columns[0].HeaderText = "Mã phòng máy";
            dataGridView1.Columns[1].HeaderText = "Tên phòng máy";
            dataGridView1.Columns[2].HeaderText = "Số máy";
            dataGridView1.Columns[3].HeaderText = "Địa điểm";
            dataGridView1.Columns[4].HeaderText = "Số điện thoại";

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 100;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtmapm.Text = "";
            txttenpm.Text = "";
            txtsomay.Text = "";
            txtdiadiem.Text = "";
            msksdt.Text = "(   )   -    ";
            txtmapm.Enabled = false;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (qlpm.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtmapm.Text = dataGridView1.CurrentRow.Cells["MaPM"].Value.ToString();
            txttenpm.Text = dataGridView1.CurrentRow.Cells["TenPM"].Value.ToString();
            txtsomay.Text = dataGridView1.CurrentRow.Cells["SoMay"].Value.ToString();
            txtdiadiem.Text = dataGridView1.CurrentRow.Cells["DiaDiem"].Value.ToString();
            msksdt.Text = dataGridView1.CurrentRow.Cells["DienThoai"].Value.ToString();

            loaddanhsachmt();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void loaddanhsachmt()
        {
            string sql;
            sql = "SELECT tblMayTinh.MaMay, tblMayTinh.TenMay, tblMayTinh.GhiChu FROM tblMayTinh join tblPhongMay on tblMayTinh.MaPM = tblPhongMay.MaPM where tblPhongMay.MaPM= N'" + txtmapm.Text + "'";

            dsmt = Class.Function.GetDataToTable(sql);
            dataGridView2.DataSource = dsmt;

            dataGridView2.Columns[0].HeaderText = "Mã máy tính";
            dataGridView2.Columns[1].HeaderText = "Tên máy tính";
            dataGridView2.Columns[2].HeaderText = "Ghi chú";

            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 150;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmapm.Enabled = false;
            txtsomay.Text = "0";
            txtsomay.Enabled = false;

            //thêm mã phòng tự động
            int count = 0;
            count = dataGridView1.Rows.Count; //đếm tất cả các dòng có trong dtgv
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dataGridView1.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));
            if (chuoi2 + 1 < 10)
                txtmapm.Text = "PM00" + (chuoi2 + 1).ToString();
            else if (chuoi2 + 1 < 100)
                txtmapm.Text = "PM0" + (chuoi2 + 1).ToString();
            else if (chuoi2 + 1 < 1000)
                txtmapm.Text = "PM" + (chuoi2 + 1).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttenpm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên phòng máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenpm.Focus();
                return;
            }
            if (txtdiadiem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải địa điểm của phòng máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiadiem.Focus();
                return;
            }
            if (msksdt.Text == "(   )   -    ")
            {
                MessageBox.Show("Bạn phải số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksdt.Focus();
                return;
            }

            sql = "INSERT INTO tblPhongMay(MaPM,TenPM,SoMay,DiaDiem,DienThoai) VALUES(N'" + txtmapm.Text.Trim() +
                    "',N'" + txttenpm.Text.Trim() + "'," + txtsomay.Text.Trim() + ",N'" + txtdiadiem.Text.Trim() + "','" + msksdt.Text + "')";
            Function.RunSql(sql);
            load();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmapm.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (qlpm.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmapm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenpm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên phòng máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenpm.Focus();
                return;
            }
            if (txtdiadiem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa điểm phòng máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiadiem.Focus();
                return;
            }
            if (msksdt.Text == "(   )   -    ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksdt.Focus();
                return;
            }


            sql = "UPDATE tblPhongMay SET  TenPM=N'" + txttenpm.Text.Trim().ToString() + "', DiaDiem=N'" + txtdiadiem.Text.Trim() + "', DienThoai='" + msksdt.Text + "' WHERE MaPM=N'" + txtmapm.Text + "'";

            Function.RunSql(sql);
            load();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (qlpm.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmapm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblPhongMay WHERE MaPM = N'" + txtmapm.Text + "'";
                Function.RunSqlDel(sql);
            }
            load();
            ResetValues();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimkiem.Focus();
                return;
            }

            sql = "select MaPM, TenPM, SoMay, DiaDiem, DienThoai from tblPhongMay where 1=1";

            string keyword = txtTimkiem.Text.Trim();
            string sdt = xoakytusdt(keyword);

            if (txtTimkiem.Text != "")
            {
                sql += " AND (MaPM LIKE N'%" + keyword + "%' OR TenPM LIKE N'%" + keyword + "%' or DiaDiem LIKE N'%" + keyword + "%' OR " + "REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(DienThoai, '(', ''), ')', ''), '-', ''), ' ', ''), '.', '') LIKE N'%" + sdt + "%' )";
            }

            qlpm = Function.GetDataToTable(sql);
            if (qlpm.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + qlpm.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView1.DataSource = qlpm;
            ResetValues();
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

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            load();
            ResetValues();
            loaddanhsachmt();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmapm.Enabled = false;
            loaddanhsachmt();
        }
    }
}
