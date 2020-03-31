<%@ Page Title="" Language="C#" MasterPageFile="~/IncentiveWeb.Master" AutoEventWireup="true" CodeBehind="ExistingMember.aspx.cs" Inherits="OMS.Incentive.MemberRegisterd.ExistingMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="generalInformation">
        <div>
            <div class="text-center">
                <h2>General Information</h2>
            </div>
        </div>
        <asp:Label ID="lablmessage" runat="server"></asp:Label>
        <div class="form-group" style="margin-top: 40px">
            <label class="col-sm-3 control-label">
                Membership No
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtMembershipCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 40px">
            <label class="col-sm-3 control-label">
                Company Name
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">
                Company Name(Bangla)
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCompanyNameBangla" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">
                Company Address
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-3 control-label">Company Address(Bangla)</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCompanyAddressBangla" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Email</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Insert Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Confirm Email</label>
            <div class="col-sm-6">
                <asp:TextBox ID="ConfirmtxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtEmail" ControlToValidate="ConfirmtxtEmail" ErrorMessage="Email are not matched" ForeColor="Red"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Password</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Insert Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Confirm Password</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password are not matched" ForeColor="#FF3300"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Phone</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Mobile</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Type Of Business</label>
            <div class="col-sm-6">
                <asp:DropDownList ID="ddlBusniessTypes" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Company Type</label>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlCompanyType" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Company Category</label>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlCompanyCategory" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>



        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Membership Expire Date</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtExpireDate" CssClass="EstablishmentDate" runat="server"></asp:TextBox>
                <%--<cc1:calendarextender id="txtFromDate_CalendarExtender" runat="server" targetcontrolid="txtExpireDate" format="dd/MM/yyyy">
                            </cc1:calendarextender>--%>
            </div>
        </div>
      <%--  <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Account Name</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtAccountName" runat="server" Enabled="false" Width="300"></asp:TextBox>
            </div>
        </div>--%>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Opening Balance</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtOpeningBalance" CssClass="form-control" runat="server"></asp:TextBox>
                <%--<asp:TextBox ID="TextBox4" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>--%>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <%--<div id="previous3" class="btn btn-success">Previous</div>--%>
                <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

            </div>
        </div>
    </div>



    <div class="CompanyInformation displayNone">
        <div>
            <div class="text-center">
                <h2>Company Information</h2>
            </div>
        </div>


        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <div id="previous1" class="btn btn-success">Previous</div>
                <div id="next2" class="btn btn-success">Next</div>
            </div>
        </div>
    </div>

    <div class="RegistrationFee" style="display: none;">
        <div>
            <div class="text-center">
                <h2>Registration Fee</h2>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <div id="previous2" class="btn btn-success">Previous</div>
                <div id="next3" class="btn btn-success">Next</div>
            </div>
        </div>
    </div>

    <div class="AttastedDocument" style="display: none;">
    </div>

    <asp:Label ID="lblmessage" runat="server"></asp:Label>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#next1").click(function () {
                $(".generalInformation").hide();
                $(".CompanyInformation").show();
            });

            $("#next2").click(function () {
                $(".CompanyInformation").hide();
                $(".RegistrationFee").show();
            });


            $("#next3").click(function () {
                $(".RegistrationFee").hide();
                $(".AttastedDocument").show();
            });

            $("#previous1").click(function () {
                $(".CompanyInformation").hide();
                $(".generalInformation").removeClass('properties');
                $(".generalInformation").show();
            });
            $("#previous2").click(function () {
                $(".RegistrationFee").hide();
                $(".CompanyInformation").show();
            });
            $("#previous3").click(function () {
                $(".AttastedDocument").hide();
                $(".RegistrationFee").show();
            });
        });


    </script>

    <style type="text/css">
        .displayNone {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $('.EstablishmentDate').datepicker({
            format: "dd/mm/yyyy",
        });
    </script>

    <%--<div class="container">
        <div class="text-center">
            <h1>Member Registration Form</h1>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="ViewCompanyNameDetails" runat="server">
                <div class="form-group" style="margin-top: 40px">
                    <label class="col-sm-2 control-label">
                        Company Name
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group" style="margin-top: 40px">
                    <label class="col-sm-2 control-label">
                        Company Bangla
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtCompanyNameBangla" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group" style="margin-top: 40px">
                    <label class="col-sm-2 control-label">
                        Company Address
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group" style="margin-top: 40px">
                    <label class="col-sm-2 control-label">Company Address(Bangla)</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtCompanyAddressBangla" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Email</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Insert Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Confirm Email</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="ConfirmtxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtEmail" ControlToValidate="ConfirmtxtEmail" ErrorMessage="Email are not matched" ForeColor="Red"></asp:CompareValidator>
                    </div>
                </div>
                 <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Phone</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Mobile</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
               
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Fax</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnGoToStep2" runat="server" Text="Next >>" OnClientClick="btnGoToStep2_Click" OnClick="btnGoToStep2_Click" />
                    </div>
                </div>
            </asp:View>
            <asp:View ID="ViewContactDetails" runat="server">
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Industry Location</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtIndustryLocation" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group " style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Establishment Year</label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtCompanyEstablishmentDate" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Industry Foundation Year</label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtIndustryFoundationDate" runat="server" CssClass=" form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Type Of Business</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTypeOfBusiness" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Company Type</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlCompanyType" CssClass="form-control" runat="server" ></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Company Category</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlCompanyCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Manufactured Products</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtManufacturedProducts" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Imported Products</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtImportedProducts" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Exported Products</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtExportedProducts" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
               
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnBackStep1" runat="server" Text="<< Previous " OnClientClick="btnGoToStep1_Click" OnClick="btnBackStep1_Click" />
                        <asp:Button ID="btnGoToStep3" runat="server" Text="Next >>" OnClientClick="btnGoToStep3_Click" OnClick="btnGoToStep3_Click" />
                    </div>
                </div>

            </asp:View>
            <asp:View ID="ViewCompanyLocationandDate" runat="server">
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Name Of The Associations</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtNameOfTheAssociations" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Membership Status</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtMembershipStatus" runat="server" CssClass="form-control" ForeColor="Red" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Type Of Submission</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTypeOfSubmission" runat="server" CssClass="form-control" ForeColor="#CC0000" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="margin-top: 30px">
                    <label for="inputPassword3" class="col-sm-2 control-label">Membership Code</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtMembershipCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                 <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Insert Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Confirm Password</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password are not matched" ForeColor="#FF3300"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnStep2" runat="server" Text="<< privious" OnClick="btnStep2_Click" />
                         <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </asp:View>
            <asp:View ID="ViewCompanyProducts" runat="server">
                
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnStep3" runat="server" Text="<< Previous" OnClick="btnStep3_Click" />
                        <asp:Button ID="btnStep5" runat="server" Text="Next >>" OnClick="btnStep5_Click" />
                    </div>
                </div>
            </asp:View>
            <asp:View ID="ViewAssociations" runat="server">
                
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnStepAgain4" runat="server" Text="<< Previous" OnClick="btnStepAgain4_Click" />
                        
                    </div>
                </div>
            </asp:View>
            <asp:View ID="ViewSummary" runat="server">
                <table class="table table-bordered" style="border: 1px solid goldenrod">
                    <tr>
                        <td colspan="2">
                            <h2>Your Full Information</h2>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Name
                        </td>
                        <td>:
                            <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Bangla</td>
                        <td>:<asp:Label ID="lblCompanyBangla" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Address
                        </td>
                        <td>:<asp:Label ID="lblCompanyAddress" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Address(Bangla)
                        </td>
                        <td>:<asp:Label ID="lblCompanyAddressBangla" runat="server" CssClass=" control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h3>Contact Details </h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Phone
                        </td>
                        <td>:<asp:Label ID="lblPhone" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Mobile
                        </td>
                        <td>:<asp:Label ID="lblMobile" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Email
                        </td>
                        <td>:<asp:Label ID="lblEmail" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Fax
                        </td>
                        <td>:<asp:Label ID="lblFax" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h3>Location & Establishmen Date </h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Industry Location
                        </td>
                        <td>:<asp:Label ID="lblIndustryLocation" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Establishment Date
                        </td>
                        <td>:<asp:Label ID="lblCompanyEstablishmentDate" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Industry Foundation Date
                        </td>
                        <td>:<asp:Label ID="lblIndustryFoundationDate" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Type Of Business
                        </td>
                        <td>:<asp:Label ID="lblTypeOfBusiness" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h3>Company Type & Category</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Type
                        </td>
                        <td>:<asp:Label ID="lblCompanyType" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Category
                        </td>
                        <td>:<asp:Label ID="lblCompanyCategory" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Manufactured Products
                        </td>
                        <td>:<asp:Label ID="lblManufacturedProducts" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Imported Products
                        </td>
                        <td>:<asp:Label ID="lblImportedProducts" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Exported Products
                        </td>
                        <td>:<asp:Label ID="lblExportedProducts" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h3>Membership Status & Code </h3>
                        </td>
                    </tr>
                    <tr>
                        <td>Name Of The Associations
                        </td>
                        <td>:<asp:Label ID="lblNameOfTheAssociations" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Membership Status
                        </td>
                        <td>:<asp:Label ID="lblMembershipStatus" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Type Of Submission
                        </td>
                        <td>:<asp:Label ID="lblTypeOfSubmission" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>MembershipCode
                        </td>
                        <td>:<asp:Label ID="lblMembershipCode" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnGoToStepTwo2" runat="server" Text="<< Step 5" OnClick="btnGoToStepTwo2_Click" OnClientClick="btnGoToStepTwo2_Click" />
                        </td>
                        <td>
                           
                        </td>
                    </tr>

                </table>
            </asp:View>
        </asp:MultiView>
    </div>--%>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            //$("#ContentPlaceHolder1_btnGoToStep2").hide();

            //$("#ContentPlaceHolder1_txtCompanyName").keyup(IsValid);
            //$("#ContentPlaceHolder1_txtCompanyNameBangla").keyup(IsValid);
            //$("#ContentPlaceHolder1_txtCompanyAddress").keyup(IsValid);
            //$("#ContentPlaceHolder1_txtCompanyAddressBangla").keyup(IsValid);

            //function IsValid() {
            //    var companyName = $("#ContentPlaceHolder1_txtCompanyName").val();
            //    var companyNameBangla = $("#ContentPlaceHolder1_txtCompanyNameBangla").val();
            //    var companyAddress = $("#ContentPlaceHolder1_txtCompanyAddress").val();
            //    var companyAddressBangla = $("#ContentPlaceHolder1_txtCompanyAddressBangla").val();
            //    //if (companyName != "" && companyNameBangla != "" && companyAddress != "" && companyAddressBangla != "")
            //    if (companyName.trim().length > 0 && companyNameBangla.trim().length > 0 && companyAddress.trim().length > 0 && companyAddressBangla.trim().length > 0) {
            //        $("#ContentPlaceHolder1_btnGoToStep2").css("display", "block");
            //    }
            //    else {

            //    }
            //}


            //$("#ContentPlaceHolder1_btnBackStep1").click(function () {
            //    //if (companyName.length > 0 && companyNameBangla.length > 0 && companyAddress.length > 0 && companyAddressBangla.length > 0)
            //    //    {
            //    alert("SHOW");
            //    $("#ContentPlaceHolder1_btnGoToStep2").show();
            //    //}
            //    //else{}

            //});

        });
    </script>--%>
    <%--<script type="text/javascript">
        $('.EstablishmentDate').datepicker({
            format: "mm/dd/yyyy",
        });
    </script>--%>
</asp:Content>
