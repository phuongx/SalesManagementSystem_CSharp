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
    public partial class frmXDN : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=MP-LAPTOP;Initial Catalog=QuanLyBanHangTH;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtTable
        SqlDataAdapter daTable = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtTable = null;
        public frmXDN()
        {
            InitializeComponent();
        }

        private void frmXDN_Load(object sender, EventArgs e)
        {
            try {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Xử lý danh mục
                int intDM = Convert.ToInt32(this.Text);
                switch (intDM) {
                    case 1:
                        lblDanhMuc.Text = "Danh Mục Thành Phố";
                        daTable = new SqlDataAdapter("SELECT ThanhPho, TenThanhPho FROM THANHPHO", conn);
                        break;
                    case 2:
                        lblDanhMuc.Text = "Danh Mục Khách Hàng";
                        daTable = new SqlDataAdapter("SELECT MaKH, TenCTy FROM KHACHHANG", conn); 
                        break;
                    case 3:
                        lblDanhMuc.Text = "Danh Mục Nhân Viên";
                        daTable = new SqlDataAdapter("SELECT MaNV, Ho, Ten FROM NHANVIEN", conn);
                        break;
                    case 4:
                        lblDanhMuc.Text = "Danh Mục Loại Hàng Hóa";
                        daTable = new SqlDataAdapter("SELECT * FROM LOAIHANG", conn);
                        break;
                    case 5:
                        lblDanhMuc.Text = "Danh Mục Sản Phẩm";
                        daTable = new SqlDataAdapter("SELECT MaSP, TenSP, DonViTinh, DonGia FROM SANPHAM", conn);
                        break;
                    case 6:
                        lblDanhMuc.Text = "Danh Mục Hóa Đơn";
                        daTable = new SqlDataAdapter("SELECT MaHD, MaKH, MaNV FROM HOADON", conn);
                        break;
                    case 7:
                        lblDanhMuc.Text = "Danh Mục Chi Tiết Hóa Đơn";
                        daTable = new SqlDataAdapter("SELECT * FROM CHITIETHOADON", conn);
                        break;
                    case 8:
                        lblDanhMuc.Text = "Danh Mục Kho";
                        daTable = new SqlDataAdapter("SELECT * FROM Kho", conn);
                        break;
                    case 9:
                        lblDanhMuc.Text = "Danh Mục Sản phẩm trong Kho";
                        daTable = new SqlDataAdapter("SELECT * FROM KhoSP", conn);
                        break;
                    default:
                        break;
                }
                // Vận chuyển dữ liệu lên DataTable dtTable
                dtTable = new DataTable();
                dtTable.Clear();
                daTable.Fill(dtTable);
                // Đưa dữ liệu lên DataGridView 
                dgvDANHMUC.DataSource = dtTable;
                // Thay đổi độ rộng cột
                dgvDANHMUC.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        private void dtnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
