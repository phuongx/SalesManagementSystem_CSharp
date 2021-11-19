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
    public partial class frmDMDSanPham_Kho : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daKho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKho = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daKhoSP = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhoSP = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable 
                daKho = new SqlDataAdapter("SELECT * FROM KHO", conn);
                dtKho = new DataTable();
                dtKho.Clear();
                daKho.Fill(dtKho);
                // Vận chuyển dữ liệu lên DataTable 
                daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);

                // Đưa dữ liệu lên ComboBox trong DataGridView 
                (dgvSPKho.Columns["MaKho"] as
                 DataGridViewComboBoxColumn).DataSource = dtKho;
                (dgvSPKho.Columns["MaKho"] as
                DataGridViewComboBoxColumn).DisplayMember = "MaKho";
                (dgvSPKho.Columns["MaKho"] as
                DataGridViewComboBoxColumn).ValueMember = "MaKho";
                (dgvSPKho.Columns["MaSP"] as
                DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvSPKho.Columns["MaSP"] as
                DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvSPKho.Columns["MaSP"] as
                DataGridViewComboBoxColumn).ValueMember = "MaSP";

                // Vận chuyển dữ liệu lên DataTable dtKH

                daKhoSP = new SqlDataAdapter("SELECT * FROM KhoSP", conn);
                dtKhoSP = new DataTable();
                dtKhoSP.Clear();
                daKhoSP.Fill(dtKhoSP);
                // Đưa dữ liệu lên DataGridView 
                dgvSPKho.DataSource = dtKhoSP;
                // Thay đổi độ rộng cột
                dgvSPKho.AutoResizeColumns();
                //xoa trong
                this.txtSoLuong.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = false;
                this.btnTroVe.Enabled = true;
                this.cbMaKho.Enabled = true;
                this.cbMaSP.Enabled = true;
                // Đưa dữ liệu lên combobox
                this.cbMaKho.DataSource = dtKho;
                this.cbMaKho.DisplayMember = "MaKho";
                this.cbMaKho.ValueMember = "MaKho";
                this.cbMaSP.DataSource = dtSanPham;
                this.cbMaSP.DisplayMember = "MaSP";
                this.cbMaSP.ValueMember = "MaSP";
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table CHITIETHOADON.");
            }
        }
        public frmDMDSanPham_Kho()
        {
            InitializeComponent();
        }

        private void frmDMDSanPham_Kho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDMDSanPham_Kho_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKho.Dispose();
            dtKhoSP.Dispose();
            dtSanPham.Dispose();
            dtKho = null;
            dtKhoSP = null;
            dtSanPham = null;
            conn = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtSoLuong.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.cbMaKho.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên combobox
            this.cbMaKho.DataSource = dtKho;
            this.cbMaKho.DisplayMember = "MaKho";
            this.cbMaKho.ValueMember = "MaKho";
            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "MaSP";
            this.cbMaSP.ValueMember = "MaSP";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvSPKho.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.cbMaKho.SelectedValue = dgvSPKho.Rows[r].Cells[0].Value.ToString();
            this.cbMaSP.SelectedValue = dgvSPKho.Rows[r].Cells[1].Value.ToString();
            this.txtSoLuong.Text = dgvSPKho.Rows[r].Cells[2].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.cbMaKho.Enabled = false;
            this.cbMaSP.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtSoLuong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into KhoSP Values(" + "'" +
                    this.cbMaKho.SelectedValue.ToString() + "','" +
                    this.cbMaSP.SelectedValue.ToString() + "'," +
                    Convert.ToInt32(this.txtSoLuong.Text.ToString()) + ")");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Thêm dữ liệu thành công!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Không thể thêm dữ liệu.");
                }
            }
            if (!Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvSPKho.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAKho = dgvSPKho.Rows[r].Cells[0].Value.ToString();
                    string strMASP = dgvSPKho.Rows[r].Cells[1].Value.ToString();
                    MessageBox.Show(strMAKho + "   " +strMASP);
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update KhoSP Set SoLuongTon = " +
                    Convert.ToInt32(this.txtSoLuong.Text.ToString()) + " Where MaKho = '" +
                    strMAKho + "' and MaSP = '" + strMASP + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Dữ liệu không thể sửa.");
                }
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
