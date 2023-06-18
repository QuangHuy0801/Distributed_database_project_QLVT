namespace QLVT
{
    partial class Frpt_Hoat_Dong_Nhan_Vien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.denngayde = new DevExpress.XtraEditors.DateEdit();
            this.tungayde = new DevExpress.XtraEditors.DateEdit();
            this.cmbHoTen = new System.Windows.Forms.ComboBox();
            this.thongTinNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS1 = new QLVT.DS1();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new QLVT.DS1TableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new QLVT.DS1TableAdapters.TableAdapterManager();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.thongTinNhanVienTableAdapter = new QLVT.DS1TableAdapters.ThongTinNhanVienTableAdapter();
            hOTENLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.denngayde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngayde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungayde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungayde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinNhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(259, 79);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(68, 16);
            hOTENLabel.TabIndex = 3;
            hOTENLabel.Text = "Nhân viên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(259, 126);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 16);
            label2.TabIndex = 9;
            label2.Text = "Từ ngày:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(470, 126);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(66, 16);
            label3.TabIndex = 10;
            label3.Text = "Đến ngày:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(label3);
            this.panelControl1.Controls.Add(label2);
            this.panelControl1.Controls.Add(this.denngayde);
            this.panelControl1.Controls.Add(this.tungayde);
            this.panelControl1.Controls.Add(hOTENLabel);
            this.panelControl1.Controls.Add(this.cmbHoTen);
            this.panelControl1.Controls.Add(this.btnPreview);
            this.panelControl1.Controls.Add(this.cbChiNhanh);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 284);
            this.panelControl1.TabIndex = 6;
            // 
            // denngayde
            // 
            this.denngayde.EditValue = new System.DateTime(2023, 5, 25, 17, 2, 0, 0);
            this.denngayde.Location = new System.Drawing.Point(473, 145);
            this.denngayde.Name = "denngayde";
            this.denngayde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngayde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngayde.Size = new System.Drawing.Size(125, 22);
            this.denngayde.TabIndex = 8;
            // 
            // tungayde
            // 
            this.tungayde.EditValue = new System.DateTime(2023, 5, 25, 17, 1, 55, 0);
            this.tungayde.Location = new System.Drawing.Point(262, 145);
            this.tungayde.Name = "tungayde";
            this.tungayde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungayde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungayde.Size = new System.Drawing.Size(125, 22);
            this.tungayde.TabIndex = 7;
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongTinNhanVienBindingSource, "HOTEN", true));
            this.cmbHoTen.DataSource = this.thongTinNhanVienBindingSource;
            this.cmbHoTen.DisplayMember = "HOTEN";
            this.cmbHoTen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.Location = new System.Drawing.Point(348, 76);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(250, 24);
            this.cmbHoTen.TabIndex = 4;
            this.cmbHoTen.ValueMember = "MANV";
            this.cmbHoTen.SelectedIndexChanged += new System.EventHandler(this.cmbHoTen_SelectedIndexChanged);
            // 
            // thongTinNhanVienBindingSource
            // 
            this.thongTinNhanVienBindingSource.DataMember = "ThongTinNhanVien";
            this.thongTinNhanVienBindingSource.DataSource = this.DS1;
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(370, 202);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(121, 37);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(262, 31);
            this.cbChiNhanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(336, 24);
            this.cbChiNhanh.TabIndex = 1;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHI NHÁNH";
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataMember = "NhanVien";
            this.nhanVienBindingSource.DataSource = this.DS1;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.ThongTinNhanVienTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT.DS1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // thongTinNhanVienTableAdapter
            // 
            this.thongTinNhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // Frpt_Hoat_Dong_Nhan_Vien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frpt_Hoat_Dong_Nhan_Vien";
            this.Text = "Xem hoạt động nhân viên";
            this.Load += new System.EventHandler(this.Frpt_Hoat_Dong_Nhan_Vien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.denngayde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngayde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungayde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungayde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinNhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.Label label1;
        private DS1 DS1;
        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private DS1TableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private System.Windows.Forms.BindingSource thongTinNhanVienBindingSource;
        private DS1TableAdapters.ThongTinNhanVienTableAdapter thongTinNhanVienTableAdapter;
        private System.Windows.Forms.ComboBox cmbHoTen;
        private DevExpress.XtraEditors.DateEdit denngayde;
        private DevExpress.XtraEditors.DateEdit tungayde;
    }
}