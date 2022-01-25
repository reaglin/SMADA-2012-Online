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
    public partial class PrintHydrograph : System.Web.UI.Page
    {

        public int hydrographID()
        {
            if (Session["HydrographID"] != null)
            {
                return Convert.ToInt32(Session["HydrographID"].ToString());
            }
            else
            {
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");

            if (hydrographID() != 0)
            {
            Hydrograph h = new Hydrograph(hydrographID());
            h.generateHydrograph();

            string s = String.Empty;
            s += "<table><tr valign='top'>";
 
            s += "<td><h1>Watershed</h1>";
            s += h.watershed.asHtmlTable();   
            s += "</td><td>";
            s += "<h1>Rainfall</h1>";
            s += h.rainfall.asHtmlTable();
            s += "</td><td>";
            s += "<h1>Hydrograph</h1>";
            s += h.asHtmlTable();
            s += "</td></tr></table><hr/>";
            s += h.valuesAsHtmlTable();
            litHydrograph.Text = s;
            }
        }
    }
}