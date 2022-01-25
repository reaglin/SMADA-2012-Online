<%@ Page Title="Rainfall Plot" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" 
  CodeBehind="PlotRainfall.aspx.cs" Inherits="SMADA_2012.SMADAForms.PlotRainfall" ValidateRequest="false" %>
<%@ Register Src="~/UserControls/ucPlot.ascx" TagPrefix="uc" TagName="Plot" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script src="../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
  <uc:Plot runat="server" id="Plot"></uc:Plot>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
