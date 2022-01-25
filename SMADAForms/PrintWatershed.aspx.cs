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
    public partial class PrintWatershed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ph.Controls.Add(new LiteralControl(watershedAsHTML()));
        }
        public string watershedAsHTML()
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");

            int WatershedID = Convert.ToInt32(Session["WatershedID"]);
            Watershed w = new Watershed(WatershedID);
            return w.asHtmlTable();
        }

    }
}