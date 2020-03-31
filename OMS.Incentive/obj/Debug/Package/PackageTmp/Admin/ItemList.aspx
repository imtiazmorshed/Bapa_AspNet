<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="OMS.Incentive.Admin.ItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divAddCategory">
        <div>
            <div class="text-center">
                <h2>Item Category Add/Upate</h2>
            </div>
        </div>

        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Name
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Code
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Mesurement Unit
            </label>
            <div class="col-sm-4">
                <asp:DropDownList CssClass="form-control" ID="ddlMesumentUnit" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Item Category
            </label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlItemCetagory" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success " Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlCategoryList">
        <asp:ListView ID="lvItem" runat="server" OnItemDataBound="lvItem_ItemDataBound" OnItemCommand="lvItem_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">Name</th>
                        <th class="text-center">Code</th>
                        <th class="text-center">Mesurement Unit</th>
                        <th class="text-center">Category Name</th>
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
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblMesurementUnit" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-2">
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editItemCategory" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMesurementUnit" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editItemCategory" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </asp:Panel>
    
</asp:Content>
