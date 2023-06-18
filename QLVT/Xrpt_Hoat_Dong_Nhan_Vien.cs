using DevExpress.CodeParser;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT
{
   
    public partial class Xrpt_Hoat_Dong_Nhan_Vien : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_Hoat_Dong_Nhan_Vien()
        {
    
        }

        int sum = 0;
        public static string NumberToText(int number)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };

            String sNumber = number.ToString();

            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;  

            string result = " ";


            if (number == 0)
                result = unitNumbers[0];
            else
            {
                int placeValue = 0;
                while (positionDigit > 0)
                {
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (result != "")
            {
                result = result.Substring(0, 1).ToUpper() + result.Substring(1, result.Length - 1);
            }
            
            return "(" + result + " đồng).";
        }
        public Xrpt_Hoat_Dong_Nhan_Vien(int manv, DateTime batdau, DateTime ketthuc)
        {
            InitializeComponent();
            this.sqlDS_Hoat_Dong_Nhan_Vien.Connection.ConnectionString = Program.connstr;
            this.sqlDS_Hoat_Dong_Nhan_Vien.Queries[0].Parameters[0].Value = manv;
            this.sqlDS_Hoat_Dong_Nhan_Vien.Queries[0].Parameters[1].Value = batdau;
            this.sqlDS_Hoat_Dong_Nhan_Vien.Queries[0].Parameters[2].Value = ketthuc;
            this.sqlDS_Hoat_Dong_Nhan_Vien.Fill();
        }

        private void Xrpt_Sum_Tien_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
            {
                sum = int.Parse(e.Value.ToString());
            }

        }

        private void Xrpt_lbTienChu_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            Console.WriteLine(sum);
            ((XRLabel)sender).Text = NumberToText(sum);
        }
    }
}
