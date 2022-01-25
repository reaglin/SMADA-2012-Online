using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using ISRID_SAR;

namespace SMADA_2012
{
    public partial class ViewDataTransfers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            dgTransfers.DataSource = dboperations.ExecuteSQLReturnDataTable("SELECT * FROM DatabaseTransfer");
            dgTransfers.DataBind();
        }

        protected void dgTransfers_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ISRIDDataTransfer idt = new ISRIDDataTransfer();
                lblMessage.Text = idt.doTransfer(id, UserLogin.getUserID(Session));
            }

            if (e.CommandName == "print")
            {
                string id = Convert.ToString(e.CommandArgument);
                Response.Redirect("~/ReportGeneric.aspx?Type=DatabaseTransfer&DatabaseTransferID=" + id);
            }
        }

    }
}
