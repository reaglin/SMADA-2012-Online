<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageXMLPropertyObject.aspx.cs" Inherits="SMADA2013.Pages.ManageXMLPropertyObject" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h2> <asp:Label ID="lblObject" runat="server" Text=""></asp:Label></h2>
    <div style="float: left; margin: 2% 2% 0% 5% ;">
    <table>
        <tr><td style="text-align: center;">
         <asp:Button ID="btnNew" runat="server" Text="" OnClick="btnNew_Click" />
         </td></tr>
        <tr>
            <td style="text-align: center;">
            <h3>Your Data</h3><br/>
    <asp:GridView ID="gvData" runat="server" 
        CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="LastEditedDate" HeaderText="Last Edited" />
            <asp:TemplateField HeaderText="Select to Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="lbSelect" runat="server" CommandName="lbSelect" Text="Edit" CommandArgument='<%# Eval("id") %>' /> |
                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="lbDelete" Text="Delete" CommandArgument='<%# Eval("id") %>' /> |
                    <ajax:ConfirmButtonExtender runat="server" TargetControlID="lbDelete"
                       ConfirmText="Are you sure you want to delete this?" />
                    <asp:LinkButton ID="lbGlobal" runat="server" CommandName="lbGlobal" Text="Make Global" 
                        CommandArgument='<%# Eval("id") %>' ToolTip="Creates a Copy of the Data as Shared Global Access"/> |
                    <asp:LinkButton ID="lbReport" runat="server" CommandName="lbReport" Text="Report" CommandArgument='<%# Eval("id") %>' /> 

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#4197EE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        </td>
        </tr>
        <tr>
        <td style="text-align: center;">
            <h3>Global Items</h3> - These can be edited and saved as your own.<br/>
        <asp:GridView ID="gvGlobalData" runat="server" 
        CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="LastEditedDate" HeaderText="Last Edited" />
            <asp:TemplateField HeaderText="Select to Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="lbSelect" runat="server" CommandName="lbSelect" Text="Edit" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#4197EE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        </td>
        </tr>

        <tr><td style="text-align: center;">
            <br />
        <asp:Button ID="btnNew2" runat="server" Text="" OnClick="btnNew_Click" /><br/>
        <asp:Button ID="btnDone" runat="server" Text="Done" OnClick="btnDone_Click" />
        <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="OldObjectHelp" />
            </td></tr>
        </table>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
