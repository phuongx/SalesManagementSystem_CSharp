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
    
    public partial class frmDMDNhanVien : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên DataGridView 
                dgvNHANVIEN.DataSource = dtNhanVien;
                // Thay đổi độ rộng cột
                dgvNHANVIEN.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtMaNV.ResetText();
                this.txtHoLot.ResetText();
                this.txtTen.ResetText();
                this.txtDienThoai.ResetText();
                this.txtNgayNV.ResetText();
                this.txtDiaChi.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                this.txtMaNV.Enabled = true;
                this.txtHoLot.Enabled = true;
                this.txtTen.Enabled = true;
                this.chkNu.Enabled = true;
                this.txtNgayNV.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table SINHVIEN.");
            }
        }
        public frmDMDNhanVien()
        {
            InitializeComponent();
        }

        private void frmDMDNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDMDNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtNhanVien.Dispose();
            dtNhanVien = null;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoLot.ResetText();
            this.txtTen.ResetText();
            this.txtDienThoai.ResetText();
            this.txtNgayNV.ResetText();
            this.txtDiaChi.ResetText();
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
            this.txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvNHANVIEN.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNV.Text = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
            this.txtHoLot.Text = dgvNHANVIEN.Rows[r].Cells[1].Value.ToString();
            this.txtTen.Text = dgvNHANVIEN.Rows[r].Cells[2].Value.ToString();
            this.txtNgayNV.Text = dgvNHANVIEN.Rows[r].Cells[4].Value.ToString();
            this.txtDiaChi.Text = dgvNHANVIEN.Rows[r].Cells[5].Value.ToString();
            this.txtDienThoai.Text = dgvNHANVIEN.Rows[r].Cells[6].Value.ToString();
            if (dgvNHANVIEN.Rows[r].Cells[3].Value.ToString().Equals("1"))
            {
                this.chkNu.Checked = true;
            }
            
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.txtMaNV.Enabled = false;
            this.txtHoLot.Enabled = false;
            this.txtTen.Enabled = false;
            this.chkNu.Enabled = false;
            this.txtNgayNV.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtDienThoai.Focus();
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
                int r = dgvNHANVIEN.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaNV = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From NhanVien Where MaNV = '" + strMaNV + "'");
                cmd.CommandType = CommandType.Text;
                //ktra
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa nhân viên " + strMaNV + "?", "Trả lời",
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoLot.ResetText();
            this.txtTen.ResetText();
            this.txtDienThoai.ResetText();
            this.txtNgayNV.ResetText();
            this.txtDiaChi.ResetText();
            
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
                    
                    int Nu =1;
                    if (this.chkNu.Checked == false) Nu = 0;
                    cmd.CommandText = System.String.Concat("Insert Into NhanVien Values(" + "'" +
                    this.txtMaNV.Text.ToString() + "','" +
                    this.txtHoLot.Text.ToString() + "','" +
                    this.txtTen.Text.ToString() + "','" +
                    Nu + "','" +
                    this.txtNgayNV.Text.ToString() + "','" +
                    this.txtDiaChi.Text.ToString() + "','" +
                    this.txtDienThoai.Text.ToString() + "', null" + ")");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Thêm dữ liệu thành công!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Không thêm dữ liệu.");
                }
            }
            if (!Them)
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Thứ tự dòng hiện hành
                int r = dgvNHANVIEN.CurrentCell.RowIndex;
                // MaKH hiện hành
                String MaNV = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
                String DiaChi = dgvNHANVIEN.Rows[r].Cells[5].Value.ToString();
                String DienThoai  = dgvNHANVIEN.Rows[r].Cells[6].Value.ToString();
                
                // Câu lệnh SQL
                cmd.CommandText = System.String.Concat("Update NhanVien Set DienThoai = '" + this.txtDienThoai.Text.ToString() + "', DiaChi = '" + this.txtDiaChi.Text.ToString() + "'  Where MaNV = '" + MaNV + "'");
                // Cập nhật
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            // Đóng kết nối
            conn.Close();
        }
    }
}
