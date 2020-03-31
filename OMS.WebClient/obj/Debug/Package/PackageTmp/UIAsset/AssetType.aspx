<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="AssetType.aspx.cs" Inherits="OMS.WebClient.UIAsset.AssetType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td colspan="4" style="font-size: large" align="center">--:-- Asset Type --:--
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-size: large" align="center">
                <br />
            </td>
        </tr>

        
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblMessage" runat="server" EnableTheming="False" ForeColor="Green"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txyAssetName" runat="server" AutoPostBack="True" OnTextChanged="txyAssetName_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtAssetNameFieldValidator" runat="server" ControlToValidate="txyAssetName" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCodes" runat="server" Text="Code"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCode" runat="server" ReadOnly="true"  Enabled="false"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>                
                
            </td>
            <td>
                <asp:Button ID="btnAssetSave" runat="server" Text="Save" OnClick="btnAssetSave_Click" />
                <asp:Button ID="btnAsserCancel" runat="server" Text="Cancel" OnClick="btnAsserCancel_Click" />
            </td>
        </tr>        
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:ListView ID="ListViewAssetType" runat="server" OnItemCommand="ListViewAssetType_ItemCommand" OnItemDataBound="ListViewAssetType_ItemDataBound" OnPagePropertiesChanging="ListViewAssetType_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th align="center">
                                    Sl No.
                                </th>
                                <th align="center">
                                    Name
                                </th>
                                <th align="center">
                                    Code
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr  class="dGridRowClass">
                            <td width="5%" align="center">
                                <asp:Label ID="lblSerial" runat="server"><%#Eval("IID") %></asp:Label>
                           </td>
                            
                            <td align="left">
                                <asp:LinkButton ID="lblShortName" runat="server"><%#Eval("Name") %></asp:LinkButton>
                                <%--<asp:Label ID="lblShortName" runat="server"><%#Eval("Name") %></asp:Label>--%>
                            </td>
                            <td>
                                 <asp:Label ID="lblCode" runat="server"><%#Eval("Code") %></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>    
                <asp:DataPager ID="dpList" runat="server" PagedControlID="ListViewAssetType" PageSize="20" OnPreRender="dpList_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                            ShowNextPageButton="False" ShowFirstPageButton="False" />
                        <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                            NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                            ButtonType="Link" />
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                            NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                            ShowLastPageButton="False" />
                    </Fields>
                </asp:DataPager>            
            </td>
        </tr>
    </table>
</asp:Content>
