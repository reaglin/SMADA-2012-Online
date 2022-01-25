<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFormHeader.ascx.cs" Inherits="SMADA_2012.UserControls.ucFormHeader" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <span style="float:left">
        <asp:LinkButton ID="lbClose1" runat="server" ToolTip="Close Help Box">&uarr;</asp:LinkButton>
        <asp:LinkButton ID="lbOpen1" runat="server" ToolTip="Open Help Box">&darr;</asp:LinkButton>
        <asp:LinkButton runat="server" ID="lbEdit" Font-Size="XX-Small" onclick="lbEdit_Click" Text="Edit"></asp:LinkButton>
    </span>
    <asp:HiddenField ID="hidden" runat="server" />
<asp:Panel ID="PanelFormheader" runat="server" CssClass="PanelFormHeader">
<asp:Literal ID="literalHeader" runat="server"></asp:Literal>
 <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" 
 CollapseControlID="lbClose1" ExpandControlID="lbOpen1" TargetControlID="PanelFormheader" 
 ExpandDirection="Horizontal" CollapsedSize="0"  >
 </ajaxToolkit:CollapsiblePanelExtender>
</asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>
