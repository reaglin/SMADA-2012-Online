using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class DefaultLoggedIn : System.Web.UI.Page
    {
        UserLogin u = new UserLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null) Response.Redirect("~/DefaultNotLoggedIn.aspx");

            u.Retrieve(Convert.ToString(Session["UserName"]));
            Session.Add("UserID", u.UserID);

            Session.Remove("RainfallID");
            Session.Remove("WatershedID");
            Session.Remove("HydrographID");
            

            if (u.isAdministrator())
            {
                btnAdmin.Visible = true;
                ucAdminLinks1.Visible = true;
            }
            else
            {
                ucAdminLinks1.Visible = false;
                btnAdmin.Visible = false;
            }
        }

        protected void btnRainfall_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlRainfall.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnDistrib_Click(object sender, EventArgs e)
        {
            Session["DistributionID"] = null;
            Response.Redirect("~/SMADAForms/ManageDistributions.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            pnlMain.Visible = true;
            // turn off all user menus
            pnlAdmin.Visible = false;
            pnlRainfall.Visible = false;
            pnlDistribution.Visible = false;
            pnlCalculators.Visible = false;
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            pnlAdmin.Visible = true;
            pnlMain.Visible = false;
            btnBack.Visible = true;
        }

        protected void btnWatershed_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlRainfall.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnHydrograph_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlRainfall.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnRegress_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlDistribution.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnPipeFlow_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlCalculators.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnPLOAD_Click(object sender, EventArgs e)
        {
            Session["LandUsesID"] = null;
            Response.Redirect("~/SMADAForms/ManageLandUses.aspx");
        }

        protected void btnBMP_Click(object sender, EventArgs e)
        {

            pnlMain.Visible = false;
            pnlPollutantTools.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnTCCalculator_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlCalculators.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnIDF_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SMADAForms/ComingSoon.aspx");
        }

        protected void btnSewer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SMADAForms/ComingSoon.aspx");

        }
    }
}
