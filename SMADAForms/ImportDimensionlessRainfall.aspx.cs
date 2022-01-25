using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code.SMADA;
using gui = sage.GUIManager;

namespace SMADA_2012.SMADAForms
{
    public partial class ImportDimensionlessRainfall : System.Web.UI.Page
    {
        public int RainfallID()
        {
            if (Session["RainfallID"] != null)
                return Convert.ToInt32(Session["RainfallID"]);
            else
                return 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {
                setupForm();
            }
        }
        protected void setupForm()
        {
            setValues();
        }

        protected void setValues()
        {
            if (RainfallID() == 0) return;
            Rainfall r = new Rainfall(RainfallID());

            r.id.setValue(lblid, tbid);
            r.Title.setValue(lblTitle, tbTitle);
            r.Description.setValue(lblDescription,  tbDescription);
            tbValues.Text = r.dimensionlessValuesAsString();

            if (r.isDimensionless()) btnPublic.Visible = UserLogin.isAdministrator(Session);

        }

        protected void getValues()
        {
            Rainfall r = new Rainfall(RainfallID());

            r.UserID.Value = Convert.ToString(UserLogin.getUserID(Session));
            r.CreatedDate.Value = Convert.ToString(DateTime.Now);

            r.Title.getValue( tbTitle);
            r.Description.getValue(tbDescription);
            r.IsDimensionless.Value = "True";

            r.importDimensionlessCumulativeValuesFromString(tbValues.Text); 
            r.Update();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            getValues();
            Response.Redirect("~/SMADAForms/SelectRainfall.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DefaultLoggedIn.aspx");
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if (tbIncrement.Text == String.Empty) return;
 
            Rainfall r = new Rainfall(RainfallID());
            r.UserID.Value = Convert.ToString(UserLogin.getUserID(Session));
            r.CreatedDate.Value = Convert.ToString(DateTime.Now);

            r.Title.getValue(tbTitle);
            r.Description.getValue(tbDescription);
            r.IsDimensionless.Value = "True";
            r.importDimensionlessIncrementalValuesFromString(tbIncrement.Text);
            tbid.Text = Convert.ToString(r.Update());

            tbValues.Text = r.dimensionlessValuesAsString();
        }

        protected void btnPublic_Click(object sender, EventArgs e)
        {
            int rid = RainfallID();
            if (rid == 0) return;

            // Makes rainall publicly available - only available to administrators
            Rainfall.ConvertDimensionlessToPublic(rid);
        }


    }
}