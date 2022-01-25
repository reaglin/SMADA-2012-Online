using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012
{
    public partial class ViewCategories : System.Web.UI.Page
    {
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

            gvCategories.DataSource = Categories.getAllCategories();
            gvCategories.DataBind();

            if (CategoryID() != 0)
            {
                Categories c = new Categories();
                c.CategoryID = CategoryID();
                c.Retrieve();

                dgCodes.Visible = true;
                dgCodes.DataSource = c.GetCodes();
                dgCodes.DataBind();

                LabelCodes.Visible = true;
                LabelCodes.Text = "Codes for " + c.CategoryDescriptionText;

            }
        }

        protected void gvCategories_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Categories c = new Categories(id);
                c.Delete();

                Response.Redirect("~/ViewCategories.aspx");
            }

        }
        protected void gvCodes_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Codes c = new Codes(id);
                c.Delete();

                Response.Redirect("~/ViewCategories.aspx?CategoryID=" + Convert.ToString(CategoryID()));
            }

        }

    }
}
