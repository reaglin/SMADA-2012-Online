using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using ISRID_SAR;

namespace SMADA_2012.UserControls
{
    public partial class ucCoordinates : System.Web.UI.UserControl
    {

        private int m_LocationCoordinatesID;

        public Label Label
        {
            get { return lblLabel; }
            set { lblLabel = value; }
        }

        public string Latitude
        {
            get { return tbNSLatitude.Text; }
            set { tbNSLatitude.Text = value; }
        }

        public string Longitude
        {
            get { return tbEWLongitude.Text; }
            set { tbEWLongitude.Text = value; }
        }

        public string CoordinateFormat
        {
            get { return cbCoordinateFormat.SelectedValue; }
            set { cbCoordinateFormat.SelectedValue = value; }
        }

        public int LocationCoordinatesID
        {
            get { return m_LocationCoordinatesID; }
            set
            {
                m_LocationCoordinatesID = value;
                if (value != 0) setValues();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) setupForm();
        }

        private void setupForm()
        {
            LocationCoordinates c = new LocationCoordinates(LocationCoordinatesID);

            GUIManager.setup(c.CoordinatesFormatCode, cbCoordinateFormat);
            GUIManager.setup(c.EastWestCoordinate, tbEWLongitude_TextBoxWatermarkExtender);
            GUIManager.setup(c.NorthSouthCoordinate, tbNSLatitude_TextBoxWatermarkExtender);

        }

        private void setValues()
        {
            LocationCoordinates c = new LocationCoordinates(LocationCoordinatesID);

            GUIManager.setValue(c.NorthSouthCoordinate, tbNSLatitude);
            GUIManager.setValue(c.EastWestCoordinate, tbEWLongitude);
            GUIManager.setValue(c.CoordinatesFormatCode, cbCoordinateFormat);
        }

        public int getValues()
        {
            // Answers the LocationCoordinatesID
            LocationCoordinates c = new LocationCoordinates(LocationCoordinatesID);

            GUIManager.getValue(c.NorthSouthCoordinate, tbNSLatitude);
            GUIManager.getValue(c.EastWestCoordinate, tbEWLongitude);
            GUIManager.getValue(c.CoordinatesFormatCode, cbCoordinateFormat);

            if (LocationCoordinatesID == 0)
                return c.Insert();
            else
            {
                c.Update();
                return LocationCoordinatesID;
            }

        }


    }
}