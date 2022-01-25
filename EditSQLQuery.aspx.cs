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
    public partial class EditSQLQuery : System.Web.UI.Page
    {
        public int SQLQueryID()
        {
            if (Request["SQLQueryID"] != null)
                return Convert.ToInt32(Request["SQLQueryID"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isAdmin = UserLogin.isAdministrator(Session);
            pnlEdit.Visible = isAdmin;
            lbEdit.Visible = isAdmin;
            lblEdit.Visible = isAdmin;

            if (!Page.IsPostBack)
            {
                setup();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewSQLQueries.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            getValues();
            bindDataGrid();
        }

        private void setup()
        {
            setValues();
            bindDataGrid();
        }

        private void bindDataGrid()
        {
            if (tbSQL.Text == String.Empty) return;

            DataTable dt = data();
            if (dt.Rows.Count == 0) return;

            dgData.DataSource = dt;
            dgData.DataBind();
        }

        private void setValues()
        {
            if (SQLQueryID() == 0) return;
            SQLQueryManager sqm = new SQLQueryManager(SQLQueryID());
            gui.setValue(sqm.SQLQueryManagerName, tbName);
            gui.setValue(sqm.SQLQueryManagerDescription, tbDescription);
            gui.setValue(sqm.SQLQueryManagerSQLText, tbSQL);
        }

        private void getValues()
        {
            SQLQueryManager sqm = new SQLQueryManager();
            gui.getValue(sqm.SQLQueryManagerName, tbName);
            gui.getValue(sqm.SQLQueryManagerDescription, tbDescription);
            gui.getValue(sqm.SQLQueryManagerSQLText, tbSQL);

            if (SQLQueryID() == 0)
                sqm.Insert();
            else
            {
                sqm.SQLQueryManagerID.Value = Convert.ToString(SQLQueryID());
                sqm.Update();
            }
        }
        protected void gvData_Change(Object sender, DataGridPageChangedEventArgs e)
        {
            dgData.CurrentPageIndex = e.NewPageIndex;

            bindDataGrid();
        }


        private DataTable data()
        {
            DataTable ds = new DataTable();
            if (tbSQL.Text == String.Empty) return new DataTable();

            try
            {
                ds = dboperations.ExecuteSQLReturnDataTable(tbSQL.Text);
                return ds;
            }
            catch
            {
                return new DataTable();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (SQLQueryID() == 0) return;

            string sql = "DELETE FROM SQLQueryManager WHERE SQLQueryManagerID = " + Convert.ToString(SQLQueryID());
            dboperations.ExecuteSQL(sql);

            Response.Redirect("~/ViewSQLQueries.aspx");
        }

    }
}
