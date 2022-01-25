<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ViewSQLQueries.aspx.cs" Inherits="SMADA_2012.ViewSQLQueries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
 <center>
 <asp:DataGrid ID="dgQuery" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" Visible="true" >
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>
        
        <asp:BoundColumn DataField="SQLQueryManagerName" HeaderText="Name" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="SQLQueryManagerDescription" HeaderText="Description"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="View" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:HyperLink runat="server" id="hlView" Text="View" 
                        NavigateUrl='<%# "~/EditSQLQuery.aspx?SQLQueryID=" + DataBinder.Eval(Container.DataItem, "SQLQueryManagerID") %>'></asp:HyperLink> 

        </ItemTemplate></asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
