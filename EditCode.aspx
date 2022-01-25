<%@ Page Language="C#" Title = "Create a New Code or Edit An Existing Code"AutoEventWireup="true" CodeBehind="EditCode.aspx.cs" Inherits="SMADA_2012.EditCode" MasterPageFile="ISRID.Master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormContents" Runat="Server">
    <table border="0" align="center">
    <tr><td colspan="2"><br />
    All codes must belong to a Category. Codes are used in drop down lists in the interface and also stored
    in the database. The Code Name is stored in the database when the user selects that option. The Code 
    Description is displayed in the selection - this is what the users see. The Description is not stored in 
    the database. The Help Text is displayed in the tool tips along with any category help.<br /><br />
    </td></tr>
<tr><td class='labels'>Category

</td><td class='controls'><asp:TextBox runat="server" id="TextBoxCategory" Width="500px" MaxLength="50" Enabled="false"></asp:TextBox></td></tr>
<tr><td class='labels'>Code Name
<div style="font-size:small;"> This is the name stored in the database.</div>
</td><td class='controls'><asp:TextBox runat="server" id="TextBoxCodeNameText" Width="500px" MaxLength="50"></asp:TextBox></td></tr>
<tr><td class='labels'>Code Description
<div style="font-size:small;"> This is the name users will see in the interface.</div>
</td><td class='controls'><asp:TextBox runat="server" id="TextBoxCodeDescriptionText" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox></td></tr>
<tr><td class='labels'>Code Help Text
<div style="font-size:small;"> This is what users will see in the form help.</div>
</td><td class='controls'><asp:TextBox runat="server" id="TextBoxCodeHelpText" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox></td></tr>
<tr><td class='labels'>Deleted?</td><td class='controls'><asp:CheckBox runat="server" id="CheckBoxDeletedBit" /></td></tr>
</table>

<br/><div align="center">
<asp:Button runat="server" id="ButtonSubmit" text="Submit" 
        onclick="ButtonSubmit_Click" />&nbsp;
<asp:Button runat="server" id="ButtonSubmit2" text="Submit and Enter Another Code" 
        onclick="ButtonSubmit2_Click" />&nbsp;
<asp:Button runat="server" id="ButtonUpdate" text="Update" 
        onclick="ButtonUpdate_Click" />&nbsp;
<asp:Button runat="server" id="ButtonCancel" text="Cancel" 
        onclick="ButtonCancel_Click" style="height: 26px" />&nbsp;
<asp:Button runat="server" id="ButtonDelete" text="Delete" 
         style="height: 26px" onclick="ButtonDelete_Click" />&nbsp;
        
        <br /><br />
        <h2>Current Codes</h2>
        
        <asp:DataGrid ID="dgCodes" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="false" Visible="false" OnItemCommand="dgCodes_OnItemCommand">
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
        <asp:TemplateColumn HeaderText="Manage"><ItemTemplate>
        <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandName="delete" CommandArgument='<%#Eval("CodeID") %>' CssClass="gridButton"></asp:LinkButton>        
        <asp:ConfirmButtonExtender ID="cbe" runat="server"
    TargetControlID="lbDelete"
    ConfirmText="Are you sure you want to delete this code (this may orphan assigned values)?" />

        </ItemTemplate></asp:TemplateColumn>            
    </Columns>
    </asp:DataGrid>
        
</div>
</asp:Content>