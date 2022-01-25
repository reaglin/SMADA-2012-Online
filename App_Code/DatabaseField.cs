using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AjaxControlToolkit;
using System.Web.UI.WebControls;

using sage;

namespace sage
{
    public class DatabaseField : ObjectCommon
    {
        /*
         * This is the wrapper class for all data elements that 
         * exist inside the database
         * * 
    CREATE TABLE [dbo].[DataField](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IsPrimaryKey] [bit] NULL,
	[TableNameText] [varchar](50) NULL,
	[FieldNameText] [varchar](200) NULL,
	[TypeText] [varchar] (50) NULL,
	[PromptText] [nvarchar](200) NULL,
	[PrintText] [nvarchar](200) NULL,
	[InterfaceElement] [varchar](50) NULL,
	[CategoryNameText] [nvarchar](50) NULL,
	[ToolTipText] [nvarchar](250) NULL,
	[DefaultWidth] [int] NULL,
	[MaxCharacters] [int] NULL,
	[HelpText] [nvarchar](MAX) NULL,
	[IsRequiredBit] [bit] NULL,
	[RegularExpression] [varchar(500)] NULL) 

         */

        #region "properties"

        public int id { get; set; }
        public bool isPrimaryKey { get; set; }
        public string tableNameText { get; set; }
        public string fieldNameText { get; set; }
        public string typeText { get; set; }
        public string promptText { get; set; }
        public string printText { get; set; }
        public string interfaceElement { get; set; } // default interface element for edit
        public string categoryNameText { get; set; }
        public string toolTipText { get; set; }
        public int defaultWidth { get; set; }
        public int maxCharacters { get; set; }
        public string helpText { get; set; }
        public bool isRequiredBit { get; set; }
        public string regularExpression { get; set; }
        private string m_Value = String.Empty;

        public const string typeString = "string";
        public const string typeInt = "int";
        public const string typeFloat = "float";
        public const string typeDouble = "double";
        public const string typeBool = "bool";
        public const string typeDate = "date";
        public const string typeDateString = "datestring"; // Represents a date, stored in DB as string
        public const string RBLTypeCodeUpDown = "UpDown";

        public string Value
        {
            get
            {
                switch (typeText)
                {
                    case typeInt:
                        {
                            if (m_Value == String.Empty) return String.Empty;
                            if (m_Value == null) return String.Empty;

                            try
                            {
                                int i = Convert.ToInt16(m_Value);
                                return Convert.ToString(i);
                            }
                            catch
                            {
                                return String.Empty;
                            }
                        }

                    case typeDateString:
                        {
                            if (m_Value == String.Empty) return String.Empty;
                            if (m_Value == null) return String.Empty;

                            try
                            {
                                DateTime dt = Convert.ToDateTime(m_Value);
                                return String.Format("{0:M/d/yyyy}", dt);
                            }
                            catch
                            { return String.Empty; }
                        }

                    case typeString:
                        {
                            return m_Value.Replace("''", "'");
                        }
                    case typeFloat:
                        {
                            try
                            {
                                double x = Convert.ToDouble(m_Value);
                                return FormattedDouble(x);
                            }
                            catch
                            {
                                return String.Empty;
                            }
                        }
                    case typeDouble:
                        {
                            try
                            {
                                double x = Convert.ToDouble(m_Value);
                                return FormattedDouble(x);
                            }
                            catch
                            {
                                return String.Empty;
                            }
                        }

                    default:
                        {
                            return m_Value;
                        }
                }
            }
            set
            {
                m_Value = value;
            }
        }

        public static string FormattedDouble(double v)
        {
            return String.Format(FormatString(v), v);
        }
        private static string FormatString(double v)
        {
            if (v > 1000) return "{0:F0}";
            if (v > 10) return "{0:F1}";
            if (v > .1) return "{0:F2}";
            return "{0:F3}";
        }
        #endregion

        #region Constructors

        public DatabaseField(string pTableName, string pFieldName, string pType)
        {
            tableNameText = pTableName;
            fieldNameText = pFieldName;
            typeText = pType;
            RetrieveFromFieldName();
        }


        public DatabaseField(string pTableNameText, string pFieldNameText)
        {
            tableNameText = pTableNameText;
            fieldNameText = pFieldNameText;
            typeText = typeString;
            RetrieveFromFieldName();
        }

        public DatabaseField(int pID)
        {
            id = pID;
            Retrieve();
        }


        public DatabaseField()
        {
        }

        #endregion

        #region Utilities

        public string asHTML()
        {
            string s = String.Empty;

            s += promptText + " : ";
            s += Value + "< br/>< br/>";

            return s;
        }

        public string asHTML(string format)
        {
            string s = String.Empty;

            if (Value == string.Empty) return string.Empty;

            if (format == "table")
            {
                s += "<tr><td>" + printText  + "</td><td>";
                s += Value + "</td></tr>";
                return s;
            }
            return asHTML();
        }

        public string asHtmlTableCell()
        {
            string s = String.Empty;
            s += "<td>";
            s += formattedValue() + "</td>";
            return s;
        }

        public string formattedValue()
        {
            // to allow automated formatting
            return Value;
        }
        public bool isNumeric()
        {
            if (typeText == typeFloat) return true;
            if (typeText == typeInt) return true;
            if (typeText == typeDouble) return true;
            return false;
        }

        public bool isString()
        {
            if (typeText == typeDateString) return true;
            if (typeText == typeString) return true;
            return false;
        }
        public int asInteger()
        {
            int i;
            try
            {
                i = Convert.ToInt32(Value);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public string toString()
        {
            return Convert.ToString(Value);
        }

        public double asDouble()
        {
            double x;
            try
            {
                x = Convert.ToDouble(Value);
                return x;
            }
            catch
            {
                return 0.0;
            }
        }

        public void setValue(double x)
        {
            try { Value = Convert.ToString(x); }
            catch { Value = "0.0"; }
        }

        public void setValue(int x)
        {
            try { Value = Convert.ToString(x); }
            catch { Value = "0"; }
        }

        public void setValue(float x)
        {
            try { Value = Convert.ToString(x); }
            catch { Value = "0.0"; }
        }

        #endregion

        #region SQL Operation

        public static DataTable getAll()
        {
            string sql = "SELECT * FROM DataField";
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public string SQLUpdateText()
        {
            if (Value == String.Empty) return String.Empty;

            switch (typeText)
            {
                case typeString: return fieldNameText + " = '" + cleanString(Value) + "' ,";
                case typeDateString: return fieldNameText + " = '" + cleanString(Value) + "' ,";
                case typeInt: return fieldNameText + " = " + Value + ",";
                case typeBool:
                    if (Convert.ToBoolean(Value))
                        return fieldNameText + " = 1,";
                    else
                        return fieldNameText + " = 0,";

                default: return fieldNameText + " = " + Value + ","; ;
            }
        }

        public string cleanString(string v)
        {
            string s = v;
            string t = String.Empty;
            //s = s.Replace(Convert.ToChar(34), new Char());
            //s = s.Replace(Convert.ToChar(37), new Char());
            //s = s.Replace(Convert.ToChar(39), new Char());
            //s = s.Replace(Convert.ToChar(42), new Char());
            if (s.Contains("'"))
                t = s.Replace("'", "''"); // Double single quotes are needed for SQL
            else
                t = s;

            if (maxCharacters == 0) return t;
            if (t.Length <= maxCharacters) return t;
            return t.Substring(0, maxCharacters).TrimEnd(' ');
        }

        public string SQLValueText()
        {
            if (Value == String.Empty) return String.Empty;
            switch (typeText)
            {
                case typeString: return "'" + cleanString(Value) + "',";
                case typeDateString: return "'" + cleanString(Value) + "',";
                case typeInt: return Value + ",";
                case typeBool:
                    try
                    {
                        if (Convert.ToBoolean(Value))
                            return "1,";
                        else
                            return "0,";
                    }
                    catch
                    {
                        return "0,";
                    }
                default: return Value + ",";
            }

        }

        public string SQLFieldText()
        {
            if (Value == String.Empty) return String.Empty;

            else
                return fieldNameText + ",";
        }

        public void setValueFromDataRow(DataRow dr)
        {
            try
            {
                if (dr == null) return;
                if (dr[fieldNameText] == null) return;
                Value = Convert.ToString(dr[fieldNameText]);
            }
            catch
            {
                Value = "Error: " + fieldNameText;
            }
        }

        #endregion

        #region Database Functions
        public bool isBlank(string s)
        {
            if (s == string.Empty) return true;
            if (s == null) return true;
            return false;
        }
        public override void FillFromDataRow(DataRow dr)
        {
            // If data fields is null just moves to next field
            id = ConvertToInteger(dr["id"]);
            isPrimaryKey = ConvertToBoolean(dr["IsPrimaryKey"]);
            if (isBlank(tableNameText)) tableNameText = ConvertToString(dr["TableNameText"]);
            if (isBlank(fieldNameText)) fieldNameText = ConvertToString(dr["FieldNameText"]);
            if (isBlank(typeText)) typeText = ConvertToString(dr["TypeText"]);
            promptText = ConvertToString(dr["PromptText"]);
            if (isBlank(promptText)) promptText = tableNameText + " "+ fieldNameText;

            printText = ConvertToString(dr["PrintText"]);
            if (isBlank(printText)) printText = promptText;

            interfaceElement = ConvertToString(dr["InterfaceElement"]);
            if (isBlank(interfaceElement)) interfaceElement = "TextBox";

            categoryNameText = ConvertToString(dr["CategoryNameText"]);
            toolTipText = ConvertToString(dr["TooltipText"]);
            defaultWidth = ConvertToInteger(dr["DefaultWidth"]);
            maxCharacters = ConvertToInteger(dr["MaxCharacters"]);
            helpText = ConvertToString(dr["HelpText"]);
            isRequiredBit = ConvertToBoolean(dr["IsRequiredBit"]);
            regularExpression = ConvertToString(dr["RegularExpression"]);
        }

        public void Update()
        {
            Dictionary<string, object> ht = asDictionary();
            dboperations.ExecuteProcedure("[sp_UpdateDataField]", ht);
        }

        public void Insert()
        {
            Dictionary<string, object> ht = asDictionary();
            ht.Remove("@id");
            dboperations.ExecuteProcedure("[sp_InsertDataField]", ht);
        }

        public int Count()
        {
            string sql = "SELECT Count(*) FROM DataField WHERE TableNameText = '" + tableNameText + "' AND FieldNameText = '" + fieldNameText + "'";
            return dboperations.ExecuteSQLReturnInteger(sql);
        }

        public void Retrieve()
        {
            if (id == 0) RetrieveFromFieldName();

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@id", id);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_GetDataField", ht);

            FillFromDataSet(ds);
        }

        public void RetrieveFromFieldName()
        {
            // Allows us to build database as we add fields
            if (Count() == 0) Insert();

            // Does actual retrieval
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@TableNameText", tableNameText);
            ht.Add("@FieldNameText", fieldNameText);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("[sp_GetDataFieldFromField]", ht);

            FillFromDataSet(ds);
        }

        public Dictionary<string, object> asDictionary()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@id", id);
            ht.Add("@IsPrimaryKey", isPrimaryKey);
            ht.Add("@TableNameText", tableNameText);
            ht.Add("@FieldNameText", fieldNameText);
            ht.Add("@PromptText", promptText);
            ht.Add("@PrintText", printText);
            ht.Add("@InterfaceElement", interfaceElement);
            ht.Add("@CategoryNameText", categoryNameText);
            ht.Add("@ToolTipText", toolTipText);
            ht.Add("@DefaultWidth", defaultWidth);
            ht.Add("@MaxCharacters", defaultWidth);
            ht.Add("@HelpText", helpText);
            ht.Add("@IsRequiredBit", isRequiredBit);
            ht.Add("@RegularExpression", regularExpression);
            return ht;
        }

        public void generateInterfaceMap(System.Web.UI.Control o)
        {
            // The Interface Map keeps track of where the 
            // values are stored
            if (o.GetType().Name != "HtmlForm")
            {
                if (o.Parent == null) return;
                generateInterfaceMap(o.Parent);
            }
            else
            {
                if (o == null) return;

                string sql = "SELECT COUNT(*) FROM InterfaceMap WHERE ";
                sql += "PageName = '" + getPageName(o);
                sql += "' AND TableName = '" + tableNameText;
                sql += "' AND FieldName = '" + fieldNameText + "'";

                int i = dboperations.ExecuteSQLReturnInteger(sql);
                if (i == 0)
                {
                    sql = "INSERT INTO InterfaceMap VALUES(";
                    sql += "'" + getPageName(o) + "',";
                    sql += "'" + tableNameText + "',";
                    sql += "'" + fieldNameText + "')";

                    dboperations.ExecuteSQL(sql);
                }
            }
        }

        public static string getPageName(System.Web.UI.Control p)
        {
            return p.Page.ToString().Substring(4, p.Page.ToString().Substring(4).Length - 5);
        }


        #endregion

        #region "Inerface Utilities - SetValue"

        public void setValue(Table t)
        {
            TableRow tr = new TableRow();
            setValue(tr);
        }

        public void AddTableRow(Table t)
        {
            TableRow tr = new TableRow();
            setValue(tr);
        }

        public void setValue(TableRow tr)
        {
            // This function will create a row with 2 TableCells - one cell contains a Label, the other a TextBox
            TableCell tcl = new TableCell();
            TableCell tcr = new TableCell();
            tcl.CssClass = "TableCellL";
            tcr.CssClass = "TableCellR";

            addLabelToTableCell(tcl);

            if (interfaceElement == "TextBox")
            {
                addTextBoxToTableCell(tcr);
                return;
            }

            addTextBoxToTableCell(tcr);
       }


        private void addLabelToTableCell(TableCell tc)
        {
            Label lbl = new Label();
            setLabel(lbl);
            tc.Controls.Add(lbl);
        }

        private void addTextBoxToTableCell(TableCell tc)
        {
            TextBox tb = new TextBox();
            tb.ID = fieldNameText;
            setValue(tb);
            tc.Controls.Add(tb);

            if (isRequiredBit)
            {
                RequiredFieldValidator rfv = new RequiredFieldValidator();
                rfv.ControlToValidate = fieldNameText;
                rfv.ErrorMessage = promptText + " Is Required";
                tc.Controls.Add(rfv);
            }
        }

        public void setLabel(Label lbl)
        {
            string link = " (<a href='../Help.aspx?id=" + id.ToString() + "' CssClass='helplink' target='_new'>help</a>)";
            if (promptText != String.Empty)
            {
                lbl.Text = promptText;
            }
            lbl.Text += link;
        }

        public void setValue(TextBox tb)
        {
            if (defaultWidth != 0) tb.Width = defaultWidth;
            tb.Text = toString();
        }

        public void  setValue( DropDownList ddl)
        {
            try { if (Value != String.Empty) ddl.SelectedValue = Value; }
            catch { }
        }

        public void setValue(ComboBox cb)
        {
            try { if (Value != String.Empty) cb.SelectedValue = Value; }
            catch { }
        }

        public void setValue(TextBoxWatermarkExtender w)
        {
            SetWatermark(w);
        }

        public void setValue(CheckBox cb)
        {
            cb.Checked = false;
            if (Value.ToUpper() == "YES") cb.Checked = true;
            if (Value.ToUpper() == "TRUE") cb.Checked = true;
            if (Value == "1") cb.Checked = true;
        }

        public void setValue(Label lbl, TextBox tb)
        {
            setLabel(lbl);
            setValue(tb);
        }

        public void setValue(Label lbl, DropDownList ddl)
        {
            setLabel(lbl);
            setValue(ddl);
        }

        public void setValue(Label lbl, CheckBox cb)
        {
            setLabel(lbl);
            setValue(cb);
        }
        public void SetWatermark(TextBoxWatermarkExtender w)
        {
            if (promptText == String.Empty)
            {
                w.WatermarkText = "Not Set";
                return;
            }

            if (promptText == null)
            {
                w.WatermarkText = "Not Set";
                return;
            }

            w.WatermarkText = promptText;

            try
            {
                string tbName = w.ID.Substring(0, w.ID.IndexOf('_'));
                TextBox tb = (TextBox)w.Parent.FindControl(tbName);
                if (toolTipText != String.Empty) tb.ToolTip = toolTipText;
                if (defaultWidth != 0) tb.Width = defaultWidth;
            }
            catch
            {
            }
        }

        #endregion

        #region "getValue"

        public void getValue( RadioButtonList rbl)
        {
            if (rbl.SelectedItem == null)
                Value = String.Empty;
            else
                Value = Convert.ToString(rbl.SelectedItem.Value);
        }

        public void getValue( CheckBox cb)
        {
            Value = "False";
            if (cb.Checked) Value = "True";
        }

        public void getValue(ComboBox cb)
        {
            if (cb.SelectedIndex != 0)
                Value = cb.SelectedValue;
        }

        public void getValue(DropDownList cb)
        {
            if (cb.SelectedIndex != 0)
                Value = cb.SelectedValue;
        }

        public void getValue(TextBox tb)
        {
            Value = tb.Text;
        }
        public void getValue(Label lbl)
        {
            Value = lbl.Text;
        }

        public void getValue(ListBox lb)
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
            Value = selected;
        }

        public void getValue(CheckBoxList lb)
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
            Value = selected;
        }

        public void getValue(RadioButtonList rbl, TextBox tb, string RBLTypeCode)
        {
            if (tb.Text == String.Empty) return;
            if (rbl.SelectedValue == "Up")
            {
                getValue(tb);
                return;
            }

            string abs = Convert.ToString(Math.Abs(Convert.ToInt32(tb.Text)));
            Value = "-" + abs;
        }

        #endregion


        #region "Interface Utiities - setup"


        public void setup(TextBoxWatermarkExtender w)
        {
            generateInterfaceMap( w);
            SetWatermark(w);
        }

        public void setup( RadioButtonList rbl)
        {
            generateInterfaceMap( rbl);
            FillCodes( rbl);
        }

        public void setup(CheckBox chk)
        {
            generateInterfaceMap(chk);
            chk.Text = promptText;
            chk.ToolTip = toolTipText;
        }
        public void setup( ComboBox cb)
        {
            generateInterfaceMap( cb);
            FillCodes(cb);
        }

        public void setup(DropDownList ddl)
        {
            generateInterfaceMap(ddl);
            FillCodes(ddl);
        }

        public void setup(Label lbl)
        {
            generateInterfaceMap(lbl);
            lbl.Text = promptText;
            lbl.ToolTip = toolTipText;
        }

        public void setWidth(TextBox tb)
        {
            try
            {
                if (defaultWidth != 0) tb.Width = defaultWidth;
                tb.ToolTip = toolTipText;
            }
            catch { }
        }

        public void setWidth(ListBox lb)
        {
            try
            {
                if (defaultWidth != 0) lb.Width = defaultWidth;
                lb.ToolTip = toolTipText;
            }
            catch { }
        }

        public void setWidth(CheckBoxList cbl)
        {
            try
            {
                if (defaultWidth != 0) cbl.Width = defaultWidth;
                cbl.ToolTip = toolTipText;
            }
            catch {}
        }

        public void setWidth(ComboBox cb)
        {
            try
            {
                if (defaultWidth != 0) cb.Width = defaultWidth;
                cb.ToolTip = toolTipText;
            }
            catch { }
        }

        public void setWidth(DropDownList cb)
        {
            try
            {
                if (defaultWidth != 0) cb.Width = defaultWidth;
                cb.ToolTip = toolTipText;
            }
            catch { }
        }

        public void setup(Label lbl, TextBox tb)
        {
            generateInterfaceMap(tb);
            lbl.Text = promptText;
            lbl.ToolTip = toolTipText;
            setWidth(tb);
        }

        public void setup(ListBox lb)
        {
            generateInterfaceMap(lb);
            lb.DataSource = Categories.getCodes(categoryNameText);

            lb.DataValueField = "CodeNameText";
            lb.DataTextField = "CodeDescriptionText";
            lb.ToolTip = categoryNameText + " - Hold Ctrl to select multiple";
            lb.DataBind();

            setWidth(lb);
        }

        public void setup(CheckBoxList lb)
        {
            generateInterfaceMap(lb);
            lb.DataSource = Categories.getCodes(categoryNameText);

            lb.DataValueField = "CodeNameText";
            lb.DataTextField = "CodeDescriptionText";
            lb.ToolTip = categoryNameText + " - Hold Ctrl to select multiple";
            lb.DataBind();

            setWidth(lb);
        }


        public void setup(ListBox lb, Label lbl)
        {
            generateInterfaceMap(lb);
            lb.DataSource = Categories.getCodes(categoryNameText);

            lb.DataValueField = "CodeNameText";
            lb.DataTextField = "CodeDescriptionText";
            lbl.Text = categoryNameText;
            lb.ToolTip = "Hold Ctrl to select multiple";
            lb.DataBind();

            lb.ToolTip = toolTipText;
        }

        public void setup(RadioButtonList rbl, TextBoxWatermarkExtender tb, string RBLTypeCode)
        {
            if (RBLTypeCode == RBLTypeCodeUpDown)
            {
                rbl.Items.Add("Up");
                rbl.Items.Add("Down");
            }
            setup( tb);
        }

        public  void FillCodes(RadioButtonList rbl)
        {
            rbl.DataSource = Categories.getCodes(categoryNameText);

            rbl.DataValueField = "CodeNameText";
            rbl.DataTextField = "CodeDescriptionText";

            // Fill in Default text here

            rbl.DataBind();
            rbl.ToolTip = toolTipText;
        }

        public void FillCodes(ComboBox cb)
        {
            // After the Data Source is set - this will finish up the combo box 
            // setting the display and value fields and propoerties

            cb.DataSource = Categories.getCodes(categoryNameText);
            if (categoryNameText != String.Empty)
            {
                cb.DataValueField = "CodeNameText";
                cb.DataTextField = "CodeDescriptionText";

                // Fill in Default text here

                cb.DataBind();
            }
            if (promptText == String.Empty)
                cb.Items.Insert(0, tableNameText + ":" + fieldNameText);
            else
                cb.Items.Insert(0, "- " + promptText + " -");

            setWidth(cb);
        }

        public void FillCodes(DropDownList cb)
        {
            // After the Data Source is set - this will finish up the combo box 
            // setting the display and value fields and propoerties

            cb.DataSource = Categories.getCodes(categoryNameText);
            if (categoryNameText != String.Empty)
            {
                cb.DataValueField = "CodeNameText";
                cb.DataTextField = "CodeDescriptionText";

                // Fill in Default text here

                cb.DataBind();
            }
            if (promptText == String.Empty)
                cb.Items.Insert(0, tableNameText + ":" + fieldNameText);
            else
                cb.Items.Insert(0, "- " + promptText + " -");

            setWidth(cb);
        }

        #endregion

        #region Reporting and Help

        public string fullHelpText()
        {
            string s = String.Empty;

            s += "<h1><center>" + promptText + "</center></h1><br/><br/>";
            s += helpText + "<br/>";

            if (categoryNameText != String.Empty)
            {
                Categories c = new Categories(categoryNameText);
                s += c.fullHelpText();
            }
            return s;
        }


        #endregion
    }
}