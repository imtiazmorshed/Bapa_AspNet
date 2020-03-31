<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="SupplierView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.SupplierView" Title="Supplier Infrormation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td colspan="4" valign="middle" align="center" style="height: 30px;">
                <h3>
                    <span style="color: Maroon;"><b>Supplier Information</b></span></h3>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblMsg" runat="server" EnableTheming="false" ForeColor="Green" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Name :
            </td>
            <td>
                <asp:TextBox ID="txtSname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="r1" runat="server"
                    ControlToValidate="txtSname" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">
                Code :
            </td>
            <td>
                <asp:TextBox ID="txtSCode" runat="server" Enabled="false"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="r1" runat="server" ControlToValidate="txtSCode" ErrorMessage="*">
                </asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left" rowspan="2">
                Address :
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txtSAddress" runat="server" Font-Bold="true" TextMode="MultiLine"
                    Height="40"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Phone :
            </td>
            <td>
                <asp:TextBox ID="txtSPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Mobile :
            </td>
            <td>
                <asp:TextBox ID="txtSMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Fax :
            </td>
            <td>
                <asp:TextBox ID="txtSFax" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Email :
            </td>
            <td>
                <asp:TextBox ID="txtSEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Web :
            </td>
            <td>
                <asp:TextBox ID="txtSWeb" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Contact Person :
            </td>
            <td>
                <asp:TextBox ID="txtSContact" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left" rowspan="2">
                Contact Address :
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txtSCAddress" runat="server" TextMode="MultiLine" Height="40"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Contact Phone :
            </td>
            <td>
                <asp:TextBox ID="txtSCPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Contact Mobile :
            </td>
            <td>
                <asp:TextBox ID="txtSCMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Contact Email :
            </td>
            <td>
                <asp:TextBox ID="txtSCEmail" runat="server"></asp:TextBox>
            </td>
            <%--<td class="LabelTD">
                Airlines Type
            </td>
            <td>
                <asp:DropDownList ID="ddlAirlinesType" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlAirlinesType_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAirlinesType"
                    Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ValueToCompare="-1" ValidationGroup="r1"></asp:CompareValidator>
            </td>--%>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ListView ID="lvTicketClass" runat="server" DataKeyNames="IID" OnItemCommand="lvTicketClass_ItemCommand"
                    OnItemDataBound="lvTicketClass_ItemDataBound">
                    <LayoutTemplate>
                        <table border="0" cellpadding="0" cellspacing="1" width="100%" style="border-style: none">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th id="th1" runat="server" align="center">
                                    Ticket Class
                                </th>
                                <th id="th4" runat="server" align="center">
                                    Normal Commission
                                </th>
                                <th id="th5" runat="server" align="center">
                                    In Percentage / In Amount
                                </th>
                                <th id="th6" runat="server" align="center">
                                    Amount
                                </th>
                                <th id="th7" runat="server" align="center">
                                    Excess Commission
                                </th>
                                <th id="th2" runat="server" align="center">
                                    In Percentage / In Amount
                                </th>
                                <th id="th3" runat="server" align="center">
                                    Amount
                                </th>
                            </tr>
                            <tbody id="itemPlaceholder" runat="server">
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="dGridRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblTicketClass" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNormalCommission" runat="server" Text = "Normal Commission"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlAmountType1" runat="server" CssClass ="ddlSmall" EnableTheming ="false">
                                </asp:DropDownList>                                
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtAmount1" runat="server" CssClass ="textSmallArea" EnableTheming ="false"></asp:TextBox>                                
                            </td>
                            <td align="center">
                                <asp:Label ID="lblExcessCommission" runat="server" Text = "Excess Commission"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlAmountType2" runat="server" CssClass ="ddlSmall" EnableTheming ="false">
                                </asp:DropDownList>                                
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtAmount2" runat="server" CssClass ="textSmallArea" EnableTheming ="false"></asp:TextBox>                                
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblTicketClass" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNormalCommission" runat="server" Text = "Normal Commission"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlAmountType1" runat="server" CssClass ="ddlSmall" EnableTheming ="false">
                                </asp:DropDownList>                                
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtAmount1" runat="server" CssClass ="textSmallArea" EnableTheming ="false"></asp:TextBox>                                
                            </td>
                            <td align="center">
                                <asp:Label ID="lblExcessCommission" runat="server" Text = "Excess Commission"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlAmountType2" runat="server" CssClass ="ddlSmall" EnableTheming ="false">
                                </asp:DropDownList>                                
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtAmount2" runat="server" CssClass ="textSmallArea" EnableTheming ="false"></asp:TextBox>                                
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:ListView>
            </td>
        </tr>
        <%--<tr>
            <td class="LabelTD">
                Normal Commission Type:
            </td>
            <td class="LabelTD">
                <asp:RadioButtonList ID="rdoNoramal" runat="server" CausesValidation="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="In Percentage" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="In Amount"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="LabelTD">
                Excess Commission Type:
            </td>
            <td class="LabelTD">
                <asp:RadioButtonList ID="rdoExcess" runat="server" CausesValidation="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="In Percentage" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="In Amount"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Normal Commission :
            </td>
            <td class="LabelTD">
                <asp:TextBox ID="txtNormalCommission" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="r1" runat="server"
                    ControlToValidate="txtNormalCommission" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD">
                Excess Commission :
            </td>
            <td class="LabelTD">
                <asp:TextBox ID="txtExcessCommission" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td class="LabelTD" colspan="4">
                <asp:Label ID="lblSMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSaveSupplier" ValidationGroup="r1" runat="server" OnClick="btnSaveSupplier_Click"
                    Text="Save"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ListView ID="lvSupplier" runat="server" DataKeyNames="IID" OnItemCommand="lvSupplier_ItemCommand"
                    OnItemDataBound="lvSupplier_ItemDataBound" 
                    onpagepropertieschanging="lvSupplier_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th width="5%" align="center">
                                    Sl. No.
                                </th>                                
                                <th align="center">
                                    ID
                                </th>
                                <th align="center">
                                    Name
                                </th>
                                <th align="center">
                                    Address
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
                            <td align="center" width="5%">
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </td>                            
                            <td align="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
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
                            <td align="center" width="5%">
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </td>                            
                            <td align="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
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
                <asp:DataPager ID="dpList" runat="server" PagedControlID="lvSupplier" PageSize="20"
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
