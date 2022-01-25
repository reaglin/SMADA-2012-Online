<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="DefaultNotLoggedIn.aspx.cs" Inherits="SMADA_2012.DefaultNotLoggedIn" %>
<%@ Register src="~/UserControls/ucCalculators.ascx" tagname="ucCalculators" tagprefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Panel runat="server" ID="pnlCalculators" Visible="true">
        <uc:ucCalculators ID="ucCalculators" runat="server" />
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
