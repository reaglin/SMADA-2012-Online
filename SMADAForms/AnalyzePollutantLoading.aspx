<%@ Page Title="Analyze Pollutant Loading" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="AnalyzePollutantLoading.aspx.cs" Inherits="SMADA_2012.SMADAForms.AnalyzePollutantLoading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
Global Rainfall Value: (in):
            <asp:TextBox ID="tbGRainfall" runat="server" Width="40" ToolTip="If Entered this value will be used for all land use types"></asp:TextBox>

    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <EmptyDataTemplate>No Land Use Data Exists in File</EmptyDataTemplate>
        <Columns>
        <asp:BoundField DataField="Land Use" HeaderText="Land Use" />
        <asp:BoundField DataField="Rational C" HeaderText="Rational C" />
        <asp:TemplateField>
        <ItemTemplate>
        Watershed Area (acres): 
            <asp:TextBox ID="tbArea" runat="server" Width="50"></asp:TextBox>
        Watershed Rainfall (in):
            <asp:TextBox ID="tbRainfall" runat="server" Width="50"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" 
        CssClass="actionButton" onclick="btnCalculate_Click" />

<br /><br />
    <asp:GridView ID="gvResults" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="true" Visible="false">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView><br />
    Pollutant Loading in kg, area in acres, rainfall in inches

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
