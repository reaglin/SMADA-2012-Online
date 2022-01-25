<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="AnalyzeRegression.aspx.cs" Inherits="SMADA_2012.SMADAForms.AnalyzeRegression" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script src="../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../highcharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Panel runat="server" ID="pnlPlot" Visible="false">
    <asp:Literal runat="server" ID="litPlot"></asp:Literal><br /> 
</asp:Panel>
<table>
<tr>
<td>
    <asp:Button ID="btnAnalyze" runat="server" Text="Analyze Data" 
        CssClass="actionButton"  
        ToolTip="Analyzes and Fits to Regression" onclick="btnAnalyze_Click"/><br /><br />

    <asp:CheckBoxList ID="cblTypes" runat="server">
    </asp:CheckBoxList><br />

    <asp:Label runat="server" ID="lblRawData" CssClass="gridTitle" Text="Raw Data"></asp:Label>
    <br />
                <asp:GridView ID="gvData" runat="server" CellPadding="4" ForeColor="#333333" 
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
<td>
    <asp:Label runat="server" ID="lblParameters" CssClass="gridTitle" 
      Visible="false" Text="Curve Fit Parameters"></asp:Label><br />

                <asp:GridView ID="gvParam" runat="server" CellPadding="4" ForeColor="#333333" 
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
                </asp:GridView><br /><br />

    <asp:Label runat="server" ID="lblG2Title" CssClass="gridTitle" 
     Visible="false" Text="Fitted Data"></asp:Label><br />
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

</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
