using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.UserControls
{
    public partial class ucTimeOfConcentration : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            TimeOfConcentration t = new TimeOfConcentration();
            t.Intensity = getValue(tbIntensity);
            t.Area = getValue(tbArea);
            t.Length = getValue(tbL);
            t.ManningsN = getValue(tbManningsN);
            t.RationalC = getValue(tbRationalC );
            t.RetardanceC = getValue(tbRetardanceC);
            t.RetardanceN = getValue(tbRetardanceN);
            t.Slope = getValue(tbSlope);
            t.CurveNumber = getValue(tbCN);

            Literal1.Text = t.asHTMLTable();

        }

        private double getValue(TextBox t)
        {
            if (t.Text == String.Empty) return 0;
            try
            {
                return Convert.ToDouble(t.Text);
            }
            catch
            {
                return 0;
            }
        }
    }
}