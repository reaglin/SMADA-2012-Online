<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SMADA2013.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Contact Information</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            The program was written by Dr. Ron Eaglin at
            <a href="http://www.daytonastate.edu/">Daytona State College</a> and Dr. Marty Wanielista of the 
            <a href="http://www.stormwater.ucf.edu/">UCF Stormwater Management Academy</a>.
        </p>
    </section>

</asp:Content>