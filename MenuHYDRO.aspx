<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuHYDRO.aspx.cs" Inherits="SMADA2013.MenuHYDRO" %>
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
        <h2>HYDRO - Rainfall and Hydrograph Generation</h2><br/>
        HYYDRO provides routines to create and save dimensionless rainfall curves, generate rainfall
        from dimensionless curves, save and edit watershed information, and to generate hydrographs
         from watersheds and rainfall.

    <table >
    <tr>
        <td>
            <asp:Button ID="btnWatershed" runat="server" Text="Watershed Entry" 
                OnClick="btnWatershed_Click" Width="200" Height="100" 
                Tooltip="Use this to create a watershed for hydrograph generation"/></td>
        <td>
            <asp:Button ID="btnDimRainfall" runat="server" Text="Dimensionless Rainfall" 
                OnClick="btnDimRainfall_Click" Width="200" Height="100" 
                Tooltip="Use this to create a cumulative dimensionless rainfall "/></td>
        <td>
            <asp:Button ID="btnRainfall" runat="server" Text="Rainfall" OnClick="btnRainfall_Click"  
                Width="200" Height="100"
                Tooltip="Use to enter a rainfall manually or create from a dimensionless curve"/></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnHydrograph" runat="server" Text="Hydrograph Generation" 
                OnClick="btnHydrograph_Click"  Width="200" Height="100"
                Tooltip="Use this to create a hydrograph (requires a watershed and a rainfall)"/></td>
        <td>
            <asp:Button ID="btnUnitHydrograph" runat="server" Text="Coming Soon - Unit Hydrograph" Width="200" Height="100"  /></td>
        <td>
            <asp:Button ID="Button4" runat="server" Text="Coming Soon" Width="200" Height="100" /></td>
    </tr>

    </table>
   <asp:Button ID="btnBack" runat="server" Text="Back to Main Menu" 
                Width="655" Height="100" PostBackUrl="~/DefaultLoggedIn.aspx" />

        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
