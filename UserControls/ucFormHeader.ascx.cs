using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code;

namespace SMADA_2012.UserControls
{
    public partial class ucFormHeader : System.Web.UI.UserControl
    {
        private string m_pagetitle;
        public string PageTitle
        {
            get { return hidden.Value ; }
            set {
                hidden.Value  = value;
                literalHeader.Text = FormHeaders.getFormHeaderText(value);}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            Session.Add("EditHeader", PageTitle);
            Response.Redirect("~/EditFormHeader.aspx");
        }

        protected void lbEdit_Click1(object sender, EventArgs e)
        {

        }

    }
}