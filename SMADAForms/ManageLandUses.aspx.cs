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
    public partial class ManageLandUses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            LandUses lu = new LandUses();

            GridView1.DataSource = lu.RetrieveAll(UserLogin.getUserID(Session));
            GridView1.DataBind();
        }

        protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "use")
            {
                Session.Add("LandUsesID", rid);
                Response.Redirect("~/SMADAForms/AnalyzePollutantLoading.aspx");
            }
            if (e.CommandName == "edit")
            {
                Session.Add("LandUsesID", rid);
                Response.Redirect("EditLandUses.aspx");
            }
            if (e.CommandName == "lbDelete")
            {
                LandUses lu = new LandUses();

                int uID = UserLogin.getUserID(Session);
                lu.Delete(rid, uID);
            }
        }

    }
}