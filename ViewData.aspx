<%@ Page Title="View Data From Table" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ViewData.aspx.cs" Inherits="SMADA_2012.ViewData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
  <center>
  <asp:DataGrid runat="server" ID="dgData" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AllowPaging="True" PageSize="25" OnPageIndexChanged="gvData_Change">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditItemStyle BackColor="#999999" />
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" 
            Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        </asp:DataGrid>
 
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
