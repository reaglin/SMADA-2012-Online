using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.UserControls.SMADA
{
    public partial class ucEditLandUse : System.Web.UI.UserControl
    {

        public static LandUses luFile;
        public static int numberLandUses;
        public static int currentLandUse;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void setText()
        {
            tbLandUseName.Text = luFile.LandUseArray[currentLandUse].LandUseName;
//            tbRationalC.Text = Convert.ToString(luFile.LandUseArray[currentLandUse].RationalC);
//            tbPollutantData.Text = luFile.LandUseArray[currentLandUse].pollutantsAsString();

            tbXML.Text = luFile.asXML();
        }


        protected void btnAddLandUse_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddPollutant_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveNew_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveGlobal_Click(object sender, EventArgs e)
        {

        }
    }
}