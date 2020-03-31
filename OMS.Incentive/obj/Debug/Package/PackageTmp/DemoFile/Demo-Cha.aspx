<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo-Cha.aspx.cs" Inherits="OMS.Incentive.DemoFile.Demo_Cha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
    <div class="form-group">
        <div class="row">
            <div class="col-md-offset-1 col-md-8">
                সার্কুলার নং-১৫/২০০৫ এর ০৪(ক) অনুচ্ছেদ দ্রষ্টব্য
            </div>
            <div class="col-md-offset-2">
                ফরম-চ
            </div>
        </div>
    </div>
    <div class="text-center form-group">
        <div class="row">
            <div class="col-md-12">
                <h2>বাংলাদেশ এগ্রো-প্রসেসরস এসোসিয়েশন  (বাপা)</h2>
                <p>
                    নাভানা নিউবেরি প্লেস, ফ্ল্যাট #ডি-৬(৭ম তলা), ৪/১/এ সোবহানবাগ, ধানমন্ডি, ধাকা-১২০৭ । ফোনঃ ৮১৪৪৫৩৬, ০১৭১৫-০৯৮৯০৯, ফ্যাক্সঃ ৯১২৫৪৯০, ইমেইলঃinfo@bapabd.org
                </p>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-md-offset-1 col-md-8">
                <p>বাপা/৩২/২০</p>
            </div>
            <div class="col-md-offset-1">
                <p>তারিখ:<%--   /  /২০১--%><asp:Label ID="lblNowDate" runat="server"></asp:Label>  </p>
                
            </div>
        </div>
    </div>
    <div class="form-group text-center">
        <div class="col-md-12">
            <p style="font-size: 25px"><strong>বাংলাদেশ এগ্রো-প্রসেসরস এসোসিয়েশন প্রদেয় সনদপত্র</strong> </p>
            <h3>(এসোসিয়েশনের সদস্যবৃন্দের জন্য প্রযোজ্য)</h3>
            <p style="font-size: 15px">প্রক্রিয়াজত (এগ্রো - প্রসেসিং) কৃষিপণ্য রপ্তানি খাতে ভর্তুকির আবেদনের সঙ্গে প্রদেয় সনদপত্র</p>
            <hr />
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ১। আবেদনকারী প্রতিষ্ঠানের নাম :
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CompanyRequiredFieldValidator" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ঠিকানা :
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CompanyAddressRequiredFieldValidator1" runat="server" ControlToValidate="txtAddress" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ২। রপ্তানি ঋণপত্র/চুক্তিপত্র-এর নম্বর :
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtAgrementNumber" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtAgrementNumberRequiredFieldValidator" runat="server" ControlToValidate="txtAgrementNumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                তারিখ :
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtAgrementDate" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtAgrementDateRequiredFieldValidator" runat="server" ControlToValidate="txtAgrementDate" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            মূল্যমান :
        </label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtAggrementValue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtAggrementValueRequiredFieldValidator" runat="server" ControlToValidate="txtAggrementValue" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ৩| বিদেশী ক্রেতার নাম: 
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtForiegnBuyer" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtForiegnBuyerRequiredFieldValidator" runat="server" ControlToValidate="txtForiegnBuyer" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ঠিকানা :
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtForignAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtForignAddressRequiredFieldValidator" runat="server" ControlToValidate="txtForignAddress" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ৪| বিদেশী ক্রেতার ব্যাংকার নাম: 
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtForiegnBankName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtForiegnBankNameRequiredFieldValidator" runat="server" ControlToValidate="txtForiegnBankName" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ঠিকানা :
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtForiegnBankAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtForiegnBankAddressRequiredFieldValidator" runat="server" ControlToValidate="txtForiegnBankAddress" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ৫| ক) ইনভয়েস নম্বর:
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtInvoiceNumberRequiredFieldValidator" runat="server" ControlToValidate="txtInvoiceNumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                তারিখ :
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtInvoiceDateRequiredFieldValidator" runat="server" ControlToValidate="txtInvoiceDate" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            খ) ইনভয়েসে উল্লিখিত পন্যের পরিমান:
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtInvoiceQuientity" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtInvoiceQuientityRequiredFieldValidator" runat="server" ControlToValidate="txtInvoiceQuientity" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                মুল্য:
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtInvoiceQuintityValue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtInvoiceQuintityValueRequiredFieldValidator" runat="server" ControlToValidate="txtInvoiceQuintityValue" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ৬| ক) রপ্তানি পন্যে ব্যবহৃত স্থানীয় উপকরণাদির বর্ণনা: 
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtExportProductUsedQuintity" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtExportProductUsedQuintityRequiredFieldValidator" runat="server" ControlToValidate="txtExportProductUsedQuintity" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                পরিমান:
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtUsedProductQuantity" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtUsedProductQuantityRequiredFieldValidator" runat="server" ControlToValidate="txtUsedProductQuantity" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            মুল্য:
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtUsedProductQuantityValue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtUsedProductQuantityValueRequiredFieldValidator" runat="server" ControlToValidate="txtUsedProductQuantityValue" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            খ) সংগ্রহসূত্র (সরবরাহকারীর নাম ও ঠিকানা): 
        </label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtSupplierNameAndAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtSupplierNameAndAddressRequiredFieldValidator" runat="server" ControlToValidate="txtSupplierNameAndAddress" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ৭। ক) রপ্তানি পন্যের বর্ণনা: 
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtExportProductDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtExportProductDescriptionRequiredFieldValidator" runat="server" ControlToValidate="txtExportProductDescription" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            খ) পরিমান: 
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtExportProductQuaintity" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtExportProductQuaintityRequiredFieldValidator" runat="server" ControlToValidate="txtExportProductQuaintity" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                মুল্য:
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtExportProductRate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtExportProductRateRequiredFieldValidator" runat="server" ControlToValidate="txtExportProductRate" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ৮| জাহাজীকরণের তারিখ:  
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtShippingDate" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtShippingDateRequiredFieldValidator" runat="server" ControlToValidate="txtShippingDate" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                গন্তব্য বন্দর:
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtDestinationAddress" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtDestinationAddressRequiredFieldValidator" runat="server" ControlToValidate="txtDestinationAddress" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ৯ | এক্ষ্পি নম্বর:	  
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtEXPINumber" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtEXPINumberRequiredFieldValidator" runat="server" ControlToValidate="txtEXPINumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                তারিখ:
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtEXPINumberDate" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtEXPINumberDateRequiredFieldValidator" runat="server" ControlToValidate="txtEXPINumberDate" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            মুল্য: 
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtEXPIValue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtEXPIValueRequiredFieldValidator" runat="server" ControlToValidate="txtEXPIValue" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ১০ | মোট প্রত্তাবাসিত রপ্তানি মুল্য(বৈদেশিক মুদ্রায়): 
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtForiegnCurrency" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtForiegnCurrencyRequiredFieldValidator" runat="server" ControlToValidate="txtForiegnCurrency" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3">
            ১১ | প্রত্তাবাসিত রপ্তানি মূল্যের সনদপত্র নম্বর:  
        </label>
        <div class="col-sm-5">
            <asp:TextBox ID="txtExportPriceCertificateNumber" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtExportPriceCertificateNumberRequiredFieldValidator" runat="server" ControlToValidate="txtExportPriceCertificateNumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-1">
            <label class="control-label">
                তারিখ:
            </label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtExportPriceCertificateDate" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtExportPriceCertificateDateRequiredFieldValidator" runat="server" ControlToValidate="txtExportPriceCertificateDate" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <label class="col-sm-3 control-label">
            ১২ | নীট এফওবি মূল্য:  
        </label>
        <div class="col-sm-8">
            <asp:TextBox ID="txtNitFOBValue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtNitFOBValueRequiredFieldValidator" runat="server" ControlToValidate="txtNitFOBValue" ErrorMessage="* *"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-md-offset-1 col-md-8">
            </div>
            <div class="col-md-offset-2">
                ( রপ্তানি কারকের স্বাক্ষর ও তারিখ )
            </div>
        </div>
    </div>

    <div class="form-group text-center">
        <div class="row">
            <div class="col-md-12">
                <p>
                    এতদারা প্রত্তয়ন করা যাইতেছে যে, উপরোক্ত রপ্তানি বিষয়ে ঘুষিত তথ্যাদি সঠিক ও নির্ভুল | ৬ নং ক্রমিকে উল্লিকিত উপকরণাদি উল্লিকিত সরবরাহকারীদের </br>খামারে/আমাদের নিজস্ব খামারে স্থানীয়ভাবে উৎপাদিত| বিদেশী ক্রেতা/আমদানিকারকের যথার্থতা / বিশ্বাসযোগ্যতা সম্পর্কেও নিশ্চিত করা হইল |
                </p>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-md-offset-1 col-md-8">
            </div>
            <div class="col-md-offset-2">
                ( রপ্তানি কারকের স্বাক্ষর ও তারিখ )
            </div>
        </div>
    </div>
    <div class="form-group text-center">
        <div class="row">
            <div class="col-md-12">
                <p>উপরোল্লিকিত উনুচ্ছেদগুলি যথাযথভাবে যাচাইপূর্বক সঠিক পাওয়া গিয়াছে | প্রক্রিয়াজাত(এগ্রো - প্রসেসিং) কৃষিপণ্য রপ্তানির প্রত্তাবাসিত মূল্যের বিপরীতে উপরোক্ত<br /> রপ্তানীকারককে ভর্থুকি প্রদানের জন্য সুপারিশ করা হইল | </p>
            </div>
        </div>
    </div>
    <div class="form-group text-center">
        <div class="row">
            <div class="col-md-12">
                <p>
                   দুইজন কর্মকর্তার স্বাক্ষর ও সীল
                </p>
            </div>
            <hr />
            <div class="col-md-12">
                <p>
                    কোন প্রকার ঘষামজা, কাটাছেঠা বা সংশোধন করা হইলে এই প্রতয়নপত্র বাতিল বলিয়া গণ্য হইবে | 
                </p>
            </div>
        </div>
    </div>


    <div class="form-group">
        <div class="col-sm-offset-3 col-sm-9">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>
    <asp:Label ID="lblmessage" runat="server"></asp:Label>
    <script type="text/javascript">
        $('.EstablishmentDate').datepicker({
            format: "mm/dd/yyyy",
        });
    </script>
    </div>
    </form>
</body>
</html>
