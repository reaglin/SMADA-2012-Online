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
    public partial class AnalyzePollutantLoading : System.Web.UI.Page
    {
        public static LandUses luFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                if (Session["LandUsesID"] != null)
                {
                    int rid = Convert.ToInt32(Session["LandUsesID"]);
                    luFile = new LandUses(rid);
                    fillForm();
                }
                else
                {
                    Response.Redirect("~/SMADAForms/ManageLandUses.aspx");
                }
            }
        }

        protected void fillForm()
        {
            luFile.Retrieve();
            GridView1.DataSource = luFile.asDataTable();
            GridView1.DataBind();

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            // Need to get data
            int i = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox tbArea = (TextBox)row.FindControl("tbArea");
                TextBox tbRainfall = (TextBox)row.FindControl("tbRainfall");

                if (tbArea.Text != String.Empty)
                {
                    luFile.LandUseArray[i].Area = Convert.ToSingle(tbArea.Text);
                    if (tbRainfall.Text != String.Empty)
                        luFile.LandUseArray[i].Rainfall = GlobalFunctions.asFloat(tbRainfall);
                    else
                        luFile.LandUseArray[i].Rainfall = GlobalFunctions.asFloat(tbGRainfall);
                    i++;
                }
            }
            gvResults.Visible = true;
            gvResults.DataSource = luFile.calculate();
            gvResults.DataBind();

        }
    }
}