<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="PurchaseView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.PurchaseView" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Supplier:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSupplier" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Bill #:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBillNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Item Information">
                                <br />
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblItem1" runat="server">Item</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label4" runat="server">Cost Price</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label5" runat="server">Sell Price</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label6" runat="server">Quantity</asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlItem" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCostPrice" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSellPrice" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="left">
                                            <asp:ListView ID="lvItem" runat="server" DataKeyNames="IID" OnItemDataBound="lvItem_ItemDataBound">
                                                <LayoutTemplate>
                                                    <table width="100%">
                                                        <tr class="dGridHeaderClass" id="tr1" runat="server">
                                                            <th align="center">
                                                                Item Name
                                                            </th>
                                                            <th align="center">
                                                                Item Code
                                                            </th>
                                                            <th align="center">
                                                                Cost Price
                                                            </th>
                                                            <th align="center">
                                                                Sell Price
                                                            </th>
                                                            <th align="center">
                                                                Quantity
                                                            </th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr class="dGridRowClass" id="trBody" runat="server">
                                                        <td align="center" visible="false">
                                                            <asp:Label ID="lblItemID" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblItemName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblCostPrice" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblSellPrice" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    no item to display!!!
                                                </EmptyDataTemplate>
                                            </asp:ListView>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Panel ID="Panel3" runat="server" GroupingText="Purchase Detail List">
                    <asp:ListView ID="lvPurchaseDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvPurchaseDetail_ItemDataBound"
                        OnItemCommand="lvPurchaseDetail_ItemCommand">
                        <LayoutTemplate>
                            <table width="100%">
                                <tr class="dGridHeaderClass" id="tr1" runat="server">
                                    <th align="center">
                                        Date
                                    </th>
                                    <th align="center">
                                        Transaction No
                                    </th>
                                    <th align="center">
                                        Supplier Name
                                    </th>
                                    <th align="center">
                                        Total Price
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
                                    <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="dGridAltRowClass" id="trBody" runat="server">
                                <td align="center">
                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            no item to display!!!
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:DataPager ID="dpPurchaseDetail" runat="server" PagedControlID="lvPurchaseDetail" PageSize="5"
                        OnPreRender="dpPurchaseDetail_PreRender">
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
                    </asp:DataPager>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
