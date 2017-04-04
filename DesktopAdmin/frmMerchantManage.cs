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
    public partial class frmMerchantManage : Form
    {
        private BOMerchantManage _bomermng = new BOMerchantManage();
        private BAMerchantManage _bamermng = new BAMerchantManage();
        private List<BOMerchantManage> _bomermnglist = new List<BOMerchantManage>();
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmMerchantManage(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
            dgvMerchantManage.Columns[0].Visible = false;
            dgvMerchantManage.Columns[7].Visible = false;
        }

        private void frmMerchantManage_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _bomermng.Event = "GETALL";
            _bomermnglist = _bamermng.GetMerchantLevelList(_bomermng);
            int sn = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bomermnglist);
            dgvMerchantManage.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvMerchantManage.Rows.Add();
                dgvMerchantManage.Rows[sn].Cells[0].Value = Convert.ToString(row["MerchantId"]);
                dgvMerchantManage.Rows[sn].Cells[1].Value = Convert.ToString(row["MerchantName"]);
                dgvMerchantManage.Rows[sn].Cells[2].Value = Convert.ToString(row["Country"]);
                dgvMerchantManage.Rows[sn].Cells[3].Value = Convert.ToString(row["State"]);
                dgvMerchantManage.Rows[sn].Cells[4].Value = Convert.ToString(row["Telephone"]);
                dgvMerchantManage.Rows[sn].Cells[5].Value = Convert.ToString(row["MerchantLevel"]);
                dgvMerchantManage.Rows[sn].Cells[6].Value = Convert.ToString(row["StartDate"] + "-" + row["EndDate"]);
                if (Convert.ToBoolean(row["ActiveStatus"]))
                    dgvMerchantManage.Rows[sn].Cells[8].Value = "Activated";
                else
                {
                    dgvMerchantManage.Rows[sn].Cells[8].Value = "Inactivated";
                }
                dgvMerchantManage.Rows[sn].Cells[7].Value = Convert.ToString(row["ActiveStatus"]);
                sn++;
            }
        }

        private void dgvMerchantManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvMerchantManage.Columns[e.ColumnIndex].Name == "Active")
                    {
                        bool isactive = Convert.ToBoolean(dgvMerchantManage.Rows[e.RowIndex].Cells[7].Value.ToString());
                        if (isactive == true)
                        {
                            _bomermng.ActiveStatus = false;
                        }
                        else
                        {
                            _bomermng.ActiveStatus = true;
                        }
                        _bomermng.MerchantId = Convert.ToInt32(dgvMerchantManage.Rows[e.RowIndex].Cells[0].Value.ToString());

                        _bomermng.UpdatedBy = loginID;
                        _bomermng.UpdatedDate = DateTime.UtcNow;
                        _bomermng.Event = "UpdateStatus";
                        MessageBox.Show(Common.Message("Merchant profile is", _bamermng.Update(_bomermng)));
                        FillDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMerchantManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 8)
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
