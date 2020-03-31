<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="CustomerView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.CustomerView" Title="Customer Infrormation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td colspan="4" style="font-size: large" align="center">
                --:-- Customer Information --:--
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-size: large" align="center">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="true" EnableTheming="false" ForeColor="Green"
                    Text=""></asp:Label>
            </td>
                   </tr>
        <tr>
            <td class="LabelTD" align="left">
                Name :
            </td>
            <td>
                <asp:TextBox ID="txtSname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ValidationGroup="r1" ControlToValidate="txtSname"
                    ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">
                Code :
            </td>
            <td>
                <asp:TextBox ID="txtSCode" runat="server" Enabled="false"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="r1" runat="server"
                    ControlToValidate="txtSCode" ErrorMessage="*">
                </asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left" rowspan="2">
                Address :
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txtSAddress" runat="server" TextMode="MultiLine" Height="40"></asp:TextBox>
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
            <td valign="top" class="LabelTD">
                Date of Birth :
            </td>
            <td>
                <asp:TextBox ID="txtDateofBirth" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateofBirth_CalendarExtender" runat="server" TargetControlID="txtDateofBirth"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label21" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Valid Date"
                    ControlToValidate="txtDateofBirth" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="r1"></asp:RequiredFieldValidator>--%>
                <asp:RegularExpressionValidator ID="rfv" runat="server" ControlToValidate="txtDateofBirth"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="r1" ErrorMessage="Please Enter Valid Date">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Passport No. :
            </td>
            <td>
                <asp:TextBox ID="txtPassportNo" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD">
                National ID :
            </td>
            <td>
                <asp:TextBox ID="txtNationalID" runat="server"></asp:TextBox>
            </td>
        </tr>
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
                <asp:Button ID="btnSaveCustomer" runat="server" ValidationGroup="r1" OnClick="btnSaveCustomer_Click"
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
                                <th align="center" width="5%">
                                    Sl No.
                                </th>
                                <th align="left">
                                    Name
                                </th>
                                <th align="left">
                                    Code
                                </th>
                                <th align="left">
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
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
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
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
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
