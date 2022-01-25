<%@ Page Language="C#"  Title="Create a New Category or Edit An Existing Category" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="SMADA_2012.EditCategory" MasterPageFile="ISRID.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="FormContents" Runat="Server">
    <table border="0" align="center">
    <tr><td colspan="2"><br />
     Categories are groups of codes that are possible options for a field in the forms. Each Category will 
     have multiple codes associated with it. These codes are shown in drop down boxes in the entry forms.
     The Help Text is displayed in the tool tips.<br /><br />
    </td></tr>

<tr><td class='labels'>Category Name 
<div style="font-size:small;"> This is the name stored in the database - it should be unique.</div></td><td class='controls'>
<asp:TextBox runat="server" id="TextBoxCategoryNameText" Width="500px" MaxLength="50"></asp:TextBox></td></tr>
<tr><td class='labels'>Category Description
<div style="font-size:small;"> This is the descriptive name, the users will see this name in the program interface.</div>
</td><td class='controls'><asp:TextBox runat="server" id="TextBoxCategoryDescriptionText" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox></td></tr>
<tr><td class='labels'>Category Help
<div style="font-size:small;"> This is what users will see if the click on form help where this category is used.</div>
</td><td class='controls'><asp:TextBox runat="server" id="TextBoxCategoryHelpText" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox></td></tr>
<tr><td class='labels'>Deleted?</td><td class='controls'><asp:CheckBox runat="server" id="CheckBoxDeletedBit" /></td></tr>
</table>

<br/><div align="center">
<asp:Button runat="server" id="ButtonSubmit" text="Submit" 
        onclick="ButtonSubmit_Click" />
<asp:Button runat="server" id="ButtonUpdate" text="Update" 
        onclick="ButtonUpdate_Click" />
<asp:Button runat="server" id="ButtonCancel" text="Cancel" 
        onclick="ButtonCancel_Click" style="height: 26px" />

</div>
</asp:Content>

