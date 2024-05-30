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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Ban co muon thoat hay khong?", "Thong bao" ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        //CÁCH KHÔNG VIẾT CONNECT VÀO FUNCTION
        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    SqlConnection conn = new SqlConnection(@"Data Source=RYNNA\THUYHA;Initial Catalog=QLPM;Integrated Security=True;Encrypt=False");
        //    try
        //    {
        //        conn.Open();
        //        string tk = txtAccountid.Text;
        //        string mk = txtPassword.Text;
        //        string sql = "SELECT * FROM tblAccount WHERE Accountid = '" + tk + "'and password='" + mk + "'";
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataReader dta = cmd.ExecuteReader();
        //        if (dta.Read() == true) {
        //            MessageBox.Show("Dang nhap thanh cong", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Dang nhap that bai" ,"thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //    }catch (Exception ex)
        //    {
        //        MessageBox.Show("Loi ket noi");
        //    }
        //}


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Class.Function.Connect();
                string tk = txtAccountid.Text;
                string mk = txtPassword.Text;
                string sql = "SELECT * FROM tblAccount WHERE Accountid = @Accountid AND password = @password";
                SqlCommand cmd = new SqlCommand(sql, Function.Conn);
                cmd.Parameters.AddWithValue("@Accountid", tk);
                cmd.Parameters.AddWithValue("@password", mk);

                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    dta.Close(); // Đóng DataReader trước khi thực hiện truy vấn tiếp theo

                    // Truy vấn để lấy thông tin chức vụ từ bảng NhanVien
                    string sqlChucVu = "SELECT ChucVu FROM tblNhanVien WHERE Accountid = @Accountid";
                    SqlCommand cmdChucVu = new SqlCommand(sqlChucVu, Function.Conn);
                    cmdChucVu.Parameters.AddWithValue("@Accountid", tk);

                    string chucVu = (string)cmdChucVu.ExecuteScalar();

                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng form đăng nhập và mở form chính

                    frmMain mainForm = new frmMain(tk, chucVu); // Truyền tài khoản và chức vụ vào form chính
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
