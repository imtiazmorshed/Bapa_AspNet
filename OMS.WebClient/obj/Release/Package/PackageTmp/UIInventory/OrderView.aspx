<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="OMS.WebClient.UIInventory.OrderView" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width = "100%" style="border-color: #C0C0C0; border-style: solid; border-width: thin">
    <tr>    
        <td>
            <table width = "100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Order No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderNo" runat="server"></asp:TextBox>
                    </td>
                    <td>                    
                        <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Channel Code"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlChannelCode" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Channel Name"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlChannelName" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
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
        </td>
    </tr>
</table>
</asp:Content>
