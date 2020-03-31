<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ChequeBookView.aspx.cs"
    Inherits="OMS.WebClient.UIAccount.ChequeBookView" Title="Cheque Book" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function HasLeaf() {
            var txtNumberofLeaf = document.getElementById('ctl00_ContentPlaceHolder1_txtNumberofLeaf');
            if (txtNumberofLeaf.value == '') {
                alert('Please enter number of leaf');
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="font-size: large" align="center" colspan="2">
                --:-- Cheque Book and Cheque Leaf Information --:--
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
                <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" >
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ValidationGroup="r1"
                    ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBank">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td width="40%">
                                    Branch
                                </td>
                                <td width="60%">
                                    <asp:DropDownList ID="ddlBranch" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                        AutoPostBack="true" >
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                        ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBranch">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBank" />
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td width="40%">
                                    Account Name
                                </td>
                                <td width="60%">
                                    <asp:DropDownList ID="ddlAccountName" runat="server">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                        ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlAccountName">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBranch" />
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%--<tr>
            <td width="40%">
                Cheque Book Number
            </td>
            <td width="60%">
                <asp:TextBox ID="txtChequeBookNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ValidationGroup="r1" ControlToValidate="txtChequeBookNumber">
                </asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td width="40%">
                No Of leaf
            </td>
            <td width="60%">
                <asp:TextBox ID="txtNumberofLeaf" runat="server" ></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNumberofLeaf"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ValidationGroup="r1" ControlToValidate="txtNumberofLeaf">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td width="40%" valign="top">
                                    Start Leaf Number
                                </td>
                                <td width="60%" >
                                    <asp:TextBox ID="txtStartLeafNumber" runat="server" onkeypress="HasLeaf()" OnTextChanged="txtStartLeafNumber_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblEndLeafNumber" runat="server" Text=""></asp:Label>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtStartLeafNumber"
                                        FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                        ValidationGroup="r1" ControlToValidate="txtStartLeafNumber">
                                    </asp:RequiredFieldValidator>
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
                        <asp:AsyncPostBackTrigger EventName="TextChanged" ControlID="txtStartLeafNumber" />
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:ListView ID="lvCheckBook" runat="server" DataKeyNames="IID" OnItemCommand="lvCheckBook_ItemCommand"
                    OnItemDataBound="lvCheckBook_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th align="left">
                                    Account Name
                                </th>
                                <th align="left">
                                    Cheque Book Number
                                </th>
                                <th align="left">
                                    Number of Leaf
                                </th>
                                <th align="left">
                                    Start Leaf Number
                                </th>
                                <th align="left">
                                    End Leaf Number
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
                                <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNumberofLeaf" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkChequeBookNumber" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStartLeafNumber" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEndLeafNumber" runat="server"></asp:Label>
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
                                <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNumberofLeaf" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkChequeBookNumber" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStartLeafNumber" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEndLeafNumber" runat="server"></asp:Label>
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
                
            </td>
           
        
        </tr>
        <tr>    
            <td colspan ="2" align ="center">
                <asp:DataPager ID="dpList" runat="server" PagedControlID="lvCheckBook" PageSize="5"
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
