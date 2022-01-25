using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using gui = sage.GUIManager;
using System.Web.UI.DataVisualization.Charting;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.SMADAForms
{
    public partial class PlotHydrograph : System.Web.UI.Page
    {
        public int hydrographID()
        {
            return gui.getID(Session, "HydrographID");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            fillChart();
        }
        protected void fillChart()
        {
            int hydrographID = Convert.ToInt32(Session["HydrographID"].ToString());
            Hydrograph h = new Hydrograph(hydrographID);
            h.generateHydrograph();
            
            SMADAPlot chart = new SMADAPlot();

            ltrChart.Text = chart.HydrographPlot(h);
            tbChart.Text = ltrChart.Text;
        }
    }
}