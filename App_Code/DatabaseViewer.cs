using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using sage;

namespace sage
{
    public class DatabaseViewer
    {
        public DatabaseViewer()
        {
            //
            // Placeholder for Static functions under object
            //
        }

        public static DataTable StoredProcedures()
        {
            return DatabaseViewer.TableByType("Procedures");
        }

        public static DataTable Tables()
        {
            return DatabaseViewer.TableByType("Tables");
        }

        public static DataTable Tables(string cString)
        {
            return DatabaseViewer.TableByType("Tables", cString);
        }

        public static DataTable BaseTables()
        {
            string[] restrictions = new string[4];
            restrictions[3] = "BASE TABLE";
            return DatabaseViewer.TableByType("Tables", restrictions);
        }

        public static DataTable Restrictions()
        {
            return DatabaseViewer.TableByType("Restrictions");
        }

        public static DataTable ProcedureParameters()
        {
            return DatabaseViewer.TableByType("ProcedureParameters");
        }

        public static DataTable Columns(string TableName)
        {
            return ColumnsForTable(TableName);
        }

        public static DataTable Columns()
        {
            return DatabaseViewer.TableByType("Columns");
        }

        public static DataTable ColumnsForTable(string TableName)
        {
            string[] restrictions = new string[4];
            restrictions[2] = TableName;
            return DatabaseViewer.TableByType("Columns", restrictions);
        }

        public static DataTable Columns(string TableName, string cString)
        {
            string[] restrictions = new string[4];
            restrictions[2] = TableName;
            return DatabaseViewer.TableByType("Columns", restrictions, cString);
        }


        public static DataSet StoredProcedureCode(String ProcedureName)
        {
            String TempProcedureName = DatabaseViewer.RealProcedureName(ProcedureName);
            String sqlString = "Select * from information_schema.routines";
            sqlString += " where routine_name = '" + TempProcedureName + "'";

            return dboperations.ExecuteSQL(sqlString);

        }

        public static DataSet Constraints(string TableName)
        {
            String sqlString = "SELECT CONSTRAINT_TYPE, Constraints.CONSTRAINT_NAME, Constraints.TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION";
            sqlString += " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS Constraints";
            sqlString += " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS Keys";
            sqlString += " ON Constraints.CONSTRAINT_NAME = Keys.CONSTRAINT_NAME";
            sqlString += " WHERE Constraints.TABLE_NAME = '" + TableName + "'";

            return dboperations.ExecuteSQL(sqlString);
        }


        public static DataSet ForeignKeys(string TableName)
        {
            String sqlString = "SELECT Constraints.CONSTRAINT_NAME As ConstraintName, Parent.TABLE_NAME AS ParentTableName, Child.TABLE_NAME AS ChildTableName";
            sqlString += " FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE AS Parent";
            sqlString += " INNER JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS As Constraints";
            sqlString += " ON Constraints.UNIQUE_CONSTRAINT_CATALOG = Parent.CONSTRAINT_CATALOG AND";
            sqlString += " Constraints.UNIQUE_CONSTRAINT_SCHEMA = Parent.CONSTRAINT_SCHEMA AND";
            sqlString += " Constraints.UNIQUE_CONSTRAINT_NAME = Parent.CONSTRAINT_NAME";
            sqlString += " INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE AS Child";
            sqlString += " ON Constraints.CONSTRAINT_CATALOG = Child.CONSTRAINT_CATALOG AND";
            sqlString += " Constraints.CONSTRAINT_SCHEMA = Child.CONSTRAINT_SCHEMA AND";
            sqlString += " Constraints.CONSTRAINT_NAME = Child.CONSTRAINT_NAME";
            sqlString += " WHERE Parent.TABLE_NAME = '" + TableName + "'";
            sqlString += " OR Child.TABLE_NAME = '" + TableName + "'";

            return dboperations.ExecuteSQL(sqlString);
        }

        public static String StoredProcedureString(String ProcedureName)
        {
            return Convert.ToString(StoredProcedureCode(ProcedureName).Tables[0].Rows[0]["ROUTINE_DEFINITION"]);
        }


        private static string RealProcedureName(String ProcedureName)
        {
            String p2;
            char[] charsToTrim = { ';' };
            if (ProcedureName.IndexOf(";") > 0)
            {
                p2 = ProcedureName.TrimEnd(charsToTrim);
            }
            else
            {
                p2 = ProcedureName;
            }
            return p2;
        }

        private static DataTable TableByType(String s)
        {
            SqlConnection connection = dboperations.GetConnection();
            connection.Open();

            return connection.GetSchema(s);
        }

        private static DataTable TableByType(string strType, string[] rf)
        {
            //'Answers a The collection table based on the integer index
            //' strType - string of the type
            //' rf() string array of filters

            SqlConnection connection = dboperations.GetConnection();
            connection.Open();
            return connection.GetSchema(strType, rf);
        }

        private static DataTable TableByType(string s, string cString)
        {
            SqlConnection connection = dboperations.GetConnection(cString);
            connection.Open();

            return connection.GetSchema(s);
        }

        private static DataTable TableByType(string strType, string[] rf, string cString)
        {
            //'Answers a The collection table based on the integer index
            //' strType - string of the type
            //' rf() string array of filters

            SqlConnection connection = dboperations.GetConnection(cString);
            connection.Open();
            return connection.GetSchema(strType, rf);
        }

        public static DataTable CountByType(string TableName, string FieldName)
        {
            string sql = "DECLARE @Total FLOAT " + Environment.NewLine;

            sql += "SET @Total = (SELECT Count([" + FieldName + "]) FROM [" + TableName + "]" + Environment.NewLine;
            sql += "WHERE [" + FieldName + "] IS NOT NULL)" + Environment.NewLine;

            sql += "IF @Total <> 0" + Environment.NewLine;
            sql += "BEGIN" + Environment.NewLine;
            sql += "SELECT	[" + FieldName + "], " + Environment.NewLine;
            sql += "Count([" + FieldName + "]) AS 'Total', " + Environment.NewLine;
            sql += "ROUND(100*Count([" + FieldName + "])/@Total,2) As 'Percent'" + Environment.NewLine;
            sql += "FROM [" + TableName + "] " + Environment.NewLine;
            sql += "WHERE [" + FieldName + "] IS NOT NULL" + Environment.NewLine;
            sql += "GROUP BY [" + FieldName + "]" + Environment.NewLine;
            sql += "ORDER BY 'Total' DESC  " + Environment.NewLine;
            sql += "END" + Environment.NewLine;

            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static int ColumnSize(string TableName, string ColumnName)
        {
            DataTable dt = Columns(TableName);
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToString(dr["COLUMN_NAME"]) == ColumnName)
                {
                    int n = Convert.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"]);
                    return n;
                }
            }
            return 0;
        }

        public static string ColumnType(string TableName, string ColumnName)
        {
            DataTable dt = Columns(TableName);
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToString(dr["COLUMN_NAME"]) == ColumnName)
                {
                    string s = Convert.ToString(dr["DATA_TYPE"]);
                    return s;
                }
            }
            return String.Empty;
        }
    }
}
