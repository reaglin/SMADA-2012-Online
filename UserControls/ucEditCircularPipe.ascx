<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEditCircularPipe.ascx.cs" Inherits="SMADA2013.UserControls.ucEditCircularPipe" %>
<table>
<tr>
<td class="TableInnerLabelCell"><asp:Label ID="lblDiameter" runat="server" Text="Diameter (inches) *"></asp:Label></td>
<td class="TableInnerEntryCell"><asp:TextBox ID="tbDiameter" runat="server" TextMode="Number" Width="60"></asp:TextBox></td>
</tr>
<tr>
<td class="TableInnerLabelCell">&nbsp;<asp:Label ID="lblManningsN" runat="server" Text="Manning's N *"></asp:Label></td>
<td class="TableInnerEntryCell"><asp:TextBox ID="tbManningsN" runat="server" TextMode="Number"  Width="60"></asp:TextBox></td>
</tr>
<tr>
<td class="TableInnerLabelCell"><asp:Label ID="lblSlope" runat="server" Text="Slope (fraction) *"></asp:Label> </td>
<td class="TableInnerEntryCell"><asp:TextBox ID="tbSlope" runat="server" TextMode="Number" Width="60"></asp:TextBox></td>
</tr>
<tr>
<td class="TableInnerLabelCell"><asp:Label ID="lblFlow" runat="server" Text="Flow (cfs)"></asp:Label> </td>
<td class="TableInnerEntryCell"><asp:TextBox ID="tbFlow" runat="server" TextMode="Number" Width="60"></asp:TextBox></td>
</tr>
<tr>
<td class="TableInnerLabelCell"><asp:Label ID="lblDepth" runat="server" Text="Depth (ft)"></asp:Label> </td>
<td class="TableInnerEntryCell"><asp:TextBox ID="tbDepth" runat="server" TextMode="Number" Width="60" ></asp:TextBox></td>
</tr>
<tr>
<td class="TableInnerLabelCell">   
* - Required field<br />
Must enter <b>Flow</b> or <b>Depth</b><br />
</td>
<td class="TableInnerEntryCell"></td>
</tr>
</table>
