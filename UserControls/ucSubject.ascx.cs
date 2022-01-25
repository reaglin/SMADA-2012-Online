using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using ISRID_SAR;
using gui = sage.GUIManager;

namespace SMADA_2012.UserControls
{

    public partial class ucSubject : System.Web.UI.UserControl
    {
        private int m_SubjectID;
        private int m_SubjectNumber;
        private bool m_IsMedicalData;

        public int IncidentSubjectID
        {
            get { return m_SubjectID; }
            set
            {
                m_SubjectID = value;
            }
        }

        public int SubjectNumber
        {
            get { return m_SubjectNumber; }
            set
            {
                lblNum.Text = Convert.ToString(value);
                m_SubjectNumber = value;
            }
        }

        public int IncidentID()
        {
            if (Session["IncidentID"] != null)
                return Convert.ToInt32(Session["IncidentID"]);
            else
                return 0;
        }


        public bool IsMedicalData
        {
            get { return m_IsMedicalData; }
            set { m_IsMedicalData = value; }
        }

        public bool isModified = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setupFields();
            }
        }

        private void setupFields()
        {
            if (IsMedicalData)
            {
                cbSex.Visible = false;
                cbLocal.Visible = false;
                cbWeight.Visible = false;
                cbHeight.Visible = false;
                cbBuild.Visible = false;
                cbFitness.Visible = false;
                cbExperience.Visible = false;
                cbEquipment.Visible = false;
                cbClothing.Visible = false;
                cbSurvival.Visible = false;
                cbMental.Visible = false;
                cbInjuryType.Visible = true;
                cbStatus.Visible = true;
                cbMechanism.Visible = true;
                cbIllness.Visible = true;
                cbTxBy.Visible = true;
            }
            else
            {
                cbSex.Visible = true;
                cbLocal.Visible = true;
                cbBuild.Visible = true;
                cbHeight.Visible = true;
                cbBuild.Visible = true;
                cbFitness.Visible = true;
                cbExperience.Visible = true;
                cbEquipment.Visible = true;
                cbClothing.Visible = true;
                cbSurvival.Visible = true;
                cbMental.Visible = true;
                cbInjuryType.Visible = false;
                cbStatus.Visible = false;
                cbMechanism.Visible = false;
                cbIllness.Visible = false;
                cbTxBy.Visible = false;

            }


            IncidentSubject s = new IncidentSubject(IncidentSubjectID);

            gui.setup(s.SubjectAge, tbAge_TextBoxWatermarkExtender);
            gui.setup(s.SubjectSexCode, cbSex);
            gui.setup(s.SubjectLocalCode, cbLocal);
            gui.setup(s.SubjectBuildCode, cbBuild);
            gui.setup(s.SubjectWeightCode, cbWeight);
            gui.setup(s.SubjectHeightCode, cbHeight);
            gui.setup(s.SubjectFitnessCode, cbFitness);
            gui.setup(s.SubjectExperienceCode, cbExperience);
            gui.setup(s.SubjectEquipmentCode, cbEquipment);
            gui.setup(s.SubjectClothingCode, cbClothing);
            gui.setup(s.SubjectSurvivalCode, cbSurvival);
            gui.setup(s.SubjectMentalCode, cbMental);
            gui.setup(s.SubjectStatusCode, cbStatus);
            gui.setup(s.SubjectMechanismCode, cbMechanism);
            gui.setup(s.SubjectInjuryTypeCode, cbInjuryType);
            gui.setup(s.SubjectIllnessCode, cbIllness);
            gui.setup(s.SubjectTxByCode, cbTxBy);

        }

        public void setValues()
        {
            IncidentSubject s = new IncidentSubject(getSubjectID());

            gui.setValue(s.SubjectAge, tbAge);
            gui.setValue(s.SubjectNumber, lblNum);
            gui.setValue(s.SubjectSexCode, cbSex);
            gui.setValue(s.SubjectLocalCode, cbLocal);
            gui.setValue(s.SubjectBuildCode, cbBuild);
            gui.setValue(s.SubjectWeightCode, cbWeight);
            gui.setValue(s.SubjectHeightCode, cbHeight);
            gui.setValue(s.SubjectFitnessCode, cbFitness);
            gui.setValue(s.SubjectExperienceCode, cbExperience);
            gui.setValue(s.SubjectEquipmentCode, cbEquipment);
            gui.setValue(s.SubjectClothingCode, cbClothing);
            gui.setValue(s.SubjectSurvivalCode, cbSurvival);
            gui.setValue(s.SubjectMentalCode, cbMental);
            gui.setValue(s.SubjectStatusCode, cbStatus);
            gui.setValue(s.SubjectMechanismCode, cbMechanism);
            gui.setValue(s.SubjectInjuryTypeCode, cbInjuryType);
            gui.setValue(s.SubjectIllnessCode, cbIllness);
            gui.setValue(s.SubjectTxByCode, cbTxBy);

        }

        public void getValues()
        {
            IncidentSubject s = new IncidentSubject(getSubjectID());
            IncidentSubject s2 = new IncidentSubject(getSubjectID());

            s.IncidentID.Value = Convert.ToString(IncidentID());
            s2.IncidentID.Value = Convert.ToString(IncidentID());

            gui.getValue(s.SubjectAge, tbAge);
            gui.getValue(s.SubjectSexCode, cbSex);
            gui.getValue(s.SubjectLocalCode, cbLocal);
            gui.getValue(s.SubjectBuildCode, cbBuild);
            gui.getValue(s.SubjectWeightCode, cbWeight);
            gui.getValue(s.SubjectHeightCode, cbHeight);
            gui.getValue(s.SubjectFitnessCode, cbFitness);
            gui.getValue(s.SubjectExperienceCode, cbExperience);
            gui.getValue(s.SubjectEquipmentCode, cbEquipment);
            gui.getValue(s.SubjectClothingCode, cbClothing);
            gui.getValue(s.SubjectSurvivalCode, cbSurvival);
            gui.getValue(s.SubjectMentalCode, cbMental);
            gui.getValue(s.SubjectStatusCode, cbStatus);
            gui.getValue(s.SubjectMechanismCode, cbMechanism);
            gui.getValue(s.SubjectInjuryTypeCode, cbInjuryType);
            gui.getValue(s.SubjectIllnessCode, cbIllness);
            gui.getValue(s.SubjectTxByCode, cbTxBy);

            if (getSubjectID() != 0)
            {
                gui.getValue(s.SubjectNumber, lblNum);
                s.Update();
                return;
            }
            else
            {
                if (s != s2)
                {
                    gui.getValue(s.SubjectNumber, lblNum);
                    s.Insert();
                }
            }
        }

        private int getSubjectID()
        {
            if (IncidentSubjectID == 0)
                IncidentSubjectID = IncidentSubject.getSubjectID(IncidentID(), SubjectNumber);

            return IncidentSubjectID;
        }

    }
}