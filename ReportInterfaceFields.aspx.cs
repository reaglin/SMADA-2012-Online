using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012.UserControls
{
    public partial class ReportInterfaceFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            phInterface.Controls.Add(new LiteralControl(GUIManager.asHTML()));
        }
    }
}
