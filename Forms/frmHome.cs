using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
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
            if (UserSession.ChucVu == "Giáo viên")
            {
                pnPhongTH.Hide();
                pnBCSC.Hide();
            }

            Class.Function.Connect();
                // Truy vấn SQL để đếm số phòng máy
                string query = "SELECT COUNT(*) FROM tblPhongMay";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                // Truy vấn SQL để đếm số BCSC chưa được xử lý
                string query1 = "SELECT COUNT(*) FROM tblBaoCaoSuCo WHERE TrangThai = 0";
                SqlCommand command1 = new SqlCommand(query1, Class.Function.Conn);
            // Truy vấn SQL để đếm số phòng máy trong hôm nay
            string query2 = "SELECT COUNT(DISTINCT MaPM) FROM tblLich WHERE NgayBD <= GETDATE() AND NgayKT >= GETDATE()";
            SqlCommand command2 = new SqlCommand(query2, Class.Function.Conn);
                // Thực thi truy vấn và lấy kết quả
                int soPhongMay = (int)command.ExecuteScalar();
                int soBaoCao = (int)command1.ExecuteScalar();
            int tongSoPhongMay = (int)command2.ExecuteScalar();
            // Hiển thị kết quả trong Label
            label2.Text = "" + soPhongMay;
                label5.Text = "" + soBaoCao;
                label3.Text = "" + tongSoPhongMay;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pnTONGPM_Paint(object sender, PaintEventArgs e)
        {

        }
     
        private void pnTONGPM_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
