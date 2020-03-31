<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="BankLinkToChartOfAccount.aspx.cs" EnableViewState="true"
    Inherits="OMS.WebClient.UIAccount.BankLinkToChartOfAccount" Title="Bank Link To COA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td colspan="4" style="font-size: large" align="center">
                --:-- Bank Link to Chart of Account --:--
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr/>
            </td>
        </tr>
        <tr>            
            <td colspan ="4" align="left">
                <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <b>Bank Account Info</b>
            </td>
            <td colspan="2" align="center">
                <b>Chart Of Account Bank Info</b>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                Chart of Account(COA)
            </td>
            <td>
                <asp:Label ID="lblCOA" runat="server" Text="There is no Chart of Account named (Bank).<br/> please create Chart of Account First"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Bank Name
            </td>
            <td>
                <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style1">
                Bank Name (COA)
            </td>
            <td class="style1">
                <asp:DropDownList ID="ddlBankCOA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBankCOA_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Branch Name
            </td>
            <td class="style1">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBranch" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBranch">
                        </asp:CompareValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBank" />
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                Branch Name (COA)
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBranchCOA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranchCOA_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBankCOA" />
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Bank Account
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlAccountName" runat="server">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ValidationGroup="r1"
                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlAccountName">
                        </asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAccountName"
                            ErrorMessage="*" ValidationGroup="r1"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBranch"/>
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                    
                </asp:UpdatePanel>
            </td>
            <td>
                Bank Account (COA)
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBankAccountCOA" runat="server">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlBankAccountCOA"
                            ErrorMessage="*" Operator="NotEqual" ValidationGroup="r1" ValueToCompare="-1">
                        </asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlBankAccountCOA"
                            ErrorMessage="*" ValidationGroup="r1"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBranchCOA" />
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style1">
                </td>
            <td class="style1">
                </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSave" runat="server" Text="Link" OnClick="btnSave_Click" 
                    ValidationGroup="r1" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ListView ID="lvMap" runat="server" DataKeyNames="IID" OnItemCommand="lvMap_ItemCommand"
                    OnItemDataBound="lvMap_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr style="border:solid 1px black" class="dGridHeaderClass">
                                
                                <th align="center" colspan="3">
                                    Bank Account
                                </th>
                                <th align="center" colspan="3">
                                    Chart Of Account
                                </th>
                            </tr>
                            <tr style="border:solid 1px black" id="tr1" runat="server" class="dGridHeaderClass">
                                
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
                                    Bank
                                </th>
                                <th align="left">
                                    Branch
                                </th>
                                <th align="left">
                                    Account Name
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
                                <asp:LinkButton ID="lnkAccoutName" runat="server"></asp:LinkButton>
                            </td>
                           <td align="left">
                                <asp:Label ID="lblBankCOA" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBranchCOA" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkAccoutNameCOA" runat="server"></asp:LinkButton>
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
                                <asp:LinkButton ID="lnkAccoutName" runat="server"></asp:LinkButton>
                            </td>
                           <td align="left">
                                <asp:Label ID="lblBankCOA" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBranchCOA" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkAccoutNameCOA" runat="server"></asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
</asp:Content>
