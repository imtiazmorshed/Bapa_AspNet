<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucReportAirlinesPayment.ascx.cs"
    Inherits="OMS.WebClient.Controls.wucReportAirlinesPayment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table width="100%">
    <tr>
        <td colspan="4">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Search Option" Font-Bold="True"
                ForeColor="Navy">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Payment No. :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPayment" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" width="25%">
                            <asp:Label ID="Label1" runat="server" Text="Transaction No. :"></asp:Label>
                        </td>
                        <td align="left" width="25%">
                            <asp:TextBox ID="txtTransactionNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Name of Airlines :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAirlinesName" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="left" width="25%">
                        </td>
                        <td align="left" width="25%">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="25%">
                            <asp:Label ID="Label3" runat="server" Text="From Date :"></asp:Label>
                        </td>
                        <td align="left" width="25%">
                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td align="left" width="25%">
                            <asp:Label ID="Label4" runat="server" Text="To Date :"></asp:Label>
                        </td>
                        <td align="left" width="25%">
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
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="4">
            <asp:Panel ID="Panel4" runat="server" GroupingText="Airlines Payment List" Font-Bold="True"
                ForeColor="Navy">
                <asp:ListView ID="lvPayment" runat="server" DataKeyNames="IID" OnItemDataBound="lvPayment_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th align="center">
                                    Date
                                </th>
                                <th align="center">
                                    Payment No
                                </th>
                                <th align="center">
                                    Transaction No
                                </th>
                                <th align="center">
                                    Airlines Name
                                </th>
                                <th align="center">
                                    Ticket Price(In Taka)
                                </th>
                                <th align="center">
                                    Airlines Payable
                                </th>
                                <th align="center">
                                    TAX Amount
                                </th>
                                <th align="center">
                                    Airlines Paid
                                </th>
                                <th align="center">
                                    Airlines Due
                                </th>
                                <th align="center">
                                    Next Payment Date
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="dGridRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnPaymentNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTransactionNo" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPaid" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesDue" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextPaymentDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnPaymentNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTransactionNo" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPaid" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesDue" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextPaymentDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
            </asp:Panel>
        </td>
    </tr>
</table>
