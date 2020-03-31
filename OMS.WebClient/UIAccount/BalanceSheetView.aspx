<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="BalanceSheetView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.BalanceSheetView" Title="Balance Sheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlPrint" runat="server" valign="top">
                    <table width="100%">
                        <tr>
                            <td style="font-size: large; text-align: center;">
                                <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PrimeTech_Logo.jpg" 
                                        Height="70px" Width="70px" />--%>
                                        <asp:Image ID="imgLogo" runat="server"/>
                                    <br />
                                    
                                    <asp:Label ID="lblCompany" runat="server" Text="" style="font-size:15px; font-weight:bold;"></asp:Label>
                                    <br />
                                Balance Sheet
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: large" align="center">
                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                            <td bgcolor="#666666">
                                <asp:Label ID="lblParticulars" runat="server" ForeColor="#F2F2F2" Font-Size="12" Text ="Particulars"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:ListView ID="lvBalanceSheet" runat="server" DataKeyNames="IID" OnItemDataBound="lvBalanceSheet_ItemDataBound">
                                    <LayoutTemplate>
                                        <table width="100%">
                                            <%--<tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th id="th1" runat="server" align="center">
                                    <asp:Label ID="lblClassH" runat="server"></asp:Label>
                                </th>
                            </tr>--%>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td bgcolor="#666666">
                                                <asp:Label ID="lblClass" runat="server" ForeColor="#F2F2F2" Font-Size="12"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trBody" runat="server" class="dGridRowClass">
                                            <td>
                                                <asp:ListView ID="lvAccountsDetails" runat="server" DataKeyNames="IID" OnItemDataBound="lvAccountsDetails_ItemDataBound">
                                                    <LayoutTemplate>
                                                        <table width="100%">
                                                            <%--<tr id="tr1" runat="server" class="dGridHeaderClass">
                                                <th align="left">
                                                    Account
                                                </th>
                                                <th align="left">
                                                    Amount
                                                </th>
                                            </tr>--%>
                                                            <tr id="itemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr id="tr1" runat="server" class="dGridAltRowClass">
                                                            <td align="left" width="80%">
                                                                <asp:Label ID="lblAccount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="Silver">
                                                                <asp:ListView ID="lvGroupAccounts" runat="server" DataKeyNames="IID" OnItemDataBound="lvGroupAccounts_ItemDataBound">
                                                                    <LayoutTemplate>
                                                                        <table width="100%">
                                                                            <tr id="itemPlaceholder" runat="server">
                                                                            </tr>
                                                                        </table>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <tr id="trBody" runat="server" class="dGridRowClass">
                                                                            <td align="left" width="80%" style="padding-left: 50px;">
                                                                                <asp:Label ID="lblGroupAccount" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right" width="20%">
                                                                                <asp:Label ID="lblGroupAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <EmptyDataTemplate>
                                                                        no item to display!!!
                                                                    </EmptyDataTemplate>
                                                                </asp:ListView>
                                                            </td>
                                                        </tr>
                                                        <tr id="trBody" runat="server" class="dGridAltRowClass">
                                                            <td align="left" width="80%">
                                                                <asp:Label ID="lblAccount1" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right" width="20%">
                                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        no item to display!!!
                                                    </EmptyDataTemplate>
                                                </asp:ListView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" bgcolor="#666666">
                                                <asp:Label ID="lblBalanceHead" runat="server" ForeColor="#F2F2F2" Font-Size="12"></asp:Label>
                                            </td>
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
    </table>
</asp:Content>
