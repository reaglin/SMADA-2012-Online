<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="DisplayReport.aspx.cs" 
    Inherits="SMADA2013.Pages.DisplayReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Page.Title %> </title>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/highcharts.js" type="text/javascript"></script>
</head>
<body>
    <h1>Report for <%: Page.Title %></h1><br/>
    <table style="margin: 0% 0% 0% 5%">
        <tr><td> <asp:Literal ID="litTable" runat="server"></asp:Literal></td></tr>
        <tr><td> <asp:Literal ID="litPlot" runat="server"></asp:Literal></td></tr>
    </table><br/>
    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
</body>
</html>
