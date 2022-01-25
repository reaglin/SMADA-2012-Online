<%@ Page Title="Edit SQL Query - Reports" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditSQLQuery.aspx.cs" Inherits="SMADA_2012.EditSQLQuery" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div style="float:right;">
<asp:Label runat="server" id="lblEdit"></asp:Label>&nbsp;
<asp:LinkButton runat="server" ID="lbEdit" Text="SQL Query Controls"></asp:LinkButton>
</div>

<asp:Panel runat="server" ID="pnlEdit">
<center>
<table class="defaultTable">
<tr>
<td class="defaultCell">
    <asp:Label ID="lblName" runat="server" Text="Query Name"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:TextBox runat="server" ID="tbName" Width="150"></asp:TextBox>
</td>
</tr>
<tr>
<td class="defaultCell">
    <asp:Label ID="Label1" runat="server" Text="Query Description"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:TextBox runat="server" ID="tbDescription" Width="500"></asp:TextBox>
</td>
</tr>
<tr>
<td class="defaultCell">
    <asp:Label ID="Label2" runat="server" Text="SQL Query Text"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:TextBox runat="server" ID="tbSQL" Width="500" TextMode="MultiLine" Height="400"></asp:TextBox>
</td>
</tr>


</table>
<br />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" /> &nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" /> &nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
        onclick="btnDelete_Click" />
</center>
</asp:Panel>
<asp:CollapsiblePanelExtender ID="pnlEdit_CollapsiblePanelExtender" 
        runat="server" Enabled="True" TargetControlID="pnlEdit" CollapsedText="Display"
         ExpandedText="Hide" TextLabelID="lblPanel" ExpandControlID="lbEdit" 
          CollapseControlID="lbEdit" Collapsed="true">
    </asp:CollapsiblePanelExtender>
<center>
<br /><br />
<asp:DataGrid runat="server" ID="dgData" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AllowPaging="True" PageSize="25" OnPageIndexChanged="gvData_Change"
             AutoGenerateColumns="true" >
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <EditItemStyle BackColor="#999999" />
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" 
            Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        </asp:DataGrid>
</center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
