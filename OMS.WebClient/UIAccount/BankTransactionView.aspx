<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="BankTransactionView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.BankTransactionView" Title="Bank Transaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td colspan="2" style="font-size: large" align="center">
                --:-- Bank Transaction --:--
            </td>
        </tr>
        <tr>
            <td align ="right">
                <asp:Label ID="Label3" runat="server" Text="Select Transaction Type :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTransationType" runat="server">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ValidationGroup="v1"
                    ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlTransationType">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align ="right">
                <asp:Label ID="Label1" runat="server" Text="From Cheque Date :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td align ="right">
                <asp:Label ID="Label2" runat="server" Text="To Cheque Date :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td align ="right">
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    ValidationGroup="v1" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlBankTransaction" runat="server" GroupingText="Bank Transaction List">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:ListView ID="lvTransaction" runat="server" DataKeyNames="IID" OnItemCommand="lvTransaction_ItemCommand"
                                    OnItemDataBound="lvTransaction_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                                <th align="left">
                                                    Transaction Date
                                                </th>
                                                <th align="left">
                                                    Jurnal Code
                                                </th>
                                                <th align="left">
                                                    Cheque Date
                                                </th>
                                                <th align="left">
                                                    Cheque Leaf No
                                                </th>
                                                <th align="left">
                                                    Amount
                                                </th>
                                                <th align="left">
                                                    Cheque Leaf Status
                                                </th>
                                                <th>
                                                </th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="trBody" runat="server" class="dGridRowClass">
                                            <td align="left">
                                                <asp:Label ID="lblTransactionDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblJurnalCode" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblChequeDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblChequeLeafNo" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlChequeLeafStatus" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr id="trBody" runat="server" class="dGridAltRowClass">
                                            <td align="left">
                                                <asp:Label ID="lblTransactionDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblJurnalCode" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblChequeDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblChequeLeafNo" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlChequeLeafStatus" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <EmptyDataTemplate>
                                        no item to display!!!
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <%--<asp:DataPager ID="dpTransaction" runat="server" PagedControlID="lvTransaction" PageSize="5"
                    OnPreRender="dpTransaction_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                            ShowNextPageButton="False" ShowFirstPageButton="False" />
                        <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                            NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                            ButtonType="Link" />
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                            NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                            ShowLastPageButton="False" />
                    </Fields>
                </asp:DataPager>--%>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" />
            </td>
        </tr>
    </table>
</asp:Content>
