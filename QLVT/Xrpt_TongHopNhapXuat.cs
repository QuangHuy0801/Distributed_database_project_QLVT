using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT
{
    public partial class Xrpt_TongHopNhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_TongHopNhapXuat()
        {
            InitializeComponent();
        }

        public Xrpt_TongHopNhapXuat(DateTime batdau, DateTime ketthuc)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = batdau;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = ketthuc;
            this.sqlDataSource1.Fill();
        }

    }
}
