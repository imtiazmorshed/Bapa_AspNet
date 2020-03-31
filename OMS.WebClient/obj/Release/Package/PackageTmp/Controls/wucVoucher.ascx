<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucVoucher.ascx.cs" Inherits="OMS.WebClient.Controls.wucVoucher" %>
<table width="750px" height="400px">
            <tr>
                <td valign="top">
                    
                        <table width="100%">
                            <tr>
                                <td width="20%" align="left">
                                    <asp:Image ID="imgLogo" runat="server" />
                                </td>
                                <td width="80%" align="left">
                                    <asp:Label ID="lblCompany" runat="server" Text="" Font-Size="Large"
                                        Font-Bold="True"></asp:Label><br />
                                    <asp:Label ID="lblAddress" runat="server" Text="" Font-Size="X-Small"></asp:Label><br />
                                    <%--<asp:Label ID="lblBranchName" runat="server" Font-Size="Small" Text="Name of Branch: "></asp:Label>--%>
                                   
                                    <asp:Label ID="lblEmail" runat="server" Text="" Font-Size="X-Small"></asp:Label><br />
                                    <asp:Label ID="lblPhone" runat="server" Text="" Font-Size="X-Small"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    <asp:Label ID="lblTransactionType" runat="server" Text="DEBIT VOUCHER" Font-Bold="True"></asp:Label>
                                    <br />
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
                                                <asp:TextBox ID="txtParticulars" runat="server" TextMode="MultiLine" Width="95%"
                                                    BorderStyle="None"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:ListView ID="lvTransactionDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvTransactionDetail_ItemDataBound">
                                        <LayoutTemplate>
                                            <table  cellpadding="0" cellspacing="1" width="100%" style="border: 1px solid black;
                                                    border-collapse: collapse;">
                                                <tr id="tr1" runat="server">
                                                    <th align="left" style="vertical-align: middle; border: 1px solid black;">
                                                        Sl No.
                                                    </th>
                                                    <th align="left" style="vertical-align: middle; border: 1px solid black;">
                                                        A/C Name[Number]
                                                    </th>
                                                    <th align="left" style="vertical-align: middle; border: 1px solid black;">
                                                        Particular
                                                    </th>
                                                    <th align="left" style="vertical-align: middle; border: 1px solid black;">
                                                        Debit
                                                    </th>
                                                    <th align="left" style="vertical-align: middle; border: 1px solid black;">
                                                        Credit
                                                    </th>
                                                </tr>
                                                <tr id="itemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr id="trBody" runat="server">
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblSLNo" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblParticular" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr id="trBody" runat="server">
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblSLNo" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblParticular" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="vertical-align: middle; border: 1px solid black;">
                                                    <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
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
                
                </td>
            </tr>
            
        </table>