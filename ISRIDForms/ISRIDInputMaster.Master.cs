using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using ISRID_SAR;

namespace SMADA_2012.ISRIDForms
{
    public partial class ISRIDInputMaster : System.Web.UI.MasterPage
    {

        public int IncidentID()
        {
            if (Session["IncidentID"] != null)
                return Convert.ToInt32(Session["IncidentID"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitle.Text = this.Page.Header.Title;
            if (IncidentID() == 0)
            {
                //PageTitle.Text += " (New Incident)";
                pnlNav.Visible = false;
            }
            else
            {
                PageTitle.Text += " (Existing Incident)";
                pnlNav.Visible = true;
            }


            if (UserLogin.isLoggedIn(Session))
            {
                lbLogout.Visible = true;
                lblUserName.Text = Convert.ToString(Session["UserName"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(UserLogin.defaultURL());
        }

        protected void lbHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportGeneric.aspx?HelpForm=" + GUIManager.getPageName(this.Page));
        }
    }
}
