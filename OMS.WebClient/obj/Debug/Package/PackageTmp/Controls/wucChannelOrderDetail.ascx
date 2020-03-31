<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucChannelOrderDetail.ascx.cs"
    Inherits="OMS.WebClient.Controls.wucChannelOrderDetail" %>
<table width="100%">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td align ="left">
                        <asp:Label ID="Label1" runat="server" Text="Channel Code"></asp:Label>
                    </td>
                    <td align ="left">
                        <asp:Label ID="lblChannelCode" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align ="left">
                        <asp:Label ID="Label2" runat="server" Text="Channel Name"></asp:Label>
                    </td>
                    <td align ="left">
                        <asp:Label ID="lblChannelName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align ="left">
                        <asp:Label ID="Label3" runat="server" Text="Order No."></asp:Label>
                    </td>
                    <td align ="left">
                        <asp:Label ID="lblOrderNo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align ="left">
                        <asp:Label ID="Label5" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td align ="left">
                        <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>    
            </table>
        </td>
    </tr>
    <tr>
        <td align ="left">
             <asp:ListView ID="lvOrderDetails" runat="server" DataKeyNames="IID" 
                 onitemcommand="lvOrderDetails_ItemCommand" 
                 onitemdatabound="lvOrderDetails_ItemDataBound">
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
        </td>
    </tr>
    
</table>
