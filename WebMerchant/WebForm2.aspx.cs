using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMerchant
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keysQ = Request.Form.AllKeys.Where(key => key.Contains("txtQ")).ToList();
            if (keysQ.Count > 0)
            {
                foreach (string key in keysQ)
                {
                    int txtId = Convert.ToInt16(key.Substring(4));
                    this.CreateTextBoxQ("txtQ" + txtId, txtId);
                    txtId++;
                }
            }

            List<string> keysA = Request.Form.AllKeys.Where(key => key.Contains("txtA")).ToList();
            if (keysA.Count > 0)
            {
                foreach (string key in keysA)
                {
                    int txtId = Convert.ToInt16(key.Substring(4));
                    this.CreateTextBoxA("txtA" + txtId, txtId);
                    txtId++;
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                pnlQuestion.Controls.Clear();
                pnlAnswer.Controls.Clear();
            }

        }
        private void InitializeDynamicText()
        {
            int index = pnlQuestion.Controls.OfType<TextBox>().ToList().Count + 1;
            int index1 = pnlAnswer.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBoxQ("txtQ" + index, index);
            this.CreateTextBoxA("txtA" + index1, index1);
        }

        protected void AddTextBox(object sender, EventArgs e)
        {
            int indexQ = pnlQuestion.Controls.OfType<TextBox>().ToList().Count + 1;
            int indexA = pnlAnswer.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBoxQ("txtQ" + indexQ, indexQ);
            this.CreateTextBoxA("txtA" + indexA, indexA);
        }

        private void CreateTextBoxQ(string id, int i)
        {
            TextBox txt = new TextBox { ID = id, Width = 120 };
            Label lbl = new Label { Text = "Question " + i + ": " };
            Literal lt = new Literal { Text = "<br />" };
            pnlQuestion.Controls.Add(txt);
            pnlQuestion.Controls.Add(lt);
        }

        private void CreateTextBoxA(string id, int i)
        {
            TextBox txt = new TextBox { ID = id, Width = 120 };
            Label lbl = new Label { Text = "Answer " + ": " };
            Literal lt = new Literal { Text = "<br />" };

            Button btnRemove = new Button { ID = "bttn" + i.ToString(), Text = "x" };
            btnRemove.Click += new EventHandler(Remove_Click);
            btnRemove.Visible = i != 1;

            pnlAnswer.Controls.Add(txt);
            pnlAnswer.Controls.Add(btnRemove);
            pnlAnswer.Controls.Add(lt);
        }

        protected void GetTextBoxValues(object sender, EventArgs e)
        {
            try
            {
                string resultQ = pnlQuestion.Controls.OfType<TextBox>().Aggregate("", (current, textBox) => current + (textBox.ID + ": " + textBox.Text + ", "));
                string resultA = pnlAnswer.Controls.OfType<TextBox>().Aggregate("", (current, textBox) => current + (textBox.ID + ": " + textBox.Text + ", "));
                lblResult.Text = resultQ + resultA;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            divAdd.Visible = true;
            InitializeDynamicText();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            divAdd.Visible = false;
            pnlQuestion.Controls.Clear();
            pnlAnswer.Controls.Clear();
            lblResult.Text = string.Empty;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            List<string> keysQ = Request.Form.AllKeys.Where(key => key.Contains("txtQ")).ToList();
            List<string> keysA = Request.Form.AllKeys.Where(key => key.Contains("txtA")).ToList();
            int countQ = keysQ.Count; int countA = keysA.Count;
            if (countQ > 1 && countA > 1)
            {
                pnlQuestion.Controls.Remove(pnlQuestion.FindControl("txtQ" + countQ + ""));
                pnlAnswer.Controls.Remove(pnlAnswer.FindControl("txtA" + countA + ""));
            }
        }

        void Remove_Click(object sender, EventArgs e)
        {
            Button ib = sender as Button;
            if (ib != null)
            {
                string btnId = ib.ID;
                string txtId = btnId.Substring(4);

                string deltxtQ = "txtQ" + txtId;
                foreach (Control c in pnlQuestion.Controls)
                {
                    if (c.ID == deltxtQ)
                    {
                        pnlQuestion.Controls.Remove(c);

                        break;
                    }
                }

                string deltxtA = "txtA" + txtId;
                foreach (Control a in pnlAnswer.Controls)
                {
                    if (a.ID == deltxtA)
                    {
                        pnlAnswer.Controls.Remove(a);
                        pnlAnswer.Controls.Remove(ib);
                        break;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            divAdd.Visible = true;
            for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
            {
                this.CreateTextBoxQ("txtQ" + loopcnt, loopcnt);
            }
            for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
            {
                this.CreateTextBoxA("txtA" + loopcnt, loopcnt);
            }
        }
    }
}