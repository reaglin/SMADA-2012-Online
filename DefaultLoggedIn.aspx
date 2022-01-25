<%@ Page Title="SMADA Online Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultLoggedIn.aspx.cs" Inherits="SMADA2013.DefaultLoggedIn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

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
    <div class="content-wrapper">
    <table>
    <tr>
        <td>
            <asp:Button ID="btnHydro" runat="server" Text="HYDRO - Rainfall and Hydrograph Generation" Height="100" Width="310" PostBackUrl="MenuHYDRO.aspx" /></td>
    
        <td >
            <asp:Button ID="btnBPTRAINS" runat="server" Text="BMPTRAINS BMP Selection and Pollutant Analysis" Height="100" Width="310" PostBackUrl="~/MenuBMPTRAINS.aspx" /></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSTATS" runat="server" Text="STATS - Statistics Routines" Height="100" Width="310" PostBackUrl="~/MenuSTATS.aspx" /></td>
        <td ></td>
    </tr>

        </table>
        <table>
    <tr>
        <td>
            <asp:Button ID="btnCircularChannel" runat="server" Text="Circular Channel Calculator (CPCALC)" 
                Width="200" Height="100" OnClick="btnCircularChannel_Click" 
                Tooltip="Calculate the depth or flow rate of an open circular channel"/></td>
        <td>
            <asp:Button ID="btnTrapezoidalChannel" runat="server" Text="Trapezoidal Channel Calculator (CPCALC)" 
                Width="200" Height="100" OnClick="btnTrapezoidalChannel_Click" 
                Tooltip="Calculate the depth or flow rate of a trapezoidal channel" /></td>
        <td>
            <asp:Button ID="btnTimeOfConcentration" runat="server" Text="Time of Concentration Calculator (TCCALC)" 
                Width="200" Height="100" OnClick="btnTimeOfConcentration_Click"/></td>
    </tr>
   
    </table>
    Link to <asp:HyperLink ID="hlDocumentation" runat="server" NavigateUrl="https://smadaonline.pbworks.com/" Target="_new">SMADA Documentation</asp:HyperLink>

        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
