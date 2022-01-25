<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" 
         CodeBehind="EditLandUses.aspx.cs" Inherits="SMADA_2012.SMADAForms.EditLandUses" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<asp:Label ID="lblError" runat="server" Text="" Font-Size="X-Large" Visible="false"></asp:Label><br />
Please Enter a Name for Your Land Use File (required):<asp:TextBox ID="tbName" runat="server" Width="200"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="A File Name is Requred" ControlToValidate="tbName">
    </asp:RequiredFieldValidator>
<br />
<table>
<tr>
<td colspan="2">

Current Data to be saved: <br\ />
<asp:TextBox ID="tbXML" runat="server" ClientIDMode="Static" TextMode="MultiLine"  
    Height="400" Width="800" />
 </td>
</tr>
<tr>
<td>
    Land Use Editor - Use to change values in XML file below;<br />
    <table border="1">
    <tr>
    <td> Name:</td>
    <td> 
        <asp:TextBox ID="tbLandUseName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td> Rational C:</td>
    <td> 
        <asp:TextBox ID="tbRationalC" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Button ID="btnAddLandUse" runat="server" Text="Add Land Use" CssClass="actionButton" 
         ToolTip="Adds Land Use to List or Edits existing Land Use" onclick="btnAddLandUse_Click"/>
    </td>
    <td></td>
    </tr>
    </table>
    Select a Land Use to Edit the values for that land use:<br />
    <asp:RadioButtonList ID="rblLandUses" runat="server" AutoPostBack="true" 
        onselectedindexchanged="rblLandUses_SelectedIndexChanged">
    </asp:RadioButtonList><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="actionButton" 
         ToolTip="Saves Land Use to Database as Current Entry" onclick="btnSave_Click"/>
    <asp:Button ID="btnSaveNew" runat="server" Text="Save As New" CssClass="actionButton" 
         ToolTip="Saves Land Use to Database as a New Entry" onclick="btnSaveNew_Click"/>
    <asp:Button ID="btnSaveGlobal" runat="server" Text="Save As Global" CssClass="actionButton" 
         ToolTip="Saves Land Use to Database as a Global Entry" onclick="btnSaveGlobal_Click"/>

         <br />

</td>
<td>
  Edit Pollutant Values: <br />
  pollutant, concentration (example: BOD, 2.35)<br />
  one per line<br />
 <asp:TextBox ID="tbPollutantData" runat="server" ClientIDMode="Static" TextMode="MultiLine"  
    Height="300" Width="300" />
</td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
