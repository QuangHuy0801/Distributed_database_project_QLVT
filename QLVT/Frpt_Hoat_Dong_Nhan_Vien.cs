using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLVT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class Frpt_Hoat_Dong_Nhan_Vien : Form
    {
        public Frpt_Hoat_Dong_Nhan_Vien()
        {
            InitializeComponent();
        }
        int manv;
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

                this.thongTinNhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.thongTinNhanVienTableAdapter.Fill(this.DS1.ThongTinNhanVien);
               
            }
        }

        private void Frpt_Hoat_Dong_Nhan_Vien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS1.ThongTinNhanVien' table. You can move, or remove it, as needed.
            
            this.thongTinNhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.thongTinNhanVienTableAdapter.Fill(this.DS1.ThongTinNhanVien);
     
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;

            }
            else
            {

                cbChiNhanh.Enabled = false;
            }

            tungayde.DateTime  = DateTime.Now;
            denngayde.DateTime = DateTime.Now;
        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbHoTen.SelectedValue != null) manv = int.Parse(cmbHoTen.SelectedValue.ToString());
            }
            catch(Exception ex) { }
        }

        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (tungayde.Text.Length == 0)
            {
                MessageBox.Show("Ngày bắt đầu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                tungayde.Focus();
                return;
            }
            if (denngayde.Text.Length == 0)
            {
                MessageBox.Show("Ngày kết thúc không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                denngayde.Focus();
                return;
            }
            if (cmbHoTen.Text.Length == 0)
            {
                MessageBox.Show("Họ tên không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                cmbHoTen.Focus();
                return;
            }
            //DateTime batdau = DateTime.ParseExact(tungayde.Text.ToString(),
           //     "MM/dd/yyyy HH:mm:ss,fff", CultureInfo.CurrentCulture);
           // DateTime ketthuc = DateTime.ParseExact(denngayde.Text.ToString(),
             //   "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Xrpt_Hoat_Dong_Nhan_Vien rpt = new Xrpt_Hoat_Dong_Nhan_Vien(manv, DateTime.Parse(tungayde.Text.ToString()), DateTime.Parse(denngayde.Text.ToString()));
           // Xrpt_Hoat_Dong_Nhan_Vien rpt = new Xrpt_Hoat_Dong_Nhan_Vien(manv, batdau, ketthuc);
            rpt.sqlDS_Hoat_Dong_Nhan_Vien.Connection.ConnectionString = Program.connstr;
            rpt.Xrpt_lbTenNV.Text = cmbHoTen.Text.ToString();
           // rpt.Xrpt_lbThoiGian.Text = "Từ ngày : " + batdau.ToString("dd/MM/yyyy") + " đến ngày : " + ketthuc.ToString("dd/MM/yyyy");
            rpt.Xrpt_lbThoiGian.Text = "Từ ngày : " + tungayde.DateTime.ToString("dd/MM/yyyy") + " đến ngày : " + denngayde.DateTime.ToString("dd/MM/yyyy");
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
            Console.WriteLine(rpt.Xrpt_lbThoiGian.Text + "Tien");
            Console.WriteLine(rpt.Xrpt_Sum_Tien.Text + "Tie2n");
            Console.WriteLine(rpt.Xrpt_Sum_Tien.Value + "Tie3n");

        }
    }
}
