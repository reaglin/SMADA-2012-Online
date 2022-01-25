using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace sage
{
    public class GlobalFunctions
    {

        public static float asFloat(TextBox tb)
        {
            try
            {
                return Convert.ToSingle(tb.Text);
            }
            catch
            {
                return 0;
            }
        }

        public static float asPositiveFloat(TextBox tb)
        {
            try
            {
                return Math.Abs(Convert.ToSingle(tb.Text));
            }
            catch
            {
                return 0;
            }
        }


    }
}