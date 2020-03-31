<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true"
    CodeBehind="BalanceSheetNew.aspx.cs" Inherits="OMS.WebClient.UIAccount.BalanceSheetNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="font-size: large" align="center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ALLogo.jpg" 
                                        Height="70px" Width="301px" />
                                    <br />
                Balance Sheet
            </td>
        </tr>
        <tr>
            <td>
                <%--<table>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>--%>
                Assets
            </td>
        </tr>
        <tr>
            <td>             
                Capital
            </td>
        </tr>
        <tr>
            <td>             
                Liability
            </td>
        </tr>        
    </table>
</asp:Content>
