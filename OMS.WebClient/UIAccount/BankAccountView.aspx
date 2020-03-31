<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="BankAccountView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.BankAccountView" Title="Bank Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td colspan="2" style="font-size: large" align="center">
                        --:-- Bank Account Information --:--
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                    </td>
                </tr>       
                <tr>
                    <td width="40%">
                        Bank
                    </td>
                    <td width="60%">
                        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ValidationGroup="r1"
                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBank">
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td width="40%">
                        Bank Branch
                    </td>
                    <td width="60%">
                        <asp:DropDownList ID="ddlBranch" runat="server">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBranch">
                        </asp:CompareValidator>
                    </td>
                </tr>
                         <tr>
                    <td width="40%">
                        Name
                    </td>
                    <td width="60%">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                            ControlToValidate="txtName">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="40%">
                        Account No
                    </td>
                    <td width="60%">
                        <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ValidationGroup="r1" ControlToValidate="txtAccountNo">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="40%">
                        Account Type
                    </td>
                    <td width="60%">
                        <asp:DropDownList ID="ddlAccountType" runat="server">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ValidationGroup="r1"
                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlAccountType">
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td width="40%">
                    </td>
                    <td width="60%">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="r1" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBank" />
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:ListView ID="lvBankAccount" runat="server" DataKeyNames="IID" OnItemCommand="lvBankAccount_ItemCommand"
                    OnItemDataBound="lvBankAccount_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th align="left">
                                    Bank
                                </th>
                                <th align="left">
                                    Branch
                                </th>
                                <th align="left">
                                    Account Name
                                </th>
                                <th align="left">
                                    Account No
                                </th>
                                <th align="left">
                                    Account Type
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr id="trBody" runat="server" class="dGridRowClass">
                            <td align="left">
                                <asp:Label ID="lblBank" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBranch" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAccountNo" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAccountType" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server" class="dGridAltRowClass">
                            <td align="left">
                                <asp:Label ID="lblBank" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBranch" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAccountNo" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAccountType" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:DataPager ID="dpList" runat="server" PagedControlID="lvBankAccount" PageSize="5"
                    OnPreRender="dpList_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                            ShowNextPageButton="False" ShowFirstPageButton="False" />
                        <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                            NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                            ButtonType="Link" />
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                            NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                            ShowLastPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</asp:Content>
