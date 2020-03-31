﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="InvoiceList.aspx.cs" Inherits="OMS.Incentive.Admin.InvoiceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group" style="margin-top: 30px">
            <div class="col-sm-6">
                <asp:HyperLink runat="server" ID="lnkAddNewInvoice" NavigateUrl="Invoice.aspx">Create New Invoice</asp:HyperLink>
            </div>
        </div>
    <asp:Panel runat="server" ID="Panel1" GroupingText="Search">
        
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlInvoiceList">
        <asp:ListView ID="lvInvoiceList" runat="server" OnItemDataBound="lvInvoiceList_ItemDataBound" >
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <%--<th class="text-center">Invoice</th>--%>
                        <th class="text-center">Member Name</th>
                        <th class="text-center">Invoice No</th>
                        <th class="text-center">Invoice Amount</th>
                        <th class="text-center">Invoice Date</th>
                        <th></th>
                        
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>

            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-md-4">
                        <asp:Label ID="lblMemberName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblInvoiceAmount" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblInvoiceDate" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkBtnEdit" runat="server">Edit</asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-md-4">
                        <asp:Label ID="lblMemberName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblInvoiceAmount" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblInvoiceDate" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkBtnEdit" runat="server">Edit</asp:HyperLink>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </asp:Panel>
</asp:Content>
