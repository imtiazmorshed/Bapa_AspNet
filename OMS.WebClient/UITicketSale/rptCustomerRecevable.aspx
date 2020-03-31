<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="rptCustomerRecevable.aspx.cs" Inherits="OMS.WebClient.UITicketSale.rptCustomerRecevable" Title="" %>
<%@ Register src="../Controls/wucCustomerReceivable.ascx" tagname="wucCustomerReceivable" tagprefix="uc1" %>
<%@ Register src="../Controls/wucReportCustomerReceivable.ascx" tagname="wucReportCustomerReceivable" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:wucReportCustomerReceivable ID="wucReportCustomerReceivable1" 
        runat="server" />
</asp:Content>
