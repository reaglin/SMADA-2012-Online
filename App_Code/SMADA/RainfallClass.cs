using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sage;
using System.Data;
using System.ComponentModel;
using DBF = sage.DatabaseField;


//  #Eaglin  - convert rainfall and rainfall steps.
namespace SMADA_2012.App_Code.SMADA
{
    public enum RainfallType
    {
        [Description("User Defined")]
        UserDefined,
        [Description("SCS Type I")]
        SCSTypeI,
        [Description("SCS Type II")]
        SCSTypeII,
        [Description("SCS Type IIA")]
        SCSTypeIIA,
        [Description("Dimensionless")]
        Dimensionless
    }
    public class Rainfall: DatabaseTable 
    {
        #region Properties
        public const int MAXRAINFALL = 2000;

        public DBF id = new DBF("Rainfall", "id", DBF.typeInt);
        public DBF Title = new DBF("Rainfall", "Title", DBF.typeString);
        public DBF Description = new DBF("Rainfall", "Description", DBF.typeString);
        public DBF Type = new DBF("Rainfall", "Type", DBF.typeString);
        public DBF DimensionlessID = new DBF("Rainfall", "DimensionlessID", DBF.typeInt);
        public DBF TimeStep = new DBF("Rainfall", "TimeStep", DBF.typeInt);
        public DBF NumberOfSteps = new DBF("Rainfall", "NumberOfSteps", DBF.typeInt);
        public DBF StartTime = new DBF("Rainfall", "StartTime", DBF.typeDateString);
        public DBF EndTime = new DBF("Rainfall", "EndTime", DBF.typeDateString);
        public DBF Duration = new DBF("Rainfall", "Duration", DBF.typeDouble);
        public DBF Total = new DBF("Rainfall", "Total", DBF.typeDouble);
        public DBF UserID = new DBF("Rainfall", "UserID", DBF.typeInt);
        public DBF CreatedDate = new DBF("Rainfall", "CreatedDate", DBF.typeDateString);
        public DBF IsDimensionless = new DBF("Rainfall", "IsDimensionless", DBF.typeBool);

        RainfallStep[] rainfall = new RainfallStep[MAXRAINFALL];        // Array of all rainfall

        // By default accessing the object as an array will return the depth
       // public double this[int index]
        //{  get { return rainfall[index].Depth.asDouble() ;} }

        #endregion

        #region Constructors
        public Rainfall()
        {
            setup();
        }

        public Rainfall(string RainfallID)
        {
            if (RainfallID != String.Empty) id.Value = RainfallID;
            setup();
        }

        public Rainfall(int RainfallID)
        {
            if (RainfallID != 0) id.Value = Convert.ToString(RainfallID);
            setup();
        }

        public int rainfallID()
        {
            return id.asInteger();
        }

        public void setup()
        {
            TableName = "Rainfall";
            PrimaryKey = "id";

            setupRainfallSteps();
            
            // rainfall is the array of all values
            setupColumns();

            if (id.asInteger() != 0)
            {
                Select(id.asInteger());
                calculate();
                //setupRainfallSteps();
            }
        }

        public void setupRainfallSteps()
        {
            int ns = numberOfSteps();
            int rid = id.asInteger();
            for (int i = 0; i <= ns ; i++)
            {
                rainfall[i] = new RainfallStep(rid);
            }
        }

        public Dictionary<string, DatabaseField> setupColumns()
        {
            Fields.Clear();
            Fields.Add(id.fieldNameText, id);
            Fields.Add(Title.fieldNameText, Title);
            Fields.Add(Description.fieldNameText, Description);
            Fields.Add(Type.fieldNameText, Type);
            Fields.Add(DimensionlessID.fieldNameText, DimensionlessID);
            Fields.Add(TimeStep.fieldNameText, TimeStep);
            Fields.Add(NumberOfSteps.fieldNameText, NumberOfSteps);
            Fields.Add(StartTime.fieldNameText, StartTime);
            Fields.Add(EndTime.fieldNameText, EndTime);
            Fields.Add(Duration.fieldNameText, Duration);
            Fields.Add(Total.fieldNameText, Total);
            Fields.Add(UserID.fieldNameText, UserID);
            Fields.Add(CreatedDate.fieldNameText, CreatedDate);
            Fields.Add(IsDimensionless.fieldNameText, IsDimensionless);	
            return Fields;
        }
        public RainfallType rainfallType()
        {
            if (Type.Value == "SCS Type I") return RainfallType.SCSTypeI;
            if (Type.Value == "SCS Type II") return RainfallType.SCSTypeII;
            if (Type.Value == "SCS Type IIA") return RainfallType.SCSTypeIIA;

            return RainfallType.UserDefined;
        }

        public int numberOfSteps()
        {
            return NumberOfSteps.asInteger();
        }

        public void setNumberOfSteps(int n)
        {
            NumberOfSteps.setValue(n);
        }

        public bool isDimensionless()
        {
            try
            {
                return Convert.ToBoolean(IsDimensionless.Value);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Calculations

        public string Validate()
        {
            return String.Empty;
        }
        public void calculate()
        {
        }


        public int calculateNumberOfSteps()
        {
           // Based on rules - need to calculate the number of steps
            double d = Duration.asDouble();
            double ts = TimeStep.asDouble();
            int ns = NumberOfSteps.asInteger();

            // if duration and time step exist - calculate number of steps
            if (((d != 0) && (ts != 0)) && (ns == 0))
            {
                ns = (int)Math.Floor(d / (ts / 60.0));
                NumberOfSteps.setValue(ns);
                return ns;
            }

            // if duration and number of steps exist - calculatte time step
            if ((d != 0) && (ns != 0)&&(ts == 0))
            {
                ts = Math.Round(60.0 * d / ns,2);
                TimeStep.setValue(ts);
                return ns;
            }

            // if time step and number of steps exist - caculate duration 
            if ((ts != 0) && (ns != 0) && (d == 0))
            {
                d = calculateDuration(ts, ns);
                Duration.setValue(d);
                return ns;
            }

            return 0;
        }

        public static double calculateDuration(double timeStep, int numberOfSteps)
        {
            return Math.Round(timeStep * numberOfSteps / 60.0, 2);
        }

        public static int calculateNumberOfSteps(double timeStep, double duration)
        {
            if (timeStep == 0)
                return 0;
            else
                return (int)Math.Floor(duration / (timeStep / 60.0));
        }

        public double calculateTotalRainfall()
        {

            int ns = NumberOfSteps.asInteger();
            double x = 0;
            for (int i = 1; i <= ns; i++) 
            { 
                x = x + depth(i);
                if (i == 1) setTime(1, 0.0);
                if (i > 1) setTime(i, depth(i - 1) + TimeStep.asDouble()); 
            }
            Total.setValue(x);
            return x;
        }

#endregion

#region Dimensionless Rainfall

        public void makeDimensionless()
        {
            double x1 = 0;
            double x2 = 0;

            int ns = NumberOfSteps.asInteger();
            double dur = Duration.asDouble();
            // Creates a dimensionless rainfall both rain and time
            // must go from 0 to 1
            //Rainfall dr = new Rainfall();

            if (ns == 0) return;
            if (dur == 0) return;

            // Total rainfall values
            x1 = calculateTotalRainfall();

            // Create dimensionless rainfall from them
            x2 = 0;

            for (int i = 0; i <= ns; i++)
            {
                x2 = x2 + depth(i);
                setTime(i, (double)i / ns * dur);
                setDepth(i, (double)x2 / x1);
            }
        }

        public double[] convertIncrementalToCumulative(int n,double[] ir)
        {
            double[] cr = new double[MAXRAINFALL];
            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                    cr[i] = ir[i];
                else
                    cr[i] = cr[i-1] +  ir[i];
            }

            return cr;
        }

        public double calculateDimensionlessRainfallDepth(double t)
        {
            // t is dimnsionless time

            double x1 = 0;
            double x2 = 0;

            // Given dimensionless time t (0-1) and dimensionless Rainfall dr
            // this function will answer the cumulative rainfall
            // at time t (t is dimensionless). To do this the function may
            // need to interpolate between two values in the
            // dimensionless rainfall.

            // We may need to check to see if a rainfall is dimensionless
            // and convert to dimensionless if not.

            if (t >= 1) return 1.0;

            int i = 1;
            do
            {
                if (t == time(i)) return depth(i);

                if (time(i) > t)
                    break; // TODO: might not be correct. Was : Exit Do

                i = i + 1;

            } while (i < MAXRAINFALL);

            // interpolate between increments
            if (time(i) != time(i - 1))
                x1 = (depth(i) - depth(i - 1)) / (time(i) - time(i - 1));
            else
                x1 = 0;

            x2 = (t - time(i - 1)) * x1;
            return (double)depth(i - 1) + x2;
        }

        public string dimensionlessValuesAsString()
        {
            // Answers a string, values separated by new line character
            string s = string.Empty;
            for (int i = 1; i <= numberOfSteps(); i++)
            {
                s += Convert.ToString(depth(i));
                if (i != numberOfSteps()) s += Environment.NewLine.ToString();
            }
            return s;
        }

        public void importDimensionlessIncrementalValuesFromString(string s)
        {
            string[] vals = s.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int i = 1;
            double[] d = new double[MAXRAINFALL]; 
            foreach (string val in vals)
            {
                d[i] = Convert.ToDouble(val);
                i++;
            }
            int n = i - 1;

            double[] e = convertIncrementalToCumulative(n, d);
            importDimensionlessCumulativeValues(n, e);
        }

        public void importDimensionlessCumulativeValuesFromString(string s)
        {
            // Imports numbers for dimensionless rainfall separated by line break
            // Rainfall is cumulative values going from 0 - 1

            IsDimensionless.Value = Convert.ToString(true); 
            string[] vals = s.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            // This works if values are cumulative
            int i = 1;
            double[] d = new double[MAXRAINFALL];

            foreach(string val in vals)
            {
                d[i] = Convert.ToDouble(val);
                i++;
            }
            int n = i-1;
            importDimensionlessCumulativeValues(n, d);
        }

        public void importDimensionlessCumulativeValues(int n, double[] d)
        {
            double max = 0.0;
            for (int i = 1; i <= n; i++)
            {
                // values must increase in cumulative
                if (i == 1)
                {
                    setDepth(i, d[i]);
                }
                else
                {
                    if (d[i] >= d[i - 1])
                        setDepth(i, d[i]);
                    else
                        setDepth(i, d[i - 1]);
                }

                max = Math.Max(max, d[i]);
            }

            setNumberOfSteps(n);
            if (max == 0) return;
            for (int i = 1; i <= n; i++)
            {
                setDepth(i, depth(i) / max);
                setTime(i, (double)i / (double)n);
            }
        }

        public Rainfall createFromDimensionlessRainfall()
        {
            // Should only be called if this already designates a dimensionless rainfall

            if (DimensionlessID.asInteger() == 0) return this;
            
            // Create a new dimensionless rainfall to use in generation
            Rainfall dr = new Rainfall(DimensionlessID.asInteger());

            // If rainfall specified is not a dimensionless rainfall cannot calculate
            if (!dr.isDimensionless()) return this;

            // Current rainfall to generate must have a total number of steps
            if (numberOfSteps() == 0) calculateNumberOfSteps();
            if (numberOfSteps() == 0) return this;

            return createFromDimensionlessRainfall(dr);
    }

        public Rainfall createFromDimensionlessRainfall(Rainfall dr)
        {

            // Passes a dimesionless rainfall to the rainfall to current to create values
            // create the actual rainfall

            double x1 = 0;
            double x2 = 0;

            // Current rainfall must have a Total, Duration, and Time Step 
            if (Total.asDouble() == 0) return this;
            if (Duration.asDouble() == 0) return this;
            if (TimeStep.asDouble() == 0) return this;

            // Total is input
            double tot = Total.asDouble();
            double dur = Duration.asDouble();
            if (numberOfSteps() == 0) calculateNumberOfSteps();
            int ns = numberOfSteps();

            setDepth(0, 0.0);

            x1 = 0.0;
            for (int i = 1; i <= numberOfSteps(); i++)
            {
                double dt = (double)i / (double)ns; // dimensionless time
                x2 = dr.calculateDimensionlessRainfallDepth(dt);
                setTime(i, Math.Round(dt * dur, 2));
                setDepth(i, Math.Round(tot * (x2 - x1),2));

                x1 = x2;
            }
            return this;
        }

#endregion

#region Rainfall Values

        public double time(int i)
        {
            try
            {
                return rainfall[i].Time;
            }
            catch
            {
                setTime(i, (numberOfSteps() == 0?0:i/numberOfSteps()));
                return rainfall[i].Time;
            }
        }
        public double depth(int i)
        {
            try
            {
                return rainfall[i].Depth;
            }
            catch
            {
                setDepth(i, 0);
                return rainfall[i].Depth;
            }

        }
        public void setTime(int i, double t)
        {
            int rid = rainfallID();
            if (rainfall[i] == null) rainfall[i] = new RainfallStep(rid, i);
            rainfall[i].Time = t;
        }

        public void setDepth(int i, double d)
        {
            int rid = rainfallID();
            if (rainfall[i] == null) rainfall[i] = new RainfallStep(rid, i);
            rainfall[i].Depth = d;
        }

        public void setZorder(int i, int j)
        {
            int rid = rainfallID();
            if (rainfall[i] == null) rainfall[i] = new RainfallStep(rid, i);
            rainfall[i].Zorder = j;
        }

        public RainfallStep newRainfallStep()
        {
            int rid = rainfallID();
            RainfallStep rs = new RainfallStep(rid);
            return rs;
        }

        public double[] values()
        {
            double[] d = new double[MAXRAINFALL];
            for (int i = 1; i <= numberOfSteps(); i++)
            {
                d[i - 1] = rainfall[i].Depth; 
            }
            return d;
        }

        public object[,] valuesAsObject()
        {
            object[,] d = new object[1,MAXRAINFALL];
            for (int i = 1; i <= numberOfSteps(); i++)
            {
                d[0,i - 1] = rainfall[i].Time;
                d[1,i - 1] = rainfall[i].Depth;
            }
            return d;
        }

#endregion
        
#region Database

        new public int Update()
        {
            int n = base.Update();
            UpdateRainfallValues();
            return n;
        }

        public void UpdateRainfallValues()
        {
            // Delete Old values
            if (PrimaryKeyValue() != 0)
            {
                deleteRainfallValues(PrimaryKeyValue());
            }

            // Save new values
            for (int i = 1; i <= numberOfSteps(); i++)
            {
                setZorder(i, i);
                rainfall[i].RainfallID = Convert.ToInt32(id.Value);
                rainfall[i].Insert(); 
            }
        }

        public void Select()
        {
            Select(id.asInteger());
        }

        public override void Select(int pk)
        {
            id.Value = Convert.ToString(pk);
            string sql = "SELECT * FROM Rainfall WHERE id = " + Convert.ToString(pk);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            if (dt.Rows.Count != 0) base.Select(dt.Rows[0]);

            // Now retrieve all values
            getRainfallValues(id.asInteger());
        }

        public void getRainfallValues(int rid)
        {
        DataTable dt = RainfallStep.selectAll(rid);

        foreach (DataRow dr in dt.Rows)
        {
            int z = Convert.ToInt32(dr["ZOrder"].ToString());
            if ((z != 0) && (z < MAXRAINFALL))
            {
                rainfall[z] = new RainfallStep(rid);
                rainfall[z].Select(dr);
            }
        }
        }

        public static void deleteRainfall(int pk)
        {
            deleteRainfallValues(pk);
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("RainfallID", pk);

            dboperations.ExecuteProcedure("sp_DeleteRainfall", p);
        }

        public static void deleteRainfallValues(int pk)
        {
            string sql = "delete from RainfallStep WHERE RainfallID = " + Convert.ToString(pk);
            dboperations.ExecuteSQL(sql);
        }

        public static DataTable UserAllRainfalls(int uid)
        {
            string sql = "SELECT * FROM Rainfall WHERE UserID = " + Convert.ToString(uid);
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static DataTable UserRealRainfalls(int uid)
        {
            string sql = "SELECT * FROM Rainfall WHERE UserID = " + Convert.ToString(uid);
            sql += " AND (IsDimensionless = 0 OR IsDimensionless IS NULL) ";
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static DataTable UserDimRainfalls(int uid)
        {
            string sql = "SELECT * FROM Rainfall WHERE UserID = " + Convert.ToString(uid);
            sql += " AND IsDimensionless = 1";
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static DataTable dimensionlessRainfalls(int uid)
        {
            string sql = "SELECT * FROM Rainfall WHERE UserID IN( 0, 1, " + Convert.ToString(uid) + ")";
            sql += " AND IsDimensionless = 1";

            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static void ConvertDimensionlessToPublic(int rid)
        {
            string sql = "UPDATE Rainfall SET UserID = 1 WHERE ISDimensionless = 1 and id = " + Convert.ToString(rid);
            dboperations.ExecuteSQL(sql);
        }

#endregion
#region HTML 
        public string valuesAsHtmlTable()
        {
            string s = String.Empty;
            s += "<table>";
            s += RainfallStep.asHeader();
            for (int i = 1; i <= numberOfSteps(); i++)
            {
                s += rainfall[i].asHtmlTableRow();
            }
            s += "</table>";
            return s;
        }


        #endregion
    }

    public class RainfallStep 
    {
        // Each instance is a step in a rainfall file

        public int RainfallID { get; set; }
        public int Zorder { get; set; }
        public double Time { get; set; }
        public double Depth { get; set; }
        
        public RainfallStep()
        {
            RainfallID= 0;
            Zorder= 0;
            Time= 0;
            Depth= 0;

            setup();
        }

        public RainfallStep(int rid)
        {
            RainfallID=rid;
            Zorder = 0;
            Time = 0;
            Depth = 0;

            setup();
        }
        public RainfallStep(int rid, int z)
        {
            RainfallID = rid;
            Zorder = z;
            Time = 0;
            Depth = 0;

            setup();
        }
        public RainfallStep(int rid, int z, double t, double d)
        {
            RainfallID = rid;
            Zorder = z;
            Time = t;
            Depth = d;

            setup();
        }

        public void setup()
        {
        }


        public static string asHeader()
        {
            string s = String.Empty;
            s += "<tr>";
            s += "<th>Time</th>";
            s += "<th>Depth</th>"; ;
            s += "</tr>";
            return s;

        }

        public string asHtmlTableRow()
        {
            string s = String.Empty;
            s += "<tr>";
            s += "<td>" + Time.ToString("F5") + "</td>";
            s += "<td>" + Depth.ToString("F5") + "</td>";
            s += "</tr>";
            return s;
        }

        public void Insert()
        {
            string sql = "INSERT INTO RainfallStep ";
            sql += "(RainfallID, ZOrder, Time, Depth) VALUES (";
            sql += Convert.ToString(RainfallID) + ",";
            sql += Convert.ToString(Zorder) + ",";
            sql += Convert.ToString(Time) + ",";
            sql += Convert.ToString(Depth) + ")";

            dboperations.ExecuteSQL(sql);
        }

        public void Select(DataRow dr)
        {
            RainfallID = Convert.ToInt32(dr["RainfallID"]);
            Zorder = Convert.ToInt32(dr["Zorder"]);
            Time = Convert.ToDouble(dr["Time"]);
            Depth = Convert.ToDouble(dr["Depth"]);
        }

        public static DataTable selectAll(int RainfallID)
        {
            string sql = "SELECT * FROM RainfallStep WHERE RainfallID = " + Convert.ToString(RainfallID) + " ORDER BY ZOrder ASC"; ;
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        
    }
}