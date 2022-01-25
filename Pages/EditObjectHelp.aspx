<%@ Page Title="Edit or Add Help for Objects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditObjectHelp.aspx.cs" 
    Inherits="SMADA2013.Pages.EditObjectHelp" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1>
    Note that help items entered by a user will be available to all users in the system. Either enter
    simple text help (notes for yourself or other users, or enter a URL with a simple description of
    the contents. These will be available on the help entry screens for others.
    <table style="margin:0% 0% 0% 5%;">            
             <tr><td>
                 <table>
                     <tr>
                        <td class="TableLabelCell">
                            Select Object for Help
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlObjects" runat="server" AutoPostBack="True" 
                                 CssClass="DropDownList" OnSelectedIndexChanged="ddlObjects_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="TableLabelCell">
                            Enter Help URL
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbHelpUrl" runat="server" Width="498px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter URL Description
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Youtube Video ID
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbYoutubeId" runat="server" ></asp:TextBox>
                        </td>
                    </tr>

                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <asp:Button ID="btnCancel" runat="server" Text="Done" OnClick="btnCancel_Click" CausesValidation="false" CssClass="FormButton"  />
                            <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="ObjectHelp" />
                        </td>
                    </tr>
                </table>
            </td>
    <td>
           <asp:GridView ID="gvHelp" runat="server" 
        CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
        <Columns>
           <asp:TemplateField HeaderText="Help Link">
                <ItemTemplate>
                    <asp:HyperLink ID="hlHelp" runat="server" NavigateUrl=<%# Eval("HelpUrl") %> 
                        Target="_new" ToolTip=<%# Eval("Description") %>>Click Here</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="HelpText" HeaderText="Help Text" />
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
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
