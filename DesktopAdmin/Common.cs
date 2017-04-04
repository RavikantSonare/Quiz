using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace DesktopAdmin
{
    public static class Common
    {
        public static string ConfirmDeleteMsg = "Are you sure do you want to delete this record";
        public static string ConfirmUpdateMsg = "Are you sure do you want to update this record";


        public static string Message(int val)
        {
            string _mess = string.Empty;
            if (val.Equals(1))
                _mess = "Record Inserted";
            if (val.Equals(2))
                _mess = "Record Updated";
            if (val.Equals(3))
                _mess = "Record Deleted";
            if (val.Equals(4))
                _mess = "User Name Already Exists";
            if (val.Equals(5))
                _mess = "You Can't Delete Because Used in Another Entity";
            if (val.Equals(6))
                _mess = "activated";
            if (val.Equals(7))
                _mess = "inactivated";
            if (val.Equals(8))
                _mess = "confirmed successfully";
            if (val.Equals(100))
                _mess = "Some Technical Error!!";
            return _mess;
        }
        public static string Message(string msg, int val)
        {
            string _mess = string.Empty;
            if (val.Equals(1))
                _mess = msg + " added successfully";
            if (val.Equals(2))
                _mess = msg + " updated successfully";
            if (val.Equals(3))
                _mess = msg + " deleted successfully";
            if (val.Equals(4))
                _mess = msg + " already exists";
            if (val.Equals(5))
                _mess = "Can't delete " + msg + " because used in another entity";
            if (val.Equals(6))
                _mess = msg + " activated";
            if (val.Equals(7))
                _mess = msg + " inactivated";
            if (val.Equals(8))
                _mess = msg + " confirmed successfully";
            return _mess;
        }
        public static DataTable LINQToDataTable<T>(IEnumerable<T> linqList)
        {
            var dtReturn = new DataTable();
            PropertyInfo[] columnNameList = null;

            if (linqList == null) return dtReturn;

            foreach (T t in linqList)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (columnNameList == null)
                {
                    columnNameList = ((Type)t.GetType()).GetProperties();

                    foreach (PropertyInfo columnName in columnNameList)
                    {
                        Type columnType = columnName.PropertyType;

                        if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            columnType = columnType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(columnName.Name, columnType));
                    }
                }

                DataRow dataRow = dtReturn.NewRow();

                foreach (PropertyInfo columnName in columnNameList)
                {
                    dataRow[columnName.Name] =
                        columnName.GetValue(t, null) == null ? DBNull.Value : columnName.GetValue(t, null);
                }

                dtReturn.Rows.Add(dataRow);
            }

            return dtReturn;
        }

        public static void ClearPanel(Panel panle)
        {
            foreach (Control cntrl in panle.Controls)
            {
                if (cntrl is TextBox)
                {
                    TextBox textBox = (TextBox)cntrl;
                    textBox.Text = null;
                    if (textBox.Tag.Equals("f"))
                        textBox.Focus();

                    ComboBox comboBox = (ComboBox)cntrl;
                    comboBox.Text = null;
                    if (comboBox.Tag.Equals("f"))
                        comboBox.Focus();
                }
            }
        }

        public static void BtnHideHover(TableLayoutPanel tblpanle)
        {
            foreach (Control cntrl in tblpanle.Controls)
            {
                if (cntrl is Button)
                {
                    Button btn = (Button)cntrl;
                    btn.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
                }
            }
        }

    }
}
