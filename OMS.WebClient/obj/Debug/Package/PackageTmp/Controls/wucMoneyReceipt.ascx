<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMoneyReceipt.ascx.cs"
    Inherits="OMS.WebClient.Controls.wucMoneyReceipt" %>
<table width="750px" height="400px">
    <tr>
        <td valign="top">
            <table width="100%" style="border: thin solid #808080">
                <tr>
                    <td align="right" colspan="2">
                        <asp:Label ID="lblTransactionType" runat="server" Text="Cash Receipt" 
                            Font-Bold="True" Font-Italic="True" Font-Names="Tahoma" Font-Size="Large" 
                            ForeColor="#336699"></asp:Label>
                            <hr  style="color: #336699" />
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <tr>
                                <td width="20%" align="left" valign="top">
                                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/LogoS.jpg" />
                                </td>
                                <td width="60%" align="left" valign="top">
                                    <asp:Label ID="lblCompany" runat="server" Text="" Font-Size="Large"
                                        Font-Bold="True"></asp:Label><br />
                                    <asp:Label ID="lblAddress" runat="server" Text="" Font-Size="X-Small"
                                        ></asp:Label><br />
                                    <asp:Label ID="lblEmail" runat="server" Text="" Font-Size="X-Small"
                                        ></asp:Label><br />
                                    <asp:Label ID="lblPhone" runat="server" Text="" Font-Size="X-Small"
                                        ></asp:Label><br />
                                </td>
                                <td width="25%" align="left" valign="top">
                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label><br />
                                    <asp:Label ID="lblVoucherNo" runat="server" Text="Voucher No.:"></asp:Label><br />
                                    <%--<asp:Label ID="lblBranchName" runat="server" Font-Size="Small" Text=""></asp:Label>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    <hr  style="color: Gray" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <tr>
                                <td width="15%" align="left" style="border: thin solid #808080">
                                    From:
                                </td>
                                <td width="55%" align="left" style="border: thin solid #808080">
                                    <asp:Label ID="lblToFrom" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td align="left" style="border: thin solid #808080">
                                    <asp:Label ID="lblAmount" runat="server" Text="Tk."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="left" style="border: thin solid #808080">
                                    Amount:
                                </td>
                                <td align="left" colspan="3" style="border: thin solid #808080">
                                    <asp:Label ID="lblTakaInWord" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="left" style="border: thin solid #808080">
                                    Purpose:
                                </td>
                                <td colspan="3" align="left" style="border: thin solid #808080">
                                    <asp:TextBox ID="txtParticulars" runat="server" TextMode="MultiLine" Width="95%"
                                        BorderStyle="None"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="left" style="border: thin solid #808080">
                                    Payment Mode:
                                </td>
                                <td colspan="3" align="left" style="border: thin solid #808080">
                                    <asp:Label ID="lblPaymentMode" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width ="100%">
                            <tr>
                                <td align="left" width="20%" style="border: thin solid #808080">
                                    Total Amount:
                                </td>
                                <td align="right" width="30%" style="border: thin solid #808080">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left" width="20%" valign="top" style="border: thin solid #808080">
                                    Amount Paid:
                                </td>
                                <td align="right" width="30%" valign="top" style="border: thin solid #808080">
                                    <asp:Label ID="lblPaidAmount" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left" width="20%" valign="top" style="border: thin solid #808080">
                                    Balance Due:
                                </td>
                                <td align="right" width="30%" valign="top" style="border: thin solid #808080">
                                    <asp:Label ID="lblBalanceDue" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <br />
                        <table width="100%">
                            <tr>
                                <td width="25%" align="center">
                                </td>
                                <td width="25%" align="center">
                                </td>
                                <td width="25%" align="center">
                                </td>
                                <td width="25%" align="center">
                                    _______________
                                </td>
                            </tr>
                            <tr>
                                <td width="25%" align="center">
                                </td>
                                <td width="25%" align="center">
                                </td>
                                <td width="25%" align="center">
                                </td>
                                <td width="25%" align="center">
                                    <asp:Label ID="Label16" runat="server" Text="Signed"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
