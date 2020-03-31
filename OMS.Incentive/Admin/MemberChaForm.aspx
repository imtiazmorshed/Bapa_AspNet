<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="MemberChaForm.aspx.cs" Inherits="OMS.Incentive.Admin.MemberChaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group" style="margin-top: 30px">
        <label class="col-sm-3 control-label">
            Member
        </label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlMember" runat="server"></asp:DropDownList>

        </div>
    </div>
    <div>
        <div class="text-center">
            <h2>Submitted Cha-Form Listing </h2>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlSubmittedChaFromList">
        <asp:ListView ID="lvSubmittedChaForm" runat="server" OnItemDataBound="lvSubmittedChaForm_ItemDataBound" OnItemCommand="lvSubmittedChaForm_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">Member No
                        </th>
                        <th class="text-center">Member Name
                        </th>
                        <th class="text-center">Aggrement No
                        </th>
                        <th class="text-center">Aggrement Date
                        </th>
                        <th>Forign Customer Name
                        </th>
                        <th>Forign Customer Bank Name
                        </th>
                        <th>Currency
                        </th>
                        <th>Shipment Date
                        </th>
                        <th></th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-md-5">
                        <asp:Label ID="lblMemberNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblMemberName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerBankName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblShipmentDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:LinkButton ID="lnkBtnView" CommandName="viewChaForm" runat="server">View</asp:LinkButton>
                        <asp:LinkButton ID="lnkBtnApprove" CommandName="approveChaForm" runat="server">Approve</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-md-5">
                        <td class="col-md-5">
                            <asp:Label ID="lblMemberNo" runat="server"></asp:Label>
                        </td>
                        <td class="col-md-5">
                            <asp:Label ID="lblMemberName" runat="server"></asp:Label>
                        </td>
                        <asp:Label ID="lblAggrementNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerBankName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblShipmentDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editChaForm" runat="server">Edit</asp:LinkButton>
                        <asp:LinkButton ID="LinkBtnSummit" CommandName="submitChaForm" runat="server">Submit</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </asp:Panel>
    <div>
        <div class="text-center">
            <h2>Approved Cha-Form Listing </h2>
        </div>
    </div>
    <asp:Panel runat="server" ID="Panel1">
        <asp:ListView ID="lvApproved" runat="server" OnItemDataBound="lvApproved_ItemDataBound" OnItemCommand="lvApproved_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">Cha-Form No
                        </th>
                        <th class="text-center">Member No
                        </th>
                        <th class="text-center">Member Name
                        </th>
                        <th class="text-center">Aggrement No
                        </th>
                        <th class="text-center">Aggrement Date
                        </th>
                        <th>Forign Customer Name
                        </th>
                        <th>Forign Customer Bank Name
                        </th>
                        <th>Currency
                        </th>
                        <th>Shipment Date
                        </th>
                        <th></th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-md-5">
                        <asp:Label ID="lblChaFormNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblMemberNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblMemberName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerBankName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblShipmentDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:LinkButton ID="lnkBtnView" CommandName="viewChaForm" runat="server">View</asp:LinkButton>
                        
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-md-5">
                        <asp:Label ID="lblChaFormNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblMemberNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblMemberName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementNo" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblAggrementDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblForignCustomerBankName" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-5">
                        <asp:Label ID="lblShipmentDate" runat="server"></asp:Label>
                    </td>
                    <td class="col-md-2">
                         <asp:LinkButton ID="lnkBtnView" CommandName="viewChaForm" runat="server">View</asp:LinkButton>
                        
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </asp:Panel>
</asp:Content>
