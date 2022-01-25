<%@ Page Title="Manage Regression Data" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ManageRegressions.aspx.cs" Inherits="SMADA_2012.SMADAForms.ManageRegressions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" OnRowCommand="gv_OnRowCommand">
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
        <EmptyDataTemplate>No Regression Data Exists</EmptyDataTemplate>
        <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" />
        <asp:BoundField DataField="DescriptionText" HeaderText="Description Of Data" />
        <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lbUse" runat="server" CommandName="use" CommandArgument='<%#Eval("id") %>' 
              CssClass="gridButton">Use Data for Analysis</asp:LinkButton> |
            <asp:LinkButton ID="lbEdit" runat="server" CommandName="editd"  CommandArgument='<%#Eval("id") %>' 
              CssClass="gridButton">Edit Regression Data</asp:LinkButton> |
            <asp:LinkButton ID="lbDelete" runat="server" CommandName="deleted" CommandArgument='<%#Eval("id") %>' 
               CssClass="gridButton">Delete Regression Data</asp:LinkButton> 
        <ajaxToolkit:ConfirmButtonExtender ID="cbe1" runat="server" TargetControlID="lbDelete" ConfirmText="Will Delete Regression Data - Are You Sure?" >
            </ajaxToolkit:ConfirmButtonExtender>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
