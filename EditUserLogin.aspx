<%@ Page Language="C#" Title="Create and Edit User Login" AutoEventWireup="true" CodeBehind="EditUserLogin.aspx.cs" Inherits="SMADA_2012.EditUserLogin"  MasterPageFile="ISRID.Master"%>

<asp:Content id="Content1" ContentPlaceHolderID="FormContents" Runat="Server">
<center>
<table class="defaultTable">
<tr><td class='labels'>User Login Name</td><td class='controls'><asp:TextBox runat="server" id="TextBoxUserName"  Width="200px"></asp:TextBox>
<asp:Label runat="server" ID="lblMessage" Visible="False" Font-Size="Large" 
        ForeColor="#CC3300"></asp:Label>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Must Enter User Name" ControlToValidate="TextBoxUserName" ></asp:RequiredFieldValidator>

</td></tr>
<tr><td class='labels'>User Password</td><td class='controls'><asp:TextBox runat="server" id="TextBoxUserPassword"  Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Must Enter Password" ControlToValidate="TextBoxUserPassword"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td class='labels'>User Full Name</td><td class='controls'><asp:TextBox runat="server" id="TextBoxUserFullName"  Width="500px"></asp:TextBox></td></tr>
<tr><td class='labels'>User Email</td><td class='controls'><asp:TextBox runat="server" id="TextBoxUserEmail"  Width="500px"></asp:TextBox></td></tr>
<tr><td class='labels'>User Phone</td><td class='controls'><asp:TextBox runat="server" id="TextBoxUserPhone"  Width="200px"></asp:TextBox></td></tr>
</table>
<br/>
<div align="center">
<asp:Button runat="server" id="ButtonSubmit" text="Submit" 
        onclick="ButtonSubmit_Click" />
<asp:Button runat="server" id="ButtonUpdate" text="Update" 
        onclick="ButtonUpdate_Click" />
</div>

</center>
</asp:Content>
