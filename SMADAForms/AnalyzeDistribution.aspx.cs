using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMADA_2012.App_Code;
using SMADA_2012.App_Code.SMADA;
using sage;
using System.Data;


namespace SMADA_2012.SMADAForms
{
    public partial class AnalyzeDistribution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
           
            // Must have a distribution to use this form
            int id = Convert.ToInt32(Session["DistributionID"]);
            if (id == 0) Response.Redirect("ManageDistributions.aspx");

            setTitle(id);

            if (!IsPostBack)
                if (Session["DistributionID"] != null)
                {
                    DistributionAnalysis da = new DistributionAnalysis();
                    this.Title = "Distribution Analysis: " + da.RetrieveDescription(id);

                    this.GridView1.DataSource = SpreadsheetPaste.GetDataTable(da.RetrieveData(id), true);
                    this.GridView1.DataBind();

                    fillTitleDDL();
                    fillDistributionDDL();
                }
        }

        private void setTitle(int id)
        {

        }

        private void fillTitleDDL()
        {
            int i=0;
            ddlTitle.Items.Clear();

            foreach (TableCell c in GridView1.HeaderRow.Cells)
            {
                ddlTitle.Items.Add(new ListItem(c.Text, Convert.ToString(i)));
                i++;
            }
            ddlTitle.Visible = (i > 0);
        }

        private void fillDistributionDDL()
        {
            ddlDChoice.Items.Clear();

            ddlDChoice.DataSource = DistributionAnalysis.typesAsSortedList();
            ddlDChoice.DataTextField = "value";
            ddlDChoice.DataValueField = "key";
            ddlDChoice.DataBind();

        }

        private string getTitleFromGrid(int col)
        {
           return  Convert.ToString(GridView1.HeaderRow.Cells[col].Text);
        }

        private int getValuesFromGrid(int col, Double[] v)
        {
            // Pulls the values from a specific column in the GridView

            double tv;
            int tn = 1;
            for (int i = 1; i <= GridView1.Rows.Count - 1; i++)
            {
                tv = Convert.ToDouble(GridView1.Rows[i].Cells[col].Text);
                if (tv != 0)
                {
                    v[tn] = tv;
                    tn++;
                }
            }
            return tn - 1;
        }

        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            DoSingleColumnAnalysis();
            showPlot();
        }


        
        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            string d = GUIManager.GridViewAsString(GridView1);
            int dID = Convert.ToInt32(Session["DistributionID"]);
            DistributionAnalysis da = new DistributionAnalysis(dID);

            da.Insert(da.RetrieveDescription(dID), d, UserLogin.getUserID(Session));
        }

        protected void btnAnalyzeAll_Click(object sender, EventArgs e)
        {
            DoProbabilityPredictionAnalysis();
            ScatterPlot s = new ScatterPlot();

            // We only plot data from raw data columns
            // This puts the values of those columns in c
            int nc = GridView1.Rows[0].Cells.Count;
            int[] c = new int[nc];
            for (int i = 0; i < nc; i++) c[i] = i + 2;

            // This plot function prints only grid columns specified inc
            litPlot.Text = s.plotGrid("Distribution Analysis", 0, c, GridView2);
            pnlPlot.Visible = true;

        }

        protected void showPlot()
        {
            ScatterPlot s = new ScatterPlot(new string[] { "Distribution Analysis", "Weibull Probability", "Computed or Actual Value" });
            litPlot.Text = s.plotGrid( 0, GridView2);
            pnlPlot.Visible = true;
        }

        protected void hidePlot()
        {
            pnlPlot.Visible = false;

        }


        protected void DoSingleColumnAnalysis()
        {
            double[] v = new double[SMADA_2012.App_Code.SMADA.DistributionAnalysis.MAXDATA];
            int c = Convert.ToInt32(ddlTitle.SelectedValue);
            int n = getValuesFromGrid(c, v);

            DistributionAnalysis dd = new DistributionAnalysis(n, v);
            ProbabilityData pd = new ProbabilityData();
            lblG2Title.Text = " Distribution Analysis of " + ddlTitle.SelectedItem.Text;

            if (dd.calculateAll(pd))
            {
                GridView2.DataSource = dd.asDataTable();
                GridView2.DataBind();

                lblG2Title.Visible = true;
                lblM1.Visible = true;
                lblM2.Visible = true;
                lblM3.Visible = true;
                lblM1.Text = "M1: " + String.Format("{0:0.00}", dd.m1);
                lblM2.Text = "M2: " + String.Format("{0:0.00}", dd.m2);
                lblM3.Text = "M3: " + String.Format("{0:0.00}", dd.m3);
            }
        }

        protected void DoProbabilityPredictionAnalysis()
        {
            double[] v = new double[SMADA_2012.App_Code.SMADA.DistributionAnalysis.MAXDATA];
            int nd = GridView1.HeaderRow.Cells.Count; // Number of Data Columns

            ProbabilityData pd = new ProbabilityData();
            DataTable dt = pd.newDataTable();

            for (int c = 0; c <= nd - 1; c++)
            {
                string chosenDistribution = ddlDChoice.SelectedValue;
                lblG2Title.Text = chosenDistribution + " Distribution";
                int n = getValuesFromGrid(c, v); // number of data in column
                DistributionAnalysis dd = new DistributionAnalysis(n, v);

                if (dd.calculate(chosenDistribution, pd))
                {
                    dt = pd.addPredictions(dt, getTitleFromGrid(c));
                }
            }

            lblG2Title.Visible = true;

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
}