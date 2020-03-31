<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="PaymentTransactionView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.acc_Transaction" Title="Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/ucTransaction.ascx" TagName="ucTransaction" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <uc1:ucTransaction ID="ucTransaction1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
