<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true"
    CodeBehind="NoPermission.aspx.cs" Inherits="OMS.WebClient.NoPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; height: 100%; border-right">
        <tr>
            <td align="center" class="ContentText" style="height: 460px">
                <span style="font-size: 25px; color: cornflowerblue; font-family: Verdana">
                    <asp:Label ID="lblErr" runat="server" Text="You have no access  on this page"></asp:Label></span>
            </td>
        </tr>
    </table>
</asp:Content>
