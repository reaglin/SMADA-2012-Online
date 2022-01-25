<%@ Page Title="Edit/Enter Rainfall Information" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditRainfall.aspx.cs" Inherits="SMADA_2012.SMADAForms.EditRainfall" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
    <div class="inputForm">
<table class="TableCenter" >
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblTitle" Text = "Title"></asp:Label></td>
<td class="defaultCellL" colspan="3"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbTitle"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Title is Required" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
    </td>
</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblDescription" Text = "Description"></asp:Label></td>
<td class="defaultCellL" colspan="3"><asp:TextBox runat="server" 
        CssClass="inputControl" ID = "tbDescription" Width="373px"></asp:TextBox></td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblDimensionlessID" Text = "Dimensionless Rainfall"></asp:Label>

</td>

<td class="defaultCellL" colspan="3"><asp:DropDownList runat="server" CssClass="inputControl" ID = "cbDimensionlessID"></asp:DropDownList></td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblTimeStep" Text = "TimeStep"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbTimeStep"></asp:TextBox></td>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblNumberOfSteps" Text = "NumberOfSteps"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbNumberOfSteps"></asp:TextBox>
    <asp:Button ID="btnCalculateNS" runat="server" Text="Calculate" 
        onclick="btnCalculateNS_Click" />
</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblDuration" Text = "Duration"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbDuration"></asp:TextBox>
    <asp:Button ID="btnCalculateDuration" runat="server" Text="Calculate" 
        onclick="btnCalculateDuration_Click" />
</td>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblTotal" Text = "Total"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbTotal"></asp:TextBox></td>
</tr>
</table>
    <asp:Label ID="lblValidate" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

<br />
</div>
<div class="footerButtons">
<br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Create Rainfall" 
    CssClass="formbutton" onclick="btnSave_Click"/>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Rainfall" 
    CssClass="formbutton" onclick="btnUpdate_Click"/>
    <asp:Button ID="btnValues" runat="server" Text="Edit Rainfall Values" 
    CssClass="formbutton" onclick="btnValues_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel and Return" 
    CssClass="formbutton" onclick="btnCancel_Click"/>
    
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
