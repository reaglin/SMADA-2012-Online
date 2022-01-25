using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using sage;

namespace SMADA_2012.App_Code
{
    public class Feedback
    {
        public string pageName { get; set; }
        public string feedbackText { get; set; }
        public bool isResolved {get; set; }
        public static void Insert()
        {
            
        }

        public static void getAllFeedback()
        {
        }

        public static void getUnresolvedFeedback()
        {
        }


    }

    public class FormHeaders
    {
        // Will containmostly static methods for header and footer text used on forms

        public static void insertFormHeader(string formName, string formText)
        {
            string sql = "SELECT COUNT(*) FROM FormTitles WHERE formName = '" + formName + "'";
            int n = dboperations.ExecuteSQLReturnInteger(sql);
            string sp = "sp_InsertFormTitle";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            if (n == 1)
            {
                sql = "SELECT id FROM FormTitles WHERE formName = '" + formName + "'";
                int id = dboperations.ExecuteSQLReturnInteger(sql);
                Parameters.Add("@id", id);
                sp = "sp_UpdateFormTitle";
            }

            Parameters.Add("@FormName", formName);
            Parameters.Add("@FormText", formText);

            dboperations.ExecuteProcedure(sp, Parameters);

        }

        public static string getFormHeaderText(string ft)
        {
            string sql = "SELECT TOP 1 FormText FROM FormTitles WHERE FormName = '" + ft + "'";
            return dboperations.ExecuteSQLReturnString(sql);
        }
    }
}