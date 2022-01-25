<%@ Page Title="Manage Hydrographs" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="SelectHydrograph.aspx.cs" Inherits="SMADA_2012.SMADAForms.SelectHydrograph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div class="inputForm">
<asp:DataGrid ID="gvHydrographs" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" OnItemCommand="gvHydrographs_OnRowCommand" Align="center">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <AlternatingItemStyle BackColor="White"  />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>
        <asp:BoundColumn DataField="id" HeaderText="ID" ></asp:BoundColumn>     
        <asp:BoundColumn DataField="WatershedID" HeaderText="ID" Visible="false" ></asp:BoundColumn>     
        <asp:BoundColumn DataField="RainfallID" HeaderText="ID" Visible="false"></asp:BoundColumn>     
        <asp:BoundColumn DataField="Title" HeaderText="Title"></asp:BoundColumn>       
        <asp:BoundColumn DataField="HydrographMethod" HeaderText="Method"></asp:BoundColumn>    
        <asp:BoundColumn DataField="TotalArea" HeaderText="Total Area"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:LinkButton runat="server" id="lbEdit" Text="Edit Hydrograph"  CommandName ="editHydrograph" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbEditWatershed" Text="Edit Watershed"  CommandName ="editWatershed" 
                CommandArgument='<%#Eval("WatershedID") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbEditRainfall" Text="Edit Rainfall"  CommandName ="editRainfall" 
                CommandArgument='<%#Eval("WatershedID") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbPrint" Text="Print"  CommandName ="print" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> |

        <asp:LinkButton runat="server" id="lbShare" Text="Share"  CommandName ="share" Visible="false" 
                CommandArgument='<%#Eval("id") %>'  CssClass="gridButton"></asp:LinkButton>

        <asp:LinkButton runat="server" id="lbPlot" Text="Plot"  CommandName ="plot" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> 

        </ItemTemplate>

            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    <br /><br />
    <asp:HyperLink runat="server" ID="hlEditHydrograph" Text="Create New Hydrograph" NavigateUrl="~/SMADAForms/Edithydrograph.aspx"></asp:HyperLink><br />
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
