using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using sage;
using DBF = sage.DatabaseField;

namespace SMADA_2012.App_Code.SMADA
{
    public enum InfiltrationMethod
    {
        [Description("SCS Curve Number")]
        SCSCurveNumber,
        [Description("Horton Infiltration")]
        HortonInfiltration,
        [Description("Not Specified")]
        NotSpecified
    }

    public enum HydrographGenerationMethod
    {

        /* 
             *   
             * 
  USE SMADA
  GO
  
  DECLARE @N INTEGER
  INSERT INTO Categories 
    (CategoryNameText, DeletedBit)
  VALUES
     ('HydrographGenerationMethods', 0)
  SET @N = @@IDENTITY   
  
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'Santa Barbara Method', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'Generic SCS Method', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'SCS 484 Method', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'SCS 256 Method', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'Generic SCS Method 2', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'SCS 484 Method 2', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'SCS 256 Method 2', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'Clark Method', 0)
  INSERT INTO Codes (CategoryID, CodeNameText, DeletedBit)
  VALUES (@N, 'Unit Hydrograph', 0)     
             * 
             */

        [Description("Santa Barbara Method")]
        SantaBarbaraMethod,
        [Description("Generic SCS Method")]
        GenericSCSMethod,
        [Description("SCS 484 Method")]
        SCS484Method,
        [Description("SCS 256 Method")]
        SCS256Method,
        [Description("Generic SCS 2")]
        GenericSCS2,
        [Description("SCS 484 Method 2")]
        SCS484Method2,
        [Description("SCS 256 Method 2")]
        SCS256Method2,
        [Description("Clark Method")]
        ClarkMethod,
        [Description("Unit Hydrograph Method")]
        UnitHdrographMethod,
        [Description("Not specified")]
        NotSpecified,
    }


    public class Watershed : DatabaseTable 
    {
        #region Properties
     
        public DBF id = new DBF("Watershed", "id", DBF.typeInt);
        public DBF Title = new DBF("Watershed", "Title", DBF.typeString);
        public DBF Description = new DBF("Watershed", "Description", DBF.typeString);
        public DBF InfMeth = new DBF("Watershed", "InfMeth", DBF.typeString);
        public DBF TotalArea = new DBF("Watershed", "TotalArea", DBF.typeDouble);
        public DBF TimeCon = new DBF("Watershed", "TimeCon", DBF.typeDouble);
        public DBF ImpArea = new DBF("Watershed", "ImpArea", DBF.typeDouble);
        public DBF DCIA = new DBF("Watershed", "DCIA", DBF.typeDouble);
        public DBF AddAbsImp = new DBF("Watershed", "AddAbsImp", DBF.typeDouble);
        public DBF AddAbsPerv = new DBF("Watershed", "AddAbsPerv", DBF.typeDouble);
        public DBF MaxInf = new DBF("Watershed", "MaxInf", DBF.typeDouble);
        public DBF hic = new DBF("Watershed", "hic", DBF.typeDouble);
        public DBF hio = new DBF("Watershed", "hio", DBF.typeDouble);
        public DBF hip = new DBF("Watershed", "hip", DBF.typeDouble);
        public DBF hipo = new DBF("Watershed", "hipo", DBF.typeDouble);
        public DBF hk = new DBF("Watershed", "hk", DBF.typeDouble);
        public DBF hkr = new DBF("Watershed", "hkr", DBF.typeDouble);
        public DBF CN = new DBF("Watershed", "CN", DBF.typeDouble);
        public DBF irate = new DBF("Watershed", "irate", DBF.typeDouble);
        public DBF InitAbs = new DBF("Watershed", "InitAbs", DBF.typeDouble);
        public DBF FracDCIA = new DBF("Watershed", "FracDCIA", DBF.typeDouble);
        public DBF FracNDCIA = new DBF("Watershed", "FracNDCIA", DBF.typeDouble);
        public DBF FracPerv = new DBF("Watershed", "FracPerv", DBF.typeDouble);
        public DBF SmoothFlag = new DBF("Watershed", "SmoothFlag", DBF.typeInt);
        public DBF UserID = new DBF("Watershed", "UserID", DBF.typeInt);
        public DBF CreatedDate = new DBF("Watershed", "CreatedDate", DBF.typeDateString);

        #endregion

        #region Constructors

        public Watershed()
        {
            setup();
        }

        public Watershed(string WatershedID)
        {
            id.Value = WatershedID;
            setup();
        }

        public Watershed(int WatershedID)
        {
            id.Value = Convert.ToString(WatershedID);
            setup();
        }

        public void setup()
        {
            id.isPrimaryKey = true;
            TableName = "Watershed";
            PrimaryKey = "id";

            setupFields();

            if (id.asInteger() != 0)
            {
                Select(id.asInteger());
                calculate();
            }
        }

        public Dictionary<string, DatabaseField> setupFields()
        {
            Fields.Clear();
            Fields.Add(id.fieldNameText, id);
            Fields.Add(Title.fieldNameText, Title);
            Fields.Add(Description.fieldNameText, Description);
            Fields.Add(InfMeth.fieldNameText, InfMeth);
            Fields.Add(TotalArea.fieldNameText, TotalArea);
            Fields.Add(TimeCon.fieldNameText, TimeCon);
            Fields.Add(ImpArea.fieldNameText, ImpArea);
            Fields.Add(DCIA.fieldNameText, DCIA);
            Fields.Add(AddAbsImp.fieldNameText, AddAbsImp);
            Fields.Add(AddAbsPerv.fieldNameText, AddAbsPerv);
            Fields.Add(MaxInf.fieldNameText, MaxInf);
            Fields.Add(hic.fieldNameText, hic);
            Fields.Add(hio.fieldNameText, hio);
            Fields.Add(hip.fieldNameText, hip);
            Fields.Add(hipo.fieldNameText, hipo);
            Fields.Add(hk.fieldNameText, hk);
            Fields.Add(hkr.fieldNameText, hkr);
            Fields.Add(CN.fieldNameText, CN);
            Fields.Add(irate.fieldNameText, irate);
            Fields.Add(InitAbs.fieldNameText, InitAbs);
            Fields.Add(FracDCIA.fieldNameText, FracDCIA);
            Fields.Add(FracNDCIA.fieldNameText, FracNDCIA);
            Fields.Add(FracPerv.fieldNameText, FracPerv);
            Fields.Add(SmoothFlag.fieldNameText, SmoothFlag);
            Fields.Add(UserID.fieldNameText, UserID);
            Fields.Add(CreatedDate.fieldNameText, CreatedDate);
            return Fields;
        }


        public InfiltrationMethod infiltrationMethod()
        {
            if (InfMeth.Value.Contains("SCS")) return InfiltrationMethod.SCSCurveNumber;
            if (InfMeth.Value.Contains("Horton")) return InfiltrationMethod.HortonInfiltration;
            return InfiltrationMethod.NotSpecified;
        }

        public bool isHortonInfiltration()
        {
            return (infiltrationMethod() == InfiltrationMethod.HortonInfiltration);
        }
        public bool isSCSInfiltration()
        {
            return (infiltrationMethod() == InfiltrationMethod.SCSCurveNumber);

        }

        #endregion

        #region "Calculations"

        public string Validate()
        {
            string s = String.Empty;
            if (DCIA.asDouble() > 100) s += DCIA.promptText + " cannot be greater than 100% \n";
            if (ImpArea.asDouble() > TotalArea.asDouble())
                s += ImpArea.promptText + " cannot be greater than " + TotalArea.promptText;

 
            return s;
        }
        public void calculate()
        {
            // Calculates watershed parameters
            //
            // Fraction DCIA
            // Fraction NDCIA
            // Fraction Pervious

            double dcia = DCIA.asDouble(); ;
            double ia = ImpArea.asDouble();
            double ta = TotalArea.asDouble();

            if (dcia != 0)
                FracDCIA.Value = Convert.ToString((ia / ta) * (dcia / 100.0));
            if (ta != 0)
            {
                FracDCIA.setValue ((dcia / 100) * ia / ta);
                FracNDCIA.setValue((ia / ta) * ((100.0 - dcia) / 100.0));
                FracPerv.setValue((ta - ia) / ta);
            }
        }

        public bool AddWatershed(Watershed w)
        {

            // #eaglin - implement if needed
            return true;

        }

        public double CalculateHortonInfiltrationRate(double f)
        {
            /*   F refers to the cumulative infiltration
       '   this subroutine solves
        '   Horton equation using infiltration rate as a
        '   function of cumulative infiltration
        '   f = fo - fc*Ln((f-fc)/(fo-fc)) - FK
        '   where F = Cumulative Infiltration
        '
        '   When using this function for normal simulations
        '   First set tw.HIP to tw.HIO, the tw.HIP allows for
        '   Soil moisture adjustment when performing continuous
        '   simulation
             */
            double fo = hipo.asDouble();
            double fc = hic.asDouble();
            double k = hk.asDouble();
            
            return CalculateHortonInfiltrationRaw(fo, fc, k, f);

        }

        public static double CalculateHortonInfiltrationRaw(double fo, double fc, double k, double f)
        {
            double functionReturnValue = 0;
            //   F refers to the cumulative infiltration
            //   this subroutine solves
            //   Horton equation using infiltration rate as a
            //   function of cumulative infiltration
            //   f = fo - fc*Ln((f-fc)/(fo-fc)) - FK
            //   where F = Cumulative Infiltration
            //
            //   When using this function for normal simulations
            //   First set tw.HIP to tw.HIO, the tw.HIP allows for
            //   Soil moisture adjustment when performing continuous
            //   simulation

            double tfr = 0;
            // Temporary iniltration rate
            double delta = 0;
            
            int iter = 0;
            double incr = 0;
            //bool exitflag = false;
            double eqn1 = 0;
            double eqn2 = 0;

            // Limiting Case

            if (f == 0) { functionReturnValue = fo; return 0.0; }

            tfr = fo;
            delta = 1;
            iter = 0;
            incr = -0.1 * (fo - fc);
            if (f < 0)
                f = 0;


            //exitflag = false;
            // trap minimum case for initial rate
            if (fo == fc)
            {
                return fo;
            }
            double lastdelta = 0;
            while (Math.Abs(delta) >= 1E-05)
            {
                if (tfr <= fc)
                    tfr = 1.0000001 * fc;
                if (tfr <= 0)
                {
                    return 0.0;
                }

                eqn1 = fc * Math.Log((tfr - fc) / (fo - fc));
                eqn2 = fo - f * k;
                delta = tfr - (eqn2 - eqn1);
                if (Math.Sign(lastdelta) != Math.Sign(delta))
                {
                    incr = incr / 2f;
                }
                if (delta < 0)
                {
                    if (tfr - incr < fc)
                        incr = incr / 2;
                    tfr = tfr - incr;
                }
                else
                {
                    tfr = tfr + incr;
                }
                iter = iter + 1;
                if (delta == lastdelta)
                    break; // TODO: might not be correct. Was : Exit Do
                lastdelta = delta;
                if (iter > 50)
                {
                    return fc;
                }
            }
            if (tfr < fc)
                tfr = fc;
            //If tfr > tw.hip Then tfr = tw.hip

            return tfr;

        }

        #endregion

        #region "Save and Retrieve"

        public override void Select(int pk)
        {
            id.Value = Convert.ToString(pk);
            string sql = "SELECT * FROM " + TableName + " WHERE id = " + Convert.ToString(pk);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            if (dt.Rows.Count != 0) base.Select(dt.Rows[0]);
        }

        public static DataTable UserWatersheds(int uid)
        {
            string sql = "SELECT * FROM Watershed WHERE UserID = " + Convert.ToString(uid);
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static void deleteWatershed(int pk)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("WatershedID", pk);

            dboperations.ExecuteProcedure("sp_DeleteWatershed", p);
        }

        public static DataTable getInfiltrationMethods()
        {
            return Categories.getCodes("WatershedInfiltrationType");

        }

        #endregion
    }

    public class Hydrograph : DatabaseTable
    {

        // At its core a Hydrograph has a Rainfall, a Watershed, and a method.
        #region "Properties and Contructors"
        public const int MAXSTEPS = 2000;

        public double[] excess;
        public double[] infiltration;
        public double[] outflow;

        public Rainfall rainfall;
        public Watershed watershed;

        // Persistent values are saved 
        public DBF id = new DBF("Hydrograph", "id", DBF.typeInt);
        public DBF Title = new DBF("Hydrograph", "Title", DBF.typeString);
        public DBF Description = new DBF("Hydrograph", "Description", DBF.typeString);
        public DBF HydrographMethod = new DBF("Hydrograph", "HydrographMethod", DBF.typeString);
        public DBF WatershedID = new DBF("Hydrograph", "WatershedID", DBF.typeInt);
        public DBF RainfallID = new DBF("Hydrograph", "RainfallID", DBF.typeInt);

        public DBF PeakAttFactor = new DBF("Hydrograph", "PeakAttFactor", DBF.typeInt);
        public DBF NumberOfSteps = new DBF("Hydrograph", "NumberOfSteps", DBF.typeInt);
        public DBF TimeStep = new DBF("Hydrograph", "TimeStep", DBF.typeInt);
        public DBF UserID = new DBF("Hydrograph", "UserID", DBF.typeInt);
        public DBF CreatedDate = new DBF("Hydrograph", "CreatedDate", DBF.typeDateString);

        public Hydrograph()
        {
            setup();
        }

        public Hydrograph(string HydrographID)
        {
            id.Value = HydrographID;
            setup();
        }

        public Hydrograph(int HydrographID)
        {
            id.Value = Convert.ToString(HydrographID);
            setup();
        }

        public void initialize()
        {
            TableName = "Hydrograph";
            PrimaryKey = "id";

            setupFields();
        }

        public double timeOfConcentration
        { get { return watershed.TimeCon.asDouble(); }}

        public double totalArea
        { get { return watershed.TotalArea.asDouble(); }}

        public double depth(int i)
        { return rainfall.depth(i); }

        public double time(int i)
        { return rainfall.time(i); }

        public double timeStep
        { get { return rainfall.TimeStep.asDouble(); }}

        public int numberOfRainfallSteps
        { get { return rainfall.NumberOfSteps.asInteger(); } }

        public int numberOfSteps
        { get { return NumberOfSteps.asInteger(); } }

        public void setNumberOfSteps(int i)
        { NumberOfSteps.setValue(i); }


        public HydrographGenerationMethod  hydrographGenerationMethod()
        {
            return HydrographGenerationMethod.SantaBarbaraMethod;
        }

        #endregion

        #region "Setup"

        public void setup()
        {
            TableName = "Hydrograph";
            PrimaryKey = "id";

            setupFields();

            if (id.asInteger() != 0)
            {
                Select(id.asInteger());
                if (RainfallID.asInteger() != 0)
                    rainfall = new Rainfall(RainfallID.asInteger());
                else
                    rainfall = new Rainfall();

                if (WatershedID.asInteger() != 0)
                    watershed = new Watershed(WatershedID.asInteger());
                else
                    watershed = new Watershed();
            }
            excess = new double[MAXSTEPS];
            infiltration = new double[MAXSTEPS];
            outflow = new double[MAXSTEPS];
        }


        public Dictionary<string, DatabaseField> setupFields()
        {

            // The dictionary is used to iterate each DBElem for insertion or update
            Fields.Clear();
            Fields.Add(id.fieldNameText, id);
            Fields.Add(Title.fieldNameText, Title);
            Fields.Add(Description.fieldNameText, Description);
            Fields.Add(HydrographMethod.fieldNameText, HydrographMethod);
            Fields.Add(WatershedID.fieldNameText, WatershedID);
            Fields.Add(RainfallID.fieldNameText, RainfallID);

            Fields.Add(PeakAttFactor.fieldNameText, PeakAttFactor);
            Fields.Add(NumberOfSteps.fieldNameText, NumberOfSteps);
            Fields.Add(TimeStep.fieldNameText, TimeStep);

            Fields.Add(UserID.fieldNameText, UserID);
            Fields.Add(CreatedDate.fieldNameText, CreatedDate);

            return Fields;
        }

        public HydrographGenerationMethod generationMethod()
        {
            if (HydrographMethod.Value == "Santa Barbara Method") return HydrographGenerationMethod.SantaBarbaraMethod;
            if (HydrographMethod.Value == "SCS 484 Method") return HydrographGenerationMethod.SCS484Method;
            if (HydrographMethod.Value == "SCS 256 Method") return HydrographGenerationMethod.SCS256Method;
            if (HydrographMethod.Value == "SCS 484 Method 2") return HydrographGenerationMethod.SCS484Method2;
            if (HydrographMethod.Value == "SCS 256 Method 2") return HydrographGenerationMethod.SCS256Method2;
            if (HydrographMethod.Value == "Generic SCS Method") return HydrographGenerationMethod.GenericSCSMethod;
            if (HydrographMethod.Value == "Generic SCS Method 2") return HydrographGenerationMethod.GenericSCS2;

            return HydrographGenerationMethod.NotSpecified;
        }
        #endregion

        #region "Calculations"

        public string Validate()
        {
            return String.Empty;
        }

        public void generateHydrograph()
        {
            if (timeStep == 0) return;
            generateInstantHydrograph();

            switch (generationMethod())
            {
                case HydrographGenerationMethod.SantaBarbaraMethod:
                    generateSantaBarbaraHydrograph();
                    break;
                case HydrographGenerationMethod.SCS256Method:
                    generateSCSHydrograph(256);
                    break;
                case HydrographGenerationMethod.SCS484Method:
                    generateSCSHydrograph(484);
                    break;
                case HydrographGenerationMethod.SCS256Method2:
                    generateSCSHydrograph2(256);
                    break;
                case HydrographGenerationMethod.SCS484Method2:
                    generateSCSHydrograph2(484);
                    break;
                case HydrographGenerationMethod.GenericSCSMethod:
                    if (PeakAttFactor.asDouble() == 0) PeakAttFactor.setValue(640);
                    generateSCSHydrograph(PeakAttFactor.asDouble());
                    break;

                case HydrographGenerationMethod.GenericSCS2:
                    if (PeakAttFactor.asDouble() == 0) PeakAttFactor.setValue(640);
                    generateSCSHydrograph2(PeakAttFactor.asDouble());
                    break;
            }
        }

        // All hydrograph methods use the instant hydrograph
        private void generateInstantHydrograph()
        {
            double imperviousExcess = 0;
            double cumulativeRainfall = 0;
            double cumulativePerviousRainfall = 0;
            double cumulativeImperviousAbstraction = 0;
            double cumulativePerviousAbstraction = 0;
            double cumulativePerviousExcess = 0;
            double cumulativeInfiltration = 0;
            double cumulativePerviousRunoff = 0;
            double lastCumulativePerviousRunoff = 0;
            double addAbsImp = watershed.AddAbsImp.asDouble();
            double addAbsPerv = watershed.AddAbsPerv.asDouble();

            //double totalPerviousRainfall = 0.0;
            double totalExcess = 0.0;
            double totalInfiltration = 0.0;

            for (int i = 1; i <= rainfall.numberOfSteps(); i++)
            {
                cumulativeRainfall  += depth(i); // depth in inches

                // Additional Abstraction routing - first impervious
                // it either routes to the pervious surface (DCIA)
                // or routes to the impervious area where it can infiltrate

                if (addAbsImp > cumulativeRainfall)
                {
                    imperviousExcess = 0;
                    cumulativeImperviousAbstraction += depth(i);
                }
                else if (((cumulativeRainfall - depth(i)) < addAbsImp) && (cumulativeRainfall > addAbsImp))
                {
                    imperviousExcess = depth(i) - (addAbsImp - cumulativeImperviousAbstraction );
                    cumulativeImperviousAbstraction = addAbsImp;                    
                }
                else
                {
                    imperviousExcess = depth(i);
                }
                if (imperviousExcess < 0) imperviousExcess = 0;


                // Routing Impervious to Pervious Excess

                double totalArea = watershed.TotalArea.asDouble();
                double impArea = watershed.ImpArea.asDouble();
                double imperviousToPerviousExcess = 0.0;
                double fracNDCIA = watershed.FracNDCIA.asDouble();

                // Routing fromimpervious to pervious area
                if (totalArea <= impArea)
                {
                    imperviousToPerviousExcess = 0.0;
                }
                else
                {
                    imperviousToPerviousExcess = fracNDCIA * imperviousExcess * totalArea /(totalArea - impArea);
                }

                double imperviousRunoff = imperviousExcess;
                double perviousRainfall = depth(i) + imperviousToPerviousExcess;
                cumulativePerviousRainfall += perviousRainfall; 

                // Routing of Abstraction on Pervious Surface
                double perviousExcess = 0.0;
                if (addAbsPerv > cumulativePerviousRainfall)
                {
                    perviousExcess = 0.0;
                    cumulativePerviousAbstraction = cumulativePerviousRainfall;
                }
                else
                {
                    perviousExcess = perviousRainfall + (cumulativePerviousAbstraction - addAbsPerv);
                    cumulativePerviousAbstraction = addAbsPerv;
                }
                cumulativePerviousExcess += perviousExcess;

                // Now for the infiltration methods
                double maxInf = watershed.MaxInf.asDouble();
                if (maxInf <= 0) maxInf = cumulativeRainfall;
                double potentialInfiltrationRate = watershed.CalculateHortonInfiltrationRate(cumulativeInfiltration);
                double potentialInfiltration = potentialInfiltrationRate * timeStep / 60;
                double perviousRunoff = 0.0;

                if (watershed.isHortonInfiltration())
                {
                    if (cumulativeInfiltration < maxInf)
                    {
                        if (perviousExcess > potentialInfiltration)
                        {
                            perviousRunoff = perviousExcess - potentialInfiltration;
                            infiltration[i] = potentialInfiltration;
                        }
                        else
                        {
                            perviousRunoff = 0.0;
                            infiltration[i] = perviousExcess;
                        }
                    }
                    else
                    {
                        perviousRunoff = perviousExcess;
                        infiltration[i] = 0.0;
                    }
                } // end Horton Infiltration

                if (watershed.isSCSInfiltration())
                {

                    double sprime = 1000 / watershed.CN.asDouble() - 10;
                    double absFact = watershed.InitAbs.asDouble() * sprime;
                    double initAbs = watershed.InitAbs.asDouble();
                    if (cumulativePerviousExcess > absFact) 
                    {
                        cumulativePerviousRunoff = (Math.Pow(cumulativePerviousExcess - absFact, 2)/(cumulativePerviousExcess + (1 - initAbs) * sprime));
                        perviousRunoff = cumulativePerviousRunoff - lastCumulativePerviousRunoff; 
                        lastCumulativePerviousRunoff = cumulativePerviousRunoff;

                        if (cumulativeInfiltration < maxInf)
                        {
                            infiltration[i] = perviousExcess - perviousRunoff;
                        }
                        else
                        {
                            infiltration[i] = 0;
                            perviousRunoff = perviousExcess;
                        }
                    } //   (cumulativePerviousExcess > absFact)
                   
                    else
                    {
                        if (cumulativeInfiltration < maxInf)
                        {
                            perviousRunoff = 0;
                            infiltration[i] = perviousExcess;
                        }
                        else
                        {
                            perviousRunoff = perviousExcess;
                            infiltration[i] = 0;
                        }
                    } //   (cumulativePerviousExcess > absFact)
                    
                } // End SCS Infiltration

                double fracPerv = watershed.FracPerv.asDouble();
                double fracDCIA = watershed.FracNDCIA.asDouble();
                cumulativeInfiltration += infiltration[i];
                infiltration[i] = infiltration[i] * fracPerv;
                double tempExcess = fracDCIA * imperviousRunoff + fracPerv * perviousRunoff;
                totalExcess += tempExcess;
                // put excess in volume terms
                excess[i] = 60 * tempExcess * totalArea * 1.008 / timeStep;
                totalInfiltration += infiltration[i];

           } // next i     
        } // end generateInstantHydrograph()

        public void generateSantaBarbaraHydrograph()
        {

            int i = 1;
            bool exitFlag = false;

            double peakOutflow = 0;

            if (timeOfConcentration == 0) return;
            if (timeStep == 0) return;
            double KR = timeStep / (2 * timeOfConcentration + timeStep);
            outflow.Initialize();
 
            while (!exitFlag)
            {
                if (i >= 2)
                    outflow[i] = outflow[i - 1] + KR * (excess[i - 1] + excess[i] - 2 * outflow[i - 1]);
                else
                    outflow[i] = KR * excess[i];

                peakOutflow = Math.Max(peakOutflow, outflow[i]);
                if (((i > numberOfRainfallSteps) && (outflow[i] < .005 )) || (i == MAXSTEPS-1))
                {
                    exitFlag = true;
                    setNumberOfSteps(i);
                }
                i++;
            }
        }

        public void generateSCSHydrograph(double PAF)
        {
            UnitHydrograph uh = new UnitHydrograph();
            uh.GenerateSCS(PAF, watershed.TimeCon.asDouble() , timeStep);

            multiplyUnitHydrograph(uh);
  
        }

        public void generateSCSHydrograph2(double PAF)
        {
            UnitHydrograph uh = new UnitHydrograph();
            uh.GenerateSCSType2(PAF, watershed.TimeCon.asDouble(), timeStep);

            multiplyUnitHydrograph(uh);
        }

        public bool multiplyUnitHydrograph(UnitHydrograph uh)
        {
            uh.normalize();
            bool exitFlag = false;
            int i = 1;
            double peakOutflow = 0;
            while (!exitFlag)
            {
                for (int j = 0; j <= i - 1; j++)
                    outflow[i] = outflow[i] + excess[i - j] * uh.q[j + 1];

                peakOutflow = Math.Max(peakOutflow, outflow[i]);

                if (i == MAXSTEPS - 1) exitFlag = true;
                if ((i > numberOfSteps) && (outflow[i] < 0.005 * peakOutflow)) exitFlag = true;
                i++;
            }

            setNumberOfSteps(i - 1);
            return true;
        }

        #endregion

        #region "Save and Retrieve"
        public override void Select(int pk)
        {
            id.Value = Convert.ToString(pk);
            string sql = "SELECT * FROM " + TableName + " WHERE id = " + Convert.ToString(pk);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            if (dt.Rows.Count != 0)
                base.Select(dt.Rows[0]);
        }
        #endregion

        #region "Static Methods"
        public static DataTable Userhydrographs(int uid)
        {
            string sql = "SELECT * FROM Hydrograph WHERE UserID = " + Convert.ToString(uid);
            return dboperations.ExecuteSQLReturnDataTable(sql);
        }

        public static void DeleteHydrograph(int pk)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("HydrographID", pk);

            dboperations.ExecuteProcedure("sp_DeleteHydrograph", p);
        }

        #endregion

        #region "Output Routines"
        public string htmlOutput()
        {
            string s = String.Empty;
            s +=  "<h1>Hydrograph</h1><br />";
            s += asHtmlTable();
            s += "<br/>";
            s += valuesAsHtmlTable();

            return s;
        }
        public double[] outflowValues()
        {
            double[] v = new double[MAXSTEPS];
            for (int i = 0; i < numberOfSteps; i++) v[i] = outflow[i];
            return v;
        }

        public double[] excessValues()
        {
            double[] v = new double[MAXSTEPS];
            for (int i = 0; i < numberOfSteps; i++) v[i] = excess[i];
            return v;
        }


        public string valuesAsHtmlTable()
        {
            string s = String.Empty;
            s += "<h1>Hydrograph Values</h1><br/>";
            s += "<table>";
            s += "<tr>";
            s += Html.td("Time (min)");
            s += Html.td("Rainfall Depth (in)");
            s += Html.td("Infiltration (in)");
            s += Html.td("Excess (cfs)");
            s += Html.td("Runoff (cfs)");
            s += "</tr>";
            for (int i = 1; i < rainfall.numberOfSteps(); i++) s+= asHtmlTableRow(i);
            s += "</table>";
            return s;
        }

        public string asHtmlTableRow(int i)
        {
            string s = String.Empty;
            s += Html.td(i * timeStep, 0);
            s += Html.td(depth(i), 2);
            s += Html.td(infiltration[i], 2);
            s += Html.td(excess[i], 2);
            s += Html.td(outflow[i], 2);
            return Html.tr(s);
        }

        #endregion
    }

    public class UnitHydrograph : TableWrapper
    {
        public const int MAXUHSTEPS = 1000;
        
        public double[] q;
        private int numberOfSteps {get; set;}
        public UnitHydrograph()
        {
            q = new double[MAXUHSTEPS];
        }
     

        public void GenerateSCS(double PAF, double timeCon, double timeStep)
        { GenerateSCSCalculations(PAF, timeCon, timeStep, timeStep); }

        public void GenerateSCSType2(double PAF, double timeCon, double timeStep)
        { GenerateSCSCalculations(PAF, timeCon, timeStep, timeStep/2.0 + 0.6*timeCon); }

        private void GenerateSCSCalculations(double PAF, double timeCon, double timeStep, double fallStep)
        {
            double fallLimbFact = (1291 / PAF) - 1;
            double unitTimeCon;

            if (timeCon < timeStep)
                unitTimeCon = timeStep;
            else
                unitTimeCon = fallStep;

            double timeFall = fallLimbFact * timeCon;
            double totalUnitTime = unitTimeCon + timeFall;
            totalUnitTime = Convert.ToInt16(totalUnitTime / timeStep + 0.5) * timeStep;
            numberOfSteps = Convert.ToInt16(totalUnitTime / timeStep + 0.5);

            for (int j = 1; j <= numberOfSteps; j++)
            {
                double stepTime = j * timeStep;
                if (stepTime <= unitTimeCon)
                    q[j] = stepTime / unitTimeCon;
                else
                    q[j] = 1 + unitTimeCon / timeFall - stepTime / timeFall;

                if (q[j] < 0) q[j] = 0;
            }
            normalize();
        }

        public void normalize()
        {
            double uhTotal = 0;
            for (int j = 1; j <= numberOfSteps; j++) uhTotal += q[j];
            for (int j = 1; j <= numberOfSteps; j++) q[j] = q[j] / uhTotal;
        }
    }
}