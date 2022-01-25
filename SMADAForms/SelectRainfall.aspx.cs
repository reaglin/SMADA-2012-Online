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
    public partial class SelectRainfall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {
                int uid = UserLogin.getUserID(Session);
                gvRainfall.DataSource = Rainfall.UserRealRainfalls(uid);
                gvRainfall.DataBind();

                dgDRainfall.DataSource = Rainfall.UserDimRainfalls(uid);
                dgDRainfall.DataBind();
            }

            Session.Remove("RainfallID");
        } // End Page_Load

        protected void gvRainfall_OnRowCommand(object sender, DataGridCommandEventArgs e)
        {

            int rid = Convert.ToInt32(e.CommandArgument);
            if ((string)e.CommandName == "edit")
            {
                Session.Add("RainfallID", rid);
                Rainfall r = new Rainfall(rid);
                if (r.isDimensionless())
                    Response.Redirect("~/SMADAForms/ImportDimensionlessRainfall.aspx");
                else
                Response.Redirect("~/SMADAForms/EditRainfall.aspx");
            }

            if ((string)e.CommandName == "delete")
            {
                Rainfall.deleteRainfall(rid);
                Session.Remove("RainfallID");
                Response.Redirect("~/SMADAForms/SelectRainfall.aspx");
            }

            if ((string)e.CommandName == "print")
            {
                Session.Add("RainfallID", rid);
                Response.Redirect("~/SMADAForms/PrintRainfall.aspx");
            }

            if ((string)e.CommandName == "plot")
            {
                Session.Add("RainfallID", rid);
                Response.Redirect("~/SMADAForms/PlotRainfall.aspx");
            }

            if ((string)e.CommandName == "values")
            {
                Session.Add("RainfallID", rid);
                Rainfall r = new Rainfall(rid);

                if (r.isDimensionless())
                    Response.Redirect("~/SMADAForms/ImportDimensionlessRainfall.aspx");
                else
                    Response.Redirect("~/SMADAForms/EditRainfallValues.aspx");
            }

        } // End OnRowCommand

        protected void gvDRainfall_OnRowCommand(object sender, DataGridCommandEventArgs e)
        {

            int rid = Convert.ToInt32(e.CommandArgument);
            if ((string)e.CommandName == "edit")
            {
                Session.Add("RainfallID", rid);
                Rainfall r = new Rainfall(rid);
                if (r.isDimensionless())
                    Response.Redirect("~/SMADAForms/ImportDimensionlessRainfall.aspx");
                else
                    Response.Redirect("~/SMADAForms/EditRainfall.aspx");
            }

            if ((string)e.CommandName == "delete")
            {
                Rainfall.deleteRainfall(rid);
                Session.Remove("RainfallID");
                Response.Redirect("~/SMADAForms/SelectRainfall.aspx");
            }

            if ((string)e.CommandName == "print")
            {
                Session.Add("RainfallID", rid);
                Response.Redirect("~/SMADAForms/PrintRainfall.aspx");
            }

            if ((string)e.CommandName == "plot")
            {
                Session.Add("RainfallID", rid);
                Response.Redirect("~/SMADAForms/PlotRainfall.aspx");
            }

            if ((string)e.CommandName == "values")
            {
                Session.Add("RainfallID", rid);
                Rainfall r = new Rainfall(rid);

                if (r.isDimensionless())
                    Response.Redirect("~/SMADAForms/ImportDimensionlessRainfall.aspx");
                else
                    Response.Redirect("~/SMADAForms/EditRainfallValues.aspx");
            }

        } // End OnRowCommand

    }
}