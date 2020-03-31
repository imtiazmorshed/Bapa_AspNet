<%@ Page Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="ChannelView.aspx.cs"
    Inherits="OMS.WebClient.UIInventory.ChannelView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" >
        <tr>
            <td>
                <table width="100%">
                    <tr>
                    
                        <td colspan = "4" align ="left" bgcolor="#77ACAA" style="color: #FFFFFF; font-size: medium;">
                            Channel Basic Information
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Code"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Parent"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:DropDownList ID="ddlParent" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Channel Type"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:DropDownList ID="ddlChannelType" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan = "4" align ="left" bgcolor="#77ACAA" style="color: #FFFFFF; font-size: medium;">
                            Channel Contacts
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Phone"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Fax"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>                        
                        <td>
                            <asp:Label ID="lblWeb" runat="server" Text="Web"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtWeb" runat="server"></asp:TextBox>                            
                        </td>
                        
                    </tr>
                    <tr>
                    
                        <td colspan = "4" align ="left" bgcolor="#77ACAA" style="color: #FFFFFF; font-size: medium;">
                        
                            Channel Contact Person
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtContactPersonAddress" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Phone"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtContactPersonPhone" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtContactPersonMobile" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="txtContactPersonEmail" runat="server"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align ="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                onclick="btnCancel_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                  <asp:ListView ID="lvChannel" runat="server" DataKeyNames="IID" 
                      onitemcommand="lvChannel_ItemCommand" onitemdatabound="lvChannel_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" class ="dGridHeaderClass">
                                <th align ="left">
                                    Name
                                </th>
                                <th align ="left">
                                    Code
                                </th>
                                <th align ="left">
                                    Channel Type
                                </th>
                                <th align ="left">
                                    Phone/Mobile
                                </th>
                                <th align ="left">
                                    Contact Person
                                </th>
                                <th align ="left">
                                    Contact Person Phone/Mobile
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
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblChannelType" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblPhoneMobile" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblContactPerson" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblContactPersonPhoneMobile" runat="server"></asp:Label>                                
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
                                <asp:LinkButton ID="lnkName" runat="server"></asp:LinkButton>
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblChannelType" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblPhoneMobile" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblContactPerson" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblContactPersonPhoneMobile" runat="server"></asp:Label>                                
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
                <asp:DataPager ID="dpChannel" runat="server" PagedControlID="lvChannel" 
                      PageSize="5" onprerender="dpChannel_PreRender" >
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
