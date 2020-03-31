<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptVoucher.aspx.cs" Inherits="OMS.WebClient.UITicketSale.rptVoucher" %>

<%@ Register Src="../Controls/wucVoucher.ascx" TagName="wucVoucher" TagPrefix="uc1" %>
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
                <td>
                    <asp:Panel ID="pnlPrint" runat="server" valign="top">
                        <uc1:wucVoucher ID="wucVoucher1" runat="server" />
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
