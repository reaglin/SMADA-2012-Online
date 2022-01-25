<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRationalCoefficientLookup.ascx.cs" Inherits="SMADA2013.UserControls.ucRationalCoefficientLookup" %>
<table class="TableInput">
     <tr>
        <td class="TableInnerLabelCell">
            Rainfall Zone 
        </td>
        <td class="TableInnerEntryCell">
            <asp:DropDownList ID="ddlZone" runat="server" CssClass="DropDownList"></asp:DropDownList> 
        </td>
      </tr>
        <tr>
        <td class="TableInnerLabelCell">
            Pre-Condition<br/>
            Non-Directly Connected Impervious<br/>
             Area Curve Number (NDCIA CN)
        </td>
        <td class="TableInnerEntryCell">
            <asp:TextBox ID="tbPreNDCIACN" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td class="TableInnerLabelCell">
            Pre-Condition<br/>
            Directly Connected Impervious<br/>
            Percent of Watershed (NDCIA %)
        </td>
        <td class="TableInnerEntryCell">
            <asp:TextBox ID="tbPreDCIAPercent" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td class="TableInnerLabelCell">
            Pre-Condition<br/>
            Rational Coefficient<br/>
            Enter or Calculate 
        </td>
        <td class="TableInnerEntryCell">
            <asp:TextBox ID="tbPreC" runat="server"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td class="TableInnerLabelCell">
            Post-Condition<br/>
            Non-Directly Connected Impervious<br/>
             Area Curve Number (NDCIA CN)
        </td>
        <td class="TableInnerEntryCell">
            <asp:TextBox ID="tbPostNDCIACN" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td class="TableInnerLabelCell">
            Post-Condition<br/>
            Directly Connected Impervious<br/>
            Percent of Watershed (NDCIA %)
        </td>
        <td class="TableInnerEntryCell">
            <asp:TextBox ID="tbPostDCIAPercent" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td class="TableInnerLabelCell">
            Post-Condition<br/>
            Rational Coefficient<br/>
            Enter or Calculate 
        </td>
        <td class="TableInnerEntryCell">
            <asp:TextBox ID="tbPostC" runat="server"></asp:TextBox>
        </td>
        </tr>
</table>