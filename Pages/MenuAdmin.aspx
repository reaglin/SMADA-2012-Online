<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="SMADA2013.Pages.MenuAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pages/EditObjectHelp.aspx">Project Object Help</asp:HyperLink><br/>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Pages/Resources.aspx">Resources</asp:HyperLink><br/>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=LookupTable">Edit Lookup Table</asp:HyperLink><br/>
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Pages/ManageAllObjects.aspx">Manage All Objects</asp:HyperLink><br/>
    <asp:Button ID="btnObjectHelp" runat="server" Text="Object Help" OnClick="btnObjectHelp_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
