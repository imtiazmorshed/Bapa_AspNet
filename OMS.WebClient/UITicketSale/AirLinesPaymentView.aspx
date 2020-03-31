<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="AirLinesPaymentView.aspx.cs"
    Inherits="OMS.WebClient.UITicketSale.AirLinesPaymentView" Title="" %>

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
            <td colspan="4" valign="middle" align="center" style="background-color: #B8DBFF;
                height: 30px">
                <h3>
                    <b>Airlines Payment View</b>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-size: large" align="center">
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" width ="20%">
                <asp:Label ID="Label" runat="server" Text="Airlines Name :"></asp:Label>
            </td>
            <td align="left" width ="30%">
                <asp:DropDownList ID="ddlAirlines" runat="server">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlAirlines"
                    Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ValueToCompare="-1"
                    ValidationGroup="Gen"></asp:CompareValidator>
            </td>
            <td align="left" width ="20%">
            
            </td>
            <td align="left" width ="30%">
            
            </td>
            
        </tr>
        <%--<tr>
            <td align="left">
                <asp:Label ID="Label3" runat="server" Text="From Date :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtStartDate" runat="server" Height="20px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td align="left">
                <asp:Label ID="Label4" runat="server" Text="To Date :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" TargetControlID="txtEndDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
        </tr>--%>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" ValidationGroup="Gen"/>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <%--<tr>
            <td align="left" colspan="4">
                <asp:ListView ID="lvTicketSale" runat="server" DataKeyNames="IID" OnItemDataBound="lvTicketSale_ItemDataBound"
                    OnItemCommand="lvTicketSale_ItemCommand">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th align="center">
                                    Date
                                </th>
                                <th align="center">
                                    Transaction No
                                </th>
                                <th align="center">
                                    Airlines Name
                                </th>
                                <th align="center">
                                    Customer Name
                                </th>
                                <th align="center">
                                    Ticket Price(In Taka)
                                </th>
                                <th align="center">
                                    Airlines Payable
                                </th>
                                <th align="center">
                                    Airlines Due
                                </th>
                                <th align="center">
                                    Payment Date
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="dGridRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesDue" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkbtnTransactionNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTicketPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesPayable" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAirlinesDue" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
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
            <td align="left" colspan="4">
                <asp:Label ID="lblMSGPaymentStatus" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td align="left">
                <asp:Label ID="Label8" runat="server" Text="Payment Date :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtPaymentDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender_txtPaymentDate" runat="server" TargetControlID="txtPaymentDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label20" runat="server" Text="dd/mm/yyyy"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtPaymentDate" ValidationExpression="(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="pay"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPaymentDate"
                    SetFocusOnError="true" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                    ValidationGroup="pay" ErrorMessage="*">
                </asp:RegularExpressionValidator>
            </td>
            <td align="left">
                <asp:Label ID="Label2" runat="server" Text="Total Sale Amount:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtTotalSale" runat="server" Enabled="False"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label5" runat="server" Text="Total Paid Amount :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtTotalPaidAmount" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Label ID="Label10" runat="server" Text="Total Due Amount :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtTotalDueAmount" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label6" runat="server" Text="Pay Amount :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtPayAmount" runat="server" OnTextChanged="txtPayAmount_TextChanged"
                    AutoPostBack="True"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Label ID="Label7" runat="server" Text="Due Amount :"></asp:Label>
            </td>
            <td align="left">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDue" runat="server" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtPayAmount" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label9" runat="server" Text="Next Payment Date:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNextPaymentDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender_txtNextPaymentDate" runat="server" TargetControlID="txtNextPaymentDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:Label ID="Label1" runat="server" Text="dd/mm/yyyy"></asp:Label>
            </td>
            <td align="left" valign="top">
                <asp:Label ID="Label11" runat="server" Text="Payment Mode :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddlPaymentMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Payment Mode</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlPaymentMode"
                    Display="Dynamic" ErrorMessage="*" Operator="NotEqual" ValueToCompare="-1"
                    ValidationGroup="pay"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div runat="server" id="dvChequePayment">
                            <table width="100%">
                                <tr>
                                    <td align="left" width ="40%">
                                        <asp:Label ID="Label12" runat="server" Text="Bank Name :"></asp:Label>
                                    </td>
                                    <td align="left" width ="60%">
                                        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBank">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label13" runat="server" Text="Branch Name :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlBranch" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBranch">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label14" runat="server" Text="Bank Account :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlAccountName" runat="server" OnSelectedIndexChanged="ddlAccountName_SelectedIndexChanged"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlAccountName">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label15" runat="server" Text="Cheque Leaf :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlChequeLeaf" runat="server">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                            ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlChequeLeaf">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlPaymentMode" />
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBank" />
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBranch" />
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlAccountName" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <div id="dvChequeDate" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="left" width ="40%">
                                        <asp:Label ID="Label27" runat="server" Text="Cheque Date :"></asp:Label>
                                    </td>
                                    <td align="left" width ="60%">
                                        <asp:TextBox ID="txtChequeDate" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server" TargetControlID="txtChequeDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlPaymentMode" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                <asp:Button ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click" ValidationGroup="pay"/>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:ListView ID="lvPayment" runat="server" DataKeyNames="IID" OnItemDataBound="lvPayment_ItemDataBound"
                    OnItemCommand="lvPayment_ItemCommand">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr class="dGridHeaderClass" id="tr1" runat="server">
                                <th align="center">
                                    Date
                                </th>
                                <th align="center">
                                    Payment No
                                </th>                                
                                <th align="center">
                                    Airlines Name
                                </th>
                                <th align="center">
                                    Paid Amount
                                </th>
                                <th align="center">
                                    Due Amount
                                </th>
                                <th align="center">
                                    Next Payment Date
                                </th>
                                <%--<th align="center">
                                   
                                </th>--%>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="dGridRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkbtnPaymentNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblPaidAmount" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDueAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextPaymentDate" runat="server"></asp:Label>
                            </td>
                            <%--<td align="center">
                                <asp:LinkButton ID="lnkbtnEdit" runat="server"></asp:LinkButton>
                            </td>--%>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="dGridAltRowClass" id="trBody" runat="server">
                            <td align="center">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkbtnPaymentNo" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAirlinesName" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblPaidAmount" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDueAmount" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNextPaymentDate" runat="server"></asp:Label>
                            </td>
                            <%--<td align="center">
                                <asp:LinkButton ID="lnkbtnEdit" runat="server"></asp:LinkButton>
                            </td>--%>
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
