<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/OMS.Master"
    AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PTech_BIID.Web.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .changePass_box
        {
            background: url('../App_Themes/Default/_lib/common/about_sub.png') top left no-repeat;
            width: 430px;
            height: 221px;
            display: block;
            padding: 30px 10px 0 10px;
            color: #fff;
            font-weight: bold;
            font-size: 18px;
            letter-spacing: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       <h2 class="headline2" align="center">
            <span>Change Password</span>
        </h2>
        <table width="100%">
            <tr>
                <td align="center">
                    <div class="changePass_box">
                        <%--<div style="padding-left: 90px">--%>
                        <%--<asp:ChangePassword ID="ChangePassword1" runat="server" CancelButtonStyle-CssClass="inbut_button"
                            ContinueButtonStyle-CssClass="inbut_button" ChangePasswordButtonStyle-CssClass="inbut_button"
                            OnChangedPassword="ChangePassword1_ChangedPassword" OnContinueButtonClick="ChangePassword1_ContinueButtonClick"
                            Width="100%" EnableTheming="false">
                        </asp:ChangePassword>--%>
                        <%-- </div>--%>
                        Old Password:&nbsp;&nbsp;<asp:TextBox ID="txtoldpass" runat="server" TextMode="Password"></asp:TextBox><br />
                        New Password:&nbsp;&nbsp;<asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox><br />
                        Confirm Password:&nbsp;&nbsp;<asp:TextBox ID="txtconpass" runat="server" TextMode="Password"></asp:TextBox><br />
                        <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                        <asp:Button ID="btnSave" runat="server" Text="Change" onclick="btnSave_Click" />
                        <asp:Button ID="btnDone" runat="server" Text="Done" onclick="btnDone_Click" />
                    </div>
                </td>
            </tr>
        </table>
    
</asp:Content>
