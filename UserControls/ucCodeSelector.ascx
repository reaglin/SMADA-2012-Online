<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCodeSelector.ascx.cs" Inherits="SMADA_2012.UserControls.ucCodeSelector" %>
<asp:Panel ID="Panel1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="" CssClass="CodeSelectTitle"></asp:Label><br />
    <asp:RadioButtonList ID="rblCodes" runat="server" CssClass="CodeSelectRadioButtonList" >
    </asp:RadioButtonList><br />
    <asp:Button ID="btnSelect" runat="server" Text="Select" 
        CssClass="CodeSelectButton" onclick="btnSelect_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        CssClass="CodeSelectButton" onclick="btnCancel_Click" />
</asp:Panel>
