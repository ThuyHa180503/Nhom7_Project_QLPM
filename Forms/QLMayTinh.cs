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
    public partial class QLMayTinh : Form
    {
        public QLMayTinh()
        {
            InitializeComponent();
        }

        DataTable qlmt;

        private void QLMayTinh_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            btnCapnhat.Enabled = false;

            Load_DataGridView();

            functions.FillCombo("SELECT MaBanPhim, TenBanPhim FROM tblBanPhim",cbobp, "MaBanPhim", "TenBanPhim");
            cbobp.SelectedIndex = -1;

            functions.FillCombo("SELECT MaChip, TenChip FROM tblChip", cbochip, "MaChip", "TenChip");
            cbochip.SelectedIndex = -1;

            functions.FillCombo("SELECT MaChuot, TenChuot FROM tblChuot", cbochuot, "MaChuot", "TenChuot");
            cbochuot.SelectedIndex = -1;

            functions.FillCombo("SELECT MaCoManHinh, TenCoManHinh FROM tblCoManHinh", cbocmh, "MaCoManHinh", "TenCoManHinh");
            cbocmh.SelectedIndex = -1;

            functions.FillCombo("SELECT MaDungLuong, TenDungLuong FROM tblDungLuong", cbodl, "MaDungLuong", "TenDungLuong");
            cbodl.SelectedIndex = -1;

            functions.FillCombo("SELECT MaManHinh, TenManHinh FROM tblManHinh", cbomh, "MaManHinh", "TenManHinh");
            cbomh.SelectedIndex = -1;

            functions.FillCombo("SELECT MaOCung, TenOCung FROM tblOCung", cbooc, "MaOCung", "TenOCung");
            cbooc.SelectedIndex = -1;

            functions.FillCombo("SELECT MaODia, TenODia FROM tblODia", cboodia, "MaODia", "TenODia");
            cboodia.SelectedIndex = -1;

            functions.FillCombo("SELECT MaRam, TenRam FROM tblRam", cboram, "MaRam", "TenRam");
            cboram.SelectedIndex = -1;

            functions.FillCombo("SELECT MaTocDo, TenTocDo FROM tblTocDo", cbotocdo, "MaTocDo", "TenTocDo");
            cbotocdo.SelectedIndex = -1;

            functions.FillCombo("SELECT MaPM, TenPM FROM tblPhongMay", cbophongmay, "MaPM", "TenPM");
            cbophongmay.SelectedIndex = -1;

            functions.FillCombo("SELECT MaPM, TenPM FROM tblPhongMay", cboloc, "MaPM", "TenPM");
            cboloc.SelectedIndex = -1;

            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaMay,TenMay,MaPM,MaOCung,MaDungLuong,MaRam,MaTocDo,MaManHinh,MaBanPhim,MaChuot,MaCoManHinh,MaODia,MaChip,GhiChu FROM tblMayTinh";

            qlmt = Class.functions.GetDataToTable(sql);
            dataGridView1.DataSource = qlmt;

            dataGridView1.Columns[0].HeaderText = "Mã máy tính";
            dataGridView1.Columns[1].HeaderText = "Tên máy tính";
            dataGridView1.Columns[2].HeaderText = "Mã phòng máy";
            dataGridView1.Columns[3].HeaderText = "Mã ổ cứng";
            dataGridView1.Columns[4].HeaderText = "Mã dung lượng";
            dataGridView1.Columns[5].HeaderText = "Mã ram";
            dataGridView1.Columns[6].HeaderText = "Mã tốc độ";
            dataGridView1.Columns[7].HeaderText = "Mã màn hình";
            dataGridView1.Columns[8].HeaderText = "Mã bàn phím";
            dataGridView1.Columns[9].HeaderText = "Mã chuột";
            dataGridView1.Columns[10].HeaderText = "Mã cỡ màn hình";
            dataGridView1.Columns[11].HeaderText = "Mã ổ đĩa";
            dataGridView1.Columns[12].HeaderText = "Mã chip";
            dataGridView1.Columns[13].HeaderText = "Ghi chú";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 100;
            dataGridView1.Columns[12].Width = 80;
            dataGridView1.Columns[13].Width = 200;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtmamay.Text = "";
            txttenmay.Text = "";
            cbophongmay.Text = "";
            cbooc.Text = "";
            cbocmh.Text = "";
            cbobp.Text = "";
            cbochip.Text = "";
            cbochuot.Text = "";
            cbodl.Text = "";
            cbomh.Text = "";
            cboodia.Text = "";
            cboram.Text = "";
            cbotocdo.Text = "";
            txtghichu.Text = "";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamay.Focus();
                return;
            }
            if (qlmt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            txtmamay.Text = dataGridView1.CurrentRow.Cells["MaMay"].Value.ToString();
            txttenmay.Text = dataGridView1.CurrentRow.Cells["TenMay"].Value.ToString();
            txtghichu.Text = dataGridView1.CurrentRow.Cells["GhiChu"].Value.ToString();

            string pm = dataGridView1.CurrentRow.Cells["MaPM"].Value.ToString();
            cbophongmay.Text = functions.GetFieldValues("SELECT TenPM FROM tblPhongMay WHERE MaPM = N'" + pm + "'");

            string bp = dataGridView1.CurrentRow.Cells["MaBanPhim"].Value.ToString();
            cbobp.Text = functions.GetFieldValues("SELECT TenBanPhim FROM tblBanPhim WHERE MaBanPhim = N'" + bp + "'");

            string chip = dataGridView1.CurrentRow.Cells["MaChip"].Value.ToString();
            cbochip.Text = functions.GetFieldValues("SELECT TenChip FROM tblChip WHERE MaChip = N'" + chip + "'");

            string chuot = dataGridView1.CurrentRow.Cells["MaChuot"].Value.ToString();
            cbochuot.Text = functions.GetFieldValues("SELECT TenChuot FROM tblChuot WHERE MaChuot = N'" + chuot + "'");

            string cmh = dataGridView1.CurrentRow.Cells["MaCoManHinh"].Value.ToString();
            cbocmh.Text = functions.GetFieldValues("SELECT TenCoManHinh FROM tblCoManHinh WHERE MaCoManHinh = N'" + cmh + "'");

            string dl = dataGridView1.CurrentRow.Cells["MaDungLuong"].Value.ToString();
            cbodl.Text = functions.GetFieldValues("SELECT TenDungLuong FROM tblDungLuong WHERE MaDungLuong = N'" + dl + "'");

            string mh = dataGridView1.CurrentRow.Cells["MaManHinh"].Value.ToString();
            cbomh.Text = functions.GetFieldValues("SELECT TenManHinh FROM tblManHinh WHERE MaManHinh = N'" + mh + "'");

            string oc = dataGridView1.CurrentRow.Cells["MaOCung"].Value.ToString();
            cbooc.Text = functions.GetFieldValues("SELECT TenOCung FROM tblOCung WHERE MaOCung = N'" + oc + "'");

            string od = dataGridView1.CurrentRow.Cells["MaODia"].Value.ToString();
            cboodia.Text = functions.GetFieldValues("SELECT TenODia FROM tblODia WHERE MaODia = N'" + od + "'");

            string ram = dataGridView1.CurrentRow.Cells["MaRam"].Value.ToString();
            cboram.Text = functions.GetFieldValues("SELECT TenRam FROM tblRam WHERE MaRam = N'" + ram + "'");

            string tocdo = dataGridView1.CurrentRow.Cells["MaTocDo"].Value.ToString();
            cbotocdo.Text = functions.GetFieldValues("SELECT TenTocDo FROM tblTocDo WHERE MaTocDo = N'" + tocdo + "'");

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtmamay.Enabled = false;
            ResetValues();
            
            //thêm mã máy tự động
            int count = 0;
            count = dataGridView1.Rows.Count; //đếm tất cả các dòng có trong dtgv
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dataGridView1.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));
            if (chuoi2 + 1 < 10)
                txtmamay.Text = "MT000" + (chuoi2 + 1).ToString();
            else if (chuoi2 + 1 < 100)
                txtmamay.Text = "MT00" + (chuoi2 + 1).ToString();
            else if (chuoi2 + 1 < 1000)
                txtmamay.Text = "MT0" + (chuoi2 + 1).ToString();
            else if (chuoi2 + 1 < 10000)
                txtmamay.Text = "MT" + (chuoi2 + 1).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttenmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenmay.Focus();
                return;
            }
            if (cbophongmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phòng máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbophongmay.Focus();
                return;
            }

            string maOCung;
            if (cbooc.SelectedValue != null)
            {
                maOCung = "N'" + cbooc.SelectedValue.ToString() + "'";
            }
            else
            {
                maOCung = "NULL";
            }

            string maDungLuong;
            if (cbodl.SelectedValue != null)
            {
                maDungLuong = "N'" + cbodl.SelectedValue.ToString() + "'";
            }
            else
            {
                maDungLuong = "NULL";
            }

            string maRam;
            if (cboram.SelectedValue != null)
            {
                maRam = "N'" + cboram.SelectedValue.ToString() + "'";
            }
            else
            {
                maRam = "NULL";
            }

            string maTocDo;
            if (cbotocdo.SelectedValue != null)
            {
                maTocDo = "N'" + cbotocdo.SelectedValue.ToString() + "'";
            }
            else
            {
                maTocDo = "NULL";
            }

            string maManHinh;
            if (cbomh.SelectedValue != null)
            {
                maManHinh = "N'" + cbomh.SelectedValue.ToString() + "'";
            }
            else
            {
                maManHinh = "NULL";
            }

            string maBanPhim;
            if (cbobp.SelectedValue != null)
            {
                maBanPhim = "N'" + cbobp.SelectedValue.ToString() + "'";
            }
            else
            {
                maBanPhim = "NULL";
            }

            string maChuot;
            if (cbochuot.SelectedValue != null)
            {
                maChuot = "N'" + cbochuot.SelectedValue.ToString() + "'";
            }
            else
            {
                maChuot = "NULL";
            }

            string maCoManHinh;
            if (cbocmh.SelectedValue != null)
            {
                maCoManHinh = "N'" + cbocmh.SelectedValue.ToString() + "'";
            }
            else
            {
                maCoManHinh = "NULL";
            }

            string maODia;
            if (cboodia.SelectedValue != null)
            {
                maODia = "N'" + cboodia.SelectedValue.ToString() + "'";
            }
            else
            {
                maODia = "NULL";
            }

            string maChip;
            if (cbochip.SelectedValue != null)
            {
                maChip = "N'" + cbochip.SelectedValue.ToString() + "'";
            }
            else
            {
                maChip = "NULL";
            }

            sql = "INSERT INTO tblMayTinh (MaMay, TenMay, GhiChu, MaOCung, MaDungLuong, MaPM, MaRam, MaTocDo, MaManHinh, MaBanPhim, MaChuot, MaCoManHinh, MaODia, MaChip) VALUES (N'" + txtmamay.Text.Trim() + "', N'" + txttenmay.Text.Trim() + "', N'" + txtghichu.Text.Trim() + "', " + maOCung + ", " + maDungLuong + ", N'" + cbophongmay.SelectedValue.ToString() + "', " + maRam + ", " + maTocDo + ", " + maManHinh + ", " + maBanPhim + ", " + maChuot + "," + maCoManHinh + "," + maODia + "," + maChip + ")";

            functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnCapnhat.Enabled = true;
            txtmamay.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (qlmt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtmamay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên máy", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txttenmay.Focus();
                return;
            }
            if (cbophongmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phòng máy", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbophongmay.Focus();
                return;
            }

            string mapmtruoc = functions.GetFieldValues("SELECT MaPM FROM tblMayTinh WHERE MaMay = N'" + txtmamay.Text.Trim() + "'");

            string maOCung;
            if (cbooc.SelectedValue != null)
            {
                maOCung = "N'" + cbooc.SelectedValue.ToString() + "'";
            }
            else
            {
                maOCung = "NULL";
            }

            string maDungLuong;
            if (cbodl.SelectedValue != null)
            {
                maDungLuong = "N'" + cbodl.SelectedValue.ToString() + "'";
            }
            else
            {
                maDungLuong = "NULL";
            }

            string maRam;
            if (cboram.SelectedValue != null)
            {
                maRam = "N'" + cboram.SelectedValue.ToString() + "'";
            }
            else
            {
                maRam = "NULL";
            }

            string maTocDo;
            if (cbotocdo.SelectedValue != null)
            {
                maTocDo = "N'" + cbotocdo.SelectedValue.ToString() + "'";
            }
            else
            {
                maTocDo = "NULL";
            }

            string maManHinh;
            if (cbomh.SelectedValue != null)
            {
                maManHinh = "N'" + cbomh.SelectedValue.ToString() + "'";
            }
            else
            {
                maManHinh = "NULL";
            }

            string maBanPhim;
            if (cbobp.SelectedValue != null)
            {
                maBanPhim = "N'" + cbobp.SelectedValue.ToString() + "'";
            }
            else
            {
                maBanPhim = "NULL";
            }

            string maChuot;
            if (cbochuot.SelectedValue != null)
            {
                maChuot = "N'" + cbochuot.SelectedValue.ToString() + "'";
            }
            else
            {
                maChuot = "NULL";
            }

            string maCoManHinh;
            if (cbocmh.SelectedValue != null)
            {
                maCoManHinh = "N'" + cbocmh.SelectedValue.ToString() + "'";
            }
            else
            {
                maCoManHinh = "NULL";
            }

            string maODia;
            if (cboodia.SelectedValue != null)
            {
                maODia = "N'" + cboodia.SelectedValue.ToString() + "'";
            }
            else
            {
                maODia = "NULL";
            }

            string maChip;
            if (cbochip.SelectedValue != null)
            {
                maChip = "N'" + cbochip.SelectedValue.ToString() + "'";
            }
            else
            {
                maChip = "NULL";
            }

            sql = "UPDATE tblMayTinh SET  TenMay=N'" + txttenmay.Text.Trim().ToString() +"',GhiChu=N'" + txtghichu.Text.Trim().ToString() + "',MaOCung= "+maOCung+" , MaDungLuong=" + maDungLuong+",MaPM=N'" + cbophongmay.SelectedValue.ToString() + "',MaRam="+maRam+",MaTocDo="+maTocDo+",MaManHinh="+maManHinh+",MaBanPhim="+maBanPhim+", MaChuot="+maChuot+",MaCoManHinh="+maCoManHinh+",MaODia="+maODia+",MaChip="+maChip+" WHERE MaMay=N'" + txtmamay.Text + "'";
            functions.RunSql(sql);

            sql = "UPDATE tblPhongMay SET SoMay = SoMay + 1 WHERE MaPM = N'" + cbophongmay.SelectedValue.ToString() + "'";
            functions.RunSql(sql);
            // Cập nhật số máy của phòng máy cũ
            sql = "UPDATE tblPhongMay SET SoMay = SoMay - 1 WHERE MaPM = N'" + mapmtruoc + "'";
            functions.RunSql(sql);
            //Cập nhập số máy của phòng máy mới
            sql = "UPDATE tblPhongMay SET SoMay = SoMay + 1 WHERE MaPM = N'" + cbophongmay.SelectedValue.ToString() + "'";
            functions.RunSql(sql);

            Load_DataGridView();
            ResetValues();

            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (qlmt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtmamay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string maPM = functions.GetFieldValues("SELECT MaPM FROM tblMayTinh WHERE MaMay = N'" + txtmamay.Text + "'");

                sql = "DELETE tblMayTinh WHERE MaMay=N'" + txtmamay.Text + "'";
                functions.RunSqlDel(sql);

                // Cập nhật số máy của phòng máy vừa xóa máy tính
                sql = "UPDATE tblPhongMay SET SoMay = SoMay - 1 WHERE MaPM = N'" + maPM + "'";
                functions.RunSql(sql);

                Load_DataGridView();
                ResetValues();
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimkiem.Focus();
                return;
            }

            sql = "select MaMay,TenMay,MaPM,MaOCung,MaDungLuong,MaRam,MaTocDo,MaManHinh,MaBanPhim,MaChuot,MaCoManHinh,MaODia,MaChip,GhiChu from tblMayTinh where 1=1";

            string keyword = txtTimkiem.Text.Trim();

            if (txtTimkiem.Text != "")
            {
                sql += " AND (MaMay LIKE N'%" + keyword + "%' OR TenMay LIKE N'%" + keyword + "%' )";
            }

            qlmt = functions.GetDataToTable(sql);
            if (qlmt.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + qlmt.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dataGridView1.DataSource = qlmt;
            ResetValues();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmamay.Enabled = false;
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            ResetValues();
            btnThem.Enabled = true;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaPM, COUNT(*) AS SoMay FROM tblMayTinh GROUP BY MaPM";
            qlmt = functions.GetDataToTable(sql);

            foreach (DataRow row in qlmt.Rows)
            {
                string maPM = row["MaPM"].ToString();
                int somay = Convert.ToInt32(row["SoMay"]);
                sql = "UPDATE tblPhongMay SET SoMay = " + somay + " WHERE MaPM = N'" + maPM + "'";
                functions.RunSql(sql);
            }

            MessageBox.Show("Cập nhật số máy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maPM = cboloc.SelectedValue.ToString();

            string sql = "SELECT MaMay, TenMay, MaPM, MaOCung, MaDungLuong, MaRam, MaTocDo, MaManHinh, MaBanPhim, MaChuot, MaCoManHinh, MaODia, MaChip, GhiChu FROM tblMayTinh WHERE MaPM = '" + maPM + "'";

            qlmt = functions.GetDataToTable(sql);
            dataGridView1.DataSource = qlmt;
        }
    }
}
