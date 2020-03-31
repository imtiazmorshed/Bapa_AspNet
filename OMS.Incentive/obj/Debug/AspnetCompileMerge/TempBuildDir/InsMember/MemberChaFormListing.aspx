<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterdMemberDashBoard.Master" AutoEventWireup="true" CodeBehind="MemberChaFormListing.aspx.cs" Inherits="OMS.Incentive.InsMember.MemberChaFormListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <div class="text-center">
                <h2>Draft Cha-Form </h2>
            </div>
        </div>
    <div id="divDraftList">
        <asp:ListView ID="lvIDraftChaForm" runat="server" OnItemDataBound="lvIDraftChaForm_ItemDataBound" OnItemCommand="lvIDraftChaForm_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">
                            Aggrement No
                        </th>
                        <th class="text-center">
                            Aggrement Date
                        </th>
                        <th>
                            Forign Customer Name
                        </th>
                        <th>
                            Forign Customer Bank Name
                        </th>
                        <th>
                            Currency
                        </th>
                        <th>
                            Shipment Date
                        </th>
                        <th></th>
                    </tr>
                    <tr >
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tr>
                    
                </table>
            </LayoutTemplate>
            
            <ItemTemplate>
                <tr class = "active">
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
                    <asp:LinkButton ID="lnkBtnEdit" CommandName="editChaForm" runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="lnkBtnSummit" CommandName="submitChaForm" runat="server">Submit</asp:LinkButton>
                </td>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr class = "success">
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
                    <asp:LinkButton ID="lnkBtnEdit" CommandName="editChaForm" runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="lnkBtnSummit" CommandName="submitChaForm" runat="server">Submit</asp:LinkButton>
                </td>
                    </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
    <br />
     <div>
            <div class="text-center">
                <h2>Declined Cha-Form </h2>
            </div>
        </div>
    <div id="divDeclinedList">
         <asp:ListView ID="lvDeclinedChaForm" runat="server" OnItemDataBound="lvDeclinedChaForm_ItemDataBound" OnItemCommand="lvDeclinedChaForm_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">
                            Aggrement No
                        </th>
                        <th class="text-center">
                            Aggrement Date
                        </th>
                        <th>
                            Forign Customer Name
                        </th>
                        <th>
                            Forign Customer Bank Name
                        </th>
                        <th>
                            Currency
                        </th>
                        <th>
                            Shipment Date
                        </th>
                        <th></th>
                    </tr>
                    <tr >
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tr>
                    
                </table>
            </LayoutTemplate>
            
            <ItemTemplate>
                <tr class = "active">
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
                    <asp:LinkButton ID="lnkBtnEdit" CommandName="editChaForm" runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnSummit" CommandName="submitChaForm" runat="server">Submit</asp:LinkButton>
                </td>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr class = "success">
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
                    <asp:LinkButton ID="lnkBtnEdit" CommandName="editChaForm" runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnSummit" CommandName="submitChaForm" runat="server">Submit</asp:LinkButton>
                </td>
                    </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
    <br />
     <div>
            <div class="text-center">
                <h2>Submitted Cha-Form </h2>
            </div>
        </div>
    <div id="divSubmittedList">
        <asp:ListView ID="lvSubmittedChaForm" runat="server" OnItemDataBound="lvSubmittedChaForm_ItemDataBound" OnItemCommand="lvSubmittedChaForm_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">
                            Aggrement No
                        </th>
                        <th class="text-center">
                            Aggrement Date
                        </th>
                        <th>
                            Forign Customer Name
                        </th>
                        <th>
                            Forign Customer Bank Name
                        </th>
                        <th>
                            Currency
                        </th>
                        <th>
                            Shipment Date
                        </th>
                        <th></th>
                    </tr>
                    <tr >
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tr>
                    
                </table>
            </LayoutTemplate>
            
            <ItemTemplate>
                <tr class = "active">
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
                    <asp:LinkButton ID="lnkBtnView" CommandName="ViewChaForm" runat="server">View</asp:LinkButton>
                </td>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr class = "success">
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
                    <asp:LinkButton ID="lnkBtnView" CommandName="ViewChaForm" runat="server">View</asp:LinkButton>
                </td>
                    </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
    <br />
     <div>
            <div class="text-center">
                <h2>Approved Cha-Form </h2>
            </div>
        </div>
    <div id="divApprovedList">
         <asp:ListView ID="lvApprovedChaForm" runat="server" OnItemDataBound="lvApprovedChaForm_ItemDataBound" OnItemCommand="lvApprovedChaForm_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">
                            Aggrement No
                        </th>
                        <th class="text-center">
                            Aggrement Date
                        </th>
                        <th>
                            Forign Customer Name
                        </th>
                        <th>
                            Forign Customer Bank Name
                        </th>
                        <th>
                            Currency
                        </th>
                        <th>
                            Shipment Date
                        </th>
                        <th></th>
                    </tr>
                    <tr >
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tr>
                    
                </table>
            </LayoutTemplate>
            
            <ItemTemplate>
                <tr class = "active">
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
                 <tr class = "success">
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
    </div>
    

</asp:Content>
