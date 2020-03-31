<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptReceipt.aspx.cs" Inherits="OMS.WebClient.UITicketSale.rptReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e-Ticket</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="750px" height="400px">
            <tr>
                <td valign="top">
                    <asp:Panel ID="pnlPrint" runat="server" valign="top">
                        <table width="100%">
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
                                    <asp:Label ID="lblTransactionType" runat="server" Text="Credit Voucher" Font-Bold="True"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td width="20%" align="left">
                                                <asp:Label ID="Date" runat="server" Text="Date:"></asp:Label>
                                            </td>
                                            <td width="30%" align="left">
                                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td width="20%" align="left">
                                                <asp:Label ID="Label6" runat="server" Text="Voucher No.:"></asp:Label>
                                            </td>
                                            <td width="30%" align="left">
                                                <asp:Label ID="lblTransactionNo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label7" runat="server" Text="Name of Customer:"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label8" runat="server" Text="Address:"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label5" runat="server" Text="Name of Airlines:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAirlines" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label9" runat="server" Text="Ticket No.:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblTicketNo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" Text="Transaction No.:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReferenceNo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label18" runat="server" Text="Receivable Amount:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReceivableAmount" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label19" runat="server" Text="Received Amount:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReceivedAmount" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label20" runat="server" Text="Due Amount:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDueAmount" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
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
                                            <td width="25%" align="center">
                                                _______________
                                            </td>
                                            <td width="25%" align="center">
                                                _______________
                                            </td>
                                            <td width="25%" align="center">
                                                _______________
                                            </td>
                                            <td width="25%" align="center">
                                                _______________
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" align="center">
                                                <asp:Label ID="Label13" runat="server" Text="Received By"></asp:Label>
                                            </td>
                                            <td width="25%" align="center">
                                                <asp:Label ID="Label14" runat="server" Text="Checked By"></asp:Label>
                                            </td>
                                            <td width="25%" align="center">
                                                <asp:Label ID="Label15" runat="server" Text="Accounts Office"></asp:Label>
                                            </td>
                                            <td width="25%" align="center">
                                                <asp:Label ID="Label16" runat="server" Text="Approved By"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
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
