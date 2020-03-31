<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ChartOfAccountView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.ChartOfAccountView" Title="Chart Of Account" %>

<%@ Register Src="../Controls/accountTree.ascx" TagName="accountTree" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" style="border-style: inherit; border-width: thin; border-color: #008080">
        <tr>
            <td style="font-size: large" align="center">
                --:-- Chart of Account --:--
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" GroupingText="Chart of Account Information"
                    Style="font-size: large">
                    <table width="100%">
                        <tr>
                            <td width="25%">
                                <asp:Label ID="Label1" runat="server" Text="Class"></asp:Label>
                            </td>
                            <td width="75%">
                                <asp:DropDownList ID="ddlAccountClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountClass_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAccountClass"
                                    Display="Dynamic" ErrorMessage="Please Select Class" Operator="NotEqual" ValueToCompare="-1"
                                    ValidationGroup="Gen"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Group Head"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNonTransactableAccount" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Account No"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtAccountNo_TextBoxWatermarkExtender" runat="server"
                                    TargetControlID="txtAccountNo" WatermarkText="Enter Account Number" WatermarkCssClass="WaterMarkClass">
                                </cc1:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Account Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAccountName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAccountName"
                                    ErrorMessage="Please Enter Account Name" Display="Dynamic" ValidationGroup="Gen">
                                </asp:RequiredFieldValidator>
                                <%--<cc1:TextBoxWatermarkExtender ID="txtAccountName_TextBoxWatermarkExtender" runat="server"
                                    TargetControlID="txtAccountName" WatermarkText="Enter Account Name" WatermarkCssClass="WaterMarkClass">
                                </cc1:TextBoxWatermarkExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RadioButton ID="rbTransactable" runat="server" Text="Ledger Head" GroupName="Transaction"
                                    AutoPostBack="True" OnCheckedChanged="rbTransactable_CheckedChanged" />
                                <asp:RadioButton ID="rbNonTransactable" runat="server" Text="Group Head" GroupName="Transaction"
                                    AutoPostBack="True" OnCheckedChanged="rbNonTransactable_CheckedChanged" />
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" 
                                    Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr id="trOB" runat="server">
                                                <td width="25%" align="left" valign="top">
                                                    <asp:Label ID="Label94" runat="server" Text="Opening Balance"></asp:Label>
                                                </td>
                                                <td width="75%" align="left" valign="top">
                                                    <asp:TextBox ID="txtOpeningBalance" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rbTransactable" EventName="CheckedChanged">
                                        </asp:AsyncPostBackTrigger>
                                        <asp:AsyncPostBackTrigger ControlID="rbNonTransactable" EventName="CheckedChanged">
                                        </asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#339933" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="Gen" />
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Chart of Account List" Style="font-size: large">
                    <%--<uc1:accountTree ID="accountTree1" runat="server" />--%>
                    <asp:TreeView ID="tvShartofAccount" runat="server" ImageSet="Msdn" NodeIndent="10"
                        OnSelectedNodeChanged="tvShartofAccount_SelectedNodeChanged">
                        <ParentNodeStyle Font-Bold="false" />
                        <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" Font-Underline="True" />
                        <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" BorderWidth="1px"
                            Font-Underline="False" HorizontalPadding="3px" VerticalPadding="1px" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="1px" VerticalPadding="2px" />
                    </asp:TreeView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
