using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using sage;
using gui = sage.GUIManager;

namespace SMADA_2012
{
    public partial class EditFieldMapping : System.Web.UI.Page
    {
        public int DatabaseTransferID()
        {
            if (Request["DatabaseTransferID"] != null)
                return Convert.ToInt32(Request["DatabaseTransferID"]);
            else
                return 0;
        }

        public string SourceConnectionString()
        {
            return DatabaseTransferSystem.getSourceConnectionString(DatabaseTransferID());
        }

        public string DestinationConnectionString()
        {
            return DatabaseTransferSystem.getDestinationConnectionString(DatabaseTransferID());
        }

        public int FieldMappingID()
        {
            if (Request["FieldMappingID"] != null)
                return Convert.ToInt32(Request["FieldMappingID"]);
            else
                return 0;
        }

        public string SourceTableName()
        {
            if (Request["SourceTableName"] != null)
                return Convert.ToString(Request["SourceTableName"]);
            else
            {
                if (cbSourceTable.SelectedIndex != 0)
                    return Convert.ToString(cbSourceTable.SelectedValue);
                else
                    return String.Empty;
            }
        }

        public string DestinationTableName()
        {
            if (Request["DestinationTableName"] != null)
                return Convert.ToString(Request["DestinationTableName"]);
            else
            {
                if (cbDestTable.SelectedIndex != 0)
                    return Convert.ToString(cbDestTable.SelectedValue);
                else
                    return String.Empty;
            }
        }

        public string SourceFieldName()
        {
            if (Request["SourceFieldName"] != null)
                return Convert.ToString(Request["SourceFieldName"]);
            else
            {
                if (cbSourceField.SelectedIndex != 0)
                    return Convert.ToString(cbSourceField.SelectedValue);
                else
                    return String.Empty;
            }
        }

        public string DestinationFieldName()
        {
            if (Request["DestinationFieldName"] != null)
                return Convert.ToString(Request["DestinationFieldName"]);
            else
            {
                if (cbDestField.SelectedIndex != 0)
                    return Convert.ToString(cbDestField.SelectedValue);
                else
                    return String.Empty;
            }
        }

        public string DestinationCategoryName()
        {
            if (Request["DestinationCategoryName"] != null)
                return Convert.ToString(Request["DestinationCategoryName"]);
            else
            {
                if (cbDestCategory.SelectedIndex != 0)
                    return Convert.ToString(cbDestCategory.SelectedValue);
                else
                    return String.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            if (DatabaseTransferID() == 0) Response.Redirect("~/ViewDataTransfers.aspx");
            lblSourceID.Text = DatabaseTransferSystem.getSourceIDName(DatabaseTransferID());
            if (!IsPostBack)
            {
                setupSourceTable();
                setupDestTable();
                setupDestCategories();
            }
            setupDatagrid();
        }

        private void setupSourceTable()
        {
            cbSourceTable.DataSource = DatabaseViewer.Tables(SourceConnectionString());
            cbSourceTable.DataTextField = "TABLE_NAME";
            cbSourceTable.DataValueField = "TABLE_NAME";
            cbSourceTable.DataBind();
            cbSourceTable.Items.Insert(0, "- Select Table -");

            if (SourceTableName() != String.Empty)
            {
                cbSourceTable.SelectedItem.Value = SourceTableName();
                setupSourceField();

            }
        }

        private void setupSourceField()
        {
            if (SourceTableName() == String.Empty)
            {
                cbSourceField.Visible = false;
                return;
            }
            else
            {
                cbSourceField.Visible = true;
                cbSourceField.DataSource = DatabaseViewer.Columns(SourceTableName(), SourceConnectionString());
                cbSourceField.DataTextField = "COLUMN_NAME";
                cbSourceField.DataValueField = "COLUMN_NAME";
                cbSourceField.DataBind();
                cbSourceField.Items.Insert(0, "- Select Field -");

                if (SourceFieldName() != String.Empty)
                {
                    cbSourceTable.SelectedItem.Value = SourceFieldName();
                    setupSourceValue();

                }
            }
        }

        private void setupSourceValue()
        {
            string sql = "SELECT DISTINCT([" + SourceFieldName() + "]) FROM [" + SourceTableName();
            sql += "] WHERE [" + SourceFieldName() + "] NOT IN (";
            sql += "SELECT SourceValue FROM FieldMapping WHERE SourceFieldName = '" + SourceFieldName();
            sql += "' AND SourceTableName = '" + SourceTableName() + "')";


            cbSourceValue.Visible = true;
            cbSourceValue.DataSource = dboperations.ExecuteSQLReturnDataTable(sql, SourceConnectionString());

            cbSourceValue.DataTextField = SourceFieldName();
            cbSourceValue.DataValueField = SourceFieldName();
            cbSourceValue.DataBind();
            cbSourceValue.Items.Insert(0, "- Select Value -");
        }

        private void setupDestValue()
        {
            if (cbDestCategory.SelectedIndex == 0) return;
            cbDestValue.Visible = true;
            cbDestValue.DataSource = Categories.getCodes(cbDestCategory.SelectedValue);

            cbDestValue.DataTextField = "CodeNameText";
            cbDestValue.DataValueField = "CodeDescriptionText";
            cbDestValue.DataBind();
            cbDestValue.Items.Insert(0, "- Select Value - ");
        }


        private void setupDestTable()
        {
            cbDestTable.DataSource = DatabaseViewer.Tables(DestinationConnectionString());
            cbDestTable.DataTextField = "TABLE_NAME";
            cbDestTable.DataValueField = "TABLE_NAME";
            cbDestTable.DataBind();
            cbDestTable.Items.Insert(0, "- Select Table -");

            setDestTableFromCategory();
            if (DestinationTableName() != String.Empty) setupDestField();
        }

        private void setDestTableFromCategory()
        {
            if (cbDestCategory.SelectedIndex == -1) return;

            string dCat = DestinationCategoryName();
            if (dCat == String.Empty) return;
            string tableName = GUIManager.TableNameForCategory(dCat);
            if (tableName == String.Empty) return;
            try
            {
                cbDestTable.SelectedValue = tableName;
                setupDestField();
            }
            catch
            {
            }
        }

        private void setDestFieldFromCategory()
        {
            if (cbDestCategory.SelectedIndex == -1) return;

            string dCat = DestinationCategoryName();
            if (dCat == String.Empty) return;
            string colName = GUIManager.ColumnNameForCategory(dCat);
            if (colName == String.Empty) return;
            try
            {
                cbDestField.SelectedValue = colName;
            }
            catch
            {
            }

        }

        private void setupDestField()
        {

            if (DestinationTableName() == String.Empty) return;

            cbDestField.Visible = true;
            cbDestField.DataSource = DatabaseViewer.Columns(DestinationTableName(), DestinationConnectionString());
            cbDestField.DataTextField = "COLUMN_NAME";
            cbDestField.DataValueField = "COLUMN_NAME";
            cbDestField.DataBind();
            cbDestField.Items.Insert(0, "- Select Field -");

            setDestFieldFromCategory();

        }

        private void setupDestCategories()
        {
            cbDestCategory.DataSource = Categories.getAllCategories();
            cbDestCategory.DataTextField = "CategoryDescriptionText";
            cbDestCategory.DataValueField = "CategoryNameText";
            cbDestCategory.DataBind();
            cbDestCategory.Items.Insert(0, "- Transfer Directly -");

            if (DestinationCategoryName() != String.Empty)
            {
                cbDestCategory.SelectedItem.Value = DestinationCategoryName();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!isValid()) return;
            addCurrentSourceValueToCodes();
            getValues();
            setupDatagrid();
        }

        protected Boolean isValid()
        {
            if (cbSourceTable.SelectedIndex == 0) return false;
            if (cbSourceField.SelectedIndex == 0) return false;
            if (cbDestTable.SelectedIndex == 0) return false;
            if (cbDestField.SelectedIndex == 0) return false;
            return true;
        }

        private void getValues()
        {
            FieldMapping fm = new FieldMapping();
            fm.SourceIDName.Value = lblSourceID.Text;
            gui.getValue(fm.SourceTableName, cbSourceTable);
            gui.getValue(fm.SourceFieldName, cbSourceField);
            gui.getValue(fm.SourceValue, cbSourceValue);
            gui.getValue(fm.DestTableName, cbDestTable);
            gui.getValue(fm.DestFieldName, cbDestField);
            gui.getValue(fm.DestCategory, cbDestCategory);
            gui.getValue(fm.DestValue, cbDestValue);

            fm.Insert();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewDataTransfers.aspx");
        }

        private void setupDatagrid()
        {
            // Add ability to filter by source fields
            string sql = "SELECT * FROM FieldMapping" + filterSQL();
            sql += " ORDER BY SourceTableName, SourceFieldName, SourceValue";

            dgFM.DataSource = dboperations.ExecuteSQLReturnDataTable(sql);
            dgFM.DataBind();
        }


        private string filterSQL()
        {
            string s = String.Empty;
            s += " WHERE SourceIDName = '" + lblSourceID.Text + "'";
            if (cbSourceTable.SelectedIndex != 0)
            {
                s += " AND SourceTableName = '" + Convert.ToString(cbSourceTable.SelectedValue) + "'";

                if (cbSourceField.SelectedIndex != 0)
                    s += " AND SourceFieldName = '" + Convert.ToString(cbSourceField.SelectedValue) + "'";
            }
            return s;
        }

        protected void cbSourceTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupSourceField();
            setupDatagrid();
        }

        protected void cbSourceField_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupDatagrid();
        }

        protected void cbDestCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupSourceValue();
            setupDestValue();
            setDestTableFromCategory();
        }

        protected void cbDestTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupDestField();
        }

        protected void btnSubmitAgain_Click(object sender, EventArgs e)
        {
            if (!isValid()) return;
            addAllCurrentSourceValuesToCodes();
            setupDatagrid();
        }


        private void RedirectCurrent()
        {
            string s = "~/EditFieldMapping.aspx?DatabaseTransferID=" + Convert.ToString(DatabaseTransferID());
            if (cbSourceTable.SelectedIndex != 0) s += "&SourceTableName=" + cbSourceTable.SelectedValue;
            if (cbSourceField.SelectedIndex != 0) s += "&SourceFieldName=" + cbSourceField.SelectedValue;
            if (cbDestTable.SelectedIndex != 0) s += "&DestinationTableName=" + cbDestTable.SelectedValue;
            if (cbDestField.SelectedIndex != 0) s += "&DestinationFieldName=" + cbDestField.SelectedValue;
            if (cbDestField.SelectedIndex != 0) s += "&DestinationCategoryName=" + cbDestField.SelectedValue;
            Response.Redirect(s);
        }

        private void RedirectNew()
        {
            Response.Redirect("~/EditFieldMapping.aspx?DatabaseTransferID=" + Convert.ToString(DatabaseTransferID()));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            RedirectNew();
        }

        protected void lbAddCode_Click(object sender, EventArgs e)
        {
            addCurrentSourceValueToCodes();
        }

        private void addCurrentSourceValueToCodes()
        {
            // If no code is specified - this will add it to the codes.

            if (cbSourceValue.SelectedIndex == 0) return;
            if (cbDestCategory.SelectedIndex == 0) return;
            if (cbDestValue.SelectedIndex != 0) return;
            string cat = cbDestCategory.SelectedValue;
            string code = cbSourceValue.SelectedValue;

            Codes.addCode(cat, code);

            cbDestValue.Items.Add(code);
            cbDestValue.SelectedValue = code;
        }

        private void addAllCurrentSourceValuesToCodes()
        {
            if (cbDestCategory.SelectedIndex == 0) return;
            string cat = cbDestCategory.SelectedValue;
            foreach (ListItem li in cbSourceValue.Items)
            {
                if ((li.Value != String.Empty) && (li.Value != cbSourceValue.Items[0].Value))
                {
                    string code = li.Value;
                    Codes.addCode(cat, code);

                    FieldMapping fm = new FieldMapping();
                    fm.SourceIDName.Value = lblSourceID.Text;
                    gui.getValue(fm.SourceTableName, cbSourceTable);
                    gui.getValue(fm.SourceFieldName, cbSourceField);
                    fm.SourceValue.Value = li.Value;
                    gui.getValue(fm.DestTableName, cbDestTable);
                    gui.getValue(fm.DestFieldName, cbDestField);
                    gui.getValue(fm.DestCategory, cbDestCategory);
                    fm.DestValue.Value = li.Value;

                    fm.Insert();
                }
            }
        }

        protected void dgFM_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                string id = Convert.ToString(e.CommandArgument);
                string sql = "DELETE FROM FieldMapping WHERE FieldMappingID = " + id;

                dboperations.ExecuteSQL(sql);

                Response.Redirect("~/EditFieldMapping.aspx?DatabaseTransferID=" + Convert.ToString(DatabaseTransferID()));
            }

        }

        protected void btnKeyFields_Click(object sender, EventArgs e)
        {
            if (!isValid()) return;

            FieldMapping fm = new FieldMapping();
            fm.SourceIDName.Value = lblSourceID.Text;
            gui.getValue(fm.SourceTableName, cbSourceTable);
            gui.getValue(fm.SourceFieldName, cbSourceField);
            gui.getValue(fm.DestTableName, cbDestTable);
            gui.getValue(fm.DestFieldName, cbDestField);
            fm.KeyFieldsBit.Value = "True";

            fm.Insert();
        }

        protected void lbValues_Click(object sender, EventArgs e)
        {
            if (cbSourceTable.SelectedIndex == 0) return;
            if (cbSourceField.SelectedIndex == 0) return;
            string sql = "SELECT DISTINCT TOP 10 [" + cbSourceField.SelectedValue + "] FROM [" + cbSourceTable.SelectedValue + "]";

            DatabaseTransferSystem dts = new DatabaseTransferSystem(DatabaseTransferID());
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql, dts.SourceConnectionString.Value);

            lbValues.ToolTip = String.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                lbValues.ToolTip += Convert.ToString(dr[cbSourceField.SelectedValue]) + "  ";
            }

        }

    }
}
