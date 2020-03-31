<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ReceiveTransactionView.aspx.cs" Inherits="OMS.WebClient.UIAccount.ReceiveTransactionView" Title="Receive" %>
<%@ Register src="../Controls/ucTransaction.ascx" tagname="ucTransaction" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ucTransaction ID="ucTransaction1" runat="server" />
    
</asp:Content>
