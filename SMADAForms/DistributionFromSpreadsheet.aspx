<%@ Page Title="Distribution Analysis" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" 
CodeBehind="DistributionFromSpreadsheet.aspx.cs" Inherits="SMADA_2012.SMADAForms.DisitrubutionFromSpreadsheet" 
 ValidateRequest="false" %>
<%@ Register Src="~/UserControls/ucFormHeader.ascx" TagPrefix="uc" TagName="FormHeader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script src="../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Panel runat="server" ID="pnlPlot" Visible="false">
    <asp:Literal runat="server" ID="litPlot"></asp:Literal><br /> 
</asp:Panel>

<table><tr>
<td valign="top">
<table>
<tr>
<td>
    <asp:Button ID="btnAnalyze" runat="server" Text="Analyze Single Column" 
        CssClass="actionButton" onclick="btnAnalyze_Click" 
        ToolTip="Analyzes a Single Column using All Distributions"/><br />
</td>
<td>
        <asp:DropDownList ID="ddlTitle" runat="server" Visible="false" CssClass="submitButton">
        </asp:DropDownList><br /><br />
</td>
</tr>
</table>
<table>
<tr>
<td>
    <asp:Button ID="btnAnalyzeAll" runat="server" Text="Analyze All Columns" 
        CssClass="actionButton" onclick="btnAnalyzeAll_Click"
        ToolTip="Analyzes All Columns using the Selected Distribution Type"/><br />
</td>
<td>
    <asp:DropDownList ID="ddlDChoice" runat="server" Visible="true" CssClass="submitButton">
        </asp:DropDownList><br /><br />
</td>
</tr>
</table>

    <asp:Label runat="server" ID="lblRawData" CssClass="gridTitle" Text="Raw Data for Analysis"></asp:Label>
    <br />
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">                  
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:HiddenField ID="ClipboardContent" runat="server" ClientIDMode="Static" />
</td>

<td valign="top">
    <asp:Label runat="server" ID="lblG2Title" CssClass="gridTitle" Visible="false"></asp:Label><br />
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblM1" runat="server" Text="M1:" Visible="false"></asp:Label><br />
    <asp:Label ID="lblM2" runat="server" Text="M2:" Visible="false"></asp:Label><br />
    <asp:Label ID="lblM3" runat="server" Text="M3:" Visible="false"></asp:Label><br />
</td>
</tr></table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
