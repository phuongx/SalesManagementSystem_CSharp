using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangTH
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        public void frmLogin()
        {
            Form frm = new frmLogin();
            frm.ShowDialog();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmLogin();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn thoát ứng dụng?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }
        void XemDanhMuc(int intDanhMuc)
        {
            Form frm = new frmXDN();
            
            frm.Text = intDanhMuc.ToString();
            frm.ShowDialog();
        }

        private void danhMụcThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        private void danhMụcLoạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }

        private void danhMụcHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(6);
        }

        private void danhMụcChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(7);
        }

        private void danhMụcKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(8);
        }

        private void danhMụcSảnPhẩmTrongKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(9);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDThanhPho();
            frm.Text = "Quản lý Danh mục Thành Phố";
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDNhanVien();
            frm.Text = "Quản lý Danh mục Nhân viên";
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDKhachHang();
            frm.Text = "Quản lý Danh mục Khách hàng";
            frm.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDLoaiHang();
            frm.Text = "Quản lý Danh mục Khách hàng";
            frm.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDKho();
            frm.Text = "Quản lý Danh mục Khách hàng";
            frm.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDSanPham();
            frm.Text = "Quản lý Danh mục Sản phẩm";
            frm.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDHoaDon();
            frm.Text = "Quản lý Danh mục Hóa đơn";
            frm.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDChiTietHD();
            frm.Text = "Quản lý Danh mục Chi tiết hóa đơn";
            frm.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form frm = new frmDMDSanPham_Kho();
            frm.Text = "Quản lý Danh mục Sản phẩm trong Kho";
            frm.ShowDialog();
        }

        private void kháchHàngTheoThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmKHtheoTP();
            frm.Text = "Quản lý Khách hàng theo Thành phố";
            frm.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmHDtheoKH();
            frm.Text = "Quản lý Hóa đơn theo Khách hàng";
            frm.ShowDialog();
        }

        private void quảnLýDanhMụcTheoNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmCTHDtheoSP();
            frm.Text = "Quản lý Chi tiết hóa đơn theo Khách hàng";
            frm.ShowDialog();
        }

        private void hóaĐơnTheoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmHDtheoNV();
            frm.Text = "Quản lý Hóa đơn theo Nhân viên";
            frm.ShowDialog();
        }

        private void chiTiếtHóaĐơnTheoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmCTHDtheoHD();
            frm.Text = "Quản lý Chi tiet Hóa đơn theo Hóa đơn";
            frm.ShowDialog();
        }

        private void sảnPhẩmTheoLoạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmSPtheoLoai();
            frm.Text = "Quản lý Sản phẩm theo Loại hàng hóa";
            frm.ShowDialog();
        }

        private void sảnPhẩmTheoKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmSPtheoKho();
            frm.Text = "Quản lý Sản phẩm theo Kho";
            frm.ShowDialog();
        }

        private void khoTheoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmKhotheoSP();
            frm.Text = "Quản lý Kho theo Sản phẩm";
            frm.ShowDialog();
        }

        private void quảnLýĐaCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDaCap1();
            frm.Text = "Quản lý Đa cấp Khách hàng - Hóa đơn";
            frm.ShowDialog();
        }

        private void quanrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDaCap2();
            frm.Text = "Quản lý Đa cấp Sản phẩm - Kho";
            frm.ShowDialog();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTacGia();
            frm.Text = "Về Tác giả";
            frm.ShowDialog();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được xây dựng.");
        }

        private void loạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được xây dựng.");
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được xây dựng.");
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được xây dựng.");
        }
    }
}
