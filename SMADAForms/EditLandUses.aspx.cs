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
    public partial class EditLandUses : System.Web.UI.Page
    {
        public static LandUses luFile;
        public static int numberLandUses;
        public static int currentLandUse;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            btnSaveGlobal.Visible = UserLogin.isAdministrator(Session);

            if (!IsPostBack)
            {
                if (Session["LandUsesID"] != null)
                {
                    int rid = Convert.ToInt32(Session["LandUsesID"]);
                    luFile = new LandUses(rid);
                    numberLandUses = luFile.nLandUses;
                    fillForm();
                }
                else
                {
                    numberLandUses = 0;
                    luFile = new LandUses();
                }
            }
        }

        public void fillForm()
        {
            tbXML.Text = luFile.asXML();
            tbName.Text = luFile.DescriptionText;
            fillLandUseList();
        }

        public void fillLandUseList()
        {
            if (luFile.nLandUses > 0)
            {
                rblLandUses.DataSource = luFile.landUseNames();
                rblLandUses.DataBind();
            }
        }

        protected void rblLandUses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Need to put new values in forms
            currentLandUse = rblLandUses.SelectedIndex;
            btnAddLandUse.Text = "Edit Land Use";
            setText();
        }

        protected void setText()
        {
            tbLandUseName.Text = luFile.LandUseArray[currentLandUse].LandUseName;
            tbRationalC.Text = Convert.ToString(luFile.LandUseArray[currentLandUse].RationalC);
            tbPollutantData.Text = luFile.LandUseArray[currentLandUse].pollutantsAsString();

            tbXML.Text = luFile.asXML();
        }

        protected void btnAddLandUse_Click(object sender, EventArgs e)
        {
            enterLandUse();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            luFile.DescriptionText = tbName.Text;
            string s = getXML();

            if (s == string.Empty)
            {
                return;
            }

            luFile.DataText = s;
            
            int UserID = UserLogin.getUserID(Session);
            if (Session["LandUsesID"] == null)
            {
                Session.Add("LandUseID", luFile.Insert(UserID));
                Response.Redirect("~/SMADAForms/ManageLandUses.aspx");
            }
            else
            {
                luFile.Update(UserID);
                Response.Redirect("~/SMADAForms/ManageLandUses.aspx");
            }
        }

        protected void enterLandUse()
        {
            // This adds a new Land Use
            if ((currentLandUse == -1) || (numberLandUses == 0))
            {
                luFile.addLandUse(tbLandUseName.Text, Convert.ToSingle(tbRationalC.Text), tbPollutantData.Text);
                btnAddLandUse.Text = "Add Land Use";
                currentLandUse = -1;
            }
            else
            {
                luFile.LandUseArray[currentLandUse].LandUseName =  tbLandUseName.Text;
                luFile.LandUseArray[currentLandUse].RationalC = Convert.ToSingle(tbRationalC.Text);
                luFile.LandUseArray[currentLandUse].addPollutants(tbPollutantData.Text);
                currentLandUse = -1;
            }
            clearFields();
            tbXML.Text = luFile.asXML();
        }

        protected void clearFields()
        {
            tbLandUseName.Text = String.Empty;
            tbRationalC.Text = String.Empty;
            tbPollutantData.Text = String.Empty;
        }

        protected string getXML()
        {
            if (SMADABase.testXmlWellFormed(tbXML.Text))
            {
                lblError.Visible = false;
                return tbXML.Text;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "XML is not well formed - check XML file";
                return string.Empty;
            }
        }

        protected void btnSaveNew_Click(object sender, EventArgs e)
        {
            int UserID = UserLogin.getUserID(Session);
            saveFile(UserID);
        }

        protected void btnSaveGlobal_Click(object sender, EventArgs e)
        {
            saveFile(0);        
        }

        protected void saveFile(int uID)
        {
            LandUses luNewFile = new LandUses();

            luNewFile.DescriptionText = tbName.Text;
            string s = getXML();
            if (s == string.Empty)
            {
                // Do Nothing
            }
            else
            {
                luNewFile.DataText = s;
                int UserID = UserLogin.getUserID(Session);
                luNewFile.Insert(uID);
                Response.Redirect("~/SMADAForms/ManageLandUses.aspx");
            }

        }
    
    }
}