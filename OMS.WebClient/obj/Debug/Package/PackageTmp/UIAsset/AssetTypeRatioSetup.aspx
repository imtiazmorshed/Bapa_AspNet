<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="AssetTypeRatioSetup.aspx.cs" Inherits="OMS.WebClient.UIAsset.AssetTypeRatioSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">

        <tr>
            <td colspan="4" style="font-size: large" align="center">--:-- Asset Depriciation Ratio --:--
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
                <asp:Label ID="lblMsg" runat="server" EnableTheming="false" ForeColor="Green" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Asset Type :
            </td>
            <td>
                <asp:DropDownList ID="ddlAssetList" runat="server"></asp:DropDownList>
            </td>
            </tr>
        <tr>

            <td class="LabelTD" align="left">Ratio :
            </td>
            <td>
                <asp:TextBox ID="txtRatio" runat="server"></asp:TextBox>
            </td>
            </tr>
        <tr>
        
            <td class="LabelTD" align="left">Year :
            </td>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server">
                    <asp:ListItem>2001-2002</asp:ListItem>
                    <asp:ListItem>2002-2003</asp:ListItem>
                    <asp:ListItem>2003-2004</asp:ListItem>
                    <asp:ListItem>2004-2005</asp:ListItem>
                    <asp:ListItem>2005-2006</asp:ListItem>
                    <asp:ListItem>2006-2007</asp:ListItem>
                    <asp:ListItem>2007-2008</asp:ListItem>
                    <asp:ListItem>2008-2009</asp:ListItem>
                    <asp:ListItem>2009-2010</asp:ListItem>
                    <asp:ListItem>2010-2011</asp:ListItem>
                    <asp:ListItem>2011-2012</asp:ListItem>
                    <asp:ListItem>2012-2013</asp:ListItem>
                    <asp:ListItem>2013-2014</asp:ListItem>
                    <asp:ListItem>2014-2015</asp:ListItem>
                    <asp:ListItem>2015-2016</asp:ListItem>
                    <asp:ListItem>2016-2017</asp:ListItem>
                    <asp:ListItem>2017-2018</asp:ListItem>
                    <asp:ListItem>2018-2019</asp:ListItem>
                    <asp:ListItem>2019-2020</asp:ListItem>
                    <asp:ListItem>2020-2021</asp:ListItem>
                    <asp:ListItem>2021-2022</asp:ListItem>
                    <asp:ListItem>2022-2023</asp:ListItem>
                    <asp:ListItem>2023-2024</asp:ListItem>
                    <asp:ListItem>2024-2025</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="margin-top: 20px" class="margintop">
            <td></td>
            <td style="margin-top: 20px">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>

    <table width="100%">
        <tr>
            <td align="center">
                <asp:ListView ID="ListViewAssetTypeRatio" runat="server" OnItemCommand="ListViewAssetTypeRatio_ItemCommand" OnItemDataBound="ListViewAssetTypeRatio_ItemDataBound" OnPagePropertiesChanging="ListViewAssetTypeRatio_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class="dGridHeaderClass">
                                <th align="center">
                                    Sl No.
                                </th>
                                <th align="center">
                                    Asset Type
                                </th>
                                <th align="center">
                                    Ratio
                                </th>
                                <th align="center">
                                    Year
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
                                <asp:LinkButton ID="lblAssetTypeID" runat="server"><%#Eval("AssettypeID") %></asp:LinkButton>
                                <%--<asp:Label ID="lblShortName" runat="server"><%#Eval("Name") %></asp:Label>--%>
                            </td>
                            <td width="5%" align="center">
                                <asp:Label ID="lblRatio" runat="server"><%#Eval("Ratio") %></asp:Label>
                           </td>
                            <td width="5%" align="center">
                                <asp:Label ID="lblyear" runat="server"><%#Eval("AssetYear") %></asp:Label>
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
                <asp:DataPager ID="dpList" runat="server" PagedControlID="ListViewAssetTypeRatio" PageSize="20" OnPreRender="dpList_PreRender">
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
