using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class ViewGUIFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));

            gvGUIFields.DataSource = DatabaseField.getAll();
            gvGUIFields.DataBind();
        }
    }
}
