
namespace QuanLyBanHangTH
{
    partial class frmDaCap2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTroVe = new System.Windows.Forms.Button();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongKS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLoaiHang = new System.Windows.Forms.ComboBox();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.dgvKhoSP = new System.Windows.Forms.DataGridView();
            this.MaK = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_SP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoSP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTroVe
            // 
            this.btnTroVe.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTroVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVe.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTroVe.Location = new System.Drawing.Point(799, 602);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(147, 58);
            this.btnTroVe.TabIndex = 58;
            this.btnTroVe.Text = "Trở về";
            this.btnTroVe.UseVisualStyleBackColor = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // dgvKho
            // 
            this.dgvKho.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaK,
            this.DienThoai,
            this.DiaChi});
            this.dgvKho.Location = new System.Drawing.Point(152, 528);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowHeadersWidth = 62;
            this.dgvKho.RowTemplate.Height = 28;
            this.dgvKho.Size = new System.Drawing.Size(572, 132);
            this.dgvKho.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 528);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 55;
            this.label4.Text = "Chi tiết Kho:";
            // 
            // txtTongKS
            // 
            this.txtTongKS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongKS.Location = new System.Drawing.Point(202, 278);
            this.txtTongKS.Name = "txtTongKS";
            this.txtTongKS.Size = new System.Drawing.Size(89, 30);
            this.txtTongKS.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Chi tiết Kho SP:";
            // 
            // txtTongSP
            // 
            this.txtTongSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSP.Location = new System.Drawing.Point(202, 45);
            this.txtTongSP.Name = "txtTongSP";
            this.txtTongSP.Size = new System.Drawing.Size(82, 30);
            this.txtTongSP.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "Danh sách SP:";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Location = new System.Drawing.Point(396, -1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 42);
            this.btnOK.TabIndex = 48;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 47;
            this.label1.Text = "Chọn Loại hàng:";
            // 
            // cbLoaiHang
            // 
            this.cbLoaiHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiHang.FormattingEnabled = true;
            this.cbLoaiHang.Location = new System.Drawing.Point(202, 1);
            this.cbLoaiHang.Name = "cbLoaiHang";
            this.cbLoaiHang.Size = new System.Drawing.Size(177, 33);
            this.cbLoaiHang.TabIndex = 46;
            // 
            // dgvSP
            // 
            this.dgvSP.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.MaLoai,
            this.DonViTinh,
            this.DonGia});
            this.dgvSP.Location = new System.Drawing.Point(25, 81);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.RowHeadersWidth = 62;
            this.dgvSP.RowTemplate.Height = 28;
            this.dgvSP.Size = new System.Drawing.Size(921, 191);
            this.dgvSP.TabIndex = 59;
            this.dgvSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellClick);
            // 
            // dgvKhoSP
            // 
            this.dgvKhoSP.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvKhoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKho,
            this.Ma,
            this.Ma_SP,
            this.SoLuongTon});
            this.dgvKhoSP.Location = new System.Drawing.Point(22, 314);
            this.dgvKhoSP.Name = "dgvKhoSP";
            this.dgvKhoSP.RowHeadersWidth = 62;
            this.dgvKhoSP.RowTemplate.Height = 28;
            this.dgvKhoSP.Size = new System.Drawing.Size(924, 194);
            this.dgvKhoSP.TabIndex = 60;
            this.dgvKhoSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoSP_CellClick);
            // 
            // MaK
            // 
            this.MaK.DataPropertyName = "MaKho";
            this.MaK.Frozen = true;
            this.MaK.HeaderText = "Mã Kho";
            this.MaK.MinimumWidth = 8;
            this.MaK.Name = "MaK";
            this.MaK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaK.Width = 150;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện thoại";
            this.DienThoai.MinimumWidth = 8;
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DienThoai.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 8;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 150;
            // 
            // MaKho
            // 
            this.MaKho.DataPropertyName = "MaKho";
            this.MaKho.HeaderText = "Mã Kho";
            this.MaKho.MinimumWidth = 8;
            this.MaKho.Name = "MaKho";
            this.MaKho.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaKho.Width = 150;
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "MaSP";
            this.Ma.HeaderText = "Mã SP";
            this.Ma.MinimumWidth = 8;
            this.Ma.Name = "Ma";
            this.Ma.Width = 150;
            // 
            // Ma_SP
            // 
            this.Ma_SP.DataPropertyName = "MaSP";
            this.Ma_SP.HeaderText = "Tên SP";
            this.Ma_SP.MinimumWidth = 8;
            this.Ma_SP.Name = "Ma_SP";
            this.Ma_SP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ma_SP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ma_SP.Width = 150;
            // 
            // SoLuongTon
            // 
            this.SoLuongTon.DataPropertyName = "SoLuongTon";
            this.SoLuongTon.HeaderText = "Số Lượng Tồn";
            this.SoLuongTon.MinimumWidth = 8;
            this.SoLuongTon.Name = "SoLuongTon";
            this.SoLuongTon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SoLuongTon.Width = 150;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.Frozen = true;
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 8;
            this.MaSP.Name = "MaSP";
            this.MaSP.Width = 150;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên SP";
            this.TenSP.MinimumWidth = 8;
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 150;
            // 
            // MaLoai
            // 
            this.MaLoai.DataPropertyName = "MaLoai";
            this.MaLoai.HeaderText = "Loại Hàng";
            this.MaLoai.MinimumWidth = 8;
            this.MaLoai.Name = "MaLoai";
            this.MaLoai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaLoai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaLoai.Width = 150;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.MinimumWidth = 8;
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DonViTinh.Width = 150;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 8;
            this.DonGia.Name = "DonGia";
            this.DonGia.Width = 150;
            // 
            // frmDaCap2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(978, 692);
            this.Controls.Add(this.dgvKhoSP);
            this.Controls.Add(this.dgvSP);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.dgvKho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTongKS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTongSP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLoaiHang);
            this.Name = "frmDaCap2";
            this.Text = "Quản lý Đa cấp Sản phẩm - Kho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDaCap2_FormClosing);
            this.Load += new System.EventHandler(this.frmDaCap2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongKS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLoaiHang;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.DataGridView dgvKhoSP;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ma_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongTon;
    }
}