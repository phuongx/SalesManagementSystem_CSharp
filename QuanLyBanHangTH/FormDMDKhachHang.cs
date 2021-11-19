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
    public partial class frmDMDKhachHang : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKH
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtTP
                daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);

                // Đưa dữ liệu lên ComboBox trong DataGridView 
                (dgvKHACHHANG.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                (dgvKHACHHANG.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "TenThanhPho"; (dgvKHACHHANG.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).ValueMember =
                "ThanhPho";
                // Vận chuyển dữ liệu lên DataTable dtKH
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên DataGridView 
                dgvKHACHHANG.DataSource = dtKhachHang;
                // Thay đổi độ rộng cột
                dgvKHACHHANG.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtMaKH.ResetText();
                this.txtTenCty.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
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
                this.txtMaKH.Enabled = true;
                this.txtTenCty.Enabled = true;
                // Đưa dữ liệu lên combobox
                this.cbxThanhPho.DataSource = dtThanhPho;
                this.cbxThanhPho.DisplayMember = "TenThanhPho";
                this.cbxThanhPho.ValueMember = "ThanhPho";
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table KHACHHANG.");
            }
        }
        public frmDMDKhachHang()
        {
            InitializeComponent();
        }

        private void frmDMDKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDMDKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtKhachHang.Dispose();
            dtKhachHang = null;
            dtThanhPho.Dispose();
            dtThanhPho = null;
            // Hủy kết nối
            conn = null;
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
            this.txtMaKH.ResetText();
            this.txtTenCty.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
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
            this.txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cbxThanhPho.DataSource = dtThanhPho;
            this.cbxThanhPho.DisplayMember = "TenThanhPho";
            this.cbxThanhPho.ValueMember = "ThanhPho";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvKHACHHANG.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaKH.Text = dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
            this.txtTenCty.Text = dgvKHACHHANG.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text = dgvKHACHHANG.Rows[r].Cells[2].Value.ToString();
            this.cbxThanhPho.SelectedValue = dgvKHACHHANG.Rows[r].Cells[3].Value.ToString();
            this.txtDienThoai.Text = dgvKHACHHANG.Rows[r].Cells[4].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.txtMaKH.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtTenCty.Focus();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenCty.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
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
                int r = dgvKHACHHANG.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAKH =
                dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From KhachHang Where MaKH = '" + strMAKH + "'");
                cmd.CommandType = CommandType.Text;
                //ktra
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa khách hàng "+strMAKH+"?", "Trả lời",
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
                    cmd.CommandText = System.String.Concat("Insert Into KhachHang Values(" + "'" +
                    this.txtMaKH.Text.ToString() + "','" +
                    this.txtTenCty.Text.ToString() + "','" +
                    this.txtDiaChi.Text.ToString() + "','" +
                    this.cbxThanhPho.SelectedValue.ToString() +
                    "','" + this.txtDienThoai.Text.ToString() + "')");
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
                    int r = dgvKHACHHANG.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAKH =
                    dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update KhachHang Set TenCty = '" +
                    this.txtTenCty.Text.ToString() + "', DiaChi='"
                    + this.txtDiaChi.Text.ToString() + "', ThanhPho = '" +
                    this.cbxThanhPho.SelectedValue.ToString() + "', DienThoai = '" +
                    this.txtDienThoai.Text.ToString() + "' Where MaKH = '" + strMAKH + "'");
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
