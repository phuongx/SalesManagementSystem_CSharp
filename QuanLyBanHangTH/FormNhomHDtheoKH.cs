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
    public partial class frmHDtheoKH : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        void LoadData()
        {
            try
            {
               
                (dgv.Columns["MaKH"] as  DataGridViewComboBoxColumn).DataSource = dtKhachHang;
                (dgv.Columns["MaKH"] as  DataGridViewComboBoxColumn).DisplayMember = "TenCty"; 
                (dgv.Columns["MaKH"] as  DataGridViewComboBoxColumn).ValueMember = "MaKH";
                // Vận chuyển dữ liệu lên DataTable dtNV
                daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên DataGridView 
                (dgv.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgv.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "Ten";
                (dgv.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";
                // Vận chuyển dữ liệu lên DataTable dtKH
                daHoaDon = new SqlDataAdapter("SELECT * FROM Hoadon where MaKH = '" + this.cbMaKH.SelectedValue.ToString() + "'", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgv.DataSource = dtHoaDon;
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
        public frmHDtheoKH()
        {
            InitializeComponent();
        }

        private void frmHDtheoKH_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            // Vận chuyển dữ liệu lên DataTable dtTP
            daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
            dtKhachHang = new DataTable();
            dtKhachHang.Clear();
            daKhachHang.Fill(dtKhachHang);

            // Đưa dữ liệu lên combobox
            this.cbMaKH.DataSource = dtKhachHang;
            this.cbMaKH.DisplayMember = "TenCty";
            this.cbMaKH.ValueMember = "MaKH";
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            LoadData();
        }

        private void frmHDtheoKH_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtNhanVien.Dispose();
            dtHoaDon.Dispose();
            dtHoaDon = null;
            dtNhanVien = null;
            dtKhachHang = null;
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
