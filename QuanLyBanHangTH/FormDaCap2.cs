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
    public partial class frmDaCap2 : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtSP
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable dtLoai
        SqlDataAdapter daLoai = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtLoai = null;
        // Đối tượng đưa dữ liệu vào DataTable dtSP1
        SqlDataAdapter daSanPham1 = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham1 = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhoSP
        SqlDataAdapter daKhoSP = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhoSP = null;
        SqlDataAdapter daKho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKho = null;
        
        void LoadData()
        {
            try
            {

                (dgvSP.Columns["MaLoai"] as DataGridViewComboBoxColumn).DataSource = dtLoai;
                (dgvSP.Columns["MaLoai"] as DataGridViewComboBoxColumn).DisplayMember = "TenLoai";
                (dgvSP.Columns["MaLoai"] as DataGridViewComboBoxColumn).ValueMember = "MaLoai";
                // Vận chuyển dữ liệu lên DataTable dtSP
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham where MaLoai = '" + this.cbLoaiHang.SelectedValue.ToString() + "'", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên DataGridView 
                dgvSP.DataSource = dtSanPham;
                txtTongSP.Text = Convert.ToString(Convert.ToInt32(dgvSP.Rows.Count.ToString()) - 1);
                // Thay đổi độ rộng cột
                dgvSP.AutoResizeColumns();
                LoadData2();
                LoadData3();

                this.btnTroVe.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table KHACHHANG.");
            }
        }
        void LoadData2()
        {
            try
            {
                if (Convert.ToInt32(dgvSP.Rows.Count.ToString()) > 1)
                {
                    dgvSP.CurrentCell.Selected = true;
                    // Vận chuyển dữ liệu lên DataTable dt
                    daSanPham1 = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                    dtSanPham1 = new DataTable();
                    dtSanPham1.Clear();
                    daSanPham1.Fill(dtSanPham1);
                    (dgvKhoSP.Columns["Ma_SP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham1;
                    (dgvKhoSP.Columns["Ma_SP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                    (dgvKhoSP.Columns["Ma_SP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
                    // Vận chuyển dữ liệu lên DataTable dtSP
                    int r = dgvSP.CurrentCell.RowIndex;
                    String strMaSP = dgvSP.Rows[r].Cells[0].Value.ToString();
                    daKhoSP = new SqlDataAdapter("SELECT * FROM KhoSP where MaSP = '" +strMaSP + "'", conn);
                    dtKhoSP = new DataTable();
                    dtKhoSP.Clear();
                    daKhoSP.Fill(dtKhoSP);
                    // Đưa dữ liệu lên DataGridView 
                    dgvKhoSP.DataSource = dtKhoSP;
                    txtTongKS.Text = Convert.ToString(Convert.ToInt32(dgvKhoSP.Rows.Count.ToString()) - 1);

                }
                else
                {
                    daKhoSP = new SqlDataAdapter("SELECT * FROM KhoSP where MaSP = ' '", conn);
                    dtKhoSP = new DataTable();
                    dtKhoSP.Clear();
                    daKhoSP.Fill(dtKhoSP);
                    // Đưa dữ liệu lên DataGridView 
                    dgvKhoSP.DataSource = dtKhoSP;
                    txtTongKS.Text = Convert.ToString(Convert.ToInt32(dgvKhoSP.Rows.Count.ToString()) - 1);
                }
                dgvKhoSP.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table KhoSP.");
            }
        }
        void LoadData3()
        {
            try
            {
                if (Convert.ToInt32(dgvSP.Rows.Count.ToString()) > 1 && Convert.ToInt32(dgvKhoSP.Rows.Count.ToString()) > 1)
                {

                    dgvKhoSP.CurrentCell.Selected = true;
                    // Vận chuyển dữ liệu lên DataTable dt
                    daKho = new SqlDataAdapter("SELECT * FROM Kho", conn);
                    dtKho = new DataTable();
                    dtKho.Clear();
                    daKho.Fill(dtKho);
                    (dgvKho.Columns["MaK"] as DataGridViewComboBoxColumn).DataSource = dtKho;
                    (dgvKho.Columns["MaK"] as DataGridViewComboBoxColumn).DisplayMember = "MaKho";
                    (dgvKho.Columns["MaK"] as DataGridViewComboBoxColumn).ValueMember = "MaKho";

                    int rh = dgvKhoSP.CurrentCell.RowIndex;
                    // Chuyển thông tin lên panel
                    String strMaKho = dgvKhoSP.Rows[rh].Cells[0].Value.ToString();
                    daKho = new SqlDataAdapter("SELECT * FROM Kho where MaKho='"+strMaKho+"'", conn);
                    dtKho = new DataTable();
                    dtKho.Clear();
                    daKho.Fill(dtKho);
                    // Đưa dữ liệu lên DataGridView 
                    dgvKho.DataSource = dtKho;
                }
                else
                {
                    daKho = new SqlDataAdapter("SELECT * FROM Kho where MaKho=' '", conn);
                    dtKho = new DataTable();
                    dtKho.Clear();
                    daKho.Fill(dtKho);
                    // Đưa dữ liệu lên DataGridView 
                    dgvKho.DataSource = dtKho;

                }
                dgvKho.AutoResizeColumns();

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table Kho.");
            }
        }
        public frmDaCap2()
        {
            InitializeComponent();
        }

        private void frmDaCap2_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            // Vận chuyển dữ liệu lên DataTable dtTP
            daLoai = new SqlDataAdapter("SELECT * FROM LoaiHang", conn);
            dtLoai = new DataTable();
            dtLoai.Clear();
            daLoai.Fill(dtLoai);
            // Đưa dữ liệu lên combobox
            this.cbLoaiHang.DataSource = dtLoai;
            this.cbLoaiHang.DisplayMember = "TenLoai";
            this.cbLoaiHang.ValueMember = "MaLoai";
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDaCap2_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKho.Dispose();
            dtKhoSP.Dispose();
            dtLoai.Dispose();
            dtSanPham.Dispose();
            dtSanPham1.Dispose();
            dtSanPham1 = null;
            dtSanPham = null;
            dtLoai = null;
            dtKhoSP = null;
            dtKho = null;
            conn = null;
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData2();
            LoadData3();
        }

        private void dgvKhoSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData3();
        }
    }
}
