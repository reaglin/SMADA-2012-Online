<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHelpPopup.ascx.cs" Inherits="SMADA2013.UserControls.ucHelpPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
    
<asp:Button ID="btnHelp" runat="server" Text="Help" CausesValidation="false" CssClass="FormButton"/>

<ajax:modalpopupextender id="mpeErrors" runat="server" 
	    TargetControlID="btnHelp" PopupControlID="Panel1" 
	    CancelControlID ="btnDone" backgroundcssclass="HelpPopupBG">
</ajax:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	<div style="min-width:200px;min-height:150px;background-color:wheat;">
    <div id="PopupHeader" style="background-color: lightcyan">
        <div style="float: left; font-size:larger">User Help for <asp:Label ID="lblObject" runat="server" Text="Object"></asp:Label></div>
        <div style="float: right; font-size:larger"><asp:LinkButton ID="btnDone" runat="server" Text="Done" /></div>
    </div>
    <div style="background-color:white;">
   <asp:Image ID="image" runat="server" Visible="false" /><br/>
        <div style="margin-left:5%">
    <asp:Label ID="LabelShowYouTubeVideo" runat="server"></asp:Label><br/>
        </div><br/>
    </div>
    </div>
   <div style="text-align: center; background-color:wheat;" >
    <h3>Additional Help Links for <asp:Label ID="lblObject2" runat="server" Text="Object"></asp:Label></h3> <br/>
       <asp:HyperLink ID="hlDocumentation" runat="server" NavigateUrl="https://smadaonline.pbworks.com/">SMADA Documentation</asp:HyperLink>
       <br/>   
       <asp:Literal ID="litHelpLinks" runat="server"></asp:Literal>
       </div>
    </asp:panel>