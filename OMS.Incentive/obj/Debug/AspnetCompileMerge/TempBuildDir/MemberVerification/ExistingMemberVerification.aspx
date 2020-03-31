<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="ExistingMemberVerification.aspx.cs" Inherits="OMS.Incentive.MemberVerification.ExistingMemberVerification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lvNewMember" runat="server" OnItemDataBound="lvNewMember_ItemDataBound" OnItemCommand="lvNewMember_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Member Name
                        </th>
                        <th>
                            Address
                        </th>
                        <th>
                            Verification Status
                        </th>
                        <th>
                            Last Update Date
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
                <td >
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lnkBtnVerification" CommandName="memberverification" runat="server">LinkButton</asp:LinkButton>
                </td>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr class = "success">
                <td >
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lnkBtnVerification" CommandName="memberverification" runat="server">LinkButton</asp:LinkButton>
                </td>
                    </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
</asp:Content>
