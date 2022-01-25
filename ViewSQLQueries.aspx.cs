using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class ViewSQLQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");

            string sql = "SELECT * FROM SQLQueryManager";
            dgQuery.DataSource = dboperations.ExecuteSQLReturnDataTable(sql);
            dgQuery.DataBind();
        }
    }
}
