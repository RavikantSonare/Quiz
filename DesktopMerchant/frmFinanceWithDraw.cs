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
    public partial class frmFinanceWithDraw : Form
    {
        private int MerchantID = default(int);
        private BOWithDrawManage _bowmng = new BOWithDrawManage();
        private BAWithDrawManage _bawmng = new BAWithDrawManage();
        private List<BOWithDrawManage> _bowmnglist = new List<BOWithDrawManage>();

        public frmFinanceWithDraw(int mrcntid)
        {
            InitializeComponent();
            MerchantID = mrcntid;
            lblcurrbal.Text = Convert.ToString(SelectbalanceAmount("GetBalanceWithMId", MerchantID));
            dgvWithDrawreport.Columns[1].Visible = false;
            dgvWithDrawreport.Columns[2].Visible = false;
        }

        private void frmFinanceWithDraw_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            FillDataGridView(MerchantID);
        }

        private void FillDataGridView(int merchantID)
        {
            _bowmnglist = _bawmng.SelectWithDrawRecord("GetWithDrawRecordWithMId", merchantID);
            if (_bowmnglist.Count > 0)
            {
                int tmp = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(_bowmnglist);
                dgvWithDrawreport.Rows.Clear();

                foreach (DataRow row in _table.Rows)
                {
                    dgvWithDrawreport.Rows.Add();

                    DateTime dtval = Convert.ToDateTime(row["OrderDate"]);
                    dgvWithDrawreport.Rows[tmp].Cells[0].Value = dtval.ToString("yyyy/MM/dd");
                    dgvWithDrawreport.Rows[tmp].Cells[1].Value = Convert.ToString(row["WithDrawOrderId"]);
                    dgvWithDrawreport.Rows[tmp].Cells[2].Value = Convert.ToString(row["WithDrawOrderNo"]);
                    dgvWithDrawreport.Rows[tmp].Cells[3].Value = Convert.ToString(row["Amount"]);
                    if (Convert.ToBoolean(row["OrderStatus"]))
                        dgvWithDrawreport.Rows[tmp].Cells[4].Value = "Confirmed";
                    else
                        dgvWithDrawreport.Rows[tmp].Cells[4].Value = "Processing";
                    tmp++;
                }
            }
        }

        private decimal SelectbalanceAmount(string eventtxt, int mid)
        {
            decimal blnc = default(decimal);
            BAMerchantBalance _bamrblnc = new BALayer.BAMerchantBalance();
            blnc = _bamrblnc.SelectMerbalance(eventtxt, mid);
            return blnc;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblcurrbal.Text) > Convert.ToDecimal(txtWithDraw.Text))
            {
                _bowmng.WithDrawOrderNo = GetOrderNo();
                _bowmng.Amount = Convert.ToDecimal(txtWithDraw.Text);
                _bowmng.MerchantId = MerchantID;
                _bowmng.OrderStatus = false;
                _bowmng.OrderDate = DateTime.UtcNow;
                _bowmng.IsActive = true;
                _bowmng.IsDelete = false;
                _bowmng.CreatedBy = MerchantID;
                _bowmng.CreatedDate = DateTime.UtcNow;
                _bowmng.UpdatedBy = MerchantID;
                _bowmng.UpdatedDate = DateTime.UtcNow;
                _bowmng.Event = "Insert";
                MessageBox.Show(Common.Message(_bawmng.Insert(_bowmng)));
                lblcurrbal.Text = Convert.ToString(SelectbalanceAmount("GetBalanceWithMId", MerchantID));
            }
            else
            {
                MessageBox.Show("Your Balance not greater then Withdraw Amount");
            }
        }

        private string GetOrderNo()
        {
            int ordno = default(int);
            ordno = _bawmng.Getordrno("Getorderno");
            return Convert.ToString("ORD" + (ordno + 1));
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
