using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class EditCode : System.Web.UI.Page
    {
        // Either the codeID (for updating a code) or
        // a CategoryID (for inserting a code) will be set.

        Categories category = new Categories();
        Codes code = new Codes();

        public int CategoryID()
        {
            if (Request["CategoryID"] != null)
                return Convert.ToInt32(Request["CategoryID"]);
            else
                return Convert.ToInt32(code.CategoryID);
        }

        public int CodeID()
        {
            if (Request["CodeID"] != null)
                return Convert.ToInt32(Request["CodeID"]);
            else
                return 0;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            if (CodeID() == 0 && CategoryID() == 0) Response.Redirect("~/ViewCategories.aspx");

            if (CategoryID() == 0)
            {
                code.CodeID = CodeID();
                code.Retrieve();
            }

            setCategoryText();

            if (!Page.IsPostBack)
            {
                if (CodeID() != 0)
                {
                    ButtonUpdate.Visible = true;
                    ButtonDelete.Visible = true;
                    ButtonSubmit.Visible = false;
                    ButtonSubmit2.Visible = false;
                    SetFormValues();
                }
                else
                {
                    ButtonUpdate.Visible = false;
                    ButtonDelete.Visible = false;
                    ButtonSubmit.Visible = true;
                    ButtonSubmit2.Visible = true;
                }
            }
        }


        private void SetFormValues()
        {
            code.CodeID = CodeID();

            if (code.CodeID != 0)
            {
                code.Retrieve();

                TextBoxCodeNameText.Text = code.CodeNameText;

                TextBoxCodeDescriptionText.Text = code.CodeDescriptionText;
                TextBoxCodeHelpText.Text = code.CodeHelpText;
                CheckBoxDeletedBit.Checked = code.DeletedBit;
            }
        }

        private void setCategoryText()
        {
            if (CategoryID() != 0)
            {
                category.CategoryID = CategoryID();
                category.Retrieve();
                TextBoxCategory.Text = category.CategoryNameText;
                dgCodes.Visible = true;
                dgCodes.DataSource = category.GetCodes();
                dgCodes.DataBind();

            }
        }

        private void GetFormValues()
        {
            code.CategoryID = CategoryID();
            code.CodeNameText = TextBoxCodeNameText.Text;

            if (TextBoxCodeDescriptionText.Text != String.Empty)
                code.CodeDescriptionText = TextBoxCodeDescriptionText.Text;
            else
                code.CodeDescriptionText = TextBoxCodeNameText.Text;

            code.CodeHelpText = TextBoxCodeHelpText.Text;
            code.DeletedBit = CheckBoxDeletedBit.Checked;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            GetFormValues();
            code.Insert();

            TextBoxCodeNameText.Text = "";
            TextBoxCodeDescriptionText.Text = "";
            TextBoxCodeHelpText.Text = "";
            CheckBoxDeletedBit.Checked = false;

            Response.Redirect("~/ViewCategories.aspx?CategoryID=" + Convert.ToString(CategoryID()));
        }

        protected void ButtonSubmit2_Click(object sender, EventArgs e)
        {
            GetFormValues();
            code.Insert();

            TextBoxCodeNameText.Text = "";
            TextBoxCodeDescriptionText.Text = "";
            TextBoxCodeHelpText.Text = "";
            CheckBoxDeletedBit.Checked = false;

            Response.Redirect("~/EditCode.aspx?CategoryID=" + Convert.ToString(CategoryID()));
        }


        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            GetFormValues();
            code.CodeID = CodeID();
            code.CategoryID = CategoryID();

            code.Update();
            Response.Redirect("~/ViewCategories.aspx?CategoryID=" + Convert.ToString(CategoryID()));

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewCategories.aspx?CategoryID=" + Convert.ToString(CategoryID()));

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int cat = CategoryID();
            Codes c = new Codes(CodeID());
            c.Delete();
            Response.Redirect("~/ViewCategories.aspx?CategoryID=" + Convert.ToString(CategoryID()));
        }

        protected void dgCodes_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Codes c = new Codes(id);
                c.Delete();

                Response.Redirect("~/EditCode.aspx?CategoryID=" + Convert.ToString(CategoryID()));
            }
        }
    }
}
