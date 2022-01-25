<%@ Page Title="Input or Edit Watershed Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditWatershed.aspx.cs" Inherits="SMADA2013.Pages.SMADA.EditWatershed" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%: Page.Title %> </h1> 
    <h2><asp:Label ID="lblValidate" runat="server" Text="" Visible="False" ForeColor="red"></asp:Label></h2>
<table><tr><td>
    <table style="margin-left:5%">
        <tr>
            <td class="TableLabelCell">Name of Watershed (required to save)</td>
            <td class="TableEntryCell">
                <asp:TextBox ID="tbName" runat="server" Width="261px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
           </td>
        </tr>
        <tr>
            <td class="TableLabelCell">Enter Characteristic Watershed Parameters</td>
            <td class="TableEntryCell"><uc1:ucEditXmlPropertyObject runat="server" id="ucWatershedInput" LabelWidth="250" /> </td>
        </tr>
        <tr>
            <td class="TableLabelCell">Enter Infiltration Parameters</td>
            <td class="TableEntryCell">
                <uc1:ucEditXmlPropertyObject runat="server" ID="ucInfiltrationInputSCS" LabelWidth="250"/>
            </td>
        </tr>
        <tr>
            <td colspan='2'>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" CausesValidation="false"  />
                <asp:Button ID="btnShow" runat="server" Text="Calculate" OnClick="btnShow_Click" CausesValidation="false" />
                <asp:Button ID="btnCancel" runat="server" Text="Done" OnClick="btnCancel_Click" CausesValidation="false"  PostBackUrl="~/MenuHYDRO.aspx" />
                <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="Watershed" />
                <asp:Button ID="btnRainfall" runat="server" Text="Rainfall" CausesValidation="false" PostBackUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=SMADA2013.App_Code.SMADA.Rainfall"/>
                <asp:Button ID="btnHydrograph" runat="server" Text="Hydrograph" CausesValidation="false" PostBackUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=SMADA2013.App_Code.SMADA.Hydrograph"/>

           </td>
        </tr>
    </table>
    </td>
    <td>
        <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" Visible="False" /> </td>
    </tr></table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
