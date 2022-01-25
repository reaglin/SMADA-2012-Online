<%@ Page Title="Leave Feedback for Page " Language="C#" MasterPageFile="~/ISRID.Master" AutoEventWireup="true" CodeBehind="InsertFeedback.aspx.cs" Inherits="SMADA_2012.InsertFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormContents" runat="server">
    <table>
<tr>
<td>Leave Feedback for <br />
    <asp:Label ID="lblPage" runat="server" Text=""></asp:Label></td>
<td>
    <asp:TextBox ID="tbFeedback" runat="server" TextMode="MultiLine" Width="500" Rows="10"></asp:TextBox></td>
</tr>
</table><br />
<div style="text-align:center">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submitButton" 
        onclick="btnSubmit_Click" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="sp_InsertFeedback" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="PageName" SessionField="PageName" Type="String" />
            <asp:ControlParameter ControlID="tbFeedback" Name="FeedbackText" 
                PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="EnteredByUserID" SessionField="UserID" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
