<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="LedgerBalanceView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.LedgerBalanceView" Title="Ledger Balance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="font-size: large" align="center">
                <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ALLogo.jpg" 
                                        Height="70px" Width="301px" />
                                    <br />--%>
                Ledger Balance Statement
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Account Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAccountName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Account No.:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAccountNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="From:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                            <%--<cc1:TextBoxWatermarkExtender ID="txtFromDate_TextBoxWatermarkExtender" runat="server"
                                TargetControlID="txtFromDate" WatermarkText="Select From Date" WatermarkCssClass="WaterMarkClass">
                            </cc1:TextBoxWatermarkExtender>--%>
                            <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <%--Format="dd/MM/yyyy"--%>
                            <%--<asp:RegularExpressionValidator ID="revFromDate" runat="server" 
                                ControlToValidate="txtFromDate" ErrorMessage="Input a valid Date" 
                                ValidationExpression="^[0-2]?[1-9](/|-)[0-3]?[0-9](/|-)[1-2][0-9][0-9][0-9]$"></asp:RegularExpressionValidator>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="To:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>                            
                            <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                Width="80px" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlPrint" runat="server" valign="top">
                    <table width="100%">
                        <tr>
                            <td style="color: #808080; font-size: large" align="center">
                                <asp:Image ID="imgLogo" runat="server"/>
                                  <br />
                                    <asp:Label ID="lblCompany" runat="server" Text="" style="font-size:15px; font-weight:bold;"></asp:Label>
                                <br />
                                Ledger Balance-<asp:Label ID="lblAccountName" runat="server" Text="Label" Style="color: #808080;
                                    font-size: medium"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListView ID="lvLedgerBalance" runat="server" DataKeyNames="IID" OnItemDataBound="lvLedgerBalance_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                                <th align="left" width="10%">
                                                    Tr. Date
                                                </th>
                                                <th align="left" width="15%">
                                                    Voucher
                                                </th>
                                                <th align="left" width="15%">
                                                    A/C Name[Number]
                                                </th>
                                                <th align="left" width="30%">
                                                    Description
                                                </th>
                                                <th align="left" width="10%">
                                                    Debit
                                                </th>
                                                <th align="left" width="10%">
                                                    Credit
                                                </th>
                                                <th align="left" width="10%">
                                                    Balance
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
                                                <asp:Label ID="lblVoucherNo" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                                            <td align="left">
                                                <asp:Label ID="lblTransactionDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblVoucherNo" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <EmptyDataTemplate>
                                        no item to display!!!
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <%--<asp:DataPager ID="dpLedgerBalance" runat="server" PagedControlID="lvLedgerBalance" PageSize="5">
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
            <td align="right">
                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
