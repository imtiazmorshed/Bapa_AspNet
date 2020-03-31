<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="rptAirlinesayment.aspx.cs" Inherits="OMS.WebClient.UITicketSale.rptAirlinesayment" Title="" %>
<%@ Register src="../Controls/wucReportAirlinesPayment.ascx" tagname="wucReportAirlinesPayment" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:wucReportAirlinesPayment ID="wucReportAirlinesPayment1" runat="server" />
</asp:Content>
