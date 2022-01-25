<%@ Page Title="Regression Analysis" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditRegression.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditRegression" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucScatterPlot.ascx" TagPrefix="uc1" TagName="ucScatterPlot" %>
<%@ Register Src="~/UserControls/ucPlotWindow.ascx" TagPrefix="uc1" TagName="ucPlotWindow" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1><br/>
        <h2><asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label></h2>
    <table style="margin: 0% 0% 0% 5%;">
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Enter Name</h3> (required to save)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Select Regression Method</h3>
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlMethod" runat="server" CssClass="DropDownList"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Enter XY Data</h3>
                            <br/>
                            Enter as X Y Pairs - one pair<br/>
                            per line - example: <br/><br/>
                            1.0 2.0<br/>
                            3.0 5.0<br/>
                            6.0 13.0<br/><br/>
                            separate X and Y with a space.<br/><br/>
                            You can also paste directly into text box from<br/>
                            a spreadsheet if data is in columns.
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbData" runat="server" TextMode="MultiLine" Width="160px" Height="340px"></asp:TextBox>  
                        </td>
                    </tr>
                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CausesValidation="false" CssClass="FormButton" />                            
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <uc1:ucHelpPopup runat="server" ID="ucHelpPopup" ObjectClass="Regression"/>
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false"  CssClass="FormButton" PostBackUrl="~/MenuSTATS.aspx" />
                            <uc1:ucPlotWindow runat="server" ID="ucPlotWindow" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
