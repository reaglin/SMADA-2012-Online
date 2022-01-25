<%@ Page Title="Edit Rainfall Values" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditRainfallValues.aspx.cs" Inherits="SMADA_2012.SMADAForms.EditRainfallValues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div class="inputForm">
<asp:Table runat="server" ID="table1">
<asp:TableRow>
    <asp:TableCell CssClass="defaultCellL"><asp:Label ID="lblTimeLabel" runat="server" Text="Time (minutes)" Width="200"></asp:Label></asp:TableCell>
    <asp:TableCell CssClass="defaultCellR"><asp:Label ID="lblDepthLabel" runat="server" Text="Rainfall Depth (in)" Width="200"></asp:Label></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell CssClass="defaultCellL">Total (Set:Calculated)</asp:TableCell>
<asp:TableCell  CssClass="defaultCellR">
    <asp:Label ID="lblDTotal" runat="server" Text=""></asp:Label> :
<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label><asp:Button ID="btnCalculate"
        runat="server" Text="Calculate" onClick="btnCalculate_Click" />  </asp:TableCell>
</asp:TableRow>
    </asp:Table>
    <asp:Button ID="btnUpdate" runat="server" Text="Save Values" 
    CssClass="formbutton" onclick="btnUpdate_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel and Return" 
    CssClass="formbutton" onclick="btnCancel_Click"/>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
