<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucReportCustomerReceivable.ascx.cs" Inherits="OMS.WebClient.Controls.wucReportCustomerReceivable" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table width="100%">
    <tr>
        <td colspan="4">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Search Option" Font-Bold="True"
                ForeColor="Navy">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Received No. :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReceived" runat="server"></asp:TextBox>
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
                            <asp:Label ID="Label5" runat="server" Text="Name of Customer :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCustomer" runat="server">
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
                                Format="dd/MM/yyyy"></cc1:CalendarExtender>
                        </td>
                        <td align="left" width="25%">
                            <asp:Label ID="Label4" runat="server" Text="To Date :"></asp:Label>
                        </td>
                        <td align="left" width="25%">
                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" TargetControlID="txtEndDate"
                                Format="dd/MM/yyyy"></cc1:CalendarExtender>
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
            <asp:Panel ID="Panel4" runat="server" GroupingText="Customer Receivable List" Font-Bold="True"
                ForeColor="Navy">
                <asp:ListView ID="lvReceivable" runat="server" DataKeyNames="IID" 
                    onitemdatabound="lvReceivable_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th align="center">
                                    Date
                                </th>
                                <th align="center">
                                    Received No
                                </th>
                                <th align="center">
                                    Transaction No
                                </th>
                                <th align="center">
                                    Customer Name
                                </th>
                                <th align="center">
                                    Ticket Price(In Taka)
                                </th>
                                <th align="center">
                                    TAX Amount
                                </th>
                                <th align="center">
                                    Customer Receivable
                                </th>                                
                                <th align="center">
                                    Customer Received
                                </th>
                                <th align="center">
                                    Customer Due
                                </th>
                                <th align="center">
                                    Next Receivable Date
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
                                <asp:LinkButton ID="lnkbtnReceivedNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTransactionNo" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerReceivable" runat="server"></asp:Label>
                            </td>                            
                            <td align="center">
                                <asp:Label ID="lblCustomerReceived" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerDue" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextReceivableDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnReceivedNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTransactionNo" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerReceivable" runat="server"></asp:Label>
                            </td>                            
                            <td align="center">
                                <asp:Label ID="lblCustomerReceived" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerDue" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextReceivableDate" runat="server"></asp:Label>
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
