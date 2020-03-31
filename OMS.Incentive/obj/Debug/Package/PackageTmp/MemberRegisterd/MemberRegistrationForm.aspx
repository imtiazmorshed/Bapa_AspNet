<%@ Page Title="" Language="C#" MasterPageFile="~/IncentiveWeb.Master" AutoEventWireup="true" CodeBehind="MemberRegistrationForm.aspx.cs" Inherits="OMS.Incentive.MemberRegisterd.MemberRegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<hr class="featurette-divider">
    <div class="generalInformation">
        <div>
            <div class="text-center">
                <h2>General Information</h2>
            </div>
        </div>

        <div class="form-group" style="margin-top: 30px">
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
            <label for="inputPassword3" class="col-sm-3 control-label">Fax</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">                
                <div id="next1" class="btn btn-success ">Next</div>
                
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
            <label for="inputPassword3" class="col-sm-3 control-label">Industry Location</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtIndustryLocation" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group ">
            <label for="inputPassword3" class="col-sm-3 control-label">Company Establishment Year</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtCompanyEstablishmentDate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Industry Foundation Year</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtIndustryFoundationDate" runat="server" CssClass=" form-control"></asp:TextBox>
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
            <label for="inputPassword3" class="col-sm-3 control-label">Manufactured Products</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtManufacturedProducts" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Imported Products</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtImportedProducts" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Exported Products</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtExportedProducts" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Name Of The Associations</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtNameOfTheAssociations" runat="server" CssClass="form-control"></asp:TextBox>
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
            <label for="inputPassword3" class="col-sm-3 control-label">Registration Amount</label>
            <div class="col-sm-6">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Payorder No</label>
            <div class="col-sm-6">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Payorder Date</label>
            <div class="col-sm-6">
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Payorder Slip</label>
            <div class="col-sm-3">
                <asp:FileUpload ID="fuPayorderSlip" name="fuPayorderSlip" runat="server" accept=".pdf, .png,.jpg,.jpeg, .JPG, .JPEG,.gif" />
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
        <div>
            <div class="text-center">
                <h2>Attasted Documents</h2>
            </div>
        </div>    
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">TIN Certificate</label>
            <div class="col-sm-3">                
                <asp:FileUpload ID="fuTINCertificate" name="UploadedFile" runat="server" accept=".png,.jpg,.jpeg, .JPG, .JPEG, .gif" />
            </div>
        </div>

        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Trade license</label>
            <div class="col-sm-3">                
                <asp:FileUpload ID="fuTradeLicense" runat="server" accept=".png,.jpg,.jpeg, .JPG, .JPEG, .gif" />
            </div>
        </div>

        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">VAT Certificate</label>
            <div class="col-sm-3">
                <asp:FileUpload ID="fuVATCertificate" runat="server" accept=".png,.jpg,.jpeg, .JPG, .JPEG, .gif" />
            </div>
        </div>

        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Partnership Agrement</label>
            <div class="col-sm-3">
                <asp:FileUpload ID="fuPartnershipAgrement" runat="server" accept=".png,.jpg,.jpeg, .JPG, .JPEG, .gif" />
            </div>
        </div>

        <div class="form-group">
            <label for="inputPassword3" class="col-sm-3 control-label">Bank Statment</label>
            <div class="col-sm-3">
                <asp:FileUpload ID="fuBankStatment" runat="server" accept=".png,.jpg,.jpeg, .JPG, .JPEG, .gif" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                <div id="previous3" class="btn btn-success">Previous</div>
                <asp:Button ID="btnSubmit" CssClass="btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                
            </div>
        </div>
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
                format: "mm/dd/yyyy",
            });
    </script>

</asp:Content>