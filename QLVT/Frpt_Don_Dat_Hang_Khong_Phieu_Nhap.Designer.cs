namespace QLVT
{
    partial class Frpt_Don_Dat_Hang_Khong_Phieu_Nhap
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
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(209, 55);
            this.cbChiNhanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(336, 24);
            this.cbChiNhanh.TabIndex = 3;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHI NHÁNH:";
            // 
            // btPreview
            // 
            this.btPreview.Location = new System.Drawing.Point(345, 121);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(139, 38);
            this.btPreview.TabIndex = 4;
            this.btPreview.Text = "PREVIEW";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // Frpt_Don_Dat_Hang_Khong_Phieu_Nhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.cbChiNhanh);
            this.Controls.Add(this.label1);
            this.Name = "Frpt_Don_Dat_Hang_Khong_Phieu_Nhap";
            this.Text = "Xem đơn đặt hàng không có phiếu nhập";
            this.Load += new System.EventHandler(this.Frpt_Don_Dat_Hang_Khong_Phieu_Nhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPreview;
    }
}