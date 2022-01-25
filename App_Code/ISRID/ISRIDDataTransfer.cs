using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ISRID_SAR;
using sage;

namespace ISRID_SAR
{
    public class ISRIDDataTransfer
    {
        public DatabaseTransferSystem dts = new DatabaseTransferSystem();


        public string doTransfer(int DatabaseTransferID, int UserID)
        {
            dts.Select(DatabaseTransferID);

            // This is the field mapping for the Source Key
            int fmPK = dts.PrimaryKeyFieldMappingID("Incident");
            if (fmPK == 0) return "No Key Fields Set in Field Mapping";

            // We get all the source keys
            FieldMapping fm = new FieldMapping(fmPK);
            DataTable SourceKeys = fm.AllSourceValues(dts.SourceConnectionString.Value);

            // For each source key we insert into incident
            int nRows = 0;
            foreach (DataRow drKeys in SourceKeys.Rows)
            {
                Incident incident = new Incident();
                string sourceKeyName = GetSourceKeyName(fm);
                string sourceKeyValue = Convert.ToString(drKeys[sourceKeyName]);
                incident.ImportKey.Value = sourceKeyValue;
                incident.UserID.Value = Convert.ToString(UserID);

                incident.SetNVarcharMaximums();
                // Once the incident has been inserted - remaining values are done by update

                int incidentPK = incident.Import();
                incident.IncidentID.Value = Convert.ToString(incidentPK);

                DataTable SourceFields = dts.AllSourceImportFields(fm.SourceTableName.Value);

                foreach (DataRow drFields in SourceFields.Rows)
                {
                    string sourceTable = fm.SourceTableName.Value;
                    string sourceField = Convert.ToString(drFields["SourceFieldName"]);

                    string sourceValue = dts.SelectSourceValue(sourceTable, sourceField, sourceKeyName, sourceKeyValue);

                    string destField = dts.SelectDestinationField(fm.SourceIDName.Value, sourceTable, sourceField);
                    string destValue = dts.SelectDestinationValue(fm.SourceIDName.Value, sourceTable, sourceField, sourceValue);
                    incident.setValue(destField, destValue);

                }
                nRows++;
                // Coordinates are pointed to by incident

                int i1 = InsertIncidentLocation(incident.IncidentID.Value, "IPPLocationID", sourceKeyName, sourceKeyValue, fm.SourceIDName.Value, fm.SourceTableName.Value);
                int i2 = InsertIncidentLocation(incident.IncidentID.Value, "DestinationCoordinatesID", sourceKeyName, sourceKeyValue, fm.SourceIDName.Value, fm.SourceTableName.Value);
                //                int i3 = InsertIncidentLocation(incident.IncidentID.Value, "RevisedPLSCoordinatesID", sourceKeyName, sourceKeyValue, fm.SourceIDName.Value, fm.SourceTableName.Value);
                //                int i4 = InsertIncidentLocation(incident.IncidentID.Value, "DecisionPointCoordinatesID", sourceKeyName, sourceKeyValue, fm.SourceIDName.Value, fm.SourceTableName.Value);
                int i5 = InsertIncidentLocation(incident.IncidentID.Value, "FindCoordinatesID", sourceKeyName, sourceKeyValue, fm.SourceIDName.Value, fm.SourceTableName.Value);

                if (i1 != 0) incident.IPPLocationID.Value = Convert.ToString(i1);
                if (i2 != 0) incident.DestinationCoordinatesID.Value = Convert.ToString(i2);
                //if (i3 != 0) incident.RevisedPLSCoordinatesID.Value = Convert.ToString(i3);
                //if (i4 != 0) incident.DecisionPointCoordinatesID.Value = Convert.ToString(i4);
                if (i5 != 0) incident.FindCoordinatesID.Value = Convert.ToString(i5);

                incident.Update();



                InsertIncidentSubject(incident.IncidentID.Value, sourceKeyName, sourceKeyValue, fm.SourceIDName.Value, fm.SourceTableName.Value);
                //if (nRows == 1000)
                //    return "Transfer Was Successful " + Convert.ToString(nRows) + " Imported";
            }

            return "Transfer Was Successful " + Convert.ToString(nRows) + " Imported";
        }


        private string SourceIDName()
        {
            return dts.SourceIDName.Value;
        }

        private string GetSourceKeyName(FieldMapping fm)
        {
            return fm.SourceFieldName.Value;
        }


        private string getNextSubjectNumber(string incidentID)
        {
            string sql = "SELECT MAX(SubjectNumber) FROM IncidentSubject WHERE IncidentID = " + incidentID;
            int n = dboperations.ExecuteSQLReturnInteger(sql);
            return Convert.ToString(n + 1);
        }

        private int InsertIncidentLocation(string incidentID, string incidentLocField, string sourceKeyName, string sourceKeyValue, string sIDName, string sTableName)
        {
            // If record exists - update it, else create it
            string sql = "SELECT " + incidentLocField + " FROM Incident WHERE IncidentID = " + incidentID;
            int v1 = dboperations.ExecuteSQLReturnInteger(sql); // zero if no value exists

            LocationCoordinates lc = new LocationCoordinates();
            if (v1 != 0) lc.LocationCoordinatesID.Value = Convert.ToString(v1);


            // This is hard codes
            string NS = String.Empty;
            string EW = String.Empty;

            switch (incidentLocField)
            {
                case "IPPLocationID":
                    NS = "LKP Coord (N/S)";
                    EW = "LKP Coord (E/W)";
                    break;
                case "DestinationCoordinatesID":
                    NS = "Destination Coord (N/S)";
                    EW = "Destination Coord (E/W)";

                    break;
                case "RevisedPLSCoordinatesID":

                    break;
                case "DecisionPointCoordinatesID":

                    break;
                case "FindCoordinatesID":
                    NS = "Find Coord (N/S)";
                    EW = "Find Coord (E/W)";
                    break;
                default: break;

            }
            string NSValue = dts.SelectSourceValue(sTableName, NS, sourceKeyName, sourceKeyValue);
            string EWValue = dts.SelectSourceValue(sTableName, EW, sourceKeyName, sourceKeyValue);
            lc.setValue(lc.NorthSouthCoordinate.FieldName, NSValue);
            lc.setValue(lc.EastWestCoordinate.FieldName, EWValue);

            if (v1 == 0)
            {
                return lc.Insert();
            }
            else
            {
                lc.Update();
                return 0; // no need to update incident
            }
        }

        private void InsertIncidentSubject(string incidentID, string sourceKeyName, string sourceKeyValue, string sIDName, string sTableName)
        {

            IncidentSubject in_sub = new IncidentSubject();
            in_sub.IncidentID.Value = incidentID;
            in_sub.SubjectNumber.Value = getNextSubjectNumber(incidentID);
            in_sub.ImportKey.Value = sourceKeyValue;
            // First Insert a Subject To Establish the record

            int subjectID = in_sub.Import();
            in_sub.IncidentSubjectID.Value = Convert.ToString(subjectID);
            in_sub.SetNVarcharMaximums();

            DataTable SourceFields = dts.AllSourceImportFields(sTableName);

            // The if-then handles the multiple subject issue

            string ageValue = dts.SelectSourceValue(sTableName, "Age", sourceKeyName, sourceKeyValue);

            ageValue = ageValue.TrimEnd(',');
            if (ageValue.Contains(","))  // More than one age             
            {
                string[] sAgeArray = ageValue.Split(',');
                int n = 0;
                foreach (string s in sAgeArray)
                {
                    foreach (DataRow drFields in SourceFields.Rows)
                    {
                        string sFieldName = Convert.ToString(drFields["SourceFieldName"]);
                        string sourceValue = dts.SelectSourceValue(sTableName, sFieldName, sourceKeyName, sourceKeyValue);
                        string dFieldName = dts.SelectDestinationField(sIDName, sTableName, sFieldName);
                        string destValue = String.Empty;

                        if (sFieldName == "Age")
                        {
                            destValue = s;
                            in_sub.setValue("SubjectNumber", Convert.ToString(n + 1));
                        }
                        else
                            destValue = dts.SelectDestinationValue(sIDName, sTableName, sFieldName, sourceValue);

                        if (sFieldName == "Sex")
                            if (sourceValue.Length > Math.Max(n, 1)) destValue = sourceValue.Substring(n, 1); else destValue = String.Empty;
                        else
                            destValue = dts.SelectDestinationValue(sIDName, sTableName, sFieldName, sourceValue);

                        in_sub.setValue(dFieldName, destValue);

                    }
                    in_sub.Update();
                    n++;
                }
            }

            else
            {
                foreach (DataRow drFields in SourceFields.Rows)
                {
                    string sFieldName = Convert.ToString(drFields["SourceFieldName"]);

                    string sourceValue = dts.SelectSourceValue(sTableName, sFieldName, sourceKeyName, sourceKeyValue);

                    string dFieldName = dts.SelectDestinationField(sIDName, sTableName, sFieldName);
                    string destValue = dts.SelectDestinationValue(sIDName, sTableName, sFieldName, sourceValue);
                    in_sub.setValue(dFieldName, destValue);
                }
                in_sub.Update();
            }
        }

    }
}
