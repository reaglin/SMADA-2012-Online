<%@ Page Title="Database Transfers/Data Import" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ViewDataTransfers.aspx.cs" Inherits="SMADA_2012.ViewDataTransfers" %>
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

<asp:DataGrid ID="dgTransfers" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" Visible="true" OnItemCommand="dgTransfers_OnItemCommand">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>        
        <asp:BoundColumn DataField="SourceIDName" HeaderText="Source" ></asp:BoundColumn>         
        <asp:BoundColumn DataField="SourceConnectionString" HeaderText="Source Connection String" ></asp:BoundColumn>         
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center" > <ItemTemplate>
        <asp:HyperLink runat="server" id="hlCodes" Text="New Transfer" 
                        NavigateUrl="~/EditDatabaseTransfer.aspx" CssClass="gridButton"></asp:HyperLink> |

        <asp:HyperLink runat="server" id="hlEdit" Text="Edit Transfer" 
                        NavigateUrl='<%# "~/EditDatabaseTransfer.aspx?DatabaseTransferID=" + DataBinder.Eval(Container.DataItem, "DatabaseTransferID") %>' CssClass="gridButton"></asp:HyperLink>

        <br />
        <asp:HyperLink runat="server" id="hlMappings" Text="Edit Column Mappings" 
                        NavigateUrl='<%# "~/EditFieldMapping.aspx?DatabaseTransferID=" + DataBinder.Eval(Container.DataItem, "DatabaseTransferID") %>' CssClass="gridButton"></asp:HyperLink> | 

         
         <asp:LinkButton runat="server" ID="lbPrint" CommandName="print" CommandArgument='<%#Eval("DatabaseTransferID") %>' Text="Print Column Mappings" CssClass="gridButton"></asp:LinkButton>
         
         <br />
         
         <asp:LinkButton runat="server" ID="lbGo" CommandName="go" CommandArgument='<%#Eval("DatabaseTransferID") %>' Text="Start Data Transfer" CssClass="gridButton"></asp:LinkButton>
         
        </ItemTemplate></asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
<asp:Label runat="server" ID="lblMessage" ></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
