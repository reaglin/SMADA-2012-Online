<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSelectCatchment.ascx.cs" Inherits="SMADA2013.UserControls.ucSelectCatchment" %>
              <table style="margin: 0% 0% 0% 5%;">
                    <tr>
                        <td colspan="2"><h3>Catchment values are required for calculations, you can get these
                            from an existing catchment or enter them directly.</h3>
                        </td>
                  </tr>
                  <tr>
                        <td class="TableLabelCell">
                            <asp:Label ID="lblCatchment" runat="server" Text="Select Catchment or Enter Values" CssClass="UseCatchment"></asp:Label>
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlCatchment" runat="server" CssClass="DropDownList"></asp:DropDownList>
                            <asp:Button ID="btnSelectCatchment" runat="server" Text="Select" OnClick="btnSelectCatchment_Click" />
                        </td>
                    </tr>
                   <tr>
                        <td class="TableLabelCell">
                            Select Rainfall Zone 
                        </td>
                        <td class="TableEntryCell">
                            <asp:DropDownList ID="ddlRainfallZone" runat="server" CssClass="DropDownList"></asp:DropDownList>
                        </td>
                    </tr>
                   <tr>
                        <td class="TableLabelCell">
                            Enter Annual Rainfall (in) 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbAnnualRainfall" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   <tr>
                        <td class="TableLabelCell">
                            Enter Catchment Total Area (acres) 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbTotalArea" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="TableLabelCell">
                            Enter Non-Directly Connected Impervious Area Curve Number 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbNDCIA_CN" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="TableLabelCell">
                            Enter Percent Directly Connected Impervious Area (%) 
                        </td>
                        <td class="TableEntryCell">
                            <asp:TextBox ID="tbDCIA" runat="server"></asp:TextBox>
                        </td>
                    </tr>
              </table>
