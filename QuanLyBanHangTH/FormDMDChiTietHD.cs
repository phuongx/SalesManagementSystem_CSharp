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
    public partial class frmDMDChiTietHD : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daChiTietHD = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHD = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable 
                daHoaDon = new SqlDataAdapter("SELECT * FROM HOADON", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Vận chuyển dữ liệu lên DataTable 
                daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);

                // Đưa dữ liệu lên ComboBox trong DataGridView 
               (dgvCTHD.Columns["MaHD"] as
                DataGridViewComboBoxColumn).DataSource = dtHoaDon;
                (dgvCTHD.Columns["MaHD"] as
                DataGridViewComboBoxColumn).DisplayMember = "MaHD";
                (dgvCTHD.Columns["MaHD"] as
                DataGridViewComboBoxColumn).ValueMember = "MaHD";
                (dgvCTHD.Columns["MaSP"] as
                DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvCTHD.Columns["MaSP"] as
                DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvCTHD.Columns["MaSP"] as
                DataGridViewComboBoxColumn).ValueMember = "MaSP";
                
                // Vận chuyển dữ liệu lên DataTable dtKH

                daChiTietHD = new SqlDataAdapter("SELECT * FROM CHITIETHOADON", conn);
                dtChiTietHD = new DataTable();
                dtChiTietHD.Clear();
                daChiTietHD.Fill(dtChiTietHD);
                // Đưa dữ liệu lên DataGridView 
                dgvCTHD.DataSource = dtChiTietHD;
                // Thay đổi độ rộng cột
                dgvCTHD.AutoResizeColumns();
                //xoa trong
                this.txtSoLuong.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                this.cbMaHD.Enabled = true;
                this.cbMaSP.Enabled = true;
                // Đưa dữ liệu lên combobox
                this.cbMaHD.DataSource = dtHoaDon;
                this.cbMaHD.DisplayMember = "MaHD";
                this.cbMaHD.ValueMember = "MaHD";
                this.cbMaSP.DataSource = dtSanPham;
                this.cbMaSP.DisplayMember = "MaSP";
                this.cbMaSP.ValueMember = "MaSP";
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table CHITIETHOADON.");
            }
        }
        public frmDMDChiTietHD()
        {
            InitializeComponent();
        }

        private void frmDMDChiTietHD_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDMDChiTietHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtChiTietHD.Dispose();
            dtHoaDon.Dispose();
            dtSanPham.Dispose();
            dtChiTietHD = null;
            dtHoaDon = null;
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
            this.cbMaHD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên combobox
            this.cbMaHD.DataSource = dtHoaDon;
            this.cbMaHD.DisplayMember = "MaHD";
            this.cbMaHD.ValueMember = "MaHD";
            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "MaSP";
            this.cbMaSP.ValueMember = "MaSP";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvCTHD.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.cbMaHD.SelectedValue = dgvCTHD.Rows[r].Cells[0].Value.ToString();
            this.cbMaSP.SelectedValue = dgvCTHD.Rows[r].Cells[1].Value.ToString();
            this.txtSoLuong.Text = dgvCTHD.Rows[r].Cells[2].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.cbMaHD.Enabled = false;
            this.cbMaSP.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtSoLuong.Focus();
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
                int r = dgvCTHD.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAHD = dgvCTHD.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From ChiTietHoaDon Where MaHD = '" + strMAHD + "'");
                cmd.CommandType = CommandType.Text;
                //ktra
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa chi tiết hóa đơn " + strMAHD + "?", "Trả lời",
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
                    cmd.CommandText = System.String.Concat("Insert Into ChiTietHoaDon Values(" + "'" +
                    this.cbMaHD.SelectedValue.ToString() + "','" +
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
                    int r = dgvCTHD.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAHD = dgvCTHD.Rows[r].Cells[0].Value.ToString();
                    string strMASP = dgvCTHD.Rows[r].Cells[1].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update ChiTietHoaDon Set SoLuong = " +
                    Convert.ToInt32(this.txtSoLuong.Text.ToString()) + " Where MaHD = '" + 
                    strMAHD + "' and MaSP = '" + strMASP + "'");
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            LoadData();
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
