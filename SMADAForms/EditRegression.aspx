<%@ Page Title="Enter or Edit Regression Data" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditRegression.aspx.cs" Inherits="SMADA_2012.SMADAForms.EditRegression" %>
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
Enter Regression Title:<asp:TextBox ID="tbTitle" runat="server" Width="300px" Visible="true" Text="Required Description"></asp:TextBox><br />
<br />
To Paste Data: (1) Select and Copy in Excel (2) Use Ctrl-V in to Paste int Text Box Below<br />
Regression Data does not have data headers, data should be organized as X, Y<br />
    <asp:TextBox ID="tbData" runat="server" ClientIDMode="Static" TextMode="MultiLine"  
    Height="400" Width="300" />
    <br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save Data" CssClass="actionButton" 
        onclick="btnSave_Click" ToolTip="Saves Data in Database, enter Title for easy retrieval"/>
    <asp:Button ID="btnSaveAsNew" runat="server" Text="Save as New" CssClass="actionButton" 
         ToolTip="Saves Data in Databaseas new entry" 
        onclick="btnSaveAsNew_Click"/>
        
        <br /><br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/SMADAForms/ManageRegressions.aspx" 
    CssClass="actionButton" 
    ToolTip="Manage Screen allows for analysis of data, save data first.">Go to Manage Screen</asp:HyperLink><br />
</td>
<td style="width:400px">
This is an example of how to enter data. Data should be entered as X Y pairs. Data can be separated by
a comma (,), a semicolon (;), a space, or a tab character. The program will automatically parse the data
and convert it to tab delimited when you save it. Tab delimited data can be copy and pasted between the program
and most spreadsheets. Do not enter lines after the last line of data.<br />

    <asp:TextBox ID="tbSample" runat="server" ClientIDMode="Static" 
    TextMode="MultiLine" Height="200" Width="300" Enabled="false" />
    <br /></td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
