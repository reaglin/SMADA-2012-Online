using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using sage;
using gui = sage.GUIManager;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.SMADAForms
{
    public partial class EditHydrograph : System.Web.UI.Page
    {
        public int HydrographID
        {
            get { return gui.getID(Session, "HydrographID"); }
            set { Session.Add("HydrographID", value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {
                setupForm();
                if (HydrographID == 0)
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
                setValues();
            }
        }

        protected void setupForm()
        {
            gui.FillComboBox("HydrographGenerationMethods", ddlHydrographMethod);

            int uid = UserLogin.getUserID(Session);
            DataTable dtw = Watershed.UserWatersheds(uid);
            ddlWatershedID.DataSource = dtw;
            ddlWatershedID.DataTextField = "Title";
            ddlWatershedID.DataValueField = "id";
            ddlWatershedID.DataBind();
            ddlWatershedID.Items.Insert(0, new ListItem("Please Select Watershed", "null"));

            DataTable dtr = Rainfall.UserRealRainfalls(uid);
            ddlRainfallID.DataSource = dtr;
            ddlRainfallID.DataTextField = "Title";
            ddlRainfallID.DataValueField = "id";
            ddlRainfallID.DataBind();
            ddlRainfallID.Items.Insert(0, new ListItem("Please Select Rainfall", "null"));
        }


        protected void setValues()
        {
            Hydrograph h = new Hydrograph(HydrographID);

            h.id.setValue(lblid, tbid);
            h.Title.setValue(lblTitle, tbTitle);
            h.Description.setValue(lblDescription, tbDescription);
            h.HydrographMethod.setValue(lblHydrographMethod, ddlHydrographMethod);
            h.PeakAttFactor.setValue(lblPeakAttFactor, tbPeakAttFactor);
            h.WatershedID.setValue(lblWatershedID, ddlWatershedID);
            h.RainfallID.setValue(lblRainfallID, ddlRainfallID);
        }

        private bool getValues()
        {
            Hydrograph h = new Hydrograph();
            if (HydrographID != 0) h.id.Value = Convert.ToString(HydrographID);

            h.UserID.Value = Convert.ToString(UserLogin.getUserID(Session));
            h.CreatedDate.Value = Convert.ToString(DateTime.Now);

            h.Title.getValue(tbTitle);
            h.Description.getValue(tbDescription);
            h.HydrographMethod.getValue(ddlHydrographMethod);
            h.PeakAttFactor.getValue(tbPeakAttFactor);
            h.WatershedID.Value = ddlWatershedID.SelectedValue;
            h.RainfallID.Value = ddlRainfallID.SelectedValue;

            string v = h.Validate();
            if (v == String.Empty)
            {
                HydrographID = h.Update();
                Response.Redirect("~/SMADAForms/PrintHydrograph.aspx");
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
            if (getValues()) Response.Redirect("~/DefaultLoggedIn.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (getValues())  Response.Redirect("~/SMADAForms/PrintHydrograph.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DefaultLoggedIn.aspx");
        }
    }
}