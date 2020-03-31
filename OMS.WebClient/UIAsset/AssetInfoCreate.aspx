<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="AssetInfoCreate.aspx.cs" Inherits="OMS.WebClient.UIAsset.AssetInfoCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table width="100%">

        <tr>
            <td colspan="4" style="font-size: large" align="center">--:-- Asset Information --:--
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
            <td colspan="4" align="center">
                <asp:Label ID="Label1" runat="server" EnableTheming="false" ForeColor="Green" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Asset Type :
            </td>
            <td>
                <asp:DropDownList ID="ddlAssetList" runat="server"></asp:DropDownList>
            </td>

            <td class="LabelTD" align="left">Name :
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Serial :
            </td>
            <td>
                <asp:TextBox ID="txtSerial" runat="server"></asp:TextBox>                
            </td>
            <td class="LabelTD" align="left">Qty :
            </td>
            <td>
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">FAR No :
            </td>
            <td>
                <asp:TextBox ID="txtFarNo" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">Location :
            </td>
            <td>
                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Origin :
            </td>
            <td>
                <asp:TextBox ID="txtOrigin" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">Purchace Year :
            </td>
            <td>
                <asp:TextBox ID="txtPurchaceYear" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Unit Price :
            </td>
            <td >
                <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                <%--<asp:TextBox ID="txtSCAddress" runat="server" TextMode="MultiLine" Height="40"></asp:TextBox>--%>
            </td>
            <td class="LabelTD" align="left">
            </td>
            <td>
                               
            </td>
        </tr>


        <tr style="margin-top: 20px" class="margintop">
            <td></td>
            <td style="margin-top: 20px">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
        </tr>
    </table>

    <table width="100%">
        <tr>
            <td align="center">
                <asp:ListView ID="ListViewAssetInfo" runat="server" OnItemCommand="ListViewAssetInfo_ItemCommand" OnItemDataBound="ListViewAssetInfo_ItemDataBound" OnPagePropertiesChanging="ListViewAssetInfo_PagePropertiesChanging" >
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
                                    Name
                                </th>
                                <th align="center">
                                    Serial
                                </th>
                                <th align="center">
                                    Qty
                                </th>
                                <th align="center">
                                    FAR No
                                </th>
                                <th align="center">
                                    Location
                                </th>
                                <th align="center">
                                    Origin
                                </th>
                                <th align="center">
                                    Purchace Year
                                </th>
                                <th align="center">
                                    Unit Price
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
                            <td width="5%" align="center">
                                <%--<asp:Label ID="Label3" runat="server"><%#Eval("AssetTypeID") %></asp:Label>--%>
                                 <asp:LinkButton ID="lblAssetTypeID" runat="server"><%#Eval("AssetTypeID") %></asp:LinkButton>                               
                           </td>
                            <td align="left">                               
                               <asp:Label ID="lblName" runat="server"><%#Eval("Name") %></asp:Label>
                            </td>

                            <td width="5%" align="center">
                                <asp:Label ID="lblSerialNo" runat="server"><%#Eval("Serial") %></asp:Label>
                           </td>
                            
                            <td width="5%" align="center">
                                <asp:Label ID="lblQty" runat="server"><%#Eval("Qty") %></asp:Label>
                           </td>
                            <td width="5%" align="center">
                                <asp:Label ID="lblFarNo" runat="server"><%#Eval("FARNo") %></asp:Label>
                           </td>

                            <td width="5%" align="center">
                                <asp:Label ID="lblLocation" runat="server"><%#Eval("Location") %></asp:Label>
                           </td>

                            <td width="5%" align="center">
                                <asp:Label ID="lblOrigin" runat="server"><%#Eval("Origin") %></asp:Label>
                           </td>

                            <td width="5%" align="center">
                                <asp:Label ID="lblPurchaceYear" runat="server"><%#Eval("PurchesYear") %></asp:Label>
                           </td>

                            <td width="5%" align="center">
                                <asp:Label ID="lblUnitPrice" runat="server"><%#Eval("UnitPrice") %></asp:Label>
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
                <asp:DataPager ID="dpList" runat="server" PagedControlID="ListViewAssetInfo" PageSize="20" OnPreRender="dpList_PreRender">
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
