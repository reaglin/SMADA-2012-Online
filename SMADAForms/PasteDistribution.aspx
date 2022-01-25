<%@ Page Title="Enter/Edit Distribution Data" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="PasteDistribution.aspx.cs" Inherits="SMADA_2012.SMADAForms.PasteDistribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script language="javascript" type="text/javascript">
    function pasteContent() {
        document.getElementById('tbData').value = window.clipboardData.getData('Text');
        return (true);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<table>
<tr>
<td>
Enter Distribution Title:<asp:TextBox ID="tbTitle" runat="server" Width="300px" Visible="true"></asp:TextBox><br />
Enter Data:<br />
    <asp:TextBox ID="tbData" runat="server" ClientIDMode="Static" TextMode="MultiLine"  Height="400" Width="500" />
    <br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="actionButton" 
        onclick="btnSave_Click" Tooltip="Saves data to database, be sure to enter a title to easily identify the data."/>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/SMADAForms/ManageDistributions.aspx" 
    CssClass="actionButton" ToolTip="Do not forget to save before going to analysis screen.">Go to Manage Screen</asp:HyperLink><br />
</td>
<td style="width:500">
<br />
This is a sample of Distribution Data. You can enter more than one column at a time, but each column should
have the same number of data points. The first row is used as a data identifier (header). The columns can be separated
by a space, tab, comma, or semicolon. When the data is saved these will all be converted to tab characters. <br /><br />
    <asp:TextBox ID="tbSample" runat="server" TextMode="MultiLine"  Height="100" Width="500" Enabled="false"/>
    <br /><br />
To Paste Data from Excel or other spreadsheet: (1) Select and Copy in Excel (2) Click mouse into Text Box
 () Use Ctrl-V in to Paste int Text Box. First Row of spreadsheet data should be data headers.
</td>

</tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
