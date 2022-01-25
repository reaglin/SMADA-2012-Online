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
    public partial class EditRainfall : System.Web.UI.Page
    {
        public int RainfallID()
        {
            return gui.getID(Session, "RainfallID");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");

            if (!Page.IsPostBack)
            {
                setupForm();
                if (RainfallID() == 0)
                {
                    btnValues.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = true;
                    btnValues.Visible = true;
                    btnSave.Visible = false;
                }
            }
        }

        protected void setupForm()
        {
            setupLabels();
            setValues();
        }

        protected void setupLabels()
        {
            Rainfall r = new Rainfall();
            int UserID = UserLogin.getUserID(Session);

            cbDimensionlessID.DataSource = Rainfall.dimensionlessRainfalls(UserID);
            cbDimensionlessID.DataTextField = "Title";
            cbDimensionlessID.DataValueField = "id";
            cbDimensionlessID.DataBind();
            cbDimensionlessID.Items.Insert(0, "- Select Dimensionless Rainfall -"); 
        }

        protected void setValues()
        {
            Rainfall r = new Rainfall(RainfallID());

            r.Title.setValue( lblTitle, tbTitle);
            r.Description.setValue( lblDescription, tbDescription);

            // Uses a dimensionless rainfall to create
            if (r.DimensionlessID.asInteger() != 0)
                cbDimensionlessID.SelectedIndex  = r.DimensionlessID.asInteger();

            r.DimensionlessID.setValue(lblDimensionlessID, cbDimensionlessID);
            r.TimeStep.setValue( lblTimeStep, tbTimeStep);
            r.NumberOfSteps.setValue( lblNumberOfSteps,  tbNumberOfSteps);
            r.Duration.setValue( lblDuration, tbDuration);
            r.Total.setValue( lblTotal, tbTotal);

        }

        private bool getValues()
        {
            Rainfall r = new Rainfall(RainfallID());

            r.UserID.Value = Convert.ToString(UserLogin.getUserID(Session));
            r.CreatedDate.Value = Convert.ToString(DateTime.Now);

            r.Title.getValue( tbTitle);

            if (tbDescription.Text == String.Empty)
                r.Description.getValue(tbTitle);
            else
                r.Description.getValue(tbDescription);

            r.Type.Value = string.Empty;
            r.DimensionlessID.getValue( cbDimensionlessID);
            r.TimeStep.getValue( tbTimeStep);
            r.NumberOfSteps.getValue(tbNumberOfSteps);
            r.Duration.getValue(tbDuration);
            r.Total.getValue(tbTotal);

            string v = r.Validate();
            if (v == String.Empty)
            {
                if (r.DimensionlessID.asInteger() != 0) r.createFromDimensionlessRainfall();
                r.Update();
                lblValidate.Text = String.Empty;
                return true;
            }
            else
            {
                lblValidate.Text = v;
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (getValues()) redirectToForm();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (getValues()) redirectToForm();
        }

        protected void btnValues_Click(object sender, EventArgs e)
        {
            getValues();
        }

        protected void redirectToForm()
        {
            Rainfall r = new Rainfall(RainfallID());

            if (r.isDimensionless())
            {
                Response.Redirect("~/SMADAForms/ImportDimensionlessRainfall.aspx");
            }
            else
            {
                Response.Redirect("~/SMADAForms/SelectRainfall.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DefaultLoggedIn.aspx");
        }

        protected void btnCalculateNS_Click(object sender, EventArgs e)
        {
            double ts = Convert.ToDouble(tbTimeStep.Text);
            double d = Convert.ToDouble(tbDuration.Text);
            tbNumberOfSteps.Text = Convert.ToString(Rainfall.calculateNumberOfSteps(ts,d));
        }

        protected void btnCalculateDuration_Click(object sender, EventArgs e)
        {
            int ns = Convert.ToInt32(tbNumberOfSteps.Text);
            double ts = Convert.ToDouble(tbTimeStep.Text);
            tbDuration.Text = Convert.ToString(Rainfall.calculateDuration(ts,ns));
        }

    }
}