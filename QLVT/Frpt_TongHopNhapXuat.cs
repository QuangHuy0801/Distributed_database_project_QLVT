using DevExpress.XtraReports.UI;
using QLVT.Properties;
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
    public partial class Frpt_TongHopNhapXuat : Form
    {
        public Frpt_TongHopNhapXuat()
        {
            InitializeComponent();
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

                /*this.thongTinNhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.thongTinNhanVienTableAdapter.Fill(this.DS1.ThongTinNhanVien);*/

            }
        }

        private void Frpt_TongHopNhapXuat_Load(object sender, EventArgs e)
        {
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "TENSERVER";
            cbChiNhanh.SelectedIndex = Program.mChinhNhanh;

            if(Program.mGroup == "CONGTY")
            {
                cbChiNhanh.Enabled = true;
            }
            else cbChiNhanh.Enabled = false;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (start.Text.Length == 0)
            {
                MessageBox.Show("Ngày bắt đầu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                start.Focus();
                return;
            }
            if (end.Text.Length == 0)
            {
                MessageBox.Show("Ngày kết thúc không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                end.Focus();
                return;
            }
            Xrpt_TongHopNhapXuat rpt = new Xrpt_TongHopNhapXuat(start.DateTime, end.DateTime);
            rpt.Xrpt_lbThoiGian.Text = "Từ " + start.DateTime.ToString("dd/MM/yyyy") + " đến " + end.DateTime.ToString("dd/MM/yyyy");
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void denngayde_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tungayde_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
