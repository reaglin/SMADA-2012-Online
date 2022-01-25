<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucReportsAndSearch.ascx.cs" Inherits="SMADA_2012.UserControls.ucReportsAndSearch" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />
<asp:Label runat="server" ID="lblGuestLinks" CssClass="linkListHeader" Text="Search and Reports"></asp:Label><br /><br />
<asp:HyperLink runat="server" ID="hlBasicReports" Text="Counts Reports" NavigateUrl="~/ISRIDForms/ReportCountsForCodes.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlAdhoc" Text="Ad-Hoc Reports" NavigateUrl="~/ViewSQLQueries.aspx"></asp:HyperLink><br />
