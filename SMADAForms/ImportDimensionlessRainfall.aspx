<%@ Page Title="Edit/Create Dimensionless Rainfall" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="ImportDimensionlessRainfall.aspx.cs" Inherits="SMADA_2012.SMADAForms.ImportDimensionlessRainfall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<table class="TableCenter">	
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblid" Text = "id"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="disabledID" ID = "tbid" Enabled="false"></asp:TextBox></td>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblTitle" Text = "Title"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbTitle"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Title is Required" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>

</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblDescription" Text = "Description"></asp:Label></td>
<td colspan="3" class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbDescription" Width="400"></asp:TextBox></td>
</tr>
<tr>
<td colspan="2" class="defaultCellR">
Enter Cumulative Dimensionless Values (one per line) in the Cumulative Text Box<br /> or enter incremental values in 
the Incremental text box and <br />press the <b>Convert Incremental Values</b> button. 

</td>
<td class="defaultCellL">Incremental:<br /><asp:TextBox runat="server" ID="tbIncrement" TextMode="MultiLine" Rows="15" Width="150"></asp:TextBox></td>
<td class="defaultCellL">Cumulative:<br /><asp:TextBox runat="server" ID="tbValues" TextMode="MultiLine" Rows="15" Width="150"></asp:TextBox></td>
</tr>
</table> 
<div class="footerButtons">
<br /><br />
    <asp:Button ID="btnConvert" runat="server" Text="Convert Incremental Values" 
    CssClass="formbutton" onclick="btnConvert_Click" CausesValidation="false"/>
    <asp:Button ID="btnUpdate" runat="server" Text="Save Values" 
    CssClass="formbutton" onclick="btnUpdate_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel and Return" 
    CssClass="formbutton" onclick="btnCancel_Click" CausesValidation="False"/>
        <asp:Button ID="btnPublic" runat="server" Text="Make Public Dimensionless" 
    CssClass="formbutton" onclick="btnPublic_Click" CausesValidation="false"/>

</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
