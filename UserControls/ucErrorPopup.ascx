<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucErrorPopup.ascx.cs" Inherits="SMADA2013.UserControls.ucErrorPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
    
<asp:Button ID="btnHidden" runat="server" Text="" CausesValidation="false" Visible="false"/>

<ajax:modalpopupextender id="mpeErrors" runat="server" 
	    TargetControlID="btnHidden" PopupControlID="Panel1" 
	    CancelControlID ="btnDone" backgroundcssclass="ModalPopupBG">
</ajax:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	<div class="PopupPanel">
                <div class="PopupHeader" id="PopupHeader">User Messages</div>
                <div class="PopupBody">
                     <asp:Label id="lblMessage" runat="server" Width="500" Height="600" /><br/>
                    <div style="text-align: center;" ><asp:Button ID="btnDone" runat="server" Text="Done" /></div>
                </div>
        </div>
    </asp:panel>