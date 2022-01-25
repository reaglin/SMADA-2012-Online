<%@ Page Title="" Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="EditFormHeader.aspx.cs" Inherits="SMADA_2012.EditFormHeader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
  <br />
  Page Being Edited: <asp:Label ID="lblTitle" runat="server"></asp:Label><br />
  <asp:Literal ID="literalHeader" runat="server"></asp:Literal><br />
  <hr />
  <asp:TextBox ID="tbEdit" runat="server" TextMode="MultiLine" Width="800" Height="400"></asp:TextBox><br />
  <asp:LinkButton ID="lbSubmit" runat="server" onclick="lbSubmit_Click">Submit</asp:LinkButton> 
  <asp:LinkButton ID="lbCancel" runat="server" onclick="lbCancel_Click" >Cancel</asp:LinkButton> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
