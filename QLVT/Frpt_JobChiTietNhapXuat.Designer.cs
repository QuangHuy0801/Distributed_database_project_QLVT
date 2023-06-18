namespace QLVT
{
    partial class Frpt_JobChiTietNhapXuat
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
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.txtTuThang = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenThang = new DevExpress.XtraEditors.DateEdit();
            this.btPreview = new System.Windows.Forms.Button();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lbChucVu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenThang.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLoai
            // 
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Nhập",
            "Xuất"});
            this.cmbLoai.Location = new System.Drawing.Point(205, 114);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(121, 24);
            this.cmbLoai.TabIndex = 0;
            // 
            // txtTuThang
            // 
            this.txtTuThang.EditValue = new System.DateTime(2023, 5, 25, 17, 1, 55, 0);
            this.txtTuThang.Location = new System.Drawing.Point(205, 181);
            this.txtTuThang.Name = "txtTuThang";
            this.txtTuThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuThang.Properties.MaskSettings.Set("mask", "Y");
            this.txtTuThang.Properties.UseMaskAsDisplayFormat = true;
            this.txtTuThang.Size = new System.Drawing.Size(163, 22);
            this.txtTuThang.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loại phiếu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ tháng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đến tháng:";
            // 
            // txtDenThang
            // 
            this.txtDenThang.EditValue = new System.DateTime(2023, 5, 25, 17, 1, 55, 0);
            this.txtDenThang.Location = new System.Drawing.Point(482, 184);
            this.txtDenThang.Name = "txtDenThang";
            this.txtDenThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenThang.Properties.MaskSettings.Set("mask", "Y");
            this.txtDenThang.Properties.UseMaskAsDisplayFormat = true;
            this.txtDenThang.Size = new System.Drawing.Size(186, 22);
            this.txtDenThang.TabIndex = 13;
            // 
            // btPreview
            // 
            this.btPreview.Location = new System.Drawing.Point(297, 259);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(139, 38);
            this.btPreview.TabIndex = 14;
            this.btPreview.Text = "PREVIEW";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // txtChucVu
            // 
            this.txtChucVu.Enabled = false;
            this.txtChucVu.Location = new System.Drawing.Point(205, 58);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(137, 22);
            this.txtChucVu.TabIndex = 15;
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Location = new System.Drawing.Point(125, 61);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(50, 16);
            this.lbChucVu.TabIndex = 16;
            this.lbChucVu.Text = "Xuất ở :";
            // 
            // Frpt_JobChiTietNhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbChucVu);
            this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.txtDenThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTuThang);
            this.Controls.Add(this.cmbLoai);
            this.Name = "Frpt_JobChiTietNhapXuat";
            this.Text = "Xem chi tiết số lượng - trị giá nhập xuất";
            this.Load += new System.EventHandler(this.Frpt_JobChiTietNhapXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTuThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenThang.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLoai;
        private DevExpress.XtraEditors.DateEdit txtTuThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit txtDenThang;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lbChucVu;
    }
}