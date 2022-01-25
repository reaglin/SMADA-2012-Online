using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkit;
using System.Web.UI.WebControls;
using System.Data;
using sage;

namespace sage
{
    public class GUIField : ObjectCommon
    {

        /*
         * Allows for automated generation of fields and field labels in the interface
         * Dependencies:    
         *      Tables: GUIFields, InterfaceMap
         *      Classes: dboperation 
         * 
         * 
    CREATE TABLE [dbo].[GUIFields](
	[GUIFieldID] [int] IDENTITY(1,1) NOT NULL,
	[TableNameText] [nvarchar](50) NULL,
	[FieldNameText] [nvarchar](200) NULL,
	[PromptText] [nvarchar](200) NULL,
	[InterfaceElementText] [nvarchar](50) NULL,
	[CategoryNameText] [nvarchar](50) NULL,
	[ToolTipText] [nvarchar](250) NULL,
	[Width] [nvarchar](4) NULL,
	[HelpText] [ntext] NULL,
 CONSTRAINT [PK_GUIFields] PRIMARY KEY CLUSTERED 
(
	[GUIFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
    CREATE TABLE [dbo].[InterfaceMap](
	[PageName] [nvarchar](100) NOT NULL,
	[TableName] [nvarchar](100) NOT NULL,
	[FieldName] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO
         *
         * 
         */

        #region "Properties"
        bool isModified;
        long myGUIFieldID;
        string myTableNameText = String.Empty;
        string myFieldNameText = String.Empty;
        string myPromptText = String.Empty;
        string myInterfaceElementText = String.Empty;
        string myTooltipText = String.Empty;
        string myWidth = String.Empty;
        string myHelpText = String.Empty;

        string myCategoryNameText;

        public long GUIFieldID
        {
            get { return myGUIFieldID; }
            set
            {
                myGUIFieldID = value;
                isModified = true;
            }
        }

        public string TableNameText
        {
            get { return myTableNameText; }
            set
            {
                myTableNameText = value;
                isModified = true;
            }
        }

        public string FieldNameText
        {
            get { return myFieldNameText; }
            set
            {
                myFieldNameText = value;
                isModified = true;
            }
        }

        public string PromptText
        {
            get
            {

                if (myPromptText == String.Empty) return TableNameText + " " + FieldNameText;
                else return myPromptText;
            }
            set
            {
                myPromptText = value;
                isModified = true;
            }
        }

        public string InterfaceElementText
        {
            get { return myInterfaceElementText; }
            set
            {
                myInterfaceElementText = value;
                isModified = true;
            }
        }

        public string CategoryNameText
        {
            get { return myCategoryNameText; }
            set
            {
                myCategoryNameText = value;
                isModified = true;
            }
        }

        public string TooltipText
        {
            get
            {
                if (myTooltipText == String.Empty) return PromptText;
                else return myTooltipText;
            }
            set
            {
                myTooltipText = value;
                isModified = true;
            }
        }

        public string Width
        {
            get { return myWidth; }
            set
            {
                myWidth = value;
                isModified = true;
            }
        }

        public string HelpText
        {
            get { return myHelpText; }
            set
            {
                myHelpText = value;
                isModified = true;
            }
        }

        #endregion

        #region Constructors

        public GUIField(string pTableNameText, string pFieldNameText)
        {
            TableNameText = pTableNameText;
            FieldNameText = pFieldNameText;

            RetrieveFromFieldName();
        }

        public GUIField(int id)
        {
            GUIFieldID = id;
            Retrieve();
        }


        public GUIField()
        {
        }

        public GUIField(DBElem d)
        {
            TableNameText = d.TableName;
            FieldNameText = d.FieldName;

            RetrieveFromFieldName();

            d.Prompt = PromptText;
            d.Category = CategoryNameText;
        }

        #endregion

        #region Database Access

        public bool Insert()
        {

            isModified = false;
            Dictionary<string, object> ht = new Dictionary<string, object>();

            ht.Add("@TableNameText", TableNameText);
            ht.Add("@FieldNameText", FieldNameText);
            ht.Add("@PromptText", PromptText);
            ht.Add("@InterfaceElementText", InterfaceElementText);
            ht.Add("@CategoryNameText", CategoryNameText);
            ht.Add("@TooltipText", TooltipText);
            ht.Add("@Width", Width);
            ht.Add("@HelpText", HelpText);

            dboperations.ExecuteProcedure("sp_InsertGUIFields", ht);
            return true;
        }

        public bool Retrieve()
        {
            if (GUIFieldID == 0) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@GUIFieldID", GUIFieldID);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_GetGUIFields", ht);

            return FillFromDataSet(ds);
        }

        public bool RetrieveFromFieldName()
        {
            // Allows us to build database as we add fields
            if (Count() == 0) Insert();

            // Does actual retrieval
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@TableNameText", TableNameText);
            ht.Add("@FieldNameText", FieldNameText);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("[sp_GetGUIFieldsFromField]", ht);

            return FillFromDataSet(ds);
        }

        public int Count()
        {
            string sql = "SELECT Count(*) FROM GUIFields WHERE TableNameText = '" + TableNameText + "' AND FieldNameText = '" + FieldNameText + "'";
            return dboperations.ExecuteSQLReturnInteger(sql);
        }

        public override void FillFromDataRow(DataRow dr)
        {

            // If data fields is null just moves to next field
            GUIFieldID = ConvertToInteger(dr["GUIFieldID"]);
            TableNameText = ConvertToString(dr["TableNameText"]);
            FieldNameText = ConvertToString(dr["FieldNameText"]);
            PromptText = ConvertToString(dr["PromptText"]);
            InterfaceElementText = ConvertToString(dr["InterfaceElementText"]);
            CategoryNameText = ConvertToString(dr["CategoryNameText"]);
            TooltipText = ConvertToString(dr["TooltipText"]);
            Width = ConvertToString(dr["Width"]);
            HelpText = ConvertToString(dr["HelpText"]);
        }

        public bool Update()
        {
            if (!isModified) return true;
            if (!Validate()) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@GUIFieldID", GUIFieldID);
            ht.Add("@TableNameText", TableNameText);
            ht.Add("@FieldNameText", FieldNameText);
            ht.Add("@PromptText", PromptText);
            ht.Add("@InterfaceElementText", InterfaceElementText);
            ht.Add("@CategoryNameText", CategoryNameText);
            ht.Add("@TooltipText", TooltipText);
            ht.Add("@Width", Width);
            ht.Add("@HelpText", HelpText);
            DataSet ds = new DataSet();
            dboperations.ExecuteProcedure("[sp_UpdateGUIFields]", ht);

            return true;
        }

        #endregion

        #region HTML Functions

        public string asHTML(DBElem d, string format)
        {
            string s = String.Empty;
            switch (format)
            {
                case "table":
                    s += "<tr><td>" + PromptText + "</td><td>";
                    s += d.Value + "</td></tr>";
                    return s;

                default:

                    s += "<u>" + PromptText + "</u> : ";
                    s += d.Value + "<br/>";
                    return s;
            }
        }

        public string fullHelpText()
        {
            string s = String.Empty;

            s += "<h1><center>" + PromptText + "</center></h1>";
            s += "<h2><center>" + InterfaceElementText  + "</center></h2><br/><br/>";
            s += HelpText + "<br/>";

            if (CategoryNameText != String.Empty)
            {
                Categories c = new Categories(CategoryNameText);
                s += c.fullHelpText();
            }
            return s;
        }

        #endregion

    }  // End Class GUIField


    public class GUIManager
    {

        public const string RBLTypeCodeUpDown = "UpDown";

        #region "Static Methods"

        public static DataTable GetAllGUIFields()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();

            return (DataTable)dboperations.GetDataTable("sp_GetAllGUIFields", ht);
        }

        public static int getID(System.Web.SessionState.HttpSessionState s, string var)
        {
            if (s[var] != null)
                return Convert.ToInt32(s[var]);
            else
                return 0;
        }

        public static int getID(HttpRequest r, string var)
        {
            if (r[var] != null)
                return Convert.ToInt32(r[var]);
            else
                return 0; 
        }

        public static string asHTML()
        {
            string s = "<table>";
            s += "<tr><th>Table</th><th>Field</th><th>Prompt</th><th>Category</th><th>Codes</th></tr>";
            DataTable dt = GetAllGUIFields();
            foreach (DataRow dr in dt.Rows)
            {
                s += "<tr>";
                s += "<td>" + Convert.ToString(dr["TableNameText"]) + "</td>";
                s += "<td>" + Convert.ToString(dr["FieldNameText"]) + "</td>";
                s += "<td>" + Convert.ToString(dr["PromptText"]) + "</td>";
                string catName = String.Empty;
                int catID = 0;
                if (dr["CategoryNameText"] == null)
                {
                    catName = String.Empty;
                }
                else
                {
                    catName = Convert.ToString(dr["CategoryNameText"]);
                    catID = Categories.GetCategoryID(catName);
                }

                s += "<td>" + catName + "</td>";
                s += "<td>" + Codes.asString(catID) + "</td>";

                s += "</tr>";
            }
            s += "</table>";
            return s;
        }
#endregion

        #region "setup"

        public static void generateInterfaceMap(DBElem d, System.Web.UI.Control o)
        {

            if (o.GetType().Name != "HtmlForm")
            {
                if (o.Parent == null) return;
                generateInterfaceMap(d, o.Parent);
            }
            else
            {
                if (o == null) return;
                GUIField g = new GUIField(d);

                string sql = "SELECT COUNT(*) FROM InterfaceMap WHERE ";
                sql += "PageName = '" + getPageName(o);
                sql += "' AND TableName = '" + g.TableNameText;
                sql += "' AND FieldName = '" + g.FieldNameText + "'";

                int i = dboperations.ExecuteSQLReturnInteger(sql);
                if (i == 0)
                {
                    sql = "INSERT INTO InterfaceMap VALUES(";
                    sql += "'" + getPageName(o) + "',";
                    sql += "'" + g.TableNameText + "',";
                    sql += "'" + g.FieldNameText + "')";

                    dboperations.ExecuteSQL(sql);
                }
            }
        }

        public static string getPageName(System.Web.UI.Control p)
        {
            return p.Page.ToString().Substring(4, p.Page.ToString().Substring(4).Length - 5);
        }

        public static string getHelp(string form_name)
        {
            string s = String.Empty;
            string sql = "SELECT * FROM InterfaceMap WHERE PageName = '" + form_name + "'";
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                string tn = Convert.ToString(dr["TableName"]);
                string fn = Convert.ToString(dr["FieldName"]);

                GUIField g = new GUIField(tn, fn);
                s += g.fullHelpText();
            }
            return s;
        }

        public static void FillComboBox(String Category, ComboBox cb)
        {
            // After the Data Source is set - this will finish up the combo box 
            // setting the display and value fields and propoerties

            cb.DataSource = Categories.getCodes(Category);

            cb.DataValueField = "CodeNameText";
            cb.DataTextField = "CodeDescriptionText";

            // Fill in Default text here

            cb.DataBind();

            cb.Items.Insert(0, "- " + Category + " -");

        }

        public static void FillComboBox(String Category, DropDownList cb)
        {
            // After the Data Source is set - this will finish up the combo box 
            // setting the display and value fields and propoerties

            cb.DataSource = Categories.getCodes(Category);

            cb.DataValueField = "CodeNameText";
            cb.DataTextField = "CodeDescriptionText";

            // Fill in Default text here

            cb.DataBind();

            cb.Items.Insert(0, "- " + Category + " -");
        }

        public static void FillComboBox(DBElem d, DropDownList cb)
        {
            GUIField g = new GUIField(d);

            cb.DataSource = Categories.getCodes(g.CategoryNameText);
            if (g.CategoryNameText != String.Empty)
            {
                cb.DataValueField = "CodeNameText";
                cb.DataTextField = "CodeDescriptionText";

                // Fill in Default text here

                cb.DataBind();
            }
            if (d.Prompt == String.Empty)
                cb.Items.Insert(0, d.TableName + ":" + d.FieldName);
            else
                cb.Items.Insert(0, "- " + d.Prompt + " -");

            cb.ToolTip = g.TooltipText;
            if (g.Width != String.Empty) cb.Width = Convert.ToInt32(g.Width);

        }

        public static void FillCheckBox(DBElem d, CheckBox chk)
        {
            GUIField g = new GUIField(d);
            chk.Text = g.PromptText;
            chk.ToolTip = g.TooltipText;

        }

        public static void FillComboBox(DBElem d, ComboBox cb)
        {
            // After the Data Source is set - this will finish up the combo box 
            // setting the display and value fields and propoerties

            GUIField g = new GUIField(d);

            cb.DataSource = Categories.getCodes(g.CategoryNameText);
            if (g.CategoryNameText != String.Empty)
            {
                cb.DataValueField = "CodeNameText";
                cb.DataTextField = "CodeDescriptionText";

                // Fill in Default text here

                cb.DataBind();
            }
            if (d.Prompt == String.Empty)
                cb.Items.Insert(0, d.TableName + ":" + d.FieldName);
            else
                cb.Items.Insert(0, "- " + d.Prompt + " -");

            cb.ToolTip = g.TooltipText;
            if (g.Width != String.Empty) cb.Width = Convert.ToInt32(g.Width);

        }

        public static void setup(DBElem d, TextBoxWatermarkExtender w)
        {
            generateInterfaceMap(d, w);
            SetWatermark(w, d);
        }
        public static void setup(DBElem d, RadioButtonList rbl)
        {
            generateInterfaceMap(d, rbl);
            FillRadioButtonList(d, rbl);
        }

        public static void setup(DBElem d, CheckBox chk)
        {
            generateInterfaceMap(d, chk);
            FillCheckBox(d, chk);
        }
        public static void setup(DBElem d, ComboBox cb)
        {
            generateInterfaceMap(d, cb);
            FillComboBox(d, cb);
        }

        public static void setup(DBElem d, Label lbl)
        {
            generateInterfaceMap(d, lbl);
            FillLabel(d, lbl);
        }

        public static void setup(DBElem d, Label lbl, TextBox tb)
        {
            generateInterfaceMap(d, tb);
            FillLabel(d, lbl);
            GUIField g = new GUIField(d);
            if (g.Width != String.Empty) tb.Width = Convert.ToInt32(g.Width);
            tb.ToolTip = g.TooltipText;
        }

        public static void setup(DBElem d, ListBox lb)
        {
            generateInterfaceMap(d, lb);
            GUIField g = new GUIField(d);
            lb.DataSource = Categories.getCodes(g.CategoryNameText);

            lb.DataValueField = "CodeNameText";
            lb.DataTextField = "CodeDescriptionText";
            lb.ToolTip = g.CategoryNameText + " - Hold Ctrl to select multiple";
            lb.DataBind();

            lb.ToolTip = g.TooltipText;
            if (g.Width != String.Empty) lb.Width = Convert.ToInt32(g.Width);
        }

        public static void setup(DBElem d, CheckBoxList lb)
        {
            generateInterfaceMap(d, lb);
            GUIField g = new GUIField(d);
            lb.DataSource = Categories.getCodes(g.CategoryNameText);

            lb.DataValueField = "CodeNameText";
            lb.DataTextField = "CodeDescriptionText";
            lb.ToolTip = g.CategoryNameText + " - Hold Ctrl to select multiple";
            lb.DataBind();

            lb.ToolTip = g.TooltipText;
            if (g.Width != String.Empty) lb.Width = Convert.ToInt32(g.Width);
        }


        public static void setup(DBElem d, ListBox lb, Label lbl)
        {
            generateInterfaceMap(d, lb);
            GUIField g = new GUIField(d);
            lb.DataSource = Categories.getCodes(g.CategoryNameText);

            lb.DataValueField = "CodeNameText";
            lb.DataTextField = "CodeDescriptionText";
            lbl.Text = g.CategoryNameText;
            lb.ToolTip = "Hold Ctrl to select multiple";
            lb.DataBind();

            lb.ToolTip = g.TooltipText;
        }

        public static void setup(DBElem d, RadioButtonList rbl, TextBoxWatermarkExtender tb, string RBLTypeCode)
        {
            GUIField g = new GUIField(d);

            if (RBLTypeCode == RBLTypeCodeUpDown)
            {
                rbl.Items.Add("Up");
                rbl.Items.Add("Down");
            }
            setup(d, tb);
        }



        public static void SetWatermark(TextBoxWatermarkExtender w, DBElem d)
        {

            GUIField g = new GUIField(d);

            if (g.PromptText == String.Empty)
            {
                w.WatermarkText = "Not Set";
                return;
            }

            if (g.PromptText == null)
            {
                w.WatermarkText = "Not Set";
                return;
            }

            w.WatermarkText = g.PromptText;

            try
            {
                string tbName = w.ID.Substring(0, w.ID.IndexOf('_'));
                TextBox tb = (TextBox)w.Parent.FindControl(tbName);
                if (g.TooltipText != String.Empty) tb.ToolTip = g.TooltipText;
                if (g.Width != String.Empty) tb.Width = Convert.ToInt32(g.Width);
            }
            catch
            {
            }
        }

        public static void FillRadioButtonList(String Category, RadioButtonList rbl)
        {
            rbl.DataSource = Categories.getCodes(Category);

            rbl.DataValueField = "CodeNameText";
            rbl.DataTextField = "CodeDescriptionText";

            // Fill in Default text here

            rbl.DataBind();

        }

        public static void FillLabel(DBElem d, Label lbl)
        {
            GUIField g = new GUIField(d);
            lbl.Text = g.PromptText;
            lbl.ToolTip = g.TooltipText;
        }


        public static void FillRadioButtonList(DBElem d, RadioButtonList rbl)
        {
            GUIField g = new GUIField(d);
            rbl.DataSource = Categories.getCodes(g.CategoryNameText);

            rbl.DataValueField = "CodeNameText";
            rbl.DataTextField = "CodeDescriptionText";

            // Fill in Default text here

            rbl.DataBind();
            rbl.ToolTip = g.TooltipText;
        }
        #endregion

        #region "setValue"

        public static void setValue(DBElem db, RadioButtonList rbl)
        {
            if (db.Value != String.Empty) rbl.SelectedValue = db.Value;
        }

        public static void setValue(DBElem db, ComboBox cb)
        {
            try { if (db.Value != String.Empty) cb.SelectedValue = db.Value; }
            catch { }
        }

        public static void setValue(DBElem db, Label lbl, ComboBox cb)
        {
            setLabel(db, lbl);
            setValue(db, cb);
        }

        public static void setValue(DBElem db, DropDownList cb)
        {
            try { if (db.Value != String.Empty) cb.SelectedValue = db.Value; }
            catch { }
        }

        public static void setValue(DBElem db, Label lbl, DropDownList cb)
        {
            setLabel(db, lbl);
            setValue(db, cb);
        }



        public static void setValue(DBElem db, CheckBox cb)
        {
            cb.Checked = false;
            if (db.Value.ToUpper() == "YES") cb.Checked = true;
            if (db.Value.ToUpper() == "TRUE") cb.Checked = true;
            if (db.Value == "1") cb.Checked = true;
        }

        public static void setValue(DBElem db, Label lbl, CheckBox cb)
        {
            setLabel(db, lbl);
            setValue(db, cb);
        }

        public static void setValue(DBElem db, TextBox tb)
        {
            GUIField g = new GUIField(db);
            if (g.Width != String.Empty) tb.Width = Convert.ToInt32(g.Width);

            if (db.Value != String.Empty) tb.Text = db.Value;
        }

        public static void setValue(DBElem db, Label lbl, TextBox tb)
        {
            // Label associated with text entry
            setLabel(db, lbl);
            setValue(db, tb);
        }

        public static void setValue(DBElem db, Label lbl)
        {
            if (db.Value != String.Empty) lbl.Text = db.Value;
        }

        public static void setValue(DBElem db, ListBox lb)
        {
            if (db.Value == String.Empty) return;
            string[] values = db.Value.Split(',');
            foreach (string v in values)
            {
                lb.Items.FindByValue(v).Selected = true;
            }
        }

        public static void setValue(DBElem db, Label lbl, ListBox lb)
        {
            // Sets label associated with ListBox
            setLabel(db, lbl);
            setValue(db, lb);
        }


        public static void setValue(DBElem db, CheckBoxList lb)
        {
            if (db.Value == String.Empty) return;
            string[] values = db.Value.Split(',');
            foreach (string v in values)
            {
                lb.Items.FindByValue(v).Selected = true;
            }
        }


        public static void setValue(DBElem d, RadioButtonList rbl, TextBox tb, string RBLTypeCode)
        {
            GUIField g = new GUIField(d);

            if (d.Value == String.Empty)
            {
                rbl.SelectedValue = "Up";
                return;
            }

            if (Convert.ToInt32(d.Value) < 0) rbl.SelectedValue = "Down";

            string abs = Convert.ToString(Math.Abs(Convert.ToInt32(d.Value)));
            tb.Text = abs;
        }

        public static void setLabel(DBElem db, Label lbl)
        {
            GUIField g = new GUIField(db);
            if (g.PromptText != String.Empty)
            {
                
                lbl.Text = g.PromptText + " (<a href='../Help.aspx?id=" + g.GUIFieldID.ToString() + "' cssclass='helplink' target='_new'>help</a>)";
                return;
            }

            if (db.Prompt != String.Empty) lbl.Text = db.Prompt;
           
        }

        #endregion

        #region "getValue"

        public static string getValue(RadioButtonList rbl)
        {
            if (rbl.SelectedItem == null) return String.Empty;
            return Convert.ToString(rbl.SelectedItem.Value);
        }

        public static void getValue(DBElem db, RadioButtonList rbl)
        {
            if (rbl.SelectedItem == null)
                db.Value = String.Empty;
            else
                db.Value = Convert.ToString(rbl.SelectedItem.Value);
        }

        public static void getValue(DBElem db, CheckBox cb)
        {
            db.Value = "False";
            if (cb.Checked) db.Value = "True";
        }

        public static void getValue(DBElem db, ComboBox cb)
        {
            if (cb.SelectedIndex != 0)
                db.Value = cb.SelectedValue;
        }

        public static void getValue(DBElem db, DropDownList cb)
        {
            if (cb.SelectedIndex != 0)
                db.Value = cb.SelectedValue;
        }

        public static void getValue(DBElem db, TextBox tb)
        {
            db.Value = tb.Text;
        }
        public static void getValue(DBElem db, Label lbl)
        {
            db.Value = lbl.Text;
        }

        public static void getValue(DBElem db, ListBox lb)
        {
            string selected = String.Empty;
            foreach (ListItem li in lb.Items)
            {
                if (li.Selected == true)
                {
                    if (selected == String.Empty)
                        selected = li.Value;
                    else
                        selected += "," + li.Value;
                }
            }
            db.Value = selected;
        }

        public static void getValue(DBElem db, CheckBoxList lb)
        {
            string selected = String.Empty;
            foreach (ListItem li in lb.Items)
            {
                if (li.Selected == true)
                {
                    if (selected == String.Empty)
                        selected = li.Value;
                    else
                        selected += "," + li.Value;
                }
            }
            db.Value = selected;
        }

        public static void getValue(DBElem d, RadioButtonList rbl, TextBox tb, string RBLTypeCode)
        {
            GUIField g = new GUIField(d);

            if (tb.Text == String.Empty) return;
            if (rbl.SelectedValue == "Up")
            {
                getValue(d, tb);
                return;
            }

            string abs = Convert.ToString(Math.Abs(Convert.ToInt32(tb.Text)));
            d.Value = "-" + abs;
        }

        #endregion

        #region "Miscellaneous Static Methods"

        public static string TableNameForCategory(string cNameText)
        {
            string sql = "SELECT TableNameText FROM GUIFields WHERE CategoryNameText = '" + cNameText + "'";
            return dboperations.ExecuteSQLReturnString(sql);
        }

        public static string ColumnNameForCategory(string cNameText)
        {
            string sql = "SELECT FieldNameText FROM GUIFields WHERE CategoryNameText = '" + cNameText + "'";
            return dboperations.ExecuteSQLReturnString(sql);
        }

        public static string GridViewAsString(GridView g)
        {
            string s = string.Empty;
            foreach (TableCell cell in g.HeaderRow.Cells)
            {
                s += cell.Text += "\t";
            }
            s.Remove(s.Length-1);
            s += "\n";

            foreach (GridViewRow r in g.Rows)
            {
                foreach ( TableCell cell in r.Cells)
                {
                    s += cell.Text += "\t";
                }
                s.Remove(s.Length-1);
                s += "\n";
            }
            s.Remove(s.Length-1);
            return s;
        }

        #endregion

    }
}
 