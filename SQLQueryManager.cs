using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;
namespace sage
{
    public class SQLQueryManager : TableWrapper
    {
        public DBElem SQLQueryManagerID = new DBElem("SQLQueryManager", "SQLQueryManagerID", DBElem.typeInt);
        public DBElem SQLQueryManagerName = new DBElem("SQLQueryManager", "SQLQueryManagerName", DBElem.typeString);
        public DBElem SQLQueryManagerDescription = new DBElem("SQLQueryManager", "SQLQueryManagerDescription", DBElem.typeString);
        public DBElem SQLQueryManagerSQLText = new DBElem("SQLQueryManager", "SQLQueryManagerSQLText", DBElem.typeString);

        public SQLQueryManager()
        {
            Initialize();
        }

        public SQLQueryManager(int pk)
        {
            Initialize();
            Select(pk);
        }

        private void Initialize()
        {
            TableName = "SQLQueryManager";
            PrimaryKey = "SQLQueryManagerID";
            setupColumns();
        }

        public Dictionary<string, DBElem> setupColumns()
        {
            Columns.Clear();
            Columns.Add(SQLQueryManagerID.FieldName, SQLQueryManagerID);
            Columns.Add(SQLQueryManagerName.FieldName, SQLQueryManagerName);
            Columns.Add(SQLQueryManagerDescription.FieldName, SQLQueryManagerDescription);
            Columns.Add(SQLQueryManagerSQLText.FieldName, SQLQueryManagerSQLText);
            return Columns;
        }

    }
}
