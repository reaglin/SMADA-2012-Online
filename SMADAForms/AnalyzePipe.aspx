<%@ Page Title="Analyze Open Channel and Pipe Flow" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="AnalyzePipe.aspx.cs" Inherits="SMADA_2012.SMADAForms.AnalyzePipe" %>
<%@ Register Src="~/UserControls/SMADA/ucCircularPipe.ascx" TagPrefix="uc" TagName="CircularPipe" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script src="../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Panel runat="server" ID="pnlPlot" Visible="false">
    <asp:Literal runat="server" ID="litPlot"></asp:Literal><br /> 
</asp:Panel>
<uc:CircularPipe runat="server" id="ucPircularPipe"></uc:CircularPipe>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
