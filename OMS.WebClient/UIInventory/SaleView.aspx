<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="SaleView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.SaleView" Title="" %>

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
                            <asp:Label ID="Label1" runat="server" Text="Customer:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCustomer" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Sales Person:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSalesPerson" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Bill No:"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtBillNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Select Item">
                    <br />
                    <table width="100%">
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                                <%--<asp:Label ID="Label3" runat="server" Text="Cost Price"></asp:Label>--%>
                            </td>
                            <td>
                                <%--<asp:Label ID="Label7" runat="server" Text="Sell Price"></asp:Label>--%>
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <asp:Label ID="Label5" runat="server" Text="Item Name:"></asp:Label>
                                <asp:DropDownList ID="ddlItemName" runat="server" OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                            <asp:Label ID="Label6" runat="server" Text="Item Code:"></asp:Label>
                                <asp:DropDownList ID="ddlItem" runat="server" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                            <asp:Label ID="Label8" runat="server" Text="Item Quantity:"></asp:Label>
                                 <asp:TextBox ID="txtQuantity" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>
                                <%--<asp:TextBox ID="txtCostPrice" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>--%>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtSellPrice" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>--%>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>--%>
                                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
                                <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </td>
                            <td colspan="5">
                                <asp:ListView ID="lvItemBatch" runat="server" DataKeyNames="IID" OnItemDataBound="lvItemBatch_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                                <th align="center">
                                                    Item Batch #
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
                                            <td align="center">
                                                <asp:Label ID="lblItemBatchNo" runat="server"></asp:Label>
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
                        <tr>
                            <td colspan="5" align="left">
                                <asp:ListView ID="lvItem" runat="server" DataKeyNames="IID" 
                                    OnItemDataBound="lvItem_ItemDataBound" onitemcommand="lvItem_ItemCommand">
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
                                                    Item Batch #
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
                                                <th>
                                                    Delete
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
                                                <asp:Label ID="lblItemBatchNo" runat="server"></asp:Label>
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
                                            <td align="center">
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        no item to display!!!
                                    </EmptyDataTemplate>
                                </asp:ListView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>                                               
                                                <td align ="right" width="80%">
                                                    <asp:Label ID="Label11" runat="server" Text="TotalAmount:"></asp:Label>
                                                </td>
                                                <td align ="left" width="20%">
                                                    <asp:TextBox ID="txtTotalAmount" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align ="right" width="80%">
                                                    <asp:Label ID="Label9" runat="server" Text="Special Discount:"></asp:Label>
                                                </td>
                                                <td align ="left" width="20%">
                                                    <asp:TextBox ID="txtSpecialDiscount" runat="server" OnTextChanged="txtSpecialDiscount_TextChanged"
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td align ="right" width="80%">
                                                    <asp:Label ID="Label10" runat="server" Text="Total Payable Amount:"></asp:Label>
                                                </td>
                                                <td align ="left" width="20%">
                                                    <asp:TextBox ID="txtTotalPayableAmount" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td align ="right" width="80%">
                                                    <asp:Label ID="Label12" runat="server" Text="Paid Amount:"></asp:Label>
                                                </td>
                                                <td align ="left" width="20%">
                                                    <asp:TextBox ID="txtPaidAmount" runat="server" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td align ="right" width="80%">
                                                    <asp:Label ID="Label13" runat="server" Text="Due Amount:"></asp:Label>
                                                </td>
                                                <td align ="left" width="20%">
                                                    <asp:TextBox ID="txtDueAmount" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
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
                <asp:Panel ID="Panel3" runat="server" GroupingText="Sales Detail List">
                    <asp:ListView ID="lvSaleDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvSaleDetail_ItemDataBound">
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
                                        Customer Name
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
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
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
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
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
                    <asp:DataPager ID="dpSaleDetail" runat="server" PagedControlID="lvSaleDetail" 
                        PageSize="5" onprerender="dpSaleDetail_PreRender">
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
