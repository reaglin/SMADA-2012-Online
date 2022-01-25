using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using sage;

namespace SMADA_2012
{
    public partial class ViewData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));

            dgData.DataSource = data();
            dgData.DataBind();

        }
        protected void gvData_Change(Object sender, DataGridPageChangedEventArgs e)
        {

            // Set CurrentPageIndex to the page the user clicked.
            dgData.CurrentPageIndex = e.NewPageIndex;

            // Rebind the data. 
            dgData.DataSource = data();
            dgData.DataBind();
        }

        private DataSet data()
        {
            String tn = System.Convert.ToString(Request.QueryString["tn"]);
            String sql = "SELECT * FROM " + tn;

            DataSet ds = dboperations.ExecuteSQL(sql);
            return ds;

        }
    }
}
