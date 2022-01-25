<%@ Page Title="Calculate Pollutant Loads for Catchment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCatchment.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditCatchment" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1>
    <asp:Panel ID="pnlEdit" runat="server" >
                <table  style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td class="TableLabelCell">
                            Enter Name (required)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server" Width="261px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Description 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDescription" runat="server" Width="521px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Select Zone 
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlZone" runat="server" CssClass="DropDownList"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="TableLabelCell">
                            Select Pre-Condition Land Use 
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlPreLandUse" runat="server" CssClass="DropDownList"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Select Post-Condition Land Use 
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlPostLandUse" runat="server" CssClass="DropDownList"></asp:DropDownList> 
                        </td>
                    </tr>

                    <tr>
                        <td class="TableLabelCell">
                            Enter Properties
                        </td>
                        <td class="TableEntryCell">
                            <uc1:ucEditXmlPropertyObject runat="server" ID="ucParameters" />
                        </td>
                    </tr>
                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CssClass="FormButton" CausesValidation="false" />
                         <uc1:ucHelpPopup runat="server" ID="ucHelpPopup" ObjectClass="Catchment" VideoId="ipjvRt2YgJ8"/>
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false" PostBackUrl="~/MenuBMPTRAINS.aspx" CssClass="FormButton" />
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
               <asp:Button ID="btnSave2" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
               <asp:Button ID="btnUpdate2" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
               <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" />
               <asp:Button ID="btnCalculate2" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CssClass="FormButton" CausesValidation="false" />
               <uc1:ucHelpPopup runat="server" ID="ucHelpPopup1" ObjectClass="Catchment" VideoId="ipjvRt2YgJ8"/>
               <asp:Button ID="btnDone2" runat="server" Text="Done" CausesValidation="false" PostBackUrl="~/MenuBMPTRAINS.aspx" CssClass="FormButton" />
            </td>
        </tr>

    </table>
  </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
