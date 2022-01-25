<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucScatterPlot.ascx.cs" Inherits="SMADA2013.UserControls.ucScatterPlot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

    <asp:Button ID="btnPlot" runat="server" Text="Plot" CausesValidation="false" />

    <ajax:modalpopupextender id="ModalPopupExtender1" runat="server" 
	    TargetControlID="btnPlot" PopupControlID="Panel1" 
	    CancelControlID ="btnDonePlot" backgroundcssclass="ModalPopupBG">
    </ajax:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	<div class="PopupPanel">
                <div class="PopupHeader" id="PopupHeader">Plot Window</div>
                <div class="PopupBody">
                     <highchart:ScatterChart id="hcPlot" runat="server" Width="1000" Height="550" /><br/>
                    <div style="text-align: center;" ><asp:Button ID="btnDonePlot" runat="server" Text="Done" /></div>
                </div>
        </div>
    </asp:panel>