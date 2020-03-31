<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="MeasurementUnitView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.MeasurementUnitView" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" >
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>  
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Unit"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox>
                        </td>
                    </tr> 
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                onclick="btnCancel_Click" />
                        </td>
                    </tr>                   
                </table>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:ListView ID="lvMeasurementUnit" runat="server" DataKeyNames="IID" 
                     onitemcommand="lvMeasurementUnit_ItemCommand" 
                     onitemdatabound="lvMeasurementUnit_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class ="dGridHeaderClass">
                                <th align ="left">
                                    Measurement Unit
                                </th>
                                <th align ="left">
                                    Unit
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
                        <tr id="trBody" runat="server" class ="dGridRowClass">
                            <td align ="left">
                                <asp:LinkButton ID="lnkMeasurementUnit" runat="server"></asp:LinkButton>
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblUnit" runat="server"></asp:Label>                                
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server" class ="dGridAltRowClass">
                            <td align ="left">
                                <asp:LinkButton ID="lnkMeasurementUnit" runat="server"></asp:LinkButton>
                            </td>
                            <td align ="left">
                                <asp:LinkButton ID="lnkUnit" runat="server"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:DataPager ID="dpMeasurementUnit" runat="server" PagedControlID="lvMeasurementUnit" 
                      PageSize="5" onprerender="dpMeasurementUnit_PreRender">
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
