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
    public partial class frmDMDSanPham : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daLoaiHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtLoaiHang = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable 
                daLoaiHang = new SqlDataAdapter("SELECT * FROM LOAIHANG", conn);
                dtLoaiHang = new DataTable();
                dtLoaiHang.Clear();
                daLoaiHang.Fill(dtLoaiHang);

                // Đưa dữ liệu lên ComboBox trong DataGridView 
                (dgvSANPHAM.Columns["MaLoai"] as
                DataGridViewComboBoxColumn).DataSource = dtLoaiHang;
                (dgvSANPHAM.Columns["MaLoai"] as
                DataGridViewComboBoxColumn).DisplayMember = "TenLoai";
                (dgvSANPHAM.Columns["MaLoai"] as
                DataGridViewComboBoxColumn).ValueMember = "MaLoai";
                // Vận chuyển dữ liệu lên DataTable dtKH

                daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên DataGridView 
                dgvSANPHAM.DataSource = dtSanPham;
                // Thay đổi độ rộng cột
                dgvSANPHAM.AutoResizeColumns();
                //xoa trong
                Reset();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                this.txtMaSP.Enabled = true;
                this.txtTenSP.Enabled = true;
                // Đưa dữ liệu lên combobox
                this.cbxLoaiHang.DataSource = dtLoaiHang;
                this.cbxLoaiHang.DisplayMember = "TenLoai";
                this.cbxLoaiHang.ValueMember = "MaLoai";
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table SANPHAM.");
            }
        }
        void Reset()
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDonViTinh.ResetText();
            this.txtDonGia.ResetText();
        }
        public frmDMDSanPham()
        {
            InitializeComponent();
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDMDSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDMDSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtSanPham.Dispose();
            dtSanPham = null;
            dtLoaiHang.Dispose();
            dtLoaiHang = null;
            // Hủy kết nối
            conn = null;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            Reset();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            Reset();
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
            this.txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cbxLoaiHang.DataSource = dtLoaiHang;
            this.cbxLoaiHang.DisplayMember = "TenLoai";
            this.cbxLoaiHang.ValueMember = "MaLoai";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvSANPHAM.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaSP.Text = dgvSANPHAM.Rows[r].Cells[0].Value.ToString();
            this.txtTenSP.Text = dgvSANPHAM.Rows[r].Cells[1].Value.ToString();
            this.cbxLoaiHang.SelectedValue = dgvSANPHAM.Rows[r].Cells[2].Value.ToString();
            this.txtDonViTinh.Text = dgvSANPHAM.Rows[r].Cells[3].Value.ToString();
            this.txtDonGia.Text = dgvSANPHAM.Rows[r].Cells[4].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.txtMaSP.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtTenSP.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvSANPHAM.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMASP = dgvSANPHAM.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From SANPHAM Where MaSP = '" + strMASP + "'");
                cmd.CommandType = CommandType.Text;
                //ktra
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa sản phẩm " + strMASP + "?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi != DialogResult.OK)
                {
                    LoadData();
                    return;
                }
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Xóa dữ liệu thành công!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Dữ liệu không thể xóa.");
            }
            // Đóng kết nối
            conn.Close();
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
                    cmd.CommandText = System.String.Concat("Insert Into SanPham Values(" + "'" +
                    this.txtMaSP.Text.ToString() + "','" +
                    this.txtTenSP.Text.ToString() + "','" +
                    this.cbxLoaiHang.SelectedValue.ToString() + "','" +
                    this.txtDonViTinh.Text.ToString() + "','" +
                    Convert.ToInt32(this.txtDonGia.Text.ToString()) + "',null)");
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
                    int r = dgvSANPHAM.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMASP = dgvSANPHAM.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update SanPham Set TenSP = '" + 
                    this.txtTenSP.Text.ToString() + "', MaLoai = '" +
                    this.cbxLoaiHang.SelectedValue.ToString() + "', DonGia = '" +
                    Convert.ToInt32(this.txtDonGia.Text.ToString()) + "', DonViTinh ='" +
                    this.txtDonViTinh.Text.ToString() + "' Where MaSP = '" + strMASP + "'");
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
    }
}
