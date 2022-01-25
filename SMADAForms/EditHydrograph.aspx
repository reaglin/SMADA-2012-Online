<%@ Page Title="Enter Hydrograph Information" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditHydrograph.aspx.cs" Inherits="SMADA_2012.SMADAForms.EditHydrograph" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div class="inputForm">
<table class="TableCenter">	
 <tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblid" Text = "id"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="disabledID" ID = "tbid" Width='100'></asp:TextBox></td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblTitle" Text = "Title"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbTitle"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Title is Required" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblDescription" Text = "Description"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbDescription" Width='400'></asp:TextBox></td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblWatershedID" Text = "WatershedID"></asp:Label></td>
<td class="defaultCellL"><asp:DropDownList runat="server" CssClass="inputControl" ID = "ddlWatershedID"></asp:DropDownList>
<asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="Must Select a Watershed" ControlToValidate="ddlWatershedID"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblRainfallID" Text = "RainfallID"></asp:Label></td>
<td class="defaultCellL"><asp:DropDownList runat="server" CssClass="inputControl" ID = "ddlRainfallID"></asp:DropDownList>
<asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="Must Select a Rainfall" ControlToValidate="ddlRainfallID"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblHydrographMethod" Text = "HydrographMethod"></asp:Label></td>
<td class="defaultCellL"><asp:DropDownList runat="server" CssClass="inputControl" ID = "ddlHydrographMethod"></asp:DropDownList>
<asp:RequiredFieldValidator ID="rfv4" runat="server" ErrorMessage="Must Select a Hydrograph Generation Method" ControlToValidate="ddlHydrographMethod"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="defaultCellR"><asp:Label runat="server" CssClass="inputLabel" ID = "lblPeakAttFactor" Text = "PeakAttFactor"></asp:Label></td>
<td class="defaultCellL"><asp:TextBox runat="server" CssClass="inputControl" ID = "tbPeakAttFactor"></asp:TextBox></td>
</tr>
</table>
</div>
    <asp:Label ID="lblValidate" runat="server" Text=""  CssClass="ErrorMessage"></asp:Label>

<br />
<div class="footerButtons">
    <asp:Button ID="btnSave" runat="server" Text="Create Hydrograph" 
    CssClass="formbutton" onclick="btnSave_Click"/>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Hydrograph" 
    CssClass="formbutton" onclick="btnUpdate_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel and Return" 
    CssClass="formbutton" onclick="btnCancel_Click" CausesValidation="false"/>
 </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
