<%@ Page Language="C#" Title="Interface Elements" AutoEventWireup="true" CodeBehind="EditGUIFields.aspx.cs" Inherits="SMADA_2012.EditGUIFields" MasterPageFile="~/ISRID.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="FormContents" Runat="Server">
    This form allows the for the setting of prompts for the text elements and also default prompts for 
fields relying on categories and codes.  Be sure to use valid table and field names for all 
entries. For fields that use combo boxes you can specify the category to use in the box.<br /> 
    <table border="0" align="center">
<tr><td class='labels'>Table Name</td><td class='controls'><asp:TextBox runat="server" id="tbTableName" Width="300px" MaxLength="50"></asp:TextBox></td></tr>
<tr><td class='labels'>Field Name</td><td class='controls'><asp:TextBox runat="server" id="tbFieldName" Width="300px" MaxLength="50"></asp:TextBox></td></tr>
<tr><td class='labels'>Prompt Text</td><td class='controls'><asp:TextBox runat="server" id="tbPromptText" Width="300px" MaxLength="50"></asp:TextBox></td></tr>
<tr><td class='labels'>Category</td><td class='controls'><asp:DropDownList runat="server" id="cbCategoryText" Width="300px"></asp:DropDownList>
 <asp:HyperLink runat="server" ID="hlCategories" Text="Add" NavigateUrl="~/EditCategory.aspx"></asp:HyperLink>
 </td></tr>
<tr><td class='labels'>Interface Element</td><td class='controls'>
<asp:DropDownList runat="server" id="cbInterfaceElement"  Width="500px">
    <asp:ListItem Text="Not Specified" Value=""></asp:ListItem>
    <asp:ListItem Text="TextBox" Value="TextBox"></asp:ListItem>
    <asp:ListItem Text="ComboBox" Value="ComboBox"></asp:ListItem>
    <asp:ListItem Text="RadioButtonList" Value="RadioButtonList"></asp:ListItem>
    <asp:ListItem Text="ListBox" Value="ListBox"></asp:ListItem>
    <asp:ListItem Text="CheckBoxListList" Value="CheckBoxListList"></asp:ListItem>
</asp:DropDownList></td></tr>
<tr><td class='labels'>Tooltip Text</td><td class='controls'><asp:TextBox runat="server" id="tbTooltip" Width="500px" MaxLength="250"></asp:TextBox></td></tr>
<tr><td class='labels'>Default Width</td><td class='controls'><asp:TextBox runat="server" id="tbWidth" Width="40px" MaxLength="3"></asp:TextBox></td></tr>
<tr><td class='labels'>Help Text</td><td>    <asp:TextBox ID="tbHelpText" 
        runat="server" Width="509px" TextMode="MultiLine" Height="200px"></asp:TextBox>
    <ajaxToolkit:HtmlEditorExtender runat="server" TargetControlID="tbHelpText"></ajaxToolkit:HtmlEditorExtender>
</td></tr>
</table>
<br/><div align="center">
<asp:Button runat="server" id="ButtonSubmit" text="Submit" 
        onclick="ButtonSubmit_Click" />&nbsp;
<asp:Button runat="server" id="ButtonUpdate" text="Update" 
        onclick="ButtonUpdate_Click" />&nbsp;
<asp:Button runat="server" id="ButtonCancel" text="Cancel" 
        onclick="ButtonCancel_Click" />
</div>
</asp:Content>