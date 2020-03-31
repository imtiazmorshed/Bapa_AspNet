<%@ Page Title="" Language="C#" MasterPageFile="~/AdminIncentive.Master" AutoEventWireup="true" CodeBehind="RegistrationMemberVerification.aspx.cs" Inherits="OMS.Incentive.MemberRegisterd.RegistrationMemberVerification" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default ">
            <div class="panel-heading ">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse1">
                       <%-- Varification No 1 :--%>
                        <strong> কৃষি পণ্য প্রক্রিয়া করনের সাথে জড়িত আছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse1" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType11" runat="server" GroupName="VType1" Text="হ্যাঁ" />
                        <br />
                        <asp:RadioButton ID="radioVType12" runat="server" GroupName="VType1" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="lblMessage" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment1" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType1" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType1_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse2">
                        <%--Varification No 2 :--%>
                       <strong>  কোম্পানি / ফার্ম / প্রতিষ্ঠান এর প্রতিষ্ঠা / ফ্যাক্টরি আছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse2" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                       <asp:RadioButton ID="radioVType13" runat="server" GroupName="VType2" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType14" runat="server" GroupName="VType2" Text="না"/>                       
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment2" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType2" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType2_Click" />
                        
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse3">
                        <%--Varification No 3 :--%>
                         <strong> কোম্পানি / ফার্ম / প্রতিষ্ঠান এর প্রতিষ্ঠা / ফ্যাক্টরি নেই তবে ভবিষ্যৎএ কোম্পানি / ফার্ম / প্রতিষ্ঠান স্থাপন করবেন এই মর্মে পরিকল্পনা পত্র জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse3" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <%--<asp:Label ID="Label4" runat="server" CssClass="label form-control" Font-Bold="True" Font-Size="Medium" ForeColor="Black">
                            কোম্পানি / ফার্ম / প্রতিষ্ঠান এর প্রতিষ্ঠা / ফ্যাক্টরি নেই তবে ভবিষ্যৎএ কোম্পানি / ফার্ম / প্রতিষ্ঠান স্থাপন করবেন এই মর্মে পরিকল্পনা পত্র জমা দিয়েছেন কি না :
                        </asp:Label><br />--%>
                        <asp:RadioButton ID="radioVType15" runat="server" GroupName="VType3" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType16" runat="server" GroupName="VType3" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label5" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment3" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType3" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType3_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse4"><%--Varification No 4 :--%>
                        <strong> প্রাইভেট / পাবলিক লিঃ কোম্পানির ক্ষেত্রে মেমরান্দাম এন্ড আর্টিকেল এর সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse4" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType17" runat="server" GroupName="VType4" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType18" runat="server" GroupName="VType4" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label7" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment4" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType4" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType4_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse5"><%--Varification No 5:--%>
                        <strong> পার্টনারশিপ কোম্পানির ক্ষেত্রে পার্টনারশিপ ডিড এর সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse5" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType19" runat="server" GroupName="VType5" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType20" runat="server" GroupName="VType5" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label9" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment5" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType5" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType5_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse6"><%--Varification No 6:--%>
                        <strong> পার্টনারশিপ কোম্পানির ক্ষেত্রে বাপা'র প্রতিনিধি মনোনয়ন রেজুলেশন আছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse6" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType21" runat="server" GroupName="VType6" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType22" runat="server" GroupName="VType6" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label11" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment6" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType6" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType6_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse7"><%--Varification No 7:--%>
                        <strong> হালনাগাদ ট্রেড লাইসেন্স এর সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse7" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                       <asp:RadioButton ID="radioVType23" runat="server" GroupName="VType7" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType24" runat="server" GroupName="VType7" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label13" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment7" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType7" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType7_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse8"><%--Varification No 8:--%>
                       <strong>টিআইএস এর সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse8" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType25" runat="server" GroupName="VType8" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType26" runat="server" GroupName="VType8" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label15" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment8" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType8" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType8_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse9"><%--Varification No 9:--%>
                       <strong>  ভ্যাট সংক্রান্ত দলিল এর সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse9" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <%--<asp:Label ID="Label16" runat="server" CssClass="label" Text="ভ্যাট সংক্রান্ত দলিল এর sottyitto কপি জমা দিয়েছেন কি না :" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />--%>
                        <asp:RadioButton ID="radioVType27" runat="server" GroupName="VType9" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType28" runat="server" GroupName="VType9" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label17" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment9" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType9" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType9_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse10"><%--Varification No 10:--%>
                       <strong>  রপ্তানীকারক এর রপ্তানী নিবন্ধনপত্রের সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse10" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <%--<asp:Label ID="Label18" runat="server" CssClass="label" Text="রপ্তানীকারক এর রপ্তানী নিবন্ধনপত্রের সত্যায়িত কপি জমা দিয়েছেন কি না :" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />--%>
                        <asp:RadioButton ID="radioVType29" runat="server" GroupName="VType10" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType30" runat="server" GroupName="VType10" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label19" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment10" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType10" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType10_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse11"><%--Varification No 11:--%>
                       <strong>  কোম্পানির মালিক/প্রধান নির্বাহী কর্মকর্তার দুই কপি সত্যায়িত ছবি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse11" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                       <asp:RadioButton ID="radioVType31" runat="server" GroupName="VType11" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType32" runat="server" GroupName="VType11" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label21" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment11" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType11" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType11_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse12"><%--Varification No 12:--%>
                       <strong>  প্রতিনিধির ক্ষেত্রে তার জাতীয় পরিচয়পত্র এর সত্যায়িত কপি জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse12" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                       <asp:RadioButton ID="radioVType33" runat="server" GroupName="VType12" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType34" runat="server" GroupName="VType12" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label23" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment12" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType12" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType12_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse13"><%--Varification No 13:--%>
                        <strong> আবেদন ফি বাবদ ২০,০০০/-(বিশ হাজার) টাকা ও সংশ্লিষ্ট বছরের বার্ষিক ফি বাবদ ১০,০০০/-(দশ হাজার) টাকা মোট ৩০,০০০/(ত্রিশ হাজার) টাকার পে-অরডার 'বাংলাদেশ এগ্রো-প্রসেসরস এসোসিয়েশন' এর অনুকুলে জমা দেয়া হয়েছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse13" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType35" runat="server" GroupName="VType13" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType36" runat="server" GroupName="VType13" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label25" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment13" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType13" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType13_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse14"><%--Varification No 14:--%>
                       <strong>  প্রস্তুতকারক বা রপ্তানী উৎপাদন/রপ্তানী পণ্যের তালিকা জমা দিয়েছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse14" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType37" runat="server" GroupName="VType14" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType38" runat="server" GroupName="VType14" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label27" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment14" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType14" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType14_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse15"><%--Varification No 15:--%>
                       <strong>  ব্যাংক এর হিসাবের প্রত্যয়ন আছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse15" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType39" runat="server" GroupName="VType15" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType40" runat="server" GroupName="VType15" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label29" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment15" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType15" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType15_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse16"><%--Varification No 16:--%>
                        <strong> প্রত্রিস্রুতি দাখিল করেছেন কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse16" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType41" runat="server" GroupName="VType16" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType42" runat="server" GroupName="VType16" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label31" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment16" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType16" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType16_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse17"><%--Varification No 17:--%>
                       <strong>  কোম্পানী এর প্রতিষ্ঠান/প্রসেসিং ফ্যাক্টরী অডিট করানো হয়েছে কিনা । অডিট রিপোর্ট সংযুক্ত আছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse17" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType43" runat="server" GroupName="VType17" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType44" runat="server" GroupName="VType17" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label33" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment17" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType17" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType17_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse18"><%--Varification No 18:--%>
                        <strong> মেম্বারশীপ এর আবেদন ফরমটি সঠিকভাবে পূরণ করা হয়েছে কি না :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse18" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:RadioButton ID="radioVType45" runat="server" GroupName="VType18" Text="হ্যাঁ" />
                        <br />
                       <asp:RadioButton ID="radioVType46" runat="server" GroupName="VType18" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label35" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment18" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType18" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType18_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse19"><%--Varification No 19:--%>
                       <strong>কোন পয়েন্ট-এ না থাকলে ইহা করিয়া কবে জমা দিবেন :</strong> 
                    </a>
                </h4>
            </div>
            <div id="collapse19" class="panel-collapse collapse">
                <ul class="list-group">
                    <li class="list-group-item">
                       <asp:RadioButton ID="radioVType47" runat="server" GroupName="VType19" Text="হ্যাঁ" ></asp:RadioButton>
                        <br />
                       <asp:RadioButton ID="radioVType48" runat="server" GroupName="VType19" Text="না"/>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="Label37" runat="server" CssClass="label" Text="যাচাই কারীর মন্তব্য" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label><br />
                        <asp:TextBox ID="txtComment19" CssClass="form-control" runat="server"
                            TextMode="MultiLine"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Button ID="btnVType19" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnVType19_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>



         <div class="panel-group col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:Button ID="btnAllSubmit" CssClass="btn btn-success" runat="server" Text="Approved For Commitee Meeting" OnClick="btnAllSubmit_Click"/>
                    </li>
                </ul>
            </div>
    </div>
        </div>
</asp:Content>
