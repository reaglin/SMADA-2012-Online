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
    public partial class SelectWatereshed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {
                gvWatersheds.DataSource = Watershed.UserWatersheds(UserLogin.getUserID(Session));
                gvWatersheds.DataBind();
            }

            Session.Remove("WatershedID");
        }

        protected void gvWatersheds_OnRowCommand(object sender, DataGridCommandEventArgs e)
        {

            if ((string)e.CommandName == "edit")
            {
                Session.Add("WatershedID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/EditWatershed.aspx");
            }

            if ((string)e.CommandName == "delete")
            {
                Watershed.deleteWatershed(Convert.ToInt32(e.CommandArgument));
                Session.Remove("WatershedID");
                Response.Redirect("~/SMADAForms/SelectWatershed.aspx");
            }

            if ((string)e.CommandName == "print")
            {
                Session.Add("WatershedID", Convert.ToInt32(e.CommandArgument));
                Response.Redirect("~/SMADAForms/PrintWatershed.aspx");
            }

        }

    }
}