using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;

namespace sage
{
    public class UserLogin : ObjectCommon
    {

        /*
         * Dependencies on following tables
         * 
     USE DatabaseName
     GO     
     CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleNameText] [nvarchar](250) NOT NULL,
	[RoleDescriptionText] [ntext] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
          
     CREATE TABLE [dbo].[UserLogin](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](63) NOT NULL,
	[UserPassword] [nvarchar](63) NOT NULL,
	[UserFullName] [nvarchar](200) NULL,
	[UserEmail] [nvarchar](300) NOT NULL,
	[UserPhone] [nvarchar](20) NULL,
	[UserCreatedDate] [datetime] NOT NULL,
	[UserLastLoginDate] [datetime] NULL,
	[UserIsDeletedBit] [bit] NOT NULL,
	[UserAgencyID] [int] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
    CREATE TABLE [dbo].[UserRoles](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO

ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO

ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_UserLogin] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserLogin] ([UserID])
GO

ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_UserLogin]
GO
         
INSERT INTO [dbo].[Roles]
           ([RoleNameText]
           ,[RoleDescriptionText])
     VALUES
           ('Guest',
           'Guest User')
GO
INSERT INTO [dbo].[Roles]
           ([RoleNameText]
           ,[RoleDescriptionText])
     VALUES
           ('Administrator',
           'Administrative User')
GO
    INSERT INTO [dbo].[UserLogin]
           ([UserName]
           ,[UserPassword]
           ,[UserFullName]
           ,[UserEmail]           
           ,[UserCreatedDate]
           ,[UserIsDeletedBit])
     VALUES
           ('Administrator'
           ,'Password'
           ,'Administrative User'
           ,'mail@domain.com'
           ,GETDATE()
           ,0)
GO
INSERT INTO [dbo].[UserRoles]
           ([UserID]
           ,[RoleID])
     VALUES
           (1,2)
GO

        USE [smadaonline]
GO


         *  
         * */


        #region Properties

        bool isModified;
        long myUserID;
        string myUserName;
        string myUserPassword;
        string myUserFullName;
        string myUserEmail;
        string myUserPhone;
        System.DateTime myUserCreatedDate;
        System.DateTime myUserLastLoginDate;
        bool myUserIsDeletedBit;
        long myUserAgencyID;


        public long UserID
        {
            get { return myUserID; }
            set
            {
                myUserID = value;
                isModified = true;
            }
        }

        public string UserName
        {
            get { return myUserName; }
            set
            {
                myUserName = value;
                isModified = true;
            }
        }

        public string UserPassword
        {
            get { return myUserPassword; }
            set
            {
                myUserPassword = value;
                isModified = true;
            }
        }

        public string UserFullName
        {
            get { return myUserFullName; }
            set
            {
                myUserFullName = value;
                isModified = true;
            }
        }

        public string UserEmail
        {
            get { return myUserEmail; }
            set
            {
                myUserEmail = value;
                isModified = true;
            }
        }

        public string UserPhone
        {
            get { return myUserPhone; }
            set
            {
                myUserPhone = value;
                isModified = true;
            }
        }

        public System.DateTime UserCreatedDate
        {
            get { return myUserCreatedDate; }
            set
            {
                myUserCreatedDate = value;
                isModified = true;
            }
        }

        public System.DateTime UserLastLoginDate
        {
            get { return myUserLastLoginDate; }
            set
            {
                myUserLastLoginDate = value;
                isModified = true;
            }
        }

        public bool UserIsDeletedBit
        {
            get { return myUserIsDeletedBit; }
            set
            {
                myUserIsDeletedBit = value;
                isModified = true;
            }
        }

        public long UserAgencyID
        {
            get { return myUserAgencyID; }
            set
            {
                myUserAgencyID = value;
                isModified = true;
            }
        }

        #endregion

        #region Constructors

        public UserLogin(System.Web.SessionState.HttpSessionState s)
        {
            if (UserLogin.isLoggedIn(s))
                this.Retrieve(Convert.ToString(s["UserName"]));
        }

        public UserLogin(String name)
        {
            this.Retrieve(name);
        }

        public UserLogin(int id)
        {
            this.UserID = id;
            this.Retrieve();
        }

        public UserLogin()
        { }

        #endregion

        #region Database Access

        public bool Insert()
        {
            // *** saves  to the database, returns true on success ***
            if (!Validate()) return false;
            isModified = false;

            string sql = "SELECT COUNT(*) FROM UserLogin WHERE UserName = '" + UserName + "'";
            if (dboperations.ExecuteSQLReturnInteger(sql) > 0) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();

            ht.Add("@UserName", UserName);
            ht.Add("@UserPassword", UserPassword);
            ht.Add("@UserFullName", UserFullName);
            ht.Add("@UserEmail", UserEmail);
            ht.Add("@UserPhone", UserPhone);
            ht.Add("@UserIsDeletedBit", UserIsDeletedBit);
            //ht.Add("@UserAgencyID", UserAgencyID);

            DataSet ds = new DataSet();
            ds = dboperations.GetDataSet("sp_InsertUserLogin", ht);
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
            if (UserID == 0) return false;
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@UserID", UserID);

            return FillFromDataSet(dboperations.GetDataSet("sp_GetUserLogin", ht));
        }

        public bool Retrieve(String name)
        {
            return RetrieveByField("UserName", name);
        }

        public bool RetrieveByField(string fieldName, string FieldValue)
        {
            string sql = null;
            sql = "SELECT * FROM UserLogin WHERE " + fieldName + " = '" + FieldValue + "'";
            DataSet ds = new DataSet();
            ds = dboperations.ExecuteSQL(sql);
            return FillFromDataSet(ds);
        }

        public override void FillFromDataRow(DataRow dr)
        {

            // If data fields is null just moves to next field
            UserID = ConvertToInteger(dr["UserID"]);
            UserName = ConvertToString(dr["UserName"]);
            UserPassword = ConvertToString(dr["UserPassword"]);
            UserFullName = ConvertToString(dr["UserFullName"]);
            UserEmail = ConvertToString(dr["UserEmail"]);
            UserPhone = ConvertToString(dr["UserPhone"]);
            UserCreatedDate = ConvertToDateTime(dr["UserCreatedDate"]);
            UserLastLoginDate = ConvertToDateTime(dr["UserLastLoginDate"]);
            UserIsDeletedBit = ConvertToBoolean(dr["UserIsDeletedBit"]);
            UserAgencyID = ConvertToInteger(dr["UserAgencyID"]);
        }

        public bool Update()
        {
            // *** retrievs  from the database ***
            // *** returns true on success ***
            if (!isModified) return true;

            if (!Validate()) return false;

            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@UserID", UserID);
            ht.Add("@UserName", UserName);
            ht.Add("@UserPassword", UserPassword);
            ht.Add("@UserFullName", UserFullName);
            ht.Add("@UserEmail", UserEmail);
            ht.Add("@UserPhone", UserPhone);
            ht.Add("@UserIsDeletedBit", UserIsDeletedBit);
            //ht.Add("@UserAgencyID", UserAgencyID);

            dboperations.ExecuteProcedure("sp_UpdateUserLogin", ht);
            return true;
        }

        public bool isAdministrator()
        {
            string sql = String.Empty;
            sql = "SELECT Count(*) FROM UserRoles WHERE UserID=" + Convert.ToString(UserID) + " AND RoleID = 2";
            int i = dboperations.ExecuteSQLReturnInteger(sql);
            if (i > 0)
                return true;
            else
                return false;
        }

        public void setAsAministrator()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@UserID", UserID);

            dboperations.ExecuteProcedure("sp_InsertAdministrator", ht);

        }

        public void deleteAministrator()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@UserID", UserID);

            dboperations.ExecuteProcedure("sp_DeleteAdministrator", ht);

        }

        #endregion

        #region "Static Methods"

        public static bool ValidateLogin(string UserName, string UserPassword)
        {
            string sql = String.Empty;
            sql = "SELECT Count(*) FROM UserLogin WHERE UserName='" + UserName + "' AND UserPassword='" + UserPassword + "'";
            int i = dboperations.ExecuteSQLReturnInteger(sql);

            if (i > 0)
                return true;
            else
                return false;

        }

        public static bool isAdministrator(System.Web.SessionState.HttpSessionState s)
        {
            if (s["UserName"] == null) return false;
            if (Convert.ToString(s["UserName"]) == String.Empty) return false;
            return UserLogin.isAdministrator(Convert.ToString(s["UserName"]));
        }

        public static bool isAdministrator(String user_name)
        {
            UserLogin ul = new UserLogin(user_name);
            return ul.isAdministrator();
        }


        public static bool isLoggedIn(System.Web.SessionState.HttpSessionState s)
        {
            if (s["UserName"] == null) return false;
            if (Convert.ToString(s["UserName"]) == String.Empty) return false;
            return true;
        }

        public static String defaultURL()
        {
            return "~/default.aspx";
        }

        public static String defaultLoggedInURL()
        {
            return "~/DefaultLoggedIn.aspx";
        }

        public static String bounceURL(System.Web.SessionState.HttpSessionState s)
        {
            // Goes to correct URL for useer
            if (s["UserName"] == null) return UserLogin.defaultURL();
            if (Convert.ToString(s["UserName"]) == String.Empty) return UserLogin.defaultURL();
            return defaultLoggedInURL();
        }

        public static DataTable getAllUserRoles()
        {
            return dboperations.GetDataTable("sp_GetAllUserRoles");
        }

        public static int getUserID(System.Web.SessionState.HttpSessionState s)
        {
            if (UserLogin.isLoggedIn(s))

                return dboperations.ExecuteSQLReturnInteger("SELECT UserID FROM UserLogin WHERE UserName = '" + Convert.ToString(s["UserName"]) + "'");
            else
                return 0;
        }

        public static string getUserName(System.Web.SessionState.HttpSessionState s)
        {
            return Convert.ToString(s["UserName"]);
        }

        public static string getUserFullName(System.Web.SessionState.HttpSessionState s)
        {
            if (UserLogin.isLoggedIn(s))

                return dboperations.ExecuteSQLReturnString("SELECT UserFullName FROM UserLogin WHERE UserName = '" + Convert.ToString(s["UserName"]) + "'");
            else
                return "";
        }


        #endregion

    }
}
