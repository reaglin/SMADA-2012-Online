using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMADA_2012.App_Code.SMADA
{
    public class Pipe
    {
        
        private double flow;         // default cfs
        private double slope;        // fraction
        private double manningsN;
        private double depth;        // feet
        private double velocity;     // fps
       
        public double Flow
        {
            get { return flow;}
            set {flow=value;}
        }

        public double Slope
        {
            get { return slope;}
            set {slope=value;}
        }
        
        public double ManningsN
        {
            get { return manningsN;}
            set {manningsN=value;}
        }

        public double Depth
        {
            get { return depth;}
            set {depth=value;}
        }

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Pipe()
        {
            // Default Constructor
        }
    }

    public class CircularPipe : Pipe
    {
        private double diameter;     // inches

        public double Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        public CircularPipe()
        {
            // Default Constructor
        }

        public void calculate()
        {

            if (Slope != 0 && ManningsN != 0 && Flow != 0 && Diameter != 0)
            {
                Depth = calculateDepth();
                Velocity = calculateVelocity();
                return;
            }

            if (Slope != 0 && ManningsN != 0 && Depth != 0 && Diameter != 0)
            {
                Flow = calculateFlow();
                Velocity = calculateVelocity();
                return;
            }
        }

        public double calculateAngle()
        {
            // Uses Flow to calculate theta

            double d = Diameter/12;
            double n = ManningsN;

            if (d == 0) return 0;
            if (n == 0) return 0;
            if (ManningsN <= 0) return 0;

            if (Flow > fullFlow()) return 2 * Math.PI;

            double theta = 1.0;
            double delta = 1.0;
            double lastdelta = 0.0;
            double incr = 0.5;
            int iter = 0;

            double r;
            double b;
            while (Math.Abs(delta) > 0.00001 && iter < 500)
            {
                r = 0.25*d*(1-Math.Sin(theta)/theta);
                b = Flow /((1.0/8.0)*(theta - Math.Sin(theta))*Math.Pow(d,2));
                delta = (1.49/n) * Math.Pow(r, 2.0/3.0)*Math.Pow(Slope, 0.5) - b;

                if (Math.Sign(lastdelta) != Math.Sign(delta)) incr = incr / 2;
                theta = (delta > 0 ? theta - incr  : theta +incr);
                lastdelta = delta;

                if (theta > 2 * Math.PI) return 2 * Math.PI;
                iter++;
            }
            return theta;
        }

        public double calculateDepth()
        {
            // Using Flow Calculates Depth
         
            if (Slope == 0) return 0;
            if (Flow == 0) return 0;
            if (ManningsN == 0) return 0;

            double theta = calculateAngle();
            if (theta == 0) return 0;

            double d = diameter/12;
            double r = d / 2;

            if (theta > 2*Math.PI) return d;

            if (theta < Math.PI)
            {
                double t = (Math.PI - theta) / 2;
                return r - r * Math.Sin(t);
            }
            else
            {
                double t = (theta - Math.PI) / 2;
                return r + r * Math.Sin(t);
            }
        }

        public double calculateVelocity()
        {
            // Uses Flow to Calculate depth

            if (Slope == 0) return 0;
            if (Flow == 0) return 0;
            if (ManningsN == 0) return 0;

            double d = diameter/12;
            double r = d/2;

            if (Flow > fullFlow()) 
                  return Flow /( Math.PI * Math.Pow(r,2));

            double theta = calculateAngle();
            if (theta == 0) return 0;

            double area = Math.PI*Math.Pow(r,2)*(theta / (2*Math.PI));
            return Flow/area;
        }

        public double calculateHydraulicRadius()
        {
            // uses depth to calculate Hydraulic Radius

            if (Depth == 0) return 0;
            if (Depth > Diameter / 12) return 0.5;

            double r = Diameter / 24;

            double a = calculateFlowArea();
            double p = calculateWettedPerimeter();
            return a / p;
        }

        public double calculateWettedPerimeter()
        {
            // uses depth to calculate Hydraulic Radius

            if (Depth == 0) return 0;
            if (Depth > Diameter / 12) return Math.PI * Diameter / 12;

            double r = Diameter / 24;
            if (Depth <= r)
            {
                double th = 2 * Math.Acos((r - Depth) / r);
                double a = (Math.Pow(r,2)*(th-Math.Sin(th)))/2;
                double p = r*th;
                return a/p;
            }
            else // more than half full
            {
                double h = Diameter / 12 - Depth;
                double th = 2 * Math.Acos((r - h) / r);
                double a = Math.PI*Math.Pow(r,2) - (Math.Pow(r, 2) * (th - Math.Sin(th))) / 2;
                double p = 2*Math.PI*r - r * th;
                return a/p;
            }
        }

        public double calculateFlow()
        {
            double hr = calculateHydraulicRadius();
            double xcArea = calculateFlowArea();

            return (1.49 / ManningsN) * xcArea * Math.Pow(hr, 2.0 / 3.0) * Math.Pow(Slope, 0.5);
        }

        public double fullFlow()
        {
            double d = Diameter/12;

            return (0.4644 / ManningsN) * Math.Pow(d, (8.0 / 3.0)) * Math.Pow(Slope, 0.5); 
        }

        public double calculateFlowArea()
        {
            if (Depth != 0)
            {
                double r = Diameter / 24;

                if (Depth > Diameter/12)              
                    return Math.PI * Math.Pow(r,2);
                if (Depth <= r)
                {
                   double th = 2 * Math.Acos((r - Depth) / r);
                   return (Math.Pow(r,2)*(th-Math.Sin(th)))/2;
                }
            else // more than half full
               {
                double h = Diameter / 12 - Depth;
                double th = 2 * Math.Acos((r - h) / r);
                return Math.PI*Math.Pow(r,2) - (Math.Pow(r, 2) * (th - Math.Sin(th))) / 2; 
               }
            }

            if (Flow != 0)
            {
            double r = Diameter / 24;
            double theta = calculateAngle();
            if (theta == 0) return 0;

            double area = Math.PI * Math.Pow(r, 2) * (theta / (2 * Math.PI));
            return area;
            }
            
           return 0;
        }

        public double[,] asDoubleFlowDepth()
        {
            int n = 20;
            
            double[,] v = new double[2, n];

            for (int i = 0; i < n; i++)
            {
                v[0, i] = i * (Diameter / 12) / 20;
                Depth = v[0, i];

                v[1, i] = calculateFlow();
                
            }
            return v;
        }

        public string asHTMLTable()
        {
            double theta = calculateAngle();
            double area = calculateFlowArea();
            double wp = calculateWettedPerimeter();
            double hr = calculateHydraulicRadius();

            string s = String.Empty;
            s += "<table border='1'>";
            s += "<tr><td>Diameter (in)</td><td>" + String.Format("{0:0.0}", Diameter) + "</td></tr>";
            s += "<tr><td>Flow Rate (cfs)</td><td>" + String.Format("{0:0.000}", Flow) + "</td></tr>";
            s += "<tr><td>Slope (%)</td><td>" + String.Format("{0:0.00}", Slope*100) + "</td></tr>";
            s += "<tr><td>Manning's n </td><td>" + String.Format("{0:0.000}", ManningsN) + "</td></tr>";
            s += "<tr><td>Depth (ft) </td><td>" + String.Format("{0:0.000}", Depth) + "</td></tr>";
            s += "<tr><td>Velocity (fps) </td><td>" + String.Format("{0:0.000}", Velocity) + "</td></tr>";
            s += "<tr><td>Flow Angle (rad) </td><td>" + String.Format("{0:0.000}", theta) + "</td></tr>";
            s += "<tr><td>Flow Area (sf)</td><td>" + String.Format("{0:0.000}", area) + "</td></tr>";
            s += "<tr><td>Wetted Perimeter (ft) </td><td>" + String.Format("{0:0.000}", wp) + "</td></tr>";
            s += "<tr><td>Hydraulic Radius (ft) </td><td>" + String.Format("{0:0.000}", hr) + "</td></tr>";

            s += "</table>";
            return s;
        }

    }

    public class TrapezoidalChannel : Pipe
    {
        private double sideslope;
        private double bottomwidth;  // feet

        public double SideSlope
        {
            get { return sideslope; }
            set { sideslope = value; }
        }

        public double BottomWidth
        {
            get { return bottomwidth; }
            set { bottomwidth = value; }
        }

        public void calculate()
        {

            if (Slope != 0 && ManningsN != 0 && Flow != 0 && BottomWidth != 0)
            {
                Depth = calculateDepth();
                Velocity = calculateVelocity();
                return;
            }

            if (Slope != 0 && ManningsN != 0 && Depth != 0 && BottomWidth != 0)
            {
                Flow = calculateFlow();
                Velocity = calculateVelocity();
                return;
            }
        }


        public double calculateDepth()
        {
            // Iteratively calculates depth

            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (BottomWidth == 0) return 0;

            double b = BottomWidth;
            double z = SideSlope;
            double q = Flow;
            double dq = 0;
            double hr = 0;
            double wp = 0;
            double area = 0;
            double dh = 1.0;
            double delta = 1.0;
            double lastdelta = 1.0;
            double incr = 0.1;

            while (delta > 0.0001 && incr > 0.00001)
            {
                area = (b + z * dh) * dh;
                wp = b + 2*dh*Math.Sqrt(((1 + Math.Pow(z,2))));
                hr = area / wp;
                dq = (1.49 / ManningsN) * area * Math.Pow(hr, 2 / 3) * Math.Sqrt(Slope);

                delta = dq - q;
                if (Math.Sign(delta) != Math.Sign(lastdelta)) incr = incr/2;
                if (delta > 0) dh -= incr;
                if (delta < 0) dh += incr;
                lastdelta = delta;
            }
            return dh;
        }

        public double calculateFlowArea()
        {
            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (BottomWidth == 0) return 0;
            if (Depth == 0) return 0;

            return Depth * (BottomWidth + SideSlope * Depth);
        }

        public double calculateWettedPerimeter()
        {
            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (BottomWidth == 0) return 0;
            if (Depth == 0) return 0;

            return BottomWidth + 2 * Depth * Math.Sqrt(1 + Math.Pow(SideSlope, 2));
        }

        public double calculateHydraulicRadius()
        {
            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (BottomWidth == 0) return 0;
            if (Depth == 0) return 0;

            return calculateFlowArea() / calculateWettedPerimeter();
        }

        public double calculateVelocity()
        {
            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (BottomWidth == 0) return 0;
            if (Depth == 0) return 0;

            double area = calculateFlowArea();
            return Flow / area;
        }

        public double calculateFlow()
        {
            if (Slope == 0) return 0;
            if (ManningsN == 0) return 0;
            if (BottomWidth == 0) return 0;
            if (Depth == 0) return 0;

            double area = calculateFlowArea();
            double hr = calculateHydraulicRadius();

            return  (1.49 / ManningsN) * area * Math.Pow(hr, 2 / 3) * Math.Sqrt(Slope);
        }

        public string asHTMLTable()
        {
            double area = calculateFlowArea();
            double wp = calculateWettedPerimeter();
            double hr = calculateHydraulicRadius();

            string s = String.Empty;
            s += "<table border='1'>";
            s += "<tr><td>Bottom Width (ft)</td><td>" + String.Format("{0:0.0}", BottomWidth ) + "</td></tr>";
            s += "<tr><td>Side Slope (fvert/horiz)</td><td>" + String.Format("{0:0.0}", SideSlope) + "</td></tr>";
            s += "<tr><td>Flow Rate (cfs)</td><td>" + String.Format("{0:0.000}", Flow) + "</td></tr>";
            s += "<tr><td>Slope (%)</td><td>" + String.Format("{0:0.00}", Slope * 100) + "</td></tr>";
            s += "<tr><td>Manning's n </td><td>" + String.Format("{0:0.000}", ManningsN) + "</td></tr>";
            s += "<tr><td>Depth (ft) </td><td>" + String.Format("{0:0.000}", Depth) + "</td></tr>";
            s += "<tr><td>Velocity (fps) </td><td>" + String.Format("{0:0.000}", Velocity) + "</td></tr>";
            s += "<tr><td>Flow Area (sf)</td><td>" + String.Format("{0:0.000}", area) + "</td></tr>";
            s += "<tr><td>Wetted Perimeter (ft) </td><td>" + String.Format("{0:0.000}", wp) + "</td></tr>";
            s += "<tr><td>Hydraulic Radius (ft) </td><td>" + String.Format("{0:0.000}", hr) + "</td></tr>";

            s += "</table>";
            return s;
        }
        public double[,] asDoubleFlowDepth()
        {
            int n = 20;

            double holdDepth = Depth;
            double maxDepth = Depth * 2;
            double[,] v = new double[2, n];

            for (int i = 0; i < n; i++)
            {
                v[0, i] = i * (maxDepth) / 20;
                Depth = v[0, i];

                v[1, i] = calculateFlow();

            }
            Depth = holdDepth;
            return v;
        }

    }
}