<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptInvoice.aspx.cs" Inherits="OMS.WebClient.UITicketSale.rptInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e-Ticket</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border: 1px; border-color: Black; width: 100%;">
            <tr>
                <td valign="top">
                    <asp:Panel ID="pnlPrint" runat="server" valign="top">
                        <table style="border: 1px solid #C0C0C0; width: 100%;">
                            <tr>
                                <td width="20%" align="left">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/LogoS.jpg" />
                                </td>
                                <td width="80%" align="left">
                                    <asp:Label ID="Label1" runat="server" Text="SANJAR AVIATION LTD." Font-Size="Large"
                                        Font-Bold="True"></asp:Label><br />
                                    <asp:Label ID="Label3" runat="server" Text="Tours & Travels" Font-Size="X-Small"></asp:Label><br />
                                    <asp:Label ID="lblBranchName" runat="server" Font-Size="Small" Text="Name of Branch: "></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    <asp:Label ID="lblTransactionType" runat="server" Text="Invoice" Font-Bold="True"
                                        Font-Size="Larger"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%" style="border: 1px; border-color: Gray; width: 100%;">
                                        <tr>
                                            <td width="15%" align="left" class="tdClass">
                                                <asp:Label ID="Label26" runat="server" Text="Bill To"></asp:Label>
                                            </td>
                                            <td width="45%" align="left" class="tdClass">
                                            </td>
                                            <td width="15%" align="left" class="tdClass">
                                                <asp:Label ID="Date" runat="server" Text="Date:"></asp:Label>
                                            </td>
                                            <td width="25%" align="left" class="tdClass">
                                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" align="left" class="tdClass">
                                                <asp:Label ID="Label5" runat="server" Text="Name:"></asp:Label>
                                            </td>
                                            <td width="45%" align="left" class="tdClass">
                                                <asp:Label ID="lblBillTo" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label6" runat="server" Text="Invoice No.:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblTransactionNo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label8" runat="server" Text="Address:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label23" runat="server" Text="Class:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblClass" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label28" runat="server" Text="Phone:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label24" runat="server" Text="Carrier:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblCarrier" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label29" runat="server" Text="Email:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label25" runat="server" Text="Sector:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblSector" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label2" runat="server" Text="Issue Date:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblIssueDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label21" runat="server" Text="Depat Date:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblDepat" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="Label22" runat="server" Text="Return Date:"></asp:Label>
                                            </td>
                                            <td align="left" class="tdClass">
                                                <asp:Label ID="lblReturnDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:ListView ID="lvTicketSaleDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvTicketSaleDetail_ItemDataBound">
                                        <LayoutTemplate>
                                            <table width="100%" style="border: 1px solid #E0E0E0;">
                                                <tr id="tr1" runat="server">
                                                    <th style="border: thin solid #000000" align="center">
                                                        Sl
                                                    </th>
                                                    <th style="border: thin solid #000000" align="center">
                                                        Passenger Name
                                                    </th>
                                                    <th style="border: thin solid #000000" align="center">
                                                        Ticket No.
                                                    </th>
                                                    <th style="border: thin solid #000000" align="center">
                                                        Ticket Fair In USD
                                                    </th>
                                                    <th style="border: thin solid #000000" align="center">
                                                        Ticket Fair
                                                    </th>
                                                    <th style="border: thin solid #000000" align="center">
                                                        TAX
                                                    </th>
                                                    <th style="border: thin solid #000000" align="center">
                                                        Sub Total
                                                    </th>
                                                </tr>
                                                <tr id="itemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr id="trBody" runat="server" style="border: thin solid #808080">
                                                <td align="center" style="border: thin solid #808080">
                                                    <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="border: thin solid #808080">
                                                    <asp:Label ID="lblPassengerName" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" style="border: thin solid #808080">
                                                    <asp:Label ID="lblTicketNo" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" style="border: thin solid #808080">
                                                    <asp:Label ID="lblTicketFairInUSD" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" style="border: thin solid #808080">
                                                    <asp:Label ID="lblTicketFair" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" style="border: thin solid #808080">
                                                    <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" style="border: thin solid #808080">
                                                    <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table style="border: thin solid #C0C0C0; width: 100%;">
                                        <%--<tr>
                                            <td style="border: thin solid #C0C0C0; text-align :center;">
                                                <asp:Label ID="Label32" runat="server" Text="Sl No."></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; text-align :center;">
                                                <asp:Label ID="Label7" runat="server" Text="Passenger Name"></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; text-align :center;">
                                                <asp:Label ID="Label9" runat="server" Text="Ticket No."></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; text-align :center;">
                                                <asp:Label ID="Label11" runat="server" Text="Fair"></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; text-align :center;">
                                                <asp:Label ID="Label30" runat="server" Text="TAX"></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; text-align :center;">
                                                <asp:Label ID="Label31" runat="server" Text="Amount"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="250px" style="border: thin solid #C0C0C0; vertical-align:top; text-align:center;">
                                            <asp:Label ID="lblSerialNo" runat="server">1</asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; vertical-align:top;text-align:left;">
                                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; vertical-align:top;text-align:center;">
                                                <asp:Label ID="lblTicketNo" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; vertical-align:top;text-align:right;">
                                                <asp:Label ID="lblTicketAmount" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; vertical-align:top; text-align:right;">
                                                <asp:Label ID="lblTAX" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border: thin solid #C0C0C0; vertical-align:top;text-align:right;">
                                                <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td width="50%" colspan="4" rowspan="3">
                                            </td>
                                            <td align="left" style="border: thin solid #C0C0C0;">
                                                <asp:Label ID="Label34" runat="server" Text="Total Amount"></asp:Label>
                                            </td>
                                            <td align="right" style="border: thin solid #C0C0C0;">
                                                <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="border: thin solid #C0C0C0;">
                                                <asp:Label ID="Label33" runat="server" Text="Discount"></asp:Label>
                                            </td>
                                            <td align="right" style="border: thin solid #C0C0C0;">
                                                <asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="border: thin solid #C0C0C0;">
                                                <asp:Label ID="Label36" runat="server" Text="Net Amount"></asp:Label>
                                            </td>
                                            <td align="right" style="border: thin solid #C0C0C0;">
                                                <asp:Label ID="lblNetAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" Text="Name of Airlines:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblAirlines" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label10" runat="server" Text="Departure From:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDeparture" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label12" runat="server" Text="Destination:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDestination" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label17" runat="server" Text="Discount Amount:"></asp:Label>
                                </td>
                                <td align="left">
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td align="left">
                                    <asp:Label ID="Label18" runat="server" Text="Payable Amount:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPayableAmount" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label19" runat="server" Text="Paid Amount:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPaidAmount" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label20" runat="server" Text="Due Amount:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDueAmount" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="20%" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Taka In Words(Paid):"></asp:Label>
                                </td>
                                <td align="left" width="80%" valign="top">
                                    <asp:Label ID="lblTakaInWord" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    <br />
                                    <table width="100%">
                                        <tr>
                                            <td width="10%">
                                            </td>
                                            <td width="25%" align="center">
                                                _______________
                                            </td>
                                            <td width="15%" align="center">
                                            </td>
                                            <td width="15%" align="center">
                                            </td>
                                            <td width="25%" align="center">
                                                _______________
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                            </td>
                                            <td width="25%" align="center">
                                                <asp:Label ID="Label13" runat="server" Text="Received By"></asp:Label>
                                            </td>
                                            <td width="15%" align="center">
                                            </td>
                                            <td width="15%" align="center">
                                            </td>
                                            <td width="25%" align="center">
                                                <asp:Label ID="Label16" runat="server" Text="Authorise by"></asp:Label>
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    Thank you for your business
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
