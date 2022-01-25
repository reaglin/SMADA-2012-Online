using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code;
using SMADA_2012.App_Code.SMADA;
namespace SMADA_2012.SMADAForms
{
    public partial class ManageRegressions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            RegressionAnalysis ra = new RegressionAnalysis();

            GridView1.DataSource = ra.RetrieveAll(UserLogin.getUserID(Session));
            GridView1.DataBind();

        }
        protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "use")
            {
                Session.Add("RegressionID", rid);
                Response.Redirect("~/SMADAForms/AnalyzeRegression.aspx");
            }
            if (e.CommandName == "editd")
            {
                Session.Add("RegressionID", rid);
                Response.Redirect("EditRegression.aspx");
            }
            if (e.CommandName == "deleted")
            {
                int uID = UserLogin.getUserID(Session);

                RegressionAnalysis ra = new RegressionAnalysis();
                ra.Delete(rid, uID);
            }
        }
    }
}