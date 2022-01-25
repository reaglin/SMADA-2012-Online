using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code;
namespace SMADA_2012
{
    public partial class EditFormHeader : System.Web.UI.Page
    {
        static string prevPage = String.Empty;

        public string EditHeader()
        {
           if (Session["EditHeader"] != null)
                return Convert.ToString(Session["EditHeader"]);
            else
                return String.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            if (!IsPostBack)
            {
                lblTitle.Text = EditHeader();
                literalHeader.Text = FormHeaders.getFormHeaderText(EditHeader());
                tbEdit.Text = literalHeader.Text;
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            FormHeaders.insertFormHeader(EditHeader(), tbEdit.Text);
            Response.Redirect(prevPage);
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

    }
}