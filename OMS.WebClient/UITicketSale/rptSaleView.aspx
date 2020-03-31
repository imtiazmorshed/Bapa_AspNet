<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="rptSaleView.aspx.cs" Inherits="OMS.WebClient.UITicketSale.rptSaleView" %>
<%@ Register src="../Controls/wucReportSale.ascx" tagname="wucReportSale" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <table style="border: 1px; border-color: Black; width: 100%;">
            <tr>
                <td valign="top">
                    
                        <table style="border: 1px solid #C0C0C0; width: 100%;">
                            <tr>
                                <td>
                               <uc1:wucReportSale ID="wucReportSale1" runat="server" />
                                </td>                                
                            </tr>                            
                        </table>
                    
                </td>
            </tr>
            
        </table>
</asp:Content>
