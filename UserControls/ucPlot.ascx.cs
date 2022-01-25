using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMADA_2012.UserControls
{
    public partial class ucPlot : System.Web.UI.UserControl
    {
        public string ChartText
        { get { return tbChart.Text; } set { tbChart.Text = value; litChart.Text = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewPlot_Click(object sender, EventArgs e)
        {
            if (litChart.Visible)
            {
                litChart.Visible = false;
                btnViewPlot.Text = "Show Plot";
            }
            else
            {
                litChart.Visible = true;
                btnViewPlot.Text = "Hide Plot";
            }
        }

        protected void btnViewCode_Click(object sender, EventArgs e)
        {
            if (tbChart.Visible)
            {
                tbChart.Visible = false;
                btnViewCode.Text = "Show Code";
            }
            else
            {
                tbChart.Visible = true;
                btnViewCode.Text = "Hide Code";
            }
        }
    }
}