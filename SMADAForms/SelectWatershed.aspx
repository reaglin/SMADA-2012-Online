<%@ Page Title="Manage Watersheds" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="SelectWatershed.aspx.cs" Inherits="SMADA_2012.SMADAForms.SelectWatereshed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div class="inputForm">
<asp:DataGrid ID="gvWatersheds" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" OnItemCommand="gvWatersheds_OnRowCommand" align="center">
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
        <asp:BoundColumn DataField="Title" HeaderText="Title"></asp:BoundColumn>       
        <asp:BoundColumn DataField="TotalArea" HeaderText="Total Area"></asp:BoundColumn>    
        <asp:BoundColumn DataField="TimeCon" HeaderText="Time of Concentration"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:LinkButton runat="server" id="lbEdit" Text="Edit"  CommandName ="edit" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbPrint" Text="Print"  CommandName ="print" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton" ></asp:LinkButton> |

        <asp:LinkButton runat="server" id="lbShare" Text="Share"  CommandName ="share" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> 
        </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateColumn>
    </Columns>
    </asp:DataGrid>
    <br /><br />
    <asp:HyperLink runat="server" ID="hlEditWatershed" Text="Create New Watershed" NavigateUrl="~/SMADAForms/EditWatershed.aspx" CssClass="mainButton"></asp:HyperLink><br />
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
