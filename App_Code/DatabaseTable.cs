using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace sage
{
    public class DatabaseTable
    {

        /* This is an abstract class, allows for constructing SQL Statements for inserting and updating data
        // automatically.
        // Class Dependencies - dboperations, DBElem
         * 
         * When using the class - properties for each of the database elements should be created (see DBElem documentation)
         * 
         * These functions should be implemented - initialize should be called in the object constructor
         * setupColumns - creates a Dictionary of the database fields (and DBElem) that can be iterated for 
         * inserting, selecting, updating the database.
         * 
        public void initialize()
        {
            TableName = "input table name";
            PrimaryKey = "input primary key of table";

            setupColumns();
        }
         * 
        public Dictionary<string, DBElem> setupColumns()
        {

            Columns.Clear();
            Columns.Add - see DBElem documentation for creating columns
        }
         * 
         * 
        */

        private string m_TableName;
        private string m_PrimaryKey;
        private string m_ImportKeyColumn;

        public string TableName { get { return m_TableName; } set { m_TableName = value; } }
        public string PrimaryKey { get { return m_PrimaryKey; } set { m_PrimaryKey = value; } }
        public string ImportKeyColumn { get { return m_ImportKeyColumn; } set { m_ImportKeyColumn = value; } }
        // These are a dictionary array of the fields used in update or insert

        public Dictionary<string, DatabaseField> Fields = new Dictionary<string, DatabaseField>();

        private string startUpdate()
        { return "UPDATE " + TableName + " SET "; }

        private string startInsert()
        { return "INSERT INTO " + TableName + " "; }

        private string valuesInsert()
        { return " VALUES( "; }


        private string trimLastComma(string t)
        {
            char[] c = { ',' };
            return t.TrimEnd(c);
        }

        public int lastIdentity()
        {
            try
            {
                if (PrimaryKey.Trim() != String.Empty)
                    return dboperations.ExecuteSQLReturnInteger("SELECT MAX(" + PrimaryKey + ") FROM " + TableName);
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        public void Add(DatabaseField d)
        {
            Fields.Add(d.fieldNameText, d);
        }

        public string getValue(string key)
        {
            try
            {
                return Fields[key].Value;
            }
            catch
            {
                return String.Empty;
            }
        }

        public void setValue(string key, string value)
        {
            if (key == String.Empty) return;
            if (value == String.Empty) return;

            try
            {
                Fields[key].Value = value;
            }
            catch
            {
            }
        }

        public DataRow selectValues(int pkID)
        {
            string sql = "SELECT * FROM " + TableName + " WHERE " + PrimaryKey + " = " + Convert.ToString(pkID);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            if (dt.Rows.Count != 0)
                return dt.Rows[0];
            else
                return null;
        }

        public virtual void Select(int pk)
        {
            DataRow dr = selectValues(pk);
            Fields[PrimaryKey].Value = Convert.ToString(pk);

            Select(dr);
        }

        public virtual int PrimaryKeyValue()
        {
            if (Fields[PrimaryKey].Value != null)
                return Fields[PrimaryKey].asInteger();
            else
                return 0;
        }

        public void setPrimaryKeyValue(int pk) { Fields[PrimaryKey].Value = Convert.ToString(pk); }

        public string SQLUpdate()
        {
            string t = startUpdate();

            string c = String.Empty;
            foreach (DatabaseField d in Fields.Values)
            {
                if (d.fieldNameText != PrimaryKey) c += d.SQLUpdateText();
            }
            if (c == String.Empty) return String.Empty;

            t += trimLastComma(c);
            t += " WHERE " + PrimaryKey + " = " + PrimaryKeyValue();
            return t;
        }

        private string SQLInsertFieldsFromDictionary()
        {
            string t = "(";

            string c = String.Empty;
            foreach (DatabaseField d in Fields.Values)
            {
                if (d.fieldNameText != PrimaryKey) c += d.SQLFieldText();
            }
            if (c == String.Empty) return String.Empty;
            t += trimLastComma(c);
            t += ")";
            return t;

        }

        private string SQLInsertValuesFromDictionary()
        {
            string t = "(";

            string c = String.Empty;
            foreach (DatabaseField d in Fields.Values)
            {
                if (d.fieldNameText != PrimaryKey) c += d.SQLValueText();
            }
            if (c == String.Empty) return String.Empty;
            t += trimLastComma(c);
            t += ")";
            return t;

        }


        public string SQLInsert()
        {
            string t = startInsert();
            string c1 = SQLInsertFieldsFromDictionary();
            if (c1 == String.Empty) return String.Empty;

            string c2 = SQLInsertValuesFromDictionary();
            if (c2 == String.Empty) return String.Empty;

            t += c1;
            t += " VALUES ";
            t += c2;

            return t;
        }

        public virtual int Insert()
        {
            string sql = SQLInsert();
            if (sql != String.Empty)
            {
                dboperations.ExecuteSQL(sql);
                return lastIdentity();
            }
            else
                return 0;
        }

        public bool hasValuesSet()
        {
            foreach (DatabaseField d in Fields.Values)
            {
                if (d.Value != String.Empty) return true;
            }
            return false;
        }
        public int Update()
        {
            // #Eaglin - Better check here is to see if record exists 

            if (PrimaryKeyValue() == 0)
            {
                int pk = Insert();
                setPrimaryKeyValue(pk);
                return pk;
            }

            string sql = SQLUpdate();
            if (sql != String.Empty)
                dboperations.ExecuteSQL(sql);

            return PrimaryKeyValue();
        }

        public void Select(DataRow dr)
        {
            foreach (DatabaseField d in Fields.Values)
            {
                if (d.fieldNameText != this.PrimaryKey)
                    d.setValueFromDataRow(dr);
            }
        }

        public void Select(DataRow dr, String pkField)
        {
            foreach (DatabaseField d in Fields.Values)
            {
                d.setValueFromDataRow(dr);
            }
        }

        public string Export()
        {
            return dboperations.generateInsert(TableName);
        }

        public DatabaseField UpdateFieldAt(string id)
        {
            return Fields[id];
        }


        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            DatabaseTable  p = obj as DatabaseTable;
            if ((System.Object)p == null)
            {
                return false;
            }

            foreach (DatabaseField d in Fields.Values)
            {
                if (d != p.UpdateFieldAt(d.fieldNameText)) return false;
            }
            return true;
        }

        public int Import()
        {
            string sql1 = "SELECT COUNT(*) FROM " + TableName + " WHERE ImportKey = '" + getValue(ImportKeyColumn) + "'";
            string sql2 = "SELECT " + PrimaryKey + " FROM  " + TableName + "  WHERE ImportKey = '" + getValue(ImportKeyColumn) + "'";

            int n = dboperations.ExecuteSQLReturnInteger(sql1);

            if (n == 0)
                return Insert();
            else
            {
                return dboperations.ExecuteSQLReturnInteger(sql2);
            }
        }


        public string asHTML()
        {

            string s = String.Empty;
            foreach (DatabaseField d in Fields.Values)
            {
                s += d.asHTML();
            }
            return s;
        }

        public string asHtmlTable()
        {
            return asHTML("table");
        }


        public string asHTML(string style)
        {
            switch (style)
            {
                case "table":
                    string s = "<table>";
                    foreach (DatabaseField d in Fields.Values)
                    {
                            s += d.asHTML("table");
                    }
                    s += "</table>";
                    return s;

                default:

                    return asHTML();
            }
        }
        public void SetNVarcharMaximums()
        {
            foreach (DatabaseField d in Fields.Values)
            {
                if (DatabaseViewer.ColumnType(TableName, d.fieldNameText) == "nvarchar")
                {
                    d.maxCharacters  = DatabaseViewer.ColumnSize(TableName, d.fieldNameText);
                }
            }
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(UpdateFieldAt(PrimaryKey));
        }

    }
    public class Html
    {
        public static string tr(string s)
        {
            return "<tr>" + s + "</tr>";
        }
        public static string td(string s)
        {
            return "<td>" + s + "</td>";
        }
        public static string td(double d, int n)
        {
            return "<td>" + Html.decimalPlaceNoRounding(d, n) + "</td>";
        }

        public static string decimalPlaceNoRounding(double d, int decimalPlaces = 2)
        {
            d = d * Math.Pow(10, decimalPlaces);
            d = Math.Truncate(d);
            d = d / Math.Pow(10, decimalPlaces);
            return string.Format("{0:N" + Math.Abs(decimalPlaces) + "}", d);
        }

    }

}
