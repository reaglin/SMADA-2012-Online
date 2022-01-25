<%@ Page Title="Calculate Exfiltration System Removal Efficiency" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditExfiltration.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditExfiltration" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>
<%@ Register Src="~/UserControls/ucSelectCatchment.ascx" TagPrefix="uc1" TagName="ucSelectCatchment" %>
<%@ Register Src="~/UserControls/ucNameAndDescription.ascx" TagPrefix="uc1" TagName="ucNameAndDescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1>
    <asp:Panel ID="pnlEdit" runat="server">
              <table style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td colspan='2'>
                            <uc1:ucNameAndDescription runat="server" id="ucNameAndDescription" />
                        </td>
                    </tr>
                  <tr>
                      <td colspan='2'>
                          <uc1:ucSelectCatchment runat="server" id="ucSelectCatchment" />
                      </td>
                  </tr>
                        <tr>
                            <td colspan="2"><h3>These values define the amount of storage available</h3></td>
                        </tr>

                    <tr>
                        <td class="TableLabelCell">
                            Enter Storage Properties<br/>
                        </td>
                        <td class="TableEntryCell">
                            <uc1:ucEditXmlPropertyObject runat="server" ID="ucParameters" />
                        </td>
                    </tr>
                  <tr>
                        <td colspan='2'>
                            <br/>
                         <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CausesValidation="false" CssClass="FormButton" />
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <uc1:ucHelpPopup runat="server" ID="ucHelpPopup" ObjectClass="Exfiltration" Image ="~/Images/exfitration.png"/>
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/MenuBMPTRAINS.aspx" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
    </asp:Panel>
    <asp:Panel ID="pnlOutput" runat="server" Visible="False">
    <table style="margin: 0% 0% 0% 5%;">
        <tr>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject"  Image ="~/Images/exfiltration.png" />
            </td>
        </tr>
        <tr>
            <td>
                <br/>
               <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" CssClass="FormButton" />                
               <asp:Button ID="btnSave2" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
               <asp:Button ID="btnUpdate2" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
               <uc1:ucHelpPopup runat="server" ID="ucHelpPopup1" ObjectClass="Exfiltration" Image ="~/Images/exfiltration.png"/>
                <asp:Button ID="btnDone2" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/DefaultLoggedIn.aspx" OnClick="btnDone2_Click" CssClass="FormButton" />
            </td>
        </tr>

    </table>
        </asp:Panel>
<br/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
