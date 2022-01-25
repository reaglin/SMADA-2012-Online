using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
namespace SMADA_2012
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (UserLogin.ValidateLogin(TextBoxUserName.Text, TextBoxUserPassword.Text))
            {
                Session.Add("UserName", TextBoxUserName.Text);
                Response.Redirect("~/DefaultLoggedIn.aspx");
            }
            else
            {
                TextBoxUserName.Text = "";
                TextBoxUserPassword.Text = "";
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
