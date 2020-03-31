<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OMS.Incentive.Login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Login</title>

    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="assets/css/form-elements.css"/>
    <link rel="stylesheet" href="assets/css/style.css"/>
    <link href="assets/prettify.css" rel="stylesheet" />
    <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="assets/ico/favicon.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-bapa_logo.png"/>
</head>

<body>

    <!-- Top menu -->
    <nav class="navbar navbar-inverse navbar-no-bg" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#top-navbar-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="/Login/login.aspx">Bangladesh Agro Precess Association(BAPA)</a>
            </div>
        </div>
    </nav>

    <!-- Top content -->
    <div class="top-content">

        <div class="inner-bg">
            <div class="container">
                <div class="row">
                    <div class="col-sm-7 text">
                        <h3 style="color: blue">
                            <strong>BANGLADESH AGRO PROCESSING ASSOCIATION(BAPA)</strong>
                        </h3>
                        <div class="description" style="color: black">
                            <p>
                                Bangladesh is a thickly populated agro based country gifted with favorable conditions yet. Hard working people combined with modern knowledge have contributed admirably to make it solvent in our staple food. Necessity is the mother of invention.
                            </p>
                        </div>
                    </div>
                    <div class="col-sm-5 form-box">
                        <div class="form-top">
                            <div class="form-top-left">
                                <h3>Sign in here</h3>
                            </div>
                            <div class="form-top-right">
                            </div>
                        </div>
                        <div class="form-bottom" >
                            <form role="form" runat="server" class="registration-form">
                                <div class="form-group">
                                    <asp:Label ID="lblStatus" runat="server" ></asp:Label>
                                    <label for="form-first-name">Email</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<input id="txtUserName" type="text" name="form-last-name" placeholder="Password..." class="form-last-name form-control" />--%>

                                </div>
                                <div class="form-group">
                                    <label for="form-last-name">Password</label>

                                    <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<input id="txtPassword" type="password" name="form-last-name" placeholder="Password..." class="form-last-name form-control" />--%>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblLoginStatus" ForeColor="Red" runat="server"></asp:Label>
                                </div>
                                
                                <%--<button type="button" class="btn btn-info btn-lg" onclick="UserLoginFunction()">SignIn</button>--%>
                                <asp:Button ID="btnloginSubmit" CssClass="btn btn-info btn-lg" runat="server" Text="SignIn" OnClick="btnloginSubmit_Click" />
                                <%--<asp:Button ID="btnmodalSignUp" CssClass="btn btn-info btn-lg" runat="server" data-toggle="modal" data-target="#modalSignUp" Text="SignUp"  />--%>
                                <input type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#modalSignUp" value="SignUp"></input>
                                
                            </form>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div id="modalSignUp" class="modal fade col-md-12" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">All Registration</h4>
                </div>
                <div class="modal-body">                    
                    <%--<a href="../MemberRegisterd/ExistingMemberRegistrationForm.aspx" class="btn btn-info btn-lg" title="Registration">Existing Member Registration</a>--%>
                    <a href="../MemberRegisterd/ExistingMember.aspx" class="btn btn-info btn-lg" title="Registration">Existing Member Registration</a>
                    <hr />
                    <a href="../MemberRegisterd/MemberRegistrationForm.aspx" class="btn btn-info btn-lg" title="Registration">New Member Registration </a>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Javascript -->
    <script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="assets/js/jquery-1.11.1.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.backstretch.min.js"></script>
    <script src="assets/js/retina-1.1.0.min.js"></script>
    <script src="assets/js/scripts.js"></script>
    <script src="assets/prettify.js"></script>
    <script src="assets/jquery.bootstrap.wizard.min.js"></script>

    <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->

    <script type="text/javascript">
        function openModal() {
            alert('LOL');
            $('#btnmodalSignUp').Modal({
               
                show: true
            });

        }
</script>




    
    <script>
        $(document).ready(function () {
            $('#rootwizard').bootstrapWizard({
                onNext: function (tab, navigation, index) {
                    if (index == 1) {
                        // Make sure we entered the name
                        if (!$('#txtCompanyName').val()) {
                            alert('You must enter your company name');
                            $('#txtCompanyName').focus();
                            return false;
                        }
                    }


                    // Set the name for the next tab
                    $('#tab6').html('Hello, ' + $('#txtCompanyName').val());

                }, onTabShow: function (tab, navigation, index) {
                    var $total = navigation.find('li').length;
                    var $current = index + 1;
                    var $percent = ($current / $total) * 100;
                    $('#rootwizard .progress-bar').css({ width: $percent + '%' });
                }
            });
            window.prettyPrint && prettyPrint()
        });
    </script>
    <script>
        //$(document).ready(function () {
        //    if (('#btnSubmitAll').val() == null) {
        //        alert('Please Insert All Field !!!')
        //        $('#btnSubmitAll').hide();
        //        return false;
        //    }
        //});
        $(document).ready(function () {
            $("#txtMembershipCode").click(function () {
                $("#btnSubmitAll").show();
            });
        });
    </script>
    <script type="text/javascript">
        function UserOrEmailAvailability() {
            $("#txtCompanyName").blur(function () {
                var value = $('#txtCompanyName').val();
                $.ajax({
                    type: "POST",
                    url: "login.aspx/GetMemberByName",
                    data: '{name: "' + value + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var msg = $("#<%=lblStatus.ClientID%>")[0];
                        if (response.d != "") {
                            msg.style.display = "block";
                            msg.style.color = "red";
                            msg.innerHTML = "Company Name already exists.";
                        }
                        else {
                            //var msg = $("#<%=lblStatus.ClientID%>")[0];
                            msg.style.display = "block";
                            msg.style.color = "green";
                            msg.innerHTML = "Company Name Available";
                        }
                    }<%--,
                    failure: function (response) {
                         var msg = $("#<%=lblStatus.ClientID%>")[0];
                        msg.style.display = "block";
                        msg.style.color = "green";
                        msg.innerHTML = "Company Name Available";
                    } --%>
                });

            });
        }

    </script>


    <script type="text/javascript">
        function UserLoginFunction() {
            //$("#txtCompanyName").blur(function () {
            var UserName = $('#txtUserName').val();
            var PassWord = $('#txtPassword').val();
            $.ajax({
                type: "POST",
                url: "login.aspx/GetUserNameOrPass",
                data: '{name: "' + UserName + ', ' + PassWord + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var msg = $("#<%=lblLoginStatus.ClientID%>")[0];
                        if (response.d != "") {
                            msg.style.display = "block";
                            msg.style.color = "red";
                            msg.innerHTML = "User Name or Password are invalid";
                        }
                        else {
                            //var msg = $("#<%=lblLoginStatus.ClientID%>")[0];
                            msg.style.display = "block";
                            msg.style.color = "green";
                            msg.innerHTML = "";
                        }
                    }<%--,
                    failure: function (response) {
                         var msg = $("#<%=lblStatus.ClientID%>")[0];
                        msg.style.display = "block";
                        msg.style.color = "green";
                        msg.innerHTML = "Company Name Available";
                    } --%>
                });

              //});
          }

    </script>
</body>
</html>
