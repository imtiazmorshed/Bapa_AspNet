<%@ Page Language="C#" AutoEventWireup="true" Inherits="LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <%--<link rel="icon" type="image/gif" href="App_Themes/Default/_lib/common/animated_favicon.gif" />--%>
    <link rel="icon" href="animated_favicon.gif" type="image/gif" />
    <link rel="stylesheet" href="App_Themes/Default/_lib/css/style.css" media="screen" />
    <link href="App_Themes/Default/_lib/css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <div class="banner">
        </div>
    </div>
    <div style="background-color: #DFEFF9">
        <div>
            <div>
                <div class="centered">
                    <div class="column" style="margin-top: -174px;">
                        <div class="logo">
                        </div>
                        <div class="login_page preserve_links">
                            <div class="title_graphic">
                            </div>
                            <div class="login_frame flexible">
                                <div class="top">
                                </div>
                                <div class="middle">
                                    <div class="flash_message">
                                        <div class="flash_boxes" id="divMsg" runat="server" visible="false">
                                            <img src="App_Themes/Default/_lib/common/notice.png" style="margin-right: 10px; float: left" />
                                            <p>
                                                User Name or password incorrect, or account not activated.</p>
                                        </div>
                                    </div>
                                    <%--<div style="margin: 0pt; padding: 0pt;">&nbsp;</div>--%>
                                    <div>
                                        <b><asp:Label ID="lblMgs" EnableTheming="false" runat="server" Text="" ForeColor="Red"></asp:Label></b>
                                    </div>
                                    <div>
                                        &nbsp;
                                    </div>
                                    <div >
                                        <label for="email">
                                            User Name</label>
                                    </div>
                                    <div >
                                        <asp:TextBox ID="txtUserName" runat="server" EnableTheming="false"></asp:TextBox>
                                    </div>
                                    <div>
                                        <label for="password">
                                            Password</label>
                                        <span>&nbsp;&nbsp; </span>
                                        <%--<a href="https://gist.com/users/forgot_password?from_openid=false">
                                            Forgot password?</a>--%>
                                    </div>
                                    <div >
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" EnableTheming="false"></asp:TextBox>
                                    </div>
                                    
                                    <%--<div class="remember_me_field">
                                        <div style="width:200px">
                                            <asp:CheckBox ID="chkRememberMe" runat="server" />
                                            <label for="remember_me" style="display: inline;">
                                                Stay signed in</label>
                                        </div>
                                    </div>--%>
                                    <div class="actions">
                                        <div style="float: left">
                                            <asp:ImageButton CssClass="inputLogin" ID="btnLogin" runat="server" ImageUrl="~/App_Themes/Default/_lib/common/11.png"
                                                OnClick="btnLogin_Click" EnableTheming="false" Height="25px" Width="80px" ToolTip="Login"
                                                AlternateText="Login" />
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </div>
                                <div class="bottom">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
