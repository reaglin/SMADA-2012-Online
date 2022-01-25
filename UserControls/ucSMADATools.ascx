<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSMADATools.ascx.cs" Inherits="SMADA_2012.UserControls.ucSMADATools" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />

<asp:Label runat="server" ID="Label1" CssClass="linkListHeader" Text="Distribution Analysis Tools"></asp:Label><br /><br />

<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlDistribution1" Text="Insert/Edit Distribution Data" 
               NavigateUrl="~/SMADAForms/PasteDistribution.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="HyperLink1" Text="Manage/Analyze Distribution Data" 
               NavigateUrl="~/SMADAForms/ManageDistributions.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table>
<br /><br />
<asp:Label runat="server" ID="Label2" CssClass="linkListHeader" Text="Regression Analysis Tools"></asp:Label><br /><br />
<table>
<tr>
<td>
<asp:HyperLink runat="server" ID="HyperLink2" Text="Insert/Edit Regression Data" 
               NavigateUrl="~/SMADAForms/EditRegression.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
<td>
<asp:HyperLink runat="server" ID="HyperLink3" Text="Manage/Analyze Regression Data" 
               NavigateUrl="~/SMADAForms/ManageRegressions.aspx" CssClass="mainButton" Width="200"></asp:HyperLink>
</td>
</tr>
</table>
<asp:Label runat="server" ID="Label3" CssClass="linkListHeader" Text=" "></asp:Label><br /><br />
