
namespace QuanLyBanHangTH
{
    partial class frmXDN
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
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.dgvDANHMUC = new System.Windows.Forms.DataGridView();
            this.dtnTroVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDANHMUC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMuc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDanhMuc.Location = new System.Drawing.Point(214, 42);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(101, 36);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "label1";
            // 
            // dgvDANHMUC
            // 
            this.dgvDANHMUC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDANHMUC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDANHMUC.Location = new System.Drawing.Point(39, 112);
            this.dgvDANHMUC.Name = "dgvDANHMUC";
            this.dgvDANHMUC.RowHeadersWidth = 62;
            this.dgvDANHMUC.RowTemplate.Height = 28;
            this.dgvDANHMUC.Size = new System.Drawing.Size(543, 289);
            this.dgvDANHMUC.TabIndex = 1;
            // 
            // dtnTroVe
            // 
            this.dtnTroVe.BackColor = System.Drawing.SystemColors.HotTrack;
            this.dtnTroVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtnTroVe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtnTroVe.Location = new System.Drawing.Point(438, 418);
            this.dtnTroVe.Name = "dtnTroVe";
            this.dtnTroVe.Size = new System.Drawing.Size(144, 42);
            this.dtnTroVe.TabIndex = 2;
            this.dtnTroVe.Text = "Trở về";
            this.dtnTroVe.UseVisualStyleBackColor = false;
            this.dtnTroVe.Click += new System.EventHandler(this.dtnTroVe_Click);
            // 
            // frmXDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(663, 484);
            this.Controls.Add(this.dtnTroVe);
            this.Controls.Add(this.dgvDANHMUC);
            this.Controls.Add(this.lblDanhMuc);
            this.Name = "frmXDN";
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.frmXDN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDANHMUC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.DataGridView dgvDANHMUC;
        private System.Windows.Forms.Button dtnTroVe;
    }
}