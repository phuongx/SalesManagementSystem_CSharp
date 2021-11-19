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
    public partial class frmDMDHoaDon : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Đối tượng đưa dữ liệu vào DataTable 
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void Reset()
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaHD.ResetText();
            this.txtNgayLapHD.ResetText();
            this.txtNgayNhanHang.ResetText();
        }
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable 
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Vận chuyển dữ liệu lên DataTable 
                daNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);

                // Đưa dữ liệu lên ComboBox trong DataGridView 
                (dgvHOADON.Columns["MaKH"] as
                DataGridViewComboBoxColumn).DataSource = dtKhachHang;
                (dgvHOADON.Columns["MaKH"] as
                DataGridViewComboBoxColumn).DisplayMember = "TenCty";
                (dgvHOADON.Columns["MaKH"] as
                DataGridViewComboBoxColumn).ValueMember = "MaKH";
                (dgvHOADON.Columns["MaNV"] as
                DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHOADON.Columns["MaNV"] as
                DataGridViewComboBoxColumn).DisplayMember =  "Ten";
                (dgvHOADON.Columns["MaNV"] as
                DataGridViewComboBoxColumn).ValueMember = "MaNV";

                // Vận chuyển dữ liệu lên DataTable dtKH

                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvHOADON.DataSource = dtHoaDon;
                // Thay đổi độ rộng cột
                dgvHOADON.AutoResizeColumns();
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
                this.txtMaHD.Enabled = true;
                // Đưa dữ liệu lên combobox
                this.cbMaKH.DataSource = dtKhachHang;
                this.cbMaKH.DisplayMember = "TenCty";
                this.cbMaKH.ValueMember = "MaKH";
                this.cbMaNV.DataSource = dtNhanVien;
                this.cbMaNV.DisplayMember = "MaNV";
                this.cbMaNV.ValueMember = "MaNV";
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table HOADON.");
            }
        }
        public frmDMDHoaDon()
        {
            InitializeComponent();
        }

        private void frmDMDHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDMDHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtHoaDon.Dispose();
            dtKhachHang.Dispose();
            dtNhanVien.Dispose();
            dtHoaDon = null;
            dtKhachHang = null;
            dtNhanVien = null;
            conn = null;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
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
            this.txtMaHD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên combobox
            this.cbMaKH.DataSource = dtKhachHang;
            this.cbMaKH.DisplayMember = "TenCty";
            this.cbMaKH.ValueMember = "MaKH";
            this.cbMaNV.DataSource = dtNhanVien;
            this.cbMaNV.DisplayMember = "MaNV";
            this.cbMaNV.ValueMember = "MaNV";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvHOADON.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaHD.Text = dgvHOADON.Rows[r].Cells[0].Value.ToString();
            this.cbMaKH.SelectedValue = dgvHOADON.Rows[r].Cells[1].Value.ToString();
            this.cbMaNV.SelectedValue = dgvHOADON.Rows[r].Cells[2].Value.ToString();
            this.txtNgayLapHD.Text = dgvHOADON.Rows[r].Cells[3].Value.ToString();
            this.txtNgayNhanHang.Text = dgvHOADON.Rows[r].Cells[4].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.txtMaHD.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.cbMaKH.Focus();
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
                    cmd.CommandText = System.String.Concat("Insert Into HoaDon Values(" + "'" +
                    this.txtMaHD.Text.ToString() + "','" +
                    this.cbMaKH.SelectedValue.ToString() + "','" +
                    this.cbMaNV.SelectedValue.ToString() + "','" +
                    this.txtNgayLapHD.Text.ToString() + "','" +
                    this.txtNgayNhanHang.Text.ToString() + "')");
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
                    int r = dgvHOADON.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAHD = dgvHOADON.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update HoaDon Set MaKH = '" +
                    this.cbMaKH.SelectedValue.ToString() + "', MaNV = '" +
                    this.cbMaNV.SelectedValue.ToString() + "', NgayLapHD = '" +
                    this.txtNgayLapHD.Text.ToString() + "', NgayNhanHang ='" +
                    this.txtNgayNhanHang.Text.ToString() + "' Where MaHD = '" + strMAHD + "'");
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
                int r = dgvHOADON.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAHD = dgvHOADON.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From HoaDon Where MaHD = '" + strMAHD + "'");
                cmd.CommandType = CommandType.Text;
                //ktra
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa hóa đơn " + strMAHD + "?", "Trả lời",
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
    }
}
