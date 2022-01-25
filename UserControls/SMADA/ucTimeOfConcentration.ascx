<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimeOfConcentration.ascx.cs" Inherits="SMADA_2012.UserControls.ucTimeOfConcentration" %>
<link href="../../Styles.css" rel="stylesheet" type="text/css" />
<script src="../../jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="../../highcharts.js" type="text/javascript"></script>
<table>
<br />
<tr><td valign="top">
<table>
<tr>
<td><asp:Label ID="Label1" runat="server" Text="Length of Travel  (Feet L)"></asp:Label></td>
<td><asp:TextBox ID="tbL" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label3" runat="server" Text="Slope (fraction S)"></asp:Label> </td>
<td><asp:TextBox ID="tbSlope" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;<asp:Label ID="Label2" runat="server" Text="Rainfall Intensity (inches/hour i)"></asp:Label></td>
<td><asp:TextBox ID="tbIntensity" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;<asp:Label ID="Label7" runat="server" Text="Watershed Area (Square Miles A)"></asp:Label></td>
<td><asp:TextBox ID="tbArea" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label4" runat="server" Text="Roughness Coefficient (n < 1)"></asp:Label> </td>
<td><asp:TextBox ID="tbRetardanceN" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label5" runat="server" Text="Retardance Coefficient (0.005 < Cr < 2)"></asp:Label> </td>
<td><asp:TextBox ID="tbRetardanceC" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label6" runat="server" Text="Mannings Overland Flow Roughness (N < 1)"></asp:Label> </td>
<td><asp:TextBox ID="tbManningsN" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label8" runat="server" Text="NRCS Curve Number (25 < CN < 100)"></asp:Label> </td>
<td><asp:TextBox ID="tbCN" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label9" runat="server" Text="FAA Rational Coefficent (0 < C < 1)"></asp:Label> </td>
<td><asp:TextBox ID="tbRationalC" runat="server" ></asp:TextBox></td>
</tr>

<tr>
<td>   
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="actionButton" 
        Visible="true" onclick="btnCalculate_Click"/>
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
<table border="1">
<tr>
<td>Bransby Williams Equation<br />
<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/BW.BMP"  /> <br />

    A - area in square miles<br />
    S - slope as a fraction<br />
    L - Length in feet</td>
<td>Federal Aviation Authority<br />
<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/FAA.BMP"  /> </td>
<td>Izzard's Formula<br />
<asp:Image ID="Image3" runat="server" ImageUrl="~/Images/IZZARD.BMP"  /> </td>
</tr>
<tr>
<td>Kerby's Formula<br />
<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/KERBY.BMP"  /> </td>
<td>Kinematic Wave Formula<br />
<asp:Image ID="Image5" runat="server" ImageUrl="~/Images/KINEMAT.BMP"  /> </td>
<td>Kirpich's Formula<br />
<asp:Image ID="Image6" runat="server" ImageUrl="~/Images/KIRPICH.BMP"  /> </td>
</tr>
<tr>
<td>NRCS Formula<br />
<asp:Image ID="Image7" runat="server" ImageUrl="~/Images/NRCS.BMP"  /> </td>
<td> </td>
<td> </td>
</tr>
</table>
