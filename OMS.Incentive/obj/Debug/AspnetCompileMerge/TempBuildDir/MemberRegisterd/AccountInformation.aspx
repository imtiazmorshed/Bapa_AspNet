<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterdMemberDashBoard.Master" AutoEventWireup="true" CodeBehind="AccountInformation.aspx.cs" Inherits="OMS.Incentive.MemberRegisterd.AccountInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-success">
        Registerd Member Account Information
    </h1>
    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
    <br />
        <h3 class="text-center text-success"><asp:Label ID="lblMessage" runat="server"></asp:Label></h3>
    <div class="form-group" style="margin-top: 40px">
        <label class="col-sm-3 control-label">Company Name</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtCompanyName" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">Company Name (Bangla)</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtCompanyNameBangla" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="col-sm-3 control-label">Company Address</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtCompanyAddress" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label class="col-sm-3 control-label">Company Address(Bangla)</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtCompanyAddressBangla" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Email</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Phone</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtPhone" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Mobile</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtMobile" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Fax</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtFax" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Industry Location</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtIndustryLocation" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group ">
        <label for="inputPassword3" class="col-sm-3 control-label">Company Establishment Year</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtCompanyEstablishmentDate" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Industry Foundation Year</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtIndustryFoundationDate" runat="server" ReadOnly="false" CssClass=" form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Type Of Business</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtTypeOfBusiness" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Company Type</label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtCompanyTypeID" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Company Category</label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtCompanyCategoryID" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Manufactured Products</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtManufacturedProducts" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Imported Products</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtImportedProducts" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Exported Products</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtExportedProducts" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Name Of The Association</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtNameOfTheAssociations" runat="server" ReadOnly="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </div>

</asp:Content>
