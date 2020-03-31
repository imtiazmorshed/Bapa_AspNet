<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="ChaFormApproval.aspx.cs" Inherits="OMS.Incentive.Admin.ChaFormApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-2 control-label">
                Cha-Form No
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtChaFormNo" CssClass="form-control" runat="server" CausesValidation="True"></asp:TextBox>
            </div>
            <div class="col-sm-offset-2">
                <asp:Button ID="btnApproved" CssClass="btn btn-success " runat="server" Text="Approve" OnClick="btnApproved_Click" />
            </div>
        </div>
    </div>
</asp:Content>
