<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNameAndDescription.ascx.cs" Inherits="SMADA2013.UserControls.ucNameAndDescription" %>
              <table style="margin: 0% 0% 0% 5%;">
                  <tr>
                      <td colspan ="2"><h3>Name and Description are used to save and retrieve your files</h3></td>
                  </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Name
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbName" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableLabelCell">
                            Enter Description 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDescription" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
