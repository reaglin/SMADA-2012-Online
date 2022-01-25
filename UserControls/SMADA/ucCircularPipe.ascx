<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCircularPipe.ascx.cs" Inherits="SMADA_2012.UserControls.SMADA.ucCircularPipe" %>
<link href="../../Styles.css" rel="stylesheet" type="text/css" />
<script src="../../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../../highcharts.js" type="text/javascript"></script>
<table>
<tr><td valign="top">
<table>
<tr>
<td><asp:Label ID="Label1" runat="server" Text="Diameter (inches) *"></asp:Label></td>
<td><asp:TextBox ID="tbDiameter" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;<asp:Label ID="Label2" runat="server" Text="Manning's N *"></asp:Label></td>
<td><asp:TextBox ID="tbManningsN" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label3" runat="server" Text="Slope (fraction) *"></asp:Label> </td>
<td><asp:TextBox ID="tbSlope" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label4" runat="server" Text="Flow (cfs)"></asp:Label> </td>
<td><asp:TextBox ID="tbFlow" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label5" runat="server" Text="Depth (ft)"></asp:Label> </td>
<td><asp:TextBox ID="tbDepth" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td>   
* - Required field<br />
Must enter <b>Flow</b> or <b>Depth</b><br />
        <asp:Button ID="btnFlow" runat="server" Text="Calculate Pipe Parameters" CssClass="actionButton" 
        Visible="true" onclick="btnFlow_Click"/>
</td>
<td></td>
</tr>
</table>
</td>
<td>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</td>
</tr>
</table>
<asp:Literal ID="Literal2" runat="server"></asp:Literal>

