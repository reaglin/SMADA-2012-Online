<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHydrograph.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditHydrograph" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucPlotWindow.ascx" TagPrefix="uc1" TagName="ucPlotWindow" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/highcharts.js" type="text/javascript"></script>
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1>Generate Hydrograph</h1>
    <asp:Label ID="lblErrors" runat="server" Text="" Visible="False" CssClass="LabelErrors"></asp:Label>
    <table style="margin: 0% 0% 0% 5%;" >
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Enter Hydrograph Name<br/> (required to save)</h3>
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Step 1<br/> Select Rainfall and Watershed</h3>
                        </td>
                        <td class="TableEntryCell">
                            <h3>Select Watershed:</h3>
                            <asp:DropDownList ID="ddlWatershed" runat="server" CssClass="DropDownList"></asp:DropDownList>
                            <h3>Select Rainfall:</h3>
                            <asp:DropDownList ID="ddlRainfall" runat="server" CssClass="DropDownList"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            <h3>Step 2<br/>
                            Hydrograph Generation Method</h3><br/>
                        </td>
                        <td class="TableEntryCell">
                            <h3>Select From List</h3>
                            <br/>
                            <asp:DropDownList ID="ddlHydrographMethod" runat="server" CssClass="DropDownList"></asp:DropDownList>
          
                        </td>
                    </tr>
                    
                        <tr>
                        <td colspan="2">
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" CausesValidation="false"  />
                         <asp:Button ID="btnShow" runat="server" Text="Calculate" OnClick="btnShow_Click" CausesValidation="false" />
                         <asp:Button ID="btnCancel" runat="server" Text="Manage" OnClick="btnCancel_Click" CausesValidation="false"  PostBackUrl="~/MenuHYDRO.aspx" />
                         <uc1:ucPlotWindow runat="server" ID="ucPlotWindow" />
                         <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="Hydrograph" />
                         <asp:Button ID="btnRainfall" runat="server" Text="Rainfall" CausesValidation="false" PostBackUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=SMADA2013.App_Code.SMADA.Rainfall"/>
                         <asp:Button ID="btnWatershed" runat="server" Text="Watershed" CausesValidation="false" PostBackUrl="~/Pages/ManageXMLPropertyObject.aspx?Class=SMADA2013.App_Code.SMADA.Watershed"/>

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
