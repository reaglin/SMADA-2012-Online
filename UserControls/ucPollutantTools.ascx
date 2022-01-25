<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPollutantTools.ascx.cs" Inherits="SMADA_2012.UserControls.ucPollutantTools" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />

<asp:Label runat="server" ID="Label1" CssClass="linkListHeader" Text="Pollutant Analysis Tools (PLOAD)"></asp:Label><br /><br />

<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlDistribution1" Text="Insert/Edit Land Use Data" 
               NavigateUrl="~/SMADAForms/EditLandUses.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="HyperLink1" Text="Manage/Analyze Land Use Data" 
               NavigateUrl="~/SMADAForms/ManageLandUses.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table>
<br /><br />
<asp:Label runat="server" ID="Label2" CssClass="linkListHeader" Text="Best Management Analysis Tools"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="HyperLink2" Text="BMPTrains 1" 
               NavigateUrl="~/SMADAForms/ComingSoon.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="HyperLink3" Text="BMPTrains 2" 
               NavigateUrl="~/SMADAForms/ComingSoon.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table>
<asp:Label runat="server" ID="Label3" CssClass="linkListHeader" Text=" "></asp:Label><br /><br />
