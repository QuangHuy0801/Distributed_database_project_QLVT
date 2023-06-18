using DevExpress.DataAccess.Wizard.Model;
using System;
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
    public partial class FormPhieuNhap : Form
    {
        int vitri = 0;

        bool check_them = true;

        String mapn;
        DateTime ngay;
        String masoddh;
        int manv;
        String makho;
        String mavattu;
        int soluong;
        float dongia;
        Stack<String> stack = new Stack<String>();
        Stack<String> stack2 = new Stack<String>();

        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phieuNhapBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSPHIEUNHAP);

        }

        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {

            DSPHIEUNHAP.EnforceConstraints = false;
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DSPHIEUNHAP.PhieuNhap);

            this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPNTableAdapter.Fill(this.DSPHIEUNHAP.CTPN);

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;

            this.TTVTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TTVTTableAdapter.Fill(this.DSPHIEUNHAP.TTVT);

            this.TTKHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TTKHOTableAdapter.Fill(this.DSPHIEUNHAP.TTKHO);

            // Van con loi, tu xu li, thay k sua, thay se check khi thi
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;


            //bat tat phan quyen
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnGhiPN.Enabled = btnHuyPN.Enabled = btnPhucHoiPN.Enabled = false;
                btnReloadPN.Enabled = btnThoatPN.Enabled = true;


            }
            else
            {
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                cbChiNhanh.Enabled = false;
            }




            // bat tat phan quyen - chua phan quyen cho nhom khác

        }
        private string tuDongTangMa(string ma, int sochucaidau)
        {

            string m = ma.Substring(0, sochucaidau);
            int so = int.Parse(ma.Substring(sochucaidau)) + 1;
            if (so <= 9)
                return m + '0' + so.ToString();
            return m + so.ToString();
        }



              

            

     





                private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Console.WriteLine(cbChiNhanh.SelectedValue.ToString());

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
                        this.phieuNhapGridControl.Enabled = false;
                        this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.phieuNhapTableAdapter.Fill(this.DSPHIEUNHAP.PhieuNhap);
                        this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.CTPNTableAdapter.Fill(this.DSPHIEUNHAP.CTPN);
                        this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.nhanVienTableAdapter.Fill(this.DSPHIEUNHAP.NhanVien);
                        this.phieuNhapGridControl.Enabled = true;

                    }
                }

                private void TTVTComboBox_SelectedIndexChanged(object sender, EventArgs e)
                {


                    try
                    {
                        if (TTVTComboBox.SelectedValue != null) txtMAVT.Text = TTVTComboBox.SelectedValue.ToString();

                    }
                    catch { }

                }

                private void TTKHOComboBox_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (TTKHOComboBox.SelectedValue != null) txtMAKHO.Text = TTKHOComboBox.SelectedValue.ToString();

                    }
                    catch { }
                }


        private void barButtonItem12_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPN.Caption == "Chi tiết phiếu nhập")
            {
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = false;
                btnGhiPN.Enabled = btnHuyPN.Enabled = true;
                phieuNhapGridControl.Enabled = false;
                check_them = true;
                panelControl2.Enabled = true;
                vitri = phieuNhapBindingSource.Position;
                barButtonPN.Enabled = false;
                panelControl2.Enabled = true;
                phieuNhapBindingSource.AddNew();
                string getMaxIdQuery = "EXEC [dbo].[sp_Get_Max_Id] 'PHIEUNHAP', 'MAPN'";
                string maphieunhap = "";
                txtMANV.Text = Program.username.ToString();
                Console.WriteLine(getMaxIdQuery);
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(getMaxIdQuery);
                    if (Program.myReader == null) { return; }
                    Program.myReader.Read();
                    if (Program.myReader.GetString(0) == "NULL")
                    {
                        txtMAPN.Text = "PN01";
                        Program.myReader.Close();
                    }
                    else
                    {
                        maphieunhap = tuDongTangMa(Program.myReader.GetString(0), 2);
                        txtMAPN.Text = maphieunhap;
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
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = false;
                btnGhiPN.Enabled = btnHuyPN.Enabled = true;
                check_them = true;
                vitri = CTPNBindingSource.Position;
                txtMAVT.Enabled = true;
                panelControl2.Enabled = true;
                cTPNGridControl.Enabled = false;
                barButtonPN.Enabled = false;
                CTPNBindingSource.AddNew();
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPN.Caption == "Chi tiết phiếu nhập")
            {
                if (CTPNBindingSource.Count > 0)

                {
                    MessageBox.Show("Không thể xóa phiếu xuất này vì đã có chi tiết phiếu xuất!", "", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có thực sự muốn xóa phiếu nhập này!", "Xác nhận", MessageBoxButtons.OKCancel)
                   == DialogResult.OK)
                {
                    try
                    {
                        DataRowView dt = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position]);
                        mapn = dt["MAPN"].ToString();
                        ngay = (DateTime)dt["NGAY"];
                        masoddh = dt["MasoDDH"].ToString();
                        manv = (int)dt["MANV"];
                        makho = dt["MAKHO"].ToString();

                        phieuNhapBindingSource.RemoveCurrent();
                        this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.phieuNhapTableAdapter.Update(this.DSPHIEUNHAP.PhieuNhap);
                        String query = string.Format("INSERT INTO DBO.PHIEUNHAP(MAPN,NGAY,MasoDDH,MANV,MAKHO) " +
                                                    " VALUES('{0}','{1}',N'{2}',{3}, '{4}')", mapn, ngay, masoddh, manv, makho);
                        Console.WriteLine(query);
                        stack.Push(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa phiếu xuất. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                        this.phieuNhapTableAdapter.Fill(this.DSPHIEUNHAP.PhieuNhap);
                        phieuNhapBindingSource.Position = phieuNhapBindingSource.Find("MAPN", mapn);
                        return;
                    }
                }
                if (phieuNhapBindingSource.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
            }
            else
            {

                if (MessageBox.Show("Bạn có thực sự muốn xóa chi tiết phiếu nhập này!", "Xác nhận", MessageBoxButtons.OKCancel)
                   == DialogResult.OK)
                {
                    try
                    {
                        DataRowView dt = ((DataRowView)CTPNBindingSource[CTPNBindingSource.Position]);
                        mapn = dt["MAPN"].ToString();
                        mavattu = dt["MAVT"].ToString();
                        soluong = int.Parse(dt["SOLUONG"].ToString());
                        dongia = float.Parse(dt["DONGIA"].ToString());

                        CTPNBindingSource.RemoveCurrent();
                        this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.CTPNTableAdapter.Update(this.DSPHIEUNHAP.CTPN);
                        String query = string.Format("INSERT INTO DBO.CTPN(MAPN,MAVT,SOLUONG,DONGIA) " +
                                                    " VALUES('{0}','{1}',{2},{3})", mapn, mavattu, soluong, dongia);
                        Console.WriteLine(query);
                        stack2.Push(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa chi tiết phiếu nhập. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                        this.CTPNTableAdapter.Fill(this.DSPHIEUNHAP.CTPN);
                        this.CTPNTableAdapter.Fill(this.DSPHIEUNHAP.CTPN);
                        return;
                    }
                }
                if (CTPNBindingSource.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPN.Caption == "Chi tiết phiếu nhập")
            {
                vitri = phieuNhapBindingSource.Position;
                DataRowView dt = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position]);
                mapn = dt["MAPN"].ToString();
                ngay = (DateTime)dt["NGAY"];
                masoddh = dt["MasoDDH"].ToString();
                manv = (int)dt["MANV"];
                makho = dt["MAKHO"].ToString();
                panelControl2.Enabled = true;
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = false;
                btnGhiPN.Enabled = btnHuyPN.Enabled = true;
                phieuNhapGridControl.Enabled = false;
                barButtonPN.Enabled = false;
                check_them = false;
            }
            else
            {
                vitri = CTPNBindingSource.Position;
                DataRowView dt = ((DataRowView)CTPNBindingSource[CTPNBindingSource.Position]);
                mapn = dt["MAPN"].ToString();
                mavattu = dt["MAVT"].ToString();
                soluong = int.Parse(dt["SOLUONG"].ToString());
                dongia = float.Parse(dt["DONGIA"].ToString());
                panelControl2.Enabled = true;
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = false;
                btnGhiPN.Enabled = btnHuyPN.Enabled = true;
                cTPNGridControl.Enabled = false;
                barButtonPN.Enabled = false;
                check_them = false;
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPN.Caption == "Chi tiết phiếu nhập")
            {


                if (txtNGAY.Text.Trim() == "")
                {
                    MessageBox.Show("Ngày tạo phiếu nhập không được để trống!", "Thông báo", MessageBoxButtons.OK);
                    txtNGAY.Focus();
                    return;
                }
                if (txtDDH.Text.Trim() == "")
                {
                    MessageBox.Show("Mã số đơn đặt hàng không được để trống!", "Thông báo", MessageBoxButtons.OK);
                    txtDDH.Focus();
                    return;
                }
                if (txtDDH.Text.Length > 8)
                {
                    MessageBox.Show("Mã kho không thể lớn hơn 8 kí tự", "Thông báo", MessageBoxButtons.OK);
                    txtDDH.Focus();
                    return;
                }


                if (txtMAKHO.Text.Trim() == "")
                {
                    MessageBox.Show("Mã kho không được để trống!", "Thông báo", MessageBoxButtons.OK);
                    txtMAKHO.Focus();
                    return;
                }


                if (txtMAKHO.Text.Length > 4)
                {
                    MessageBox.Show("Mã kho không thể lớn hơn 4 kí tự", "Thông báo", MessageBoxButtons.OK);
                    txtMAKHO.Focus();
                    return;
                }


                if (check_them == true)
                {
                    String checkpn =
                      "EXEC [dbo].[sp_Check_Exists_Id_Char] 'PHIEUNHAP', 'MAPN' ,'" + txtMAPN.Text.Trim() + "'";
                    String checkddh =
                     "EXEC [dbo].[sp_Check_Exists_Id_Char] 'PHIEUNHAP', 'MasoDDH' ,'" + txtDDH.Text.Trim() + "'";
                    String checkddh1 =
                    "EXEC [dbo].[sp_Check_Exists_Id_Char] 'DatHang', 'MasoDDH' ,'" + txtDDH.Text.Trim() + "'";
                    String checkngay =
                   "EXEC [dbo].[sp_KiemTraNgayNhap] '" + txtDDH.Text.Trim() + "'" + ",'" + txtNGAY.Text + "'";
                   
                    Console.WriteLine(checkpn);
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkpn);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 1)
                        {

                            txtMAPN.Text = tuDongTangMa(txtMAPN.Text.Trim(), 2);
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

                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkddh1);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 0)
                        {
                            MessageBox.Show("Đơn đặt hàng này không tồn lại!", "Thông báo", MessageBoxButtons.OK);
                            txtDDH.Focus();
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


                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkddh);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 1)
                        {
                            MessageBox.Show("Đơn đặt hàng đã tồn tại phiếu nhập khác!", "Thông báo", MessageBoxButtons.OK);
                            txtDDH.Focus();
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
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkngay);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) <= 0)
                        {
                            MessageBox.Show("Ngày lập phiếu phải nhỏ hơn ngày lập đơn đặt hàng!", "Thông báo", MessageBoxButtons.OK);
                            txtNGAY.Focus();
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

                    if (masoddh.ToLower().Trim() != txtDDH.Text.ToString().Trim().ToLower())
                    {
                        String checkddh =
                        "EXEC [dbo].[sp_Check_Exists_Id_Char] 'PHIEUNHAP', 'MasoDDH' ,'" + txtDDH.Text.Trim() + "'";
                        String checkddh1 =
                        "EXEC [dbo].[sp_Check_Exists_Id_Char] 'DatHang', 'MasoDDH' ,'" + txtDDH.Text.Trim() + "'";
                        try
                        {
                            Program.myReader = Program.ExecSqlDataReader(checkddh1);
                            if (Program.myReader == null) { return; }
                            Program.myReader.Read();
                            if (Program.myReader.GetInt32(0) == 0)
                            {
                                MessageBox.Show("Đơn đặt hàng này không tồn lại!", "Thông báo", MessageBoxButtons.OK);
                                txtDDH.Focus();
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


                        try
                        {
                            Program.myReader = Program.ExecSqlDataReader(checkddh);
                            if (Program.myReader == null) { return; }
                            Program.myReader.Read();
                            if (Program.myReader.GetInt32(0) == 1)
                            {
                                MessageBox.Show("Đơn đặt hàng đã tồn tại phiếu nhập khác!", "Thông báo", MessageBoxButtons.OK);
                                txtDDH.Focus();
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
                    };


                    String checkngay =
                  "EXEC [dbo].[sp_KiemTraNgayNhap] '" + txtDDH.Text.Trim() + "'" + ",'" + txtNGAY.Text + "'";
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkngay);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) <= 0)
                        {
                            MessageBox.Show("Ngày lập phiếu phải nhỏ hơn ngày lập đơn đặt hàng!", "Thông báo", MessageBoxButtons.OK);
                            txtNGAY.Focus();
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






                    
                    String query = "";
                    phieuNhapBindingSource.EndEdit();
                    phieuNhapBindingSource.ResetCurrentItem();
                    this.phieuNhapTableAdapter.Update(this.DSPHIEUNHAP.PhieuNhap);

                    if (check_them)
                    {

                        query = "DELETE DBO.PHIEUNHAP WHERE MAPN = '" + txtMAPN.Text.Trim() + "'";

                    }
                    else
                    {
                        query = "UPDATE DBO.PHIEUNHAP " +
                               "SET " +
                               "MAPN = '" + mapn + "'," +
                               "NGAY = '" + ngay.ToString() + "'," +
                               "MasoDDH = '" + masoddh + "'," +
                               "MANV = " + manv + "," +
                               "MAKHO = '" + makho + "'" +
                               "WHERE MAPN = '" + mapn + "'";

                    }
                    Console.WriteLine(query);

                    stack.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                btnThemPN.Enabled = btnSuaPN.Enabled = btnXoaPN.Enabled = btnThoatPN.Enabled = btnReloadPN.Enabled = btnPhucHoiPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                panelControl2.Enabled = false;
                phieuNhapGridControl.Enabled = true;
                barButtonPN.Enabled = true;
            }
            else
            {
                if (check_them == true)
                {
                    if (txtMAVT.Text.Trim() == "")
                    {
                        MessageBox.Show("Mã vật tư không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        txtMAVT.Focus();
                        return;
                    }
                    if (txtSOLUONG.Text.Trim() == "")
                    {
                        MessageBox.Show("Số lượng không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        txtSOLUONG.Focus();
                        return;
                    }
                    if (txtDONGIA.Text.Trim() == "")
                    {
                        MessageBox.Show("Đơn giá không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        txtDONGIA.Focus();
                        return;
                    }

                    if (Regex.IsMatch(txtSOLUONG.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Số lượng chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                        txtSOLUONG.Focus();
                        return;
                    }

                    if (Regex.IsMatch(txtDONGIA.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Đơn giá chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                        txtDONGIA.Focus();
                        return;
                    }

                    if (int.Parse(txtSOLUONG.EditValue.ToString()) <= 0)
                    {
                        MessageBox.Show("Số lượng phải >0!", "Thông báo", MessageBoxButtons.OK);
                        txtSOLUONG.Focus();
                        return;
                    }
                    if (int.Parse(txtDONGIA.EditValue.ToString()) <= 0)
                    {
                        MessageBox.Show("Đơn giá phải >0!", "Thông báo", MessageBoxButtons.OK);
                        txtDONGIA.Focus();
                        return;
                    }
                    String checkvt =
                      "EXEC [dbo].[sp_Check_Exists_CT_Id_Char] 'CTPN', 'MAVT' ,'" + txtMAVT.Text.Trim() + "','MAPN','" + txtMAPN.Text.Trim() + "'";
                    Console.WriteLine(checkvt);
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkvt);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 1)
                        {

                            MessageBox.Show("Mã vật tư đã tồn tại ", "Thông báo", MessageBoxButtons.OK);
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
                    Console.WriteLine(234);
                    Console.WriteLine(mapn);
                    Console.WriteLine(txtMAPN.Text);
                    String query = "";
                    CTPNBindingSource.EndEdit();
                    CTPNBindingSource.ResetCurrentItem();
                    this.CTPNTableAdapter.Update(this.DSPHIEUNHAP.CTPN);
                   


                    if (check_them)
                    {

                        query = "DELETE DBO.CTPN WHERE MAPN = '" + txtMAPN.Text.Trim() + "' AND MAVT = '" + txtMAVT.Text.ToString() + "'";

                    }
                    else
                    {
                        query = "UPDATE DBO.CTPN " +
                               "SET " +
                               "MAPN = '" + mapn + "'," +
                               "MAVT = '" + mavattu + "'," +
                               "SOLUONG = " + soluong + "," +
                               "DONGIA = " + dongia + " " +
                               "WHERE MAPN = '" + txtMAPN.Text.Trim() + "' AND MAVT = '" + txtMAVT.Text.ToString() + "'";

                    }
                   
                    Console.WriteLine(query);

                    stack2.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết phiếu nhập \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                btnThemPN.Enabled = btnSuaPN.Enabled = btnXoaPN.Enabled = btnThoatPN.Enabled = btnReloadPN.Enabled = btnPhucHoiPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                panelControl2.Enabled = false;
                cTPNGridControl.Enabled = true;
                barButtonPN.Enabled = true;

            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPN.Caption == "Chi tiết phiếu nhập")
            {
                phieuNhapBindingSource.CancelEdit();
                this.phieuNhapTableAdapter.Fill(this.DSPHIEUNHAP.PhieuNhap);

                phieuNhapBindingSource.Position = vitri;
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                phieuNhapGridControl.Enabled = true;
                panelControl2.Enabled = false;
                barButtonPN.Enabled = true;

            }
            else
            {
                CTPNBindingSource.CancelEdit();
                this.CTPNTableAdapter.Fill(this.DSPHIEUNHAP.CTPN);
                CTPNBindingSource.Position = vitri;
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                cTPNGridControl.Enabled = true;
                panelControl2.Enabled = false;
                barButtonPN.Enabled = true;

            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPN.Caption == "Chi tiết phiếu nhập")
            {
                if (stack.Count == 0)
                {
                    MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                    ; return;
                }


                string query = stack.Pop();
                Program.ExecSqlNonQuery(query);

                this.phieuNhapTableAdapter.Fill(this.DSPHIEUNHAP.PhieuNhap);

               
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                phieuNhapGridControl.Enabled = true;
            }
            else
            {
                if (stack2.Count == 0)
                {
                    MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                    ; return;
                }


                string query = stack2.Pop();
                Program.ExecSqlNonQuery(query);

                this.CTPNTableAdapter.Fill(this.DSPHIEUNHAP.CTPN);

                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = btnPhucHoiPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                cTPNGridControl.Enabled = true;
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuNhapTableAdapter.Fill(this.DSPHIEUNHAP.PhieuNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload !" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup != "CONGTY")
            {
                btnThemPN.Enabled = btnXoaPN.Enabled = btnSuaPN.Enabled = btnReloadPN.Enabled = btnThoatPN.Enabled = true;
                btnGhiPN.Enabled = btnHuyPN.Enabled = false;
                txtNGAY.Visible = txtDDH.Visible = txtMANV.Visible = txtMAKHO.Visible = !txtMAKHO.Visible;
                lbNGAY.Visible = lbMasoDDH.Visible = lbMANV.Visible = lbMAKHO.Visible = TTKHOComboBox.Visible = !lbMAKHO.Visible;
                txtMAVT.Visible = txtSOLUONG.Visible = txtDONGIA.Visible = TTVTComboBox.Visible = !txtDONGIA.Visible;
                lbMAVT.Visible = lbSOLUONG.Visible = lbDONGIA.Visible = !lbDONGIA.Visible;
            }
            cTPNGridControl.Enabled = !cTPNGridControl.Enabled;
            phieuNhapGridControl.Enabled = !phieuNhapGridControl.Enabled;
            barButtonPN.ItemAppearance.Normal.BackColor = txtMANV.Visible == true ? Color.Pink : Color.Tan;
            panelControl2.Enabled = false;
            barButtonPN.Caption = txtMANV.Visible == true ? "Chi tiết phiếu nhập" : "Phiếu nhập";
        }

        

    }
}
