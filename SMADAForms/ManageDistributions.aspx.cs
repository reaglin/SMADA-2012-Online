using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code.SMADA;
namespace SMADA_2012.SMADAForms
{
    public partial class ManageDistributions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!IsPostBack) fillGridView();
        }

        protected void fillGridView()
        {
            GridView1.DataSource = DistributionAnalysis.RetrieveForUser(UserLogin.getUserID(Session), "Distribution Data");
            GridView1.DataBind();
        }

        protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int dID = Convert.ToInt32(e.CommandArgument);
            DistributionAnalysis da = new DistributionAnalysis(dID);
            int uID = UserLogin.getUserID(Session);

            if (e.CommandName == "use")
            {
                Session.Add("DistributionID", dID);
                Response.Redirect("~/SMADAForms/AnalyzeDistribution.aspx");
            }
            if (e.CommandName == "editd")
            {
                Session.Add("DistributionID", dID);
                Response.Redirect("EditDistribution.aspx");
            }
            if (e.CommandName == "deleted")
            {
                da.Delete(dID, uID);
                fillGridView();
            }
        }
    }
}