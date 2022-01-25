<%@ Page Title="Template Title" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTemplate.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditTemplate" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1>
    <asp:Panel ID="pnlEdit" runat="server">
              <table style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td class="TableLabelCell">
                            Enter Name (required)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Description 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Properties
                        </td>
                        <td>
                            <uc1:ucEditXmlPropertyObject runat="server" ID="ucParameters" />
                        </td>
                    </tr>
                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CausesValidation="false" CssClass="FormButton" />
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/DefaultLoggedIn.aspx" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>

    </asp:Panel>
    <asp:Panel ID="pnlOutput" runat="server" Visible="False">
    <table style="margin: 0% 0% 0% 5%;">
        <tr>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" />
            </td>
        </tr>
        <tr>
            <td>
               <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" CssClass="FormButton" />                
               <asp:Button ID="btnDone2" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/DefaultLoggedIn.aspx" OnClick="btnDone2_Click" CssClass="FormButton" />
            </td>
        </tr>

    </table>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
