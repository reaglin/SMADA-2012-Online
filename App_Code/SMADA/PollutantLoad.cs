using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data;

/*
 CREATE TABLE [dbo].[DataTypes](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [DataTypeText] [nvarchar](250) NOT NULL,
        [DataTypeVersion] int NULL,
        [DataTypeCommentsText] [nvarchar](max) NULL,
        [CreatedDate] [datetime] NULL)

 CREATE TABLE [dbo].[DataContainer](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
        [DataTypeText] [nvarchar](250) NOT NULL,
	[DescriptionText] [nvarchar](250) NULL,
	[DataText] [nvarchar](max) NULL,
        [CommentsText] [nvarchar](500) NULL,
	[UserID] [int] NULL,
	[CreatedDate] [datetime] NULL)
*/
namespace SMADA_2012.App_Code.SMADA
{
    public class PollutantLoad : SMADABase
    {
        // Code for the analysis of pulltant loads 

    }


    public class LandUses : SMADABase
    {
        public const int maxLandUses = 200;
        public const string TableName = "LandUseData";

        private LandUse[] landUseField = new LandUse[maxLandUses];
        public LandUse[] LandUseArray
        {
            get { return this.landUseField; }
            set {this.landUseField = value; }
        }

        private int mynLanduses;
        public int nLandUses
        {
            get { return mynLanduses; }
            set { mynLanduses = value; }
        }

        public LandUses()
            : base("Land Use Data")
        {

        }

        public LandUses(int luID)
            : base("Land Use Data")
        {
            RetrieveLandUses(luID);
        }

        public void addLandUse(LandUse lu)
        {
            LandUseArray[nLandUses] = lu;
            nLandUses++;
        }

        public void addLandUse(string name, float rationalC, string pollutants)
        {
            // pollutants come in as a delimited string

            addLandUse(nLandUses, name, rationalC, pollutants);
            nLandUses++;
        }

        public void addLandUse(int n, string name, float rationalC, string pollutants)
        {
            // pollutants come in as a delimited string
            // \t between name and value
            // \n between each line

            LandUse lu = new LandUse();
            lu.LandUseName = name;
            lu.RationalC = rationalC;

            lu.addPollutants(pollutants);
            LandUseArray[n] = lu;
        }

        public void addLanduse(XElement xelem)
        {
            LandUse lu = new LandUse(xelem);
            addLandUse(lu);
        }

        public string[] totalPollutants()
        {
            // Returns a string array of all the names of all the 
            // pollutants in all land uses
            string[] pols = new string[LandUse.maxPollutants];
            int i = 0;
            foreach (LandUse l in LandUseArray)
            {
                if (l != null)
                {
                    foreach (Pollutant p in l.Pollutants)
                    {
                        if (p != null)
                        {
                            if (!pols.Contains(p.pollutantName))
                            {
                                pols[i] = p.pollutantName;
                                i++;
                            }
                        }
                    }
                }
            }

            return pols;
        }

        public string asXML()
        {
            string s = "<landUses>\n";
            foreach (LandUse l in LandUseArray)
            {
                if (l != null)
                {
                    s += " <landUse>\n";
                    s += l.asXML();
                    s += " </landUse>\n";
                }
            }
            s += "</landUses>\n";
            return s;
        }

        public DataTable asDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Land Use"));
            dt.Columns.Add(new DataColumn("Rational C"));
          
            for (int i = 1; i <= nLandUses; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Land Use"] = LandUseArray[i-1].LandUseName;
                dr["Rational C"] = String.Format("{0:0.000}", LandUseArray[i - 1].RationalC);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void RetrieveLandUses(int luID)
        {
            base.Retrieve(luID);
            parseXML(DataText);
        }

        public void SaveLandUses(int userID)
        {
            this.Insert(userID);
        }

        public void parseXML(string xmlData)
        {
            try
            {
                var doc = XDocument.Parse(xmlData);
                nLandUses = 0;
                foreach (XElement xElem in doc.Root.Descendants("landUse"))
                {
                    addLandUse(new LandUse(xElem));
                }
            }
            catch
            { nLandUses = 0; }
        }



        public ArrayList landUseNames()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < nLandUses; i++)
            {
                list.Add(LandUseArray[i].LandUseName);
            }
            return list;
        }

        public DataTable calculate()
        {
            // Calculates loadings and answers a datatable of the results
            // Land Use Name, Rational C, Area, Rainfall, Pollutant, Pollutant, etc...

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("C"));
            dt.Columns.Add(new DataColumn("Area"));
            dt.Columns.Add(new DataColumn("Rainfall"));

            // Add a column for each pollutant type
            int i=1;
            Dictionary<string, float> totalLoading = new Dictionary<string, float>();
            foreach (string s in totalPollutants())
            {
                if (isValid(s)) {
                    dt.Columns.Add(new DataColumn(s));
                    totalLoading.Add(s, 0);
                }
            }

            float totalArea = 0;
            float totalRainfall = 0;
            float totalC = 0;
            foreach (LandUse l in LandUseArray)
            {
                if ((l != null) && (l.Area != 0))
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = l.LandUseName;
                    dr["C"] = String.Format("{0:0.000}", l.RationalC);
                    dr["Area"] = String.Format("{0:0.0}", l.Area);
                    totalArea += l.Area;
                    totalRainfall += l.Rainfall * l.Area;
                    totalC += l.RationalC * l.Area;
                    dr["Rainfall"] = String.Format("{0:0.00}", l.Rainfall);
                    foreach (string s in totalPollutants())
                    {
                        if (isValid(s))
                        {
                            dr[s] = String.Format("{0:0.000}", l.calculateLoading(s));
                            totalLoading[s] += l.calculateLoading(s);
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "Total";
            if (totalArea != 0) dr2["C"] = String.Format("{0:0.00}", totalC / totalArea);
            dr2["Area"] = String.Format("{0:0.00}", totalArea);
            if (totalArea != 0) dr2["Rainfall"] = String.Format("{0:0.00}", totalRainfall/totalArea); 
            foreach (string s in totalPollutants())
            {
                if (isValid(s))
                {
                    dr2[s] = String.Format("{0:0.000}", totalLoading[s]);
                }
            }
            dt.Rows.Add(dr2);
            return dt;
        }
    }

    public class LandUse
    {
        public const int maxPollutants = 40;

        private string landUseNameField;
        private float rationalCField;
        private float AreaField;
        private float RainfallField;

        private Pollutant[] pollutantField = new Pollutant[maxPollutants];

        public string LandUseName
        {
            get {return this.landUseNameField; }
            set{this.landUseNameField = value; }
        }

        public float RationalC
        {
            get { return this.rationalCField; }
            set { this.rationalCField = value; }
        }

        public float Area
        {
            get { return this.AreaField; }
            set { this.AreaField = value; }
        }

        public float Rainfall
        {
            get { return this.RainfallField; }
            set { this.RainfallField = value; }
        }
        

        public Pollutant[] Pollutants
        {
            get { return this.pollutantField; }
            set { this.pollutantField = value;}
        }

        private int mynPollutants;

        public int nPollutants
        {
            get { return mynPollutants; }
            set { mynPollutants = value; }
        }

        public LandUse()
        {
        }

        public LandUse(XElement xelem)
        {
            LandUseName = xelem.Element("landUseName").Value;
            RationalC = Convert.ToSingle(xelem.Element("rationalC").Value);

            nPollutants = 0;
            foreach (XElement xElem in xelem.Descendants("pollutant"))
            {
                addPollutant(new Pollutant(xElem));
            }
        }

        public void addPollutant(Pollutant p)
        {
            Pollutants[nPollutants] = p;
            nPollutants++;
        }

        public void addPollutant(string name, float concentration)
        {
            Pollutant p = new Pollutant()
            {
                pollutantName = name,
                pollutantConcentration = concentration
            };
            addPollutant(p);
        }

        public void addPollutant(string name, string concentration)
        {
            addPollutant(name, Convert.ToSingle(concentration));
        }

        public void addPollutants(string pollutants)
        {
            char ColumnDelimiter = '\t';
            char RowDelimiter = '\n';
            nPollutants = 0;
            string[] rows =  pollutants.Split(RowDelimiter);
            foreach (string row in rows)
            {
                string cleanRow = SpreadsheetPaste.convertToTabDelimited(row);
                if (cleanRow.Contains(ColumnDelimiter))
                {
                string[] cols = cleanRow.Split(ColumnDelimiter);
                addPollutant(cols[0], cols[1]);
                nPollutants++;
                }
            }
        }

        public string[] totalPollutants()
        {
            // Returns a string array of all the names of all the 
            // pollutants in this land use
            string[] pols = new string[maxPollutants];
            int i = 0;
            foreach (Pollutant p in Pollutants)
            {
                if (!pols.Contains(p.pollutantName))
                {
                    pols[i] = p.pollutantName;
                    i++;
                }
            }
            return pols;
        }

        public float calculateLoading(string pollutantName)
        {
            int i = pollutantIndex(pollutantName);
            if (i >= 0)
                return Pollutants[i].calculateLoading(RationalC,Area,Rainfall) ;
            else
                return 0;
        }

        public string pollutantName(int i)
        {
            return Pollutants[i].pollutantName;
        }

        public int pollutantIndex(string s)
        {
            int i = 0;
            foreach (Pollutant p in Pollutants)
            {
                if (p != null)
                {
                    if (s == p.pollutantName) return i;
                    i++;
                }
            }
            return -1;
        }
        public string asXML()
        {
            string s = "<landUseName>" + LandUseName + "</landUseName> \n";
            s += "<rationalC>" + Convert.ToString(RationalC) + "</rationalC> \n";
            foreach (Pollutant p in Pollutants)
            {
                if (p != null)
                {
                    s += "  <pollutant>\n";
                    s += p.asXML();
                    s += "  </pollutant>\n";
                }
            }
            return s;
        }

        public string pollutantsAsString()
        {
            string s = String.Empty;
            foreach (Pollutant p in Pollutants)
            {
                if (p != null)
                {
                    s += p.pollutantName;
                    s += "\t";
                    s += Convert.ToString(p.pollutantConcentration);
                    s += "\n";
                }
            }
            return s;
        }
    }

    public class Pollutant
    {
        private string pollutantNameField;
        private float pollutantConcentrationField;

        public string pollutantName
        {
            get { return this.pollutantNameField;}
            set { this.pollutantNameField = value;}
        }

        public float pollutantConcentration
        {
            get {return this.pollutantConcentrationField; }
            set { this.pollutantConcentrationField = value; }
        }

        public Pollutant()
        {
        }

        public Pollutant(XElement xelem)
        {
            pollutantName = xelem.Element("pollutantName").Value;
            pollutantConcentration = Convert.ToSingle(xelem.Element("pollutantConcentration").Value);
        }

        public string asXML()
        {
            string s = "   <pollutantName>" + pollutantName + "</pollutantName> \n";
            s += "   <pollutantConcentration>" + Convert.ToString(pollutantConcentration) + "</pollutantConcentration> \n";
            return s;
        }
        public float calculateLoading(float rationalC, float area, float rainfall)
        {
            return Convert.ToSingle(0.1029 * pollutantConcentration * rationalC * area * rainfall);
        }

    }
}