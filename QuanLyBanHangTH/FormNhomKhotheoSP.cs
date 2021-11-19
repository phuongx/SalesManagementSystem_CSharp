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
    public partial class frmKhotheoSP : Form
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
        SqlDataAdapter daKhoSP = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhoSP = null;
        void LoadData()
        {
            try
            {
                (dgv.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgv.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgv.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
                // Vận chuyển dữ liệu lên DataTable dtSP
                daKhoSP = new SqlDataAdapter("SELECT * FROM KhoSP where MaSP = '" + this.cbSP.SelectedValue.ToString() + "'", conn);
                dtKhoSP = new DataTable();
                dtKhoSP.Clear();
                daKhoSP.Fill(dtKhoSP);
                // Đưa dữ liệu lên DataGridView 
                dgv.DataSource = dtKhoSP;
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
        public frmKhotheoSP()
        {
            InitializeComponent();
        }

        private void frmKhotheoSP_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            // Vận chuyển dữ liệu lên DataTable dt
            daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
            dtSanPham = new DataTable();
            dtSanPham.Clear();
            daSanPham.Fill(dtSanPham);
            // Đưa dữ liệu lên combobox
            this.cbSP.DataSource = dtSanPham;
            this.cbSP.DisplayMember = "TenSP";
            this.cbSP.ValueMember = "MaSP";
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            LoadData();
        }

        private void frmKhotheoSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhoSP.Dispose();
            dtSanPham.Dispose();
            dtSanPham = null;
            dtKhoSP = null;
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
