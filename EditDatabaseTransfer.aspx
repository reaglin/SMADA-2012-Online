<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditDatabaseTransfer.aspx.cs" Inherits="SMADA_2012.EditDatabaseTransfer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div style="float:right;">
<asp:Label runat="server" id="lblPanel"></asp:Label>&nbsp;
<asp:LinkButton runat="server" ID="lbInstructions" Text="Instructions"></asp:LinkButton>
</div>
<asp:Panel runat="server" ID="pnlInstructions">
<br />
This allows the user to trigger an import of data. The data must first be converted into SQL Server
as a table. The data can be in any SQL Server database accessible through a SQL Connection String, incuding
the same database as the Destination database. You do not need to have a destination connection string, the
system will use the default connection for the destination. 
<br /><br />
To access the field mappings click <b>Edit Mappings</b>. This page has direction on how to map fields from 
the source to the destination database. Fields must be mapped from the source database to the destination
for data import to occur.
<br /><br />
To start the transfer click <b>Transfer Data</b>. This will start the transfer. This transfer can take a long 
time. If a set of data has already been imported, then the data will be udpated using any new mapping that 
has been supplied. 
<br /><br />
</asp:Panel>
    <asp:CollapsiblePanelExtender ID="pnlInstructions_CollapsiblePanelExtender" 
        runat="server" Enabled="True" TargetControlID="pnlInstructions" CollapsedText="Display"
         ExpandedText="Hide" TextLabelID="lblPanel" ExpandControlID="lbInstructions" 
          CollapseControlID="lbInstructions">
    </asp:CollapsiblePanelExtender>


<center>
<table class="defaultTable">
<tr>
<td class="defaultCell">
    <asp:Label ID="lblSourceID" runat="server" Text="Label"></asp:Label>
    </td>
<td class="defaultCell">
    <asp:TextBox ID="tbSourceID" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td class="defaultCell">
    <asp:Label ID="lblSourceConnectionString" runat="server" Text="Label"></asp:Label>
    </td>
<td class="defaultCell">
    <asp:TextBox ID="tbSourceConnectionString" runat="server" Width="500" TextMode="MultiLine" Height="100"></asp:TextBox>
    </td>
</tr>
<tr>
<td class="defaultCell">
    <asp:Label ID="lblDestConnectionString" runat="server" Text="Label"></asp:Label>
    </td>
<td class="defaultCell">
    <asp:TextBox ID="tbDestConnectionString" runat="server" Width="500" TextMode="MultiLine" Height="100" ></asp:TextBox>
    </td>
</tr>
<tr>
<td class="defaultCell">
    <asp:Label ID="lblRootTable" runat="server" Text="Label"></asp:Label>
    </td>
<td class="defaultCell">
    <asp:TextBox ID="tbRootTable" runat="server"></asp:TextBox>
    </td>
</tr>


</table>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" /> &nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Update" 
        onclick="btnSubmit_Click" />
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
