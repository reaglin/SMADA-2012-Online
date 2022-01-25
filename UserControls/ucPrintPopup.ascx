<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPrintPopup.ascx.cs" Inherits="SMADA2013.UserControls.ucPrintPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

    <asp:LinkButton ID="btnPrint" runat="server" Text="Print" CausesValidation="false" />

    <ajax:modalpopupextender id="ModalPopupExtender1" runat="server" 
	    TargetControlID="btnPrint" PopupControlID="Panel1" 
	    CancelControlID ="btnDone" backgroundcssclass="ModalPopupBG">
    </ajax:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	<div class="PopupPanel">
                <div class="PopupHeader" id="PopupHeader">Plot Window</div>
                <div class="PopupBody">
                     <asp:Literal id="litResults" runat="server" /><br/>
                    <div style="text-align: center;" >
                        <asp:LinkButton ID="btnDone" runat="server" Text="Done" /> |
                        <asp:LinkButton ID="btnSend" runat="server" Text="Send to Printer" OnClientClick="javascript:window.print();" />
                    </div>
                </div>
        </div>
    </asp:panel>