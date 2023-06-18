using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT
{
    public partial class Xrpt_Don_Dat_Hang_Khong_Phieu_Nhap : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_Don_Dat_Hang_Khong_Phieu_Nhap()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Fill();
        }

    }
}
