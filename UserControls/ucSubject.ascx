<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSubject.ascx.cs" Inherits="SMADA_2012.UserControls.ucSubject" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />

<asp:Label ID="lblNum" runat="server" Text="1"></asp:Label>
<asp:TextBox ID="tbAge" runat="server" Width="50"></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="tbAge_TextBoxWatermarkExtender" 
        runat="server" TargetControlID="tbAge" WatermarkCssClass="watermark" >
    </asp:TextBoxWatermarkExtender>

<asp:ComboBox ID="cbSex" runat="server" Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbLocal" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbWeight" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbHeight" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbBuild" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbFitness" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbExperience" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbEquipment" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbClothing" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbSurvival" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbMental" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbStatus" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbMechanism" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbInjuryType" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbIllness" runat="server"  Width="50"></asp:ComboBox>
<asp:ComboBox ID="cbTxBy" runat="server"  Width="50"></asp:ComboBox>

