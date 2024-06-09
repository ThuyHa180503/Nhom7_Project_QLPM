using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class CaNhanToi : Form
    {
        public CaNhanToi()
        {
            InitializeComponent();
        }

        private void CaNhanToi_Load(object sender, EventArgs e)
        {
            if (Class.UserSession.IsLoggedIn())
            {
                string accountId = Class.UserSession.AccountId;
                try
                {
                    Class.Function.Connect();
                    string query = "SELECT TenNV, MaNV, NamSinh, DienThoai, GioiTinh, MaTinh, Image FROM tblNhanVien WHERE Accountid = @AccountId";
                    SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                    command.Parameters.AddWithValue("@AccountId", accountId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string tenNV = reader["TenNV"].ToString();
                        string maNV = reader["MaNV"].ToString();
                        string namSinh = reader["NamSinh"].ToString();
                        string dienThoai = reader["DienThoai"].ToString();
                        bool gioiTinh = reader["GioiTinh"].ToString() == "Nam"; // Nếu là "Nam", gán true, ngược lại gán false
                        string maTinh = reader["MaTinh"].ToString();
                        string imagePath = reader["Image"].ToString(); // Lấy đường dẫn hình ảnh
                        //Thoong tin hien len gd
                        txtTen.Text = tenNV;
                        txtMa.Text = maNV;
                        mskNgaySinh.Text = namSinh;
                        mskDienThoai.Text = dienThoai;
                        ckNam.Checked = gioiTinh;
                        txtDiaChi.Text = maTinh;
                        txtMa.Enabled = false;

                        // Hiển thị hình ảnh từ đường dẫn trong PictureBox
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            picAvt.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            // Nếu không có hoặc không tìm thấy hình ảnh, có thể hiển thị một hình ảnh mặc định hoặc ẩn PictureBox
                            picAvt.Image = null;
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
                }
                finally
                {
                    Class.Function.Disconnect();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi xem thông tin cá nhân.");
                this.Close();
            }
            //TAI KHOAN
            txtTenDN.Text = Class.UserSession.AccountId;
            txtPassCu.Text = "";// an mk
            txtPassCu.Enabled = false;
            pnMKMoi.Visible = false;
            btnBoQuaMK.Visible = false;
            btnLuuMatKhau.Visible = false;
            txtTenDN.Enabled = false;
        }

        private void picAvt_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "JPG|*.jpg|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "C:\\";
            dlgOpen.FilterIndex = 3;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAvt.Image = Image.FromFile(dlgOpen.FileName);
                txtAvt.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tên của bạn");
                return;
            }
            if (
                string.IsNullOrWhiteSpace(mskNgaySinh.Text) )
            {
                MessageBox.Show("Vui lòng không để ngày sinh trống");
                return;
            }
            if (
                string.IsNullOrWhiteSpace(mskDienThoai.Text))
            {
                MessageBox.Show("Vui lòng không để số điện thoại trống");
                return;
            }
            if (
                 string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ địa chỉ của bạn");
                return;
            }
            // Kiểm tra định dạng của ngày sinh
            if (!DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Định dạng ngày sinh không hợp lệ. Vui lòng nhập theo định dạng DD/MM/YYYY.");
                return;
            }
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin này không?", "Xác nhận sửa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            // Xác định giới tính
            string gioiTinh = ckNam.Checked ? "Nam" : "Nữ";
            string dienThoai = mskDienThoai.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            // Thực hiện cập nhật thông tin nhân viên
            try
            {
                string accountId = Class.UserSession.AccountId;
                Class.Function.Connect();

                string query = $"UPDATE tblNhanVien SET TenNV = '{txtTen.Text}', NamSinh = '{ngaySinh.ToString("yyyy-MM-dd")}', DienThoai = '{dienThoai}', MaTinh = '{txtDiaChi.Text}', GioiTinh = '{gioiTinh}' WHERE Accountid = '{accountId}'";

                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công.");
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào được cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật thông tin nhân viên: " + ex.Message);
            }
            finally
            {
                Class.Function.Disconnect();
            }

        }

        private void btnThayTheAnh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đường dẫn hình ảnh đã được chọn từ picAvt hay không
            if (string.IsNullOrEmpty(txtAvt.Text))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh trước khi thay thế.");
                return;
            }
            // Đọc đường dẫn hình ảnh từ TextBox
            string imagePath = txtAvt.Text;

            try
            {
                string accountId = Class.UserSession.AccountId;
                Class.Function.Connect();

                string query = $"UPDATE tblNhanVien SET Image = '{imagePath.Replace("'", "''")}' WHERE Accountid = '{accountId.Replace("'", "''")}'";

                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thay thế ảnh thành công.");
                    // Hiển thị hình ảnh mới trên picAvt
                    if (File.Exists(imagePath))
                    {
                        picAvt.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tập tin hình ảnh.");
                    }
                }
                else
                {
                    MessageBox.Show("Không có ảnh nào được thay thế.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thay thế ảnh: " + ex.Message);
            }
            finally
            {
                Class.Function.Disconnect();
            }

        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            btnLuuMatKhau.Visible = true;
            btnBoQuaMK.Visible = true;
            pnMKMoi.Visible = true;
            btnDoiMatKhau.Enabled = false;
            txtPassCu.Enabled = true;
        }
        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            string passwordCu = txtPassCu.Text;
            string passwordMoi = txtPassMoi.Text;
            string passwordMoi2 = txtPassMoi2.Text;
            string accountid    = txtTenDN.Text;
            if (string.IsNullOrWhiteSpace(passwordCu) ||
                string.IsNullOrWhiteSpace(passwordMoi) ||
                string.IsNullOrWhiteSpace(passwordMoi2))
            {
                MessageBox.Show("Vui lòng không để trống các mật khẩu");
                return;
            }
            // Kiểm tra mật khẩu cũ
            if (!KiemTraMatKhauCu(accountid, passwordCu))
            {
                MessageBox.Show("Mật khẩu cũ không chính xác.");
                return;
            }
            // Kiểm tra hai mật khẩu mới
            if (passwordMoi != passwordMoi2)
            {
                MessageBox.Show("Hai mật khẩu mới không khớp.");
                return;
            }
            if (passwordCu == passwordMoi&&passwordCu==passwordMoi2)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ.");
                return;
            }
            if (passwordMoi.Length < 3)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 3 ký tự.");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đổi mật khẩu không?", "Xác nhận sửa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            // Lưu mật khẩu mới vào cơ sở dữ liệu
            try
            {
                Class.Function.Connect();
                string query = $"UPDATE tblAccount SET password = '{passwordMoi.Replace("'", "''")}' WHERE Accountid = '{accountid.Replace("'", "''")}'";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                }
                else
                {
                    MessageBox.Show("Không thể thay đổi mật khẩu. Vui lòng thử lại sau.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi mật khẩu: " + ex.Message);
            }
            finally
            {
                Class.Function.Disconnect();
            }

            btnLuuMatKhau.Visible = false;
            btnBoQuaMK.Visible = false;
            txtPassCu.Text = "";
            txtPassMoi.Text = "";
            txtPassMoi2.Text = "";
            btnDoiMatKhau.Enabled = true;
            pnMKMoi.Visible = false;
            txtPassCu.Enabled = false;
        }
        // Hàm kiểm tra mật khẩu cũ
        private bool KiemTraMatKhauCu(string accountId, string passwordCu)
        {
            try
            {
                Class.Function.Connect();
                string query = $"SELECT COUNT(*) FROM tblAccount WHERE Accountid = '{accountId.Replace("'", "''")}' AND password = '{passwordCu.Replace("'", "''")}'";

                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mật khẩu cũ: " + ex.Message);
                return false;
            }
            finally
            {
                Class.Function.Disconnect();
            }

        }

        private void btnBoQuaMK_Click(object sender, EventArgs e)
        {
            txtPassCu.Text = "";
            txtPassCu.Enabled = false;
            txtPassMoi.Text = "";
            txtPassMoi2.Text = "";
            pnMKMoi.Visible=false;
            btnDoiMatKhau.Enabled=true;
            btnLuuMatKhau.Visible = false;
            btnBoQuaMK.Visible=false;
        }
    }
  }

