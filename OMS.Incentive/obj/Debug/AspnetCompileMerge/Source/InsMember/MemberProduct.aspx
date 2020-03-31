<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterdMemberDashBoard.Master" AutoEventWireup="true" CodeBehind="MemberProduct.aspx.cs" Inherits="OMS.Incentive.InsMember.MemberProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divAddCategory">
        <div>
            <div class="text-center">
                <h2>Member Product Add/Upate</h2>
            </div>
        </div>
         <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Member
            </label>
            <div class="col-sm-6">
                <asp:DropDownList CssClass="col-md-4 form-control" ID="ddlMember"  runat="server" OnSelectedIndexChanged="ddlMember_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
            </div>
        </div>
         <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Category
            </label>
            <div class="col-sm-6">
                <asp:DropDownList CssClass="col-md-4 form-control" ID="ddlCategory" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ></asp:DropDownList><%--OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"--%>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Item
            </label>
            <div class="col-sm-6">
                <asp:DropDownList CssClass="col-md-4 form-control" ID="ddlItem" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Product Name
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
         <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Product Code
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <%--<div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Code
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="col-md-4" ID="txtCode" runat="server"></asp:TextBox>
            </div>
        </div>--%>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Measurement Unit
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="col-md-4 form-control" ID="txtMeasurementUnit" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Product Weight
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="col-md-4 form-control" ID="txtProductWeight" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success " Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlCategoryList">
        <asp:ListView ID="lvMemberItem" runat="server" OnItemCommand="lvMemberItem_ItemCommand" OnItemDataBound="lvMemberItem_ItemDataBound" >
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">Member</th>
                        <th class="text-center">Product Name</th>
                        <th class="text-center">Product Code</th>
                        <th class="text-center">Category Name</th>
                        <th class="text-center">Item Name</th>                        
                        <th class="text-center">Mesurement Unit</th>
                        <th class="text-center">Weight</th>
                        <th class="text-center"> Action </th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-md-4">
                        <asp:Label ID="lblMember" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblMemberItemName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                    </td>                    
                    <td class="col-md-4">
                        <asp:Label ID="lblItemName" runat="server" Text="Label"></asp:Label>
                    </td>                    
                    <td class="col-md-2">
                        <asp:Label ID="lblMesurementUnit" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblWeight" runat="server" Text="Label"></asp:Label>
                    </td>                    
                    <td class="col-md-2">
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editMemberItem" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-md-4">
                        <asp:Label ID="lblMember" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblMemberItemName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                    </td>                    
                    <td class="col-md-4">
                        <asp:Label ID="lblItemName" runat="server" Text="Label"></asp:Label>
                    </td>                    
                    <td class="col-md-2">
                        <asp:Label ID="lblMesurementUnit" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblWeight" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editMemberItem" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </asp:Panel>
</asp:Content>
