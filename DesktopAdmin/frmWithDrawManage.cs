using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLayer;
using BALayer;

namespace DesktopAdmin
{
    public partial class frmWithDrawManage : Form
    {
        private BOWithDrawManage _bowdwmng = new BOWithDrawManage();
        private List<BOWithDrawManage> _bowdwmnglist = new List<BOWithDrawManage>();
        private BAWithDrawManage _bawdwmng = new BAWithDrawManage();
        private int LoginId = default(int);
        private bool headval = default(bool);

        public frmWithDrawManage(int loginid)
        {
            InitializeComponent();
            LoginId = loginid;
        }

        private void frmWithDrawManage_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillDataGridView();
                dgvWithDrawManage.ReadOnly = true;
                dgvWithDrawManage.Columns[0].Visible = false;
                dgvWithDrawManage.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _bowdwmnglist = new List<BOWithDrawManage>();
            _bowdwmng.Event = "GETALL";
            _bowdwmnglist = _bawdwmng.SelectWithDrawManageList(_bowdwmng);

            int tmp = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bowdwmnglist);
            dgvWithDrawManage.Rows.Clear();

            foreach (DataRow row in _table.Rows)
            {
                dgvWithDrawManage.Rows.Add();

                dgvWithDrawManage.Rows[tmp].Cells[0].Value = Convert.ToString(row["WithDrawOrderId"]);
                dgvWithDrawManage.Rows[tmp].Cells[1].Value = Convert.ToString(row["WithDrawOrderNo"]);
                dgvWithDrawManage.Rows[tmp].Cells[2].Value = Convert.ToString(row["Amount"]);
                dgvWithDrawManage.Rows[tmp].Cells[3].Value = Convert.ToString(row["MerchantName"]);
                if (Convert.ToBoolean(row["OrderStatus"]))
                    dgvWithDrawManage.Rows[tmp].Cells[5].Value = "Confirmed";
                else
                    dgvWithDrawManage.Rows[tmp].Cells[5].Value = "Processing";
                dgvWithDrawManage.Rows[tmp].Cells[4].Value = Convert.ToString(row["OrderStatus"]);
                tmp++;
            }
        }

        private void dgvWithDrawManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvWithDrawManage.Columns[e.ColumnIndex].Name == "OrderConfirm")
                    {
                        bool isactive = Convert.ToBoolean(dgvWithDrawManage.Rows[e.RowIndex].Cells[4].Value.ToString());
                        if (isactive == true)
                        {
                            _bowdwmng.OrderStatus = false;
                            MessageBox.Show("Order already confirmed");
                        }
                        else
                        {
                            _bowdwmng.OrderStatus = true;
                            _bowdwmng.WithDrawOrderId = Convert.ToInt32(dgvWithDrawManage.Rows[e.RowIndex].Cells[0].Value.ToString());

                            _bowdwmng.UpdatedBy = LoginId;
                            _bowdwmng.UpdatedDate = DateTime.UtcNow;
                            _bowdwmng.Event = "UpdateStatus";
                            MessageBox.Show(Common.Message("order", _bawdwmng.Update(_bowdwmng)));
                            FillDataGridView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvWithDrawManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 5)
            {
                headval = false;
            }
            else
            {
                headval = true;
            }
        }
    }
}
