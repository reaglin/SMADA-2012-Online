<%@ Page Title="Edit Dimensionless Rainfall" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDimensionlessRainfall.aspx.cs"
     Inherits="SMADA2013.Pages.SMADA.EditDimensionlessRainfall" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucPlotWindow.ascx" TagPrefix="uc1" TagName="ucPlotWindow" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/highcharts.js" type="text/javascript"></script></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%: Page.Title %></h1>
    <h2><asp:Label ID="lblValidate" runat="server" Text="" ForeColor="red" Visible="False"></asp:Label> </h2>
        <table style="margin-left:5%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Enter Dimensionless Rainfall Name</h3>(required to save)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td class="TableLabelCell">
                            <h3>Enter Dimensionless Rainfall Description</h3>
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDescription" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Enter Dimensionless Rainfall Values.</h3>
                            Put each value on a separate line.<br/>Values go cumulative from 0.0 to 1.0<br/>
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbRainfall" runat="server" TextMode="MultiLine" Width="200" Height="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan='2'>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" Visible="False" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" CausesValidation="false" />
                         <asp:Button ID="btnCancel" runat="server" Text="Done" CausesValidation="false"  PostBackUrl="~/MenuHYDRO.aspx" />
                         <asp:Button ID="btnShow" runat="server" Text="Calculate" OnClick="btnShow_Click" CausesValidation="false" />
                         <uc1:ucPlotWindow runat="server" id="ucPlotWindow" Visible="False" />
                         <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="DimensionlessRainfall" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
