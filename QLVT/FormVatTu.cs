using DevExpress.CodeParser.Diagnostics;
using DevExpress.DataAccess.Wizard.Model;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace QLVT
{
    public partial class FormVatTu : Form
    {
        int vitri = 0;

        bool check_them = true;

        String mavt;
        String tenvt;
        String donvitinh;
        int soluongton;
        
        Stack<String> stack = new Stack<String>();
        public FormVatTu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVATTU.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSVATTU);

        }

        private void FormVatTu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSVATTU.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Fill(this.dSVATTU.CTPX);
            // TODO: This line of code loads data into the 'dSVATTU.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Fill(this.dSVATTU.CTPN);
            // TODO: This line of code loads data into the 'dSVATTU.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.dSVATTU.CTDDH);

            dSVATTU.EnforceConstraints = false;
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dSVATTU.Vattu);
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dSVATTU.CTDDH);
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dSVATTU.CTPN);
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.dSVATTU.CTPX);

            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;


            //bat tat phan quyen
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
                btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = btnGhiVT.Enabled = btnHuyVT.Enabled = btnPhucHoiVT.Enabled = false;
                btnReloadVT.Enabled = btnThoatVT.Enabled = true;


            }
            else
            {
                btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = btnReloadVT.Enabled = btnThoatVT.Enabled = btnPhucHoiVT.Enabled = true;
                btnGhiVT.Enabled = btnHuyVT.Enabled = false;
                cbChiNhanh.Enabled = false;
            }

        }

        private void btnThemVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMAVT.Enabled = true;
            btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = btnReloadVT.Enabled = btnThoatVT.Enabled = btnPhucHoiVT.Enabled = false;
            btnGhiVT.Enabled = btnHuyVT.Enabled = true;
            check_them = true;
            vitri = bdsVATTU.Position;
            panelControl2.Enabled = true;
            vattuGridControl.Enabled = false;
            barButtonPN.Enabled = false;
            bdsVATTU.AddNew();
        }

        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra txtMAKHO*/
            if (txtMAVT.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã vật tư", "Thông báo", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return false;
            }

            if (Regex.IsMatch(txtMAVT.Text, @"^[a-zA-Z0-9 ]+$") == false)
            {
                MessageBox.Show("Mã vật tư chỉ chấp nhận chữ và số", "Thông báo", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return false;
            }

            if (txtMAVT.Text.Length > 4)
            {
                MessageBox.Show("Mã vật tư không thể lớn hơn 4 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return false;
            }
            /*kiem tra txtTenKho*/
            if (txtTENVT.Text == "")
            {
                MessageBox.Show("Không bỏ trống tên vật tư", "Thông báo", MessageBoxButtons.OK);
                txtTENVT.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTENVT.Text, @"^[a-zA-Z0-9 ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+$") == false)
            {
                MessageBox.Show("Tên vật tư chỉ chấp nhận chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTENVT.Focus();
                return false;
            }

            if (txtTENVT.Text.Length > 30)
            {
                MessageBox.Show("Tên vật tư không thể quá 30 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTENVT.Focus();
                return false;
            }
            /*kiem tra txtDiaChi*/
            if (txtDVT.Text == "")
            {
                MessageBox.Show("Không bỏ trống đơn vị tính của vật tư", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }

            if (Regex.IsMatch(txtDVT.Text, @"^[a-zA-Z0-9 ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ,-]+$") == false)
            {
                MessageBox.Show("Đơn vị tính gồm chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }

            if (txtDVT.Text.Length > 15)
            {
                MessageBox.Show("Đơn vị tính không quá 15 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }
            if (Regex.IsMatch(txtSOLUONGTON.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số lượng chỉ bao gồm chữ số!", "Thông báo", MessageBoxButtons.OK);
                txtSOLUONGTON.Focus();
                return false;
            }
           

            return true;
        }

        private void btnGhiVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!kiemTraDuLieuDauVao()) return;
            if (check_them)
            {
                String checkvt =
                      "EXEC [dbo].[sp_Check_Exists_Id_Char] 'Vattu', 'MAVT' ,'" + txtMAVT.Text.Trim() + "'";
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(checkvt);
                    if (Program.myReader == null) { return; }
                    Program.myReader.Read();
                    if (Program.myReader.GetInt32(0) == 1)
                    {
                        MessageBox.Show("Vật tư đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                        txtMAVT.Focus();
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
                bdsVATTU.EndEdit();
                bdsVATTU.ResetCurrentItem();
                this.vattuTableAdapter.Update(this.dSVATTU.Vattu);
              
                if (check_them)
                {

                    query = "DELETE DBO.Vattu WHERE MAVT = " + "'" + txtMAVT.Text.Trim() + "'";

                }
                else
                {
                    query = "UPDATE DBO.Vattu " +
                                "SET " +
                                "TENVT = '" + tenvt + "'," +
                                "DVT = '" + donvitinh + "'" +
                                "SOLUONGTON = '" + soluongton + "'" +
                                "WHERE MAVT = '" + mavt + "'";

                }
                stack.Push(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi vật tư \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            btnThemVT.Enabled = btnSuaVT.Enabled = btnXoaVT.Enabled = btnThoatVT.Enabled = btnReloadVT.Enabled = btnPhucHoiVT.Enabled = true;
            btnGhiVT.Enabled = btnHuyVT.Enabled = false;
            panelControl2.Enabled = false;
            vattuGridControl.Enabled = true;
           

        }

        private void btnXoaVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTDDH.Count > 0 )

            {
                MessageBox.Show("Không thể xóa vật tư này vì đã có chi tiết đơn đặt hàng!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsCTPN.Count > 0)

            {
                MessageBox.Show("Không thể xóa vật tư này vì đã có chi tiết phiếu nhập!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsCTPX.Count > 0)

            {
                MessageBox.Show("Không thể xóa vật tư này vì đã có chi tiết phiếu xuất!", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa vật tư này!", "Xác nhận", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {
                try
                {
                    DataRowView dt = ((DataRowView)bdsVATTU[bdsVATTU.Position]);
                    mavt = dt["MAVT"].ToString();
                    tenvt = dt["TENVT"].ToString();
                   donvitinh = dt["DVT"].ToString();
                    soluongton = int.Parse(dt["SOLUONGTON"].ToString());


                    bdsVATTU.RemoveCurrent();
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.dSVATTU.Vattu);
                    String query = string.Format("INSERT INTO DBO.Vattu(MAVT,TENVT,DVT,SOLUONGTON) " +
                                                " VALUES('{0}','{1}',N'{2}',{3})", mavt, tenvt, donvitinh, soluongton);
                    Console.WriteLine(query);
                    stack.Push(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa vật tư. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                    this.vattuTableAdapter.Fill(this.dSVATTU.Vattu);
                    bdsVATTU.Position = bdsVATTU.Find("MAVT", mavt);
                    return;
                }
            }
            if (bdsVATTU.Count == 0)
            {
                btnXoaVT.Enabled = false;
            }
            btnGhiVT.Enabled = btnHuyVT.Enabled = false;
        }

        private void btnSuaVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVATTU.Position;
            DataRowView dt = ((DataRowView)bdsVATTU[bdsVATTU.Position]);
            mavt = dt["MAVT"].ToString();
            tenvt = dt["TENVT"].ToString();
            donvitinh = dt["DVT"].ToString();
            soluongton = int.Parse(dt["SOLUONGTON"].ToString()); 
            panelControl2.Enabled = true;
            btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = btnReloadVT.Enabled = btnThoatVT.Enabled = btnPhucHoiVT.Enabled = false;
            btnGhiVT.Enabled = btnHuyVT.Enabled = true;
            vattuGridControl.Enabled = false;
            check_them = false;
            txtMAVT.Enabled = false;
        }

        private void btnHuyVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsVATTU.CancelEdit();
            this.vattuTableAdapter.Fill(this.dSVATTU.Vattu);

            bdsVATTU.Position = vitri;
            btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = btnReloadVT.Enabled = btnThoatVT.Enabled = true;
            btnGhiVT.Enabled = btnHuyVT.Enabled = false;
            vattuGridControl.Enabled = true;
            panelControl2.Enabled = false;
          
        }

        private void btnPhucHoiVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stack.Count == 0)
            {
                MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                ; return;
            }


            string query = stack.Pop();
            Program.ExecSqlNonQuery(query);

            this.vattuTableAdapter.Fill(this.dSVATTU.Vattu);

            vattuGridControl.Enabled = true;
            btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = btnReloadVT.Enabled = btnThoatVT.Enabled = btnPhucHoiVT.Enabled = true;
            btnGhiVT.Enabled = btnHuyVT.Enabled = false;
        }

        private void btnReloadVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.vattuTableAdapter.Fill(this.dSVATTU.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload !" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void btnThoatVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
