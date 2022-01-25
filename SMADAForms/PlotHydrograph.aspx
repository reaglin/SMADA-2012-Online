<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="PlotHydrograph.aspx.cs" Inherits="SMADA_2012.SMADAForms.PlotHydrograph" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script src="../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
    <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
    <asp:TextBox runat="server" ID="tbChart" TextMode="MultiLine" Height="300" Width="600"></asp:TextBox>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
