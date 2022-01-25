using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class EditCategory : System.Web.UI.Page
    {
        Categories c = new Categories();

        public int CategoryID()
        {
            if (Request["CategoryID"] != null)
                return Convert.ToInt32(Request["CategoryID"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));

            if (!Page.IsPostBack)
            {
                if (CategoryID() != 0)
                {
                    ButtonUpdate.Visible = true;
                    ButtonSubmit.Visible = false;
                    SetFormValues();
                }
                else
                {
                    ButtonUpdate.Visible = false;
                    ButtonSubmit.Visible = true;
                }
            }
        }


        private void SetFormValues()
        {
            c.CategoryID = CategoryID();

            if (c.CategoryID != 0)
            {
                c.Retrieve();

                TextBoxCategoryNameText.Text = c.CategoryNameText;
                TextBoxCategoryDescriptionText.Text = c.CategoryDescriptionText;
                TextBoxCategoryHelpText.Text = c.CategoryHelpText;
                CheckBoxDeletedBit.Checked = c.DeletedBit;

            }
        }

        private void GetFormValues()
        {

            c.CategoryNameText = TextBoxCategoryNameText.Text;

            if (TextBoxCategoryDescriptionText.Text != String.Empty)
                c.CategoryDescriptionText = TextBoxCategoryDescriptionText.Text;
            else
                c.CategoryDescriptionText = TextBoxCategoryNameText.Text;

            c.CategoryHelpText = TextBoxCategoryHelpText.Text;
            c.DeletedBit = CheckBoxDeletedBit.Checked;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            GetFormValues();
            c.Insert();
            Response.Redirect("~/ViewCategories.aspx");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            GetFormValues();
            c.CategoryID = CategoryID();
            c.Update();
            Response.Redirect("~/ViewCategories.aspx");

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewCategories.aspx");

        }

    }
}
