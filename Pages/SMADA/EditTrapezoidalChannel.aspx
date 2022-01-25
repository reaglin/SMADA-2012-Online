<%@ Page Title="Trapezoidal Channel Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditTrapezoidalChannel.aspx.cs" Inherits="SMADA2013.Pages.SMADA.EditTrapezoidalChannel"
    ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%: Page.Title %></h1>
<table><tr>      
<td><uc1:ucEditXmlPropertyObject runat="server" id="ucEditXmlPropertyObject" /></td>
<td><uc1:ucOutputXmlPropertyObject runat="server" id="ucReport" /></td>
</tr></table>
<div style ="margin: 0 0 0 10%">
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton"/>
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"  CssClass="FormButton"/>
    <asp:Button ID="btnCalculateDepth" runat="server" Text="Calculate Depth" OnClick="btnCalculateDepth_Click"  CssClass="FormButton"/>
    <asp:Button ID="btnCalculateFlow" runat="server" Text="Calculate Flow" OnClick="btnCalculateFlow_Click" />
    <asp:Button ID="btnManage" runat="server" Text="Done" OnClick="btnManage_Click"  CssClass="FormButton" PostBackUrl="~/DefaultLoggedIn.aspx" />
    <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="TrapezoidalChannel"/>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
