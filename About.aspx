<%@ Page Title="About SMADA Online" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SMADA2013.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>This is all about SMADA Online.</h2>
    </hgroup>

    <article>
        <p>        
        SMADA - Stormwater Management and Design Aid is a free open source tool to perform common
            stormwater calculations.<br/> 
        SMADA is sponsored by the Florida Department of Tranportation. The program was written by Dr. Ron Eaglin at
            <a href="http://www.daytonastate.edu/">Daytona State College</a> and Dr. Marty Wanielista of the 
            <a href="http://www.stormwater.ucf.edu/">UCF Stormwater Management Academy</a>.
        </p>

        <p>        
            If you plan on using SMADA regularly it is recommended that you register an account. This is
            not required, however any data saved to SMADA without a login account is saved anonymously and 
            is available to all other users. Anonymous objects are deleted after one week. 
       </p>
        </p>
            You may also make your objects Global (available to other users). In the manage screen for
            your objects - you have the option to make the object Global.
        </p>

        <p>
            Help links and text can also be entered by users. Help is available for all SMADA items and can be entered
            directly from the edit help link on the help screen.  
        </p>
    </article>

    <aside>
<img src="Images/drippy-medium.gif"/>

    </aside>
</asp:Content>