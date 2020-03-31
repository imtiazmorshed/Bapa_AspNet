<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterdMemberDashBoard.Master" AutoEventWireup="true" CodeBehind="MemberVarificationStatus.aspx.cs" Inherits="OMS.Incentive.MemberRegisterd.MemberVarificationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server">
        <%--<asp:ListView ID="lvNewMember" runat="server" OnItemDataBound="lvNewMember_ItemDataBound" OnItemCommand="lvNewMember_ItemCommand">--%>
        <asp:ListView ID="lvNewMember" runat="server" OnItemDataBound="lvNewMember_ItemDataBound1">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr >
                        <th class="text-center">Member Name</th>
                        <th class="text-center">VerificationType</th>
                        <th class="text-center">Verification Status</th>
                        <th class="text-center">Last Update Date</th>
                        <th></th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-lg-4">
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-lg-4">
                        <asp:Label ID="lblVerificationTypeId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-lg-2">
                        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-lg-2">
                        <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-lg-4">
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-lg-4">
                        <asp:Label ID="lblVerificationTypeId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-lg-2">
                        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-lg-2">
                        <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
