using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using gui = sage.GUIManager;

namespace SMADA_2012
{
    public partial class EditDatabaseTransfer : System.Web.UI.Page
    {

        public int DatabaseTransferID()
        {
            if (Request["DatabaseTransferID"] != null)
                return Convert.ToInt32(Request["DatabaseTransferID"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setup();
                setValues();
            }
        }

        private void setup()
        {
            DatabaseTransferSystem dts = new DatabaseTransferSystem(DatabaseTransferID());
            gui.setup(dts.SourceIDName, lblSourceID, tbSourceID);
            gui.setup(dts.SourceConnectionString, lblSourceConnectionString, tbSourceConnectionString);
            gui.setup(dts.DestinationConnectionString, lblDestConnectionString, tbDestConnectionString);
            gui.setup(dts.RootTableName, lblRootTable, tbRootTable);
        }

        private void setValues()
        {
            DatabaseTransferSystem dts = new DatabaseTransferSystem(DatabaseTransferID());
            if (DatabaseTransferID() == 0) return;
            gui.setValue(dts.SourceIDName, tbSourceID);
            gui.setValue(dts.SourceConnectionString, tbSourceConnectionString);
            gui.setValue(dts.DestinationConnectionString, tbDestConnectionString);
            gui.setValue(dts.RootTableName, tbRootTable);

        }

        private void getValues()
        {
            DatabaseTransferSystem dts = new DatabaseTransferSystem(DatabaseTransferID());
            gui.getValue(dts.SourceIDName, tbSourceID);
            gui.getValue(dts.SourceConnectionString, tbSourceConnectionString);
            gui.getValue(dts.DestinationConnectionString, tbDestConnectionString);
            gui.getValue(dts.RootTableName, tbRootTable);

            if (DatabaseTransferID() == 0)
                dts.Insert();
            else
                dts.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewDataTransfers.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            getValues();
            Response.Redirect("~/ViewDataTransfers.aspx");
        }
    }
}
