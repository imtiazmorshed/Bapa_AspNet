<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="ItemCategoryList.aspx.cs" Inherits="OMS.Incentive.Admin.ItemCategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divAddCategory" >
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
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">                
               
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success " Text="Save" OnClick="btnSave_Click" />
                
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">                
               
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"/>
                
            </div>
        </div>
    </div>
     <asp:Panel runat="server" ID="pnlCategoryList">
    <asp:ListView ID="lvItemCategory" runat="server" OnItemDataBound="lvItemCategory_ItemDataBound" OnItemCommand="lvItemCategory_ItemCommand">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">
                            Name
                        </th>
                        <th class="text-center">
                            Code
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
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
                    <td class="col-md-5">
                    <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="col-md-2">
                    <asp:LinkButton ID="lnkBtnEdit" CommandName="editItemCategory" runat="server">Edit</asp:LinkButton>
                </td>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr class = "success">
                <td class="col-md-5">
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
                     <td class="col-md-5">
                    <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="col-md-2">
                    <asp:LinkButton ID="lnkBtnEdit" CommandName="editItemCategory" runat="server">Edit</asp:LinkButton>
                </td>
                    </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
        </asp:Panel>
    
</asp:Content>
