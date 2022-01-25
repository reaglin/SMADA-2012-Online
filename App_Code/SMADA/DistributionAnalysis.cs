using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;
/*
 * Used with table to store distribution data
 * CREATE TABLE [dbo].[DistributionData](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[DescriptionText] [nvarchar](250) NULL,
	[DataText] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL)
 * 
CREATE PROCEDURE sp_InsertDistributionData (
 @DescriptionText NVARCHAR(250),
 @DataText NVARCHAR(MAX),
 @UserID INT )
AS
BEGIN

INSERT INTO DistributionData 
 (DescriptionText, DataText, UserID, CreatedDate)
VALUES
 (@DescriptionText, @DataText, @UserID, GETDATE())

RETURN @@IDENTITY
END
 *
ALTER PROCEDURE sp_UpdateDistributionData (
 @id INT,
 @DescriptionText NVARCHAR(250),
 @DataText NVARCHAR(MAX))
AS
BEGIN

UPDATE	DistributionData
SET		DescriptionText = @DescriptionText,
		DataText = @DataText
WHERE	id = @id 

END


 * */
namespace SMADA_2012.App_Code.SMADA
{
    public class DistributionAnalysis : SMADABase 
    {
        #region Properties

        public const string TableName = "DistributionData";

        public const string GEVDistribution = "GEV";
        public const string NormalDistribution = "Normal";
        public const string LogNormalDistribution = "Log Normal";
        public const string LogNormal3Distribution = "3P Log Normal";
        public const string PearsonDistribution = "Pearson";
        public const string LogPearsonDistribution = "Log Pearson";
        public const string GumbelDistribution = "Gumbel";

        public const int MAXDATA = 1000;

        public bool[] CalculatedDistributions = new bool[15];
        public double[,] Prediction = new double[15, MAXDATA];

        public int n;
        public double a;
        public double e;
        public double k;
        public double m1;
        public double m2;
        public double m3;
        public double skew;
        public double[] x = new double[MAXDATA];
        public double[] xp = new double[MAXDATA]; // Current predicted
        public double[] w = new double[MAXDATA]; // Weibull plotting position

        public string selectedDistribution;
        #endregion

        #region Constructors
        public DistributionAnalysis() : base("Distribution Data")
        {

        }

        public DistributionAnalysis(int n) : base("Distribution Data")
        {
        }

        public DistributionAnalysis(int num, double[] v): base("Distribution Data")
        {
            n = num;
            for (int i = 1; i <= num; i++) x[i] = v[i];
            Sort();
        }


        #endregion

        #region Support Calculations


        public int DistributionArrayIndex(string DType)
        {
            return Array.IndexOf(DistributionTypes(), DType);
        }

        public void prepareDataForAnalysis()
        {
            Sort();
            calculateMeans();
            calculatePlottingPosition();
        }

        public void Swap(double x1, double x2)
        {
            double x3 = x1;
            x1 = x2;
            x2 = x3;
        }

        public void Sort()
        {
            long right_border = n;

            do
            {
                long last_exchange = 0;

                for (long i = 0; i < right_border; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        double temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;

                        last_exchange = i;
                    }
                }

                right_border = last_exchange;
            }
            while (right_border > 0);
        }


        public bool calculateMeans()
        {

            double a = 0.0, b = 0.0, c = 0.0;
            double n1 = n;
            if (n == 0) return false;
            for (int i = 1; i <= n; i++)
            {
                a += x[i];
                b += Math.Pow(x[i], 2);
                c += Math.Pow(x[i], 3);
            }

            m1 = a / n1;
            m2 = (b / n1) - Math.Pow((a / n1), 2.0);
            m3 = (c / n1) + 2.0 * (Math.Pow(m1, 3.0)) - 3.0 * m1 * (b / n1);
            m2 = m2 * n1 / (n1 - 1);
            skew = m3 / (Math.Pow(m2, 1.5));
            return true;
        }

        public bool calculatePlottingPosition()
        {
            for (int i = 1; i <= n; i++)
            {
                w[i] = (double)i / ((double)n + 1.0);  // Uses Weibull
                // CALIFORNIA w[i] = i/n
                // FOSTER w[i] = (2*i - 1)/(2 *n)
                // EXCEEDENCE w[i] = (i - 1)/n
            }
            return true;
        }

        public double CFactor(int v1, double v2)
        {
            double n1, n2, n3;
            int v3 = (int)Math.Round(v2, 0);
            if (v2 > v1) return 0;
            if (v2 == v1) return 1;
            if (v2 == 1) return v1;

            n3 = 1.0;
            for (int i = v1 - v3 + 1; i <= v1; i++)
            {
                n3 = n3 * i;
            }

            n1 = Factorial(v3);
            return n3 / n1;
        }

        #endregion

        #region Distribution Calculations

        public bool calculateAll(ProbabilityData p)
        {
            // Set all calculated to false - calculates for all distribution types
            for (int i = 0; i <= CalculatedDistributions.Length - 1; i++) CalculatedDistributions[i] = false;

            foreach (string dtype in DistributionTypes())
            {
                int index = DistributionArrayIndex(dtype);
                if (dtype == NormalDistribution)
                {
                    CalculatedDistributions[index] = calculateNormal(p);
                }
                if (dtype == GEVDistribution)
                {
                    CalculatedDistributions[index] = calculateGEV(p);
                }

                if (dtype == LogNormalDistribution)
                {
                    CalculatedDistributions[index] = calculateLogNormal(p);
                }
                if (dtype == LogNormal3Distribution)
                {
                    CalculatedDistributions[index] = calculateLogNormal3(p);
                }

                if (dtype == GumbelDistribution)
                {
                    CalculatedDistributions[index] = calculateGumbel(p);
                }
                if (dtype == LogPearsonDistribution)
                {
                    CalculatedDistributions[index] = calculateLogPearson(p);
                }
            }
            return true;
        }

        public bool calculate(string chosenD, ProbabilityData p)
        {
            for (int i = 0; i <= CalculatedDistributions.Length - 1; i++) CalculatedDistributions[i] = false;

            selectedDistribution = chosenD;
            if (chosenD == NormalDistribution)
            {
                return calculateNormal(p);
            }
            if (chosenD == GEVDistribution)
            {
                return calculateGEV(p);
            }

            if (chosenD == LogNormalDistribution)
            {
                return calculateLogNormal(p);
            }
            if (chosenD == LogNormal3Distribution)
            {
                return calculateLogNormal3(p);
            }

            if (chosenD == GumbelDistribution)
            {
                return calculateGumbel(p);
            }
            if (chosenD == LogPearsonDistribution)
            {
                return calculateLogPearson(p);
            }
            return false;
        }

        // All distributions calculate a predicted value
        public bool calculateGEV(ProbabilityData p)
        {
            prepareDataForAnalysis();

            double a1 = 0.0, a2 = 0.0, a3 = 0, a4 = 0;
            double c1, c2, c3, c4;
            double cl1, cl2, cl3;
            double cr1, cr2, cr3;
            double t1, t2, t3, t4;
            double c, g, f;

            for (int i = 1; i <= n; i++)
            {
                cl1 = i - 1;
                cl2 = cl1 * (i - 1 - 1) / 2;
                cl3 = cl2 * (i - 1 - 2) / 3;

                cr1 = n - i;
                cr2 = cr1 * (n - i - 1) / 2;
                cr3 = cr2 * (n - i - 2) / 3;

                a1 = a1 + x[i];
                a2 = a2 + x[i] * (cl1 - cr1);
                a3 = a3 + x[i] * (cl2 - 2 * cl1 * cr1 + cr2);
                a4 = a4 + x[i] * (cl3 - 3 * cl2 * cr1 + 3 * cl1 * cr2 - cr3);
            }
            c1 = n;
            c2 = c1 * (n - 1) / 2.0;
            c3 = c2 * (n - 2) / 3.0;
            c4 = c3 * (n - 3) / 4.0;
            a1 = a1 / c1;
            a2 = a2 / c2 / 2;
            a3 = a3 / c3 / 3;
            a4 = a4 / c4 / 4;

            //  find tau factors
            t1 = a2 / a1;
            t2 = a2 / a1;
            t3 = a3 / a2;
            t4 = a4 / a2;
            c = (2 / (3 + t3)) - (Math.Log(2) / Math.Log(3));
            k = 7.859 * c + 2.9554 * Math.Pow(c, 2); // property

            g = DistributionAnalysis.Gamma(k + 1);
            a = a2 * k / ((1 - (Math.Pow(2, -1 * k))) * g); // property
            e = a1 / a - (1 - g) / k;

            // Fills in probability array with values
            for (int i = 1; (i <= p.n); i++)
            {
                f = -Math.Log(p.p[i]);
                if ((k == 0))
                {
                    p.v[i] = a * (e - Math.Log(f));
                }
                else
                {
                    p.v[i] = a * (e + (1 - Math.Pow(f, k)) / k);
                }
            }

            // Fills in distribution array with predictions
            int d_index = DistributionArrayIndex(GEVDistribution);
            for (int i = 1; (i <= n); i++)
            {
                f = -Math.Log(w[i]);
                if ((k == 0))
                {
                    xp[i] = a * (e - Math.Log(f));
                }
                else
                {
                    xp[i] = a * (e + (1 - Math.Pow(f, k)) / k);
                }
                Prediction[d_index, i] = xp[i];
            }
            return true;
        }

        public bool calculateNormal(ProbabilityData p)
        {
            prepareDataForAnalysis();
            double k = Math.Sqrt(m2);

            // Fills in the ProbabilityData matrix
            for (int i = 1; i <= p.n; i++)
            {
                double t = DistributionAnalysis.ZStatistic(p.p[i]);
                p.v[i] = m1 + k * t;
            }
            int d_index = DistributionArrayIndex(NormalDistribution);

            // Fills in the weibull matrix
            for (int i = 1; i <= n; i++)
            {
                double t = DistributionAnalysis.ZStatistic(w[i]);
                xp[i] = m1 + k * t;
                Prediction[d_index, i] = xp[i];
            }
            return true;
        }

        public bool calculateLogNormal(ProbabilityData p)
        {
            prepareDataForAnalysis();

            double z1 = Math.Pow(m2, 0.5) / m1;
            double a = Math.Log(1 + Math.Pow(z1, 2));

            // Fill ProbabilityData Matrix 
            for (int i = 1; i <= p.n; i++)
            {
                double t = DistributionAnalysis.ZStatistic(p.p[i]);
                double k = (Math.Exp(Math.Sqrt(a) * t - a / 2) - 1) / z1;
                p.v[i] = m1 + k * Math.Sqrt(m2);
            }

            int d_index = DistributionArrayIndex(LogNormalDistribution);
            for (int i = 1; i <= n; i++)
            {
                double t = DistributionAnalysis.ZStatistic(w[i]);
                double k = (Math.Exp(Math.Sqrt(a) * t - a / 2) - 1) / z1;
                xp[i] = m1 + k * Math.Sqrt(m2);
                Prediction[d_index, i] = xp[i];
            }

            return true;
        }

        public bool calculateLogNormal3(ProbabilityData p)
        {
            prepareDataForAnalysis();

            double[] e = new double[13];
            double[] dv = new double[7];

            double dn = n;
            double lw = (-skew + Math.Sqrt((skew * skew) + 4.0)) / 2.0;
            double z2 = (1 - Math.Pow(lw, 0.66667)) / Math.Pow(lw, 0.333333);
            double amo = m1 - Math.Sqrt(m2) / z2;
            double sy = Math.Sqrt(Math.Log((z2 * z2) + 1.0));
            double sy2 = sy * sy;

            double my = Math.Log(Math.Sqrt(m2) / z2) - 0.5 * Math.Log((z2 * z2) + 1.0);
            e[0] = Math.Exp(sy2);
            e[1] = Math.Exp(2.0 * sy2);
            e[2] = Math.Exp(2.5 * sy2);
            e[3] = Math.Exp(3.0 * sy2);
            e[4] = Math.Exp(4.0 * sy2);
            e[5] = Math.Exp(6.0 * sy2);
            e[6] = Math.Exp(10.0 * sy2);
            e[7] = Math.Exp(15.0 * sy2);
            e[8] = Math.Exp(4.0 * my);
            e[9] = Math.Exp(5.0 * my);
            e[10] = Math.Exp(6.0 * my);
            e[11] = Math.Pow((Math.Exp(sy2) - 1.0), 2);

            double m4 = e[1] * e[8] * e[11] * (e[4] + 2.0 * e[3] + 3.0 * e[1] - 3.0);
            double m5 = e[2] * e[9] * (e[6] - 5.0 * e[5] + 10.0 * e[3] - 10.0 * e[0] + 4.0);
            double m6 = e[3] * e[10] * (e[7] - 6.0 * e[6] + 15.0 * e[5] - 20.0 * e[3] + 15.0 * e[0] - 5.0);

            double vm1 = m2 / dn;
            double vm2 = (m4 - (m2 * m2)) / dn;
            double vm3 = (m6 - (m3 * m3) - 6 * m4 * m2 + 9 * (m2 * m2 * m2)) / dn;

            double cm1m2 = m3 / dn;
            double cm1m3 = (m4 - 3 * m2 * m2) / dn;
            double cm2m3 = (m5 - 4 * m3 * m2) / dn;

            for (int i = 1; i <= p.n; i++)
            {
                double t = DistributionAnalysis.ZStatistic(p.p[i]);
                double dwdg = -0.5 + skew / (2.0 * Math.Sqrt(skew * skew + 4.0));
                double dz2dw = (-0.333333) * (Math.Pow(lw, -1.333333) + Math.Pow(lw, -0.66666667));
                dv[1] = Math.Log((z2 * z2) + 1.0);
                dv[2] = Math.Exp((Math.Sqrt(dv[1]) * t - dv[1] / 2.0));
                dv[3] = (2.0 * z2) / (1.0 + z2 * z2);
                dv[4] = t / (2.0 * z2 * Math.Sqrt(dv[1]));
                dv[5] = 1.0 / z2;
                dv[6] = 1.0 / (2.0 * Math.Pow(z2, 3.0));

                double dkdz2 = dv[3] * (dv[2] * (dv[4] - dv[5] - dv[6]) + dv[6] + dv[5] / 2.0);
                double k = (dv[2] - 1.0) / z2;
                double dkdg = dkdz2 * dz2dw * dwdg;
                double dxdm2 = (1.0 / (2.0 * Math.Sqrt(m2))) * (k - 3.0 * skew * dkdg);
                double dxdm3 = dkdg / m2;

                p.v[i] = m1 + k * Math.Sqrt(m2);
            }

            int d_index = DistributionArrayIndex(LogNormal3Distribution);
            for (int i = 1; i <= n; i++)
            {
                double t = DistributionAnalysis.ZStatistic(w[i]);
                double dwdg = -0.5 + skew / (2.0 * skew * Math.Sqrt(skew * skew + 4.0));
                double dz2dw = (-0.33333) * (Math.Pow(lw, -1.333333) + Math.Pow(lw, -0.66666667));
                dv[1] = Math.Log(z2 * z2 + 1.0);
                dv[2] = Math.Exp((Math.Sqrt(dv[1]) * t - dv[1] / 2.0));
                dv[3] = (2.0 * z2) / (1.0 + z2 * z2);
                dv[4] = t / (2.0 * z2 * Math.Sqrt(dv[1]));
                dv[5] = 1.0 / z2;
                dv[6] = 1.0 / (2.0 * Math.Pow(z2, 3.0));

                double dkdz2 = dv[3] * (dv[2] * (dv[4] - dv[5] - dv[6]) + dv[6] + dv[5] / 2.0);
                double k = (dv[2] - 1.0) / z2;
                double dkdg = dkdz2 * dz2dw * dwdg;
                double dxdm2 = (1.0 / (2.0 * Math.Sqrt(m2))) * (k - 3.0 * skew * dkdg);
                double dxdm3 = dkdg / m2;

                xp[i] = m1 + k * Math.Sqrt(m2);
                Prediction[d_index, i] = xp[i];
            }
            return true;
        }

        public bool calculateGumbel(ProbabilityData p)
        {
            prepareDataForAnalysis();

            double alpha = 1.2825 / Math.Sqrt(m2);
            double beta = m1 - 0.45 * Math.Sqrt(m2);

            double a = 0.0;
            double b = 0.0;
            double dn = n;

            for (int i = 1; i <= n; i++)
            {
                double yd = -Math.Log(-Math.Log((dn + 1.0 - (double)i) / (dn + 1.0)));
                a += yd;
                b += Math.Pow(yd, 2);
            }

            double ybar = a / n;
            double ystd = (b / n - Math.Pow(ybar, 2));

            // Fill in ProbabilityData values
            for (int i = 1; i <= p.n; i++)
            {
                double t = 1 / (1 - p.p[i]);
                double ym = -Math.Log(-Math.Log((t - 1) / t));
                double k = (ym - ybar) / ystd;

                p.v[i] = m1 + k * Math.Sqrt(m2);
            }

            // Fill in Weibull values
            int d_index = DistributionArrayIndex(GumbelDistribution);
            for (int i = 1; i <= n; i++)
            {
                double t = 1 / (1 - w[i]);
                double ym = -Math.Log(-Math.Log((t - 1) / t));
                double k = (ym - ybar) / ystd;

                xp[i] = m1 + k * Math.Sqrt(m2);
                Prediction[d_index, i] = xp[i];
            }
            return true;
        }

        public bool calculateLogPearson(ProbabilityData p)
        {
            prepareDataForAnalysis();

            if (calculateLogPearsonMMD(p))
                return true;
            else
                return calculateLogPearsonMMI(p);
        }

        public bool calculateLogPearsonMMI(ProbabilityData p)
        {

            double dn = n;
            double c1;
            if (n < 100)
                c1 = Math.Sqrt(dn * (dn - 1.0)) / (dn - 2.0);
            else
                c1 = 1.0;

            double c2 = 1.0 + 8.5 / dn;
            double c3 = dn / (dn - 1);
            double[] lx = new double[n + 1];
            for (int i = 1; i <= n; i++)
            {
                if (x[i] > 0) lx[i] = Math.Log(x[i]); else return false;
            }

            DistributionAnalysis ld = new DistributionAnalysis(n, lx);
            ld.calculateMeans();

            double lskew = ld.skew * c1 * c2;
            double lm1 = ld.m1;
            double lm2 = ld.m2 * c3 * dn / (dn - 1.0);

            int d_index = DistributionArrayIndex(LogPearsonDistribution);
            for (int i = 1; i <= n; i++)
            {
                xp[i] = Math.Exp(DistributionAnalysis.TCaculation(lm1, lm2, lskew, w[i]));
                Prediction[d_index, i] = xp[i];
            }


            for (int i = 1; i <= p.n; i++)
            {
                p.v[i] = Math.Exp(DistributionAnalysis.TCaculation(lm1, lm2, lskew, p.p[i]));
            }

            return true;
        }

        public bool calculateLogPearsonMMD(ProbabilityData p)
        {
            // Uses method of moments direct 
            double dn = n;
            double c1;
            if (n < 100)
                c1 = Math.Sqrt(dn * (dn - 1.0)) / (dn - 2.0);
            else
                c1 = 1.0;

            double c2 = 1.0 + 8.5 / dn;
            double c3 = dn / (dn - 1);
            double[] ldx = new double[n + 1];

            for (int i = 1; i <= n; i++)
            {
                if (x[i] > 0)
                    ldx[i] = Math.Log(x[i]);
                else
                    return false;
            }

            double a = 0, b = 0, c = 0;
            for (int i = 1; i <= n; i++)
            {
                a += x[i];
                b += Math.Pow(x[i], 2);
                c += Math.Pow(x[i], 3);
            }

            double l1 = a / dn;
            double l2 = b / dn;
            double l3 = c / dn;
            b = (Math.Log(l3) - 3.0 * Math.Log(l1)) / (Math.Log(l2) - 2.0 * Math.Log(l1));
            c = 1.0 / (b - 3.0);
            if ((b > 3) && (b < 6))
            {
                if (b <= 3.5)
                    a = -.47175 + 1.99955 * c;
                else
                    a = -0.23019 + 1.65262 * c + 0.20911 * c * c - 0.04557 * c * c * c;

                double alpha = 1.0 / (a + 3.0);
                double a1 = Math.Log(1.0 - alpha);
                double a2 = Math.Log(1.0 - 2.0 * alpha);
                double beta = (Math.Log(l2) - 2.0 * Math.Log(l1)) / (2.0 * a1 - a2);
                double gamma = Math.Log(l1) + beta * a1;
                double lpm1 = gamma + alpha * beta;
                double lpm2 = beta * alpha * alpha;
                double lpskew = 2.0 / Math.Sqrt(beta);

                if (lpskew <= 0) return false;

                // Fill in Weibull values
                int d_index = DistributionArrayIndex(LogPearsonDistribution);
                for (int i = 1; i <= n; i++)
                {
                    xp[i] = Math.Exp(DistributionAnalysis.TCaculation(m1, m2, skew, w[i]));
                    Prediction[d_index, i] = xp[i];
                }

                // Fill in ProbabilityData values
                for (int i = 1; i <= p.n; i++)
                {
                    p.v[i] = Math.Exp(DistributionAnalysis.TCaculation(m1, m2, skew, p.p[i]));
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region output Routines
        public DataTable asDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Weibull"));
            dt.Columns.Add(new DataColumn("Data"));
            // Add a column for each calculated type
            for (int i = 0; i <= DistributionTypes().Length - 1; i++)
            {
                if (CalculatedDistributions[i]) dt.Columns.Add(new DataColumn(DistributionTypes()[i]));
            }

            for (int i = 1; i <= n; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Weibull"] = String.Format("{0:0.000}", w[i]);
                dr["Data"] = String.Format("{0:0.000}", x[i]);
                for (int j = 0; j <= DistributionTypes().Length - 1; j++)
                {
                    if (CalculatedDistributions[j])
                    {
                        dr[DistributionTypes()[j]] = String.Format("{0:0.000}", Prediction[j, i]);
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
        #endregion

        #region Static Methods
        public static string[] DistributionTypes()
        {
            return new string[] { NormalDistribution, LogNormalDistribution, LogNormal3Distribution, GEVDistribution, GumbelDistribution, LogPearsonDistribution };
        }

        public static SortedList typesAsSortedList()
        {
            string[] choices = DistributionTypes();

            IDictionary list = new SortedList();

            foreach (String c in choices)
            {
                list.Add(c, c);
            }

            return (SortedList)list;
        }

        public static double max(int n, double[] x)
        {
            double maxX = -1e-17;
            for (int i = 1; i < n; i++)
            {
                if (x[i] > maxX) maxX = x[i];
            }
            return maxX;
        }

        public static double min(int n, double[] x)
        {
            double minX = max(n, x);
            for (int i = 1; i <= n; i++)
            {
                if (x[i] < minX) minX = x[i];
            }
            return minX;
        }

        public static double Factorial(int v)
        {
            if (v == 0) return 1;
            if (v == 1) return 1;

            double f = 1;
            for (int j = v; j >= 1; j--)
            {
                f = f * j;
            }
            return f;
        }

        public static double ZStatistic(double probability)
        {
            double e = 2.515517;
            double c1 = 0.802835;
            double c2 = 0.010328;
            double d1 = 1.432788;
            double d2 = 0.189269;
            double d3 = 0.001308;
            double d = probability;

            if (d > 0.5) d = 1.0 - d;
            if (d < 0.0001) d = 0.0001;

            double w = Math.Sqrt(Math.Log(1.0 / Math.Pow(d, 2)));
            double t = w - (e + c1 * w + c2 * Math.Pow(w, 2)) / (1.0 + d1 * w + d2 * Math.Pow(w, 2) + d3 * Math.Pow(w, 3));
            if (probability < 0.5) t = -t;

            return t;
        }

        public static double ZStatistic(int i, int n)
        {
            double pr = 1.0 - (double)i / ((double)n + 1);
            return ZStatistic(pr);
        }

        public static double LogGamma(double v)
        {
            double[] cof = new double[7];
            cof[1] = 76.1800917294715;
            cof[2] = -86.5053203294168;
            cof[3] = 24.0140982408309;
            cof[4] = -1.23173957245016;
            cof[5] = 1.20865097386618E-03;
            cof[6] = -5.395239384953E-06;

            double Y = v;
            double X = v;
            double tmp = X + 5.5;
            tmp = tmp - (X + 0.5) * Math.Log(tmp);
            double ser = 1.00000000019002;

            for (int j = 1; j <= 6; j++)
            {
                Y = Y + 1;
                ser = ser + cof[j] / Y;
            }

            return -tmp + Math.Log(2.506628274631 * ser / X);
        }

        public static double TCaculation(double m1, double m2, double skew, double p)
        {

            double t = ZStatistic(p);
            double t1 = t;
            double t2 = (t * t - 1.0) / 6.0;
            double t3 = 2.0 * (t * t * t - 6.0 * t) / Math.Pow(6.0, 3.0);
            double t4 = (t * t - 1.0) / Math.Pow(6.0, 3.0);
            double t5 = t / Math.Pow(6.0, 5.0);
            double t6 = 2 / Math.Pow(6.0, 6.0);

            double k = t1 + t2 * skew + t3 * Math.Pow(skew, 2) - t4 * Math.Pow(skew, 3) + t5 * Math.Pow(skew, 4) - t6 * Math.Pow(skew, 5);
            double slope = t2 + 2.0 * t3 * skew - 3.0 * t4 * Math.Pow(skew, 2) + 4.0 * t5 * Math.Pow(skew, 3) - 5.0 * t6 * Math.Pow(skew, 4);

            double t7 = 1.0;
            double t8 = k * skew;
            double t9 = (1.0 + 0.75 * skew * skew) * (k * k / 2.0);
            double t10 = 3.0 * slope * k * (skew + 0.25 * Math.Pow(skew, 3));
            double t11 = 3 * Math.Pow(slope, 2) * (2.0 + 3.0 * skew * skew + (5.0 / 8.0) * Math.Pow(skew, 4));
            double delta = t7 + t8 + t9 + t10 + t11;

            return m1 + k * Math.Sqrt(m2);
        }

        public static double Gamma(double v)
        {
            if (v <= 0) return 0;
            double v2 = LogGamma(v);
            return Math.Exp(v2);
        }
        #endregion

    }

    public class ProbabilityData
    {
        public const int MAXDATA = 50;

        public int n;
        public double[] p = new double[MAXDATA]; // Probability
        public double[] v = new double[MAXDATA]; // Predicted Value at Probability

        #region Constructors
        public ProbabilityData()
        {
            n = 9;
            p[1] = 0.998;
            p[2] = 0.995;
            p[3] = 0.99;
            p[4] = 0.98;
            p[5] = 0.96;
            p[6] = 0.9;
            p[7] = 0.8;
            p[8] = 0.666667;
            p[9] = 0.5;
        }

        #endregion

        public DataTable asDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Probability"));
            dt.Columns.Add(new DataColumn("RP"));
            dt.Columns.Add(new DataColumn("Prediction"));

            for (int i = 1; i <= n; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Probability"] = String.Format("{0:0.000}", p[i]);
                dr["RP"] = String.Format("{0:0}", 1 / (1 - p[i]));
                dr["Prediction"] = String.Format("{0:0.000}", v[i]);
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public DataTable newDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Probability"));
            dt.Columns.Add(new DataColumn("RP"));

            for (int i = 1; i <= n; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Probability"] = String.Format("{0:0.000}", p[i]);
                dr["RP"] = String.Format("{0:0}", 1 / (1 - p[i]));

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable addPredictions(DataTable dt, string Header)
        {
            dt.Columns.Add(new DataColumn(Header));
            for (int i = 1; i <= n; i++)
            {
                dt.Rows[i - 1][Header] = String.Format("{0:0.000}", v[i]);
            }
            return dt;
        }
    }
}
