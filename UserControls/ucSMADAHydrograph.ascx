<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSMADAHydrograph.ascx.cs" Inherits="SMADA_2012.UserControls.ucSMADAHydrograph" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />

<asp:Label runat="server" ID="lblWatershedLinks" CssClass="linkListHeader" Text="Watersheds"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlSelectWatershed" Text="Manage My Watersheds" 
               NavigateUrl="~/SMADAForms/SelectWatershed.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="hlEditWatershed" Text="Create New Watershed" 
               NavigateUrl="~/SMADAForms/EditWatershed.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table><br /><br />

<asp:Label runat="server" ID="lblRainfallLinks" CssClass="linkListHeader" Text="Rainfalls"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlSelectRainfall" Text="Manage My Rainfalls" 
               NavigateUrl="~/SMADAForms/SelectRainfall.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="hlEditRainfall" Text="Create New Rainfall" 
               NavigateUrl="~/SMADAForms/EditRainfall.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="hlDimRainfall" Text="Create New Dimensionless Rainfall" 
                NavigateUrl="~/SMADAForms/ImportDimensionlessRainfall.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table><br /><br />

<asp:Label runat="server" ID="lblHydrographLinks" CssClass="linkListHeader" Text="Hydrographs"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlSelectHydrograph" Text="Manage My Hydrographs" 
                NavigateUrl="~/SMADAForms/SelectHydrograph.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="hlEditHydrograph" Text="Create New Hydrograph" 
               NavigateUrl="~/SMADAForms/Edithydrograph.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table><br /><br />
