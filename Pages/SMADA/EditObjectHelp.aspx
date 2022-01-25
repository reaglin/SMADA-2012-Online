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
    <asp:Panel ID="pnlAddHelp" runat="server">
    <table style="margin:0% 0% 0% 5%;">            
             <tr><td>
                 <table>
                     <tr>
                        <td class="TableLabelCell">
                            Enter Object for Help
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbObject" runat="server" Width="498px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="TableLabelCell">
                            Enter Object Short Description
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDescription" runat="server" Width="498px"></asp:TextBox>
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
                 </asp:Panel>
                 <asp:Panel ID="pnlAddUrl" runat="server">
                 <table style="margin:0% 0% 0% 5%;">
                   <tr>
                        <td class="TableLabelCell">
                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="TableEntryCell">
                            <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
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
                            <asp:TextBox ID="tbUrlDescription" runat="server" Width="498px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td>
                             <asp:Literal ID="litHelp" runat="server"></asp:Literal>                             
                         </td> 
                        <td >
                         <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="FormButton" />
                         <asp:Button ID="btnDone2" runat="server" Text="Done" OnClick="btnCancel_Click" CausesValidation="false" CssClass="FormButton"  />

                        </td>
                    </tr>
                 </table>
            </asp:Panel>
    <uc1:ucHelpPopup runat="server" ID="ucHelpPopup1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
