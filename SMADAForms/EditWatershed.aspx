<%@ Page Title="Create and Edit Watershed Information" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditWatershed.aspx.cs" Inherits="SMADA_2012.SMADAForms.EditWatershed" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
<div class="inputForm">
    <table class="TableCenter">
     <tr>
    <td class="defaultCellR"><asp:Label ID="LabelTitle" runat="server" Text="Title" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL" colspan="3"><asp:TextBox ID="tbTitle" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Title Is Required" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td class="defaultCellR"> <asp:Label ID="LabelDescription" runat="server" Text="Description" CssClass="inputLabel"></asp:Label></td>
        <td colspan="3" class="defaultCellL">
            <asp:TextBox ID="tbDescription" runat="server" CssClass="inputControl" Width="500px"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="defaultCellR"><asp:Label ID="LabelTimeCon" runat="server" Text="Time of Concentration (min)" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbTimeCon" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>
    <td class="defaultCellR"><asp:Label ID="LabelInfiltrationMethod" runat="server" Text="Infiltration Method" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:DropDownList ID="cbInfiltrationMethod" runat="server" 
            CssClass="inputControl" AutoPostBack="True" 
            onselectedindexchanged="cbInfiltrationMethod_SelectedIndexChanged"></asp:DropDownList></td>
    </tr>
    <tr>
    <td class="defaultCellR"><asp:Label ID="LabelTotalArea" runat="server" Text="Total Area (acres)" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbTotalArea" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>

    <td class="defaultCellR"><asp:Label ID="LabelCN" runat="server" Text="SCS Curve Number" CssClass="inputLabel" Visible="false"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbCN" runat="server" CssClass="inputControl" Width="200px" Visible="false"></asp:TextBox></td>
   </tr>

    <tr>
      <td class="defaultCellR"><asp:Label ID="LabelImpArea" runat="server" Text="Impervious Area (acres)" CssClass="inputLabel"></asp:Label></td>
        <td class="defaultCellL"><asp:TextBox ID="tbImpArea" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>

        <td class="defaultCellR"><asp:Label ID="LabelHIO" runat="server" Text="Horton Initial Rate " CssClass="inputLabel" Visible="false"></asp:Label></td>
        <td class="defaultCellL"><asp:TextBox ID="tbHIO" runat="server" CssClass="inputControl" Width="200px"  Visible="false"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="defaultCellR"><asp:Label ID="LabelDCIA" runat="server" Text="DCIA (%)" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbDCIA" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>
    
    <td class="defaultCellR"><asp:Label ID="LabelHIC" runat="server" Text="Horton Final Rate" CssClass="inputLabel"  Visible="false"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbHIC" runat="server" CssClass="inputControl" Width="200px"  Visible="false"></asp:TextBox></td>

    </tr>
    <tr>
    <td class="defaultCellR"><asp:Label ID="LabelAddAbsPerv" runat="server" Text="Additional Abstracion Pervious (in)" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbAddAbsPerv" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>

    <td class="defaultCellR"><asp:Label ID="LabelHKR" runat="server" Text="Horton Rate Constant" CssClass="inputLabel"  Visible="false"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbHKR" runat="server" CssClass="inputControl" Width="200px"  Visible="false"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="defaultCellR"><asp:Label ID="LabelAddAbsImp" runat="server" Text="Additional Abstraction Impervious (in)" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbAddAbsImp" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>

    <td class="defaultCellR"><asp:Label ID="LabelMaxInf" runat="server" Text="Maximum Infiltration (in)" CssClass="inputLabel"></asp:Label></td>
    <td class="defaultCellL"><asp:TextBox ID="tbMaxInf" runat="server" CssClass="inputControl" Width="200px"></asp:TextBox></td>
    </tr>
    </table>
    <asp:Label ID="lblValidate" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Create Watershed" CssClass="formbutton" onclick="btnSave_Click"/>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Watershed" CssClass="formbutton" onclick="btnUpdate_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel and Return" CssClass="formbutton" onclick="btnCancel_Click"/>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
