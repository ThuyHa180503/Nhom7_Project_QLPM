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
    public partial class frmQuenMK : Form
    {
        public frmQuenMK()
        {
            InitializeComponent();
        }
       
        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            
               
                string tenDN = txtTenDN.Text.Trim();

                // Kiểm tra xem tên đăng nhập có trống không
                if (string.IsNullOrEmpty(tenDN))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                    return;
                }

                // Kết nối đến cơ sở dữ liệu
                Function.Connect();

                // Xây dựng câu truy vấn với giá trị trực tiếp
                string query = $"SELECT COUNT(*) FROM tblAccount WHERE accountid = '{tenDN.Replace("'", "''")}'";
                SqlCommand command = new SqlCommand(query, Function.Conn);
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu tên đăng nhập trùng với accountid, hiển thị các điều khiển và mã ngẫu nhiên
                    btnOK.Visible = true;
                    txtMa.Visible = true;
                    label1.Visible = true;
                    string randomCode = GenerateRandomCode(5);
                    label1.Text = randomCode;
                txtTenDN.Enabled = false;
            }
                else
                {
                    // Nếu không trùng, hiển thị thông báo yêu cầu nhập lại
                    MessageBox.Show("Tên đăng nhập không hợp lệ. Vui lòng nhập lại!");
                
            }


        }
        private string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmQuenMK_Load(object sender, EventArgs e)
        {
            btnOK.Visible = false;
            txtMa.Visible = false;
            label1.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string maNhapVao = txtTenDN.Text.Trim();

            if (string.IsNullOrEmpty(maNhapVao))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }

            if (txtMa.Text == label1.Text)
            {
                Function.Connect();

                string query = $"SELECT Accountid, password FROM tblAccount WHERE Accountid = '{maNhapVao.Replace("'", "''")}'";
                SqlCommand command = new SqlCommand(query, Function.Conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string accountid = reader["accountid"].ToString();
                    string password = reader["password"].ToString();
                    MessageBox.Show($"Account ID: {accountid}\nPassword: {password}");
                    this.Close();
                    Forms.frmLogin frmLogin = new Forms.frmLogin();
                    frmLogin.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản.");
                }

                Function.Disconnect();
            }

            else
            {
                MessageBox.Show("Mã không chính xác. Vui lòng kiểm tra lại!");
            }
        }
    }
}
