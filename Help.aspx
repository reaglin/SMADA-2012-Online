<%@ Page Title="Help for " Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="SMADA_2012.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Literal ID="litHelp" runat="server"></asp:Literal><br />
    <asp:LinkButton ID="lbHelp" runat="server" onclick="lbHelp_Click">Edit</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

