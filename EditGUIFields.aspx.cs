using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class EditGUIFields : System.Web.UI.Page
    {
        GUIField g = new GUIField();

        public int GUIFieldID()
        {
            if (Request["GUIFieldID"] != null)
                return Convert.ToInt32(Request["GUIFieldID"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            if (!Page.IsPostBack)
            {
                cbCategoryText.DataSource = Categories.getAllCategories();
                cbCategoryText.DataTextField = "CategoryNameText";
                cbCategoryText.DataValueField = "CategoryNameText";
                cbCategoryText.DataBind();
                cbCategoryText.Items.Insert(0, String.Empty);

                if (GUIFieldID() == 0)
                {
                    ButtonUpdate.Visible = false;
                    ButtonSubmit.Visible = true;
                }
                else
                {
                    ButtonUpdate.Visible = true;
                    ButtonSubmit.Visible = false;
                    setValues();
                }
            }
        }

        private void getValues()
        {
            g.TableNameText = tbTableName.Text;
            g.FieldNameText = tbFieldName.Text;

            if ((tbPromptText.Text == String.Empty) && (cbCategoryText.SelectedIndex != 0))
                g.PromptText = cbCategoryText.SelectedValue;
            else
                g.PromptText = tbPromptText.Text;

            if (cbCategoryText.SelectedIndex != 0)
                g.CategoryNameText = cbCategoryText.SelectedValue;

            if (cbInterfaceElement.SelectedIndex != 0)
                g.InterfaceElementText = cbInterfaceElement.SelectedValue;

            g.TooltipText = tbTooltip.Text;
            g.Width = tbWidth.Text;
            g.HelpText = tbHelpText.Text;
        }

        private void setValues()
        {
            g.GUIFieldID = GUIFieldID();
            g.Retrieve();

            tbTableName.Text = g.TableNameText;
            tbFieldName.Text = g.FieldNameText;
            tbPromptText.Text = g.PromptText;
            if (g.CategoryNameText != String.Empty)
                cbCategoryText.SelectedValue = g.CategoryNameText;

            if (g.InterfaceElementText != String.Empty)
                cbInterfaceElement.SelectedValue = g.InterfaceElementText;

            tbTooltip.Text = g.TooltipText;
            tbWidth.Text = g.Width;
            tbHelpText.Text = g.HelpText;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            getValues();
            g.Insert();
            Response.Redirect("~/ViewGUIFields.aspx");

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            g.GUIFieldID = GUIFieldID();
            getValues();
            g.Update();
            Response.Redirect("~/ViewGUIFields.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewGUIFields.aspx");
        }
    }
}
