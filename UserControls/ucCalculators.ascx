<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCalculators.ascx.cs" Inherits="SMADA_2012.UserControls.ucCalculators" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />

<asp:Label runat="server" ID="Label1" CssClass="linkListHeader" Text="Flow Calculation Tools"></asp:Label><br /><br />

<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlDistribution1" Text="Analyze Circular Pipes" 
               NavigateUrl="~/SMADAForms/AnalyzePipe.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="HyperLink1" Text="Analyze Trapezoidal Channels" 
               NavigateUrl="~/SMADAForms/AnalyzeChannel.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table>
<br /><br />
<asp:Label runat="server" ID="Label2" CssClass="linkListHeader" Text="Hydrology Calculators"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="HyperLink2" Text="Time of Concentration Calculator" 
               NavigateUrl="~/SMADAForms/CalculateTimeOfConcentration.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="HyperLink3" Text="Other" 
               NavigateUrl="~/SMADAForms/ComingSoon.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table>
