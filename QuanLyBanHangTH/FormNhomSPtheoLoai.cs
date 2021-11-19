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
    public partial class frmSPtheoLoai : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daLoai = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtLoai = null;
        void LoadData()
        {
            try
            {

                (dgv.Columns["MaLoai"] as DataGridViewComboBoxColumn).DataSource = dtLoai;
                (dgv.Columns["MaLoai"] as DataGridViewComboBoxColumn).DisplayMember = "TenLoai";
                (dgv.Columns["MaLoai"] as DataGridViewComboBoxColumn).ValueMember = "MaLoai";
                // Vận chuyển dữ liệu lên DataTable dtSP
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham where MaLoai = '" + this.cbLoai.SelectedValue.ToString() + "'", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên DataGridView 
                dgv.DataSource = dtSanPham;
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
        public frmSPtheoLoai()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmSPtheoLoai_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            // Vận chuyển dữ liệu lên DataTable dtTP
            daLoai = new SqlDataAdapter("SELECT * FROM LoaiHang", conn);
            dtLoai = new DataTable();
            dtLoai.Clear();
            daLoai.Fill(dtLoai);
            // Đưa dữ liệu lên combobox
            this.cbLoai.DataSource = dtLoai;
            this.cbLoai.DisplayMember = "TenLoai";
            this.cbLoai.ValueMember = "MaLoai";
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmSPtheoLoai_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtSanPham.Dispose();
            dtLoai.Dispose();
            dtSanPham = null;
            dtLoai = null;
            conn = null;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
