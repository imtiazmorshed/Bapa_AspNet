<%@ Page Title="Create Role" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true"
   CodeBehind="CreateRole.aspx.cs" Inherits="OMS.WebClient.UIAdmin.CreateRole" %>

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
                    <asp:Label ID="Label5" runat="server" AccessKey="F" AssociatedControlID="edtRole"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="9pt" Text="Role"></asp:Label></span></strong>
            </td>
            <td align="left">
                <asp:TextBox ID="edtRole" runat="server" Font-Names="Verdana" Width="180px" Font-Size="9pt"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="edtRole" ErrorMessage="Role Cannot be Empty"
                    Font-Names="Verdana" Font-Size="Small">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
        
        
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="divPaged" runat="server" visible="true">
                            <table width="100%">
                                <tr>
                                    <td>
                                        
                                        <asp:CheckBoxList ID="chkPageList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                    
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
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Font-Names="Verdana" OnClick="btnAdd_Click"
                    Text="Add" Font-Bold="True" Font-Size="9pt" SkinID="Button" ValidationGroup="r1" />
                <asp:Button ID="btnUpdate" runat="server" Font-Names="Verdana" OnClick="btnUpdate_Click"
                    Text="Update" Font-Bold="True" Font-Size="9pt" SkinID="Button" />
               <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                    Font-Names="Verdana" Text="Clear" Font-Bold="True" Font-Size="9pt" 
                    SkinID="Button" onclick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%" colspan="2">
                
                <asp:GridView ID="grdRoleInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdRoleInfo_RowDataBound"
                    CellPadding="4" ForeColor="#333333" Font-Names="Verdana" Font-Size="9pt" OnRowCommand="grdRoleInfo_RowCommand"
                    BorderStyle="Solid" BorderWidth="5px" Caption="Roles" BorderColor="WhiteSmoke"
                    GridLines="Vertical" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Roles">
                            <ItemTemplate>
                                <asp:Label ID="lblRole" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
               
            </td>
        </tr>
    </table>
</asp:Content>
