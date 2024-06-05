using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //connect
using Nhom7_Project_QLPM.Class;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Ban co muon thoat hay khong?", "Thong bao" ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Class.Function.Connect();
                string tk = txtAccountid.Text.Trim();
                string mk = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "SELECT * FROM tblAccount WHERE Accountid = @Accountid AND password = @password";
                using (SqlCommand cmd = new SqlCommand(sql, Function.Conn))
                {
                    cmd.Parameters.AddWithValue("@Accountid", tk);
                    cmd.Parameters.AddWithValue("@password", mk);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reader.Close();

                            // Lấy chức vụ từ bảng tblNhanVien
                            string sqlChucVu = "SELECT ChucVu FROM tblNhanVien WHERE Accountid = @Accountid";
                            using (SqlCommand cmdChucVu = new SqlCommand(sqlChucVu, Function.Conn))
                            {
                                cmdChucVu.Parameters.AddWithValue("@Accountid", tk);
                                string chucVu = (string)cmdChucVu.ExecuteScalar();

                                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Bắt đầu phiên người dùng
                                UserSession.StartSession(tk, chucVu);

                                // Mở form chính
                                frmMain mainForm = new frmMain();
                                this.Hide();
                                mainForm.ShowDialog();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                if (Function.Conn != null && Function.Conn.State == System.Data.ConnectionState.Open)
                {
                    Function.Conn.Close();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void quenmatkhau_Click(object sender, EventArgs e)
        {
            Forms.frmQuenMK f = new Forms.frmQuenMK();
            f.ShowDialog();
        }
    }
}
