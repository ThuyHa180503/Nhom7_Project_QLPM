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
    public partial class CaNhanCaiDat : Form
    {
        public CaNhanCaiDat()
        {
            InitializeComponent();
        }

        private void CaNhanCaiDat_Load(object sender, EventArgs e)
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
        }
    }
}
