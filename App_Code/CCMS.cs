using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;

namespace sage
{
    /*
 * 

    // *** The Categories Class wrapper for the table Categories ***
    // *** This class should inherit from Database Table ***

     *
     * 
     * depends on class dboperations
     * 
     * Table Dependency for this class
     * Must create CODES Table prior to this table
     * 
     * 

    CREATE TABLE [dbo].[Codes](
[CodeID] [int] IDENTITY(1,1) NOT NULL,
[CategoryID] [int] NOT NULL,
[CodeNameText] [nvarchar](50) NOT NULL,
[CodeDescriptionText] [nvarchar](250) NULL,
[CodeHelpText] [ntext] NULL,
[DeletedBit] [bit] NOT NULL,
CONSTRAINT [PK_Codes] PRIMARY KEY CLUSTERED 
(
[CodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
 
     CREATE TABLE [dbo].[Categories](
[CategoryID] [int] IDENTITY(1,1) NOT NULL,
[CategoryNameText] [nvarchar](50) NOT NULL,
[CategoryDescriptionText] [nvarchar](250) NULL,
[CategoryHelpText] [ntext] NULL,
[ParentCategoryID] [int] NULL,
[ParentCodeID] [int] NULL,
[DeletedBit] [bit] NOT NULL,
CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentCategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO

ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO

ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Codes] FOREIGN KEY([ParentCodeID])
REFERENCES [dbo].[Codes] ([CodeID])
GO

ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Codes]
GO
 
ALTER TABLE [dbo].[Codes]  WITH CHECK ADD  CONSTRAINT [FK_Codes_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO

ALTER TABLE [dbo].[Codes] CHECK CONSTRAINT [FK_Codes_Categories]
GO 
     * 
     * */
    public class Categories : ObjectCommon
    {
        bool isModified;
        long myCategoryID;
        string myCategoryNameText;
        string myCategoryDescriptionText;
        string myCategoryHelpText;
        long myParentCategoryID;
        long myParentCodeID;
        bool myDeletedBit;


        public long CategoryID
        {
            get { return myCategoryID; }
            set
            {
                myCategoryID = value;
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

        public string CategoryDescriptionText
        {
            get { return myCategoryDescriptionText; }
            set
            {
                myCategoryDescriptionText = value;
                isModified = true;
            }
        }

        public string CategoryHelpText
        {
            get { return myCategoryHelpText; }
            set
            {
                myCategoryHelpText = value;
                isModified = true;
            }
        }

        public long ParentCategoryID
        {
            get { return myParentCategoryID; }
            set
            {
                myParentCategoryID = value;
                isModified = true;
            }
        }

        public long ParentCodeID
        {
            get { return myParentCodeID; }
            set
            {
                myParentCodeID = value;
                isModified = true;
            }
        }

        public bool DeletedBit
        {
            get { return myDeletedBit; }
            set
            {
                myDeletedBit = value;
                isModified = true;
            }
        }

        public Categories()
        {
        }

        public Categories(int id)
        {
            CategoryID = id;
            Retrieve();
        }

        public Categories(string name)
        {
            CategoryID = GetCategoryID(name);
            Retrieve();
        }

        public bool Insert()
        {
            // *** saves  to the database, returns true on success ***
            if (!Validate()) return false;

            isModified = false;
            Dictionary<string, object> ht = new Dictionary<string, object>();

            ht.Add("@CategoryNameText", CategoryNameText);
            ht.Add("@CategoryDescriptionText", CategoryDescriptionText);
            ht.Add("@CategoryHelpText", CategoryHelpText);
            if (ParentCategoryID != 0) ht.Add("@ParentCategoryID", ParentCategoryID);
            if (ParentCodeID != 0) ht.Add("@ParentCodeID", ParentCodeID);
            ht.Add("@DeletedBit", DeletedBit);

            dboperations.ExecuteProcedure("sp_InsertCategory", ht);
            return true;
        }

        public new bool Validate()
        {
            bool isValid = true;
            // This returns a boolean, whether validation was successful
            // if [business rule] then 
            //     isValid = false
            //     addValidationMessage("Message Here") ' end if
            return isValid;
        }

        public bool Retrieve()
        {
            // *** retrieves  from the database ***
            // *** returns true on success ***

            // *** set the dr to the row to import from the table ***
            if (CategoryID == 0) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@CategoryID", CategoryID);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_GetCategory", ht);

            return FillFromDataSet(ds);
        }

        public bool RetrieveByField(string fieldName, string FieldValue)
        {
            string sql = null;
            sql = "SELECT * FROM Categories WHERE " + fieldName + " = '" + FieldValue + "'";
            DataSet ds = new DataSet();
            ds = dboperations.ExecuteSQL(sql);
            return FillFromDataSet(ds);
        }

        public override void FillFromDataRow(DataRow dr)
        {

            // If data fields is null just moves to next field
            CategoryID = ConvertToInteger(dr["CategoryID"]);
            CategoryNameText = ConvertToString(dr["CategoryNameText"]);
            CategoryDescriptionText = ConvertToString(dr["CategoryDescriptionText"]);
            CategoryHelpText = ConvertToString(dr["CategoryHelpText"]);
            ParentCategoryID = ConvertToInteger(dr["ParentCategoryID"]);
            ParentCodeID = ConvertToInteger(dr["ParentCodeID"]);
            DeletedBit = ConvertToBoolean(dr["DeletedBit"]);
        }

        public bool Update()
        {
            if (!isModified) return true;
            if (!Validate()) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@CategoryID", CategoryID);
            ht.Add("@CategoryNameText", CategoryNameText);
            ht.Add("@CategoryDescriptionText", CategoryDescriptionText);
            ht.Add("@CategoryHelpText", CategoryHelpText);
            if (ParentCategoryID != 0) ht.Add("@ParentCategoryID", ParentCategoryID);
            if (ParentCodeID != 0) ht.Add("@ParentCodeID", ParentCodeID);
            ht.Add("@DeletedBit", DeletedBit);

            DataSet ds = new DataSet();
            dboperations.ExecuteProcedure("sp_UpdateCategory", ht);

            return true;
        }

        public void Delete()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@CategoryID", CategoryID);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_DeleteCategory", ht);
        }

        public DataTable GetCodes()
        {
            string sql = "SELECT * FROM Codes WHERE CategoryID = " + Convert.ToString(CategoryID);
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public string fullHelpText()
        {
            string s = "<h3>Category Used : ";
            s += CategoryDescriptionText + "</h3>" + CategoryHelpText + "<br/>";
            DataTable dt = GetCodes();

            s += "<ul>";
            foreach (DataRow dr in dt.Rows)
            {
                Codes c = new Codes(Convert.ToInt32(dr["CodeID"]));
                s += "<li>" + c.fullHelpText() + "</li>";
            }
            s += "</ul>";
            return s;
        }

        #region "Static Methods"

        public static DataTable getAllCategories()
        {
            return dboperations.ExecuteSQLReturnDataTable("Select * FROM Categories ORDER BY CategoryNameText ASC");
        }


        public static int GetCategoryID(String CategoryNameText)
        {
            string sql = "SELECT CategoryID FROM Categories WHERE CategoryNameText = '" + CategoryNameText + "'";
            return dboperations.ExecuteSQLReturnInteger(sql);
        }

        public static DataTable getCodes(String CategoryNameText)
        {
            int CategoryID = GetCategoryID(CategoryNameText);
            return getCodes(CategoryID);
        }

        public static DataTable getCodes(int CategoryID)
        {
            string sql = "SELECT * FROM Codes WHERE CategoryID = " + Convert.ToString(CategoryID) + " ORDER BY CodeNameText ASC";
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static string asString(int CategoryID)
        {
            Categories c = new Categories(CategoryID);
            return c.CategoryNameText;
        }

        public static string asHTML(int CategoryID)
        {
            string s = String.Empty;
            s += "<td>" + asString(CategoryID) + "</td>";
            s += "<td>" + Codes.asString(CategoryID) + "</td>";
            return s;
        }

        public static string Export()
        {
            return dboperations.generateInsert("Categories");
        }

        public static string ExportAll()
        {
            DataTable dt = dboperations.ExecuteSQLReturnDataTable("SELECT * FROM Categories");
            string s = "DECLARE @fkID INT<br/><br/>";
            foreach (DataRow dr in dt.Rows)
            {
                s += Export(Convert.ToInt32(dr["CategoryID"]));
            }
            return s;
        }

        public static string Export(int pkID)
        {
            string s = String.Empty;
            string t = String.Empty;
            s += dboperations.generateInsert("Categories", "CategoryID", pkID);
            s += "SET @fkID = SCOPE_IDENTITY() <br/><br/>";
            DataTable dt = getCodes(pkID);
            foreach (DataRow dr in dt.Rows)
            {

                t = Codes.Export(Convert.ToInt32(dr["CodeID"]));
                s += t.Replace("(" + Convert.ToString(pkID) + " ,", "( @fkID ,");
            }
            return s;
        }

        #endregion

    }


    public class Codes : ObjectCommon
    {
        // *** This is a Class wrapper for the table Codes ***
        // *** This class should inherit from Database Table ***

        bool isModified;
        long myCodeID;
        long myCategoryID;
        string myCodeNameText;
        string myCodeDescriptionText;
        string myCodeHelpText;
        bool myDeletedBit;

        public const string CodeTextField = "CodeDescriptionText";
        public const string CodeValueField = "CodeNameText";

        public long CodeID
        {
            get { return myCodeID; }
            set
            {
                myCodeID = value;
                isModified = true;
            }
        }

        public long CategoryID
        {
            get { return myCategoryID; }
            set
            {
                myCategoryID = value;
                isModified = true;
            }
        }

        public string CodeNameText
        {
            get { return myCodeNameText; }
            set
            {
                myCodeNameText = value;
                isModified = true;
            }
        }

        public string CodeDescriptionText
        {
            get { return myCodeDescriptionText; }
            set
            {
                myCodeDescriptionText = value;
                isModified = true;
            }
        }

        public string CodeHelpText
        {
            get { return myCodeHelpText; }
            set
            {
                myCodeHelpText = value;
                isModified = true;
            }
        }

        public bool DeletedBit
        {
            get { return myDeletedBit; }
            set
            {
                myDeletedBit = value;
                isModified = true;
            }
        }

        public Codes(int id)
        {
            CodeID = id;
            Retrieve();
        }

        public Codes()
        {
        }

        public bool Insert()
        {
            // *** saves  to the database, returns true on success ***
            if (!Validate()) return false;

            isModified = false;
            Dictionary<string, object> ht = new Dictionary<string, object>();

            ht.Add("@CategoryID", CategoryID);
            ht.Add("@CodeNameText", CodeNameText);
            ht.Add("@CodeDescriptionText", CodeDescriptionText);
            ht.Add("@CodeHelpText", CodeHelpText);
            ht.Add("@DeletedBit", DeletedBit);

            dboperations.ExecuteProcedure("sp_InsertCode", ht);
            return true;

        }

        public new bool Validate()
        {
            bool isValid = true;
            // This returns a boolean, whether validation was successful
            // if [business rule] then 
            //     isValid = false
            //     addValidationMessage("Message Here") ' end if
            return isValid;
        }

        public bool Retrieve()
        {
            // *** retrieves  from the database ***
            // *** returns true on success ***

            // *** set the dr to the row to import from the table ***
            if (CodeID == 0) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@CodeID", CodeID);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_GetCode", ht);

            FillFromDataSet(ds);
            return true;
        }

        public bool RetrieveByField(string fieldName, string FieldValue)
        {
            string sql = null;
            sql = "SELECT * FROM Codes WHERE " + fieldName + " = '" + FieldValue + "'";
            DataSet ds = new DataSet();
            ds = dboperations.ExecuteSQL(sql);
            return FillFromDataSet(ds);
        }

        public override void FillFromDataRow(DataRow dr)
        {
            CodeID = ConvertToInteger(dr["CodeID"]);
            CategoryID = ConvertToInteger(dr["CategoryID"]);
            CodeNameText = ConvertToString(dr["CodeNameText"]);
            CodeDescriptionText = ConvertToString(dr["CodeDescriptionText"]);
            CodeHelpText = ConvertToString(dr["CodeHelpText"]);
            DeletedBit = ConvertToBoolean(dr["DeletedBit"]);
        }

        public bool Update()
        {
            if (!isModified) return true;
            if (!Validate()) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();

            if (CategoryID == 0) CategoryID = Codes.GetCategoryIDForCodeID(CodeID);
            ht.Add("@CodeID", CodeID);
            ht.Add("@CategoryID", CategoryID);
            ht.Add("@CodeNameText", CodeNameText);
            ht.Add("@CodeDescriptionText", CodeDescriptionText);
            ht.Add("@CodeHelpText", CodeHelpText);
            ht.Add("@DeletedBit", DeletedBit);

            dboperations.ExecuteProcedure("sp_UpdateCode", ht);
            return true;
        }

        public void Delete()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@CodeID", CodeID);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_DeleteCode", ht);
        }

        public string fullHelpText()
        {
            string s = "<b>" + CodeDescriptionText + "</b>";
            if (CodeHelpText != String.Empty) s += " : " + CodeHelpText;
            return s;
        }

        #region "Static Methods"

        public static DataTable GetAllCodesForCategory(int CategoryID)
        {
            string sql = "SELECT * FROM Codes WHERE CategoryID = " + Convert.ToString(CategoryID);
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static int GetCategoryIDForCodeID(long code_id)
        {
            string sql = "SELECT CategoryID FROM Codes WHERE CodeID = " + Convert.ToString(code_id);
            return dboperations.ExecuteSQLReturnInteger(sql);
        }

        public static void addCode(string categoryName, string codeText)
        {
            int catID = Categories.GetCategoryID(categoryName);
            if (catID == 0) return;

            Codes c = new Codes();
            c.CategoryID = catID;
            c.CodeNameText = codeText;
            c.CodeDescriptionText = codeText;

            c.Insert();
        }

        public static string asString(int CategoryID)
        {
            if (CategoryID == 0) return String.Empty;
            DataTable dt = GetAllCodesForCategory(CategoryID);

            string s = String.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                if (s == String.Empty) s += Convert.ToString(dr["CodeNameText"]);
                else s += "," + Convert.ToString(dr["CodeNameText"]);
            }
            return s;
        }

        public static string Export()
        {
            return dboperations.generateInsert("Categories") + "<br/>" + dboperations.generateInsert("Codes");
        }

        public static string Export(int pkID)
        {
            return dboperations.generateInsert("Codes", "CodeID", pkID);
        }

        #endregion
    }

}
