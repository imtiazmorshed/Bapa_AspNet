<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="ExistingMemberInCommiteeMeeting.aspx.cs" Inherits="OMS.Incentive.MemberVerification.ExistingMemberInCommiteeMeeting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ListView ID="lvNewMember" runat="server" OnItemCommand="lvNewMember_ItemCommand" OnItemDataBound="lvNewMember_ItemDataBound">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>Member Name
                        </th>
                        <th>Member No
                        </th>
                        <th>VerificationType
                        </th>
                        <th>Verification Status
                        </th>
                        <%--<th>Last Update Date
                        </th>--%>
                        <th></th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMemberNo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblVerificationTypeId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                    <%--<td>
                        <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                    </td>--%>
                    <td>
                        <asp:LinkButton ID="lnkBtnApproval" CommandName="memberapproval" runat="server" Text="Approve"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMemberNo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblVerificationTypeId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                    <%--<td>
                        <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                    </td>--%>
                    <td>
                        <asp:LinkButton ID="lnkBtnApproval" CommandName="memberapproval" runat="server" Text="Approve"></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
</asp:Content>
