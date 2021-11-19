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
    public partial class frmCTHDtheoSP : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daCTHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtCTHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        void LoadData()
        {
            try
            {

                (dgv.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgv.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgv.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
                // Vận chuyển dữ liệu lên DataTable dtHD
                daHoaDon = new SqlDataAdapter("SELECT * FROM HOADON", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                (dgv.Columns["MaHD"] as DataGridViewComboBoxColumn).DataSource = dtHoaDon;
                (dgv.Columns["MaHD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
                (dgv.Columns["MaHD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";
                // Vận chuyển dữ liệu lên DataTable dtCTHD
                daCTHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoadon where MaSP = '" + this.cbMaSP.SelectedValue.ToString() + "'", conn);
                dtCTHoaDon = new DataTable();
                dtCTHoaDon.Clear();
                daCTHoaDon.Fill(dtCTHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgv.DataSource = dtCTHoaDon;
                txtTong.Text = Convert.ToString(Convert.ToInt32(dgv.Rows.Count.ToString()) - 1);
                // Thay đổi độ rộng cột
                dgv.AutoResizeColumns();

                this.btnTroVe.Enabled = true;

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table KHACHHANG.");
            }
        }
        public frmCTHDtheoSP()
        {
            InitializeComponent();
        }

        private void frmNhomHDtheoSP_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            // Vận chuyển dữ liệu lên DataTable dtSP
            daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
            dtSanPham = new DataTable();
            dtSanPham.Clear();
            daSanPham.Fill(dtSanPham);

            // Đưa dữ liệu lên combobox
            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "TenSP";
            this.cbMaSP.ValueMember = "MaSP";
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            LoadData();
        }

        private void frmNhomHDtheoSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            dtSanPham.Dispose();
            dtCTHoaDon.Dispose();
            dtCTHoaDon = null;
            dtSanPham = null;
           
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
    }
}
