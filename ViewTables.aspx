<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ViewTables.aspx.cs" Inherits="SMADA_2012.ViewTables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
    <h1>Admin Screen - Database Tables</h1>
 <asp:gridview id="gvTables" runat="server" autogeneratecolumns="True"  
        cellpadding="4" gridlines="None" ForeColor="#333333">        
		<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
		<emptydatatemplate>No records found.</emptydatatemplate>
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
        <asp:TemplateField HeaderText = "View Structure">
        <ItemTemplate>
        <asp:HyperLink runat="server" ID="hlSP" Text='<%#Eval("TABLE_NAME") %>'
                        navigateURL = '<%#ViewURL(Eval("TABLE_NAME"))%>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "View Data">
        <ItemTemplate>
        <asp:HyperLink runat="server" ID="hlViewData" Text='<%#Eval("TABLE_NAME") %>'
                        navigateURL = '<%#ViewData(Eval("TABLE_NAME"))%>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:gridview><br />
    <h2>Columns</h2>
    <asp:gridview id="gvColumns" runat="server" cellpadding="4" gridlines="None" 
        ForeColor="#333333" AutoGenerateColumns="true">        
		<RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
		<emptydatatemplate>No records found.</emptydatatemplate>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:gridview><br /><br />
    
    <h2>Constraints</h2>
    <asp:gridview id="gvConstraints" runat="server" cellpadding="4" gridlines="None" 
        ForeColor="#333333" AutoGenerateColumns="true">        
		<RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
		<emptydatatemplate>No records found.</emptydatatemplate>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:gridview><br /><br />

    <h2>Foreign Keys</h2>
    <asp:gridview id="gvForeignKeys" runat="server" cellpadding="4" gridlines="None" 
        ForeColor="#333333" AutoGenerateColumns="true">        
		<RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
		<emptydatatemplate>No records found.</emptydatatemplate>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:gridview><br />


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
