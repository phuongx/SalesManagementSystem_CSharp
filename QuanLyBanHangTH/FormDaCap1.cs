using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHangTH
{
    public partial class frmDaCap1 : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daKhachHang1 = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang1 = null;
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        SqlDataAdapter daHoaDon1 = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon1 = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        SqlDataAdapter daCTHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtCTHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        void LoadData()
        {
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            (dgvKH.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DataSource = dtThanhPho;
            (dgvKH.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DisplayMember = "TenThanhPho";
            (dgvKH.Columns["ThanhPho"] as DataGridViewComboBoxColumn).ValueMember = "ThanhPho";
            // Vận chuyển dữ liệu lên DataTable dtKH
            daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG where ThanhPho = '" + this.cbThanhPho.SelectedValue.ToString() + "'", conn);
            dtKhachHang = new DataTable();
            dtKhachHang.Clear();
            daKhachHang.Fill(dtKhachHang);
            // Đưa dữ liệu lên DataGridView 
            dgvKH.DataSource = dtKhachHang;
            txtTongKH.Text = Convert.ToString(Convert.ToInt32(dgvKH.Rows.Count.ToString()) - 1);
            // Thay đổi độ rộng cột
            dgvKH.AutoResizeColumns();
            LoadData2();
            LoadData3();
        }
        void LoadData2()
        {
            //DGVHD
            if (Convert.ToInt32(dgvKH.Rows.Count.ToString()) > 1)
            {
                dgvKH.CurrentCell.Selected = true;
                daKhachHang1 = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                dtKhachHang1 = new DataTable();
                dtKhachHang1.Clear();
                daKhachHang1.Fill(dtKhachHang1);
                (dgvHD.Columns["Ma_KH"] as DataGridViewComboBoxColumn).DataSource = dtKhachHang1;
                (dgvHD.Columns["Ma_KH"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
                (dgvHD.Columns["Ma_KH"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";
                // Vận chuyển dữ liệu lên DataTable dtNV
                daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên DataGridView 
                (dgvHD.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHD.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "Ten";
                (dgvHD.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";

                // Vận chuyển dữ liệu lên DataTable dtKH
                int r = dgvKH.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                String MaKH = dgvKH.Rows[r].Cells[0].Value.ToString();
                daHoaDon = new SqlDataAdapter("SELECT * FROM Hoadon where MaKH = '" + MaKH + "'", conn);
                //daHoaDon = new SqlDataAdapter("SELECT * FROM Hoadon ", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvHD.DataSource = dtHoaDon;
                txtTongHD.Text = Convert.ToString(Convert.ToInt32(dgvHD.Rows.Count.ToString()) - 1);
                // Thay đổi độ rộng cột
                dgvHD.AutoResizeColumns();
            } else
            {

                daHoaDon = new SqlDataAdapter("SELECT * FROM Hoadon where MaKH = ' '", conn);
                //daHoaDon = new SqlDataAdapter("SELECT * FROM Hoadon ", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvHD.DataSource = dtHoaDon;
                txtTongHD.Text = Convert.ToString(Convert.ToInt32(dgvHD.Rows.Count.ToString()) - 1);
                // Thay đổi độ rộng cột
                dgvHD.AutoResizeColumns();
            }
        }
        void LoadData3()
        {
            //DGVCTHD
            
            if (Convert.ToInt32(dgvHD.Rows.Count.ToString()) > 1 && Convert.ToInt32(dgvKH.Rows.Count.ToString()) > 1)
            {
                dgvHD.CurrentCell.Selected = true;
                int rh = dgvHD.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                String MaHD = dgvHD.Rows[rh].Cells[0].Value.ToString();
                daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                (dgvCTHD.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvCTHD.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvCTHD.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
                daHoaDon1 = new SqlDataAdapter("SELECT * FROM HOADON", conn);
                dtHoaDon1 = new DataTable();
                dtHoaDon1.Clear();
                daHoaDon1.Fill(dtHoaDon1);
                (dgvCTHD.Columns["Ma_HD"] as DataGridViewComboBoxColumn).DataSource = dtHoaDon1;
                (dgvCTHD.Columns["Ma_HD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
                (dgvCTHD.Columns["Ma_HD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";
                // Vận chuyển dữ liệu lên DataTable dtHD
                daCTHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoadon where MaHD = '" + MaHD + "'", conn);
                //daCTHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoadon", conn);
                dtCTHoaDon = new DataTable();
                dtCTHoaDon.Clear();
                daCTHoaDon.Fill(dtCTHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvCTHD.DataSource = dtCTHoaDon;
                txtTongCTHD.Text = Convert.ToString(Convert.ToInt32(dgvCTHD.Rows.Count.ToString()) - 1);

                dgvCTHD.AutoResizeColumns();

            } else
            {
                // Vận chuyển dữ liệu lên DataTable dtHD
                daCTHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoadon where MaHD = ' '", conn);
                //daCTHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoadon", conn);
                dtCTHoaDon = new DataTable();
                dtCTHoaDon.Clear();
                daCTHoaDon.Fill(dtCTHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvCTHD.DataSource = dtCTHoaDon;
                txtTongCTHD.Text = Convert.ToString(Convert.ToInt32(dgvCTHD.Rows.Count.ToString()) - 1);

                dgvCTHD.AutoResizeColumns();

            }
        }

        public frmDaCap1()
         {
            InitializeComponent();
         }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmDaCap1_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            //DGKH
            // Vận chuyển dữ liệu lên DataTable dtTP
            daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
            dtThanhPho = new DataTable();
            dtThanhPho.Clear();
            daThanhPho.Fill(dtThanhPho);
            // Đưa dữ liệu lên combobox
            this.cbThanhPho.DataSource = dtThanhPho;
            this.cbThanhPho.DisplayMember = "TenThanhPho";
            this.cbThanhPho.ValueMember = "ThanhPho";
            LoadData();
            
        }

        private void frmDaCap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            dtThanhPho = null;
            dtSanPham = null;
            dtNhanVien = null;
            dtKhachHang = null;
            dtHoaDon = null;
            dtCTHoaDon = null;
            dtKhachHang1 = null;
            dtHoaDon1 = null;
            conn = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            LoadData2();
            LoadData3();
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            LoadData3();
        }
    }
}
