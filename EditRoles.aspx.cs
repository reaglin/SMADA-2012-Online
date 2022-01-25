using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class EditRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            dgUserRoles.DataSource = UserLogin.getAllUserRoles();
            dgUserRoles.DataBind();

        }

        protected void dgUserRoles_RowCommand(object sender, DataGridCommandEventArgs e)
        {
            if ((string)e.CommandName == "add")
            {
                UserLogin ul = new UserLogin(Convert.ToInt32(e.CommandArgument));
                ul.setAsAministrator();
            }

            if ((string)e.CommandName == "remove")
            {
                UserLogin ul = new UserLogin(Convert.ToInt32(e.CommandArgument));
                ul.deleteAministrator();
            }
        }

        public bool isAdministrator(Object UserName)
        {
            return UserLogin.isAdministrator(Convert.ToString(UserName));
        }

        public bool isNotAdministrator(Object UserName)
        {
            return !isAdministrator(UserName);
        }
    }
}
