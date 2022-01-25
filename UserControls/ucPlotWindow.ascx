<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPlotWindow.ascx.cs" Inherits="SMADA2013.UserControls.ucPlotWindow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

    <asp:Button ID="btnPlot" runat="server" Text="Plot" CausesValidation="false" />

    <ajax:modalpopupextender id="ModalPopupExtender1" runat="server" 
	    TargetControlID="btnPlot" PopupControlID="Panel1" 
	    CancelControlID ="btnDonePlot" backgroundcssclass="ModalPopupBG">
    </ajax:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server" Width="80%" Height="80%">
	<div class="PopupPanel">
                <div class="PopupHeader" id="PopupHeader">Plot Window</div>
                <div class="PopupBody">
                     <asp:Literal id="litChart" runat="server" /><br/>
                    <div style="text-align: center;" ><asp:Button ID="btnDonePlot" runat="server" Text="Done" /></div>
                </div>
        </div>
    </asp:panel>