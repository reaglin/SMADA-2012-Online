using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class EditUserLogin : System.Web.UI.Page
    {
        UserLogin userlogin = new UserLogin();

        public string UserName()
        {
            if (Session["UserName"] == null) return String.Empty;
            return Convert.ToString(Session["UserName"]);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (UserName() != String.Empty)
                {
                    ButtonUpdate.Visible = true;
                    ButtonSubmit.Visible = false;
                    SetFormValues();
                    TextBoxUserName.Enabled = false;
                }
                else
                {
                    ButtonUpdate.Visible = false;
                    ButtonSubmit.Visible = true;
                }
                lblMessage.Text = "";
            }
        }

        private bool SetFormValues()
        {

            if (!userlogin.Retrieve(UserName())) return false;

            TextBoxUserName.Text = userlogin.UserName;
            TextBoxUserPassword.Text = userlogin.UserPassword;
            TextBoxUserFullName.Text = userlogin.UserFullName;
            TextBoxUserEmail.Text = userlogin.UserEmail;
            TextBoxUserPhone.Text = userlogin.UserPhone;

            return true;
        }

        private void GetFormValues()
        {
            // Reads values from user interface

            userlogin.UserName = TextBoxUserName.Text;
            userlogin.UserPassword = TextBoxUserPassword.Text;
            userlogin.UserFullName = TextBoxUserFullName.Text;
            userlogin.UserEmail = TextBoxUserEmail.Text;
            userlogin.UserPhone = TextBoxUserPhone.Text;

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            GetFormValues();
            lblMessage.Text = "";
            if (!userlogin.Insert())
            {
                lblMessage.Visible = true;
                lblMessage.Text = "User Login Name Already In Use";
            }

            else Response.Redirect("~/Default.aspx");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            GetFormValues();
            userlogin.Update();
            Response.Redirect("~/DefaultLoggedIn.aspx");

        }

    }
}
