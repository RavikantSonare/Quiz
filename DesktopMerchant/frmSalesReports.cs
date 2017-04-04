using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopMerchant.BOLayer;
using DesktopMerchant.BALayer;

namespace DesktopMerchant
{
    public partial class frmSalesReports : Form
    {
        private int MerchantID = default(int);
        private BOSalesReports _boslsrprt = new BOSalesReports();
        private BASalesReports _baslsrprt = new BASalesReports();
        private List<BOSalesReports> _boslsrprtlist = new List<BOSalesReports>();


        private decimal sumprice = default(decimal);
        private decimal sumnetamount = default(decimal);

        public frmSalesReports(int mrcntid)
        {
            InitializeComponent();
            MerchantID = mrcntid;
            FillDataGridView_SalesReports(MerchantID);
            dgvSalesReports.Columns[0].Visible = false;
            dgvSalesReports.Columns[1].Visible = false;
        }

        private void frmSalesReports_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void FillDataGridView_SalesReports(int mrid)
        {
            _boslsrprtlist = _baslsrprt.SelectSalesReprotsWithMrid("GetReportWithMrID", mrid);
            if (_boslsrprtlist.Count > 0)
            {
                int tmp = 0;

                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(_boslsrprtlist);
                dgvSalesReports.Rows.Clear();

                foreach (DataRow row in _table.Rows)
                {
                    dgvSalesReports.Rows.Add();
                    dgvSalesReports.Rows[tmp].Cells[0].Value = Convert.ToString(row["OrderId"]);
                    dgvSalesReports.Rows[tmp].Cells[1].Value = Convert.ToString(row["OrderNo"]);
                    DateTime dtim = Convert.ToDateTime(row["OrderDate"]);
                    dgvSalesReports.Rows[tmp].Cells[2].Value = dtim.ToString("yyyy/MM/dd");
                    dgvSalesReports.Rows[tmp].Cells[3].Value = Convert.ToString(row["SecondCategory"]);
                    dgvSalesReports.Rows[tmp].Cells[4].Value = Convert.ToString(row["ExamCode"]);
                    if (Convert.ToInt32(row["OrderStatus"]) == 1)
                    {
                        dgvSalesReports.Rows[tmp].Cells[5].Value = "Confirmed";
                        sumprice += Convert.ToDecimal(row["Price"]);
                        sumnetamount += Convert.ToDecimal(row["NetAmount"]);
                    }
                    else
                        dgvSalesReports.Rows[tmp].Cells[5].Value = "Processing";
                    dgvSalesReports.Rows[tmp].Cells[6].Value = Convert.ToString(row["Price"]);
                    dgvSalesReports.Rows[tmp].Cells[7].Value = Convert.ToString(row["FeeRate"]);
                    dgvSalesReports.Rows[tmp].Cells[8].Value = Convert.ToString(row["NetAmount"]);
                    tmp++;
                }
                if (dgvSalesReports.Rows.Count > 0)
                {
                    dgvSalesReports.Rows.Add();
                    dgvSalesReports.Rows[tmp].Cells[5].Value = "Summary";
                    dgvSalesReports.Rows[tmp].Cells[6].Value = Convert.ToString(sumprice);
                    dgvSalesReports.Rows[tmp].Cells[8].Value = Convert.ToString(sumnetamount);
                }
            }
        }
    }
}
