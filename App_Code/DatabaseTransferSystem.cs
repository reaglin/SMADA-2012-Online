using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;

namespace sage
{
    public class FieldMapping : TableWrapper
    {

        public DBElem FieldMappingID = new DBElem("FieldMapping", "FieldMappingID", DBElem.typeInt); // int
        public DBElem SourceIDName = new DBElem("FieldMapping", "SourceIDName", DBElem.typeString);
        public DBElem SourceTableName = new DBElem("FieldMapping", "SourceTableName", DBElem.typeString); // nvarchar
        public DBElem SourceFieldName = new DBElem("FieldMapping", "SourceFieldName", DBElem.typeString); // nvarchar
        public DBElem SourceValue = new DBElem("FieldMapping", "SourceValue", DBElem.typeString); // nvarchar
        public DBElem DestTableName = new DBElem("FieldMapping", "DestTableName", DBElem.typeString); // nvarchar
        public DBElem DestFieldName = new DBElem("FieldMapping", "DestFieldName", DBElem.typeString); // nvarchar
        public DBElem DestValue = new DBElem("FieldMapping", "DestValue", DBElem.typeString); // nvarchar
        public DBElem DestCategory = new DBElem("FieldMapping", "DestCategory", DBElem.typeString); // nvarchar
        public DBElem KeyFieldsBit = new DBElem("FieldMapping", "KeyFieldsBit", DBElem.typeBool);

        public FieldMapping()
        {
            TableName = "FieldMapping";
            PrimaryKey = "FieldMappingID";
            setupColumns();
        }

        public FieldMapping(int pk)
        {
            TableName = "FieldMapping";
            PrimaryKey = "FieldMappingID";
            setupColumns();
            Select(pk);
        }

        public Dictionary<string, DBElem> setupColumns()
        {
            Columns.Clear();
            Columns.Add(FieldMappingID.FieldName, FieldMappingID);
            Columns.Add(SourceTableName.FieldName, SourceTableName);
            Columns.Add(SourceIDName.FieldName, SourceIDName);
            Columns.Add(SourceFieldName.FieldName, SourceFieldName);
            Columns.Add(SourceValue.FieldName, SourceValue);
            Columns.Add(DestTableName.FieldName, DestTableName);
            Columns.Add(DestFieldName.FieldName, DestFieldName);
            Columns.Add(DestValue.FieldName, DestValue);
            Columns.Add(DestCategory.FieldName, DestCategory);
            Columns.Add(KeyFieldsBit.FieldName, KeyFieldsBit);

            return Columns;
        }


        public override int PrimaryKeyValue()
        { return FieldMappingID.asInteger(); }


        public DataTable AllSourceValues(string connectionString)
        {
            // This reads the Values From the Source Database

            string sql = "SELECT [" + SourceFieldName.Value + "] FROM [" + SourceTableName.Value + "]";
            return dboperations.ExecuteSQLReturnDataTable(sql, connectionString);
        }
    }
}
namespace sage
{
    public class DatabaseTransferSystem : TableWrapper
    {
        // Here is the logic to use the Field Mappings to transfer data from one database table 
        // to another. This uses the class FieldMapping to handle the transfer. 

        // The data is transferred by a class that inherits from this class

        // Data Transfer has 3 parts - 
        // 1. Establish the root table and insert all data to the root,
        // 2. Insert all data into tables that are FK from the root
        // 3. Insert all data that has FK to the root.

        public DBElem DatabaseTransferID = new DBElem("DatabaseTransfer", "DatabaseTransferID", DBElem.typeInt); // int
        public DBElem SourceIDName = new DBElem("DatabaseTransfer", "SourceIDName", DBElem.typeString);
        public DBElem SourceConnectionString = new DBElem("DatabaseTransfer", "SourceConnectionString", DBElem.typeString);
        public DBElem DestinationConnectionString = new DBElem("DatabaseTransfer", "DestinationConnectionString", DBElem.typeString); // nvarchar
        public DBElem RootTableName = new DBElem("DatabaseTransfer", "RootTableName", DBElem.typeString); // nvarchar


        public DatabaseTransferSystem()
        {
            TableName = "DatabaseTransfer";
            PrimaryKey = "DatabaseTransferID";
            setupColumns();
        }

        public DatabaseTransferSystem(int pk)
        {
            TableName = "DatabaseTransfer";
            PrimaryKey = "DatabaseTransferID";
            setupColumns();
            Select(pk);
        }

        public Dictionary<string, DBElem> setupColumns()
        {
            Columns.Clear();
            Columns.Add(DatabaseTransferID.FieldName, DatabaseTransferID);
            Columns.Add(SourceIDName.FieldName, SourceIDName);
            Columns.Add(SourceConnectionString.FieldName, SourceConnectionString);
            Columns.Add(DestinationConnectionString.FieldName, DestinationConnectionString);
            Columns.Add(RootTableName.FieldName, RootTableName);

            return Columns;
        }


        public override int PrimaryKeyValue()
        { return DatabaseTransferID.asInteger(); }



        public static string getSourceConnectionString(int pkID)
        {
            DatabaseTransferSystem dts = new DatabaseTransferSystem(pkID);
            return dts.SourceConnectionString.Value;
        }

        public static string getDestinationConnectionString(int pkID)
        {
            DatabaseTransferSystem dts = new DatabaseTransferSystem(pkID);
            return dts.DestinationConnectionString.Value;
        }

        public static string getSourceIDName(int pkID)
        {
            DatabaseTransferSystem dts = new DatabaseTransferSystem(pkID);
            return dts.SourceIDName.Value;
        }


        public int PrimaryKeyFieldMappingID(string DestinationTableName)
        {
            // This Answers the FieldMappingID for the field that maps as the primary key

            string sql = "SELECT FieldMappingID FROM FieldMapping WHERE SourceIDName = '" + SourceIDName.Value + "'";
            sql += " AND KeyFieldsBit = 1 ";
            sql += " AND DestTableName = '" + DestinationTableName + "'";

            return dboperations.ExecuteSQLReturnInteger(sql);
        }

        public DataTable AllSourceImportFields(string sourceTableName)
        {
            // Returns a Datatable of all the Import Fields that are 
            // mapped as import fields

            string sql = "SELECT DISTINCT(SourceFieldName) FROM FieldMapping";
            sql += " WHERE SourceIDName = '" + SourceIDName.Value + "'";
            sql += " AND SourceTableName = '" + sourceTableName + "'";
            return dboperations.ExecuteSQLReturnDataTable(sql, SourceConnectionString.Value);
        }

        public string SelectSourceValue(string TableName, string FieldName, string KeyName, string KeyValue)
        {
            string sql = "SELECT [" + FieldName + "] FROM [" + TableName + "] WHERE [" + KeyName + "] = '" + KeyValue + "'";
            return dboperations.ExecuteSQLReturnString(sql, SourceConnectionString.Value);
        }

        public string SelectDestinationField(string sIDName, string sTableName, string sFieldName)
        {

            string sql = "SELECT TOP 1 DestFieldName FROM FieldMapping ";
            sql += " WHERE SourceIDName = '" + sIDName + "'";
            sql += " AND SourceTableName = '" + sTableName + "'";
            sql += " AND SourceFieldName = '" + sFieldName + "'";

            string result = dboperations.ExecuteSQLReturnString(sql);
            return result;
        }

        public string SelectDestinationValue(string sIDName, string sTableName, string sFieldName, string sValue)
        {
            // Gets the value for the destination based on source only do this if 
            // this is a Coded field

            string sql1 = "SELECT DestCategory FROM FieldMapping ";
            sql1 += " WHERE SourceIDName = '" + sIDName + "'";
            sql1 += " AND SourceTableName = '" + sTableName + "'";
            sql1 += " AND SourceFieldName = '" + sFieldName + "'";

            string category = dboperations.ExecuteSQLReturnString(sql1);
            if ((category == null) || (category == String.Empty))
            {
                return sValue;
            }

            string sql = "SELECT DestValue FROM FieldMapping ";
            sql += " WHERE SourceIDName = '" + sIDName + "'";
            sql += " AND SourceTableName = '" + sTableName + "'";
            sql += " AND SourceFieldName = '" + sFieldName + "'";
            sql += " AND SourceValue = '" + sValue + "'";

            string result = dboperations.ExecuteSQLReturnString(sql);
            return result;
        }

        public string transferAsHTML()
        {
            string s = String.Empty;
            string sql = "SELECT DISTINCT(SourceTableName) FROM FieldMapping WHERE SourceIDName = '" + SourceIDName.Value + "'";
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            s += "<h1>Data Import Mapping For " + SourceIDName.Value + "</h1><br/>";
            s += "<ul>";
            foreach (DataRow dr in dt.Rows)
            {
                s += "<li>";

                s += transferAsHTML(Convert.ToString(dr["SourceTableName"]));
                s += "</li>";
            }
            s += "</ul>";

            return s;
        }

        public string transferAsHTML(string table_name)
        {

            string s = String.Empty;
            string sql = "SELECT Distinct(SourceFieldName) FROM FieldMapping WHERE SourceIDName = '" + SourceIDName.Value + "'";
            sql += " AND SourceTableName = '" + table_name + "'";
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);
            s += "<h2> Import from Source Table: " + table_name + "</h2>";
            s += "<ul>";
            foreach (DataRow dr in dt.Rows)
            {
                s += "<li>";
                s += transferAsHTML(table_name, Convert.ToString(dr["SourceFieldName"]));
                s += "</li>";
            }
            s += "</ul>";
            return s;
        }

        public string transferAsHTML(string table_name, string field_name)
        {

            string s = String.Empty;
            string sql = "SELECT * FROM FieldMapping WHERE SourceIDName = '" + SourceIDName.Value + "'";
            sql += " AND SourceTableName = '" + table_name + "'";
            sql += " AND SourceFieldName = '" + field_name + "'";
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            s += "<h3> Field: " + field_name + "</h3>";

            if (dt.Rows.Count == 0) return s;
            if (dt.Rows.Count > 1)
            {

                s += "<ul>";
                foreach (DataRow dr in dt.Rows)
                {
                    s += "<li><b>";
                    s += Convert.ToString(dr["SourceValue"]) + "</b> : Conversion to <b>";
                    s += Convert.ToString(dr["DestTableName"]) + ".";
                    s += Convert.ToString(dr["DestFieldName"]) + "</b> Code: <b>";
                    s += Convert.ToString(dr["DestValue"]);
                    s += "</b></li>";
                }
                s += "</ul>";
            }
            else
            {
                s += " Direct Conversion to <b>";
                s += Convert.ToString(dt.Rows[0]["DestTableName"]) + ".";
                s += Convert.ToString(dt.Rows[0]["DestFieldName"]) + " ";
                s += "</b>";
            }

            return s;
        }

    }
}
