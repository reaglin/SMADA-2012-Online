using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;

namespace sage
{
    public abstract class ObjectCommon
    {
        public bool FillFromDataSet(DataSet ds)
        {
            if (ds == null) return false;
            DataRow dr = default(DataRow);
            if (ds == null) return false;
            if (ds.Tables.Count == 0) return false;
            if (ds.Tables[0].Rows.Count == 0) return false;
            dr = ds.Tables[0].Rows[0];
            FillFromDataRow(dr);
            return true;
        }


        public int ConvertToInteger(Object v)
        {
            try
            {
                int i = Convert.ToInt32(v);
                return i;
            }
            catch
            {
                return 0;
            }

        }


        public string ConvertToString(Object v)
        {
            try
            {
                string s = Convert.ToString(v);
                return s;
            }
            catch
            {
                return String.Empty;
            }

        }

        public Boolean ConvertToBoolean(Object v)
        {
            try
            {
                Boolean b = Convert.ToBoolean(v);
                return b;
            }
            catch
            {
                return false;
            }

        }
        public DateTime ConvertToDateTime(Object v)
        {
            try
            {
                DateTime d = Convert.ToDateTime(v);
                return d;
            }
            catch
            {
                DateTime d = DateTime.Today;
                return d;
            }
        }

        public bool Validate()  { return true; }


        public abstract void FillFromDataRow(DataRow dr);

    }

    public class DBElem
    {
        #region Comments
        /*
         * Copyright 2012  Ron Eaglin
         * 
         * DBElem is a class that wrappers items that are saved and stored to the the database and used in the interface
         * This class is used when a domain object extends TableWrapper. Domain classes mirror the classes in the database
         * tables. 
         * 
         * The class extending TableWrapper will need to declare a property for each database element - these can be created using 
         * following stored procedure. When executing - send results to text.

       USE [DatabaseName]
       GO

       CREATE PROCEDURE [dbo].[usp_TableToDBElemDeclarations]

       @table_name SYSNAME

       AS

       SET NOCOUNT ON

       DECLARE @temp TABLE
       (
       sort INT,
       code TEXT
       )

       INSERT INTO @temp
       SELECT 1, '#region DBElem Declarations' + CHAR(13) + CHAR(10)
       INSERT INTO @temp
       SELECT 2, CHAR(9) + 'public DBElem  ' + COLUMN_NAME +
       ' = new DBElem("' + @table_name + '" , "' + COLUMN_NAME +
       '" , DBElem.'
       + CASE
        WHEN DATA_TYPE LIKE '%CHAR%' THEN 'typeString '
        WHEN DATA_TYPE LIKE '%INT%' THEN 'typeInt '
        WHEN DATA_TYPE LIKE '%DATETIME%' THEN 'typeDateString '
        WHEN DATA_TYPE LIKE '%TEXT%' THEN 'typeString '
        WHEN DATA_TYPE LIKE '%FLOAT%' THEN 'typeDouble '
       ELSE 'typeString '
       END + ');'  + CHAR(9)
       FROM INFORMATION_SCHEMA.COLUMNS
       WHERE TABLE_NAME = @table_name
       ORDER BY ORDINAL_POSITION

       INSERT INTO @temp
       SELECT 3, '#endregion' + CHAR(13) + CHAR(10)

       SELECT code FROM @temp
       ORDER BY sort

       GO

         * in addition to this stored procedure, a collection (dictionary of columns must be created to allow
         * the program to parse through the DBElem's. This code should go into the function
         * 
         * public Dictionary<string, DBElem> setupColumns()
         * 
         * 
       CREATE PROCEDURE [dbo].[usp_TableToDBElemColumns]

       @table_name SYSNAME

       AS

       SET NOCOUNT ON

       DECLARE @temp TABLE
       (
       sort INT,
       code TEXT
       )

       INSERT INTO @temp
       SELECT 1, CHAR(9) + 'Columns.Add( ' + COLUMN_NAME +
       '.FieldName, ' + COLUMN_NAME + ');' + CHAR(9)
       FROM INFORMATION_SCHEMA.COLUMNS
       WHERE TABLE_NAME = @table_name
       ORDER BY ORDINAL_POSITION

       SELECT code FROM @temp
       ORDER BY sort

       GO
         * 
         * 
                * */
#endregion

        #region Properties

        private string m_TableName = String.Empty;
        private string m_FieldName = String.Empty;
        private string m_Value = String.Empty;
        private string m_Type = String.Empty;
        private bool m_isModified;
        private string m_Prompt = String.Empty;
        private string m_Category = String.Empty;
        private int m_MaxLength = 0;

        public const string typeString = "string";
        public const string typeInt = "int";
        public const string typeFloat = "float";
        public const string typeDouble = "double";
        public const string typeBool = "bool";
        public const string typeDate = "date";
        public const string typeDateString = "datestring"; // Represents a date, stored in DB as string

        public string TableName
        {
            get { return m_TableName; }
            set { m_TableName = value; }
        }

        public string FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value; }
        }

        public string Value
        {
            get
            {
                switch (Type)
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
                                return Convert.ToString(x);
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
                                return Convert.ToString(x);
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
                m_isModified = true;
            }
        }

        public string Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public string Prompt
        {
            get { return m_Prompt; }
            set { m_Prompt = value; }
        }

        public string Category
        {
            get { return m_Category; }
            set { m_Category = value; }
        }

        public bool isModified
        {
            get { return m_isModified; }
            set { m_isModified = value; }
        }

        public int MaxLength
        {
            get { return m_MaxLength; }
            set { m_MaxLength = value; }
        }

        #endregion

        #region Constructors

        public DBElem(string table_name, string field_name, string field_type)
        {
            TableName = table_name;
            FieldName = field_name;
            Type = field_type;
        }

        #endregion

        #region Utilities

        public string asHTML()
        {
            string s = String.Empty;

            s += Prompt + " : ";
            s += Value + "< br/>< br/>";

            return s;
        }

        public string asHtmlTableCell()
        {
            string s = String.Empty;

            s +=  "<td>";
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
            if (Type == typeFloat) return true;
            if (Type == typeInt) return true;
            if (Type == typeDouble) return true;
            return false;
        }

        public bool isString()
        {
            if (Type == typeDateString) return true;
            if (Type == typeString) return true;
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

        public string SQLUpdateText()
        {
            if (!isModified) return String.Empty;
            if (Value == String.Empty) return String.Empty;

            switch (Type)
            {
                case typeString: return FieldName + " = '" + cleanString(Value) + "' ,";
                case typeDateString: return FieldName + " = '" + cleanString(Value) + "' ,";
                case typeInt: return FieldName + " = " + Value + ",";
                case typeBool:
                    if (Convert.ToBoolean(Value))
                        return FieldName + " = 1,";
                    else
                        return FieldName + " = 0,";

                default: return FieldName + " = " + Value + ","; ;
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

            if (MaxLength == 0) return t;
            if (t.Length <= MaxLength) return t;
            return t.Substring(0, MaxLength).TrimEnd(' ');
        }

        public string SQLValueText()
        {
            if (!isModified) return String.Empty;
            if (Value == String.Empty) return String.Empty;
            switch (Type)
            {
                case typeString: return "'" + cleanString(Value) + "',";
                case typeDateString: return "'" + cleanString(Value) + "',";
                case typeInt: return Value + ",";
                case typeBool:
                    if (Convert.ToBoolean(Value))
                        return "1,";
                    else
                        return "0,";


                default: return Value + ",";
            }

        }

        public string SQLFieldText()
        {
            if (!isModified) return String.Empty;
            if (Value == String.Empty) return String.Empty;

            else
                return FieldName + ",";
        }

        public void setValueFromDataRow(DataRow dr)
        {
            try
            {
                if (dr == null) return;
                if (dr[FieldName] == null) return;
                Value = Convert.ToString(dr[FieldName]);
            }
            catch
            {
                Value = "Error: " + FieldName;
            }
        }

#endregion

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            DBElem p = obj as DBElem;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Value == p.Value && TableName == p.TableName && FieldName == p.FieldName;
        }

        public override int GetHashCode()
        {
            return FieldName.Length ^ TableName.Length;
        }


        #region "Static Operators"

        public static bool operator ==(DBElem a, DBElem b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Value == b.Value && a.TableName == b.TableName && a.FieldName == b.FieldName;
        }

        public static bool operator !=(DBElem a, DBElem b)
        {
            return !(a == b);
        }

        public static double operator +(DBElem a, DBElem b)
        {
            if (a.isNumeric()&&b.isNumeric()) return a.asDouble() + b.asDouble();

            return 0;
        }

        public static double operator *(DBElem a, DBElem b)
        {
            if (a.isNumeric() && b.isNumeric()) return a.asDouble() * b.asDouble();

            return 0;
        }
        public static double operator -(DBElem a, DBElem b)
        {
            if (a.isNumeric() && b.isNumeric()) return a.asDouble() - b.asDouble();

            return 0;
        }
        public static double operator /(DBElem a, DBElem b)
        {
            if (a.isNumeric() && b.isNumeric()) return a.asDouble() / b.asDouble();

            return 0;
        }

        public static double operator +(DBElem a, int b)
        {
            if (a.isNumeric()) return a.asDouble() + b;

            return 0;
        }


        #endregion

    }
}