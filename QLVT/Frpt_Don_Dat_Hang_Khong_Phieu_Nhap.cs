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
    public partial class Frpt_Don_Dat_Hang_Khong_Phieu_Nhap : Form
    {
        public Frpt_Don_Dat_Hang_Khong_Phieu_Nhap()
        {
            InitializeComponent();
        }

      

        private void Frpt_Don_Dat_Hang_Khong_Phieu_Nhap_Load(object sender, EventArgs e)
        {
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

                //this.sqlDS_In_DSNV.Connection.ConnectionString = Program.connstr;
                //this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
            }
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            Xrpt_Don_Dat_Hang_Khong_Phieu_Nhap rpt = new Xrpt_Don_Dat_Hang_Khong_Phieu_Nhap();
            rpt.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
