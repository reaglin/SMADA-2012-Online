<%@ Page Title="Calculate Time of Concentration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTimeOfConcentration.aspx.cs" 
    Inherits="SMADA2013.Pages.SMADA.EditTimeOfConcentration" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/ucOutputXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucOutputXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucEditXmlPropertyObject.ascx" TagPrefix="uc1" TagName="ucEditXmlPropertyObject" %>
<%@ Register Src="~/UserControls/ucHelpPopup.ascx" TagPrefix="uc1" TagName="ucHelpPopup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1><%: Page.Title %> </h1>
    <table style="margin: 0% 0% 0% 5%;">
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Name (required)
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Properties
                        </td>
                        <td class="TableEntryCell">
                            <uc1:ucEditXmlPropertyObject runat="server" ID="ucParameters" />
                        </td>
                    </tr>
                    <tr> 
                        <td colspan='2'>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButton" />
                         <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="FormButton" />
                         <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" CausesValidation="false" />
                         <asp:Button ID="btnCancel" runat="server" Text="Done" OnClick="btnCancel_Click" CausesValidation="false"  PostBackUrl="~/DefaultLoggedIn.aspx" />
                            <uc1:ucHelpPopup runat="server" id="ucHelpPopup" ObjectClass="TimeOfConcentration" />
                             </td>
                    </tr>
                </table>
            </td>
            <td>
                <uc1:ucOutputXmlPropertyObject runat="server" ID="ucOutputXmlPropertyObject" />
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" BackColor="white">
    <table border="1" style="margin:0% 0% 0% 5%">
<tr>
<td><b>Bransby Williams Equation</b><br />
<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/BW.BMP"  /> <br />
    A - area in square miles<br />
    S - slope as a fraction<br />
    L - Length of Channel (miles)</td>
<td><b>Federal Aviation Authority</b><br />
<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/FAA.BMP"  /><br/> 
    C - Rational Runoff Coefficient<br />
    S - slope in % of longest flow path <br />
    L - Maximum Length of Overland Flow (feet)
</td>
<td><b>Izzard's Formula</b><br />
<asp:Image ID="Image3" runat="server" ImageUrl="~/Images/IZZARD.BMP"  /><br/>
    tc = Time of Concentration (min)<br/>
    L = Overland Flow Distance (ft)<br/>
    i = Rainfall intensity (in/hr)<br/>
    S = Slope (ft/ft)<br/>
    Cr = Retardance Coefficient
</td>
</tr>
<tr>
<td><b>Kerby's Formula</b><br />
<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/KERBY.BMP"  /><br/>
    tc = Time of Concentration (min)<br/>
    L = Length of Flow (feet)<br/>
    s = Slope (ft/ft)<br/>
    n = Retardance Roughness Coefficient
</td>
<td><b>Kinematic Wave Formula</b><br />
<asp:Image ID="Image5" runat="server" ImageUrl="~/Images/KINEMAT.BMP"  /><br  />
    tc = Time of Concentration (min)<br/>
    L = Overland Flow Length<br/>
    N = Mannings Overland Flow Roughness Coefficient<br/>
    i = Rainfall Intensity (in/hr)<br/>
    S = Average Slope (ft/ft)
</td>
<td><b>Kirpich's Formula</b><br />
<asp:Image ID="Image6" runat="server" ImageUrl="~/Images/KIRPICH.BMP"  /><br  />
    tc = Time of Concentration (min)<br/>
    L = Length of Travel<br/>
    S = Average Slope (ft/ft)
</td>

</tr>
<tr>
<td><b>NRCS Formula</b><br />
<asp:Image ID="Image7" runat="server" ImageUrl="~/Images/NRCS.BMP"  /> <br/>
    L = Watershed hydraulic length (feet)<br/>
    S' = Potential Watershed Storage<br/>
    w = Average Watershed slope
</td>
<td>For detailed information see<br/><br/>
    Hydrology - Water Quantity and Quality Control<br/>
    Martin Wanielista, Robert Kersten, Ron Eaglin<br/>
    John Wiley, 1997<br/>
    ISBN: 0-471-07259-1
</td>
<td> </td>
</tr>
</table>


    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
