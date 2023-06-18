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
    public partial class Frpt_In_DSNV : Form
    {
        public Frpt_In_DSNV()
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

                //this.sqlDS_In_DSNV.Connection.ConnectionString = Program.connstr;
                //this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
            }
        }

        private void Frpt_In_DSNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS1.NhanVien' table. You can move, or remove it, as needed.
            // Van con loi, tu xu li, thay k sua, thay se check khi thi
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            XrptIn_DSNV rpt = new XrptIn_DSNV();
            rpt.sqlDS_In_DSNV.Connection.ConnectionString = Program.connstr;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
