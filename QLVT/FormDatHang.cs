using DevExpress.DataAccess.Wizard.Model;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class FormDatHang : Form
    {
        int vitri = 0;
        bool dangThemMoi = false;

        String maSoDDH;
        DateTime ngay;
        String nhaCC;
        int manv;
        String makho;
        String mavattu;
        int soluong;
        float dongia;

        Stack<String> stackDDH = new Stack<String>();
        Stack<String> stackCTDDH = new Stack<String>();
        public FormDatHang()
        {
            InitializeComponent();
        }
        private void FormDatHang_Load(object sender, EventArgs e)
        {
            DSDATHANG.EnforceConstraints = false;
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DSDATHANG.DatHang);
            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTDDHTableAdapter.Fill(this.DSDATHANG.CTDDH);

            this.thongTinKhoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.thongTinKhoTableAdapter.Fill(this.DSDATHANG.ThongTinKho);
            this.thongTinVTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.thongTinVTTableAdapter.Fill(this.DSDATHANG.ThongTinVT);


            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;

            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;

            
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhiPX.Enabled = btnHuyPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnReloadPX.Enabled = btnThoatPX.Enabled = true;
            }
            else
            {
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                cbChiNhanh.Enabled = false;
            }
        }

        private bool kiemTraThongTinDatHang()
        {
            /*kiem tra txtNgay*/
            if (txtNgay.Text.Trim() == "")
            {
                MessageBox.Show("Ngày lập đơn đặt hàng không được để trống!", "Thông báo", MessageBoxButtons.OK);
                txtNgay.Focus();
                return false;
            }
            /*kiem tra txtNhaCC*/
            if (txtNhaCC.Text == "")
            {
                MessageBox.Show("Không bỏ trống nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                txtNhaCC.Focus();
                return false;
            }

            if (Regex.IsMatch(txtNhaCC.Text, @"^[a-zA-Z ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ,]+$") == false)
            {
                MessageBox.Show("Tên nhà cung cấp chỉ bao gồm chữ cái, dấu phẩy và dấu gạch ngang(-)", "Thông báo", MessageBoxButtons.OK);
                txtNhaCC.Focus();
                return false;
            }

            return true;
        }

        private void SOLUONG_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lbNGAY_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cTDDHBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void barButtonDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup != "CONGTY")
            {
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                txtNgay.Visible = txtNhaCC.Visible = txtMaNV.Visible = txtMaKho.Visible = !txtMaKho.Visible;
                lbNGAY.Visible = lbNhaCC.Visible = lbMANV.Visible = lbMAKHO.Visible = cbTTKho.Visible = !lbMAKHO.Visible;
                txtMaVT.Visible = txtSoLuong.Visible = txtDonGia.Visible = cbTTVT.Visible = !txtDonGia.Visible;
                lbMAVT.Visible = lbSOLUONG.Visible = lbDONGIA.Visible = !lbDONGIA.Visible;
            }
            CTDDHGridControl.Enabled = !CTDDHGridControl.Enabled;
            datHangGridControl.Enabled = !datHangGridControl.Enabled;
            barButtonDH.ItemAppearance.Normal.BackColor = txtMaNV.Visible == true ? Color.Pink : Color.Tan;
            panelControl2.Enabled = false;
            barButtonDH.Caption = txtMaNV.Visible == true ? "Chi Tiết Đơn Đặt Hàng" : "Đặt Hàng";
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datHangGridControl_Click(object sender, EventArgs e)
        {

        }

        private void lbMANV_Click(object sender, EventArgs e)
        {

        }

        private void lbMAKHO_Click(object sender, EventArgs e)
        {

        }

        private string tuDongTangMa(string ma, int sochucaidau)
        {

            string m = ma.Substring(0, sochucaidau);
            int so = int.Parse(ma.Substring(sochucaidau)) + 1;
            if (so <= 9)
                return m + '0' + so.ToString();
            return m + so.ToString();
        }

        private void btnThemPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonDH.Caption == "Chi Tiết Đơn Đặt Hàng")
            {
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                datHangGridControl.Enabled = false;
                dangThemMoi = true;
                panelControl2.Enabled = true;
                vitri = bds_DatHang.Position;
                barButtonDH.Enabled = false;
                panelControl2.Enabled = true;
                bds_DatHang.AddNew();
                string getMaxIdQuery = "[dbo].[sp_Get_Max_Id] 'DATHANG', 'MasoDDH'";
                string maDDH = "";
                txtMaNV.Text = Program.username.ToString();   // gan txtMANV bang ma cua nhan vien dang login
                Console.WriteLine(getMaxIdQuery);
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(getMaxIdQuery);
                    if (Program.myReader == null) { return; }
                    Program.myReader.Read();
                    if (Program.myReader.GetString(0) == "NULL")
                    {
                        txtMADDH.Text = "PX01";
                        Program.myReader.Close();
                    }
                    else
                    {
                        maDDH = tuDongTangMa(Program.myReader.GetString(0), 4);
                        Console.WriteLine(maDDH);
                        txtMADDH.Text = maDDH;
                        Program.myReader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối! " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }

            }
            else
            {
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                dangThemMoi = true;
                vitri = bds_CTDDH.Position;
                panelControl2.Enabled = true;
                CTDDHGridControl.Enabled = false;
                barButtonDH.Enabled = false;
                bds_CTDDH.AddNew();
            }

        }

        private void cbTTKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTTKho.SelectedValue != null) txtMaKho.Text = cbTTKho.SelectedValue.ToString();

            }
            catch { }
        }

        private void cbTTVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTTVT.SelectedValue != null) txtMaVT.Text = cbTTVT.SelectedValue.ToString();

            }
            catch { }
        }

        private void btnGhiDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonDH.Caption == "Chi Tiết Đơn Đặt Hàng")
            {
                if (kiemTraThongTinDatHang() == false) return;

                if (dangThemMoi == true)
                {
                    String checkDDH =
                      "EXEC [dbo].[sp_Check_Exists_Id_Char] 'DATHANG', 'MaSoDDH' ,'" + txtMADDH.Text.Trim() + "'";
                    
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkDDH);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 1)
                        {
                            txtMADDH.Text = tuDongTangMa(txtMADDH.Text.Trim(), 2);
                            MessageBox.Show("Mã đã tồn tại! Hệ thống đã tự động đổi mã cho bạn rồi, vui lòng xác nhận lại!", "Thông báo", MessageBoxButtons.OK);
                            Program.myReader.Close();
                            return;
                        }
                        else
                        {
                            Program.myReader.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối! " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                }

                try
                {
                    String query = "";
                    bds_DatHang.EndEdit();
                    bds_DatHang.ResetCurrentItem();
                    this.datHangTableAdapter.Update(this.DSDATHANG.DatHang);

                    if (dangThemMoi)
                    {

                        query = "DELETE DBO.DATHANG WHERE MASODDH = '" +txtMADDH.Text.Trim() + "'";

                    }
                    else
                    {
                        query = "UPDATE DBO.DATHANG " +
                               "SET " +
                               "NGAY = '" + ngay.ToString() + "'," +
                               "NHACC = N'" + nhaCC + "'," +
                               "MANV = " + manv + "," +
                               "MAKHO = '" + makho + "'" +
                               "WHERE MASODDH = '" + maSoDDH + "'";

                    }
                    Console.WriteLine(query);

                    stackDDH.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                btnThemPX.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoatPX.Enabled = btnReloadPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                panelControl2.Enabled = false;
                datHangGridControl.Enabled = true;
                barButtonDH.Enabled = true;
            }
            else
            {
                if (dangThemMoi == true)
                {
                    if (txtMaVT.Text.Trim() == "")
                    {
                        MessageBox.Show("Mã vật tư không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        txtMaVT.Focus();
                        return;
                    }
                    if (txtSoLuong.Text.Trim() == "")
                    {
                        MessageBox.Show("Số lượng không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        txtSoLuong.Focus();
                        return;
                    }
                    if (txtDonGia.Text.Trim() == "")
                    {
                        MessageBox.Show("Đơn giá không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        txtDonGia.Focus();
                        return;
                    }

                    if (Regex.IsMatch(txtSoLuong.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Số lượng chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                        txtSoLuong.Focus();
                        return;
                    }

                    if (Regex.IsMatch(txtDonGia.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Đơn giá chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                        txtDonGia.Focus();
                        return;
                    }

                    if (int.Parse(txtSoLuong.EditValue.ToString()) <= 0)
                    {
                        MessageBox.Show("Số lượng phải >0!", "Thông báo", MessageBoxButtons.OK);
                        txtSoLuong.Focus();
                        return;
                    }
                    if (int.Parse(txtDonGia.EditValue.ToString()) <= 0)
                    {
                        MessageBox.Show("Đơn giá phải >0!", "Thông báo", MessageBoxButtons.OK);
                        txtDonGia.Focus();
                        return;
                    }
                    String checkCTDDH =
                      "EXEC [dbo].[sp_Check_Exists_CT_Id_Char] 'CTDDH', 'MAVT' ,'" + txtMaVT.Text.Trim() + "','MASODDH','" + txtMADDH.Text.Trim() + "'";
                    
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkCTDDH);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 1)
                        {

                            MessageBox.Show("Mã vật tư đã tồn tại trong đơn đặt hàng này", "Thông báo", MessageBoxButtons.OK);
                            Program.myReader.Close();
                            return;
                        }
                        else
                        {
                            Program.myReader.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối! " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }


                }

                try
                {
                    String query = "";
                    bds_CTDDH.EndEdit();
                    bds_CTDDH.ResetCurrentItem();
                    this.CTDDHTableAdapter.Update(this.DSDATHANG.CTDDH);

                    if (dangThemMoi)
                    {
                        query = "DELETE DBO.CTDDH WHERE MASODDH = '" + txtMADDH.Text.Trim() + "' AND MAVT = '" + txtMaVT.Text.ToString() + "'";
                    }
                    else
                    {
                        query = "UPDATE DBO.CTDDH " +
                               "SET " +
                               "MasoDDH = '" + maSoDDH + "'," +
                               "MAVT = '" + mavattu + "'," +
                               "SOLUONG = " + soluong + "," +
                               "DONGIA = " + dongia + " " +
                               "WHERE MasoDDH = '" + txtMADDH.Text.Trim() + "' AND MAVT = '" + txtMaVT.Text.ToString() + "'";

                    }
                    Console.WriteLine(query);

                    stackCTDDH.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                btnThemPX.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoatPX.Enabled = btnReloadPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                panelControl2.Enabled = false;
                CTDDHGridControl.Enabled = true;
                barButtonDH.Enabled = true;

            }

        }

        private void btnThoatPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnHuyPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonDH.Caption == "Chi Tiết Đơn Đặt Hàng")
            {
                bds_DatHang.CancelEdit();
                this.datHangTableAdapter.Fill(this.DSDATHANG.DatHang);

                bds_DatHang.Position = vitri;
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                datHangGridControl.Enabled = true;
                panelControl2.Enabled = false;
                barButtonDH.Enabled = true;

            }
            else
            {
                bds_CTDDH.CancelEdit();
                this.CTDDHTableAdapter.Fill(this.DSDATHANG.CTDDH);
                bds_CTDDH.Position = vitri;
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                CTDDHGridControl.Enabled = true;
                panelControl2.Enabled = false;
                barButtonDH.Enabled = true;

            }
        }

        private void btnSuaPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonDH.Caption == "Chi Tiết Đơn Đặt Hàng")
            {
                if (bds_DatHang.Count == 0)
                {
                    MessageBox.Show("Danh sách đơn đặt hàng trống!", "", MessageBoxButtons.OK);
                    btnSua.Enabled = false;
                    return;
                }
                vitri = bds_DatHang.Position;
                DataRowView dt = ((DataRowView)bds_DatHang[bds_DatHang.Position]);
                maSoDDH = dt["MasoDDH"].ToString();
                ngay = (DateTime)dt["NGAY"];
                nhaCC = dt["NhaCC"].ToString();
                manv = (int)dt["MANV"];
                makho = dt["MAKHO"].ToString();

                panelControl2.Enabled = true;
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                datHangGridControl.Enabled = false;
                barButtonDH.Enabled = false;
                dangThemMoi = false;
            }
            else
            {
                if (bds_CTDDH.Count == 0)
                {
                    MessageBox.Show("Danh sách chi tiết đơn đặt hàng trống!", "", MessageBoxButtons.OK);
                    btnSua.Enabled = false;
                    return;
                }
                vitri = bds_CTDDH.Position;
                DataRowView dt = ((DataRowView)bds_CTDDH[bds_CTDDH.Position]);
                maSoDDH = dt["MasoDDH"].ToString();
                mavattu = dt["MAVT"].ToString();
                soluong = int.Parse(dt["SOLUONG"].ToString());
                dongia = float.Parse(dt["DONGIA"].ToString());
                panelControl2.Enabled = true;
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                CTDDHGridControl.Enabled = false;
                barButtonDH.Enabled = false;
                dangThemMoi = false;
            }
        }

        private void cbTTKho_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cbTTKho.SelectedValue != null) txtMaKho.Text = cbTTKho.SelectedValue.ToString();

            }
            catch { }
        }

        private void btnXoaPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (barButtonDH.Caption == "Chi Tiết Đơn Đặt Hàng")
            {
                if (bds_DatHang.Count == 0)
                {
                    MessageBox.Show("Danh sách đơn đặt hàng trống!", "", MessageBoxButtons.OK);
                    btnXoa.Enabled = false;
                    return;
                }
                if (bds_CTDDH.Count > 0)
                {
                    MessageBox.Show("Không thể xóa DDH này vì đã có chi tiết DDH!", "", MessageBoxButtons.OK);
                    return;
                }
                if(bds_PhieuNhap.Count > 0)
                {
                    MessageBox.Show("Không thể xóa DDH này vì DDH này đã được nhập hàng!", "", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có thực sự muốn xóa phiếu xuất này!", "Xác nhận", MessageBoxButtons.OKCancel)
                   == DialogResult.OK)
                {
                    try
                    {
                        DataRowView dt = ((DataRowView)bds_DatHang[bds_DatHang.Position]);
                        maSoDDH = dt["MasoDDH"].ToString();
                        ngay = (DateTime)dt["NGAY"];
                        nhaCC = dt["NhaCC"].ToString();
                        manv = (int)dt["MANV"];
                        makho = dt["MAKHO"].ToString();

                        bds_DatHang.RemoveCurrent();
                        this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.datHangTableAdapter.Update(this.DSDATHANG.DatHang);
                        String query = string.Format("INSERT INTO DBO.DATHANG(MASODDH,NGAY,NHACC,MANV,MAKHO) " +
                                                    " VALUES('{0}','{1}',N'{2}',{3}, '{4}')", maSoDDH, ngay, nhaCC, manv, makho);
                        Console.WriteLine(query);
                        stackDDH.Push(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa phiếu xuất. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                        this.datHangTableAdapter.Fill(this.DSDATHANG.DatHang);
                        bds_DatHang.Position = bds_DatHang.Find("MAPX", maSoDDH);
                        return;
                    }
                }
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
            }
            else 
            {
                if (bds_CTDDH.Count == 0)
                {
                    MessageBox.Show("Danh sách chi tiết đơn đặt hàng trống!", "", MessageBoxButtons.OK);
                    btnXoa.Enabled = false;
                    return;
                }
                if (MessageBox.Show("Bạn có thực sự muốn xóa chi tiết DDH này!", "Xác nhận", MessageBoxButtons.OKCancel)
                   == DialogResult.OK)
                {
                    try
                    {
                        DataRowView dt = ((DataRowView)bds_CTDDH[bds_CTDDH.Position]);
                        maSoDDH = dt["MasoDDH"].ToString();
                        mavattu = dt["MAVT"].ToString();
                        soluong = int.Parse(dt["SOLUONG"].ToString());
                        dongia = float.Parse(dt["DONGIA"].ToString());

                        bds_CTDDH.RemoveCurrent();
                        this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.CTDDHTableAdapter.Update(this.DSDATHANG.CTDDH);
                        String query = string.Format("INSERT INTO DBO.CTDDH(MASODDH,MAVT,SOLUONG,DONGIA) " +
                                                    " VALUES('{0}','{1}',{2},{3})", maSoDDH, mavattu, soluong, dongia);
                        Console.WriteLine(query);
                        stackCTDDH.Push(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa chi tiết phiếu xuất. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                        this.CTDDHTableAdapter.Fill(this.DSDATHANG.CTDDH);
                        this.CTDDHTableAdapter.Fill(this.DSDATHANG.CTDDH);
                        return;
                    }
                }
                
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
            }
        }

        private void btnPhucHoiPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonDH.Caption == "Chi Tiết Đơn Đặt Hàng")
            {
                if (stackDDH.Count == 0)
                {
                    MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                    ; return;
                }


                string query = stackDDH.Pop();
                Program.ExecSqlNonQuery(query);

                this.datHangTableAdapter.Fill(this.DSDATHANG.DatHang);

                datHangGridControl.Enabled = true;
                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                datHangGridControl.Enabled = true;
            }
            else
            {
                if (stackCTDDH.Count == 0)
                {
                    MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                    ; return;
                }


                string query = stackCTDDH.Pop();
                Program.ExecSqlNonQuery(query);

                this.CTDDHTableAdapter.Fill(this.DSDATHANG.CTDDH);

                btnThemPX.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                CTDDHGridControl.Enabled = true;
            }
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cbChiNhanh.SelectedValue.ToString();

            if (cbChiNhanh.SelectedIndex != Program.mChinhNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;

            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;

            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);

            }

            else
            {
                this.datHangGridControl.Enabled = false;
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DSDATHANG.DatHang);
                this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTDDHTableAdapter.Fill(this.DSDATHANG.CTDDH);
                this.datHangGridControl.Enabled = true;

            }
        }

        private void CTDDHGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}
