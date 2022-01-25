using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMADA_2012.UserControls
{
    public partial class ucRainfallStep : System.Web.UI.UserControl
    {
        public double time {get; set; }
        public double depth { get; set; }
        protected global::System.Web.UI.WebControls.PlaceHolder ph;

        public ucRainfallStep()
        {
            initializeComponents();
            base.Construct();
        }

        public ucRainfallStep(double t, double d)
        {
            time = t;
            depth = d;
            initializeComponents();
            base.Construct();
        }

        private void initializeComponents()
        {
            System.Web.UI.WebControls.Label lblTime = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.TextBox tbRain = new System.Web.UI.WebControls.TextBox();
            lblTime.Width = 100; tbRain.Width = 100;
            
            ph.Controls.Add(lblTime);
            ph.Controls.Add(tbRain);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblTime = (Label)ph.FindControl("lblTime");
            TextBox tbRain = (TextBox)ph.FindControl("tbRain");
            lblTime.Text = String.Format("####.##", time);
            if (depth != 0) tbRain.Text = String.Format("##.##", depth);
        }
        public void getValues()
        {
            TextBox tbRain = (TextBox)ph.FindControl("tbRain");
            depth = Convert.ToDouble(tbRain.Text);
        }
    }
}