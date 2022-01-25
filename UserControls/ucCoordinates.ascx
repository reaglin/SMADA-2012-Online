<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCoordinates.ascx.cs" Inherits="SMADA_2012.UserControls.ucCoordinates" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />

<asp:Label runat="server" ID="lblLabel" Text="Coordinates" CssClass="coordinateLabel"></asp:Label>
<asp:TextBox runat="server" ID="tbNSLatitude" Width="100"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="tbNSLatitude_TextBoxWatermarkExtender" 
        runat="server" Enabled="True" TargetControlID="tbNSLatitude" WatermarkText="N/S (latitude)" WatermarkCssClass="watermark">
    </asp:TextBoxWatermarkExtender>&nbsp;
    
<asp:TextBox runat="server" ID="tbEWLongitude" Width="100"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="tbEWLongitude_TextBoxWatermarkExtender" 
        runat="server" Enabled="True" TargetControlID="tbEWLongitude" WatermarkText="E/W (Longitude)" WatermarkCssClass="watermark">
    </asp:TextBoxWatermarkExtender>&nbsp;
    

<asp:ComboBox ID="cbCoordinateFormat" runat="server" >
    </asp:ComboBox>&nbsp;
