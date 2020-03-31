<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="CustomerReceivableView.aspx.cs" Inherits="OMS.WebClient.UITicketSale.CustomerReceivableView" Title="" %>
<%@ Register src="../Controls/wucCustomerReceivable.ascx" tagname="wucCustomerReceivable" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:wucCustomerReceivable ID="wucCustomerReceivable1" runat="server" />
</asp:Content>
