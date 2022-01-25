<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdminLinks.ascx.cs" Inherits="SMADA_2012.UserControls.ucAdminLinks" %>
<link href="../Styles.css" rel="stylesheet" type="text/css" />
<asp:Label runat="server" ID="lblAdminLinks" CssClass="linkListHeader" Text="Administrative Links"></asp:Label><br /><br />
<asp:Label runat="server" ID="Label1" CssClass="linkListHeaders" Text="Categories and Codes"></asp:Label><br />
<asp:HyperLink runat="server" ID="hlCreateCategory" Text="Create New Category" NavigateUrl="~/EditCategory.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlAdminCategories" Text="Administer Codes/Categories" NavigateUrl="~/ViewCategories.aspx"></asp:HyperLink><br />

<br /><asp:Label runat="server" ID="Label2" CssClass="linkListHeader2" Text="User Management"></asp:Label><br />
<asp:HyperLink runat="server" ID="hlRoles" Text="Edit User Roles" NavigateUrl="~/EditRoles.aspx"></asp:HyperLink><br />

<br /><asp:Label runat="server" ID="Label3" CssClass="linkListHeader2" Text="Interface Management"></asp:Label><br />
<asp:HyperLink runat="server" ID="hlViewInterface" Text="View Interface Fields" NavigateUrl="~/ReportInterfaceFields.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlGUIFields" Text="Enter Interface Fields" NavigateUrl="~/ViewGUIFields.aspx"></asp:HyperLink><br />
<br /><asp:Label runat="server" ID="Label4" CssClass="linkListHeader2" Text="Table Management"></asp:Label><br />
<asp:HyperLink runat="server" ID="hlReport" Text="Create SQL Report" NavigateUrl="~/EditSQLQuery.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlViewTables" Text="View Tables and Raw Data" NavigateUrl="~/ViewTables.aspx"></asp:HyperLink><br />
<asp:HyperLink runat="server" ID="hlFeedback" Text="View Feedback" NavigateUrl="~/ViewFeedback.aspx"></asp:HyperLink><br />

