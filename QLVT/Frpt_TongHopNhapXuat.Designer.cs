namespace QLVT
{
    partial class Frpt_TongHopNhapXuat
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.end = new DevExpress.XtraEditors.DateEdit();
            this.start = new DevExpress.XtraEditors.DateEdit();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.end.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(402, 130);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 16);
            label3.TabIndex = 17;
            label3.Text = "Đến ngày:";
            label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(191, 130);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 16);
            label2.TabIndex = 16;
            label2.Text = "Từ ngày:";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // end
            // 
            this.end.EditValue = new System.DateTime(2023, 5, 25, 17, 2, 0, 0);
            this.end.Location = new System.Drawing.Point(405, 149);
            this.end.Name = "end";
            this.end.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.end.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.end.Size = new System.Drawing.Size(125, 22);
            this.end.TabIndex = 15;
            this.end.EditValueChanged += new System.EventHandler(this.denngayde_EditValueChanged);
            // 
            // start
            // 
            this.start.EditValue = new System.DateTime(2023, 5, 25, 17, 1, 55, 0);
            this.start.Location = new System.Drawing.Point(194, 149);
            this.start.Name = "start";
            this.start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.start.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.start.Size = new System.Drawing.Size(125, 22);
            this.start.TabIndex = 14;
            this.start.EditValueChanged += new System.EventHandler(this.tungayde_EditValueChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(272, 237);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(160, 37);
            this.btnPreview.TabIndex = 13;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(195, 55);
            this.cbChiNhanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(336, 24);
            this.cbChiNhanh.TabIndex = 12;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "CHI NHÁNH";
            // 
            // Frpt_TongHopNhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.end);
            this.Controls.Add(this.start);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cbChiNhanh);
            this.Controls.Add(this.label1);
            this.Name = "Frpt_TongHopNhapXuat";
            this.Text = "Tổng Hợp Nhập Xuất";
            this.Load += new System.EventHandler(this.Frpt_TongHopNhapXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.end.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit end;
        private DevExpress.XtraEditors.DateEdit start;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.Label label1;
    }
}