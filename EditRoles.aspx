<%@ Page Language="C#" Title="Edit User Roles" AutoEventWireup="true" CodeBehind="EditRoles.aspx.cs" Inherits="SMADA_2012.EditRoles" MasterPageFile="~/ISRID.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="FormContents" Runat="Server">

<asp:DataGrid ID="dgUserRoles" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" 
        onItemCommand="dgUserRoles_RowCommand">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>
    <asp:BoundColumn DataField="UserName" HeaderText="Login Name"></asp:BoundColumn>
    <asp:BoundColumn DataField="UserFullName" HeaderText="User Name"></asp:BoundColumn>
    <asp:BoundColumn DataField="RoleNameText" HeaderText="Role"></asp:BoundColumn>
    <asp:TemplateColumn HeaderText="Change Level">
    <ItemTemplate>
    
    <asp:LinkButton runat="server" ID="lbSetAdmin" Text="Set As Admin" CommandName="add" CommandArgument='<%#Eval("UserID") %>' Visible='<%#isNotAdministrator(Eval("UserName")) %>' CssClass="gridButton"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="lbRemoveAdmin" Text="Remove As Admin" CommandName="remove" CommandArgument='<%#Eval("UserID") %>' Visible='<%#isAdministrator(Eval("UserName")) %>' CssClass="gridButton"></asp:LinkButton>
    
    </ItemTemplate>
    </asp:TemplateColumn>
    
    </Columns>
</asp:DataGrid>
</asp:Content>
