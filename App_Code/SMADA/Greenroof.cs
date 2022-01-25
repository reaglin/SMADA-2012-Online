using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMADA2013.App_Code.SMADA
{
    public class Greenroof : Storage 
    {
        public static string SessionId = "RetentionID";

        public double GreenroofArea { get; set; } // Surface Area in acres
        public double RetentionProvided{ get; set; } // Depth of pond to start of weir in feet

        public override Dictionary<string, string> PropertyLabels()
        {
            var current = new Dictionary<string, string>
                {
                    {"GreenroofArea", "Greenroof Area (acres)"},
                    {"RetentionDepth", "Average Retention Depth (ft)"},
                };

            return Add(current, base.PropertyLabels());

        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            var current = new Dictionary<string, int>
                {
                    {"GreenroofArea", 2},
                    {"RetentionDepth", 2},
                };

            return Add(current, base.PropertyDecimalPlaces());
        }

        public override Dictionary<string, string> InputProperties()
        {
            return new Dictionary<string, string>
                {
                    {"GreenroofArea", "Retention Area (acres)"},
                    {"RetentionDepth", "Average Retention Depth (ft)"},
                    {"WatershedArea", "Catchment Area (acres)"},
                    {"WatershedNDCIACurveNumber", "Watershed Non-DCIA Curve Number"},
                    {"WatershedDCIAPercent", "Watershed DCIA Percent"},
                };
        }


        public new void Calculate()
        {
            base.Calculate();
        }
    }
}