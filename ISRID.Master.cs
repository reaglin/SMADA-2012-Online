using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.UserControls;

namespace SMADA_2012
{
    public partial class ISRID : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitle.Text = this.Page.Header.Title;
            if (UserLogin.isLoggedIn(Session))
            {
                lbLogout.Visible = true;
                lblUserName.Text = Convert.ToString(Session["UserName"]);
            }
            else
            {
                lbLogout.Visible = false;
            }
            if (!IsPostBack)
            {
                ucFormHeaderTop.PageTitle = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath) + "Header";
                ucFormHeaderBottom.PageTitle = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath) + "Footer";
            }
           }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(UserLogin.defaultURL());
        }

        protected void lbFeedback_Click(object sender, EventArgs e)
        {
            string page = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath);
            Session.Add("PageName", page);
            Response.Redirect("~/InsertFeedback.aspx");
        }
    }
}
