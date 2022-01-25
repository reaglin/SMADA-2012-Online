using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMADA_2012.App_Code.SMADA;
using SMADA_2012.App_Code;
using sage;

namespace SMADA_2012.SMADAForms
{
    public partial class PasteDistribution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                tbSample.Text = "COLUMN1 COLUMN2 COLUMN3\n1,2,3\n2;3;4\n5.54 6 23 7.32\n8.65\t4.65\t9.32";
                if (Session["DistributionID"] != null)
                {
                    int did = Convert.ToInt32(Session["DistributionID"]);
                    tbTitle.Text = DistributionAnalysis.RetrieveDistributionDescription(did);
                    tbData.Text = DistributionAnalysis.RetrieveDistributionData(did);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string t = tbTitle.Text ;
            string d = SpreadsheetPaste.convertToTabDelimited(tbData.Text);

// Insert new Data or Update existing data in database
            if (Session["DistributionID"] == null)
                DistributionAnalysis.InsertDistribution(t, d, UserLogin.getUserID(Session));
            else
                DistributionAnalysis.UpdateDistribution(t,d, Convert.ToInt32(Session["DistributionID"]));

            tbTitle.Text = String.Empty;
            tbData.Text = String.Empty;
            Session["DistributionID"] = null;

        }

        protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int did = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "use")
            {
                Session.Add("DistributionID", did);
                Response.Redirect("~/SMADAForms/DistributionFromSpreadsheet.aspx");
            }
            if (e.CommandName == "deleted")
            {
                DistributionAnalysis.DeleteDistribution(did);
                Session["DistributionID"] = null;
                tbTitle.Text = String.Empty;
                tbData.Text = String.Empty;
            }

            if (e.CommandName == "editd")
            {
                Session.Add("DistributionID", did);
                tbTitle.Text = DistributionAnalysis.RetrieveDistributionDescription(did);
                tbData.Text = DistributionAnalysis.RetrieveDistributionData(did);
            }
        }
    }
}