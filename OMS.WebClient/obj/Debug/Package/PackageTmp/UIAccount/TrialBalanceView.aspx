<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="TrialBalanceView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.TrialBalanceView" Title="Trial Balance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btnTrialBalance" runat="server" Text="Trial Balance" OnClick="btnTrialBalance_Click"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlPrint" runat="server" valign="top">
                    <table width="100%">
                        <tr>
                            <td style="font-size: large" align="center">
                                <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PrimeTech_Logo.jpg" 
                                        Height="70px" Width="301px" />--%>
                                        <asp:Image ID="imgLogo" runat="server"/>
                                  <br />
                                    <asp:Label ID="lblCompany" runat="server" Text="" style="font-size:15px; font-weight:bold;"></asp:Label>
                                <br />
                                    <asp:Label ID="Label2" runat="server" Text="Trial Balance" style="font-size:14px; font-weight:bold;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align ="Center">
                                <asp:Label ID="lblDate" runat="server" Text="" style="font-size:14px; font-weight:bold;"></asp:Label>
                                <br />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListView ID="lvTrialBalance" runat="server" DataKeyNames="IID" OnItemDataBound="lvTrialBalance_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                                <th align="left">
                                                    Account Name
                                                </th>
                                                <th align="right">
                                                    Debit Amount
                                                </th>
                                                <th align="right">
                                                    Credit Amount
                                                </th>
                                                <%--<th align="left">
                                    Balance
                                </th>--%>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="trBody" runat="server" class="dGridRowClass">
                                            <td align="left">
                                                <asp:Label ID="lblAccount" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblDebit" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblCredit" runat="server"></asp:Label>
                                            </td>
                                            <%--<td align="left">
                                <asp:Label ID="lblBalance" runat="server"></asp:Label>
                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
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
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
