<%@ Page Title="Enter/Edit Pervious Pavement Types" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPerviousPavementTypeList.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditPerviousPavementTypeList" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>
<%@ Register Src="~/UserControls/ucPlotWindow.ascx" TagPrefix="uc1" TagName="ucPlotWindow" %>
<%@ Register Src="~/UserControls/ucEditPerviousPavementTypeList.ascx" TagPrefix="uc1" TagName="ucEditPerviousPavementTypeList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/highcharts.js" type="text/javascript"></script>
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
                            <asp:TextBox ID="tbName" runat="server" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="TableLabelCell">
                            Enter Values<br/>
                        </td>
                        <td class="TableEntryCell">
                            <uc1:ucEditPerviousPavementTypeList runat="server" id="ucEditPerviousPavementTypeList" />
                        </td>
                    </tr>
                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <asp:Button ID="btnAdd" runat="server" Text="Add Row" OnClick="btnAddRow_Click" CssClass="FormButton" />
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/MenuBMPTRAINS.aspx" CssClass="FormButton" />
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
<br/>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
