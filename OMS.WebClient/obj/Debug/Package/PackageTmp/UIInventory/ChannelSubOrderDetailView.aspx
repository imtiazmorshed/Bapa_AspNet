<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ChannelSubOrderDetailView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.ChannelSubOrderDetailView" Title="Untitled Page" %>

<%@ Register Src="../Controls/wucChannelOrderDetail.ascx" TagName="wucChannelOrderDetail"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" >
        <tr>
            <td>
                <asp:Panel ID="pnl1" runat="server"> 
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label1" runat="server" Text="Channel Code"></asp:Label>
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlChannelCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChannelCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label2" runat="server" Text="Channel Name"></asp:Label>
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlChannelName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChannelName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label3" runat="server" Text="Date From"></asp:Label>
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label4" runat="server" Text="Date To"></asp:Label>
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo">
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
                                <asp:ListView ID="lvChannelOrderList" runat="server" DataKeyNames="IID" OnItemCommand="lvChannelOrderList_ItemCommand"
                                    OnItemDataBound="lvChannelOrderList_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                                <th align="left">
                                                    Serial No
                                                </th>
                                                <th align="left">
                                                    Details
                                                </th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <%--<GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>--%>
                                    <ItemTemplate>
                                        <tr id="trBody" runat="server" class="dGridRowClass">
                                            <td align="center">
                                                <asp:Label ID="lblSerialNo" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <uc1:wucChannelOrderDetail ID="wucChannelOrderDetail1" runat="server" />
                                                <%--<asp:UserControl ID="wucChannelOrderDetail"  runat="server" ></asp:UserControl>--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr id="trBody" runat="server" class="dGridAltRowClass">
                                            <td align="center">
                                                <asp:Label ID="lblSerialNo" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <uc1:wucChannelOrderDetail ID="wucChannelOrderDetail1" runat="server" />
                                                <%--<asp:UserControl ID="wucChannelOrderDetail"  runat="server" ></asp:UserControl>--%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <EmptyDataTemplate>
                                        no item to display!!!
                                    </EmptyDataTemplate>
                                </asp:ListView>
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
