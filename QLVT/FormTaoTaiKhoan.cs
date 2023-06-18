using DevExpress.Xpo.DB.Helpers;
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
using System.Windows.Media;
using static DevExpress.Data.Helpers.FindSearchRichParser;

namespace QLVT
{
    public partial class FormTaoTaiKhoan : Form
    {

        int vitri = 0;

        bool check_them = true;

        int user = 0;
        String login = "";
        int manv;
        String pass = "";
        String group = "";

        public FormTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {


            DS1.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);

            // TODO: This line of code loads data into the 'DS1.USER' table. You can move, or remove it, as needed.
            this.uSERTableAdapter.Connection.ConnectionString = Program.connstr;
            this.uSERTableAdapter.Fill(this.DS1.USER);
            // TODO: This line of code loads data into the 'DS1.GROUP' table. You can move, or remove it, as needed.
            this.gROUPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gROUPTableAdapter.Fill(this.DS1.GROUP);

            // TODO: This line of code loads data into the 'DS1.LOGIN' table. You can move, or remove it, as needed.
            this.lOGINTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOGINTableAdapter.Fill(this.DS1.LOGIN);

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(Program.mloginDN);
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            if (LOGINNAME.Text.ToString() != "")
            {
                MessageBox.Show("Nhân viên này đã có tài khoản", "", MessageBoxButtons.OK);
                return;
            }

            if (TRANGTHAIXOA.Checked == true)
            {
                MessageBox.Show("Nhân viên này có trạng thái là xóa nên không thể tạo tài khoản", "", MessageBoxButtons.OK);
                return;
            }
            if (Program.mGroup == "CHINHANH")
            {
                GROUPP.Items.Clear();
                GROUPP.Items.Add("CHINHANH");
                GROUPP.Items.Add("USER");
            }
            else if (Program.mGroup == "CONGTY")
            {
                GROUPP.Items.Clear();
                GROUPP.Items.Add("CONGTY");
            }    
            vitri = nhanVienBindingSource.Position;
            panelControl2.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = true;
            nhanVienGridControl.Enabled = false;
            check_them = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            gROUPBindingSource.CancelEdit();
            lOGINBindingSource.CancelEdit();
            nhanVienBindingSource.Position = vitri;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = false;
            nhanVienGridControl.Enabled = true;
            loginnameOld.Visible =  false;

            
        }
        private void btnReload_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                this.uSERTableAdapter.Fill(this.DS1.USER);
                this.gROUPTableAdapter.Fill(this.DS1.GROUP);
                this.lOGINTableAdapter.Fill(this.DS1.LOGIN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload !" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            if (LOGINNAME.Text.ToString() == "")
            {
                MessageBox.Show("Nhân viên này chưa có tài khoản !", "", MessageBoxButtons.OK);
                return;
            }

            if (LOGINNAME.Text.ToString().Trim().ToUpper() == Program.mloginDN.ToUpper())
            {
                MessageBox.Show("Không thể xóa tài khoản đang hoạt động !", "", MessageBoxButtons.OK);
                return;
            }

            if (Program.mGroup.ToUpper() == "CONGTY" && GROUPP.Text.ToString().Trim().ToUpper() != Program.mGroup.ToUpper())
            {
                MessageBox.Show("Quyền hạn của bạn không thể xóa tài khoản này !", "", MessageBoxButtons.OK);
                return;
            }
            if (Program.mGroup.ToUpper() == "CHINHANH" && GROUPP.Text.ToString().Trim().ToUpper() == "CONGTY")
            {
                MessageBox.Show("Quyền hạn của bạn không thể xóa tài khoản này !", "", MessageBoxButtons.OK);
                return;
            }
            login = LOGINNAME.Text.ToString().Trim();
            group = GROUPP.Text.ToString().Trim();

            if (MessageBox.Show("Bạn có thực sự muốn xóa tài khoản nhân viên này!", "Xác nhận", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                try
                {
                    
                    String query = String.Format("exec sp_Drop_Account '{0}', '{1}', {2}", LOGINNAME.Text.ToString().Trim(), GROUPP.Text.ToString().Trim(), MANV.Text.ToString());
                    
                    Console.WriteLine(query);

                    Program.ExecSqlNonQuery(query);
                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    this.uSERTableAdapter.Fill(this.DS1.USER);
                    this.gROUPTableAdapter.Fill(this.DS1.GROUP);
                    this.lOGINTableAdapter.Fill(this.DS1.LOGIN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa tài khoản nhân viên. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    nhanVienBindingSource.Position = nhanVienBindingSource.Find("MANV", manv);
                    return;
                }
            }
            


        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            if (GROUPP.Text.Trim() == "")
            {
                MessageBox.Show("Quyền không được bỏ trống!", "", MessageBoxButtons.OK);
                GROUPP.Focus();
                return;
            }
            if (LOGINNAME.Text.Trim() == "")
            {
                MessageBox.Show("Login name không được để trống!", "", MessageBoxButtons.OK);
                LOGINNAME.Focus();
                return;
            }

            if (Regex.IsMatch(LOGINNAME.Text, @"^[a-zA-Z ]+$") == false)
            {
                MessageBox.Show("Login name chỉ có chữ cái tiếng anh và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                LOGINNAME.Focus();
                return;
            }

            if (PASSWORD.Text.Trim() == "")
            {
                MessageBox.Show("Password không được để trống!", "", MessageBoxButtons.OK);
                PASSWORD.Focus();
                return;
            }

            String checklogin =
                  "DECLARE	@result int " +
                  "EXEC @result = [dbo].[sp_Check_Exists_Login] " +
                  LOGINNAME.Text.Trim().ToUpper() +
                  "  SELECT 'result' = @result";
            Console.WriteLine(checklogin);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(checklogin);
                if (Program.myReader == null) { return; }
                Program.myReader.Read();
                if (Program.myReader.GetInt32(0) == 1)
                {
                    MessageBox.Show("Login name đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    LOGINNAME.Focus();
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


            if (check_them == true)
            {
                Console.WriteLine(Program.mloginDN);
                try
                {

                    String query = String.Format("exec sp_Create_Account '{0}', '{1}', '{2}', {3}",
                        LOGINNAME.Text.ToString().Trim(), PASSWORD.Text.ToString(), GROUPP.Text.ToString().Trim(), MANV.Text.ToString());

                    Console.WriteLine(query);
                    Program.ExecSqlNonQuery(query);

                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    this.uSERTableAdapter.Fill(this.DS1.USER);
                    this.gROUPTableAdapter.Fill(this.DS1.GROUP);
                    this.lOGINTableAdapter.Fill(this.DS1.LOGIN);

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = false;
                    nhanVienGridControl.Enabled = true;
                    loginnameOld.Visible =  false;
                    nhanVienBindingSource.Position = vitri;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo tài khoản nhân viên. Bạn hãy tạo lại \n" + ex.Message, "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    nhanVienBindingSource.Position = nhanVienBindingSource.Find("MANV", manv);
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = false;
                    nhanVienGridControl.Enabled = true;
                    loginnameOld.Visible  = false;
                    nhanVienBindingSource.Position = vitri;
                    return;
                }

            }

            else
            {
                Console.WriteLine(Program.mloginDN);
                try
                {

                    String query = String.Format("exec sp_Alter_Account '{0}', '{1}', '{2}'",
                        loginnameOld.Text.ToString().Trim(),LOGINNAME.Text.ToString().Trim(), PASSWORD.Text.ToString());

                    Console.WriteLine(query);
                    Program.ExecSqlNonQuery(query);

                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    this.uSERTableAdapter.Fill(this.DS1.USER);
                    this.gROUPTableAdapter.Fill(this.DS1.GROUP);
                    this.lOGINTableAdapter.Fill(this.DS1.LOGIN);

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = false;
                    nhanVienGridControl.Enabled = true;
                    loginnameOld.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa tài khoản nhân viên. Bạn hãy tạo lại \n" + ex.Message, "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    nhanVienBindingSource.Position = nhanVienBindingSource.Find("MANV", manv);
                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = false;
                    nhanVienGridControl.Enabled = true;
                    loginnameOld.Visible = false;
                    return;
                }

            }

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != Program.mloginDN)
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản ở site khác, vui lòng chọn lại site của bạn", "", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            if (Program.mGroup.ToUpper() == "CONGTY" && GROUPP.Text.ToString().Trim().ToUpper() != Program.mGroup.ToUpper())
            {
                MessageBox.Show("Quyền hạn của bạn không thể sửa tài khoản này !", "", MessageBoxButtons.OK);
                return;
            }
            if (Program.mGroup.ToUpper() == "CHINHANH" && GROUPP.Text.ToString().Trim().ToUpper() == "CONGTY")
            {
                MessageBox.Show("Quyền hạn của bạn không thể sửa tài khoản này !", "", MessageBoxButtons.OK);
                return;
            }
            if (LOGINNAME.Text.ToString() == "")
            {
                MessageBox.Show("Nhân viên này chưa có tài khoản !", "", MessageBoxButtons.OK);
                return;
            }
            vitri = nhanVienBindingSource.Position;
            panelControl2.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = GROUPP.Enabled = LOGINNAME.Enabled = PASSWORD.Visible = passLabel.Visible = true;
            nhanVienGridControl.Enabled = GROUPP.Enabled = false;
            loginnameOld.Visible  = true;
            check_them = false;
        }

        
    }
}
