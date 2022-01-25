using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012.ISRIDForms
{
    public partial class EditDataField : System.Web.UI.Page
    {
        DatabaseField g = new DatabaseField();

        public int id()
        {
            if (Request["id"] != null)
                return Convert.ToInt32(Request["id"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isAdministrator(Session)) Response.Redirect(UserLogin.bounceURL(Session));
            if (!Page.IsPostBack)
            {
                g.id = id();
                g.Retrieve();
                cbCategoryText.DataSource = Categories.getAllCategories();
                cbCategoryText.DataTextField = "CategoryNameText";
                cbCategoryText.DataValueField = "CategoryNameText";
                cbCategoryText.DataBind();
                cbCategoryText.Items.Insert(0, String.Empty);

                if (g.id == 0)
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
            g.tableNameText = lblTableName.Text;
            g.fieldNameText = lblFieldName.Text;

            if ((tbPromptText.Text == String.Empty) && (cbCategoryText.SelectedIndex != 0))
                g.promptText = cbCategoryText.SelectedValue;
            else
                g.promptText = tbPromptText.Text;

            if ((tbPrintText.Text == String.Empty) && (cbCategoryText.SelectedIndex != 0))
                g.printText = cbCategoryText.SelectedValue;
            else
                g.printText = tbPrintText.Text;

            if (cbCategoryText.SelectedIndex != 0)
                g.categoryNameText = cbCategoryText.SelectedValue;

            if (cbInterfaceElement.SelectedIndex != 0)
                g.interfaceElement = cbInterfaceElement.SelectedValue;

            g.isPrimaryKey = chkPK.Checked;
            g.isRequiredBit = chkMandatory.Checked;
            g.toolTipText = tbTooltip.Text;
            g.maxCharacters = Convert.ToInt32(tbMaxCharacters.Text);
            g.defaultWidth = Convert.ToInt32(tbWidth.Text);
            g.helpText = tbHelpText.Text;
            g.regularExpression = tbRegularExpression.Text;
        }

        private void setValues()
        {
            g.id = id();
            g.Retrieve();

            lblTableName.Text = g.tableNameText;
            lblFieldName.Text = g.fieldNameText;
            chkPK.Checked = g.isPrimaryKey;
            chkMandatory.Checked = g.isRequiredBit;

            tbPromptText.Text = g.promptText;
            if (g.categoryNameText != String.Empty)
                cbCategoryText.SelectedValue = g.categoryNameText;

            tbPrintText.Text = g.printText;
            
            if (g.interfaceElement != String.Empty)
                cbInterfaceElement.SelectedValue = g.interfaceElement;

            tbTooltip.Text = g.toolTipText;
            tbWidth.Text = Convert.ToString(g.defaultWidth);
            tbMaxCharacters.Text = Convert.ToString(g.maxCharacters);
            tbHelpText.Text = g.helpText;
            tbRegularExpression.Text = g.regularExpression;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            getValues();
            g.Insert();
            Response.Redirect("~/ViewGUIFields.aspx");

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            g.id = id();
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