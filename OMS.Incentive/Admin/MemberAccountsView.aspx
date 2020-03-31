<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="MemberAccountsView.aspx.cs" Inherits="OMS.Incentive.Admin.MemberAccountsView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference NotifyScriptLoaded="true" Path="~/App_Themes/Default/_lib/js/jquery-1.4.2.min.js" />
            <asp:ScriptReference NotifyScriptLoaded="true" Path="~/App_Themes/Default/_lib/js/vmenu.js" />
            </Scripts>
    </cc1:ToolkitScriptManager>
    <table width="100%" style="border-style: inherit; border-width: thin; border-color: #008080">
        <tr>
            <td colspan="2" style="font-size: large" align="center">--:-- Member Account View --:--
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Membership Code"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMembershipCode" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr >
            <td>
                <asp:Label ID="Label1" runat="server" Text="Membership Expire Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtExpireDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtExpireDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
            </td>
        </tr>
        <tr >
            <td>
                <asp:Label ID="Label3" runat="server" Text="Account Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAccountName" runat="server" Enabled="false" Width="300"></asp:TextBox>

            </td>
        </tr>        
        <tr>
            <td width="25%" align="left" valign="top">
                <asp:Label ID="Label94" runat="server" Text="Opening Balance"></asp:Label>
            </td>
            <td width="75%" align="left" valign="top">
                <asp:TextBox ID="txtOpeningBalance" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>&nbsp;
            </td>
            <td>
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#339933" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="Gen" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Cancel" />
            </td>
        </tr>


    </table>
</asp:Content>
