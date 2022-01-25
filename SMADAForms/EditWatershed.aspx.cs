using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using gui = sage.GUIManager;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.SMADAForms
{
    public partial class EditWatershed : System.Web.UI.Page
    {
        public int WatershedID()
        {
            return gui.getID(Session, "WatershedID");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {
                setupForm();
                if (WatershedID() == 0)
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
        }

        protected void setupForm()
        {
            cbInfiltrationMethod.DataSource = Watershed.getInfiltrationMethods();
            cbInfiltrationMethod.DataTextField = "CodeNameText";
            cbInfiltrationMethod.DataValueField = "CodeDescriptionText";
            cbInfiltrationMethod.DataBind();
            cbInfiltrationMethod.Items.Insert(0, "- Select Infiltration Method -"); 
            
            setValues();
        }

        private bool getValues()
        {
            Watershed w = new Watershed();
            if (WatershedID() != 0)
                w.id.Value = Convert.ToString(WatershedID());

            w.UserID.Value = Convert.ToString(UserLogin.getUserID(Session));
            w.CreatedDate.Value = Convert.ToString(DateTime.Now);
            w.Title.getValue(tbTitle);
            w.Description.getValue(tbDescription);
            w.InfMeth.getValue(cbInfiltrationMethod);
            w.TotalArea.getValue(tbTotalArea);
            w.TimeCon.getValue(tbTimeCon);
            w.ImpArea.getValue(tbImpArea);
            w.DCIA.getValue(tbDCIA);
            w.AddAbsImp.getValue(tbAddAbsImp);
            w.AddAbsPerv.getValue(tbAddAbsPerv);
            w.MaxInf.getValue(tbMaxInf);
            w.hic.getValue(tbHIC);
            w.hio.getValue(tbHIO);
            w.hkr.getValue(tbHKR);
            w.CN.getValue(tbCN);
            
            string v = w.Validate();
            if (v == String.Empty)
            {
                w.Update();
                lblValidate.Text = String.Empty;
                return true;
            }
            else
            {
                lblValidate.Text = v;
                return false;
            }
        }

        protected void setValues()
        {
            Watershed w = new Watershed(WatershedID());
            w.Title.setValue(LabelTitle, tbTitle);
            w.Description.setValue(LabelDescription,  tbDescription);
            w.TotalArea.setValue(LabelTotalArea, tbTotalArea);
            w.InfMeth.setValue(LabelInfiltrationMethod, cbInfiltrationMethod);
            w.TimeCon.setValue(LabelTimeCon, tbTimeCon);
            w.ImpArea.setValue(LabelImpArea, tbImpArea);
            w.DCIA.setValue(LabelDCIA, tbDCIA);
            w.AddAbsImp.setValue(LabelAddAbsImp, tbAddAbsImp);
            w.AddAbsPerv.setValue(LabelAddAbsPerv, tbAddAbsPerv);
            w.MaxInf.setValue(LabelMaxInf,  tbMaxInf);
            w.hic.setValue(LabelHIC, tbHIC);
            w.hio.setValue(LabelHIO, tbHIO);
            w.hkr.setValue(LabelHKR, tbHKR);
            w.CN.setValue(LabelCN, tbCN);

            setupSelectedInfltration();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (getValues()) Response.Redirect("~/DefaultLoggedIn.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (getValues()) Response.Redirect("~/SMADAForms/SelectWatershed.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DefaultLoggedIn.aspx");
        }

        protected void cbInfiltrationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupSelectedInfltration();
        }

        protected void setupSelectedInfltration()
        {
            if (cbInfiltrationMethod.SelectedValue.Contains("SCS"))
            {
                LabelCN.Visible = true;
                tbCN.Visible = true;

                LabelHIO.Visible = false;
                tbHIO.Visible = false;

                LabelHIC.Visible = false;
                tbHIC.Visible = false;

                LabelHKR.Visible = false;
                tbHKR.Visible = false;
            }
            if (cbInfiltrationMethod.SelectedValue.Contains("Horton"))
            {
                LabelCN.Visible = false;
                tbCN.Visible = false;

                LabelHIO.Visible = true;
                tbHIO.Visible = true;

                LabelHIC.Visible = true;
                tbHIC.Visible = true;

                LabelHKR.Visible = true;
                tbHKR.Visible = true;
            }

        }
    }
}