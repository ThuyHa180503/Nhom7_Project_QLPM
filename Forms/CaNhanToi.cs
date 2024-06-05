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
        {// Kiểm tra xem người dùng đã đăng nhập chưa
            if (Class.UserSession.IsLoggedIn())
            {
                // Lấy AccountId của người dùng đăng nhập
                string accountId = Class.UserSession.AccountId;

                // Kết nối đến cơ sở dữ liệu và truy vấn thông tin nhân viên
                try
                {
                    Class.Function.Connect();
                    string query = "SELECT TenNV, MaNV, NamSinh, DienThoai, GioiTinh, MaTinh, Image FROM tblNhanVien WHERE Accountid = @AccountId";
                    SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                    command.Parameters.AddWithValue("@AccountId", accountId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy thông tin từ cơ sở dữ liệu
                        string tenNV = reader["TenNV"].ToString();
                        string maNV = reader["MaNV"].ToString();
                        string namSinh = reader["NamSinh"].ToString();
                        string dienThoai = reader["DienThoai"].ToString();
                        bool gioiTinh = reader["GioiTinh"].ToString() == "Nam"; // Nếu là "Nam", gán true, ngược lại gán false
                        string maTinh = reader["MaTinh"].ToString();
                        string imagePath = reader["Image"].ToString(); // Lấy đường dẫn hình ảnh

                        // Hiển thị thông tin lên giao diện
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
                            picAvt.Image = null; // hoặc có thể hiển thị một hình ảnh mặc định: picAvt.Image = Properties.Resources.DefaultImage;
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
            // Hiển thị Accountid trong txtTenDN
            txtTenDN.Text = Class.UserSession.AccountId;

            // Ẩn mật khẩu
            txtPassCu.Text = "";
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
            // Kiểm tra xem các trường có trống không
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(mskNgaySinh.Text) ||
                string.IsNullOrWhiteSpace(mskDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return; // Dừng xử lý nếu có trường trống
            }

            // Kiểm tra định dạng của ngày sinh
            if (!DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Định dạng ngày sinh không hợp lệ. Vui lòng nhập theo định dạng DD/MM/YYYY.");
                return; // Dừng xử lý nếu ngày sinh không hợp lệ
            }

            // Xác định giới tính
            string gioiTinh = ckNam.Checked ? "Nam" : "Nữ";
            //Nếu không muốn csdl xấu
            string dienThoai = mskDienThoai.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            // Thực hiện cập nhật thông tin nhân viên
            try
            {
                // Lấy AccountId của người dùng đăng nhập
                string accountId = Class.UserSession.AccountId;

                // Kết nối đến cơ sở dữ liệu và thực hiện truy vấn cập nhật
                Class.Function.Connect();
                string query = "UPDATE tblNhanVien SET TenNV = @TenNV, NamSinh = @NamSinh, DienThoai = @DienThoai, MaTinh = @MaTinh, GioiTinh = @GioiTinh WHERE Accountid = @AccountId";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                command.Parameters.AddWithValue("@TenNV", txtTen.Text);
                command.Parameters.AddWithValue("@NamSinh", ngaySinh); // Sử dụng giá trị DateTime đã kiểm tra
                command.Parameters.AddWithValue("@DienThoai", dienThoai);
                command.Parameters.AddWithValue("@MaTinh", txtDiaChi.Text);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@AccountId", accountId);
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
                // Lấy AccountId của người dùng đăng nhập
                string accountId = Class.UserSession.AccountId;

                // Kết nối đến cơ sở dữ liệu và thực hiện truy vấn cập nhật
                Class.Function.Connect();
                string query = "UPDATE tblNhanVien SET Image = @Image WHERE Accountid = @AccountId";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                command.Parameters.AddWithValue("@Image", imagePath);
                command.Parameters.AddWithValue("@AccountId", accountId);
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
            // Lấy dữ liệu từ các ô văn bản
            string passwordCu = txtPassCu.Text;
            string passwordMoi = txtPassMoi.Text;
            string passwordMoi2 = txtPassMoi2.Text;
            string accountid    = txtTenDN.Text;

            // Kiểm tra xem các ô văn bản có trống không
            if (string.IsNullOrWhiteSpace(passwordCu) ||
                string.IsNullOrWhiteSpace(passwordMoi) ||
                string.IsNullOrWhiteSpace(passwordMoi2))
            {
                MessageBox.Show("Vui lòng điền vào tất cả các ô.");
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
            // Kiểm tra mật khẩu mới phải có ít nhất 3 ký tự
            if (passwordMoi.Length < 3)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 3 ký tự.");
                return;
            }
            // Lưu mật khẩu mới vào cơ sở dữ liệu
            try
            {
                Class.Function.Connect();
                string query = "UPDATE tblAccount SET password = @passwordMoi WHERE Accountid = @accountId";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                command.Parameters.AddWithValue("@passwordMoi", passwordMoi);
                command.Parameters.AddWithValue("@accountId", accountid);
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
                string query = "SELECT COUNT(*) FROM tblAccount WHERE Accountid = @accountId AND password = @passwordCu";
                SqlCommand command = new SqlCommand(query, Class.Function.Conn);
                command.Parameters.AddWithValue("@accountId", accountId);
                command.Parameters.AddWithValue("@passwordCu", passwordCu);
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

