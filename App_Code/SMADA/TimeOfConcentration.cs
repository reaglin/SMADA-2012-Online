using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMADA_2012.App_Code.SMADA
{
    public class TimeOfConcentration
    {

        private double mySlope;

        public double Slope
        {
            get { return mySlope; }
            set { mySlope = value; }
        }

        private double myLength;

        public double Length
        {
            get { return myLength; }
            set { myLength = value; }
        }

        private double myArea;

        public double Area
        {
            get { return myArea; }
            set { myArea = value; }
        }

        
        private double myRationalC;

        public double RationalC
        {
            get { return myRationalC; }
            set { myRationalC = value; }
        }

        private double myRetardanceC;

        public double RetardanceC
        {
            get { return myRetardanceC; }
            set { myRetardanceC = value; }
        }

        private double myIntensity;

        public double Intensity
        {
            get { return myIntensity; }
            set { myIntensity = value; }
        }

        private double myRetardanceN;

        public double RetardanceN
        {
            get { return myRetardanceN; }
            set { myRetardanceN = value; }
        }

        private double myManningsN;

        public double ManningsN
        {
            get { return myManningsN; }
            set { myManningsN = value; }
        }

        private double myCurveNumber;

        public double CurveNumber
        {
            get { return myCurveNumber; }
            set { myCurveNumber = value; }
        }
        

        public TimeOfConcentration()
        {
            // Default Constructor
        }

        public double calculateFAA()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            if (RationalC == 0) return 0;

            return 1.8 * (1.1 - RationalC) * Math.Sqrt(Length) / Math.Pow((100*Slope), 0.33);
        }

        public double calculateIzzard()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            if (RetardanceC == 0) return 0;
            if (Intensity == 0) return 0;

            double k = 0.0007*Intensity + RetardanceC/Math.Pow(Slope, 1/3);
            return (41*k*Math.Pow(Length,1/3))/Math.Pow(Intensity,2/3);
        }

        public double calculateKerby()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            if (RetardanceN == 0) return 0;

            return 0.83 * Math.Pow((Length * RetardanceN * Math.Pow(Slope, -0.5)), 0.467);
        }

        public double calculateKinematic()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (Intensity == 0) return 0;

            return 0.93 * (Math.Pow(Length, 0.6) * Math.Pow(ManningsN, 0.6)) / (Math.Pow(Intensity, 0.4) * Math.Pow(Slope, 0.3));
        }

        public double calculateKirpich()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            return 0.0078 * Math.Pow(Length, 0.77) / Math.Pow(Slope, 0.385);
        }

        public double calculateBransbyWilliams()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            if (Area == 0) return 0;

            return 21.3 * (Length / 5280) / (Math.Pow(Area, 0.1) * Math.Pow(Slope, 0.2));
        }

        public double calculateNRCS()
        {
            if (Length == 0) return 0;
            if (Slope == 0) return 0;
            if (CurveNumber == 0) return 0;

            double S = 1000/CurveNumber - 10; 
            double l = 60*Math.Pow(Length,0.8)*Math.Pow(S+1,0.7)/(1900*Math.Sqrt(100*Slope));
            return l/0.6;
        }

        public string asHTMLTable()
        {

            string s = String.Empty;
            s += "<table border='1'>";
            s += "<tr><td>Length (ft)</td><td>" + String.Format("{0:0.0}", Length) + "</td></tr>";
            s += "<tr><td>Slope (fraction)</td><td>" + String.Format("{0:0.0000}", Slope) + "</td></tr>";
            s += "<tr><td>Area (square miles)</td><td>" + String.Format("{0:0.000}", Area) + "</td></tr>";
            s += "<tr><td>Rainall Intensity (in/hr)</td><td>" + String.Format("{0:0.00}", Intensity) + "</td></tr>";
            s += "<tr><td>Manning's Overland N </td><td>" + String.Format("{0:0.000}", ManningsN) + "</td></tr>";
            s += "<tr><td>FAA Rational C </td><td>" + String.Format("{0:0.000}", RationalC) + "</td></tr>";
            s += "<tr><td>NRCS Curve Number </td><td>" + String.Format("{0:0.0}", CurveNumber) + "</td></tr>";
            s += "<tr><td>Izzard Retardance C</td><td>" + String.Format("{0:0.000}", RetardanceC) + "</td></tr>";
            s += "<tr><td>Kerby Roughness N</td><td>" + String.Format("{0:0.000}", RetardanceN ) + "</td></tr>";
            s += "<tr><td>Time of Concentration Method</td><td> Calculated in Minutes</td></tr>";

            s += "<tr><td>FAA </td><td>" + String.Format("{0:0.000}", calculateFAA()) + "</td></tr>";
            s += "<tr><td>Izzard </td><td>" + String.Format("{0:0.000}", calculateIzzard()) + "</td></tr>";
            s += "<tr><td>Kerby </td><td>" + String.Format("{0:0.000}", calculateKerby()) + "</td></tr>";
            s += "<tr><td>Kinematic </td><td>" + String.Format("{0:0.000}", calculateKinematic()) + "</td></tr>";
            s += "<tr><td>Kirpich </td><td>" + String.Format("{0:0.000}", calculateKirpich()) + "</td></tr>";
            s += "<tr><td>Bransby Williams </td><td>" + String.Format("{0:0.000}", calculateBransbyWilliams()) + "</td></tr>";
            s += "<tr><td>NRCS </td><td>" + String.Format("{0:0.000}", calculateNRCS()) + "</td></tr>";
            s += "</table>";
            return s;
        }
    }
}