<%@ Page Title="Manage Rainfall Information" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="SelectRainfall.aspx.cs" Inherits="SMADA_2012.SMADAForms.SelectRainfall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div class="gridTitle">Rainfall Files</div>
<asp:DataGrid ID="gvRainfall" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" OnItemCommand="gvRainfall_OnRowCommand" Align="center">
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
        <asp:BoundColumn DataField="Duration" HeaderText="Duration (min)"></asp:BoundColumn>    
        <asp:BoundColumn DataField="NumberofSteps" HeaderText="Number Of Steps"></asp:BoundColumn>    
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:LinkButton runat="server" id="lbEdit" Text="Edit Properties"  CommandName ="edit" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbValues" Text="Edit Values"  CommandName ="values" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> |

        <asp:LinkButton runat="server" id="lbPrint" Text="Print"  CommandName ="print" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> |

        <asp:LinkButton runat="server" id="lbPlot" Text="Plot"  CommandName ="plot" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbDelete" Text="Delete"  CommandName ="delete" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> 

        <ajaxToolkit:ConfirmButtonExtender ID="cbe1" runat="server" TargetControlID="lbDelete" ConfirmText="Will Delete Rainfall Dimensionless Rainfall - Are You Sure?" >
            </ajaxToolkit:ConfirmButtonExtender>

        </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    <br /><br />
    <div class="gridTitle">Dimensionless Rainfall</div>
<asp:DataGrid ID="dgDRainfall" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" OnItemCommand="gvDRainfall_OnRowCommand" Align="center">
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
        <asp:BoundColumn DataField="Duration" HeaderText="Duration (min)"></asp:BoundColumn>    
        <asp:BoundColumn DataField="NumberofSteps" HeaderText="Number Of Steps"></asp:BoundColumn>  
        <asp:TemplateColumn HeaderText="Manage" HeaderStyle-HorizontalAlign="Center"> <ItemTemplate>
        <asp:LinkButton runat="server" id="lbEdit" Text="Edit Properties"  CommandName ="edit" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbValues" Text="Edit Values"  CommandName ="values" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> |

        <asp:LinkButton runat="server" id="lbPrint" Text="Print"  CommandName ="print" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> |

        <asp:LinkButton runat="server" id="lbPlot" Text="Plot"  CommandName ="plot" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> | 

        <asp:LinkButton runat="server" id="lbDelete" Text="Delete"  CommandName ="delete" 
                CommandArgument='<%#Eval("id") %>' CssClass="gridButton"></asp:LinkButton> 

            <ajaxToolkit:ConfirmButtonExtender ID="cbe1" runat="server" TargetControlID="lbDelete" ConfirmText="Will Delete Rainfall Dimensionless Rainfall - Are You Sure?" >
            </ajaxToolkit:ConfirmButtonExtender>
        </ItemTemplate>

            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateColumn>
        
    </Columns>
    </asp:DataGrid>
    <br /><br />

<asp:HyperLink runat="server" ID="hlEditRainfall" Text="Create New Rainfall" NavigateUrl="~/SMADAForms/EditRainfall.aspx"></asp:HyperLink> | 
<asp:HyperLink runat="server" ID="hlDimRainfall" Text="Create New Dimensionless Rainfall" NavigateUrl="~/SMADAForms/ImportDimensionlessRainfall.aspx"></asp:HyperLink><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
