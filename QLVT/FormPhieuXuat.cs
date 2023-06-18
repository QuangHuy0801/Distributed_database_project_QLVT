using DevExpress.XtraRichEdit.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Data.Helpers.FindSearchRichParser;

namespace QLVT
{
    public partial class FormPhieuXuat : Form
    {
        int vitri = 0;

        bool check_them = true;

        String mapx;
        DateTime ngay;
        String hotenKH;
        int manv;
        String makho;
        String mavattu;
        int soluong;
        float dongia;

        Stack<String> stack = new Stack<String>();
        Stack<String> stack2 = new Stack<String>();

        public FormPhieuXuat()
        {
            InitializeComponent();
        }

        //private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        //{
        //    this.Validate();
        //    this.phieuXuatBindingSource.EndEdit();
        //    this.tableAdapterManager.UpdateAll(this.DSPHIEUXUAT);
        //}

        //private Form CheckExists(Type ftype)
        //{
        //    foreach (Form f in this.MdiChildren)
        //        if (f.GetType() == ftype)
        //            return f;
        //    return null;
        //}
        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSPHIEUNHAP.CTPN' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DSPHIEUXUAT.ThongTinVatTu' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DSPHIEUXUAT.ThongTinKho' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DSPHIEUXUAT.NhanVien' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DSPHIEUXUAT.vw_DSNV' table. You can move, or remove it, as needed.

            DSPHIEUXUAT.EnforceConstraints = false;
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);
            this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DSPHIEUXUAT.NhanVien);
            this.thongTinKhoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.thongTinKhoTableAdapter.Fill(this.DSPHIEUXUAT.ThongTinKho);
            this.thongTinVatTuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.thongTinVatTuTableAdapter.Fill(this.DSPHIEUXUAT.ThongTinVatTu);

            // Van con loi, tu xu li, thay k sua, thay se check khi thi
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;

            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnGhiPX.Enabled = btnHuyPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnReloadPX.Enabled = btnThoatPX.Enabled = true;
            }
            else
            {
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                cbChiNhanh.Enabled = false;
            }

            // bat tat phan quyen - chua phan quyen cho nhom khác


        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (Program.mGroup != "CONGTY")
            {
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                NGAY1.Visible = HOTEN1.Visible = MANV1.Visible = MAKHO1.Visible =  !MAKHO1.Visible;
                lbNGAY.Visible = lbHOTEN.Visible = lbMANV.Visible = lbMAKHO.Visible = ttkComboBox.Visible = !lbMAKHO.Visible;
                MAVT1.Visible = SOLUONG1.Visible = DONGIA1.Visible = ttvtComboBox.Visible = !DONGIA1.Visible;
                lbMAVT.Visible = lbSOLUONG.Visible = lbDONGIA.Visible = !lbDONGIA.Visible;
            }
            cTPXGridControl.Enabled = !cTPXGridControl.Enabled;
            phieuXuatGridControl.Enabled = !phieuXuatGridControl.Enabled; 
            barButtonPX.ItemAppearance.Normal.BackColor = MANV1.Visible == true ? Color.Pink : Color.Tan;
            panelControl2.Enabled = false;
            barButtonPX.Caption = MANV1.Visible == true ? "Chi tiết phiếu xuất" : "Phiếu xuất";

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phieuXuatGridControl_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPX.Caption == "Chi tiết phiếu xuất")
            {
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                phieuXuatGridControl.Enabled = false;
                check_them = true;
                panelControl2.Enabled = true;
                vitri = phieuXuatBindingSource.Position;
                barButtonPX.Enabled = false;
                phieuXuatBindingSource.AddNew();
                string getMaxIdQuery = "EXEC [dbo].[sp_Get_Max_Id] 'PHIEUXUAT', 'MAPX'";
                string maphieuxxuat = "";
                MANV1.Text = Program.username.ToString();
                Console.WriteLine(getMaxIdQuery);
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(getMaxIdQuery);
                    if (Program.myReader == null) { return; }
                    Program.myReader.Read();
                    if (Program.myReader.GetString(0) == "NULL")
                    {
                        MAPX1.Text = "PX01";
                        Program.myReader.Close();
                    }
                    else
                    {
                        maphieuxxuat = tuDongTangMa(Program.myReader.GetString(0), 2);
                        MAPX1.Text = maphieuxxuat;
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
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                check_them = true;
                vitri = CTPXBindingSource.Position;
                panelControl2.Enabled = true;
                cTPXGridControl.Enabled = false;
                barButtonPX.Enabled = false;
                CTPXBindingSource.AddNew();
            } 
                
            
         }    
        
 

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            this.Close();
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPX.Caption == "Chi tiết phiếu xuất")
            {
                phieuXuatBindingSource.CancelEdit();
                this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);

                phieuXuatBindingSource.Position = vitri;
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                phieuXuatGridControl.Enabled = true;
                panelControl2.Enabled = false;
                barButtonPX.Enabled = true;

            }
            else
            {
                CTPXBindingSource.CancelEdit();
                this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);
                CTPXBindingSource.Position = vitri;
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                cTPXGridControl.Enabled = true;
                panelControl2.Enabled = false;
                barButtonPX.Enabled = true;

            }

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload !" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
              
            if (barButtonPX.Caption == "Chi tiết phiếu xuất")
            {
                if (phieuXuatBindingSource.Count == 0)
                {
                    MessageBox.Show("Danh sách phiếu xuất trống!", "", MessageBoxButtons.OK);
                    return;
                }
                vitri = phieuXuatBindingSource.Position;
                DataRowView dt = ((DataRowView)phieuXuatBindingSource[phieuXuatBindingSource.Position]);
                mapx = dt["MAPX"].ToString();
                ngay = (DateTime)dt["NGAY"];
                hotenKH = dt["HOTENKH"].ToString();
                manv = (int)dt["MANV"];
                makho = dt["MAKHO"].ToString();
                panelControl2.Enabled = true;
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                phieuXuatGridControl.Enabled = false;
                barButtonPX.Enabled = false;
                check_them = false;
            }
            else
            {
                if (CTPXBindingSource.Count == 0)
                {
                    MessageBox.Show("Danh sách chi tiết phiếu xuất trống!", "", MessageBoxButtons.OK);
                    return;
                }
                vitri = CTPXBindingSource.Position;
                DataRowView dt = ((DataRowView)CTPXBindingSource[CTPXBindingSource.Position]);
                mapx = dt["MAPX"].ToString();
                mavattu = dt["MAVT"].ToString();
                soluong = int.Parse(dt["SOLUONG"].ToString());
                dongia = float.Parse(dt["DONGIA"].ToString());
                panelControl2.Enabled = true;
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = false;
                btnGhiPX.Enabled = btnHuyPX.Enabled = true;
                cTPXGridControl.Enabled = false;
                barButtonPX.Enabled = false;
                check_them = false;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPX.Caption == "Chi tiết phiếu xuất")
            {
                if (phieuXuatBindingSource.Count == 0)
                {
                    MessageBox.Show("Danh sách phiếu xuất trống!", "", MessageBoxButtons.OK);
                    return;
                }
                if (CTPXBindingSource.Count > 0)

                {
                    MessageBox.Show("Không thể xóa phiếu xuất này vì đã có chi tiết phiếu xuất!", "", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có thực sự muốn xóa phiếu xuất này!", "Xác nhận", MessageBoxButtons.OKCancel)
                   == DialogResult.OK)
                {
                    try
                    {
                        DataRowView dt = ((DataRowView)phieuXuatBindingSource[phieuXuatBindingSource.Position]);
                        mapx = dt["MAPX"].ToString();
                        ngay = (DateTime)dt["NGAY"];
                        hotenKH = dt["HOTENKH"].ToString();
                        manv = (int)dt["MANV"];
                        makho = dt["MAKHO"].ToString();

                        phieuXuatBindingSource.RemoveCurrent();
                        this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.phieuXuatTableAdapter.Update(this.DSPHIEUXUAT.PhieuXuat);
                        String query = string.Format("INSERT INTO DBO.PHIEUXUAT(MAPX,NGAY,HOTENKH,MANV,MAKHO) " +
                                                    " VALUES('{0}','{1}',N'{2}',{3}, '{4}')", mapx, ngay, hotenKH, manv, makho);
                        Console.WriteLine(query);
                        stack.Push(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa phiếu xuất. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                        this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);
                        phieuXuatBindingSource.Position = phieuXuatBindingSource.Find("MAPX", mapx);
                        return;
                    }
                }
                if (phieuXuatBindingSource.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
            }
        else
            {
                if (CTPXBindingSource.Count == 0)
                {
                    MessageBox.Show("Danh sách chi tiết phiếu xuất trống!", "", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show("Bạn có thực sự muốn xóa chi tiết phiếu xuất này!", "Xác nhận", MessageBoxButtons.OKCancel)
                   == DialogResult.OK)
                {
                    try
                    {
                        DataRowView dt = ((DataRowView)CTPXBindingSource[CTPXBindingSource.Position]);
                        mapx = dt["MAPX"].ToString();
                        mavattu = dt["MAVT"].ToString();
                        soluong = int.Parse(dt["SOLUONG"].ToString());
                        dongia = float.Parse(dt["SOLUONG"].ToString());

                        CTPXBindingSource.RemoveCurrent();
                        this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.CTPXTableAdapter.Update(this.DSPHIEUXUAT.CTPX);
                        String query = string.Format("INSERT INTO DBO.CTPX(MAPX,MAVT,SOLUONG,DONGIA) " +
                                                    " VALUES('{0}','{1}',{2},{3})", mapx, mavattu, soluong, dongia);
                        Console.WriteLine(query);
                        stack2.Push(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa chi tiết phiếu xuất. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                        this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);
                        this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);
                        return;
                    }
                }
                if (CTPXBindingSource.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
            }    
     }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPX.Caption == "Chi tiết phiếu xuất")
            {
                if (NGAY1.Text.Trim() == "")
                {
                    MessageBox.Show("Ngày tạp phiếu xuất không được để trống!", "Thông báo", MessageBoxButtons.OK);
                    NGAY1.Focus();
                    return;
                }
                if (HOTEN1.Text.Trim() == "")
                {
                    MessageBox.Show("Họ tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK);
                    HOTEN1.Focus();
                    return;
                }
                if (HOTEN1.Text.Length > 100)
                {
                    MessageBox.Show("Họ tên khách hàng không thể lớn hơn 100 kí tự", "Thông báo", MessageBoxButtons.OK);
                    HOTEN1.Focus();
                    return;
                }

                if (Regex.IsMatch(HOTEN1.Text, @"^[a-zA-Z ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+$") == false)
                {
                    MessageBox.Show("Họ chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                    HOTEN1.Focus();
                    return;
                }

                if (MAKHO1.Text.Trim() == "")
                {
                    MessageBox.Show("Mã kho không được để trống!", "Thông báo", MessageBoxButtons.OK);
                    MAKHO1.Focus();
                    return;
                }


                if (MAKHO1.Text.Length > 4)
                {
                    MessageBox.Show("Mã kho không thể lớn hơn 4 kí tự", "Thông báo", MessageBoxButtons.OK);
                    MAKHO1.Focus();
                    return;
                }


                if (check_them == true)
                {
                    String checkpx =
                      "EXEC [dbo].[sp_Check_Exists_Id_Char] 'PHIEUXUAT', 'MAPX' ,'" + MAPX1.Text.Trim() + "'";
                    // string getMaxIdQuery = "EXEC [dbo].[sp_Get_Max_Id_Char] 'PHIEUXUAT', 'MAPX'";
                    Console.WriteLine(checkpx);
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(checkpx);
                        if (Program.myReader == null) { return; }
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 1)
                        {

                            MAPX1.Text = tuDongTangMa(MAPX1.Text.Trim(), 2);
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
                    phieuXuatBindingSource.EndEdit();
                    phieuXuatBindingSource.ResetCurrentItem();
                    this.phieuXuatTableAdapter.Update(this.DSPHIEUXUAT.PhieuXuat);

                    if (check_them)
                    {

                        query = "DELETE DBO.PHIEUXUAT WHERE MAPX = '" + MAPX1.Text.Trim() + "'";

                    }
                    else
                    {
                        query = "UPDATE DBO.PHIEUXUAT " +
                               "SET " +
                               "MAPX = '" + mapx + "'," +
                               "NGAY = '" + ngay.ToString() + "'," +
                               "HOTENKH = N'" + hotenKH + "'," +
                               "MANV = " + manv + "," +
                               "MAKHO = '" + makho + "'" +
                               "WHERE MAPX = '" + mapx + "'";

                    }
                    Console.WriteLine(query);

                    stack.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                btnThemPX.Enabled = btnSuaPX.Enabled = btnXoaPX.Enabled = btnThoatPX.Enabled = btnReloadPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                panelControl2.Enabled = false;
                phieuXuatGridControl.Enabled = true;
                barButtonPX.Enabled = true;
            }
            else
            {
   
                    if (MAVT1.Text.Trim() == "")
                    {
                        MessageBox.Show("Ngày lạp phiếu xuất không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        MAVT1.Focus();
                        return;
                    }
                    if (SOLUONG1.Text.Trim() == "")
                    {
                        MessageBox.Show("Số lượng không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        SOLUONG1.Focus();
                        return;
                    }
                    if (DONGIA1.Text.Trim() == "")
                    {
                        MessageBox.Show("Đơn giá không được để trống!", "Thông báo", MessageBoxButtons.OK);
                        DONGIA1.Focus();
                        return;
                    }

                    if (Regex.IsMatch(SOLUONG1.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Số lượng chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                        SOLUONG1.Focus();
                        return;
                    }

                    if (Regex.IsMatch(DONGIA1.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Đơn giá chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                        DONGIA1.Focus();
                        return;
                    }

                    if (int.Parse(SOLUONG1.EditValue.ToString()) <= 0)
                    {
                        MessageBox.Show("Số lượng phải >0!", "Thông báo", MessageBoxButtons.OK);
                        SOLUONG1.Focus();
                        return;
                    }
                    if (int.Parse(DONGIA1.EditValue.ToString()) <= 0)
                    {
                        MessageBox.Show("Đơn giá phải >0!", "Thông báo", MessageBoxButtons.OK);
                        DONGIA1.Focus();
                        return;
                    }

                if (check_them == true || mavattu != MAVT1.Text.ToString())
                {
                    String checkvt =
                      "EXEC [dbo].[sp_Check_Exists_CT_Id_Char] 'CTPX', 'MAVT' ,'" + MAVT1.Text.Trim() + "','MAPX','" + MAPX1.Text.Trim() + "'";
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
                    String query = "";
                    CTPXBindingSource.EndEdit();
                    CTPXBindingSource.ResetCurrentItem();
                    this.CTPXTableAdapter.Update(this.DSPHIEUXUAT.CTPX);

                    if (check_them)
                    {

                        query = "DELETE DBO.CTPX WHERE MAPX = '" + MAPX1.Text.Trim() + "' AND MAVT = '" + MAVT1.Text.ToString() + "'";

                    }
                    else
                    {
                        query = "UPDATE DBO.CTPX " +
                               "SET " +
                               "MAPX = '" + mapx + "'," +
                               "MAVT = '" + mavattu + "'," +
                               "SOLUONG = " + soluong + "," +
                               "DONGIA = " + dongia + " " +
                               "WHERE MAPX = '" + MAPX1.Text.Trim() + "' AND MAVT = '" + MAVT1.Text.ToString() + "'";

                    }
                    Console.WriteLine(query);

                    stack2.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết phiếu xuất \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                btnThemPX.Enabled = btnSuaPX.Enabled = btnXoaPX.Enabled = btnThoatPX.Enabled = btnReloadPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                panelControl2.Enabled = false;
                cTPXGridControl.Enabled = true;
                barButtonPX.Enabled = true;

            }


        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonPX.Caption == "Chi tiết phiếu xuất")
            {
                if (stack.Count == 0)
                {
                    MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                    ; return;
                }


                string query = stack.Pop();
                Program.ExecSqlNonQuery(query);

                this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);

                phieuXuatGridControl.Enabled = true;
                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                phieuXuatGridControl.Enabled = true;
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

                this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);

                btnThemPX.Enabled = btnXoaPX.Enabled = btnSuaPX.Enabled = btnReloadPX.Enabled = btnThoatPX.Enabled = btnPhucHoiPX.Enabled = true;
                btnGhiPX.Enabled = btnHuyPX.Enabled = false;
                cTPXGridControl.Enabled = true;
            }    
        }

        //private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    Console.WriteLine(cbChiNhanh.SelectedValue.ToString());

        //    if (cbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
        //        return;
        //    Program.servername = cbChiNhanh.SelectedValue.ToString();

        //    if (cbChiNhanh.SelectedIndex != Program.mChinhNhanh)
        //    {
        //        Program.mlogin = Program.remotelogin;
        //        Program.password = Program.remotepassword;

        //    }
        //    else
        //    {
        //        Program.mlogin = Program.mloginDN;
        //        Program.password = Program.passwordDN;

        //    }

        //    if (Program.KetNoi() == 0)
        //    {
        //        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);

        //    }

        //    else
        //    {
        //        this.phieuXuatGridControl.Enabled = false;
        //        this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
        //        this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);
        //        this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
        //        this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);
        //        this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
        //        this.nhanVienTableAdapter.Fill(this.DSPHIEUXUAT.NhanVien);
        //        this.phieuXuatGridControl.Enabled = true;

        //    }
        //}

        private void tTKHOComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ttkComboBox.SelectedValue != null) MAKHO1.Text = ttkComboBox.SelectedValue.ToString();

            }
            catch { }
        }

        private void tTCVTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ttvtComboBox.SelectedValue != null) MAVT1.Text = ttvtComboBox.SelectedValue.ToString();

            }
            catch { }
        }


        private void MAPX_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ttkComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ttkComboBox.SelectedValue != null) MAKHO1.Text = ttkComboBox.SelectedValue.ToString();

            }
            catch { }
        }

        private void ttvtComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ttvtComboBox.SelectedValue != null) MAVT1.Text = ttvtComboBox.SelectedValue.ToString();

            }
            catch { }
        }

        private void cbChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
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
                this.phieuXuatGridControl.Enabled = false;
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DSPHIEUXUAT.PhieuXuat);
                this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTPXTableAdapter.Fill(this.DSPHIEUXUAT.CTPX);
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DSPHIEUXUAT.NhanVien);
                this.phieuXuatGridControl.Enabled = true;

            }
        }
    }
}
