<%@ Page Title="View Feedback" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="SMADA_2012.ViewFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
    <asp:GridView ID="gvFeedback" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
        CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" 
        GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" />
            <asp:BoundField DataField="PageName" HeaderText="Page" 
                SortExpression="PageName" />
            <asp:BoundField DataField="FeedbackText" HeaderText="Feedback" 
                SortExpression="FeedbackText" />
            <asp:CheckBoxField DataField="IsResolved" HeaderText="Resolved" 
                SortExpression="IsResolved" />
            <asp:BoundField DataField="UserFullName" HeaderText="Entered By" 
                SortExpression="UserFullName" />
            <asp:BoundField DataField="EnteredDate" HeaderText="Entered Date" 
                SortExpression="EnteredDate" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SMADAConnectionString %>" 
        SelectCommand="SELECT * FROM [view_Feedback]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
