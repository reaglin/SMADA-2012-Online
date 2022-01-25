<%@ Page Title="Calculate Time of Concentration" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="CalculateTimeOfConcentration.aspx.cs" Inherits="SMADA_2012.SMADAForms.CalculateTimeOfConcentration" %>
<%@ Register Src="~/UserControls/SMADA/ucTimeOfConcentration.ascx" TagPrefix="uc" TagName="TimeOfConcentration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<uc:TimeOfConcentration runat="server" id="ucTC"></uc:TimeOfConcentration>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
