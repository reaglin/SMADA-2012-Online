<%@ Page Title="Global Objects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditGlobal.aspx.cs" Inherits="SMADA2013.Pages.EditGlobal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1>Set Global Objects</h1>
    On this page you can make your saved objects global. Please note that global objects are
    available to all uses. When you make an abject Global - a copy is made registered to 
    user 'Global'. All users have access to these Global Objects.<br/><br/>
    <h3>Select Object Type</h3><br/>
    <asp:DropDownList ID="ddlObjectType" runat="server" CssClass="DropDownList"></asp:DropDownList>
    <asp:Button ID="btnShow" runat="server" Text="Show" />
    


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
