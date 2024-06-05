using Nhom7_Project_QLPM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Nhom7_Project_QLPM.Forms
{
    public partial class QLXuLyBCSC : Form
    {
        DataTable SC;
        public QLXuLyBCSC()
        {
            InitializeComponent();
        }

        private void QLXuLyBCSC_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập trước khi sử dụng chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(); 
                return;

            }
            if (UserSession.ChucVu != "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); 
                return;
            }
            Class.Function.Connect();
            txtMaBCSC.Enabled = false;
            txtNgaySC.Enabled = false;
            txtGiaovien.Enabled = false;
            txtTenGV.Enabled = false;
            txtSDT.Enabled = false;
            cboPhongmay.Enabled = false;
            picSuCo.Enabled = false;
            txtMota.Enabled = false;
            txtNgayXL.Enabled = false;
            cboTrangthai.Enabled = false;
            txtGhichu.Enabled = false;
            btnBoqua.Enabled = false;

            //Lọc
            Class.Function.FillCombo("SELECT MaPM, TenPM FROM tblPhongmay", cboLocPM, "MaPM", "TenPM");
            cboLocPM.SelectedIndex = -1;
            cboLocTT.Items.Add("Chưa xử lý");
            cboLocTT.Items.Add("Đang xử lý");
            cboLocTT.Items.Add("Đã xử lý");
            ClearDTP(dateTu);
            ClearDTP(dateDen);

            Load_DataGridView();
            cboTrangthai.Items.Add("Chưa xử lý");
            cboTrangthai.Items.Add("Đang xử lý");
            cboTrangthai.Items.Add("Đã xử lý");

            btnCapnhat.Enabled = false;
            btnBoqua.Enabled = false;
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

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblBaoCaoSuCo";
            SC = Class.Function.GetDataToTable(sql);
            dataGridView1.DataSource = SC;
            dataGridView1.Columns[0].HeaderText = "Mã BCSC";
            dataGridView1.Columns[1].HeaderText = "Ngày BCSC";
            dataGridView1.Columns[2].HeaderText = "Mã phòng máy";
            dataGridView1.Columns[3].HeaderText = "Mã Giáo viên";
            dataGridView1.Columns[4].HeaderText = "Mô tả sự cố";
            dataGridView1.Columns[5].HeaderText = "Hình ảnh 1";
            dataGridView1.Columns[6].HeaderText = "Hình ảnh 2";
            dataGridView1.Columns[7].HeaderText = "Trạng thái";
            dataGridView1.Columns[8].HeaderText = "Ngày xử lý";
            dataGridView1.Columns[9].HeaderText = "Ghi chú";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cboTrangthai.Enabled = true;
            txtGhichu.Enabled = true;
            btnCapnhat.Enabled = true;
            btnBoqua.Enabled = true;


            if (SC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string mapm;
            txtMaBCSC.Text = dataGridView1.CurrentRow.Cells["MaBCSC"].Value.ToString();
            txtNgaySC.Text = dataGridView1.CurrentRow.Cells["NgayBCSC"].Value.ToString();
            mapm = dataGridView1.CurrentRow.Cells["MaPM"].Value.ToString();
            cboPhongmay.Text = Class.Function.GetFieldValues("SELECT TenPM FROM tblPhongmay WHERE MaPM = N'" + mapm + "'");
            txtGiaovien.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();

            string magv;
            magv = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenGV.Text = Class.Function.GetFieldValues("SELECT TenNV FROM tblNhanvien WHERE MaNV = N'" + magv + "'");
            txtSDT.Text = Class.Function.GetFieldValues("SELECT DienThoai FROM tblNhanvien WHERE MaNV = N'" + magv + "'");

            //Xử lý hình ảnh
            var cellValue = dataGridView1.CurrentRow.Cells["HinhAnh"].Value.ToString();

            var cellValue2 = dataGridView1.CurrentRow.Cells["HinhAnh2"].Value.ToString();

            if (cellValue != null)
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
                    picSuco2.Image = Image.FromFile(filePath2);
                }
                else
                {
                    picSuco2.Image = null;
                }
            }
            else
            {
                picSuco2.Image = null;
            }


            txtMota.Text = dataGridView1.CurrentRow.Cells["MoTaSC"].Value.ToString();

            //Hiển thị trạng thái
            int trangThai = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TrangThai"].Value.ToString());
            switch (trangThai)
            {
                case 0:
                    cboTrangthai.SelectedItem = "Chưa xử lý";
                    break;
                case 1:
                    cboTrangthai.SelectedItem = "Đang xử lý";
                    break;
                case 2:
                    cboTrangthai.SelectedItem = "Đã xử lý";
                    break;
            }
            txtNgayXL.Text = dataGridView1.CurrentRow.Cells["NgayXuLy"].Value.ToString();
            txtGhichu.Text = dataGridView1.CurrentRow.Cells["GhiChu"].Value.ToString();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {

            int trangThaiMoi = -1;

            switch (cboTrangthai.SelectedItem.ToString())
            {
                case "Chưa xử lý":
                    trangThaiMoi = 0;
                    break;
                case "Đang xử lý":
                    trangThaiMoi = 1;
                    break;
                case "Đã xử lý":
                    trangThaiMoi = 2;
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn một trạng thái để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            string maBCSC = dataGridView1.CurrentRow.Cells["MaBCSC"].Value.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật trạng thái và ghi chú của sự cố không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sql = "UPDATE tblBaoCaoSuCo SET TrangThai = " + trangThaiMoi + ", GhiChu = N'" + txtGhichu.Text + "' WHERE MaBCSC = '" + maBCSC + "'";
                Class.Function.RunSql(sql);

                if (trangThaiMoi == 2)
                {
                    string ngayXL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string sqlNgayXL = "UPDATE tblBaoCaoSuCo SET NgayXuLy = '" + ngayXL + "' WHERE MaBCSC = '" + maBCSC + "'";
                    Class.Function.RunSql(sqlNgayXL);
                }
                else if (trangThaiMoi == 0 || trangThaiMoi == 1)
                {
                    string sqlNgayXL = "UPDATE tblBaoCaoSuCo SET NgayXuLy = NULL WHERE MaBCSC = '" + maBCSC + "'";
                    Class.Function.RunSql(sqlNgayXL);
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DataGridView();
            }
        }

        public void ResetValues()
        {
            txtMaBCSC.Text = "";
            txtNgaySC.Text = "";
            txtGiaovien.Text = "";
            txtTenGV.Text = "";
            txtSDT.Text = "";
            cboPhongmay.Text = "";
            cboTrangthai.Text = "";
            txtNgayXL.Text = "";
            cboTrangthai.Text = "";
            picSuCo.Image = null;
            picSuco2.Image = null;
            txtMota.Text = null;

        }
        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            txtGhichu.Enabled = false;
            cboTrangthai.Enabled = false;
        }


        private void btnLammoi_Click(object sender, EventArgs e)
        {
            cboLocPM.Text = "";
            cboLocTT.Text = "";
            dateTu.Text = "";
            dateDen.Text = "";
            Load_DataGridView();
        }



        private void btnLoc_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblBaoCaoSuCo WHERE 1=1";


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
                if ((!isDateTuClear && isDateDenClear) || (!isDateDenClear && isDateTuClear))
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
 
    }
}