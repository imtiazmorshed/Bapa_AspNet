<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ChannelWiseTotalOrderView.aspx.cs" Inherits="OMS.WebClient.UIInventory.ChannelWiseTotalOrderView" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <table width="100%" >
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Channel Code"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlChannelCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChannelCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Channel Name"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlChannelName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChannelName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="Date From"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                                TargetControlID="txtDateFrom">
                            </cc1:CalendarExtender>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="Date To"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                                TargetControlID="txtDateTo">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnShowOrderDetails" runat="server" Text="Show Order Details" OnClick="btnShowOrderDetails_Click" />
                        </td>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
            <asp:Panel ID="pnl1" runat="server">
                     <asp:ListView ID="lvChannelOrderItemList" runat="server" DataKeyNames="IID" onitemdatabound="lvChannelOrderItemList_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class ="dGridHeaderClass">
                                <th align ="left">
                                    Item Code
                                </th>
                                <th align ="left">
                                    Item Name
                                </th>
                                <th align ="left">
                                    Quantity
                                </th>                                
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr id="trBody" runat="server" class ="dGridRowClass">
                            <td align ="left">
                                <asp:Label ID="lblItemCode" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblItemName" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblQuantity" runat="server"></asp:Label>                                
                            </td>                            
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server" class ="dGridAltRowClass">
                            <td align ="left">
                                <asp:Label ID="lblItemCode" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblItemName" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblQuantity" runat="server"></asp:Label>                                
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
            <td align ="right">
                <asp:Button ID="btnPrint" runat="server" Text="Print" 
                    onclick="btnPrint_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
