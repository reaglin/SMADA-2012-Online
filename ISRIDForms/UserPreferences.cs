using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using sage;

namespace SMADA_2012.App_Code
{
    public class UserPreferences
    {
        public const string DistributionType = "DistributionType";
        public const string ProbabilityValues = "ProbabilityValues";

        public static void add(string key, string value, HttpSessionState s)
        {
            int uid = UserLogin.getUserID(s);
            add(key, value, uid);
        }

        public static void add(string key, string value, int userID)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@UserID", userID);
            Parameters.Add("@PKey", key);
            Parameters.Add("@PValue", value);

            dboperations.ExecuteProcedure("sp_InsertPreference", Parameters);
        }

        public static string getValue(string key, HttpSessionState s)
        {
            int id = UserLogin.getUserID(s);
            return getValue(key, id);
        }

        public static string getValue(string key, int userID)
        {
            string sql = "SELECT PValue FROM User UserPreferences WHERE PKey = '" + key;
            sql += "' AND UserID = " + Convert.ToString(userID);

            return dboperations.ExecuteSQLReturnString(sql);
        }

    }
}