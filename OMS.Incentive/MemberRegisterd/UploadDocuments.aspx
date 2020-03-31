<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterdMemberDashBoard.Master" AutoEventWireup="true" CodeBehind="UploadDocuments.aspx.cs" Inherits="OMS.Incentive.MemberRegisterd.UploadDocuments" %>
<%--<%@ Import Namespace="System.Collections.Generic" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-success">Member Uploaded Documents</h1>

        <div runat="server">
        <%--<asp:ListView ID="lvNewMember" runat="server" OnItemDataBound="lvNewMember_ItemDataBound" OnItemCommand="lvNewMember_ItemCommand">--%>
        <asp:ListView ID="lvNewMember" runat="server" OnItemDataBound="lvNewMember_ItemDataBound">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>Member Name
                        </th>
                        <th>VerificationType
                        </th>
                        <th>Verification Status
                        </th>
                        <th>Last Update Date
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
                    <td>
                        <asp:Label ID="lblDocumentName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                         <%--<asp:Image id="lblVerificationTypeId" ImageUrl='<%# Container.DataItem %>' Width="200px" Runat="server" />--%>
                       
                         <%--<asp:Label ID="lblDocumentNamePath" runat="server" Text="Label"></asp:Label>--%>
                             <asp:HyperLink ID="hlinkDocumentNamePath" runat="server"></asp:HyperLink>
                         
                    </td>
                    <td>
                        <asp:Label ID="lblVerificationStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td>
                        <asp:Label ID="lblDocumentName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:Label ID="lblDocumentNamePath" runat="server" Text="Label"></asp:Label>--%>
                             <asp:HyperLink ID="hlinkDocumentNamePath" runat="server" Target="_blank"></asp:HyperLink>
                        
                        <%--<asp:Image id="lblVerificationTypeId" ImageUrl='<%# Container.DataItem %>' Width="200px" Runat="server" />--%>
                    </td>
                    <td>
                        <asp:Label ID="lblVerificationStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLastUpdateDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>


    <%--<div class="table-responsive">
        <table class="table table-bordered table-hover">
            <thead class="text-center">
                <tr class="text-center size-2">
                    <td>Document Name</td>
                    <td> Image</td>
                    <td>Download </td>
                </tr>
            </thead>
            <tbody class="text-center">
                <tr>
                    <td><asp:Label ID="lblBankStatment" runat="server"></asp:Label></td>
                    <td><asp:Image ID="ImgBankStatment" CssClass="img-responsive" Height="50px" Width="30px" runat="server" /></td>
                    <td><asp:HyperLink id="hyperlinkBankStatment" NavigateUrl="#" Text="" Target="_blank"  runat="server"><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink> </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPartnerShip" runat="server"></asp:Label></td>
                    <td><asp:Image ID="ImgPartnerShip" CssClass="img-responsive" Height="50px" Width="30px" runat="server" /></td>
                    <td><asp:HyperLink id="hyperlinkPartnerShip" NavigateUrl="#" Text="" Target="_blank"  runat="server"><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink> </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblVatCertificate" runat="server"></asp:Label></td>
                    <td><asp:Image ID="ImgVatCertificate" CssClass="img-responsive" Height="50px" Width="30px" runat="server" /></td>
                    <td><asp:HyperLink id="hyperlinkVatCertificate" NavigateUrl="#" Text="" Target="_blank"  runat="server"><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink> </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTradeLicense" runat="server"></asp:Label></td>
                    <td><asp:Image ID="ImgTradeLicence" CssClass="img-responsive" Height="50px" Width="30px" runat="server" /></td>
                    <td><asp:HyperLink id="hyperlinkTradeLicence" NavigateUrl="#" Text="" Target="_blank"  runat="server"><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink> </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTinCertificate" runat="server"></asp:Label></td>
                    <td><asp:Image ID="ImgTINcertificate" CssClass="img-responsive" Height="50px" Width="30px" runat="server" /></td>
                    <td><asp:HyperLink id="hyperlinkTINcertificate" NavigateUrl="#" Text="" Target="_blank"  runat="server"><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink> </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPayorderSlip" runat="server"></asp:Label></td>
                    <td><asp:Image ID="ImgPaorder" CssClass="img-responsive" Height="50px" Width="30px" runat="server" /></td>
                    <td><asp:HyperLink id="hyperlinkPayorderSlip" NavigateUrl="#" Text="" Target="_blank"  runat="server"><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink> </td>
                </tr>

            </tbody>
        </table>
    </div>--%>
</asp:Content>
