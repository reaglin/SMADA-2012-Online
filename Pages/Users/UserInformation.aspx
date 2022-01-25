<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInformation.aspx.cs" Inherits="SMADA2013.Pages.Users.UserInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1>Information About Current User</h1><br />
    Current Windows login: <asp:Label ID="lblWLogin" runat="server" Text=""></asp:Label><br />
    <br /><br />
    <h2>Context Properties</h2><br />
    <asp:Literal ID="litContext" runat="server"></asp:Literal>
    <br /><br />
    <h2>Membership Properties</h2><br />
    <asp:Literal ID="litMembership" runat="server"></asp:Literal>
    <br /><br />
    <b>Create a New Role:</b> <asp:TextBox ID="RoleName" runat="server"></asp:TextBox> <br /> 
    <asp:Button ID="CreateRoleButton" runat="server" Text="Create Role" OnClick="CreateRoleButton_Click" />
    <asp:Button ID="DeleteRoleButton" runat="server" Text="Delete Role" OnClick="DeleteRoleButton_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
