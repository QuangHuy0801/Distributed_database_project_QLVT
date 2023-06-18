using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conn_publisher = new SqlConnection();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCN"; 
            cbChiNhanh.ValueMember = "TENSERVER";
        }
        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null & conn_publisher.State == ConnectionState.Open)
            {
                conn_publisher.Close();
            }
             
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở dữ liệu gốc. " +
                    "Bạn xem lại Ten Server của Publisher, và tên CSDL trong chuỗi kết nối."
                    + ex.Message);
                return 0;
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Program.connstr_publisher);
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("SELECT * FROM Get_Subscribes");
            cbChiNhanh.SelectedIndex = 0;
            Program.servername = cbChiNhanh.SelectedValue.ToString();
        }

        private void lbDangNhap_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cbChiNhanh.SelectedValue.ToString();
                Console.WriteLine(Program.servername);
            }
            catch (Exception) { }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (teUserName.Text.Trim() == "" || tePassword.Text.Trim() == "")
            {
                MessageBox.Show("Username và password không được trống", "", MessageBoxButtons.OK);
                return;
            }

            Program.mlogin = teUserName.Text.Trim();
            Program.password = tePassword.Text.Trim();

            if (Program.KetNoi() == 0) return;


            try
            {
                String checkDangNhap = "declare @result int " +
                      "exec @result = [sp_Check_DangNhap_Login]  '" + Program.mlogin + "'  " +
                      "select @result";
                Console.WriteLine(checkDangNhap);
                Program.myReader = Program.ExecSqlDataReader(checkDangNhap);
                if (Program.myReader == null) { return; }
                Program.myReader.Read();
                if (Program.myReader.GetInt32(0) == 1)
                {
                    MessageBox.Show("Không có nhân viên nào tương ứng với tài khoản này!", "Thông báo", MessageBoxButtons.OK);
                    teUserName.Focus();
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


            Program.mChinhNhanh = cbChiNhanh.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            

            string strLenh = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            Program.username = Program.myReader.GetInt32(0).ToString();

            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu " +
                    "\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
            }    
            Program.mHoTen = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();

            Program.conn.Close();

            Program.formChinh.MANV.Text = "Mã NV : " + Program.username;
            Program.formChinh.HOTEN.Text = "Họ tên : " + Program.mHoTen;
            Program.formChinh.NHOM.Text = "Nhóm : " + Program.mGroup;
            Program.formChinh.HienThiMenu();
            this.Close();
        }
    }
}