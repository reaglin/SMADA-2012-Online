using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sage;
using SMADA_2012.App_Code.SMADA;

namespace SMADA_2012.SMADAForms
{
    public partial class EditRainfallValues : System.Web.UI.Page
    {
        Label[] lblTime;
        TextBox[] tbDepth;

        public int RainfallID()
        {
            if (Session["RainfallID"] != null)
                return Convert.ToInt32(Session["RainfallID"]);
            else
                return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserLogin.isLoggedIn(Session)) Response.Redirect("~/Default.aspx");
            setupForm();
            if (!Page.IsPostBack)
            {
                if (RainfallID() == 0)
                {
                }
            }
        }

        protected void setupForm()
        {
            Rainfall r = new Rainfall(RainfallID());
            r.Select();
            int ns = r.NumberOfSteps.asInteger();

            lblTime = new Label[ns+1];
            tbDepth = new TextBox[ns+1];
            double total = 0;
            for (int i = 1; i <= ns; i++)
            {
                lblTime[i] = new Label();
                tbDepth[i] = new TextBox();
                lblTime[i].Width = 200; 
                tbDepth[i].Width = 200;

                // if time is not set need to do it
                if (i == 1) r.setTime(1, 0.0);
                if (i > 1) r.setTime(i, r.time(i - 1) + r.TimeStep.asDouble()); 


                lblTime[i].Text =  r.time(i).ToString("F");

                tbDepth[i].ID = "tb" + Convert.ToString(i);
                tbDepth[i].Text =  r.depth(i).ToString("F");
                total += r.depth(i);

                TableRow tr = new TableRow();
                table1.Rows.Add(tr);
                TableCell tc1 = new TableCell(); tc1.CssClass="DefaultCellL";
                TableCell tc2 = new TableCell(); tc1.CssClass="DefaultCellR";

                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);

                tc1.Controls.Add(lblTime[i]);
                tc2.Controls.Add(tbDepth[i]);
            }
            // from http://www.csharp-examples.net/string-format-double/
            lblDTotal.Text = String.Format("{0:0.000}", r.Total.asDouble());
            lblTotal.Text = String.Format("{0:0.000}", total);
            if (ns > 1) tbDepth[1].Focus();
        }

        protected void getValues()
        {


            Rainfall r = new Rainfall(RainfallID());
            int ns = r.NumberOfSteps.asInteger();

            double total = 0;
            int i = 1;
            foreach (TableRow tr in table1.Rows)
                foreach(TableCell tc in tr.Cells)
                    foreach(Control c in tc.Controls)
                    {
                    {
                    {
                        if (c.GetType() == typeof(TextBox))
                        {
                            string s = ((TextBox)c).Text;
                            Double d = 0.0;
                            try
                            {
                                d = Convert.ToDouble(s);
                            }
                            catch
                            {
                                d = 0.0;
                            }
                            r.setDepth(i, d);
                            total += d;
                            i++;
                        }
                    }
                    }
                    }
            // from  http://www.csharp-examples.net/string-format-double/
            lblDTotal.Text = String.Format("{0:0.00}", r.Total.asDouble());
            lblTotal.Text = String.Format("{0:0.00}", total);
            r.Update();
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            getValues();
            Response.Redirect("~/SMADAForms/SelectRainfall.aspx");   
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SMADAForms/SelectRainfall.aspx");
        }
    }
}