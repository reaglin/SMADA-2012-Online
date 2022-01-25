<%@ Page Title="Edit Lookup Table" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditLookupTable.aspx.cs" 
    Inherits="SMADA2013.Pages.EditLookupTable" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 <h1><%: Page.Title %> </h1>
    <asp:Panel ID="pnlEdit" runat="server" Visible="true">
                <table style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td class="TableEntryCell">
                            Enter Name (required)
                        </td>
                        <td class="TableLabelCell">
                            <asp:TextBox ID="tbName" runat="server" Width="432px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableEntryCell">
                            Enter Description 
                        </td>
                        <td class="TableLabelCell">
                            <asp:TextBox ID="tbDescription" runat="server" Width="547px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableEntryCell">
                            Enter Decimal Places  
                        </td>
                        <td class="TableLabelCell">
                            Row:<asp:TextBox ID="tbRowDP" runat="server" Width="60px"/> Column:<asp:TextBox ID="tbColDP" runat="server" Width="61px"/> Data:<asp:TextBox ID="tbDataDP" runat="server" Width="61px"/>
                        </td>
                    </tr>

                    <tr>
                        <td class="TableEntryCell">
                            Enter Properties
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>Row Title:<br/> <asp:TextBox ID="tbRowTitle" runat="server" TextMode="MultiLine" Width="60" ></asp:TextBox><br/>
                                    </td>
                                    <td>
                                        Column Title: <asp:TextBox ID="tbColTitle" runat="server" Width="406px"></asp:TextBox><br/>
                                         <asp:TextBox ID="tbColData" runat="server" Width="700"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbRowData" runat="server" TextMode="MultiLine" Width="60" Height="600"></asp:TextBox> </td>
                                    <td>
                                        <asp:TextBox ID="tbData" runat="server" TextMode="MultiLine" Width="700" Height="600" ToolTip="Enter Data - Enter New Line at End of Each Row."></asp:TextBox> </td>
                                </tr>
                            </table>
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
    <asp:Panel ID="pnlOutput" runat="server" Visible="false">
    <div style="margin: 0% 0% 0% 5%;">
    <table>
        <tr>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" />
            </td>
            </tr>
            <tr>
            <td>
              Row Value for Lookup: <asp:TextBox ID="tbRowVal" runat="server" ></asp:TextBox>
              Column Value for Lookup: <asp:TextBox ID="tbColVal" runat="server"></asp:TextBox>
                Result: <asp:TextBox ID="tbResult" runat="server" Enabled="false"></asp:TextBox>
                <br/>
              Lookup Row: <asp:Label ID="lblRow" runat="server" Text=""></asp:Label><br/>
             <br/>
            </td>
            </tr>
    </table>
    <asp:Button ID="btnCalculate2" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CausesValidation="false" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CausesValidation="false" />
        </div></asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
