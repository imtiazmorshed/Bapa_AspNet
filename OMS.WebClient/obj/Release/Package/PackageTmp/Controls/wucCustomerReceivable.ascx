<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCustomerReceivable.ascx.cs"
    Inherits="OMS.WebClient.Controls.wucCustomerReceivable" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table width="100%">
    <tr>
        <td colspan="4" valign="middle" align="center" style="background-color: #B8DBFF;
            height: 30px">
            <h3>
                <b>Customer Receipt View</b>
            </h3>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="font-size: large" align="center">
            <br />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label" runat="server" Text="Customer Name :"></asp:Label>
        </td>
        <td align="left" colspan ="4">
            <asp:DropDownList ID="ddlCustomer" runat="server">
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlCustomer"
                Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ValueToCompare="-1" ValidationGroup="Gen"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" ValidationGroup="Gen" />
        </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <asp:Label ID="lblMSGReceivableStatus" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="25%">
                            <asp:Label ID="Label8" runat="server" Text="Receipt Date :"></asp:Label>
                        </td>
                        <td align="left" width="25%">
                            <asp:TextBox ID="txtReceiptDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender_txtReceiptDate" runat="server" TargetControlID="txtReceiptDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <asp:Label ID="Label16" runat="server" Text="dd/mm/yyyy"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtReceiptDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                                SetFocusOnError="True" Display="Dynamic" ValidationGroup="receipt"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfv" runat="server" ControlToValidate="txtReceiptDate"
                                SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                                ValidationGroup="receipt" ErrorMessage="*">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Total Receivable Amount :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTotalReceivableAmount" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Total Received Amount :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTotalReceivedAmount" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="Total Due Amount :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTotalDueAmount" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Receive Amount :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReceiveAmount" runat="server" OnTextChanged="txtReceiveAmount_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtReceiveAmount"
                                ErrorMessage="*" Display="Dynamic" ValidationGroup="receipt">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label7" runat="server" Text="Due Amount :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDue" runat="server" Enabled="False"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtReceiveAmount" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="Next Receivable Date:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNextReceivableDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender_txtNextReceivedDate" runat="server" TargetControlID="txtNextReceivableDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td align="left" valign="top">
                            <asp:Label ID="Label11" runat="server" Text="Receivable Mode :"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:DropDownList ID="ddlReceivableMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReceivableMode_SelectedIndexChanged">
                                <asp:ListItem Value="-1">Select Received Mode</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlReceivableMode"
                                Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ValueToCompare="-1" ValidationGroup="receipt"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <div runat="server" id="dvChequeReceipt">
                                        <table width="100%">
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label15" runat="server" Text="Bank Name :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label12" runat="server" Text="Branch Name :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label17" runat="server" Text="Bank Account :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:TextBox ID="txtBankAccount" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label18" runat="server" Text="Cheque Leaf No. :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:TextBox ID="txtChequeLeafNo" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlReceivableMode" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div runat="server" id="dvChequePayment">
                                        <table width="100%">
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label13" runat="server" Text="Bank Name :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                                        ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBank">
                                                    </asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label14" runat="server" Text="Branch Name :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:DropDownList ID="ddlBranch" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                                        ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBranch">
                                                    </asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="37%" align="right">
                                                    <asp:Label ID="Label19" runat="server" Text="Bank Account :"></asp:Label>
                                                </td>
                                                <td width="63%">
                                                    <asp:DropDownList ID="ddlAccountName" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                                        ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlAccountName">
                                                    </asp:CompareValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlReceivableMode" />
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBank" />
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBranch" />
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlAccountName" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <div id="dvChequeDate" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label27" runat="server" Text="Cheque Date :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtChequeDate" runat="server"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server" TargetControlID="txtChequeDate"
                                                        Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlReceivableMode" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnPay" runat="server" Text="Receive" OnClick="btnPay_Click" ValidationGroup="receipt" />
                        </td>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
    <tr>
        <td align="left" colspan="4">
            <asp:Panel ID="Panel4" runat="server" GroupingText="Customer Receipt List" Font-Bold="True"
                ForeColor="Navy">
                <asp:ListView ID="lvReceivable" runat="server" DataKeyNames="IID" OnItemDataBound="lvReceivable_ItemDataBound"
                    OnItemCommand="lvReceivable_ItemCommand">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th align="center">
                                    Date
                                </th>
                                <th align="center">
                                    Receipt No
                                </th>
                                <th align="center">
                                    Customer Name
                                </th>
                                <th align="center">
                                    Received Amount
                                </th>
                                <th align="center">
                                    Due Amount
                                </th>
                                <th align="center">
                                    Next Receivable Date
                                </th>
                                <th align="center">
                                    Money Receipt
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
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblReceivedAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDueAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextReceivableDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnMoneyReceipt" runat="server"></asp:LinkButton>
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
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblReceivedAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDueAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextReceivableDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnMoneyReceipt" runat="server"></asp:LinkButton>
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
