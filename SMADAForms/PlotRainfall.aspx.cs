using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMADA_2012.App_Code.SMADA;
using sage;

namespace SMADA_2012.SMADAForms
{
    public partial class PlotRainfall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            plotRainfall();
        }
        protected void plotRainfall()
        {
            int RainfallID = Convert.ToInt32(Session["RainfallID"]);
            Rainfall r = new Rainfall(RainfallID);

            SMADAPlot chart = new SMADAPlot();
            Plot.ChartText = chart.RainfallPlot(r);
        }
    }
}