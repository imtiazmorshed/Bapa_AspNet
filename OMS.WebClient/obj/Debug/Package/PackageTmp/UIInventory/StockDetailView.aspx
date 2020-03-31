<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="StockDetailView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.StockDetailView" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Department:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Sales Person"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSalesPerson" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Category:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Label" Visible ="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList2" runat="server" Visible ="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Item:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlItem" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Label" Visible ="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" Visible ="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" 
                    onclick="btnSearch_Click" />
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlPrint" runat="server">
                    <asp:ListView ID="lvItem" runat="server" DataKeyNames="IID" OnItemDataBound="lvItem_ItemDataBound">
                        <LayoutTemplate>
                            <table width="100%">
                                <tr class="dGridHeaderClass" id="tr1" runat="server">
                                    <th align="center">
                                        SR #
                                    </th>
                                    <th align="center">
                                        Item Name
                                    </th>
                                    <th align="center">
                                        Item Code
                                    </th>
                                    <th align="center">
                                        Purchase Quantity
                                    </th>
                                    <th align="center">
                                        Purchase Return Quantity
                                    </th>
                                    <th align="center">
                                        Sale Quantity
                                    </th>
                                    <th align="center">
                                        Sale Return Quantity
                                    </th>
                                    <th align="center">
                                        Total Stock
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
                                    <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblItemName" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPurchaseQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPurchaseReturnQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSaleQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSaleReturnQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblTotalStock" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="dGridAltRowClass" id="trBody" runat="server">
                                <td align="center" visible="false">
                                    <asp:Label ID="lblItemID" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblItemName" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPurchaseQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPurchaseReturnQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSaleQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSaleReturnQuantity" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblTotalStock" runat="server"></asp:Label>
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
        <tr>
            <td>
                <asp:Button ID="btnReport" runat="server" Text="Report" 
                    onclick="btnReport_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
