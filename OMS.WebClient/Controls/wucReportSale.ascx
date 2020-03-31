<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucReportSale.ascx.cs"
    Inherits="OMS.WebClient.Controls.wucReportSale" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table width="100%">
    <tr>
        <td colspan="4" valign="middle" align="center" style="background-color: #B8DBFF;
            height: 30px">
            <h3>
                <b>Sale Report</b>
            </h3>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label1" runat="server" Text="Transaction No. :"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtTransactionNo" runat="server"></asp:TextBox>
        </td>
        <%--<td align="left">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>--%>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label3" runat="server" Text="From Date :"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                Format="dd/MM/yyyy">
            </cc1:CalendarExtender>
        </td>
        <td align="left">
            <asp:Label ID="Label4" runat="server" Text="To Date :"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" TargetControlID="txtEndDate"
                Format="dd/MM/yyyy">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
        </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Panel ID="pnlPrint" runat="server" valign="top">
                <table width="100%">
                    <tr>
                        <td colspan="4" valign="middle" align="center" style="background-color: #B8DBFF;
                            height: 30px">
                            <p style="text-align: center; font-size: 18px; font-weight: bold">
                                Sanjar Aviation Limited</p>
                            <p style="text-align: center; font-size: 16px; font-weight: bold">
                                Statement of Income</p>
                            <br />
                            <p style="text-align: right; font-size: 12px; font-weight: bold">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <asp:ListView ID="lvBranch" runat="server" DataKeyNames="IID" OnItemDataBound="lvBranch_ItemDataBound">
                                <LayoutTemplate>
                                    <table cellpadding="0" cellspacing="1" width="100%" style="border: 1px solid black;
                                        border-collapse: collapse;">
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="18" bgcolor="#666666" align="left" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblBranch" runat="server" ForeColor="#F2F2F2" Font-Size="12"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trBody" runat="server">
                                        <td colspan="18" style="vertical-align: top; border: 1px solid black;">
                                            <asp:ListView ID="lvTicketSale" runat="server" DataKeyNames="IID" OnItemDataBound="lvTicketSale_ItemDataBound">
                                                <LayoutTemplate>
                                                    <table cellpadding="0" cellspacing="1" width="100%" style="border: 1px solid black;
                                                        border-collapse: collapse;">
                                                        <tr id="tr1" runat="server">
                                                            <th align="center" width="3%" class="thGrid">
                                                                Sl No.
                                                            </th>
                                                            <th align="center" width="8%" class="thGrid">
                                                                Transaction No
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Customer Name
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Reference Name
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Ticket Number
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Airlines Name
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Depart
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Destin
                                                            </th>
                                                            <%--<th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Qty
                                                            </th>--%>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Tax
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Ticket Fair
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Total
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Normal Comm
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Excess Comm
                                                            </th>
                                                            <th align="center" width="5%" style="vertical-align: top; border: 1px solid black;">
                                                                Discount
                                                            </th>
                                                            <th align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                                                Net Comm
                                                            </th>
                                                            <th align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                                                Net Ticket Value
                                                            </th>
                                                            <th align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                                                Collection
                                                            </th>
                                                            <th align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                                                Due Amount
                                                            </th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr id="trBody" runat="server">
                                                        <td align="center" width="3%" class="thGrid">
                                                            <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="8%" class="thGrid">
                                                            <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblReference" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblTicketNo" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblDeparture" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblDestination" runat="server"></asp:Label>
                                                        </td>
                                                        <%--<td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblQty" runat="server"></asp:Label>
                                                        </td>--%>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblTaxAmount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblAmountInTaka" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblNormalCommission" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblExcessCommission" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblTotalDiscount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblNetCommission" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblNetTicketValue" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblCollection" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center" width="6%" valign="top" style="border: 1px solid black;">
                                                            <asp:Label ID="lblDueAmount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    no item to display!!!
                                                </EmptyDataTemplate>
                                            </asp:ListView>
                                        </td>
                                    </tr>
                                    <tr id="tr1" runat="server">
                                        <td align="center" width="3%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="8%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                        </td>
                                        <%--<td align="center" width="5%" valign="top" style="border: 1px solid black;">
                                            <asp:Label ID="lblTotalQty" runat="server"></asp:Label>
                                        </td>                    --%>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalTaxAmount" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalTicketFair" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalTotal" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalNormalCommission" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalExcessCommission" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalTotalDiscount" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalNetCommission" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalNetTicketValue" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="6%" style="vertical-align: top; border: 1px solid black;">
                                            <asp:Label ID="lblTotalDueAmount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    no result found!!!
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="right" valign="top" colspan="4">
            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
        </td>
    </tr>
</table>
