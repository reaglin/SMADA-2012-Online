<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuSTATS.aspx.cs" Inherits="SMADA2013.MenuSTATS" %>
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
        <h2>STATS - Statistics Routines</h2><br/>
        STATS provides rotuines for analyzing data that is used in stormwater 
        analysis. Routines include fit to distribution (useful in rainfall prediction), 
        and regression analysis with linear transformation.

    <table >
    <tr>
        <td>
            <asp:Button ID="btnRegression" runat="server" Text="Regression Analysis (REGRESS)" 
                Width="200" Height="100" OnClick="btnRegression_Click" /></td>
        <td>
            <asp:Button ID="btnDistribution" runat="server" Text="Distribution Analysis (DISTRIB)" 
                Width="200" Height="100" OnClick="btnDistribution_Click"  /></td>
        <td></td>
    </tr>
    </table>
   <asp:Button ID="btnBack" runat="server" Text="Back to Main Menu" 
                Width="655" Height="100" PostBackUrl="~/DefaultLoggedIn.aspx" />

        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
