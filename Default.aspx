<%@ Page Title="SMADA Online Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SMADA2013._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Page.Title %></h1>
                <h2>- Tools for Stormwater Management.</h2>
            </hgroup>
            <p>
            SMADA (Stormwater Management and Design Aid) is a collection of tools to assist in 
                analysis and design of stormwater systems. These include tools to perform hydraulic calculations,
                hydrologic calculations, hydrograph generation, statistical calculations, BMP selection, and pollutant 
                loading. The system is expanded with new tools on a regular basis. Click here for        <asp:HyperLink ID="hlDocumentation" runat="server" NavigateUrl="https://smadaonline.pbworks.com/" Target="_new">documentation</asp:HyperLink>
 
                <br /><br />
                The site is absolutely free and is a supported open source software project.
                <br/><br/>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="DefaultLoggedIn.aspx">Click Here to Enter</asp:HyperLink>
                </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table><tr><td>
    <h3>Some more information about SMADA:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            To save and retrieve objects you must create a SMADA account. Use the <b>Register</b> link in the upper right corner
            to register for an account. SMADA uses open authorization so you can login using your Google
            account. A user account is not required to use SMADA. If you do not create a login all objects are saved anonymously
            and will be available to other users and deleted on a regular basis. (Anonymous Access) 
        </li>
        <li class="two">
            <h5>The Authors</h5>
            SMADA is sponsored by the Florida Department of Tranportation. The program was written by Dr. Ron Eaglin at
            <a href="http://www.daytonastate.edu/">Daytona State College</a> and Dr. Marty Wanielista of the 
            <a href="http://www.stormwater.ucf.edu/">UCF Stormwater Management Academy</a>.
        </li>
    </ol>
        </td><td><img src="Images/drippy-medium.gif"/></td></tr></table>
</asp:Content>
