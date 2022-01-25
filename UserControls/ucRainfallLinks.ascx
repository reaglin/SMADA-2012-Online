<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRainfallLinks.ascx.cs" Inherits="SMADA_2012.UserControls.ucRainfallLinks" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />
<asp:Label runat="server" ID="lblRainfallLinks" CssClass="linkListHeader" Text="Rainfall Links"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlSelectRainfall" Text="Manage My Rainfalls" 
               NavigateUrl="~/SMADAForms/SelectRainfall.aspx" CssClass="mainButton"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="hlEditRainfall" Text="Create New Rainfall" 
               NavigateUrl="~/SMADAForms/EditRainfall.aspx"  CssClass="mainButton"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="hlDimRainfall" Text="Create New Dimensionless Rainfall" 
               NavigateUrl="~/SMADAForms/ImportDimensionlessRainfall.aspx"  CssClass="mainButton"></asp:HyperLink>
</td>
</tr>
</table>