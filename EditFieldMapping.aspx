<%@ Page Title="Manage Data Import Mappings" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditFieldMapping.aspx.cs" Inherits="SMADA_2012.EditFieldMapping" %>
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
This is an administrative screen that allows you to set up mapping for data import from one database
to the SAR Database. Each field to be mapped from the source can be a coded field or a free field.
For coded fields a Source Value and Destination Value must be specified. Any field in the source database
with a specific code will be translated to the Destination Code. If the Destination Field is Coded, then
a <b>Destination Category</b> must be specied. Only mapped fields will be imported. 
<br /><br />
If a field is a free text field then leave <b>Source Value</b>, <b>Destination Category</b>, and <b>Destination
Value</b> blank.
<br /><br />
The fields <b>Source Table</b>, <b>Source Field</b>, <b>Destination Table</b>, and <b>Destination Field</b> are
all required fields.
<br /><br />
</asp:Panel>
    <asp:CollapsiblePanelExtender ID="pnlInstructions_CollapsiblePanelExtender" 
        runat="server" Enabled="True" TargetControlID="pnlInstructions" CollapsedText="Display"
         ExpandedText="Hide" TextLabelID="lblPanel" ExpandControlID="lbInstructions" 
          CollapseControlID="lbInstructions" Collapsed="true">
    </asp:CollapsiblePanelExtender>
<center>
<table class="defaultTable">
<tr>
<td class="defaultCell">
    <asp:Label ID="Label1" runat="server" Text="Source ID"></asp:Label>
    </td>
<td class="defaultCell">
    <asp:Label ID="lblSourceID" runat="server"></asp:Label>
    </td>
    <td class="defaultCell">
    <asp:Label ID="lblDestCategory" runat="server" Text="Destination Category"></asp:Label>
    </td>
    <td class="defaultCellL">
    <asp:ComboBox ID="cbDestCategory" runat="server" AutoPostBack="True" 
        onselectedindexchanged="cbDestCategory_SelectedIndexChanged"></asp:ComboBox>&nbsp;
    <asp:HyperLink runat="server" ID="hlCategory" NavigateUrl="~/EditCategory.aspx" Text="Create New" Target="_blank"></asp:HyperLink>        
    </td>

</tr>

<tr>
<td class="defaultCell">
    <asp:Label ID="lblSourceTable" runat="server" Text="Source Table"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:ComboBox ID="cbSourceTable" runat="server" AutoPostBack="True" 
        onselectedindexchanged="cbSourceTable_SelectedIndexChanged"></asp:ComboBox>
    </td>
    <td class="defaultCell">
    <asp:Label ID="lblDestTable" runat="server" Text="Destination Table"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:ComboBox ID="cbDestTable" runat="server" AutoPostBack="True" 
        onselectedindexchanged="cbDestTable_SelectedIndexChanged"></asp:ComboBox>
    </td>
</tr>

<tr>
<td class="defaultCell">
    <asp:Label ID="lblSourceField" runat="server" Text="Source Field"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:ComboBox ID="cbSourceField" runat="server" AutoPostBack="True" 
        onselectedindexchanged="cbSourceField_SelectedIndexChanged"></asp:ComboBox>
    </td>
    <td class="defaultCell">
    <asp:Label ID="lblDestField" runat="server" Text="Destination Field"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:ComboBox ID="cbDestField" runat="server"></asp:ComboBox>
    </td>


</tr>

<tr>
    <td class="defaultCell">
    <asp:Label ID="lblSourceValue" runat="server" Text="Value"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:ComboBox ID="cbSourceValue" runat="server"></asp:ComboBox>
    <asp:LinkButton runat="server" ID="lbValues" Text="Values" 
        onclick="lbValues_Click"></asp:LinkButton>
    </td>

<td class="defaultCell">
    <asp:Label ID="lblDestValue" runat="server" Text="Destination Value"></asp:Label>
    </td>
<td class="defaultCellL">
    <asp:ComboBox ID="cbDestValue" runat="server"></asp:ComboBox>&nbsp;
    </td>

</tr>

</table>
<br />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" /> &nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" /> &nbsp;
    <asp:Button ID="btnSubmitAgain" runat="server" Text="Submit All Source Values" onclick="btnSubmitAgain_Click" 
      ToolTip="This Will Add All Source Codes to Codes and Create Mapping"  />  &nbsp;

    <asp:Button ID="btnKeyFields" runat="server" Text="Set As Key Field" 
      
        ToolTip="The specified tables and fields in source and destination are table keys" 
        onclick="btnKeyFields_Click"  />  &nbsp;

    <asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click" />
    
<hr />
<asp:DataGrid ID="dgFM" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" Visible="true" OnItemCommand="dgFM_OnItemCommand">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>        
        <asp:BoundColumn DataField="SourceIDName" HeaderText="Source ID" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="SourceTableName" HeaderText="Source Table"></asp:BoundColumn>
        <asp:BoundColumn DataField="SourceFieldName" HeaderText="Source Field"></asp:BoundColumn>        
        <asp:BoundColumn DataField="SourceValue" HeaderText="Value"></asp:BoundColumn>    
        <asp:BoundColumn DataField="DestTableName" HeaderText="Source Table"></asp:BoundColumn>
        <asp:BoundColumn DataField="DestFieldName" HeaderText="Source Field"></asp:BoundColumn>        
        <asp:BoundColumn DataField="DestCategory" HeaderText="Category"></asp:BoundColumn>    
        <asp:BoundColumn DataField="DestValue" HeaderText="Value"></asp:BoundColumn>            
        <asp:BoundColumn DataField="KeyFieldsBit" HeaderText="Import Key"></asp:BoundColumn>            
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName="delete" CommandArgument='<%#Eval("FieldMappingID") %>' CssClass="gridButton"></asp:LinkButton>
                       
        </ItemTemplate></asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
</center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
