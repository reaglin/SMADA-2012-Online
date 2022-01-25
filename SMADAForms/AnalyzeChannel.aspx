<%@ Page Title="Trapezoidal Channel Calculator" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="AnalyzeChannel.aspx.cs" Inherits="SMADA_2012.SMADAForms.AnalyzeChannel" %>
<%@ Register Src="~/UserControls/SMADA/ucTrapezoidalChannel.ascx" TagPrefix="uc" TagName="Channel" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script src="../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Panel runat="server" ID="pnlPlot" Visible="false">
    <asp:Literal runat="server" ID="litPlot"></asp:Literal><br /> 
</asp:Panel>
<uc:Channel runat="server" id="ucPircularPipe"></uc:Channel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
