<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ChannelOrderDetailView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.ChannelOrderDetailView" Title="Untitled Page" %>

<%@ Register src="../Controls/wucChannelOrderDetail.ascx" tagname="wucChannelOrderDetail" tagprefix="uc1" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" >
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align ="left">
                            <asp:Label ID="Label1" runat="server" Text="Channel Code"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:DropDownList ID="ddlChannelCode" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlChannelCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align ="left">
                            <asp:Label ID="Label2" runat="server" Text="Channel Name"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:DropDownList ID="ddlChannelName" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlChannelName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align ="left">
                            <asp:Label ID="Label3" runat="server" Text="Order No."></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:DropDownList ID="ddlOrderNo" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlOrderNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align ="left">
                            <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate">
                            </cc1:CalendarExtender>
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <%--<td style="border-color: #C0C0C0; background-color: #C0C0C0;">--%>
            <td>
                <asp:Panel ID="pnl1" runat="server">
                
                <uc1:wucChannelOrderDetail ID="wucChannelOrderDetail1" runat="server" />
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
