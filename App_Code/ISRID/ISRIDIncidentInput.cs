using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sage;

namespace ISRID_SAR
{
    public class Incident : TableWrapper
    {

        // These were generated as automated code from the FMS

        public DBElem IncidentID = new DBElem("Incident", "IncidentID", DBElem.typeString);
        public DBElem UserID = new DBElem("Incident", "UserID", DBElem.typeInt);
        public DBElem ImportKey = new DBElem("Incident", "ImportKey", DBElem.typeString);
        public DBElem IncidentCommentsText = new DBElem("Incident", "IncidentCommentsText", DBElem.typeString);
        public DBElem IncidentStatusCode = new DBElem("Incident", "IncidentStatusCode", DBElem.typeString);
        public DBElem IncidentTypeCode = new DBElem("Incident", "IncidentTypeCode", DBElem.typeString);
        public DBElem IncidentEnvironmentCode = new DBElem("Incident", "IncidentEnvironmentCode", DBElem.typeString);
        public DBElem IncidentCountyRegion = new DBElem("Incident", "IncidentCountyRegion", DBElem.typeString);
        public DBElem IncidentStateProvince = new DBElem("Incident", "IncidentStateProvinceCode", DBElem.typeString);
        public DBElem IncidentPrimaryResponseAreaCode = new DBElem("Incident", "IncidentPrimaryResponseAreaCode", DBElem.typeString);
        public DBElem IncidentNumber = new DBElem("Incident", "IncidentNumber", DBElem.typeString); // int
        public DBElem MissionNumber = new DBElem("Incident", "MissionNumber", DBElem.typeString); // int
        public DBElem LeadAgencyNameText = new DBElem("Incident", "LeadAgencyNameText", DBElem.typeString); // nvarchar
        public DBElem IncidentDate = new DBElem("Incident", "IncidentDate", DBElem.typeDateString); // datetime
        public DBElem IncidentTime = new DBElem("Incident", "IncidentTime", DBElem.typeString); // nvarchar
        public DBElem PreparedByAgencyNameText = new DBElem("Incident", "PreparedByAgencyNameText", DBElem.typeString); // nvarchar
        public DBElem PreparedByUserName = new DBElem("Incident", "PreparedByUserName", DBElem.typeString); // nvarchar
        public DBElem PreparedByUserEmail = new DBElem("Incident", "PreparedByUserEmail", DBElem.typeString); // nvarchar
        public DBElem PreparedByUserPhone = new DBElem("Incident", "PreparedByUserPhone", DBElem.typeString); // nvarchar
        public DBElem SubjectCategoryCode = new DBElem("Incident", "SubjectCategoryCode", DBElem.typeString); // nvarchar
        public DBElem SubjectSubcategoryCode = new DBElem("Incident", "SubjectSubcategoryCode", DBElem.typeString); // nvarchar
        public DBElem SubjectActivityText = new DBElem("Incident", "SubjectActivityText", DBElem.typeString); // nvarchar
        public DBElem ContactMethodCode = new DBElem("Incident", "ContactMethodCode", DBElem.typeString); // nvarchar
        public DBElem IPPTypeCode = new DBElem("Incident", "IPPTypeCode", DBElem.typeString); // nvarchar
        public DBElem IPPClassificationCode = new DBElem("Incident", "IPPClassificationCode", DBElem.typeString); // nvarchar
        public DBElem IPPLocationID = new DBElem("Incident", "IPPLocationID", DBElem.typeString); // int
        public DBElem EcoRegionDomainCode = new DBElem("Incident", "EcoRegionDomainCode", DBElem.typeString); // nvarchar
        public DBElem EcoRegionDivisionCode = new DBElem("Incident", "EcoRegionDivisionCode", DBElem.typeString); // nvarchar
        public DBElem PopulationDensityCode = new DBElem("Incident", "PopulationDensityCode", DBElem.typeString); // nvarchar
        public DBElem TerrainCode = new DBElem("Incident", "TerrainCode", DBElem.typeString); // nvarchar
        public DBElem LandCoverCode = new DBElem("Incident", "LandCoverCode", DBElem.typeString); // nvarchar
        public DBElem LandOwnerCode = new DBElem("Incident", "LandOwnerCode", DBElem.typeString); // nvarchar
        public DBElem WeatherCode = new DBElem("Incident", "WeatherCode", DBElem.typeString); // nvarchar
        public DBElem TemperatureMax = new DBElem("Incident", "TemperatureMax", DBElem.typeString); // int
        public DBElem TemperatureMin = new DBElem("Incident", "TemperatureMin", DBElem.typeString); // int
        public DBElem WindMPH = new DBElem("Incident", "WindMPH", DBElem.typeString); // int
        public DBElem RainCode = new DBElem("Incident", "RainCode", DBElem.typeString); // nvarchar
        public DBElem SnowCode = new DBElem("Incident", "SnowCode", DBElem.typeString); // nvarchar
        public DBElem LightCode = new DBElem("Incident", "LightCode", DBElem.typeString); // nvarchar
        public DBElem SnowOnGroundCode = new DBElem("Incident", "SnowOnGroundCode", DBElem.typeString); // nvarchar
        public DBElem GroupCode = new DBElem("Incident", "GroupCode", DBElem.typeString);
        public DBElem GroupTypeCode = new DBElem("Incident", "GroupTypeCode", DBElem.typeString);
        public DBElem LastSeenDate = new DBElem("Incident", "LastSeenDate", DBElem.typeDateString); // nvarchar
        public DBElem LastSeenTime = new DBElem("Incident", "LastSeenTime", DBElem.typeString); // nvarchar
        public DBElem SARNotifedDate = new DBElem("Incident", "SARNotifedDate", DBElem.typeDateString); // nvarchar
        public DBElem SARNotifiedTime = new DBElem("Incident", "SARNotifiedTime", DBElem.typeString); // nvarchar
        public DBElem SubjectLocatedDate = new DBElem("Incident", "SubjectLocatedDate", DBElem.typeDateString); // nvarchar
        public DBElem SubjectLocatedTime = new DBElem("Incident", "SubjectLocatedTime", DBElem.typeString); // nvarchar
        public DBElem IncidentClosedDate = new DBElem("Incident", "IncidentClosedDate", DBElem.typeDateString); // nvarchar
        public DBElem IncidentClosedTime = new DBElem("Incident", "IncidentClosedTime", DBElem.typeString); // nvarchar
        public DBElem TotalTimeLost = new DBElem("Incident", "TotalTimeLost", DBElem.typeFloat); // int
        public DBElem TotalSearchTime = new DBElem("Incident", "TotalSearchTime", DBElem.typeFloat); // int
        public DBElem DestinationCoordinatesID = new DBElem("Incident", "DestinationCoordinatesID", DBElem.typeString); // int
        public DBElem DirectionOfTravel = new DBElem("Incident", "DirectionOfTravel", DBElem.typeString); // nvarchar
        public DBElem DOTDeterminedByCode = new DBElem("Incident", "DOTDeterminedByCode", DBElem.typeString); // nvarchar
        public DBElem RevisedPLSCoordinatesID = new DBElem("Incident", "RevisedPLSCoordinatesID", DBElem.typeString); // int
        public DBElem RevisedDeterminedByCode = new DBElem("Incident", "RevisedDeterminedByCode", DBElem.typeString); // nvarchar
        public DBElem RevisedDOT = new DBElem("Incident", "RevisedDOT", DBElem.typeString); // nvarchar
        public DBElem DecisionPointCoordinatesID = new DBElem("Incident", "DecisionPointCoordinatesID", DBElem.typeString); // int
        public DBElem TypeOfDecisionPointCode = new DBElem("Incident", "TypeOfDecisionPointCode", DBElem.typeString); // nvarchar
        public DBElem DecisionPointFactorCode = new DBElem("Incident", "DecisionPointFactorCode", DBElem.typeString); // nvarchar
        public DBElem IncidentOutcomeCode = new DBElem("Incident", "IncidentOutcomeCode", DBElem.typeString); // nvarchar
        public DBElem OutcomeScenarioCode = new DBElem("Incident", "OutcomeScenarioCode", DBElem.typeString); // nvarchar
        public DBElem NumberSubject = new DBElem("Incident", "NumberSubject", DBElem.typeString); // int
        public DBElem NumberSubjectsWell = new DBElem("Incident", "NumberSubjectsWell", DBElem.typeString); // int
        public DBElem NumberSubjectInjured = new DBElem("Incident", "NumberSubjectInjured", DBElem.typeString); // int
        public DBElem NumberSubjectsDOA = new DBElem("Incident", "NumberSubjectsDOA", DBElem.typeString); // int
        public DBElem NumberSubjectsSaved = new DBElem("Incident", "NumberSubjectsSaved", DBElem.typeString); // int
        public DBElem SuspensionReasonsCodes = new DBElem("Incident", "SuspensionReasonsCodes", DBElem.typeString); // nvarchar
        public DBElem FindCoordinatesID = new DBElem("Incident", "FindCoordinatesID", DBElem.typeString); // int
        public DBElem DistanceToIPP = new DBElem("Incident", "DistanceToIPP", DBElem.typeString); // nvarchar
        public DBElem BearingT = new DBElem("Incident", "BearingT", DBElem.typeString); // nvarchar
        public DBElem FindFeatureCode = new DBElem("Incident", "FindFeatureCode", DBElem.typeString); // nvarchar
        public DBElem FeatureSecondaryCode = new DBElem("Incident", "FeatureSecondaryCode", DBElem.typeString); // nvarchar
        public DBElem DetectabilityCode = new DBElem("Incident", "DetectabilityCode", DBElem.typeString); // nvarchar
        public DBElem MobilityCode = new DBElem("Incident", "MobilityCode", DBElem.typeString); // nvarchar
        public DBElem LostStrategyCode = new DBElem("Incident", "LostStrategyCode", DBElem.typeString); // nvarchar
        public DBElem MobilityHours = new DBElem("Incident", "MobilityHours", DBElem.typeFloat); // int
        public DBElem TrackOffsetYards = new DBElem("Incident", "TrackOffsetYards", DBElem.typeFloat); // int
        public DBElem ElevationChangeFromIPPFeet = new DBElem("Incident", "ElevationChangeFromIPPFeet", DBElem.typeInt); // int
        public DBElem MethodsUsedCodes = new DBElem("Incident", "MethodsUsedCodes", DBElem.typeString); // nvarchar
        public DBElem InjuredSearcherCode = new DBElem("Incident", "InjuredSearcherCode", DBElem.typeString); // nvarchar
        public DBElem InjuredSearcherDetailsText = new DBElem("Incident", "InjuredSearcherDetailsText", DBElem.typeString); // nvarchar
        public DBElem SignallingCode = new DBElem("Incident", "SignallingCode", DBElem.typeString); // nvarchar
        public DBElem ResourcesUsedCodes = new DBElem("Incident", "ResourcesUsedCodes", DBElem.typeString); // nvarchar
        public DBElem FindResourceCode = new DBElem("Incident", "FindResourceCode", DBElem.typeString); // nvarchar
        public DBElem NumberTasks = new DBElem("Incident", "NumberTasks", DBElem.typeString); // int
        public DBElem NumberDogs = new DBElem("Incident", "NumberDogs", DBElem.typeString); // int
        public DBElem NumberAirTasks = new DBElem("Incident", "NumberAirTasks", DBElem.typeString); // int
        public DBElem NumberAircraft = new DBElem("Incident", "NumberAircraft", DBElem.typeString); // int
        public DBElem NumberAirHours = new DBElem("Incident", "NumberAirHours", DBElem.typeString); // int
        public DBElem NumberEmergencyVolunteers = new DBElem("Incident", "NumberEmergencyVolunteers", DBElem.typeString); // int
        public DBElem NumberTotalPeople = new DBElem("Incident", "NumberTotalPeople", DBElem.typeString); // int
        public DBElem NumberManHours = new DBElem("Incident", "NumberManHours", DBElem.typeFloat); // int
        public DBElem NumberVehicles = new DBElem("Incident", "NumberVehicles", DBElem.typeInt); // int
        public DBElem NumberMiles = new DBElem("Incident", "NumberMiles", DBElem.typeFloat); // int
        public DBElem TotalCost = new DBElem("Incident", "TotalCost", DBElem.typeString); // float

        public Incident()
        {
            setupTable();
        }

        public Incident(int pk)
        {
            setupTable();
            Select(pk);
        }

        public void setupTable()
        {
            TableName = "Incident";
            PrimaryKey = "IncidentID";
            ImportKeyColumn = "ImportKey";

            setupColumns();
        }
        public Dictionary<string, DBElem> setupColumns()
        {

            // The dictionary is used to iterate each DBElem for insertion or update
            Columns.Clear();
            IncidentDate.MaxLength = 12;
            IncidentTime.MaxLength = 4;
            Columns.Add(IncidentID.FieldName, IncidentID);
            Columns.Add(UserID.FieldName, UserID);
            Columns.Add(ImportKey.FieldName, ImportKey);
            Columns.Add(IncidentCommentsText.FieldName, IncidentCommentsText);
            Columns.Add(IncidentStatusCode.FieldName, IncidentStatusCode);
            Columns.Add(IncidentTypeCode.FieldName, IncidentTypeCode);
            Columns.Add(IncidentEnvironmentCode.FieldName, IncidentEnvironmentCode);
            Columns.Add(IncidentCountyRegion.FieldName, IncidentCountyRegion);
            Columns.Add(IncidentStateProvince.FieldName, IncidentStateProvince);
            Columns.Add(IncidentPrimaryResponseAreaCode.FieldName, IncidentPrimaryResponseAreaCode);
            Columns.Add(IncidentNumber.FieldName, IncidentNumber);
            Columns.Add(MissionNumber.FieldName, MissionNumber);
            Columns.Add(LeadAgencyNameText.FieldName, LeadAgencyNameText);
            Columns.Add(IncidentDate.FieldName, IncidentDate);
            Columns.Add(IncidentTime.FieldName, IncidentTime);
            Columns.Add(PreparedByAgencyNameText.FieldName, PreparedByAgencyNameText);
            Columns.Add(PreparedByUserName.FieldName, PreparedByUserName);
            Columns.Add(PreparedByUserEmail.FieldName, PreparedByUserEmail);
            Columns.Add(PreparedByUserPhone.FieldName, PreparedByUserPhone);
            Columns.Add(SubjectCategoryCode.FieldName, SubjectCategoryCode);
            Columns.Add(SubjectSubcategoryCode.FieldName, SubjectSubcategoryCode);
            Columns.Add(SubjectActivityText.FieldName, SubjectActivityText);
            Columns.Add(ContactMethodCode.FieldName, ContactMethodCode);
            Columns.Add(IPPTypeCode.FieldName, IPPTypeCode);
            Columns.Add(IPPClassificationCode.FieldName, IPPClassificationCode);
            Columns.Add(IPPLocationID.FieldName, IPPLocationID);
            Columns.Add(EcoRegionDomainCode.FieldName, EcoRegionDomainCode);
            Columns.Add(EcoRegionDivisionCode.FieldName, EcoRegionDivisionCode);
            Columns.Add(PopulationDensityCode.FieldName, PopulationDensityCode);
            Columns.Add(TerrainCode.FieldName, TerrainCode);
            Columns.Add(LandCoverCode.FieldName, LandCoverCode);
            Columns.Add(LandOwnerCode.FieldName, LandOwnerCode);
            Columns.Add(WeatherCode.FieldName, WeatherCode);
            Columns.Add(TemperatureMax.FieldName, TemperatureMax);
            Columns.Add(TemperatureMin.FieldName, TemperatureMin);
            Columns.Add(WindMPH.FieldName, WindMPH);
            Columns.Add(RainCode.FieldName, RainCode);
            Columns.Add(SnowCode.FieldName, SnowCode);
            Columns.Add(LightCode.FieldName, LightCode);
            Columns.Add(SnowOnGroundCode.FieldName, SnowOnGroundCode);
            Columns.Add(GroupCode.FieldName, GroupCode);
            Columns.Add(GroupTypeCode.FieldName, GroupTypeCode);
            Columns.Add(LastSeenDate.FieldName, LastSeenDate);
            Columns.Add(LastSeenTime.FieldName, LastSeenTime);
            Columns.Add(SARNotifedDate.FieldName, SARNotifedDate);
            Columns.Add(SARNotifiedTime.FieldName, SARNotifiedTime);
            Columns.Add(SubjectLocatedDate.FieldName, SubjectLocatedDate);
            Columns.Add(SubjectLocatedTime.FieldName, SubjectLocatedTime);
            Columns.Add(IncidentClosedDate.FieldName, IncidentClosedDate);
            Columns.Add(IncidentClosedTime.FieldName, IncidentClosedTime);
            Columns.Add(TotalTimeLost.FieldName, TotalTimeLost);
            Columns.Add(TotalSearchTime.FieldName, TotalSearchTime);
            Columns.Add(DestinationCoordinatesID.FieldName, DestinationCoordinatesID);
            Columns.Add(DirectionOfTravel.FieldName, DirectionOfTravel);
            Columns.Add(DOTDeterminedByCode.FieldName, DOTDeterminedByCode);
            Columns.Add(RevisedPLSCoordinatesID.FieldName, RevisedPLSCoordinatesID);
            Columns.Add(RevisedDeterminedByCode.FieldName, RevisedDeterminedByCode);
            Columns.Add(RevisedDOT.FieldName, RevisedDOT);
            Columns.Add(DecisionPointCoordinatesID.FieldName, DecisionPointCoordinatesID);
            Columns.Add(TypeOfDecisionPointCode.FieldName, TypeOfDecisionPointCode);
            Columns.Add(DecisionPointFactorCode.FieldName, DecisionPointFactorCode);
            Columns.Add(IncidentOutcomeCode.FieldName, IncidentOutcomeCode);
            Columns.Add(OutcomeScenarioCode.FieldName, OutcomeScenarioCode);
            Columns.Add(NumberSubject.FieldName, NumberSubject);
            Columns.Add(NumberSubjectsWell.FieldName, NumberSubjectsWell);
            Columns.Add(NumberSubjectInjured.FieldName, NumberSubjectInjured);
            Columns.Add(NumberSubjectsDOA.FieldName, NumberSubjectsDOA);
            Columns.Add(NumberSubjectsSaved.FieldName, NumberSubjectsSaved);
            Columns.Add(SuspensionReasonsCodes.FieldName, SuspensionReasonsCodes);
            Columns.Add(FindCoordinatesID.FieldName, FindCoordinatesID);
            Columns.Add(DistanceToIPP.FieldName, DistanceToIPP);
            Columns.Add(BearingT.FieldName, BearingT);
            Columns.Add(FindFeatureCode.FieldName, FindFeatureCode);
            Columns.Add(FeatureSecondaryCode.FieldName, FeatureSecondaryCode);
            Columns.Add(DetectabilityCode.FieldName, DetectabilityCode);
            Columns.Add(MobilityCode.FieldName, MobilityCode);
            Columns.Add(LostStrategyCode.FieldName, LostStrategyCode);
            Columns.Add(MobilityHours.FieldName, MobilityHours);
            Columns.Add(TrackOffsetYards.FieldName, TrackOffsetYards);
            Columns.Add(ElevationChangeFromIPPFeet.FieldName, ElevationChangeFromIPPFeet);
            Columns.Add(SignallingCode.FieldName, SignallingCode);
            Columns.Add(ResourcesUsedCodes.FieldName, ResourcesUsedCodes);
            Columns.Add(InjuredSearcherCode.FieldName, InjuredSearcherCode);
            Columns.Add(InjuredSearcherDetailsText.FieldName, InjuredSearcherDetailsText);
            Columns.Add(MethodsUsedCodes.FieldName, MethodsUsedCodes);
            Columns.Add(FindResourceCode.FieldName, FindResourceCode);
            Columns.Add(NumberTasks.FieldName, NumberTasks);
            Columns.Add(NumberDogs.FieldName, NumberDogs);
            Columns.Add(NumberAirTasks.FieldName, NumberAirTasks);
            Columns.Add(NumberAircraft.FieldName, NumberAircraft);
            Columns.Add(NumberAirHours.FieldName, NumberAirHours);
            Columns.Add(NumberEmergencyVolunteers.FieldName, NumberEmergencyVolunteers);
            Columns.Add(NumberTotalPeople.FieldName, NumberTotalPeople);
            Columns.Add(NumberManHours.FieldName, NumberManHours);
            Columns.Add(NumberVehicles.FieldName, NumberVehicles);
            Columns.Add(NumberMiles.FieldName, NumberMiles);
            Columns.Add(TotalCost.FieldName, TotalCost);
            return Columns;
        }

        public void AddColumn(DBElem d)
        {
            d.MaxLength = DatabaseViewer.ColumnSize(TableName, d.FieldName);
            Columns.Add(d.FieldName, d);
        }

        public override void Select(int pk)
        {
            // IncidentID is PK
            DataRow dr = this.selectValuesForIncident(pk);
            IncidentID.Value = Convert.ToString(pk);

            base.Select(dr);
        }

        public DataRow selectValuesForIncident(int incidentID)
        {
            string sql = "SELECT * FROM " + TableName + " WHERE IncidentID = " + Convert.ToString(incidentID);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            if (dt.Rows.Count != 0)
                return dt.Rows[0];
            else
                return null;
        }

        public override int PrimaryKeyValue()
        {
            return IncidentID.asInteger();
        }

        public string incidentAsHTML()
        {
            string s = "<table>";
            foreach (DBElem d in Columns.Values)
            {
                GUIField g = new GUIField(d);
                if (d.Value != String.Empty)
                    s += g.asHTML(d, "table");
            }
            s += "</table>";
            return s;
        }

        #region "Static Methods"

        public static DataTable getUserIncidents(int UserID)
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            ht.Add("@UserID", UserID);

            return dboperations.GetDataTable("sp_GetUserIncidents", ht);
        }

        public static DataTable getAllIncidents()
        {
            Dictionary<string, object> ht = new Dictionary<string, object>();
            return dboperations.GetDataTable("sp_GetAllIncidents", ht);
        }

        #endregion
    }

    public class LocationCoordinates : TableWrapper
    {
        public DBElem LocationCoordinatesID = new DBElem("LocationCoordinates", "LocationCoordinatesID", DBElem.typeInt);
        public DBElem NorthSouthCoordinate = new DBElem("LocationCoordinates", "NorthSouthCoordinate", DBElem.typeString);
        public DBElem EastWestCoordinate = new DBElem("LocationCoordinates", "EastWestCoordinate", DBElem.typeString);
        public DBElem CoordinatesFormatCode = new DBElem("LocationCoordinates", "CoordinatesFormatCode", DBElem.typeString);
        public DBElem CoordinatesCommentText = new DBElem("LocationCoordinates", "CoordinatesCommentText", DBElem.typeString);

        public LocationCoordinates()
        {
            Initialize();
        }

        public LocationCoordinates(int pk)
        {
            Initialize();
            if (pk != 0)
            {
                LocationCoordinatesID.Value = Convert.ToString(pk);
                DataRow dr = this.selectValues(pk);
                base.Select(dr);
            }
        }

        private void Initialize()
        {
            TableName = "LocationCoordinates";
            PrimaryKey = "LocationCoordinatesID";
            setupColumns();
        }

        public override int PrimaryKeyValue() { return LocationCoordinatesID.asInteger(); }


        public Dictionary<string, DBElem> setupColumns()
        {
            Columns.Clear();
            Columns.Add(LocationCoordinatesID.FieldName, LocationCoordinatesID);
            Columns.Add(NorthSouthCoordinate.FieldName, NorthSouthCoordinate);
            Columns.Add(EastWestCoordinate.FieldName, EastWestCoordinate);
            Columns.Add(CoordinatesFormatCode.FieldName, CoordinatesFormatCode);
            Columns.Add(CoordinatesCommentText.FieldName, CoordinatesCommentText);
            SetNVarcharMaximums();
            return Columns;
        }

    }

    public class IncidentSubject : TableWrapper
    {
        public DBElem IncidentSubjectID = new DBElem("IncidentSubject", "IncidentSubjectID", DBElem.typeString); // int
        public DBElem IncidentID = new DBElem("IncidentSubject", "IncidentID", DBElem.typeInt); // int
        public DBElem SubjectNumber = new DBElem("IncidentSubject", "SubjectNumber", DBElem.typeInt); // int
        public DBElem ImportKey = new DBElem("IncidentSubject", "ImportKey", DBElem.typeString); // nvarchar
        public DBElem SubjectAge = new DBElem("IncidentSubject", "SubjectAge", DBElem.typeInt); // int
        public DBElem SubjectSexCode = new DBElem("IncidentSubject", "SubjectSexCode", DBElem.typeString); // nvarchar
        public DBElem SubjectLocalCode = new DBElem("IncidentSubject", "SubjectLocalCode", DBElem.typeString); // nvarchar
        public DBElem SubjectWeightCode = new DBElem("IncidentSubject", "SubjectWeightCode", DBElem.typeString); // nvarchar
        public DBElem SubjectHeightCode = new DBElem("IncidentSubject", "SubjectHeightCode", DBElem.typeString); // nvarchar
        public DBElem SubjectBuildCode = new DBElem("IncidentSubject", "SubjectBuildCode", DBElem.typeString); // nvarchar
        public DBElem SubjectFitnessCode = new DBElem("IncidentSubject", "SubjectFitnessCode", DBElem.typeString); // nvarchar
        public DBElem SubjectExperienceCode = new DBElem("IncidentSubject", "SubjectExperienceCode", DBElem.typeString); // nvarchar
        public DBElem SubjectEquipmentCode = new DBElem("IncidentSubject", "SubjectEquipmentCode", DBElem.typeString); // nvarchar
        public DBElem SubjectClothingCode = new DBElem("IncidentSubject", "SubjectClothingCode", DBElem.typeString); // nvarchar
        public DBElem SubjectSurvivalCode = new DBElem("IncidentSubject", "SubjectSurvivalCode", DBElem.typeString); // nvarchar
        public DBElem SubjectMentalCode = new DBElem("IncidentSubject", "SubjectMentalCode", DBElem.typeString); // nvarchar
        public DBElem SubjectStatusCode = new DBElem("IncidentSubject", "SubjectStatusCode", DBElem.typeString); // nvarchar
        public DBElem SubjectMechanismCode = new DBElem("IncidentSubject", "SubjectMechanismCode", DBElem.typeString); // nvarchar
        public DBElem SubjectInjuryTypeCode = new DBElem("IncidentSubject", "SubjectInjuryTypeCode", DBElem.typeString); // nvarchar
        public DBElem SubjectIllnessCode = new DBElem("IncidentSubject", "SubjectIllnessCode", DBElem.typeString); // nvarchar
        public DBElem SubjectTxByCode = new DBElem("IncidentSubject", "SubjectTxByCode", DBElem.typeString); // nvarchar
        public DBElem CommentsText = new DBElem("IncidentSubject", "CommentsText", DBElem.typeString); // nvarchar
        public DBElem InjuredResponderCode = new DBElem("IncidentSubject", "InjuredResponderCode", DBElem.typeString); // 

        public IncidentSubject()
        {
            Initialize();
        }

        public IncidentSubject(int pk)
        {
            Initialize();
            if (pk != 0)
            {
                IncidentSubjectID.Value = Convert.ToString(pk);
                DataRow dr = this.selectValues(pk);
                base.Select(dr);
            }
        }

        private void Initialize()
        {
            TableName = "IncidentSubject";
            PrimaryKey = "IncidentSubjectID";
            setupColumns();
        }

        public override int PrimaryKeyValue() { return IncidentSubjectID.asInteger(); }

        public Dictionary<string, DBElem> setupColumns()
        {
            Columns.Clear();
            Columns.Add(IncidentSubjectID.FieldName, IncidentSubjectID);
            Columns.Add(IncidentID.FieldName, IncidentID);
            Columns.Add(SubjectNumber.FieldName, SubjectNumber);
            Columns.Add(ImportKey.FieldName, ImportKey);
            Columns.Add(SubjectAge.FieldName, SubjectAge);
            Columns.Add(SubjectSexCode.FieldName, SubjectSexCode);
            Columns.Add(SubjectLocalCode.FieldName, SubjectLocalCode);
            Columns.Add(SubjectWeightCode.FieldName, SubjectWeightCode);
            Columns.Add(SubjectHeightCode.FieldName, SubjectHeightCode);
            Columns.Add(SubjectBuildCode.FieldName, SubjectBuildCode);
            Columns.Add(SubjectFitnessCode.FieldName, SubjectFitnessCode);
            Columns.Add(SubjectExperienceCode.FieldName, SubjectExperienceCode);
            Columns.Add(SubjectEquipmentCode.FieldName, SubjectEquipmentCode);
            Columns.Add(SubjectClothingCode.FieldName, SubjectClothingCode);
            Columns.Add(SubjectSurvivalCode.FieldName, SubjectSurvivalCode);
            Columns.Add(SubjectMentalCode.FieldName, SubjectMentalCode);
            Columns.Add(SubjectStatusCode.FieldName, SubjectStatusCode);
            Columns.Add(SubjectMechanismCode.FieldName, SubjectMechanismCode);
            Columns.Add(SubjectInjuryTypeCode.FieldName, SubjectInjuryTypeCode);
            Columns.Add(SubjectIllnessCode.FieldName, SubjectIllnessCode);
            Columns.Add(SubjectTxByCode.FieldName, SubjectTxByCode);
            Columns.Add(CommentsText.FieldName, CommentsText);
            Columns.Add(InjuredResponderCode.FieldName, InjuredResponderCode);

            return Columns;
        }

        public override int Insert()
        {
            if (IncidentID.Value == String.Empty)
                return 0;
            else
                return base.Insert();
        }

        public static int getNumberSubjectsForIncident(int incident_id)
        {
            string sql = "SELECT Count(*) FROM IncidentSubject WHERE IncidentID = " + Convert.ToString(incident_id);
            return dboperations.ExecuteSQLReturnInteger(sql);
        }

        public static int[] getSubjectIDsForIncident(int incident_id)
        {
            string sql = "SELECT IncidentSubjectID FROM IncidentSubject WHERE IncidentID = " + Convert.ToString(incident_id);
            DataTable dt = dboperations.ExecuteSQLReturnDataTable(sql);

            int i = 0;
            int[] a = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (DataRow dr in dt.Rows)
            {
                a[i++] = Convert.ToInt32(dr["IncidentSubjectID"]);
            }

            return a;
        }

        public static int getSubjectID(int incidentID, int subject_number)
        {
            string sql1 = "SELECT Count(*) FROM IncidentSubject WHERE IncidentID = " + Convert.ToString(incidentID) + " AND SubjectNumber = " + Convert.ToString(subject_number);
            if (dboperations.ExecuteSQLReturnInteger(sql1) == 0) return 0;

            string sql2 = "SELECT IncidentSubjectID FROM IncidentSubject WHERE IncidentID = " + Convert.ToString(incidentID) + " AND SubjectNumber = " + Convert.ToString(subject_number);
            return dboperations.ExecuteSQLReturnInteger(sql2);
        }

    }
}
