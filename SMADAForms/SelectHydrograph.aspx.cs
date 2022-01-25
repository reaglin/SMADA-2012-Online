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
    public partial class SelectHydrograph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {
                gvHydrographs.DataSource = Hydrograph.Userhydrographs(UserLogin.getUserID(Session));
                gvHydrographs.DataBind();
            }

            Session.Remove("WatershedID");
        }

        protected void gvHydrographs_OnRowCommand(object sender, DataGridCommandEventArgs e)
        {

            if ((string)e.CommandName == "editHydrograph")
            {
                Session.Add("HydrographID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/EditHydrograph.aspx");
            }

            if ((string)e.CommandName == "editWatershed")
            {
                Session.Add("WatershedID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/EditWatershed.aspx");
            }

            if ((string)e.CommandName == "editRainfall")
            {
                Session.Add("RainfallID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/EditRainfall.aspx");
            }

            if ((string)e.CommandName == "delete")
            {
                Hydrograph.DeleteHydrograph(Convert.ToInt32(e.CommandArgument));
                Session.Remove("HydrographID");
                Response.Redirect("~/SMADAForms/SelectHydrograph.aspx");
            }

            if ((string)e.CommandName == "print")
            {
                Session.Add("HydrographID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/PrintHydrograph.aspx");
            }
            if ((string)e.CommandName == "plot")
            {
                Session.Add("HydrographID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/PlotHydrograph.aspx");
            }

        }
    }
}