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
    public partial class QLXuLyBCSC : Form
    {
        DataTable SC;
        public QLXuLyBCSC()
        {
            InitializeComponent();
        }

        private void QLXuLyBCSC_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            txtMaBCSC.Enabled = false;
            txtNgaySC.Enabled = false;
            txtGiaovien.Enabled = false;
            cboPhongmay.Enabled = false;
            picSuCo.Enabled = false;
            txtMota.Enabled = false;
            txtNgayXL.Enabled = false;
            cboTrangthai.Enabled = false;
            //Lọc
            Class.Function.FillCombo("SELECT MaPM, TenPM FROM tblPhongmay", cboLocPM, "MaPM", "TenPM");
            cboLocPM.SelectedIndex = -1;
            cboLocTT.Items.Add("Chưa xử lý");
            cboLocTT.Items.Add("Đang xử lý");
            cboLocTT.Items.Add("Đã xử lý");


            //Load thong tin
            Load_DataGridView();
            cboTrangthai.Items.Add("Chưa xử lý");
            cboTrangthai.Items.Add("Đang xử lý");
            cboTrangthai.Items.Add("Đã xử lý");

            btnCapnhat.Enabled = false;
            btnBoqua.Enabled = false;
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
            dataGridView1.Columns[5].HeaderText = "Hình ảnh";
            dataGridView1.Columns[6].HeaderText = "Trạng thái";
            dataGridView1.Columns[7].HeaderText = "Ngày xử lý";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;




        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cboTrangthai.Enabled = true;
            btnCapnhat.Enabled = true;
            btnBoqua.Enabled = true;
            if(SC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            string ma;
            txtMaBCSC.Text = dataGridView1.CurrentRow.Cells["MaBCSC"].Value.ToString();
            txtNgaySC.Text = dataGridView1.CurrentRow.Cells["NgayBCSC"].Value.ToString();
            ma = dataGridView1.CurrentRow.Cells["MaPM"].Value.ToString();
            cboPhongmay.Text = Class.Function.GetFieldValues("SELECT TenPM FROM tblPhongmay WHERE MaPM = N'" + ma + "'");
            txtGiaovien.Text = dataGridView1.CurrentRow.Cells["MaGV"].Value.ToString();
            picSuCo.Image = Image.FromFile(dataGridView1.CurrentRow.Cells["HinhAnh"].Value.ToString());
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

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật trạng thái của sự cố không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sql = "UPDATE tblBaoCaoSuCo SET TrangThai = " + trangThaiMoi + " WHERE MaBCSC = '" + maBCSC + "'";
                Class.Function.RunSql(sql);

                if (trangThaiMoi == 2)
                {
                    string ngayXL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string sqlNgayXL = "UPDATE tblBaoCaoSuCo SET NgayXuLy = '" + ngayXL + "' WHERE MaBCSC = '" + maBCSC + "'";
                    Class.Function.RunSql(sqlNgayXL);
                }

                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DataGridView();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtMaBCSC.Text = "";
            txtNgaySC.Text = "";
            txtGiaovien.Text = "";
            cboPhongmay.Text = "";
            cboTrangthai.Text = "";
            txtNgayXL.Text = "";
            cboTrangthai.Text = "";
            picSuCo.Image = null;
            txtMota.Text = null;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblBaoCaoSuCo WHERE 1=1";

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

            //Lọc theo ngày
            }
            if (dateTu.Checked)
            {
                string ngayTu = dateTu.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                sql += " AND NgayBCSC >= '" + ngayTu + "'";
            }

            if (dateDen.Checked)
            {
                string ngayDen = dateDen.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                sql += " AND NgayBCSC <= '" + ngayDen + "'";
            }

            DataTable result = Class.Function.GetDataToTable(sql);

            dataGridView1.DataSource = result;

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (cboLocPM.SelectedIndex == -1 && cboLocTT.SelectedIndex == -1 && dateTu.Checked == false && dateDen.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí lọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            cboLocPM.Text = "";
            cboLocTT.Text = "";
            dateTu.Text = "";
            dateDen.Text = "";
            Load_DataGridView();
        }
    }
}
