using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class ViewTables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String tn = System.Convert.ToString(Request.QueryString["tn"]);
            if ((tn == String.Empty) || (tn == null))
            {
                gvTables.Visible = true;
                gvTables.DataSource = sage.DatabaseViewer.BaseTables();
                gvTables.DataBind();
                gvColumns.Visible = false;
                gvForeignKeys.Visible = false;
                gvConstraints.Visible = false;
            }
            else
            {
                gvTables.Visible = false;

                gvColumns.Visible = true;
                gvColumns.DataSource = DatabaseViewer.ColumnsForTable(tn);
                gvColumns.DataBind();

                gvConstraints.Visible = true;
                gvConstraints.DataSource = DatabaseViewer.Constraints(tn);
                gvConstraints.DataBind();

                gvForeignKeys.Visible = true;
                gvForeignKeys.DataSource = DatabaseViewer.ForeignKeys(tn);
                gvForeignKeys.DataBind();
            }
        }

        public String ViewURL(Object RN)
        {
            return "ViewTables.aspx?tn=" + Convert.ToString(RN);
        }

        public String ViewData(Object RN)
        {
            return "ViewData.aspx?tn=" + Convert.ToString(RN);
        }
    }
}
