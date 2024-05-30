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
    public partial class CaNhanBCSC : Form
    {
        DataTable CN;
        public CaNhanBCSC()
        {
            InitializeComponent();
        }

        private void CaNhanBCSC_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            txtNgayBCSC.Enabled = false;
            txtGiaovien.Enabled = false;
            DateTime NgayGio = DateTime.Now;
            txtNgayBCSC.Text = NgayGio.ToString("HH:mm:ss dd/MM/yyyy");
            Class.Function.FillCombo("SELECT MaPM, TenPM FROM tblPhongmay",cboPhongmay, "MaPM", "TenPM");
            cboPhongmay.SelectedIndex = -1;
            txtGiaovien.Text = "GV001";

        }


        private void btnGui_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboPhongmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phòng máy gặp sự cố", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMota.Focus();
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

                sql = "INSERT INTO tblBaoCaoSuCo (MaBCSC, NgayBCSC, MaPM, MaGV, MoTaSC, HinhAnh, Trangthai, NgayXuLy) VALUES (N'" + maBCSC + "', N'" + ConvertDateTime(txtNgayBCSC.Text.Trim()) + "', N'" + cboPhongmay.SelectedValue + "', N'" + txtGiaovien.Text.Trim() + "', N'" + txtMota.Text.Trim() + "', N'" + txtAnhSuCo.Text.Trim() + "', N'0', NULL)";

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, Class.Function.Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Báo cáo sự cố đã được gửi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resetvalues();
                    DateTime NgayGio = DateTime.Now;
                    txtNgayBCSC.Text = NgayGio.ToString("HH:mm:ss dd/MM/yyyy");
                    txtGiaovien.Text = "GV002";
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
            picSuCo.Image = null;
            
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
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "JPG|*.jpg|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "C:\\";
            dlgOpen.FilterIndex = 3;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picSuCo.Image = Image.FromFile(dlgOpen.FileName);
                txtAnhSuCo.Text = dlgOpen.FileName;
            }
        }

        public static string ConvertDateTime(string d)
        {
            DateTime parsedDate = DateTime.Parse(d);
            return parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
        }


        private void btnLamlai_Click(object sender, EventArgs e)
        {

            Resetvalues();
            DateTime NgayGio = DateTime.Now;
            txtNgayBCSC.Text = NgayGio.ToString("HH:mm:ss dd/MM/yyyy");
            txtGiaovien.Text = "GV002";

        }


    }
}
