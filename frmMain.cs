using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom7_Project_QLPM
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //sidebar
        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 0)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    pnHome.Width = sidebar.Width;
                    pnPhongMay.Width = sidebar.Width;
                    pnLichTH.Width = sidebar.Width;
                    menuQuanLy.Width = sidebar.Width;
                    menuCaNhan.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 130
                    )
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    pnHome.Width = sidebar.Width;
                    pnPhongMay.Width = sidebar.Width;
                    pnLichTH.Width = sidebar.Width;
                    menuQuanLy.Width = sidebar.Width;
                    menuCaNhan.Width = sidebar.Width;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        //MenuquanLy
        bool menuExpand = false;
        private void menuTransition0_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuQuanLy.Height += 10;
                if (menuQuanLy.Height >= 280)
                {
                    menuTransition0.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuQuanLy.Height -= 10;
                if (menuQuanLy.Height <= 35)
                {
                    menuTransition0.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            menuTransition0.Start();
        }
        //MenuCaNhan
        bool menuExpand1 = false;

        private void menuTransition1_Tick(object sender, EventArgs e)
        {
            if (menuExpand1 == false)
            {
                menuCaNhan.Height += 10;
                if (menuCaNhan.Height >= 230)
                {
                    menuTransition1.Stop();
                    menuExpand1 = true;
                }
            }
            else
            {
                menuCaNhan.Height -= 10;
                if (menuCaNhan.Height <= 35)
                {
                    menuTransition1.Stop();
                    menuExpand1 = false;
                }
            }
        }
        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            menuTransition1.Start();
        }
        //open form
        //click
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmHome());
            label2.Text = btnHome.Text;
          
        }

        private void btnPhongMay_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmPhongMay());
            label2.Text = btnPhongMay.Text;
        }

        private void btnLichTH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmLichTH());
            label2.Text=btnLichTH.Text;
        }

        private void btnQLLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLLop());
            label2.Text=btnQLLop.Text; 
        }

        private void btnQLMon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLMon());
            label2.Text = btnQLMon.Text;
        }

        private void btnQLCa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLCa());
            label2.Text = btnQLCa.Text;
        }

        private void btnQLLichTH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLLichTH());
            label2.Text = btnQLLichTH.Text;
        }

        private void btnQLPhongMay_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLPhongMay());
            label2.Text = btnQLPhongMay.Text;
        }

        private void btnQLMayTinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLMayTinh());
            label2.Text = btnQLMayTinh.Text;
        }

        private void btnQLBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLBCSC());
            label2.Text = btnQLBaoCao.Text;
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.QLTaiKhoan());
            label2.Text = btnQLTaiKhoan.Text;
        }

        private void btnCaNhanLichTH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CaNhanLichTH());
            label2.Text = btnCaNhanLichTH.Text;
        }

        private void btnCaNhanBCSC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CaNhanBCSC());
            label2.Text = btnCaNhanBCSC.Text;
        }

        private void btnCaNhanTK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CaNhanToi());
            label2.Text = btnCaNhanTK.Text;
        }

        private void btnCaNhanCaiDat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CaNhanCaiDat());
            label2.Text = btnCaNhanCaiDat.Text;
        }
    }
}
