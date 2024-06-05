using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class CaNhanBCSC : Form
    {
        DataTable CN;
        public CaNhanBCSC()
        {
            InitializeComponent();

        }

        private void CaNhanBCSC_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập trước khi sử dụng chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(); 
                return;

            }
            // Kiểm tra chức vụ của người dùng
            if (UserSession.ChucVu != "Giáo viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); 
                return;
            }

            Class.Function.Connect();
            Load_DataGridView();
            btnGui.Enabled = false;
            btnLamlai.Enabled = false; 
            txtNgayBCSC.Enabled = false;
            txtGiaovien.Enabled = false;
            cboPhongmay.Enabled = false;
            txtMota.Enabled = false;
            txtAnhSuCo.Enabled = false;
            picSuCo.Enabled = false;
            btnXoaanh1.Visible = false;
            txtAnhSuCo2.Enabled = false;
            picSuCo2.Enabled = false;
            btnXoaanh2.Visible = false;
            btnOpen.Enabled = false;
            labelTT.Visible = false;
            txtTrangthai.Visible = false;

            //Lọc
            Class.Function.FillCombo("SELECT MaPM, TenPM FROM tblPhongmay", cboLocPM, "MaPM", "TenPM");
            cboLocPM.SelectedIndex = -1;
            cboLocTT.Items.Add("Chưa xử lý");
            cboLocTT.Items.Add("Đang xử lý");
            cboLocTT.Items.Add("Đã xử lý");
            ClearDTP(dateTu);
            ClearDTP(dateDen);
        }
        private void ClearDTP(DateTimePicker dateTimePicker)
        {
            dateTimePicker.CustomFormat = " ";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }
        private void RestoreDTP(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Short; 
            dateTimePicker.CustomFormat = null;
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            RestoreDTP(dateTu);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            RestoreDTP(dateDen);
        }

        // Lấy MaNV từ bảng NhanVien dựa trên Accountid
        private string GetMaNVByAccountId(string accountId)
        {
            string maNV = "";
            try
            {
                string sql = "SELECT MaNV FROM tblNhanVien WHERE Accountid = @AccountId";
                SqlCommand cmd = new SqlCommand(sql, Class.Function.Conn);
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                maNV = cmd.ExecuteScalar()?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi truy vấn dữ liệu từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maNV;
        }

        private void Load_DataGridView()
        {
            string sql;
            string maNV = GetMaNVByAccountId(UserSession.AccountId);
            sql = "SELECT * FROM tblBaoCaoSuCo WHERE MaNV = N'"+ maNV + "'";
            CN = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = CN;
            dataGridView1.Columns[0].HeaderText = "Mã BCSC";
            dataGridView1.Columns[1].HeaderText = "Ngày BCSC";
            dataGridView1.Columns[2].HeaderText = "Mã phòng máy";
            dataGridView1.Columns[3].HeaderText = "Mã Giáo viên";
            dataGridView1.Columns[4].HeaderText = "Mô tả sự cố";
            dataGridView1.Columns[5].HeaderText = "Hình ảnh 1";
            dataGridView1.Columns[6].HeaderText = "Hình ảnh 2";
            dataGridView1.Columns[7].HeaderText = "Trạng thái";
            dataGridView1.Columns[8].HeaderText = "Ngày xử lý";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cboPhongmay.Enabled = false;
            txtMota.Enabled = false;
            picSuCo.Enabled = false;
            btnXoaanh1.Visible = false;
            picSuCo2.Enabled = false;
            btnXoaanh2.Visible = false;
            txtAnhSuCo.Visible = false;
            txtAnhSuCo2.Visible = false;
            btnLamlai.Enabled = true;
            labelTT.Visible = true;
            txtTrangthai.Visible = true;
            txtTrangthai.Enabled = false;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPhongmay.Focus();
                return;
            }

            if (CN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ma;
            txtNgayBCSC.Text = dataGridView1.CurrentRow.Cells["NgayBCSC"].Value.ToString();

            ma = dataGridView1.CurrentRow.Cells["MaPM"].Value.ToString();
            cboPhongmay.Text = Class.Function.GetFieldValues("SELECT TenPM FROM tblPhongmay WHERE MaPM = N'" + ma + "'");
            txtGiaovien.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();

            string trangthaiHT = "";
            switch (dataGridView1.CurrentRow.Cells["TrangThai"].Value.ToString())
            {
                case "0": 
                    trangthaiHT = "Chưa xử lý";
                    break;
                case "1":
                    trangthaiHT = "Đang xử lý";
                    break;
                case "2":
                    trangthaiHT = "Đã xử lý";
                    break;
            }
            txtTrangthai.Text = trangthaiHT;

            //Xử lý hình ảnh
            var cellValue = dataGridView1.CurrentRow.Cells["HinhAnh"].Value.ToString();
            var cellValue2 = dataGridView1.CurrentRow.Cells["HinhAnh2"].Value.ToString();

            if (cellValue != null )
            {
                string filePath = cellValue.ToString();

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    picSuCo.Image = Image.FromFile(filePath);
                }
                else
                {
                    picSuCo.Image = null;
                }
            }
            else
            {
                picSuCo.Image = null;
            }

            if (cellValue2 != null)
            {
                string filePath2 = cellValue2.ToString();

                if (!string.IsNullOrEmpty(filePath2) && File.Exists(filePath2))
                {
                    picSuCo2.Image = Image.FromFile(filePath2);
                }
                else
                {
                    picSuCo2.Image = null;
                }
            }
            else
            {
                picSuCo2.Image = null;
            }


            txtMota.Text = dataGridView1.CurrentRow.Cells["MoTaSC"].Value.ToString();
            btnOpen.Enabled = false;
            btnGui.Enabled = false;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Resetvalues();
            btnThem.Enabled = false;
            cboPhongmay.Enabled = true;
            cboPhongmay.Focus();
            txtMota.Enabled = true;
            txtAnhSuCo.Visible= true;
            txtAnhSuCo.Enabled = true;
            txtAnhSuCo2.Visible = true;
            txtAnhSuCo2.Enabled = true;
            btnOpen.Enabled = true;
            btnGui.Enabled = true;
            btnLamlai.Enabled = true;
            DateTime NgayGio = DateTime.Now;
            txtNgayBCSC.Text = NgayGio.ToString("HH:mm:ss dd/MM/yyyy");
            Class.Function.FillCombo("SELECT MaPM, TenPM FROM tblPhongmay", cboPhongmay, "MaPM", "TenPM");
            cboPhongmay.SelectedIndex = -1;
            string maNV = GetMaNVByAccountId(UserSession.AccountId);
            txtGiaovien.Text = maNV;
            btnXoaanh1.Visible = false;
            btnXoaanh2.Visible = false;

        }
        private void btnGui_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboPhongmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phòng máy gặp sự cố", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhongmay.Focus();
                return;
            }
            if (txtMota.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mô tả sự cố phòng máy xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMota.Focus();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thông báo sự cố tới Nhân viên phòng máy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maBCSC = SinhMaBCSC();

                sql = "INSERT INTO tblBaoCaoSuCo (MaBCSC, NgayBCSC, MaPM, MaNV, MoTaSC, HinhAnh, HinhAnh2, Trangthai, NgayXuLy) VALUES (N'" + maBCSC + "', N'" + ConvertDateTime(txtNgayBCSC.Text.Trim()) + "', N'" + cboPhongmay.SelectedValue + "', N'" + txtGiaovien.Text.Trim() + "', N'" + txtMota.Text.Trim() + "', N'" + txtAnhSuCo.Text.Trim() + "', N'" + txtAnhSuCo2.Text.Trim() + "', N'0', NULL)";

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, Class.Function.Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Báo cáo sự cố đã được gửi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resetvalues();
                    Load_DataGridView();
                    btnGui.Enabled = false;
                    btnLamlai.Enabled = false;
                    txtNgayBCSC.Enabled = false;
                    txtGiaovien.Enabled = false;
                    cboPhongmay.Enabled = false;
                    txtMota.Enabled = false;
                    txtAnhSuCo.Enabled = false;
                    picSuCo.Enabled = false;
                    btnXoaanh1.Visible = false;
                    txtAnhSuCo2.Enabled = false;
                    picSuCo2.Enabled = false;
                    btnXoaanh2.Visible = false;
                    btnOpen.Enabled = false;
                    labelTT.Visible = false;
                    txtTrangthai.Visible = false;



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            

        }

        private void Resetvalues()
        {
            txtNgayBCSC.Enabled = false;
            txtGiaovien.Enabled = false;
            txtNgayBCSC.Text = "";
            txtGiaovien.Text = "";
            cboPhongmay.Text = "";
            txtMota.Text = "";
            txtAnhSuCo.Text = "";
            txtAnhSuCo2.Text = "";
            picSuCo.Image = null;
            picSuCo2.Image = null;
            btnXoaanh1.Visible = false;
            btnXoaanh2.Visible = false;
            labelTT.Visible = false;
            txtTrangthai.Visible = false;
        }
        private void btnLamlai_Click(object sender, EventArgs e)
        {

            Resetvalues();
            btnLamlai.Enabled = false;
            btnThem.Enabled = true;
            btnGui.Enabled = false;



        }
        private string SinhMaBCSC()
        {
            int rowCount = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblBaoCaoSuCo", Class.Function.Conn))
            {
                rowCount = (int)cmd.ExecuteScalar();
            }

            string maBCSC = "SC" + (rowCount + 1).ToString("000");
            return maBCSC;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                InitialDirectory = "C:\\",
                FilterIndex = 1,
                Title = "Chọn hình ảnh"
            };

            // Kiểm tra nếu người dùng đã chọn ảnh
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                if (picSuCo.Image == null)
                {
                    // Nếu pic1 chưa có ảnh, gán ảnh vào pic1
                    picSuCo.Image = Image.FromFile(dlgOpen.FileName);
                    txtAnhSuCo.Text = dlgOpen.FileName;
                    btnXoaanh1.Visible = true;
                }
                else if (picSuCo2.Image == null)
                {
                    // Nếu pic1 đã có ảnh và pictureBox2 chưa có ảnh, gán ảnh vào pic2
                    picSuCo2.Image = Image.FromFile(dlgOpen.FileName);
                    txtAnhSuCo2.Text = dlgOpen.FileName;
                    btnXoaanh2.Visible = true;
                }
                else
                {
                    MessageBox.Show("Số lượng ảnh đã đạt đến giới hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static string ConvertDateTime(string d)
        {
            DateTime parsedDate = DateTime.Parse(d);
            return parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
        }


        private void btnXoaanh1_Click(object sender, EventArgs e)
        {
            if (picSuCo2.Image != null)
            {
                picSuCo.Image = picSuCo2.Image;
                txtAnhSuCo.Text = txtAnhSuCo2.Text;
                picSuCo2.Image = null;
                txtAnhSuCo2.Text = "";
                btnXoaanh2.Visible = false;
            }
            else
            {
                picSuCo.Image = null;
                txtAnhSuCo.Text = "";
                btnXoaanh1.Visible = false; 
            }

        }

        private void btnXoaanh2_Click(object sender, EventArgs e)
        {
            picSuCo2.Image= null;
            txtAnhSuCo2.Text = null;
            btnXoaanh2.Visible = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maNV = GetMaNVByAccountId(UserSession.AccountId);
            string sql = "SELECT * FROM tblBaoCaoSuCo WHERE 1=1 AND MaNV = N'" + maNV + "' ";


            bool isDateTuClear = dateTu.CustomFormat == " ";
            bool isDateDenClear = dateDen.CustomFormat == " ";

            if (cboLocPM.SelectedIndex == -1 && cboLocTT.SelectedIndex == -1 && (isDateTuClear && isDateDenClear))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí lọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Lọc theo Phòng máy
                if (cboLocPM.SelectedIndex != -1)
                {
                    string maPM = cboLocPM.SelectedValue.ToString();
                    sql += " AND MaPM = '" + maPM + "'";
                }

                // Lọc theo Trạng thái
                if (cboLocTT.SelectedIndex != -1)
                {
                    int trangThai = cboLocTT.SelectedIndex;
                    sql += " AND TrangThai = " + trangThai;
              
                }

                // Lọc theo ngày
                if ((!isDateTuClear && isDateDenClear) && (!isDateDenClear && isDateTuClear))
                {
                    MessageBox.Show("Vui lòng nhập cả ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if ((!isDateTuClear) && (!isDateDenClear))
                {
                    DateTime ngayTuValue = dateTu.Value;
                    DateTime ngayDenValue = dateDen.Value;

                    if (ngayDenValue >= ngayTuValue)
                    {
                        string ngayTu = ngayTuValue.ToString("yyyy-MM-dd") + " 00:00:00";
                        string ngayDen = ngayDenValue.ToString("yyyy-MM-dd") + " 23:59:59";

                        sql += " AND NgayBCSC >= '" + ngayTu + "'";
                        sql += " AND NgayBCSC <= '" + ngayDen + "'";
                    }
                    else
                    {
                        MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
            }


            DataTable result = Class.Function.GetDataToTable(sql);

                dataGridView1.DataSource = result;

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_DataGridView();
                }
            
        
        }


        private void btnHienthi_Click_1(object sender, EventArgs e)
        {
            cboLocPM.Text = "";
            cboLocTT.Text = "";
            ClearDTP(dateTu);
            ClearDTP(dateDen);
            Load_DataGridView();
        }
    }
}
