using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012.UserControls
{
    public partial class ucCodeSelector : System.Web.UI.UserControl
    {
        public int CategoryID
        {
            get { return Convert.ToInt32(Session["CategoryID"]); }
            set { Session.Add("CategoryID", value);  }
        }

        public string Category
        {
            get { return Categories.asString(CategoryID); }
            set { CategoryID = Categories.GetCategoryID(value); }

        }
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text =  value; }

        }

        public string SelectedValue
        {
            get { return Convert.ToString(rblCodes.SelectedValue); }
        }

        public delegate void CancelClickedEventHandler(object sender, EventArgs e);
        public delegate void SelectClickedEventHandler(object sender, EventArgs e);

        public event CancelClickedEventHandler CancelButtonClicked;
        public event SelectClickedEventHandler SelectButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CategoryID != null)
            {
                if (Title == String.Empty) Title = Category;
                rblCodes.DataSource = Categories.getCodes(CategoryID);
                rblCodes.DataTextField = Codes.CodeTextField;
                rblCodes.DataValueField = Codes.CodeValueField;
                rblCodes.DataBind();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectButtonClicked != null) SelectButtonClicked(this, e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null) CancelButtonClicked(this, e);
        }
    }
}