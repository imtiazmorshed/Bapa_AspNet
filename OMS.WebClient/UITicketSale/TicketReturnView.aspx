<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="TicketReturnView.aspx.cs" Inherits="OMS.WebClient.UITicketSale.TicketReturnView" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width="100%">
        <tr>
            <td style="color: #800000; font-weight: bold; font-size: 16px; font-family: Verdana;" align="center" colspan="4">
                --:-- Ticket Return Information --:--
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                <asp:Label ID="Label4" runat="server" Text="Invoice Number:"></asp:Label>
            </td>
            <td align="left" width="30%">
                <asp:TextBox ID="txtInvoiceNo" runat="server"></asp:TextBox>
                
            </td>
            
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="Gen"/>                
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name of Customer:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCustomer" runat="server" Text="Name of Customer:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Name of Airline:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAirlines" runat="server" Text="Name of Airlines:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Total Amount:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
            </td>
            <%--<td>
                <asp:Label ID="Label5" runat="server" Text="Name of Airline:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalReturmAmount" runat="server" Text="Total Returm Amount:"></asp:Label>
            </td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Return Amount:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReturnAmount" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Gen" OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" OnClick="btnClose_Click" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <%--<tr>
            <td colspan="4">
                <asp:ListView ID="lvTicketSale" runat="server" DataKeyNames="IID" OnItemDataBound="lvTicketSale_ItemDataBound"
                    OnItemCommand="lvTicketSale_ItemCommand">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th align="center">
                                    Date
                                </th>
                                <th align="center">
                                    Transaction No
                                </th>
                                <th align="center">
                                    Airlines Name
                                </th>
                                <th align="center">
                                    Customer Name
                                </th>
                                <th align="center">
                                    Ticket Price(In Taka)
                                </th>
                                <th align="center">
                                    Airlines Payable
                                </th>
                                <th align="center">
                                    Customer Receivable
                                </th>
                                <%--<th align="center">
                                </th>--%>
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
                                <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerReceivable" runat="server"></asp:Label>
                            </td>
                            <%--<td align="center">
                                <asp:Label ID="lnkbtnDelete" runat="server"></asp:Label>
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerReceivable" runat="server"></asp:Label>
                            </td>
                            <%--<td align="center">
                                <asp:Label ID="lnkbtnDelete" runat="server"></asp:Label>
                            </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <%--<td align="center">
                                <asp:Label ID="lnkbtnDelete" runat="server"></asp:Label>
                            </td>--%>
            </td>
        </tr>--%>
    </table>
</asp:Content>
