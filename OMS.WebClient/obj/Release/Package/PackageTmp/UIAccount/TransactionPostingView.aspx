<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="TransactionPostingView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.TransactionPostingView" Title="Transaction Posting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="font-size: large" align="center" colspan="2">
                --:--  Transaction Posting  --:--
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="Transaction Status"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlTransactionStatus" runat="server" AutoPostBack="True" CausesValidation ="false" onselectedindexchanged="ddlTransactionStatus_SelectedIndexChanged" >
                <asp:ListItem Value="-1">Select Transaction Status</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="To date"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFromDate"
                    ControlToValidate="txtToDate" ErrorMessage="LessThanEqual" Operator="LessThanEqual"></asp:CompareValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ListView ID="lvTransactionPosting" runat="server" DataKeyNames="IID" OnItemDataBound="lvTransactionPosting_ItemDataBound"
                    OnItemCommand="lvTransactionPosting_ItemCommand">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th align="left">
                                    SL No.
                                </th>
                                <th align="left">
                                    Transaction Date
                                </th>
                                <th align="left">
                                    Transaction Code
                                </th>
                                <th align="left">
                                    Pay Reason(Particulars)
                                </th>
                                <th align="left">
                                    Select
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr id="trBody" runat="server" class="dGridRowClass">
                            <td align="left">
                                <asp:Label ID="lblSLNo" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkbtnTransactionCode" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPayReason" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="chkPost" runat="server" CausesValidation ="false"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="5" style="border: medium inset #008080">
                                <asp:ListView ID="lvTransactionDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvTransactionDetail_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                                <th align="left">
                                                    A/C Name[Number]
                                                </th>
                                                <th align="left">
                                                    Description
                                                </th>
                                                <th align="left">
                                                    Debit
                                                </th>
                                                <th align="left">
                                                    Credit
                                                </th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="trBody" runat="server" class="dGridRowClass">
                                            <td align="left">
                                                <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <%--<EmptyDataTemplate>
                                        no item to display!!!
                                    </EmptyDataTemplate>--%>
                                </asp:ListView>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnPost" runat="server" Text="Post" OnClick="btnPost_Click" CausesValidation ="false"/>
            </td>
        </tr>
    </table>
</asp:Content>
