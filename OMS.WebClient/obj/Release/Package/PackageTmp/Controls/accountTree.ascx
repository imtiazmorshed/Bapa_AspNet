<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="accountTree.ascx.cs" Inherits="OMS.WebClient.Controls.accountTree" %>
<asp:TreeView ID="tvShartofAccount" runat="server" ImageSet="Msdn" 
        NodeIndent="10" 
    onselectednodechanged="tvShartofAccount_SelectedNodeChanged">
        <ParentNodeStyle Font-Bold="false" />
        <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" 
            Font-Underline="True" />
        <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" 
            BorderWidth="1px" Font-Underline="False" HorizontalPadding="3px" 
            VerticalPadding="1px" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px" /> 
</asp:TreeView>