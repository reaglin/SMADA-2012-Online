<%@ Page Title="Generate or Edit Rainfall" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditRainfall.aspx.cs" Inherits="SMADA2013.Pages.SMADA.EditRainfall" 
    ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucPlotWindow.ascx" TagPrefix="uc1" TagName="ucPlotWindow" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/highcharts.js" type="text/javascript"></script></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%: Page.Title %></h1>
        <asp:Panel ID="pnlEdit" runat="server">
                <table style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td class="TableLabelCell">
                            Enter Rainfall Name (required)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Rainfall Parameters
                        </td>
                        <td class="TableEntryCell">
                            <uc1:ucEditXmlPropertyObject runat="server" ID="ucRainfallParameters" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Rainfall Start (mm/dd/yy hh:mm)<br />
                            (optional)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbStartDate" runat="server" Width="229px" TextMode="DateTime"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Step 1</h3>
                            <h3>Select Method for Rainfall Entry</h3><br/>
                            <asp:Label ID="lblNoDim" runat="server" Text="No Dimensionless Rainfalls Exist - Hand Entry Only" 
                                Visible="false"></asp:Label>
                            <asp:RadioButtonList ID="rblRainfallMethod" runat="server" TextAlign="Right" 
                                AutoPostBack="True" OnSelectedIndexChanged="rblRainfallMethod_SelectedIndexChanged" 
                                RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="RadioButtonList" CausesValidation="False" ></asp:RadioButtonList><br/>
                            <br/>
                            <h3>
                            <asp:Label ID="lblSelectDimensionless" runat="server" Text="Select Dimensionless Curve to Generate Rainfall"></asp:Label></h3><br/><br/>
                            <asp:DropDownList ID="ddlDimensionlessCurves" runat="server" CssClass="DropDownList"></asp:DropDownList>
                            <asp:Button ID="btnDimCurve" runat="server" Text="Select" OnClick="btnDimCurve_Click" /><br/>
                            <asp:Label ID="lblErrors" runat="server" Text="" BackColor="Yellow"></asp:Label>
                        </td>
                        <td class="TableEntryCell">
                            <h3>Enter Rainfall Values</h3> single value per line:<br/>
                            <asp:TextBox ID="tbRainfall" runat="server" TextMode="MultiLine" Width="200" Height="250"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        <asp:Panel ID="pnlView" runat="server" Visible="False">
        <table style="margin:0% 0% 0% 5%">
            <tr>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" />
            </td>
        </tr> 
    </table>
     </asp:Panel>
    <br/>
<div style="margin:0% 0% 0% 5%">
                         <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="FormButton" />
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" CausesValidation="false"  />
                         <asp:Button ID="btnShow" runat="server" Text="Calculate" OnClick="btnShow_Click" CausesValidation="false"  CssClass="FormButton"/>
                         <asp:Button ID="btnCancel" runat="server" Text="Done" OnClick="btnCancel_Click" CausesValidation="false"  PostBackUrl="~/MenuHYDRO.aspx" CssClass="FormButton" />
                         <uc1:ucPlotWindow runat="server" ID="ucPlotWindow" Visible="False" />
                         <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="Rainfall"  />
                    <asp:Button ID="btnWatershed" runat="server" Text="Watershed" CausesValidation="false" PostBackUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=SMADA2013.App_Code.SMADA.Watershed"/>
                <asp:Button ID="btnHydrograph" runat="server" Text="Hydrograph" CausesValidation="false" PostBackUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=SMADA2013.App_Code.SMADA.Hydrograph"/>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
