<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDatabaseManager.ascx.cs" Inherits="SMADA_2012.UserControls.ucDatabaseManager" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />
<asp:Label runat="server" ID="lblAdminLinks" CssClass="linkListHeader" Text="Database Management Links"></asp:Label><br /><br />
<asp:HyperLink runat="server" ID="hlViewTables" Text="View Tables and Raw Data" NavigateUrl="~/ViewTables.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlDataTransfer" Text="Manage Data Imports" NavigateUrl="~/ViewDataTransfers.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlImport" Text="Setup New Data Import" NavigateUrl="~/EditDatabaseTransfer.aspx"></asp:HyperLink><br />
