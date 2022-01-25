using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using sage;
/*
 CREATE TABLE [dbo].[RegressionData](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[DescriptionText] [nvarchar](250) NULL,
	[DataText] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL)

 */

namespace SMADA_2012.App_Code.SMADA
{
    public class RegressionAnalysis : SMADABase
    {
        #region Properties
        
        public const int MAXDATA = 5000;

        // If you add a new type - add 2 strings
        // modify YTransform, XTransform, canCalculate
        // and doRegression (for the detransform of the parameters)

        public const string TableName = "RegressionData";

        public const int NTypes = 6;
        public const string EqnLinear = "Y = a + b*X";
        public const string EqnExponential = "Y = a*e^(b*X)";
        public const string EqnPower = "Y = a*X^b";
        public const string EqnInverse = "Y = a/(b + X)";
        public const string EqnMonod = "Y = a*X/(b + X)";
        public const string EqnReciprocal = "Y = 1/(a + b*X)";

        public const string Linear = "Linear";
        public const string Exponential = "Exponential";
        public const string Power = "Power";
        public const string Inverse = "Inverse";
        public const string Monod = "Monod";
        public const string Reciprocal = "Reciprocal";

        public int n; // Number of points
        public double[] y = new double[MAXDATA];
        public double[] x = new double[MAXDATA];

        public bool[] doType = new bool[NTypes]; // Whether to calculate a type
        public bool[] calculated = new bool[NTypes]; // If a type has been calulated
        public double[,] yp = new double[NTypes,MAXDATA];
        public double[] a = new double[NTypes];
        public double[] b = new double[NTypes];
        public double[] SSE = new double[NTypes];
        public double[] xAvg = new double[NTypes];
        public double[] yAvg = new double[NTypes];
        public double[] aVar = new double[NTypes];
        public double[] bVar = new double[NTypes];
        public double[] r2 = new double[NTypes];
        
        public string RegressionType;

#endregion
        #region Constructors

        public RegressionAnalysis() : base("Regression Data")
        {
            for (int i = 0; i < NTypes; i++) doType[i] = true;
        }

        public RegressionAnalysis(bool[] typesToCalc) : base("Regression Data")
        {
            // typesToCalc must have at least NTypes
            for (int i = 0; i < NTypes; i++) doType[i] = typesToCalc[i];
        }

        #endregion

        #region String Functions
        public static string[] RegressionTypes()
        {
            return new string[] { Linear, Exponential, Power, Inverse, Monod, Reciprocal };
        }

        public static string[] RegressionEquations()
        {
            return new string[] { EqnLinear, EqnExponential, EqnPower, EqnInverse, EqnMonod, EqnReciprocal };
        }

        public static string[] RegressionTypesWithEquations()
        {
            string[] s1 = new string[NTypes];
            string[] rt = RegressionTypes();
            int i = 0;
            foreach (string s2 in rt)
            {
                s1[i] = RegressionTypes()[i] + " (" + RegressionEquations()[i] + ")";
                i++;
            }
            return s1;
        }


        public static SortedList RegressionTypesAsSortedList()
        {
            string[] choices = RegressionTypesWithEquations();
            IDictionary list = new SortedList();

            int i = 0;
            foreach (String c in choices)
            {
                list.Add(i, c);
                i++;
            }

            return (SortedList)list;
        }


        public int RegressionTypeIndex(string type)
        {
            return Array.IndexOf(RegressionTypes(), type);
        }

        public DataTable parametersAsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Regression Type"));
            dt.Columns.Add(new DataColumn("a"));
            dt.Columns.Add(new DataColumn("b"));
            dt.Columns.Add(new DataColumn("a var"));
            dt.Columns.Add(new DataColumn("b var"));
            dt.Columns.Add(new DataColumn("Y Avg"));
            dt.Columns.Add(new DataColumn("SSE"));
            dt.Columns.Add(new DataColumn("r^2"));

            string[] rte = RegressionTypesWithEquations();
            for (int j = 0; j < NTypes; j++)
            {
                if (doType[j] && canCalculate(j))
                {
                    DataRow dr = dt.NewRow();
                    dr["Regression Type"] = rte[j];
                    dr["a"] = String.Format("{0:0.000}", a[j]);
                    dr["b"] = String.Format("{0:0.000}", b[j]);
                    dr["a var"] = String.Format("{0:0.000}", aVar[j]);
                    dr["b var"] = String.Format("{0:0.000}", bVar[j]);
                    dr["Y Avg"] = String.Format("{0:0.000}", yAvg[j]);
                    dr["SSE"] = String.Format("{0:0.000}", SSE[j]);
                    dr["R^2"] = String.Format("{0:0.000}", r2[j]);

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public DataTable asDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("X"));
            dt.Columns.Add(new DataColumn("Y Actual"));
            for (int j = 0; j < NTypes; j++) if (calculated[j])
                dt.Columns.Add(new DataColumn(RegressionTypes()[j]));

                    for (int i = 0; i < n; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["X"] = String.Format("{0:0.000}", x[i]);
                        dr["Y Actual"] = String.Format("{0:0.000}", y[i]);
                        for (int j = 0; j < NTypes; j++) if (calculated[j])
                                    dr[RegressionTypes()[j]] = String.Format("{0:0.000}", yp[j,i]);
                        dt.Rows.Add(dr);
                    }
                
            return dt;
        }


        #endregion
        
        #region Calculations

        public void calculate()
        {
            int j;
            sort();
            foreach (string type in RegressionTypes())
            {
                j = RegressionTypeIndex(type);
                calculated[j] = canCalculate(type);
                if (calculated[j])
                {
                    doRegression(type);
                    doPredictions(type);
                    doStatistics(type);
                }
            }
        }

        public void sort()
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (x[i - 1] > x[i])
                    {
                        swap(i - 1, i);
                        swapped = true;
                    }
                }
            }
        }

        public void swap(int i, int j)
        {
            double tx = x[i];
            double ty = y[i];
            x[i] = x[j];
            y[i] = y[j];
            x[j] = tx;
            y[j] = ty;
        }

        public double XTransform(double X, string type)
        {
        switch (type)
        {
            case Linear: return X;
            case Exponential: return X;
            case Power: return Math.Log(X);
            case Inverse: return X;
            case Monod: return 1/X;
            case Reciprocal: return X;
            default: return X;
        }
    }

        public double YTransform(double Y, string type)
        {
            switch (type)
            {
                case Linear: return Y;
                case Exponential: return Math.Log(Y);
                case Power: return Math.Log(Y);
                case Inverse: return 1/Y;
                case Monod: return 1/Y;
                case Reciprocal: return 1/Y;
                default: return Y;
            }
        }

        public double Prediction(int i, string type)
        {
            int j = RegressionTypeIndex(type); 
            switch (type)
            {
                case Linear: return a[j] + b[j]*x[i];
                case Exponential: return a[j]*Math.Exp(b[j]*x[i]);
                case Power: return a[j]* Math.Pow(x[i], b[j]);
                case Inverse: return a[j]/(b[j]+x[i]);
                case Monod: return a[j]*x[i]/(b[j] + x[i]);
                case Reciprocal: return 1 / (a[j] + b[j] * x[i]);
                default: return 0;
            }
        }

        public void doStatistics(string type)
        {
            int j = RegressionTypeIndex(type);
            double sse = 0; ;
            double sumX = 0;
            double sumY = 0;
            for (int i = 0; i < n; i++)
            {
                sumX += x[i];
                sumY += yp[j,i];
                sse += Math.Pow(y[i] - yp[j, i], 2);
            }
            double mse = 0;
            if (n >2) mse = sse/(n-2);
            SSE[j] = sse;
            xAvg[j] = sumX / n;
            yAvg[j] = sumY / n;

            double ssr = 0;
            double sumA2 = 0;
            for (int i = 0; i < n; i++)
            {
                ssr += Math.Pow(yp[j, i] - yAvg[j], 2);
                sumA2 += Math.Pow(x[i] - xAvg[j], 2);
            }
            bVar[j] = mse / sumA2;
            aVar[j] = mse * (1 / n + xAvg[j] / sumA2);
            r2[j] = 1 - sse / (sse + ssr);
        }
        
        public void doPredictions(string type)
        {
            int j = RegressionTypeIndex(type);
            for (int i = 0; i < n; i++)
            {
                yp[j, i] = Prediction(i, type);
            }
        }

        public void doRegression(string type)
        {
            double a1 = 0; 
            double b1 = 0;
            double x1 = 0;
            double y1 = 0;
            double sumX = 0;
            double sumX2 = 0;
            double sumY = 0;
            double sumY2 = 0;
            double sumXY = 0;
            int j = RegressionTypeIndex(type);
            for (int i = 0; i < n; i++)
            {
                x1 = XTransform(x[i],type);
                y1 = YTransform(y[i],type);
                sumX += x1;
                sumX2 += Math.Pow(x1,2);
                sumY += y1;
                sumY2 += Math.Pow(y1, 2);
                sumXY += x1 * y1;
            }
            double d = n*sumX2 - Math.Pow(sumX,2);
            a1 = (sumY * sumX2 - sumXY * sumX) / d;
            b1 = (n * sumXY - sumX * sumY) / d;

            switch (type)
            {
                case Linear:
                    a[j] = a1;
                    b[j] = b1;
                    break;
                case Exponential:
                    a[j] = Math.Exp(a1);
                    b[j] = b1;
                    break;
                case Power:
                    a[j] = Math.Exp(a1);
                    b[j] = b1;
                    break;
                case Inverse:
                    a[j] = 1/b1;
                    b[j] = a1*a[j];
                    break;
                case Monod:
                    a[j] = 1/a1;
                    b[j] = a[j] * b1;
                    break;

                case Reciprocal:
                    a[j] =  a1;
                    b[j] =  b1;
                    break;

                default: 
                    a[j] = a1;
                    b[j] = b1;
                    break;
            }
        }

        public bool canCalculate(int j)
        {
            return canCalculate(RegressionTypes()[j]);
        }

        public bool canCalculate(string type)
        {
            int j = RegressionTypeIndex(type);
            if (doType[j] == false) return false;

            switch (type)
            {
                case Linear: return true;
                case Exponential:
                    for (int i = 0; i < n; i++) if (y[i] <= 0) return false;
                    break;
                case Power:
                    for (int i = 0; i < n; i++) if ((y[i] <= 0) || (x[i] <= 0)) return false;
                    break;
                case Inverse: 
                    for (int i = 0; i < n; i++) if (y[i] <= 0)  return false;
                    break;
                case Monod: 
                    for (int i = 0; i < n; i++) if ((y[i] <= 0) || (x[i] <= 0)) return false;
                    break;
                case Reciprocal:
                    for (int i = 0; i < n; i++) if (y[i] <= 0)  return false;
                    break;
                default: return true;
            }
            return true;
        }

        public int calculateStatistics()
        {
            return 1;

        }


#endregion

    }
}