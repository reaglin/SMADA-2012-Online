<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuBMPTRAINS.aspx.cs" Inherits="SMADA2013.MenuBMPTRAINS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
            <section class="featured">
    <div class="content-wrapper">
     <hgroup class="title">
                <h1> <%: Page.Title %></h1>
                <h2>Welcome <%: Context.User.Identity.Name  %></h2>
            </hgroup>
    </div>
    </section>
    <div style="float:right; margin-right:15px; margin-top:100px"><a href="http://www.stormwater.ucf.edu/"> <img src="Images/drippy-medium.gif"/>
</a></div>
    <div class="button-menu">
        <h2>BMPTRAINS - Pollution Removal Best Practices</h2><br/>
        BMPTRAINS is a model that aids in the selection of a stormwater BMP size and effectiveness. These
        numbers are specific to the State of Florida. If you would like simulation models done for your area then
        contact the  <a href="http://www.stormwateracademy.ucf.edu">Stormwater Academy</a> 
    <table >
    <tr>
        <td>
            <asp:Button ID="btnLanduse" runat="server" Text="Land Use Pollutant Concentrations" 
                Width="200" Height="100" OnClick="btnLanduse_Click" /></td>
        <td>
            <asp:Button ID="btnCatchment" runat="server" Text="Catchment (Watershed) Entry" 
                Width="200" Height="100" OnClick="btnCatchment_Click" /></td>
        <td>
            <asp:Button ID="btnRetention" runat="server" Text="Retention" 
                Width="200" Height="100" OnClick="btnRetention_Click" /></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnExfiltration" runat="server" Text="Exfiltration" 
                Width="200" Height="100" OnClick="btnExfiltration_Click" /></td>
        <td>
            <asp:Button ID="btnWetDetention" runat="server" Text="Wet Detention" Width="200" Height="100" OnClick="btnWetDetention_Click"  /></td>
        <td>
            <asp:Button ID="btnStormwaterHarvesting" runat="server" Text="Stormwater Harvesting" Width="200" Height="100" OnClick="btnStormwaterHarvesting_Click" /></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnPPavement" runat="server" Text="Pervious Pavement" 
                Width="200" Height="100" OnClick="btnPerviousPavement_Click" /></td>
        <td>
            <asp:Button ID="btnBiofiltration" runat="server" Text="Filtration" Width="200" Height="100" OnClick="btnBiofiltration_Click"  /></td>
        <td>
            <asp:Button ID="btnStorage" runat="server" Text="Storage Retention Basin" Width="200" Height="100" OnClick="btnStorage_Click"  /></td>
    </tr>

    </table>
   <asp:Button ID="btnBack" runat="server" Text="Back to Main Menu" 
                Width="655" Height="100" PostBackUrl="~/DefaultLoggedIn.aspx" />

        </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
