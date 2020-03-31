<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="TicketSaleView.aspx.cs"
    Inherits="OMS.WebClient.UITicketSale.TicketSaleView" Title="Ticket Sale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function ShowProgress() {
            document.getElementById('<% Response.Write(UpdateProgress1.ClientID); %>').style.display = "inline";
        }    

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdateProgress DynamicLayout="false" ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <p class="Progress">
                Loading...
                <img runat="server" id="imgLoder" src="~/images/ajax-loader.gif" />
            </p>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <table width="100%">
        <tr>
            <td style="color: #800000; font-weight: bold; font-size: 16px; font-family: Verdana;"
                align="center" colspan="4">
                --:-- Ticket Sale Information --:--
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4" align="left">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                <asp:Label ID="Label4" runat="server" Text="Sale Date:"></asp:Label>
            </td>
            <td align="left" width="30%">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label21" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Valid Date"
                    ControlToValidate="txtDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Gen"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rfv" runat="server" ControlToValidate="txtDate"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="Gen" ErrorMessage="Please Enter Valid Date">
                </asp:RegularExpressionValidator>
            </td>
            <td align="left" width="20%">
                <asp:Label ID="Label14" runat="server" Text="Sales Person:"></asp:Label>
            </td>
            <td align="left" width="30%">
                <asp:DropDownList ID="ddlSalesPerson" runat="server">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlSalesPerson"
                    Display="Dynamic" ErrorMessage="Please Select Sales Person" Operator="NotEqual"
                    ValueToCompare="-1" ValidationGroup="Gen"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name of Customer:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCustomer" runat="server">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlCustomer"
                    Display="Dynamic" ErrorMessage="Please Select Customer" Operator="NotEqual" ValueToCompare="-1"
                    ValidationGroup="Gen"></asp:CompareValidator>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Refernce Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRefernce" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Destination Country:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Ticket Class:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTicketClass" runat="server">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlTicketClass"
                    Display="Dynamic" ErrorMessage="Please Select" Operator="NotEqual" ValueToCompare="-1"
                    ValidationGroup="Gen"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Name of Airline:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAirlines" runat="server" OnSelectedIndexChanged="ddlAirlines_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlAirlines"
                    Display="Dynamic" ErrorMessage="Please Select Airlines" Operator="NotEqual" ValueToCompare="-1"
                    ValidationGroup="Gen"></asp:CompareValidator>
            </td>
            <td>
                <asp:Label ID="Label30" runat="server" Text="Sector:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSector" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSector"
                    ErrorMessage="Please Enter Sector" Display="Dynamic" ValidationGroup="Gen">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label22" runat="server" Text="Departure From:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDepartureFrom" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Departure Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDepartureDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDepartureDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label20" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Valid Date"
                    ControlToValidate="txtDepartureDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Gen"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDepartureDate"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="Gen" ErrorMessage="Please Enter Valid Date">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label26" runat="server" Text="Issue Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIssueDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtIssueDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label27" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Valid Date"
                    ControlToValidate="txtIssueDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Gen"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtIssueDate"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="Gen" ErrorMessage="Please Enter Valid Date">
                </asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="Label28" runat="server" Text="Return Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReturnDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtReturnDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label29" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Valid Date"
                    ControlToValidate="txtReturnDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Gen"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtReturnDate"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="Gen" ErrorMessage="Please Enter Valid Date">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" Text="Destination:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDestination" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Airlines Invoice No:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBillNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="USD Rate:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUSDRate" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regularExpressionValidator6" runat="server" ControlToValidate="txtUSDRate"
                    ValidationExpression="^[1-9][\.\d]*(,\d+)?$" ErrorMessage="Please enter numeric value"
                    Display="Dynamic" ValidationGroup="Gen">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUSDRate"
                    ErrorMessage="Please Enter USD Rate" Display="Dynamic" ValidationGroup="Gen">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%" style="border: 1px solid #E0E0E0; background-color: #B8DBFF;">
                    <tr>
                        <td align="left" colspan="6">
                            <span style="color: #800000; font-weight: bold; font-size: 14px; font-family: Verdana;">
                                Enter Passenger Information</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="25%">
                            <asp:Label ID="Label34" runat="server" Text="Passenger Name:"></asp:Label>
                        </td>
                        <td align="left" width="15%">
                            <asp:Label ID="Label36" runat="server" Text="Ticket Number:"></asp:Label>
                        </td>
                        <td align="left" width="15%">
                            <asp:Label ID="Label37" runat="server" Text="Ticket Fair in USD:"></asp:Label>
                        </td>
                        <td align="left" width="15%">
                            <asp:Label ID="Label35" runat="server" Text="Ticket Fair:"></asp:Label>
                        </td>
                        <td align="left" width="15%">
                            <asp:Label ID="Label38" runat="server" Text="Tax:"></asp:Label>
                        </td>
                        <td align="left" width="15%">
                            <asp:Label ID="Label39" runat="server" Text="Sub Total:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox ID="txtPassengerName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassengerName"
                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Gen_sub">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTicketNo" runat="server" CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtTicketNo" runat="server" ControlToValidate="txtTicketNo"
                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Gen_sub">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTIcketPriceInUSD" runat="server" CssClass="textSmallArea" EnableTheming="false"
                                OnTextChanged="txtTIcketPriceInUSD_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regularExpressionValidator" runat="server" ControlToValidate="txtTIcketPriceInUSD"
                                ValidationExpression="^[1-9][\.\d]*(,\d+)?$" ErrorMessage="Please enter numeric value"
                                Display="Dynamic" ValidationGroup="Gen_sub">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTIcketPriceInUSD"
                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Gen_sub">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtTicketPriceInTaka" runat="server" Enabled="False" CssClass="textSmallArea"
                                        EnableTheming="false"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtTIcketPriceInUSD" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTAXAmount" runat="server" AutoPostBack="True" OnTextChanged="txtTAXAmount_TextChanged"
                                CssClass="textSmallArea" EnableTheming="false"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regularExpressionValidator5" runat="server" ControlToValidate="txtTAXAmount"
                                ValidationExpression="^[1-9][\.\d]*(,\d+)?$" ErrorMessage="Please enter numeric value"
                                Display="Dynamic" ValidationGroup="Gen_sub">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTAXAmount"
                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Gen_sub">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtSubTotal" runat="server" CssClass="textSmallArea" EnableTheming="False"
                                        Enabled="False"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtTIcketPriceInUSD" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txtTAXAmount" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnAddPost" runat="server" Text="Add" OnClick="btnAddPost_Click"
                                ValidationGroup="Gen_sub" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6">
                            <asp:ListView ID="lvTicketSaleDetail" runat="server" DataKeyNames="IID" OnItemDataBound="lvTicketSaleDetail_ItemDataBound"
                                OnItemCommand="lvTicketSaleDetail_ItemCommand">
                                <LayoutTemplate>
                                    <table width="100%" style="border: 1px solid #E0E0E0; background-color: #B8DBFF">
                                        <tr class="dGridHeaderClass" id="tr1" runat="server">
                                            <th align="center">
                                                Sl
                                            </th>
                                            <th align="center">
                                                Passenger Name
                                            </th>
                                            <th align="center">
                                                Ticket No.
                                            </th>
                                            <th align="center">
                                                Ticket Fair In USD
                                            </th>
                                            <th align="center">
                                                Ticket Fair
                                            </th>
                                            <th align="center">
                                                TAX
                                            </th>
                                            <th align="center">
                                                Sub Total
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
                                    <tr class="dGridRowClass" id="trBody" runat="server">
                                        <td align="center">
                                            <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblPassengerName" runat="server"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblTicketNo" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTicketFairInUSD" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTicketFair" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" visible="false">
                                            <asp:Label ID="lblObjID" runat="server"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                                        </td>
                                        <td align="center">
                                            <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="dGridAltRowClass" id="trBody" runat="server">
                                        <td align="center">
                                            <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblPassengerName" runat="server"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblTicketNo" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTicketFairInUSD" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTicketFair" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTAXAmount" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" visible="false">
                                            <asp:Label ID="lblObjID" runat="server"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                                        </td>
                                        <td align="center">
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
                </table>
            </td>
        </tr>
        <%--<td>
                <asp:Label ID="Label15" runat="server" Text="Airlines Payable :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAirlinesPayable" runat="server" Enabled="False" OnTextChanged="txtAirlinesPayable_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtAirlinesCommission" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>--%>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <div id="divNonIATA" runat="server">
                                <tr id="Tr2" runat="server">
                                    <td colspan="4">
                                        <asp:Label ID="Label33" runat="server" Text="Non IATA Airlines Commission Amount:"
                                            Font-Bold="True" ForeColor="#000066"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trNonIATA" runat="server">
                                    <td align="left" width="20%" valign="top">
                                        <asp:Label ID="Label32" runat="server" Text="Commission Amount:"></asp:Label>
                                    </td>
                                    <td align="left" width="30%">
                                        <asp:TextBox ID="txtNonIATACommissionAmount" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </div>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlAirlines" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label31" runat="server" Text="Customer Discount (%/Amount):"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoAmountType" runat="server" CausesValidation="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="In Percentage" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="In Amount"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <%--<td>
                <asp:Label ID="Label12" runat="server" Text="Airlines Paid :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAirlinesPaid" runat="server" AutoPostBack="True" OnTextChanged="txtAirlinesPaid_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAirlinesPaid"
                            ErrorMessage="Please Enter USD Rate" Display="Dynamic" ValidationGroup="Gen">
                        </asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtAirlinesPayable" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>--%>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Customer Discount :"></asp:Label>
                In Percentage(%)
            </td>
            <td>
                <asp:TextBox ID="txtCustomerDiscount" runat="server" AutoPostBack="True" OnTextChanged="txtCustomerDiscount_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Customer Receivable :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomerReceivable" runat="server" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomerDiscount" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <%--<td>
                <asp:Label ID="Label20" runat="server" Text="Ailines Due :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAirlinesDue" runat="server" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtAirlinesPaid" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>--%>
        </tr>
        <tr>
            <%--<th align="center">
                                </th>--%>
            <td>
                <asp:Label ID="Label16" runat="server" Text="Customer Paid :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomerPaid" runat="server" AutoPostBack="True" OnTextChanged="txtCustomerPaid_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCustomerPaid"
                            ErrorMessage="Please Enter Received Amount" Display="Dynamic" ValidationGroup="Gen">
                        </asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomerReceivable" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Customer Due :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomerDue" runat="server" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomerPaid" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <%--<th align="center">
                                </th>--%>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label25" runat="server" Text="Customer Receivable Date :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtCustomerReceivableDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtCustomerReceivableDate_CalendarExtender" runat="server"
                    TargetControlID="txtCustomerReceivableDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td align="left">
                <asp:Label ID="Label18" runat="server" Text="Ailines Payment Date :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtAirlinesPaymentDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtAirlinesPaymentDate_CalendarExtender" runat="server"
                    TargetControlID="txtAirlinesPaymentDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label5" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter Valid Date"
                    ControlToValidate="txtAirlinesPaymentDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Gen"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAirlinesPaymentDate"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="Gen" ErrorMessage="Please Enter Valid Date">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Gen" OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Cancel" OnClick="btnClose_Click" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ListView ID="lvTicketSale" runat="server" DataKeyNames="IID" OnItemDataBound="lvTicketSale_ItemDataBound"
                    OnItemCommand="lvTicketSale_ItemCommand" OnPagePropertiesChanging="lvTicketSale_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table cellpadding="0" cellspacing="1" width="100%" style="border: 1px solid black;
                            border-collapse: collapse;">
                            <tr id="tr1" runat="server">
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Sl No.
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Date
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Transaction No
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Airlines Name
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Customer Name
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Ticket Price(In Taka)
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Airlines Payable
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                    Customer Receivable
                                </th>
                                <th align="center" style="vertical-align: middle; border: 1px solid black;">
                                </th>
                                <%--<th align="center">
                                </th>--%>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr id="trBody" runat="server">
                            <td width="5%" align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblCustomerReceivable" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:LinkButton ID="lnkbtnEdit" runat="server"></asp:LinkButton>
                            </td>
                            <%--<td align="center">
                                <asp:Label ID="lnkbtnDelete" runat="server"></asp:Label>
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server">
                            <td width="5%" align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:Label ID="lblCustomerReceivable" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle; border: 1px solid black;">
                                <asp:LinkButton ID="lnkbtnEdit" runat="server"></asp:LinkButton>
                            </td>
                            <%--<td align="center">
                                <asp:Label ID="lnkbtnDelete" runat="server"></asp:Label>
                            </td>--%>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:DataPager ID="dpTicketSale" runat="server" PagedControlID="lvTicketSale" PageSize="20"
                    OnPreRender="dpTicketSale_PreRender">
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
