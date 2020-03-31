<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="accountReport.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.accountReport" Title="Accounts Report" %>

<%@ Register Src="../Controls/accountTree.ascx" TagName="accountTree" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="font-size: large" align="center">
                --:-- Account Report at a glance --:--
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlChartOfAccount" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChartOfAccount_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:accountTree ID="accountTree1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
