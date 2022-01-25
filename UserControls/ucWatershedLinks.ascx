<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucWatershedLinks.ascx.cs" Inherits="SMADA_2012.UserControls.ucWatedshed" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />
<asp:Label runat="server" ID="lblWatershedLinks" CssClass="linkListHeader" Text="Watershed Links"></asp:Label><br /><br />

<asp:HyperLink runat="server" ID="hlSelectWatershed" Text="Manage My Watersheds" NavigateUrl="~/SMADAForms/SelectWatershed.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlEditWatershed" Text="Create New Watershed" NavigateUrl="~/SMADAForms/EditWatershed.aspx"></asp:HyperLink><br />
