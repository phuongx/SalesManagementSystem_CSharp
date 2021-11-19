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
    public partial class frmDMDLoaiHang : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daLoaiHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtLoaiHang = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daLoaiHang = new SqlDataAdapter("SELECT * FROM LOAIHANG", conn);
                dtLoaiHang = new DataTable();
                dtLoaiHang.Clear();
                daLoaiHang.Fill(dtLoaiHang);
                // Đưa dữ liệu lên DataGridView 
                dgvLOAIHANG.DataSource = dtLoaiHang;
                // Thay đổi độ rộng cột
                dgvLOAIHANG.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtMaLoai.ResetText();
                this.txtTenLoai.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                this.txtMaLoai.Enabled = true;
                this.txtTenLoai.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table LOAIHANG.");
            }
        }
        public frmDMDLoaiHang()
        {
            InitializeComponent();
        }

        private void frmDMDLoaiHang_Load(object sender, EventArgs e)
        {
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

        private void frmDMDLoaiHang_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Giải phóng tài nguyên
            dtLoaiHang.Dispose();
            dtLoaiHang = null;
            // Hủy kết nối
            conn = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaLoai.ResetText();
            this.txtTenLoai.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtThanhPho
            this.txtMaLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvLOAIHANG.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaLoai.Text =
            dgvLOAIHANG.Rows[r].Cells[0].Value.ToString();
            this.txtTenLoai.Text =
            dgvLOAIHANG.Rows[r].Cells[1].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.txtMaLoai.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 
            this.txtTenLoai.Focus();
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
                int r = dgvLOAIHANG.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaLoai =
                dgvLOAIHANG.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From LoaiHang Where MaLoai = '" + strMaLoai + "'");
                cmd.CommandType = CommandType.Text;
                //ktra
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa loại hàng " + strMaLoai + "?", "Trả lời",
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
            this.txtMaLoai.ResetText();
            this.txtTenLoai.ResetText();
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
                    cmd.CommandText = System.String.Concat("Insert Into LoaiHang Values(" + "'" +
                    this.txtMaLoai.Text.ToString() + "','" +
                    this.txtTenLoai.Text.ToString() + "')");
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
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Thứ tự dòng hiện hành
                int r = dgvLOAIHANG.CurrentCell.RowIndex;
                // MaKH hiện hành
                string strMaLoai =
                dgvLOAIHANG.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL
                cmd.CommandText = System.String.Concat("Update LoaiHang Set TenLoai = '" + this.txtTenLoai.Text.ToString() + "' Where MaLoai = '" + strMaLoai + "'");
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
