<%@ Page Title="Circular Open Pipe Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditCircularChannel.aspx.cs" Inherits="SMADA2013.Pages.SMADA.EditCircularChannel" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucEditCircularPipe.ascx" TagPrefix="uc1" TagName="ucEditCircularPipe" %>
<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%: Page.Title %></h1>
    <table style="margin:0 0 0 5%">
     <tr>
      <td class="TableLabelCell"><uc1:ucEditCircularPipe runat="server" ID="ucEditCircularPipe" /></td>
      <td class="TableEntryCell">
           <uc1:ucOutputXmlPropertyObject runat="server" id="ucReport" />
      </td>
    </tr>
    </table><br/>
    <div style ="margin: 0 0 0 10%">
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton"/>
    <asp:Button ID="btnCalculateDepth" runat="server" Text="Calculate Depth" OnClick="btnCalculateDepth_Click" CssClass="FormButton" />
    <asp:Button ID="btnCalculateFlow" runat="server" Text="Calculate Flow" OnClick="btnCalculateFlow_Click" CssClass="FormButton" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="FormButton" />
    <asp:Button ID="btnManage" runat="server" Text="Done" OnClick="btnManage_Click" PostBackUrl="~/DefaultLoggedIn.aspx" CssClass="FormButton" />
        <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="CircularChannel" />
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
