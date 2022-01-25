using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMADA_2012.App_Code.SMADA;
using sage;

namespace SMADA_2012.UserControls.SMADA
{
    public partial class ucCircularPipe : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnFlow_Click(object sender, EventArgs e)
        {
            doCaclulation();
        }


        protected void doCaclulation()
        {
            CircularPipe pipe = new CircularPipe();
            if (tbDiameter.Text != String.Empty) pipe.Diameter = Convert.ToDouble(tbDiameter.Text);
            if (tbSlope.Text != String.Empty) pipe.Slope = Convert.ToDouble(tbSlope.Text);
            if (tbManningsN.Text != String.Empty) pipe.ManningsN = Convert.ToDouble(tbManningsN.Text);
            if (tbFlow.Text != String.Empty) pipe.Flow = Convert.ToDouble(tbFlow.Text);
            if (tbDepth.Text != String.Empty) pipe.Depth = Convert.ToDouble(tbDepth.Text);

            pipe.calculate();
            Literal1.Text = pipe.asHTMLTable();

            string[] titles = { "Flow vs. Depth", "Depth (ft)", "Flow (cfs)" };
            ScatterPlot plot = new ScatterPlot(titles);

            Literal2.Text = plot.plotScatterFromArray(pipe.asDoubleFlowDepth());
        }


    }
}