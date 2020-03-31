<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTransaction.ascx.cs"
    Inherits="OMS.WebClient.Controls.ucTransaction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
    
        
</script>

<table width="100%">
    <tr>
        <td align="center">
            <asp:Label ID="lblTransactionType" runat="server" Text="Transaction" Font-Bold="True"
                Font-Names="Times New Roman" Font-Size="Large"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
</table>
<fieldset>
    <legend id="legendMain" runat="server">Transaction</legend>
    <div>
        <table width="100%">
            <tr>
                <td width="20%" align="right" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Transaction Date :"></asp:Label>
                </td>
                <td width="30%">
                    <asp:TextBox ID="txtTransactionDate" runat="server"></asp:TextBox>
                    <%--<cc1:TextBoxWatermarkExtender ID="txtTransactionDate_TextBoxWatermarkExtender" TargetControlID="txtTransactionDate"
                        runat="server" WatermarkText="Select Date" WatermarkCssClass="WaterMarkClass" />--%>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTransactionDate" Format="dd/MM/yyyy"/>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTransactionDate"
                        runat="server" ValidationExpression="^[0-2]?[1-9](/|-)[0-3]?[0-9](/|-)[1-2][0-9][0-9][0-9]$"
                        ErrorMessage="Input a valid Date" />
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtTransactionDate"
                        Display="None" ErrorMessage="Required Filed Missing" />
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator2" />--%>
                </td>
                <td align="right" width="20%" valign="top">
                    <asp:Label ID="Label2" runat="server" Text="Reference Type :"></asp:Label>
                </td>
                <td width="30%" valign="top">
                    <asp:DropDownList ID="ddlReferenceType" runat="server" AppendDataBoundItems="true"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlReferenceType_SelectedIndexChanged">
                        <asp:ListItem Value="-1">Select Reference Type</asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:CompareValidator ID="CompareValidator2" Display="None" ControlToValidate="ddlReferenceType"
                        runat="server" ErrorMessage="Required Filed Missing" ValueToCompare="-1" Operator="NotEqual" />
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="CompareValidator2" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div id="dvCustomer" runat="server" visible="false">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right" valign="top" width="20%">
                                                        <asp:Label ID="Label3" runat="server" Text="Customer Name :"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="30%">
                                                        <asp:DropDownList ID="ddlCustomer" runat="server" AppendDataBoundItems="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:LinkButton ID="lnkbtnCustomer" runat="server" OnClientClick="load_facebox()"
                                                            Visible="False">Add Customer</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="dvSupplier" visible="false" runat="server">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right" valign="top" width="20%">
                                                        <asp:Label ID="Label4" runat="server" Text="Supplier Name :"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="30%">
                                                        <asp:DropDownList ID="ddlSupplier" runat="server" AppendDataBoundItems="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" valign="top" width="50%">
                                                        <asp:LinkButton ID="lnkbtnSupplier" runat="server" OnClientClick="load_facebox()"
                                                            Visible="False">Add Airlines</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlReferenceType" EventName="SelectedIndexChanged" />
                            <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    <asp:Label ID="Label5" runat="server" Text="To-From (Company/Individual) :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToFrom" runat="server"></asp:TextBox>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                </td>
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="To-From Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToFromName" runat="server"></asp:TextBox>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right" valign="top">
                    <asp:Label ID="Label7" runat="server" Text="To-From Address :"></asp:Label>
                </td>
                <td valign="top">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" EnableTheming="false"
                        CssClass="in_put_multiline"></asp:TextBox>
                    <%--<cc1:TextBoxWatermarkExtender ID="txtToFrom_TextBoxWatermarkExtender" TargetControlID="txtToFrom"
                        runat="server" WatermarkText="To-From" WatermarkCssClass="WaterMarkClass" />--%>
                </td>
                <td align="right" valign="top">
                    <asp:Label ID="Label8" runat="server" Text="Particulars :"></asp:Label>
                </td>
                <td valign="top">
                    <asp:TextBox ID="txtParticulars" runat="server" TextMode="MultiLine" EnableTheming="false"
                        CssClass="in_put_multiline"></asp:TextBox>
                    <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtToFromName"
                        runat="server" WatermarkText="To-From Name" WatermarkCssClass="WaterMarkClass" />--%>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" width="20%">
                    <asp:Label ID="Label9" runat="server" Text="Pay Reason :"></asp:Label>
                </td>
                <td valign="top">
                    <asp:TextBox ID="txtPayReason" runat="server"></asp:TextBox>
                    <%--<cc1:TextBoxWatermarkExtender ID="txtAddress_TextBoxWatermarkExtender" TargetControlID="txtAddress"
                        runat="server" WatermarkText="Address" WatermarkCssClass="WaterMarkClass" />--%>
                </td>
                <td align="right" valign="top">
                    <asp:Label ID="Label10" runat="server" Text="Transaction Mode :"></asp:Label>
                </td>
                <td valign="top">
                    <asp:DropDownList ID="ddlTransactionMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTransactionMode_SelectedIndexChanged">
                        <asp:ListItem Value="-1">Select Transaction Mode</asp:ListItem>
                    </asp:DropDownList>
                    <%-- <cc1:TextBoxWatermarkExtender ID="txtParticulars_TextBoxWatermarkExtender" TargetControlID="txtParticulars"
                        runat="server" WatermarkText="Particulars" WatermarkCssClass="WaterMarkClass" />--%>
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
                                        <td width="37%" align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Bank Name :"></asp:Label>
                                        </td>
                                        <td width="63%">
                                            <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                                ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBank">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="37%" align="right">
                                            <asp:Label ID="Label12" runat="server" Text="Branch Name :"></asp:Label>
                                        </td>
                                        <td width="63%">                                           
                                            <asp:DropDownList ID="ddlBranch" runat="server" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                                ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlBranch">
                                            </asp:CompareValidator>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="37%" align="right">
                                            <asp:Label ID="Label13" runat="server" Text="Bank Account :"></asp:Label>
                                        </td>
                                        <td width="63%">                                           
                                            <asp:DropDownList ID="ddlAccountName" runat="server" OnSelectedIndexChanged="ddlAccountName_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ValidationGroup="r1"
                                                ValueToCompare="-1" Operator="NotEqual" ControlToValidate="ddlAccountName">
                                            </asp:CompareValidator>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="37%" align="right">
                                            <asp:Label ID="Label14" runat="server" Text="Cheque Leaf :"></asp:Label>
                                        </td>
                                        <td width="63%">
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
                            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlTransactionMode" />
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
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                    <div runat="server" id="dvChequeReceipt">
                        <table width="100%">
                            <tr>
                                <td width="37%" align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Bank Name :"></asp:Label>
                                </td>
                                <td width="63%">
                                    <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="37%" align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Branch Name :"></asp:Label>
                                </td>
                                <td width="63%">
                                    <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="37%" align="right">
                                    <asp:Label ID="Label17" runat="server" Text="Bank Account :"></asp:Label>
                                </td>
                                <td width="63%">
                                    <asp:TextBox ID="txtBankAccount" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="37%" align="right">
                                    <asp:Label ID="Label18" runat="server" Text="Cheque Leaf No. :"></asp:Label>
                                </td>
                                <td width="63%">
                                    <asp:TextBox ID="txtChequeLeafNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlTransactionMode" />
                            
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
                                <td width="37%" align="right">
                                    <asp:Label ID="Label27" runat="server" Text="Cheque Date :"></asp:Label>
                                </td>
                                <td width="63%">
                                    <asp:TextBox ID="txtChequeDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server" TargetControlID="txtChequeDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </div>
                    </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlTransactionMode" />
                            
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</fieldset>
<%--<div id="faceboxCustomer" runat="server" style="background-image: url('../Images/pop720X420.gif');
    background-repeat: no-repeat; display: none; width: 720px; height: 420px; font-size: 9pt;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: right;">
        <tr>
            <td style="padding: 10px 8px 0px 0px; vertical-align: top;" colspan="2">
                <img src="../Images/cross.gif" onclick="close_facebox();" style="cursor: pointer;" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="4" align="center">
                <b>.:: <b>.::</b> <b><span>Customer </span></b><b>::.</b>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Name :
            </td>
            <td>
                <asp:TextBox ID="txtCName" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Code :
            </td>
            <td>
                <asp:TextBox ID="txtCCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left" rowspan="2">
                Address :
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txtCAddress" runat="server" TextMode="MultiLine" Height="40"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Phone :
            </td>
            <td>
                <asp:TextBox ID="txtCPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Mobile :
            </td>
            <td>
                <asp:TextBox ID="txtCMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Fax :
            </td>
            <td>
                <asp:TextBox ID="txtCFax" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Email :
            </td>
            <td>
                <asp:TextBox ID="txtCEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Web :
            </td>
            <td>
                <asp:TextBox ID="txtCWeb" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Contact Person :
            </td>
            <td>
                <asp:TextBox ID="txtCContactPerson" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left" rowspan="2">
                Contact Address :
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txtCContactAddress" runat="server" TextMode="MultiLine" Height="40"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Contact Phone
            </td>
            <td>
                <asp:TextBox ID="txtCContactPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Contact Mobile
            </td>
            <td>
                <asp:TextBox ID="txtCContactMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Contact Email
            </td>
            <td>
                <asp:TextBox ID="txtCContactEmail" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" colspan="4">
                <asp:Label ID="lblCMsg" runat="server" Text=""></asp:Label>
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
                <asp:LinkButton ID="btnSaveCustomer" runat="server" OnClick="btnSaveCustomer_Click"><b><span>Save</span></b></asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
<div id="faceboxSupplier" runat="server" style="background-image: url('../Images/pop720X420.gif');
    background-repeat: no-repeat; display: none; width: 720px; height: 420px; font-size: 9pt;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: right;">
        <tr>
            <td style="padding: 10px 8px 0px 0px; vertical-align: top;" colspan="2">
                <img src="../Images/cross.gif" onclick="close_facebox();" style="cursor: pointer;" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="4" align="center">
                <b>.::</b> <b><span>Supplier </span></b><b>::.</b>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">
                Name :
            </td>
            <td>
                <asp:TextBox ID="txtSname" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">
                Code :
            </td>
            <td>
                <asp:TextBox ID="txtSCode" runat="server"></asp:TextBox>
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
                Contact Phone
            </td>
            <td>
                <asp:TextBox ID="txtSCPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Contact Mobile
            </td>
            <td>
                <asp:TextBox ID="txtSCMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD">
                Contact Email
            </td>
            <td>
                <asp:TextBox ID="txtSCEmail" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD">
            </td>
            <td>
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
                <asp:LinkButton ID="lnkbtnSaveSupplier" runat="server" OnClick="lnkbtnSaveSupplier_Click"><b><span>Save</span></b></asp:LinkButton>
            </td>
        </tr>
    </table>
</div>--%>
<fieldset>
    <legend>Transaction Details </legend>
    <div>
        <table width="100%">
            <tr>
                <td align="center" width="25%">
                    <asp:Label ID="Label19" runat="server" Text="Account"></asp:Label>
                </td>
                <td align="center" width="25%">
                    <asp:Label ID="Label20" runat="server" Text="Particulars"></asp:Label>
                </td>
                <td align="center" width="25%">
                    <asp:Label ID="Label21" runat="server" Text="Debit"></asp:Label>
                </td>
                <td align="center" width="25%">
                    <asp:Label ID="Label22" runat="server" Text="Credit"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:DropDownList ID="ddlAccount" runat="server" EnableTheming ="False" CssClass ="ddl_min">
                    </asp:DropDownList>
                </td>
                <td align="center" valign="top">
                    <asp:TextBox ID="txtParticularsDetails" runat="server" EnableTheming="False" CssClass ="in_put_min"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtDebit" runat="server" EnableTheming="False" CssClass ="in_put_min"></asp:TextBox>
                    <asp:RangeValidator runat="server" ID="RangeValidator1" ControlToValidate="txtDebit"
                        ErrorMessage="</br>Ammount Should (+ve) be Numeric" MaximumValue="999999999"
                        MinimumValue="0" />
                </td>
                <td align="center">
                    <asp:TextBox ID="txtCredit" runat="server" EnableTheming="False" CssClass ="in_put_min"></asp:TextBox>
                    <asp:RangeValidator runat="server" ID="RangeValidator2" ControlToValidate="txtCredit"
                        ErrorMessage="</br>Ammount Should (+ve) be Numeric" MaximumValue="999999999"
                        MinimumValue="0" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right">
                    <asp:Button ID="btnAddDetails" runat="server" Text="Add" OnClick="btnAddDetails_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center" class="LabelTD">
                    <asp:Label ID="lblDetailsErrorMsg" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblDrCrBalanceMsg" runat="server" Text=""></asp:Label>
                </td>
                <%--<td colspan="2" align="center" class="LabelTD">
                    <asp:Label ID="lblDetailsErrorMsg" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="2" align="center" class="LabelTD">
                    <asp:Label ID="lblDrCrBalanceMsg" runat="server" Text=""></asp:Label>
                </td>--%>
            </tr>
        </table>
    </div>
</fieldset>
<div>
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvTransactionDetails" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="AccountID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%"
                    OnRowDataBound="gvTransactionDetails_RowDataBound" OnRowCommand="gvTransactionDetails_RowCommand">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" Text="<img src='../Images/DeleteRed.ico' alt='Delete this' border='0' />"
                                    CausesValidation="false" CommandName="DoDelete" />
                                <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure you want to Delete?"
                                    Enabled="True" TargetControlID="btnDelete">
                                </cc1:ConfirmButtonExtender>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Account" HeaderText="Account" />
                        <asp:BoundField DataField="Particulars" HeaderText="Particulars" />
                        <asp:BoundField DataField="Debit" HeaderText="Debit" />
                        <asp:BoundField DataField="Credit" HeaderText="Credit Unit" />
                    </Columns>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" width="25%">
                <asp:Label ID="Label23" runat="server" Text="Transaction Reference :"></asp:Label>
            </td>
            <td align="left">                
                <asp:FileUpload ID="fuMap" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div>
    <table width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnSearchShow" runat="server" Text="Show Voucher" OnClick="btnSearchShow_Click" />
                <asp:HiddenField runat="server" ID="hdTransactionID" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <b><span>
                    <asp:Label ID="lblMsgAll" runat="server" Text=""></asp:Label></span></b>
            </td>
        </tr>
    </table>
</div>
<div id="dvSearchVoucher" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Search Voucher">
        <table width="100%">
            <tr>
                <td align="right">
                    <asp:Label ID="Label24" runat="server" Text="Transaction Status"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTransactionStatus" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="-1">Select Transaction Status</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label25" runat="server" Text="From Date"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label26" runat="server" Text="To date"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFromDate"
                    ControlToValidate="txtToDate" ErrorMessage="LessThanEqual" Operator="LessThanEqual"></asp:CompareValidator>--%>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
<div id="dvVoucherList" runat="server">
    <asp:Panel ID="Panel2" runat="server" GroupingText="Voucher List">
        <table width="100%">
            <tr>
                <td>
                    <asp:ListView ID="lvTransaction" runat="server" DataKeyNames="IID" OnItemCommand="lvTransaction_ItemCommand"
                        OnItemDataBound="lvTransaction_ItemDataBound">
                        <LayoutTemplate>
                            <table width="100%">
                                <tr id="tr1" runat="server" class="dGridHeaderClass">
                                    <th align="left">
                                        Transaction Date
                                    </th>
                                    <th align="left">
                                        Jurnal Code
                                    </th>
                                    <th align="left">
                                        Pay Reason
                                    </th>
                                    <th>
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
                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblJurnalCode" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPayReason" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkbtnPrint" runat="server">Print</asp:LinkButton>
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
                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblJurnalCode" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPayReason" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkbtnPrint" runat="server">Print</asp:LinkButton>
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
                    <%--<asp:DataPager ID="dpTransaction" runat="server" PagedControlID="lvTransaction" PageSize="5"
                    OnPreRender="dpTransaction_PreRender">
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
                </asp:DataPager>--%>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
