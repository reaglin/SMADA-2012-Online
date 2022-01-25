<%@ Page Language="C#" Title="List of All Categories and Codes" AutoEventWireup="true" CodeBehind="ViewCategories.aspx.cs" Inherits="SMADA_2012.ViewCategories" MasterPageFile="ISRID.Master"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormContents" Runat="Server">
<center>
<asp:Label runat="server" ID="LabelCodes" Visible="false" CssClass="pagetitle"></asp:Label>
    <br />
    <asp:DataGrid ID="dgCodes" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" Visible="false" OnItemCommand="gvCodes_OnItemCommand">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>
        <asp:BoundColumn DataField="CodeID" HeaderText="ID" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="CodeNameText" HeaderText="Name" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="CodeDescriptionText" HeaderText="Description"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:HyperLink runat="server" id="hlEdit" Text="Edit Code" 
                        NavigateUrl='<%# "~/EditCode.aspx?CodeID=" + DataBinder.Eval(Container.DataItem, "CodeID") %>' CssClass="gridButton"></asp:HyperLink> |

        <asp:HyperLink runat="server" id="hlCodes" Text="New Code" 
                        NavigateUrl='<%# "~/EditCode.aspx?CategoryID=" + DataBinder.Eval(Container.DataItem, "CategoryID") %>' CssClass="gridButton"></asp:HyperLink> | 

        <asp:HyperLink runat="server" id="hlExport" Text="Export" 
                        NavigateUrl="~/ReportGeneric.aspx?Type=ExportCategories" CssClass="gridButton" > </asp:HyperLink> |

        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName = "delete" CommandArgument = '<%#Eval("CodeID") %>' CssClass="gridButton"></asp:LinkButton> | 

        </ItemTemplate></asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    <br /><br />
<asp:DataGrid ID="gvCategories" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false"  OnItemCommand="gvCategories_OnItemCommand">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditItemStyle BackColor="#2461BF" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <AlternatingItemStyle BackColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
    <Columns>
        <asp:BoundColumn DataField="CategoryID" HeaderText="ID" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="CategoryNameText" HeaderText="Name" ></asp:BoundColumn>       
        <asp:BoundColumn DataField="CategoryDescriptionText" HeaderText="Description"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="Manage Categories" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:HyperLink runat="server" id="hlEdit" Text="Edit Category" 
                        NavigateUrl='<%# "~/EditCategory.aspx?CategoryID=" + DataBinder.Eval(Container.DataItem, "CategoryID") %>' CssClass="gridButton"></asp:HyperLink> |

        <asp:HyperLink runat="server" id="HyperLink1" Text="New Category" 
                        NavigateUrl="~/EditCategory.aspx" CssClass="gridButton"></asp:HyperLink> |

        <asp:HyperLink runat="server" id="hlCodes" Text="View Codes" 
                        NavigateUrl='<%# "~/ViewCategories.aspx?CategoryID=" + DataBinder.Eval(Container.DataItem, "CategoryID") %>' CssClass="gridButton"></asp:HyperLink> |

        <asp:HyperLink runat="server" id="hlNewCode" Text="New Code" 
                        NavigateUrl='<%# "~/EditCode.aspx?CategoryID=" + DataBinder.Eval(Container.DataItem, "CategoryID") %>' CssClass="gridButton"></asp:HyperLink> | 
                        
        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName = "delete" CommandArgument = '<%#Eval("CategoryID") %>' CssClass="gridButton"></asp:LinkButton> | 

    <asp:ConfirmButtonExtender ID="cbe" runat="server"
    TargetControlID="lbDelete"
    ConfirmText="Are you sure you want to delete this category (all associated codes will also be deleted)?" />
    
        <asp:HyperLink runat="server" id="hlExport" Text="Export" 
                        NavigateUrl="~/ReportGeneric.aspx?Type=ExportCategories" CssClass="gridButton"></asp:HyperLink>

        </ItemTemplate></asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    
    
    
    
</center>
</asp:Content>