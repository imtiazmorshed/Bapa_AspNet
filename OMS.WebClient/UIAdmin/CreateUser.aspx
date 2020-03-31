<%@ Page Title="Create User" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true"
    CodeBehind="CreateUser.aspx.cs" Inherits="OMS.WebClient.UIAdmin.CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="InputTable" width="65%" style="border-right: whitesmoke 4px solid; border-top: whitesmoke 4px solid;
        border-left: whitesmoke 4px solid; border-bottom: whitesmoke 4px solid; vertical-align: top;">
        <tr>
            <td align="right" width="25%">
            </td>
            <td align="left" width="75%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: auto;">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label5" runat="server" AccessKey="F" AssociatedControlID="edtFName"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="First Name"></asp:Label></span></strong>
            </td>
            <td align="left">
                <asp:TextBox ID="edtFName" runat="server" Font-Names="Verdana" Width="180px" Font-Size="9pt"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="edtFName" ErrorMessage="First Name Cannot be Empty"
                    Font-Names="Verdana" Font-Size="Small">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label4" runat="server" AccessKey="L" AssociatedControlID="edtLName"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Last Name"></asp:Label></span></strong>
            </td>
            <td align="left">
                <asp:TextBox ID="edtLName" runat="server" Font-Names="Verdana" Width="180px" Font-Size="9pt"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="edtFName" ErrorMessage="Last Name Cannot be Empty"
                    Font-Names="Verdana" Font-Size="Small">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label3" runat="server" AccessKey="N" AssociatedControlID="edtLoginName"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Login Name"></asp:Label></span></strong>
            </td>
            <td align="left">
                <asp:TextBox ID="edtLoginName" runat="server" Font-Names="Verdana" Width="180px"
                    Font-Size="9pt"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        runat="server" ControlToValidate="edtLoginName" ErrorMessage="Login Name Cannot be Empty"
                        Font-Names="Verdana" Font-Size="Small">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label2" runat="server" AccessKey="P" AssociatedControlID="edtPassword"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Password"></asp:Label></span></strong>
            </td>
            <td align="left">
                <asp:TextBox ID="edtPassword" runat="server" Font-Names="Verdana" TextMode="Password"
                    Width="180px" Font-Size="9pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label1" runat="server" AccessKey="C" AssociatedControlID="edtConfirmPassword"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Confirm Password"></asp:Label></span></strong>
            </td>
            <td align="left" style="width: 254px;">
                <asp:TextBox ID="edtConfirmPassword" runat="server" Font-Names="Verdana" TextMode="Password"
                    Width="180px" Font-Size="9pt"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none;">
            <td align="right">
                <asp:Label ID="lblOPassword" runat="server" Text="Description" AccessKey="D" AssociatedControlID="edtDescription"
                    Font-Bold="True" Font-Names="Verdana" Font-Size="9pt"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="edtDescription" runat="server" Font-Names="Verdana" Height="50px"
                    TextMode="MultiLine" Width="211px" Font-Size="9pt" SkinID="MultiLineText"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label7" runat="server" AccessKey="R" AssociatedControlID="ddlBranch"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Branch"></asp:Label></span></strong>
            </td>
            <td align="left" valign="top">
                <asp:DropDownList ID="ddlBranch" runat="server" DataTextField="Name" DataValueField="ID"
                    Font-Names="Verdana" Font-Size="9pt" AppendDataBoundItems="true" Visible="true">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlBranch"
                    ValueToCompare="-1" Operator="NotEqual" ErrorMessage="*" ValidationGroup="r1">
                </asp:CompareValidator>                
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <strong><span style="font-size: 8pt; font-family: Verdana">
                    <asp:Label ID="Label6" runat="server" AccessKey="R" AssociatedControlID="ddlCenter"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Role"></asp:Label></span></strong>
            </td>
            <td align="left" valign="top">
                <asp:DropDownList ID="ddlCenter" runat="server" DataTextField="Name" DataValueField="ID"
                    Font-Names="Verdana" Font-Size="9pt" AppendDataBoundItems="true" Visible="true">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCenter"
                    ValueToCompare="-1" Operator="NotEqual" ErrorMessage="*" ValidationGroup="r1">
                </asp:CompareValidator>
                <asp:CheckBoxList ID="chkRole" runat="server" RepeatDirection="Horizontal" Visible="false">
                </asp:CheckBoxList>
                <asp:TextBox ID="edtEditKey" runat="server" Visible="False" Width="1px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Enabeld" runat="server" AccessKey="B" AssociatedControlID="chkEnabled"
                    Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Enabled"></asp:Label>
            </td>
            <td align="left">
                <asp:CheckBox ID="chkEnabled" runat="server" Font-Names="Verdana" Font-Size="9pt"
                    Checked="true" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:CheckBox ID="chkIsRoleBased" Text="Is PageBased" runat="server" Font-Names="Verdana"
                    Font-Size="9pt" Checked="false" AutoPostBack="true" OnCheckedChanged="chkIsRoleBased_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="divPaged" runat="server" visible="false">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <!--fdsgsdfgsdf-->
                                        <asp:CheckBoxList ID="chkPageList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="chkIsRoleBased" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td align="left">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2" style="border-right: #ff9900 1px solid; border-top: #ff9900 1px solid;
                border-left: #ff9900 1px solid; border-bottom: #ff9900 1px solid; background-color: #ffffcc">
                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="9pt" ForeColor="Red"></asp:Label><asp:ValidationSummary ID="ValidationSummary1"
                        runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Font-Names="Verdana" OnClick="btnAdd_Click"
                    Text="Add" Font-Bold="True" Font-Size="9pt" SkinID="Button" ValidationGroup="r1" />
                <asp:Button ID="btnUpdate" runat="server" Font-Names="Verdana" OnClick="btnUpdate_Click"
                    Text="Update" Font-Bold="True" Font-Size="9pt" SkinID="Button" ValidationGroup="r1"  />
                <%--<asp:Button ID="btnSearch" runat="server" CausesValidation="False"
                                                    Font-Names="Verdana" OnClick="btnSearch_Click" Text="Search" Font-Bold="True" Font-Size="9pt" SkinID="Button" />--%>
                <asp:Button ID="btnClear" runat="server" CausesValidation="False" Font-Names="Verdana"
                    OnClick="btnClear_Click" Text="Clear" Font-Bold="True" Font-Size="9pt" SkinID="Button" />
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%" colspan="2">
                <%--<asp:UpdatePanel id="UpdatePanel2" runat="server">
                                            <contenttemplate>--%>
                <asp:GridView ID="grdUserInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdUserInfo_RowDataBound"
                    CellPadding="4" ForeColor="#333333" Font-Names="Verdana" Font-Size="9pt" OnRowCommand="grdUserInfo_RowCommand"
                    BorderStyle="Solid" BorderWidth="5px" Caption="Users" BorderColor="WhiteSmoke"
                    GridLines="Vertical" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="UserName">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Roles">
                            <ItemTemplate>
                                <asp:Label ID="lblRoles" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Roles">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <%--</contenttemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>
                                        </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>
