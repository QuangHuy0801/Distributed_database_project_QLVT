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
using System.Windows.Media;

namespace QLVT
{
    public partial class FormKho : Form
    {
        string macn = "";
        int vitri = 0;
        bool dangThemMoi = false;
        Stack<string> stack = new Stack<string>();

        String maKho, tenKho, diaChi;
        public FormKho()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaKho.Enabled = true;
            vitri = bds_Kho.Position;
            Console.WriteLine(vitri);
            panelControl2.Enabled = true;

            bds_Kho.AddNew(); // Tự động xuống cuối thêm 1 row
            txtMaCN.Enabled = false; // Mã chi nhánh tự load, không sửa
            txtMaCN.Text = macn;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
            dangThemMoi = true;

            khoGridControl.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_Kho.Count == 0)
            {
                MessageBox.Show("Danh sách kho trống!", "", MessageBoxButtons.OK);
                btnXoa.Enabled = false;
                return;
            }
            if (bds_DatHang.Count > 0)

            {
                MessageBox.Show("Không thể xóa kho này do khóa ngoại Đặt Hàng!", "", MessageBoxButtons.OK);

                return;
            }
            if (bds_PhieuNhap.Count > 0)

            {
                MessageBox.Show("Không thể xóa kho này do khóa ngoại Phiếu Nhập!", "", MessageBoxButtons.OK);

                return;

            }
            if (bds_PhieuXuat.Count > 0)

            {
                MessageBox.Show("Không thể xóa kho này do khóa ngoại Phiếu Xuất!", "", MessageBoxButtons.OK);

                return;

            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa kho này!", "Xác nhận", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                try
                {
                    DataRowView dt = ((DataRowView)bds_Kho[bds_Kho.Position]);
                    maKho = dt["MAKHO"].ToString();
                    tenKho = dt["TENKHO"].ToString();
                    diaChi = dt["DIACHI"].ToString();
                    macn = dt["MACN"].ToString();

                    
                    string query = "INSERT INTO DBO.KHO( MAKHO,TENKHO,DIACHI,MACN) " +
            " VALUES( '" + txtMaKho.Text + "','" +
                        txtTenKho.Text + "','" +
                        txtDiaChi.Text + "', '" +
                        txtMaCN.Text.Trim() + "' ) ";

                    bds_Kho.RemoveCurrent();
                    this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khoTableAdapter.Update(this.DSKHO.Kho);

                    Console.WriteLine(query);
                    stack.Push(query);
                    btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Bạn hãy xóa lại \n" + ex.Message, "", MessageBoxButtons.OK);
                    this.khoTableAdapter.Fill(this.DSKHO.Kho);
                    /*bds_Kho.Position = bds_Kho.Find("MAKHO ", maKho);*/
                    bds_Kho.Position = vitri;
                    return;
                }
                
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bds_Kho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSKHO);

        }

        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra txtMAKHO*/
            if (txtMaKho.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã kho hàng", "Thông báo", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return false;
            }

            if (Regex.IsMatch(txtMaKho.Text, @"^[a-zA-Z0-9 ]+$") == false)
            {
                MessageBox.Show("Mã kho chỉ chấp nhận chữ và số", "Thông báo", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return false;
            }

            if (txtMaKho.Text.Length > 4)
            {
                MessageBox.Show("Mã kho không thể lớn hơn 4 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return false;
            }
            /*kiem tra txtTenKho*/
            if (txtTenKho.Text == "")
            {
                MessageBox.Show("Không bỏ trống tên kho hàng", "Thông báo", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTenKho.Text, @"^[a-zA-Z0-9 ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+$") == false)
            {
                MessageBox.Show("Tên kho chỉ chấp nhận chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return false;
            }

            if (txtTenKho.Text.Length > 30)
            {
                MessageBox.Show("Tên kho không thể quá 30 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return false;
            }
            /*kiem tra txtDiaChi*/
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Không bỏ trống địa chỉ kho hàng", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (Regex.IsMatch(txtDiaChi.Text, @"^[a-zA-Z0-9 ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ,-]+$") == false)
            {
                MessageBox.Show("Địa chỉ chỉ gồm chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (txtDiaChi.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không quá 100 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            return true;
        }

        private void FormKho_Load(object sender, EventArgs e)
        {
            
            DSKHO.EnforceConstraints = false;
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DSKHO.Kho);
            
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DSKHO.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DSKHO.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DSKHO.PhieuXuat);

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS1.NhanVien);

            if (bds_NhanVien.Count == 0)
            {
                MessageBox.Show("Bảng nhân viên trống, ứng dụng không còn login!", "", MessageBoxButtons.OK);
                return;
            }
            macn = ((DataRowView)bds_NhanVien[0])["MaCN"].ToString();

            /*if (bds_Kho.Count == 0)
            {
                macn = "CN" + (Program.mChinhNhanh + 1).ToString();
            }
            else macn = ((DataRowView)bds_Kho[0])["MaCN"].ToString();
            macn = "CN" + (Program.mChinhNhanh+1).ToString();*/
            
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;

            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = false;

            }
            else
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
                cbChiNhanh.Enabled = false;
            }
            btnReload.Enabled = true;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            panelControl2.Enabled = false;
            
        }

        private void mACNTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mAKHOLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stack.Count == 0)
            {
                MessageBox.Show("Không có gì để phục hồi!", "", MessageBoxButtons.OK);
                ; return;
            }


            string query = stack.Pop();
            Program.ExecSqlNonQuery(query);

            this.khoTableAdapter.Fill(this.DSKHO.Kho);

            khoGridControl.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
            khoGridControl.Enabled = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bds_Kho.CancelEdit();

            
            bds_Kho.Position = vitri; // quay lại vị trí cũ

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
            khoGridControl.Enabled = true;
            panelControl2.Enabled = false;
            this.khoTableAdapter.Fill(this.DSKHO.Kho);
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!kiemTraDuLieuDauVao()) return;
            if (dangThemMoi)
            {
                String checkKhoExist =
                    "DECLARE	@result int " +
                    "EXEC @result = [dbo].[sp_CheckKhoTonTai] " + "'" + txtMaKho.Text + "'" +
                    "  SELECT 'result' = @result";
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(checkKhoExist);
                    if (Program.myReader == null) { return; }
                    Program.myReader.Read();
                    if (Program.myReader.GetInt32(0) == 1)
                    {
                        MessageBox.Show("Kho đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                        txtMaKho.Focus();
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
                bds_Kho.EndEdit();
                bds_Kho.ResetCurrentItem();
                this.khoTableAdapter.Update(this.DSKHO.Kho);
                string query = "";
                if (dangThemMoi)
                {

                    query = "DELETE DBO.KHO WHERE MAKHO = " + "'" + txtMaKho.Text.Trim() + "'";

                }
                else
                {
                    query = "UPDATE DBO.KHO " +
                                "SET " +
                                "TENKHO = '" + tenKho + "'," +
                                "DIACHI = '" + diaChi + "'" +
                                "WHERE MAKHO = '" + maKho + "'";

                }
                stack.Push(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoat.Enabled = btnReload.Enabled = btnPhucHoi.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
            panelControl2.Enabled = false;
            khoGridControl.Enabled = true;

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_Kho.Count == 0)
            {
                MessageBox.Show("Danh sách kho trống!", "", MessageBoxButtons.OK);
                btnSua.Enabled = false;
                return;
            }
            txtMaKho.Enabled = false;
            txtMaCN.Enabled = false;
            vitri = bds_Kho.Position;

            DataRowView dt = ((DataRowView)bds_Kho[bds_Kho.Position]);
            maKho = dt["MAKHO"].ToString();
            macn = dt["MACN"].ToString();
            tenKho = dt["TENKHO"].ToString();
            diaChi = dt["DIACHI"].ToString();

            panelControl2.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;

            khoGridControl.Enabled = false;
            dangThemMoi = false;
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
                /*this.khoGridControl.Enabled = false;*/

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DSKHO.Kho);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DSKHO.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DSKHO.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DSKHO.PhieuXuat);

                this.khoGridControl.Enabled = true;
            }
        }
    

        private void mACNLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
