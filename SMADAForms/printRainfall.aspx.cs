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
    public partial class printRainfall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            ph.Controls.Add(new LiteralControl(rainfallAsHTML()));
        }
        public string rainfallAsHTML()
        {
            int RainfallID = Convert.ToInt32(Session["RainfallID"]);
            Rainfall r = new Rainfall(RainfallID);
        
            string s =  r.asHtmlTable();
            s += "<br/><br/>";
            s += r.valuesAsHtmlTable();
            return s;
        }   
    }
}