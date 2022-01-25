using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.SMADAForms
{
    public partial class AnalyzeRegression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");

            // Must have a distribution to use this form
            int id = Convert.ToInt32(Session["RegressionID"]);
            if (id == 0) Response.Redirect("ManageRegressions.aspx");

            setTitle(id);

            if (!IsPostBack)
                if (Session["RegressionID"] != null)
                {
                    RegressionAnalysis ra = new RegressionAnalysis();
                    this.Title = "Regression Analysis: " + ra.RetrieveDescription(id);

                    // Put items in check box and also set to true
                    cblTypes.DataSource = RegressionAnalysis.RegressionTypesAsSortedList();
                    cblTypes.DataValueField = "key";
                    cblTypes.DataTextField = "value";
                    cblTypes.DataBind();
                    for (int i = 0; i < cblTypes.Items.Count; i++) cblTypes.Items[i].Selected = true;
                    this.gvData.DataSource = SpreadsheetPaste.GetDataTable(ra.RetrieveData(id), new string[] {"X", "Y"});
                    this.gvData.DataBind();
                }
        }

        private void setTitle(int id)
        {
            RegressionAnalysis ra = new RegressionAnalysis();
            this.Title = "Regression Analysis: " + ra.RetrieveDescription(id);
        }

        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            bool[] calc = new bool[RegressionAnalysis.NTypes];
            for (int i = 0; i < cblTypes.Items.Count; i++) calc[i] = cblTypes.Items[i].Selected; 

            RegressionAnalysis ra = new RegressionAnalysis(calc);
            getValuesFromGrid(ra);
            ra.calculate();
            gvParam.DataSource = ra.parametersAsDataTable();
            gvParam.DataBind();

            GridView2.DataSource = ra.asDataTable();
            GridView2.DataBind();

            lblG2Title.Visible = true;
            lblParameters.Visible = true;

            SMADAPlot s = new SMADAPlot(new string[] {"Regression Analysis", "X Values", "Y Values"});
            litPlot.Text = s.plotRegression(0, GridView2);
            pnlPlot.Visible = true;
        }

       private void getValuesFromGrid(RegressionAnalysis ra)
        {
            // Pulls the values from a specific column in the GridView

            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                ra.x[i] = Convert.ToDouble(gvData.Rows[i].Cells[0].Text);
                ra.y[i] = Convert.ToDouble(gvData.Rows[i].Cells[1].Text);
            }
            ra.n = gvData.Rows.Count;
        }

    }
}