<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="AssetDepriciation.aspx.cs" Inherits="OMS.WebClient.UIAsset.AssetDepriciation" %>
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
            </tr>
        <tr>
            <td class="LabelTD" align="left">Ration :
            </td>
            <td></td>
        </tr>

        <tr>
            <td class="LabelTD" align="left">Year :
            </td>
            <td>

            </td>
        </tr>

        <tr style="margin-top: 20px" class="margintop">
            <td></td>
            <td style="margin-top: 20px">
                <asp:Button ID="btnSave" runat="server" Text="Save"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel"/>
            </td>
        </tr>
    </table>
</asp:Content>
