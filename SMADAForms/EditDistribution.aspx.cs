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
    public partial class EditDistribution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                tbSample.Text = "COLUMN1 COLUMN2 COLUMN3\n1,2,3\n2;3;4\n5.54 6 23 7.32\n8.65\t4.65\t9.32";
                if (Session["DistributionID"] != null)
                {
                    int dID = Convert.ToInt32(Session["DistributionID"]);
                    DistributionAnalysis da = new DistributionAnalysis(dID);
                    tbTitle.Text = da.RetrieveDescription(dID);
                    tbData.Text = da.RetrieveData(dID);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string t = tbTitle.Text ;
            string d = SpreadsheetPaste.convertToTabDelimited(tbData.Text);

// Insert new Data or Update existing data in database
            if (Session["DistributionID"] == null)
            {
                DistributionAnalysis da = new DistributionAnalysis();
                da.Insert(t, d, UserLogin.getUserID(Session));
            }
            else
            {
                int dID = Convert.ToInt32(Session["DistributionID"]);
                DistributionAnalysis da = new DistributionAnalysis(dID);
                int uID = UserLogin.getUserID(Session);
                da.Update(t, d, uID);
            }
            tbTitle.Text = String.Empty;
            tbData.Text = String.Empty;
            Session["DistributionID"] = null;

        }

        protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int dID = Convert.ToInt32(e.CommandArgument);
            DistributionAnalysis da = new DistributionAnalysis(dID);

            int uID = UserLogin.getUserID(Session);

            if (e.CommandName == "use")
            {
                Session.Add("DistributionID", dID);
                Response.Redirect("~/SMADAForms/DistributionFromSpreadsheet.aspx");
            }
            if (e.CommandName == "deleted")
            {
                da.Delete(dID, uID);
                Session["DistributionID"] = null;
                tbTitle.Text = String.Empty;
                tbData.Text = String.Empty;
            }

            if (e.CommandName == "editd")
            {
                Session.Add("DistributionID", dID);
                tbTitle.Text = da.RetrieveDescription(dID);
                tbData.Text = da.RetrieveData(dID);
            }
        }
    }
}