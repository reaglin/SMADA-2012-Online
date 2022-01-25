<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEditLandUse.ascx.cs" Inherits="SMADA_2012.UserControls.SMADA.ucEditLandUse" %>
<link href="../../Styles.css" rel="stylesheet" type="text/css" />
    <table border="1">
    <tr>
    <td> Enter Name for Land Use File :</td>
    <td> 
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        </td>
    </tr>
    </table>
<ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="1000" ActiveTabIndex="0">
<ajaxToolkit:TabPanel ID="tabPanel1" runat="server" HeaderText="Graphic Editor" >
<ContentTemplate>
    <table border="1">
    <tr>
    <td> Enter New Land Use Name:</td>
    <td> 
        <asp:TextBox ID="tbLandUseName" runat="server"></asp:TextBox>
    <asp:Button ID="BtnAdd" runat="server" Text="Add"  
         ToolTip="Adds a nnew Land Use to the File" onclick="btnAddLandUse_Click"/>
        </td>
    </tr>
    <tr>
    <td> Add New Pollutant, Enter Name:</td>
    <td> 
        <asp:TextBox ID="tbPollutantName" runat="server"></asp:TextBox>
    <asp:Button ID="btnAddPollutant" runat="server" Text="Add" 
         ToolTip="Adds a new Pollutant to the File" onclick="btnAddPollutant_Click"/>
        </td>
    </tr>
   <tr>
   <td >
       <asp:GridView ID="gvLandUse" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <EmptyDataTemplate>No Land Uses Exist</EmptyDataTemplate>
        <Columns>
         <asp:BoundField DataField="LandUseName" HeaderText="Land Use Name" />

        <asp:TemplateField>
        <ItemTemplate>
        Rational C :
            <asp:TextBox ID="tbC" runat="server" Width="50"></asp:TextBox>
            <asp:Button ID="btnEditPollutants" runat="server" Text="Edit Pollutants" />

        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>   
   </td>
   <td>
       <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <EmptyDataTemplate>No Pollutant Values Exist</EmptyDataTemplate>
        <Columns>
         <asp:BoundField DataField="PollutantName" HeaderText="Pollutant" />

        <asp:TemplateField>
        <ItemTemplate>
        Concentration :
            <asp:TextBox ID="tbC" runat="server" Width="50"></asp:TextBox>

        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>   
   </td>
   </tr>

</table>
</ContentTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel ID="tabPanel2" runat="server" HeaderText="XML Editor">
<ContentTemplate>
<asp:TextBox ID="tbXML" runat="server" ClientIDMode="Static" TextMode="MultiLine"  
    Height="400" Width="600" />
</ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="actionButton" 
         ToolTip="Saves Land Use to Database as Current Entry" onclick="btnSave_Click"/>
    <asp:Button ID="btnSaveNew" runat="server" Text="Save As New" CssClass="actionButton" 
         ToolTip="Saves Land Use to Database as a New Entry" onclick="btnSaveNew_Click"/>
    <asp:Button ID="btnSaveGlobal" runat="server" Text="Save As Global" CssClass="actionButton" 
         ToolTip="Saves Land Use to Database as a Global Entry" onclick="btnSaveGlobal_Click"/>
