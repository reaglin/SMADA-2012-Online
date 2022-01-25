<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditDataField.aspx.cs" Inherits="SMADA_2012.ISRIDForms.EditDataField" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
This form allows the for the setting of prompts for the text elements and also default prompts for 
fields relying on categories and codes.  Be sure to use valid table and field names for all 
entries. For fields that use combo boxes you can specify the category to use in the box.<br /> 
<table border="0" align="center">
 <tr>
  <td class='TableCellL'>Is Primary Key?</td>
  <td class='TableCellR'><asp:CheckBox runat="server" id="chkPK" Width="300px" Text="Is Primary Key?" ></asp:CheckBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Is Mandatory Field?</td>
  <td class='TableCellR'><asp:CheckBox runat="server" id="chkMandatory" Width="300px" Text="Is Mandatory?" ></asp:CheckBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Table Name</td>
  <td class='TableCellR'><asp:Label runat="server" id="lblTableName" Width="300px"></asp:Label></td>
 </tr>
 <tr>
  <td class='TableCellL'>Field Name</td>
  <td class='TableCellR'><asp:Label runat="server" id="lblFieldName" Width="300px"></asp:Label></td>
 </tr>
 <tr>
  <td class='TableCellL'>Prompt Text</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbPromptText" Width="300px" MaxLength="50"></asp:TextBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Print Text</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbPrintText" Width="300px" MaxLength="50"></asp:TextBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Category</td>
  <td class='TableCellR'><asp:DropDownList runat="server" id="cbCategoryText" Width="300px"></asp:DropDownList>
  <asp:HyperLink runat="server" ID="hlCategories" Text="Add" NavigateUrl="~/EditCategory.aspx"></asp:HyperLink></td>
 </tr>
 <tr>
  <td class='TableCellL'>Interface Element</td>
  <td class='TableCellR'><asp:DropDownList runat="server" id="cbInterfaceElement"  Width="500px">
    <asp:ListItem Text="Not Specified" Value=""></asp:ListItem>
    <asp:ListItem Text="TextBox" Value="TextBox"></asp:ListItem>
    <asp:ListItem Text="ComboBox" Value="ComboBox"></asp:ListItem>
    <asp:ListItem Text="RadioButtonList" Value="RadioButtonList"></asp:ListItem>
    <asp:ListItem Text="ListBox" Value="ListBox"></asp:ListItem>
    <asp:ListItem Text="CheckBoxListList" Value="CheckBoxListList"></asp:ListItem>
   </asp:DropDownList></td>
 </tr>
 <tr>
  <td class='TableCellL'>Tooltip Text</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbTooltip" Width="500px" MaxLength="250"></asp:TextBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Default Width</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbWidth" Width="40px" MaxLength="3"></asp:TextBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Maximum Characters</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbMaxCharacters" Width="40px" MaxLength="3"></asp:TextBox></td>
 </tr>
 <tr>
  <td class='TableCellL'>Regular Expression</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbRegularExpression" Width="300px" MaxLength="250"></asp:TextBox></td>
 </tr>

 <tr>
  <td class='TableCellL'>Help Text</td>
  <td class='TableCellR'><asp:TextBox runat="server" id="tbHelpText" Width="500px" TextMode="MultiLine" Height="200"></asp:TextBox></td>
 </tr>
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
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
