using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;
using System.Xml.XPath;
using System.Collections.Generic;


namespace sage
{
    /// <summary>
    /// Database Operations Class
    /// This module is developed as part of the SAGE Software System.
    /// 
    /// 
    /// Some very useful methods from SqlOps were added to this allowing to 
    /// INTERSECT and UNION Data Tables. These were from the DavidM Code blog
    /// 
    /// http://weblogs.sqlteam.com/davidm/ 
    /// 
    /// This common class is used for all database access within the program.
    /// 
    /// The construct used to hold parameters for passing to stored procedures is a dictionary
    /// as shown below.
    /// 
    ///             Dictionary<string, object> Parameters = new Dictionary<string, object>();
    ///             return Parameters;
    ///
    /// 
    /// Copyright 2010, Dr. Ron Eaglin, Ashar Ahmad
    /// </summary>
    public class dboperations
    {
        private string my_connectionstring;

        /// <summary>
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        #region "Non-Static Methods"

        // non-static methods use different annotation

        public string ConnectionString
        {
            get { return my_connectionstring; }
            set { my_connectionstring = value; }
        }

        public string myConnectionString()
        {
            if (ConnectionString == String.Empty)
                return ConfigurationManager.ConnectionStrings[dboperations.LocalConnectionString].ConnectionString;
            else
                return ConnectionString;
        }

        public SqlConnection getConnection()
        {
            SqlConnection connection =
                       new SqlConnection(myConnectionString());
            return connection;
        }


        #endregion


        #region "Static Methods"
        public static string LocalConnectionString = "ConnectionString";

        public static XmlDocument GetXmlDocument(string sp, Dictionary<string, object> Parameters)
        {
            XmlDocument document = new XmlDocument();
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command =
                               new SqlCommand(
                    sp, connection)
                    )
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (string Key in Parameters.Keys)
                    {
                        command.Parameters.AddWithValue(Key, Parameters[Key] == null ? DBNull.Value : Parameters[Key]);
                    }
                    connection.Open();
                    using (XmlReader reader =
                                command.ExecuteXmlReader())
                    {
                        if (reader.Read())
                            document.Load(
                          reader);
                    }
                    connection.Close();
                }
            }
            return document;
        }

        public static string MyConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[dboperations.LocalConnectionString].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection =
                       new SqlConnection(MyConnectionString());
            return connection;
        }

        public static SqlConnection GetConnection(string cString)
        {
            SqlConnection connection =
                       new SqlConnection(cString);
            return connection;
        }


        public static DataSet GetDataSet(string sp, Dictionary<string, object> Parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection =
                       GetConnection())
            {
                using (SqlCommand command =
                               new SqlCommand(
                    sp, connection)
                    )
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (string Key in Parameters.Keys)
                    {
                        command.Parameters.AddWithValue(Key, Parameters[Key] == null ? DBNull.Value : Parameters[Key]);
                    }
                    connection.Open();

                    SqlDataAdapter daAdapter = new SqlDataAdapter(command);
                    daAdapter.Fill(ds);
                }
            }
            return ds;
        }


        public static DataTable GetDataTable(string sp, Dictionary<string, object> Parameters)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet(sp, Parameters);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return new DataTable();

        }

        public static DataTable GetDataTable(string sp)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            DataSet ds = new DataSet();
            ds = GetDataSet(sp, Parameters);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return new DataTable();

        }


        public static void ExecuteProcedure(String sp, Dictionary<string, object> Parameters)
        {
            try
            {

                using (SqlConnection connection =
                           GetConnection())
                {
                    using (SqlCommand command =
                                   new SqlCommand(
                        sp, connection)
                        )
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (string Key in Parameters.Keys)
                        {
                            command.Parameters.AddWithValue(Key, Parameters[Key] == null ? DBNull.Value : Parameters[Key]);
                        }

                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #region "Executing SQL"
        public static int ExecuteSQLReturnInteger(String sqlString)
        {

            DataSet ds = dboperations.ExecuteSQL(sqlString);
            if (ds.Tables.Count == 0) return 0;
            if (ds.Tables[0].Rows.Count == 0) return 0;
            if (ds.Tables[0].Rows[0][0] is System.DBNull) return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        public static string ExecuteSQLReturnString(String sqlString, string cString)
        {

            DataSet ds = dboperations.ExecuteSQL(sqlString, cString);
            if (ds.Tables.Count == 0) return "";
            if (ds.Tables[0].Rows.Count == 0) return "";
            if (ds.Tables[0].Rows[0][0] is System.DBNull) return "";

            return Convert.ToString(ds.Tables[0].Rows[0][0]);
        }


        public static string ExecuteSQLReturnString(String sqlString)
        {
            return ExecuteSQLReturnString(sqlString, MyConnectionString());
        }

        public static DataSet ExecuteSQL(String sqlString, string cString)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = GetConnection(cString);

            SqlCommand command = new SqlCommand(sqlString, connection);

            command.CommandType = CommandType.Text;
            connection.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter(command);
            daAdapter.Fill(ds);
            connection.Close();
            return ds;
        }

        public static DataSet ExecuteSQL(String sqlString)
        {
            return ExecuteSQL(sqlString, MyConnectionString());
        }

        public static DataTable ExecuteSQLReturnDataTable(String sqlString)
        {
            return ExecuteSQLReturnDataTable(sqlString, MyConnectionString());
        }

        public static DataTable ExecuteSQLReturnDataTable(string sqlString, string cString)
        {
            DataSet ds = new DataSet();
            SqlConnection connection =
                       GetConnection(cString);

            SqlCommand command = new SqlCommand(sqlString, connection);

            command.CommandType = CommandType.Text;
            connection.Open();

            SqlDataAdapter daAdapter = new SqlDataAdapter(command);
            daAdapter.Fill(ds);
            connection.Close();

            if (ds.Tables.Count != 0)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        #endregion

        public static Dictionary<string, object> dictionary()
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return Parameters;
        }


        #region "Table Manipulations"

        public static DataTable Union(DataTable First, DataTable Second)
        {

            //Result table

            DataTable table = new DataTable("Union");

            //Build new columns

            DataColumn[] newcolumns = new DataColumn[First.Columns.Count];
            for (int i = 0; i < First.Columns.Count; i++)
            {
                newcolumns[i] = new DataColumn(First.Columns[i].ColumnName, First.Columns[i].DataType);
            }

            //add new columns to result table

            table.Columns.AddRange(newcolumns);
            table.BeginLoadData();

            //Load data from first table

            foreach (DataRow row in First.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }

            //Load data from second table

            foreach (DataRow row in Second.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }

            table.EndLoadData();
            return table;

        }

        public static DataTable Intersect(DataTable First, DataTable Second)
        {

            //Get reference to Columns in First

            DataColumn[] firstcolumns = new DataColumn[First.Columns.Count];
            for (int i = 0; i < firstcolumns.Length; i++)
            {
                firstcolumns[i] = First.Columns[i];
            }

            //Get reference to Columns in Second

            DataColumn[] secondcolumns = new DataColumn[Second.Columns.Count];

            for (int i = 0; i < secondcolumns.Length; i++)
            {
                secondcolumns[i] = Second.Columns[i];
            }

            DataTable table = new DataTable("Intersect");

            DataColumn[] newcolumns = new DataColumn[First.Columns.Count];
            for (int i = 0; i < First.Columns.Count; i++)
            {
                newcolumns[i] = new DataColumn(First.Columns[i].ColumnName, First.Columns[i].DataType);
            }

            //add new columns to result table

            table.Columns.AddRange(newcolumns);
            table.BeginLoadData();

            foreach (DataRow row in First.Rows)
            {
                bool isIn = false;
                foreach (DataRow r2 in Second.Rows)
                {
                    if (row[0].ToString() == r2[0].ToString()) isIn = true;
                }
                if (isIn)
                {
                    table.LoadDataRow(row.ItemArray, true);
                }
            }

            //JOIN ON all columns

            //DataTable table = Join(First, Second, firstcolumns, secondcolumns);
            table.TableName = "Intersect";

            return table;

        }

        private static bool RowEqual(object[] Values, object[] OtherValues)
        {

            if (Values == null)
                return false;
            for (int i = 0; i < Values.Length; i++)
            {

                if (!Values[i].Equals(OtherValues[i]))
                    return false;
            }
            return true;
        }





        public static DataTable Distinct(DataTable Table, DataColumn[] Columns)
        {

            //Empty table

            DataTable table = new DataTable("Distinct");

            //Sort variable

            string sort = string.Empty;
            //Add Columns & Build Sort expression

            for (int i = 0; i < Columns.Length; i++)
            {
                table.Columns.Add(Columns[i].ColumnName, Columns[i].DataType);
                sort += Columns[i].ColumnName + ",";
            }

            //Select all rows and sort

            DataRow[] sortedrows = Table.Select(string.Empty, sort.Substring(0, sort.Length - 1));

            object[] currentrow = null;
            object[] previousrow = null;
            table.BeginLoadData();

            foreach (DataRow row in sortedrows)
            {

                //Current row

                currentrow = new object[Columns.Length];

                for (int i = 0; i < Columns.Length; i++)
                {
                    currentrow[i] = row[Columns[i].ColumnName];
                }

                //Match Current row to previous row

                if (!RowEqual(previousrow, currentrow))

                    table.LoadDataRow(currentrow, true);

                //Previous row

                previousrow = new object[Columns.Length];

                for (int i = 0; i < Columns.Length; i++)
                {
                    previousrow[i] = row[Columns[i].ColumnName];
                }
            }

            table.EndLoadData();

            return table;



        }

        public static DataTable Distinct(DataTable Table, DataColumn Column)
        {

            return Distinct(Table, new DataColumn[] { Column });

        }

        public static DataTable Distinct(DataTable Table, string Column)
        {

            return Distinct(Table, Table.Columns[Column]);

        }

        public static DataTable Distinct(DataTable Table, params string[] Columns)
        {
            DataColumn[] columns = new DataColumn[Columns.Length];

            for (int i = 0; i < Columns.Length; i++)
            {
                columns[i] = Table.Columns[Columns[i]];
            }
            return Distinct(Table, columns);
        }

        public static DataTable Distinct(DataTable Table)
        {
            DataColumn[] columns = new DataColumn[Table.Columns.Count];

            for (int i = 0; i < Table.Columns.Count; i++)
            {
                columns[i] = Table.Columns[i];
            }

            return Distinct(Table, columns);
        }

        public static DataTable Join(DataTable First, DataTable Second, DataColumn[] FJC, DataColumn[] SJC)
        {

            //Create Empty Table

            DataTable table = new DataTable("Join");

            // Use a DataSet to leverage DataRelation

            using (DataSet ds = new DataSet())
            {

                //Add Copy of Tables

                ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });

                //Identify Joining Columns from First

                DataColumn[] parentcolumns = new DataColumn[FJC.Length];

                for (int i = 0; i < parentcolumns.Length; i++)
                {
                    parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
                }

                //Identify Joining Columns from Second

                DataColumn[] childcolumns = new DataColumn[SJC.Length];

                for (int i = 0; i < childcolumns.Length; i++)
                {
                    childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
                }

                //Create DataRelation

                DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);

                ds.Relations.Add(r);

                //Create Columns for JOIN table

                for (int i = 0; i < First.Columns.Count; i++)
                {
                    table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                }

                for (int i = 0; i < Second.Columns.Count; i++)
                {
                    //Beware Duplicates

                    if (!table.Columns.Contains(Second.Columns[i].ColumnName))
                        table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
                    else
                        table.Columns.Add(Second.Columns[i].ColumnName + "_Second", Second.Columns[i].DataType);
                }

                //Loop through First table

                table.BeginLoadData();

                foreach (DataRow firstrow in ds.Tables[0].Rows)
                {
                    //Get "joined" rows

                    DataRow[] childrows = firstrow.GetChildRows(r);
                    if (childrows != null && childrows.Length > 0)
                    {
                        object[] parentarray = firstrow.ItemArray;

                        foreach (DataRow secondrow in childrows)
                        {
                            object[] secondarray = secondrow.ItemArray;

                            object[] joinarray = new object[parentarray.Length + secondarray.Length];

                            Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);

                            Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);

                            table.LoadDataRow(joinarray, true);

                        }

                    }

                }

                table.EndLoadData();
            }

            return table;

        }

        public static DataTable Join(DataTable First, DataTable Second, DataColumn FJC, DataColumn SJC)
        {
            return Join(First, Second, new DataColumn[] { FJC }, new DataColumn[] { SJC });
        }

        public static DataTable Join(DataTable First, DataTable Second, string FJC, string SJC)
        {
            return Join(First, Second, new DataColumn[] { First.Columns[FJC] }, new DataColumn[] { First.Columns[SJC] });
        }

        #endregion

        #region "Extended Table View and Inserts"


        public static string generateInsert(string tableName)
        {
            string sql = "SELECT * FROM " + tableName;
            DataTable dt = ExecuteSQLReturnDataTable(sql);
            dt.TableName = tableName;
            return asInsert(dt);
        }

        public static string generateInsert(string tableName, string pkName, int pkValue)
        {
            string sql = "SELECT * FROM " + tableName + " WHERE " + pkName + " = " + Convert.ToString(pkValue);
            DataTable dt = ExecuteSQLReturnDataTable(sql);
            dt.TableName = tableName;
            if (dt.Rows.Count == 0)
                return String.Empty;
            else
                return asInsert(dt, pkName);
        }

        private static string asInsert(DataTable dt, string pkName)
        {
            // Returns all Columns as insert

            string s = String.Empty;
            string t = String.Empty;
            string u = String.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                s = "INSERT INTO " + dt.TableName + "<br/> (";
                s += generateColumnList(dt, dr, pkName);
                s += ")<br/>";
                s += "VALUES<br/> (";
                u = String.Empty;
                foreach (DataColumn dc in dt.Columns)
                {
                    string d = DataForColumn(dr, dc, pkName);
                    if (u == String.Empty)
                    {
                        if (d != String.Empty) u += d;
                    }
                    else
                    {
                        if (d != String.Empty) u += " , " + d;
                    }
                }
                s += u;
                s += ")<br/><br/>";
                t += s;
            }

            return t;
        }


        private static string asInsert(DataTable dt)
        {
            // Returns all Columns as insert

            string s = String.Empty;
            string t = "SET IDENTITY INSERT " + dt.TableName + " OFF <br/><br/>";
            string u = String.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                s = "INSERT INTO " + dt.TableName + "<br/> (";
                s += generateColumnList(dt, dr);
                s += ")<br/>";
                s += "VALUES<br/> (";
                u = String.Empty;
                foreach (DataColumn dc in dt.Columns)
                {
                    string d = DataForColumn(dr, dc);
                    if (u == String.Empty)
                    {
                        if (d != String.Empty) u += d;
                    }
                    else
                    {
                        if (d != String.Empty) u += " , " + d;
                    }
                }
                s += u;
                s += ")<br/><br/>";
                t += s;
            }
            t += "SET IDENTITY INSERT " + dt.TableName + " ON <br/><br/>";
            return t;
        }

        private static string DataForColumn(DataRow dr, DataColumn dc)
        {
            if (dr[dc] == null) return String.Empty;
            if (Convert.ToString(dr[dc]) == String.Empty) return String.Empty;

            switch (dc.DataType.Name)
            {
                case "String":
                    return "'" + Convert.ToString(dr[dc]) + "'";
                case "Boolean":
                    if (Convert.ToString(dr[dc]) == "False") return "0";
                    else return "1";
                default:
                    return Convert.ToString(dr[dc]);
            }
        }

        private static string DataForColumn(DataRow dr, DataColumn dc, string pkName)
        {
            // Generates the data - returns empty string if PK column

            if (dr[dc] == null) return String.Empty;
            if (Convert.ToString(dr[dc]) == String.Empty) return String.Empty;
            if (FieldForColumn(dr, dc).ToUpper() == pkName.ToUpper()) return String.Empty;

            switch (dc.DataType.Name)
            {
                case "String":
                    return "'" + Convert.ToString(dr[dc]) + "'";
                case "Boolean":
                    if (Convert.ToString(dr[dc]) == "False") return "0";
                    else return "1";
                default:
                    return Convert.ToString(dr[dc]);
            }
        }

        private static string FieldForColumn(DataRow dr, DataColumn dc)
        {
            if (dr[dc] == null) return String.Empty;
            if (Convert.ToString(dr[dc]) == String.Empty) return String.Empty;

            return dc.ColumnName;
        }


        private static string generateColumnList(DataTable dt, DataRow dr)
        {
            // Generates a column delimited list of all columns in a table that have values

            string s = String.Empty;
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                string f = FieldForColumn(dr, dc);
                if (s == String.Empty)
                {
                    if (f != String.Empty) s += f;
                }
                else
                {
                    if (f != String.Empty) s += " , " + f;
                }
            }
            return s;
        }

        private static string generateColumnList(DataTable dt, DataRow dr, string pkName)
        {

            // Used to generate a column list when we want to exclude the Primary Key from the list

            string s = String.Empty;
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                string f = FieldForColumn(dr, dc);
                if (f.ToUpper() != pkName.ToUpper())
                {
                    if (s == String.Empty)
                    {
                        if (f != String.Empty) s += f;
                    }
                    else
                    {
                        if (f != String.Empty) s += " , " + f;
                    }
                }
            }
            return s;
        }


        #endregion

        #endregion
    }
}
