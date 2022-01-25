using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMADA_2012.App_Code.SMADA;
using SMADA_2012.App_Code;
using sage;

namespace SMADA_2012.SMADAForms
{
    public partial class EditRegression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                tbSample.Text = "1,2\n3;4\n5 6\n6\t7\n8  9";
                if (Session["RegressionID"] != null)
                {
                    int rid = Convert.ToInt32(Session["RegressionID"]);
                    RegressionAnalysis ra = new RegressionAnalysis();

                    tbTitle.Text = ra.RetrieveDescription(rid);
                    tbData.Text = ra.RetrieveData(rid);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string t = tbTitle.Text;
            string d = SpreadsheetPaste.convertToTabDelimited(tbData.Text);

            // Insert new Data or Update existing data in database
            RegressionAnalysis ra = new RegressionAnalysis();

            if (Session["RegressionID"] == null)
                ra.Insert(t, d, UserLogin.getUserID(Session));
            else
                ra.Update(t, d, Convert.ToInt32(Session["RegressionID"]));

            tbTitle.Text = String.Empty;
            tbData.Text = String.Empty;
            Session["RegressionID"] = null;
            Response.Redirect("ManageRegression.aspx");

        }

        protected void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            string t = tbTitle.Text;
            string d = SpreadsheetPaste.convertToTabDelimited(tbData.Text);

            RegressionAnalysis ra = new RegressionAnalysis();

            ra.Insert(t, d, UserLogin.getUserID(Session));
            Session["RegressionID"] = null;

            Response.Redirect("ManageRegression.aspx");
        }
    }
}