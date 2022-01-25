using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class InsertFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string page = Convert.ToString(Session["PageName"]);
            lblPage.Text = page;
            Page.Title += page;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int userID = UserLogin.getUserID(Session);
            Session.Add("UserID", userID);
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        }
    }
}