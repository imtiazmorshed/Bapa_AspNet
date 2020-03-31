<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptVoucher.aspx.cs" Inherits="OMS.WebClient.UIAccount.rptVoucher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voucher</title>
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
                                <td width="60%" align="left" valign="top" colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td width="20%" align="left">
                                                <asp:Image ID="imgLogo" runat="server" />
                                            </td>
                                            <td width="80%" align="left">
                                                <asp:Label ID="lblCompany" runat="server" Text="" Font-Size="Large" Font-Bold="True"></asp:Label><br />
                                                <asp:Label ID="lblAddress" runat="server" Text="" Font-Size="X-Small"></asp:Label><br />
                                                <%--<asp:Label ID="lblBranchName" runat="server" Font-Size="Small" Text="Name of Branch: "></asp:Label>--%>
                                                <asp:Label ID="lblEmail" runat="server" Text="" Font-Size="X-Small"></asp:Label><br />
                                                <asp:Label ID="lblPhone" runat="server" Text="" Font-Size="X-Small"></asp:Label><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <hr />
                                    <asp:Label ID="lblTransactionType" runat="server" Text="DEBIT VOUCHER" Font-Bold="True"></asp:Label>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td width="15%" align="left">
                                                <asp:Label ID="Date" runat="server" Text="Date:"></asp:Label>
                                            </td>
                                            <td width="35%" align="left">
                                                <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td width="15%" align="right">
                                                <asp:Label ID="Label6" runat="server" Text="Voucher No.:"></asp:Label>
                                            </td>
                                            <td width="35%" align="left">
                                                <asp:Label ID="lblTransactionNo" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" align="left">
                                                <asp:Label ID="Label7" runat="server" Text="To/From:"></asp:Label>
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lblToFrom" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" align="left">
                                                <asp:Label ID="Label5" runat="server" Text="Particulars:"></asp:Label>
                                            </td>
                                            <td colspan="3" align="left">
                                                <asp:Label ID="lblParticulars" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:ListView ID="lvTransactionDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvTransactionDetail_ItemDataBound">
                                        <LayoutTemplate>
                                            <table cellpadding="0" cellspacing="1" width="100%" style="border: 1px solid black;
                                                border-collapse: collapse;">
                                                <tr id="tr1" runat="server">
                                                    <td style="text-align: center; vertical-align: top; border: 1px solid black;">
                                                        Sl No.
                                                    </td>
                                                    <td align="center" valign="top" style="vertical-align: top; border: 1px solid black;">
                                                        A/C Name[Number]
                                                    </td>
                                                    <td align="center" valign="top" style="border: 1px solid black;">
                                                        Particular
                                                    </td>
                                                    <td align="center" valign="top" style="border: 1px solid black;">
                                                        Debit
                                                    </td>
                                                    <td align="center" valign="top" style="border: 1px solid black;">
                                                        Credit
                                                    </td>
                                                </tr>
                                                <tr id="itemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr id="trBody" runat="server">
                                                <td align="center" valign="top" style="border: 1px solid black;">
                                                    <asp:Label ID="lblSLNo" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" valign="top" style="border: 1px solid black;">
                                                    <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" valign="top" style="border: 1px solid black;">
                                                    <asp:Label ID="lblParticular" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" valign="top" style="border: 1px solid black;">
                                                    <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" valign="top" style="border: 1px solid black;">
                                                    <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="20%">
                                    Total Amount:
                                </td>
                                <td align="left" width="80%">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="20%" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Taka In Words:"></asp:Label>
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
