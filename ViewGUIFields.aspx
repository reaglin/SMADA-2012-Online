<%@ Page Language="C#" Title="Setup Graphical Interface Prompts" AutoEventWireup="true" CodeBehind="ViewGUIFields.aspx.cs" Inherits="SMADA_2012.ViewGUIFields" MasterPageFile="~/ISRID.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="FormContents" Runat="Server">
<center>
<asp:DataGrid ID="gvGUIFields" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>
        <asp:BoundColumn DataField="id" HeaderText="ID" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="TableNameText" HeaderText="Table" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="FieldNameText" HeaderText="Field"></asp:BoundColumn>    
        <asp:BoundColumn DataField="PromptText" HeaderText="Prompt"></asp:BoundColumn>    
        <asp:BoundColumn DataField="InterfaceElement" HeaderText="Default Interface"></asp:BoundColumn>    
        <asp:BoundColumn DataField="CategoryNameText" HeaderText="Category"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>

        <asp:HyperLink runat="server" id="hlEdit" Text="Edit" 
                        NavigateUrl='<%# "~/AdminForms/EditDataField.aspx?id=" + DataBinder.Eval(Container.DataItem, "id") %>'></asp:HyperLink> |

         <asp:HyperLink runat="server" id="hlExport" Text="Export" 
                        NavigateUrl="~/ReportGeneric.aspx?TableName=DatabaseField" > </asp:HyperLink>

        </ItemTemplate></asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    <br /><br />
</center>
</asp:Content>