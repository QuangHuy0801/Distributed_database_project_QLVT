using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class Frpt_JobChiTietNhapXuat : Form
    {
        public Frpt_JobChiTietNhapXuat()
        {
            InitializeComponent();
        }

      

        private void Frpt_JobChiTietNhapXuat_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "CONGTY")
            {
                txtChucVu.Text = "Công Ty";

            }
            else if  (Program.mGroup == "CHINHANH")
            {
                txtChucVu.Text = "Chi nhánh";

            }
            else { txtChucVu.Text = "User"; }


        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            if (cmbLoai.Text.Length == 0)
            {
                MessageBox.Show("Loại phiếu không được để trống !", "Thông báo", MessageBoxButtons.OK);
                cmbLoai.Focus();
                return;
            }
            if (txtTuThang.Text.Length == 0)
            {
                MessageBox.Show("Từ tháng không được để trống !", "Thông báo", MessageBoxButtons.OK);
                txtTuThang.Focus();
                return;
            }
            if (txtDenThang.Text.Length == 0)
            {
                MessageBox.Show("Đến tháng không được để trống !", "Thông báo", MessageBoxButtons.OK);
                txtDenThang.Focus();
                return;
            }
            /* int result = DateTime.Compare(txtDenThang, txtDenThang);
             if (result>0)
             {
                 MessageBox.Show("Tháng bắt đầu ph không được để trống !", "Thông báo", MessageBoxButtons.OK);
                 txtDenThang.Focus();
                 return;
             }*/
            //DateTime batdau = DateTime.ParseExact(tungayde.Text.ToString(),
            //     "MM/dd/yyyy HH:mm:ss,fff", CultureInfo.CurrentCulture);
            // DateTime ketthuc = DateTime.ParseExact(denngayde.Text.ToString(),
            //   "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string loai = "";
            if (cmbLoai.SelectedItem.ToString() == "Nhập")
            {
                loai = "NHAP";
            }
            else loai = "XUAT";

            Xrpt_JobChiTietNhapXuat rpt = new Xrpt_JobChiTietNhapXuat(Program.mGroup,loai ,DateTime.Parse(txtTuThang.Text.ToString()), DateTime.Parse(txtDenThang.Text.ToString()));
            

            // Xrpt_Hoat_Dong_Nhan_Vien rpt = new Xrpt_Hoat_Dong_Nhan_Vien(manv, batdau, ketthuc);
            rpt.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            rpt.lbTieuDe.Text = "Bảng kê chi tiết số lượng – trị giá hàng " + cmbLoai.Text.ToLower();
            // rpt.Xrpt_lbThoiGian.Text = "Từ ngày : " + batdau.ToString("dd/MM/yyyy") + " đến ngày : " + ketthuc.ToString("dd/MM/yyyy");
            rpt.lbThoiGian.Text = "Từ ngày : " + txtTuThang.DateTime.ToString("MM/yyyy") + " đến tháng : " + txtDenThang.DateTime.ToString("MM/yyyy");
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
            
        }
    }
}
