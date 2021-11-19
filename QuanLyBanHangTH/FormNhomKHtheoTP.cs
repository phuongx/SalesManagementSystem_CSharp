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
    public partial class frmKHtheoTP : Form
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
        void LoadData()
        {
            try
            {
                
                (dgv.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                (dgv.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "TenThanhPho"; (dgv.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).ValueMember =
                "ThanhPho";
                // Vận chuyển dữ liệu lên DataTable dtKH
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG where ThanhPho = '"+this.cbThanhPho.SelectedValue.ToString()+"'", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên DataGridView 
                dgv.DataSource = dtKhachHang;
                txtTong.Text = Convert.ToString(Convert.ToInt32(dgv.Rows.Count.ToString())-1);
                // Thay đổi độ rộng cột
                dgv.AutoResizeColumns();

                this.btnTroVe.Enabled = true;
               
                

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi: Không lấy được nội dung trong table KHACHHANG.");
            }
        }

        public frmKHtheoTP()
        {
            InitializeComponent();
        }

        private void frmKHtheoTP_Load(object sender, EventArgs e)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            // Vận chuyển dữ liệu lên DataTable dtTP
            daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
            dtThanhPho = new DataTable();
            dtThanhPho.Clear();
            daThanhPho.Fill(dtThanhPho);
            // Đưa dữ liệu lên combobox
            this.cbThanhPho.DataSource = dtThanhPho;
            this.cbThanhPho.DisplayMember = "TenThanhPho";
            this.cbThanhPho.ValueMember = "ThanhPho";
            // Đưa dữ liệu lên ComboBox trong DataGridView 
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void frmKHtheoTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtThanhPho.Dispose();
            dtThanhPho = null;
            dtKhachHang = null;
            conn = null;
        }
    }
}
