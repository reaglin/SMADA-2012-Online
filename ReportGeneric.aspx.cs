using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class ReportGeneric : System.Web.UI.Page
    {
        public string Type()
        {
            return Request["Type"];
        }

        public string TableName()
        {
            if (Convert.ToString(Request["TableName"]) == null) return String.Empty;
            return Convert.ToString(Request["TableName"]);
        }
        public string HelpForm()
        {
            if (Convert.ToString(Request["HelpForm"]) == null) return String.Empty;
            return Convert.ToString(Request["HelpForm"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Type())
            {
                case "ExportCategories":
                    ph.Controls.Add(new LiteralControl(Categories.ExportAll()));
                    return;
                case "DatabaseTransfer":
                    int pk = Convert.ToInt32(Request["DatabaseTransferID"]);
                    if (pk == 0)
                    {
                        DatabaseTransferSystem dts = new DatabaseTransferSystem();
                        ph.Controls.Add(new LiteralControl(dts.asHTML()));
                        return;
                    }
                    else
                    {
                        DatabaseTransferSystem dts = new DatabaseTransferSystem(pk);
                        ph.Controls.Add(new LiteralControl(dts.transferAsHTML()));
                        return;
                    }
                default:
                    if (TableName() != String.Empty)
                    {
                        ph.Controls.Add(new LiteralControl(dboperations.generateInsert(TableName())));
                        return;
                    }

                    if (HelpForm() != String.Empty)
                    {
                        ph.Controls.Add(new LiteralControl(GUIManager.getHelp(HelpForm())));
                        return;
                    }
                    return;
            }

            {

            }
        }
    }
}
