<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGuestLinks.ascx.cs" Inherits="SMADA_2012.UserControls.ucGuestLinks" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />
<asp:Label runat="server" ID="lblGuestLinks" CssClass="linkListHeader" Text="Incident Entry Options"></asp:Label><br /><br />
<asp:HyperLink runat="server" ID="hlNewIncident" Text="Create New Incident" NavigateUrl="~/ISRIDForms/EditAdministrativeInformation.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlExistingIncidents" Text="View My Incidents" NavigateUrl="~/ISRIDForms/ViewIncidents.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlSearch" Text="Search Incidents" NavigateUrl="~/ISRIDForms/SearchIncident.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlMyInfo" Text="Edit My Information" NavigateUrl="~/EditUserLogin.aspx"></asp:HyperLink><br />