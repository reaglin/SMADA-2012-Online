<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucOutputXmlPropertyObject.ascx.cs" Inherits="SMADA2013.UserControls.ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucPrintPopup.ascx" TagPrefix="uc1" TagName="ucPrintPopup" %>

<script>
    function copyToClipboard() {
        var text= document.getElementById('selectText').innerHTML;
        window.prompt ("Copy to clipboard: Ctrl+C, Enter", text);
}
</script>

<asp:LinkButton ID="lbTableView" runat="server" OnClick="lbTableView_Click" 
    ToolTip="Display as a rendered HTML table in the browser window"  CausesValidation="False">Table View</asp:LinkButton> | 
<asp:LinkButton ID="lbCopy" runat="server" OnClientClick="copyToClipboard()" Visible="False">Copy</asp:LinkButton>
<asp:LinkButton ID="lbPrint" runat="server" OnClick="lbPrint_Click" OnClientClick="aspnetForm.target ='_new';" CausesValidation="False">Report View</asp:LinkButton>
<asp:LinkButton ID="lbXmlView" runat="server" OnClick="lbXmlView_Click" Visible="False"
    ToolTip="Display as XML that can be copied for export and import">XML View</asp:LinkButton>
<asp:LinkButton ID="lbCodeView" runat="server" OnClick="lbCodeView_Click" Visible="False"
    ToolTip="Display as code that can be copied for export and import">Code</asp:LinkButton>
<br />
<table><tr><td>
<span id="selectText">
<asp:Literal ID="litReport" runat="server"></asp:Literal>
</span>
<asp:TextBox ID="tbXML" runat="server" Visible="false" TextMode="MultiLine" ></asp:TextBox>
<asp:TextBox ID="tbCode" runat="server" Visible="false" TextMode="MultiLine" ></asp:TextBox>
 </td>
 <td>
     <asp:Image ID="image" runat="server" Visible="false" /><br/>
 </td>
 </tr>
</table>