<%@ Page Title="Import Lookup Table" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportLookupTable.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.ImportLookupTable" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1>
    <asp:Panel ID="pnlEdit" runat="server">
               <asp:Button ID="btnImport2" runat="server" Text="Import" OnClick="btnImport_Click" /><br/>
              <table style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td class="TableLabelCell">
                            Paste
                        </td>
                        <td>
                            <asp:TextBox ID="tbData" runat="server" TextMode="MultiLine" Width="1200" Height="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" />
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/DefaultLoggedIn.aspx" />
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
               <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" />   
               <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
               <asp:Button ID="btnDone2" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/DefaultLoggedIn.aspx" OnClick="btnDone2_Click" />
            </td>
        </tr>

    </table>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
