using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using gui = sage.GUIManager;


namespace SMADA_2012
{
    public partial class Help : System.Web.UI.Page
    {
        public int HelpID()
        {
            return gui.getID(Request, "id"); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (UserLogin.isAdministrator(Session))
            {
                lbHelp.Visible = true;
            }
            else
            {
                lbHelp.Visible = false;
            }
            if (HelpID() == 0) return;
            
            DatabaseField dbf = new DatabaseField(HelpID());
            Page.Title += dbf.promptText;
            litHelp.Text = dbf.fullHelpText(); 
        }

        protected void lbHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminForms/EditDataField.aspx?id=" + Convert.ToString(HelpID()));
        }

    }
}