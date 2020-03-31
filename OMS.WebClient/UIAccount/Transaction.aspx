<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="OMS.WebClient.UIAccount.acc_Transaction" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td align="right" width="20%"><b><span>Transaction Type :</span></b></td>
                <td width="30%">
                    <asp:DropDownList ID="ddlTransactionType" runat="server" Width="200px" >
                    </asp:DropDownList>
                     <asp:CompareValidator ID="CompareValidator3" Display="None" 
                        ControlToValidate="ddlTransactionType" runat="server" 
                        ErrorMessage="Required Filed Missing" 
                        ValueToCompare="-1"  Operator="NotEqual"/>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="CompareValidator3"/>
                </td>
                <td  align="right" width="20%"><b><span>Transaction Mode: </span></b></td>
                <td width="30%">
                     <asp:DropDownList ID="ddlTransactionMode" runat="server" Width="200px">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" Display="None" 
                        ControlToValidate="ddlTransactionMode" runat="server" 
                        ErrorMessage="Required Filed Missing" 
                        ValueToCompare="-1"  Operator="NotEqual"/>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator1"/>
                </td>
            </tr>
            <tr>
                <td width="40%" align="right"><b><span>Transaction Date: </span></b></td>
                <td>
                   <asp:TextBox ID="txtTransactionDate" runat="server" Width="200px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="txtTransactionDate_TextBoxWatermarkExtender" TargetControlID="txtTransactionDate"
                        runat="server" WatermarkText="Select Date" WatermarkCssClass="WaterMarkClass" />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTransactionDate" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTransactionDate"
                        runat="server" ValidationExpression="^[0-2]?[1-9](/|-)[0-3]?[0-9](/|-)[1-2][0-9][0-9][0-9]$"
                        ErrorMessage="Input a valid Date" />
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtTransactionDate"
                        Display="None" ErrorMessage="Required Filed Missing" />
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator2" />
                </td>
                <td  align="right" rowspan="2" valign="top"><b><span>Particulars : </span></b></td>
                <td  rowspan="2" valign="top">
                    <asp:TextBox ID="txtParticulars" runat="server" Width="250px" TextMode="MultiLine" Height="60px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="txtParticulars_TextBoxWatermarkExtender" TargetControlID="txtParticulars"
                        runat="server" WatermarkText="Particulars" WatermarkCssClass="WaterMarkClass" />
                </td>
            </tr>
            <tr>
                <td width="40%" align="right"><b><span>Status : </span></b></td>
                <td>
                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Non-Posted</asp:ListItem>
                        <asp:ListItem Value="2">Posted</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td width="40%" align="right"><b><span>To-From : </span></b></td>
                <td>
                    <asp:TextBox ID="txtToFrom" runat="server" Width="200px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="txtToFrom_TextBoxWatermarkExtender" TargetControlID="txtToFrom"
                        runat="server" WatermarkText="To-From" WatermarkCssClass="WaterMarkClass" />
                </td>
                <td  align="right"><b><span>Pay Reason : </span></b></td>
                <td>
                    <asp:TextBox ID="txtPayReason" runat="server" Width="200px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="txtPayReason_TextBoxWatermarkExtender" TargetControlID="txtPayReason"
                        runat="server" WatermarkText="Pay Reason" WatermarkCssClass="WaterMarkClass" />
                </td>
            </tr>
            <tr>
                <td width="40%" align="right" valign="top" rowspan="2"><b><span>To-From Address : </span></b></td>
                <td  valign="top" rowspan="2">
                    <asp:TextBox ID="txtAddress" runat="server" Width="300px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="txtAddress_TextBoxWatermarkExtender" TargetControlID="txtParticulars"
                        runat="server" WatermarkText="Address" WatermarkCssClass="WaterMarkClass" />
                </td>
                <td  align="right"><b><span>To-From Name : </span></b></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtPayReason"
                        runat="server" WatermarkText="Pay Reason" WatermarkCssClass="WaterMarkClass" />
                </td>
            </tr>
            <tr>
                <td width="40%" align="right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td>
                    <asp:ListView ID="lvTransaction" runat="server" DataKeyNames="IID" OnItemCommand="lvTransaction_ItemCommand"
                    OnItemDataBound="lvTransaction_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th align="left">
                                    Name
                                </th>
                                <th align="left">
                                    Code
                                </th>
                                <th align="left">
                                    Measurement Unit
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
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblMeasurementUnit" runat="server"></asp:Label>
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
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblMeasurementUnit" runat="server"></asp:Label>
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
                <asp:DataPager ID="dpTransaction" runat="server" PagedControlID="lvTransaction" PageSize="5" OnPreRender="dpTransaction_PreRender">
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
    </div>
</asp:Content>
