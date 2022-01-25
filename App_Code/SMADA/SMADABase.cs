using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Linq;
using sage;

namespace SMADA_2012.App_Code.SMADA
{
    public class SMADABase
    {
        public const char ColumnDelimiter = '\t';
        public const char RowDelimiter = '\n';

        private string myTable;
        public string Table
        {
            get { return myTable; }
            set { myTable = value; }
        }

        //private string myDataType;
        //public string DataType
        //{
        //    get { return myDataType; }
        //    set { myDataType = value; }
        //}

        private int myID;
        public int ID
        {
            get { return myID; }
            set { myID = value; }
        }

        private int myUserID;
        public int UserID
        {
            get { return myUserID; }
            set { myUserID = value; }
        }

        private string myDescription;
        public string DescriptionText
        {
            get { return myDescription; }
            set { myDescription = value; }
        }

        private string myData;
        public string DataText
        {
            get { return myData; }
            set { myData = value; }
        }

        private string myDataTypeText;

        public string DataTypeText
        {
            get { return myDataTypeText; }
            set { myDataTypeText = value; }
        }
        

        public SMADABase(string dataType)
        {
            Table = "DataContainer"; // All Data Stored in DataContainer
            DataTypeText = dataType; // Type is defined when creating object
        }

        public SMADABase()
        {
        }

        #region Database Routines
        public int Insert(int UserID)
        {
            ID = Insert(DescriptionText, DataText, UserID);
            return ID;
        }
        
        public int Insert(string Description, string Data, int UserID)
        {
            string description = cleanString(Description);
            string data = cleanString(Data);
            
            string sql = "INSERT INTO " + Table; 
                   sql +=" (DescriptionText, DataTypeText, DataText, UserID, CreatedDate)";
                   sql += " VALUES";
                   sql += " ('" + description + "', '" + DataTypeText + "', '" + data + "', " + Convert.ToString(UserID) + ", GETDATE())";

                   dboperations.ExecuteSQL(sql);
                   return dboperations.ExecuteSQLReturnInteger("SELECT MAX(id) FROM " + Table + " WHERE DataTypeText = '" + DataTypeText + "'"); 
        }

        public void Update(int UserID)
        {
            Update(DescriptionText, DataText, UserID);
        }

        public void Update(string Description, string Data, int UserID)
        {
            string description = cleanString(Description);
            string data = cleanString(Data);
            string sID = Convert.ToString(UserID);

            string sql = "UPDATE " + Table;	
            sql += " SET DescriptionText = '" + description + "', ";
		    sql += "DataText = '" + data +"'";
            sql += " WHERE id = " + Convert.ToString(ID);
            sql += " AND UserID = " + Convert.ToString(UserID);

            dboperations.ExecuteSQL(sql);
        }

        public DataTable Retrieve()
        {
            string sql = "SELECT * FROM " + Table + " WHERE id = " + Convert.ToString(ID);
            sql += " AND DataTypeText = '" + DataTypeText + "'";
            return Retrieve(ID);
        }

        public DataTable Retrieve(int id)
        {
            string sql = "SELECT * FROM " + Table + " WHERE id = " + Convert.ToString(id);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            ID = id;
            DataText = Convert.ToString(dt.Rows[0]["DataText"]);
            DescriptionText = Convert.ToString(dt.Rows[0]["DescriptionText"]);
            UserID = Convert.ToInt32(dt.Rows[0]["UserId"]);

            return dt;
        }

        public DataTable RetrieveAll(int UserID)
        {
            string sql = "SELECT * FROM " + Table + " WHERE UserID IN (" + Convert.ToString(UserID) + ", 0)";
            sql += " AND DataTypeText = '" + DataTypeText + "'";
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public string RetrieveData(int id)
        {
            string sql = "SELECT DataText FROM " + Table + " WHERE id = " + Convert.ToString(id);
            return dboperations.ExecuteSQLReturnString(sql);
        }
        public string RetrieveDescription(int id)
        {
            string sql = "SELECT DescriptionText FROM " + Table + " WHERE id = " + Convert.ToString(id);
            return dboperations.ExecuteSQLReturnString(sql);
        }

        public void Delete(int id, int uID)
        {
            // Only Delete if UserID is owner
            if (uID == 0) return;
            string sql = "DELETE FROM " + Table + " WHERE id = " + Convert.ToString(id) + " AND UserID = " + Convert.ToString(uID);
            dboperations.ExecuteSQL(sql);
        }

        public string cleanString(string v)
        {
            string t = v;
            t = t.Replace("'", ""); 
            t = t.Replace("--", "");
            return t;
        }

        public bool isValid(string s)
        {
            if (s == null) return false;
            if (s == String.Empty) return false;
            return true;
        }
        #endregion
        #region Static Methods

        public static DataTable RetrieveForUser(int UserID, string dataType)
        {
            string sql = "SELECT * FROM DataContainer WHERE UserID IN (" + Convert.ToString(UserID) + ", 0)";
            sql += " AND DataTypeText = '" + dataType + "'";
          
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static bool testXmlWellFormed(string s)
        {
            try
            {
                XDocument x = XDocument.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}