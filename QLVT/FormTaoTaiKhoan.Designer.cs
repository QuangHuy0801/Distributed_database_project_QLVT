namespace QLVT
{
    partial class FormTaoTaiKhoan
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label loginnameLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label trangThaiXoaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaoTaiKhoan));
            this.colNGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS1 = new QLVT.DS1();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nhanVienGridControl = new DevExpress.XtraGrid.GridControl();
            this.tableAdapterManager = new QLVT.DS1TableAdapters.TableAdapterManager();
            this.nhanVienTableAdapter = new QLVT.DS1TableAdapters.NhanVienTableAdapter();
            this.uSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSERTableAdapter = new QLVT.DS1TableAdapters.USERTableAdapter();
            this.gROUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gROUPTableAdapter = new QLVT.DS1TableAdapters.GROUPTableAdapter();
            this.lOGINBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOGINTableAdapter = new QLVT.DS1TableAdapters.LOGINTableAdapter();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.TRANGTHAIXOA = new DevExpress.XtraEditors.CheckEdit();
            this.GROUPP = new System.Windows.Forms.ComboBox();
            this.passLabel = new DevExpress.XtraEditors.LabelControl();
            this.loginnameOld = new DevExpress.XtraEditors.TextEdit();
            this.MANV = new System.Windows.Forms.TextBox();
            this.PASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.LOGINNAME = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            loginnameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            trangThaiXoaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gROUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGINBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRANGTHAIXOA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginnameOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PASSWORD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOGINNAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(588, 71);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(48, 16);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Quyền:";
            // 
            // loginnameLabel
            // 
            loginnameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            loginnameLabel.AutoSize = true;
            loginnameLabel.Location = new System.Drawing.Point(557, 146);
            loginnameLabel.Name = "loginnameLabel";
            loginnameLabel.Size = new System.Drawing.Size(78, 16);
            loginnameLabel.TabIndex = 2;
            loginnameLabel.Text = "Login name:";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(548, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 16);
            label1.TabIndex = 13;
            label1.Text = "Mã nhân viên:";
            // 
            // trangThaiXoaLabel
            // 
            trangThaiXoaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            trangThaiXoaLabel.AutoSize = true;
            trangThaiXoaLabel.Location = new System.Drawing.Point(915, 28);
            trangThaiXoaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            trangThaiXoaLabel.Name = "trangThaiXoaLabel";
            trangThaiXoaLabel.Size = new System.Drawing.Size(95, 16);
            trangThaiXoaLabel.TabIndex = 13;
            trangThaiXoaLabel.Text = "Trạng thái xóa:";
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.Caption = "Ngày sinh";
            this.colNGAYSINH.FieldName = "NGAYSINH";
            this.colNGAYSINH.MinWidth = 25;
            this.colNGAYSINH.Name = "colNGAYSINH";
            this.colNGAYSINH.Visible = true;
            this.colNGAYSINH.VisibleIndex = 5;
            this.colNGAYSINH.Width = 93;
            // 
            // colSOCMND
            // 
            this.colSOCMND.Caption = "Số CMND";
            this.colSOCMND.FieldName = "SOCMND";
            this.colSOCMND.MinWidth = 25;
            this.colSOCMND.Name = "colSOCMND";
            this.colSOCMND.OptionsColumn.ReadOnly = true;
            this.colSOCMND.Visible = true;
            this.colSOCMND.VisibleIndex = 3;
            this.colSOCMND.Width = 93;
            // 
            // colTEN
            // 
            this.colTEN.Caption = "Tên";
            this.colTEN.FieldName = "TEN";
            this.colTEN.MinWidth = 25;
            this.colTEN.Name = "colTEN";
            this.colTEN.OptionsColumn.ReadOnly = true;
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 93;
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataMember = "NhanVien";
            this.nhanVienBindingSource.DataSource = this.DS1;
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnGhi,
            this.btnReload,
            this.btnThoat,
            this.btnHuy});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReload),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 2;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 3;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy thao tác";
            this.btnHuy.Id = 7;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 5;
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick_1);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1413, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 709);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1413, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 679);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1413, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 679);
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 25;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.OptionsColumn.ReadOnly = true;
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 4;
            this.colDIACHI.Width = 93;
            // 
            // colHO
            // 
            this.colHO.Caption = "Họ";
            this.colHO.FieldName = "HO";
            this.colHO.MinWidth = 25;
            this.colHO.Name = "colHO";
            this.colHO.OptionsColumn.ReadOnly = true;
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            this.colHO.Width = 93;
            // 
            // colMANV
            // 
            this.colMANV.Caption = "Mã nhân viên";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.OptionsColumn.ReadOnly = true;
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            this.colMANV.Width = 93;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHO,
            this.colTEN,
            this.colSOCMND,
            this.colDIACHI,
            this.colNGAYSINH,
            this.colLUONG,
            this.colMACN,
            this.colTrangThaiXoa});
            this.gridView1.GridControl = this.nhanVienGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colLUONG
            // 
            this.colLUONG.Caption = "Lương";
            this.colLUONG.DisplayFormat.FormatString = "n0";
            this.colLUONG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLUONG.FieldName = "LUONG";
            this.colLUONG.MinWidth = 25;
            this.colLUONG.Name = "colLUONG";
            this.colLUONG.Visible = true;
            this.colLUONG.VisibleIndex = 6;
            this.colLUONG.Width = 93;
            // 
            // colMACN
            // 
            this.colMACN.Caption = "Mã chi nhánh";
            this.colMACN.FieldName = "MACN";
            this.colMACN.MinWidth = 25;
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 7;
            this.colMACN.Width = 93;
            // 
            // colTrangThaiXoa
            // 
            this.colTrangThaiXoa.Caption = "Trạng thái xóa";
            this.colTrangThaiXoa.FieldName = "TrangThaiXoa";
            this.colTrangThaiXoa.MinWidth = 25;
            this.colTrangThaiXoa.Name = "colTrangThaiXoa";
            this.colTrangThaiXoa.Visible = true;
            this.colTrangThaiXoa.VisibleIndex = 8;
            this.colTrangThaiXoa.Width = 93;
            // 
            // nhanVienGridControl
            // 
            this.nhanVienGridControl.DataSource = this.nhanVienBindingSource;
            this.nhanVienGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.nhanVienGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nhanVienGridControl.Location = new System.Drawing.Point(0, 30);
            this.nhanVienGridControl.MainView = this.gridView1;
            this.nhanVienGridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nhanVienGridControl.MenuManager = this.barManager1;
            this.nhanVienGridControl.Name = "nhanVienGridControl";
            this.nhanVienGridControl.Size = new System.Drawing.Size(1413, 234);
            this.nhanVienGridControl.TabIndex = 12;
            this.nhanVienGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // uSERBindingSource
            // 
            this.uSERBindingSource.DataMember = "NhanVien_USER";
            this.uSERBindingSource.DataSource = this.nhanVienBindingSource;
            // 
            // uSERTableAdapter
            // 
            this.uSERTableAdapter.ClearBeforeFill = true;
            // 
            // gROUPBindingSource
            // 
            this.gROUPBindingSource.DataMember = "USER_GROUP";
            this.gROUPBindingSource.DataSource = this.uSERBindingSource;
            // 
            // gROUPTableAdapter
            // 
            this.gROUPTableAdapter.ClearBeforeFill = true;
            // 
            // lOGINBindingSource
            // 
            this.lOGINBindingSource.DataMember = "USER_LOGIN";
            this.lOGINBindingSource.DataSource = this.uSERBindingSource;
            // 
            // lOGINTableAdapter
            // 
            this.lOGINTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 264);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1413, 445);
            this.panelControl2.TabIndex = 29;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(trangThaiXoaLabel);
            this.panelControl4.Controls.Add(this.TRANGTHAIXOA);
            this.panelControl4.Controls.Add(label1);
            this.panelControl4.Controls.Add(this.GROUPP);
            this.panelControl4.Controls.Add(this.passLabel);
            this.panelControl4.Controls.Add(this.loginnameOld);
            this.panelControl4.Controls.Add(this.MANV);
            this.panelControl4.Controls.Add(this.PASSWORD);
            this.panelControl4.Controls.Add(loginnameLabel);
            this.panelControl4.Controls.Add(this.LOGINNAME);
            this.panelControl4.Controls.Add(nameLabel);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 73);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1409, 370);
            this.panelControl4.TabIndex = 9;
            // 
            // TRANGTHAIXOA
            // 
            this.TRANGTHAIXOA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TRANGTHAIXOA.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nhanVienBindingSource, "TrangThaiXoa", true));
            this.TRANGTHAIXOA.Location = new System.Drawing.Point(1033, 25);
            this.TRANGTHAIXOA.Margin = new System.Windows.Forms.Padding(4);
            this.TRANGTHAIXOA.MenuManager = this.barManager1;
            this.TRANGTHAIXOA.Name = "TRANGTHAIXOA";
            this.TRANGTHAIXOA.Properties.Caption = "";
            this.TRANGTHAIXOA.Properties.ReadOnly = true;
            this.TRANGTHAIXOA.Size = new System.Drawing.Size(100, 24);
            this.TRANGTHAIXOA.TabIndex = 14;
            // 
            // GROUPP
            // 
            this.GROUPP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GROUPP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gROUPBindingSource, "name", true));
            this.GROUPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GROUPP.Enabled = false;
            this.GROUPP.FormattingEnabled = true;
            this.GROUPP.Location = new System.Drawing.Point(733, 64);
            this.GROUPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GROUPP.Name = "GROUPP";
            this.GROUPP.Size = new System.Drawing.Size(121, 24);
            this.GROUPP.TabIndex = 12;
            // 
            // passLabel
            // 
            this.passLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passLabel.Location = new System.Drawing.Point(576, 208);
            this.passLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(60, 16);
            this.passLabel.TabIndex = 11;
            this.passLabel.Text = "Password:";
            this.passLabel.Visible = false;
            // 
            // loginnameOld
            // 
            this.loginnameOld.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginnameOld.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.lOGINBindingSource, "loginname", true));
            this.loginnameOld.Location = new System.Drawing.Point(731, 112);
            this.loginnameOld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginnameOld.MenuManager = this.barManager1;
            this.loginnameOld.Name = "loginnameOld";
            this.loginnameOld.Properties.ReadOnly = true;
            this.loginnameOld.Size = new System.Drawing.Size(125, 22);
            this.loginnameOld.TabIndex = 10;
            this.loginnameOld.Visible = false;
            // 
            // MANV
            // 
            this.MANV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MANV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "MANV", true));
            this.MANV.Location = new System.Drawing.Point(733, 21);
            this.MANV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MANV.Name = "MANV";
            this.MANV.ReadOnly = true;
            this.MANV.Size = new System.Drawing.Size(121, 23);
            this.MANV.TabIndex = 8;
            // 
            // PASSWORD
            // 
            this.PASSWORD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PASSWORD.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.lOGINBindingSource, "password", true));
            this.PASSWORD.Location = new System.Drawing.Point(731, 202);
            this.PASSWORD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PASSWORD.MenuManager = this.barManager1;
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(125, 22);
            this.PASSWORD.TabIndex = 5;
            this.PASSWORD.Visible = false;
            // 
            // LOGINNAME
            // 
            this.LOGINNAME.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LOGINNAME.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.lOGINBindingSource, "loginname", true));
            this.LOGINNAME.Enabled = false;
            this.LOGINNAME.Location = new System.Drawing.Point(731, 140);
            this.LOGINNAME.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LOGINNAME.MenuManager = this.barManager1;
            this.LOGINNAME.Name = "LOGINNAME";
            this.LOGINNAME.Size = new System.Drawing.Size(125, 22);
            this.LOGINNAME.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1409, 71);
            this.panelControl3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1405, 67);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 709);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.nhanVienGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTaoTaiKhoan";
            this.Text = "Tạo tài khoản";
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gROUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGINBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRANGTHAIXOA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginnameOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PASSWORD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOGINNAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colNGAYSINH;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private DS1 DS1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl nhanVienGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiXoa;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private DS1TableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private System.Windows.Forms.BindingSource uSERBindingSource;
        private DS1TableAdapters.USERTableAdapter uSERTableAdapter;
        private System.Windows.Forms.BindingSource gROUPBindingSource;
        private DS1TableAdapters.GROUPTableAdapter gROUPTableAdapter;
        private System.Windows.Forms.BindingSource lOGINBindingSource;
        private DS1TableAdapters.LOGINTableAdapter lOGINTableAdapter;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit PASSWORD;
        private DevExpress.XtraEditors.TextEdit LOGINNAME;
        private System.Windows.Forms.TextBox MANV;
        private DevExpress.XtraEditors.TextEdit loginnameOld;
        private DevExpress.XtraEditors.LabelControl passLabel;
        private System.Windows.Forms.ComboBox GROUPP;
        private DevExpress.XtraEditors.CheckEdit TRANGTHAIXOA;
    }
}