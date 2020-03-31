<%@ Page Title="" Language="C#" MasterPageFile="~/OMS.Master" AutoEventWireup="true" CodeBehind="CompanyInfoView.aspx.cs" Inherits="OMS.WebClient.UIAdmin.CompanyInfoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table width="100%">

        <tr>
            <td colspan="4" style="font-size: large" align="center">--:-- Company Information --:--
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
            <td class="LabelTD" align="left">Company Name :
            </td>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtCompanyNameRequierdFieldValidator" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="r1" runat="server"
                    ControlToValidate="txtCompanyName" ErrorMessage="*"> </asp:RequiredFieldValidator>
            </td>

            <td class="LabelTD" align="left">Zip :
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtZipFieldRequierd" runat="server" ControlToValidate="txtZip" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Company Address :
            </td>
            <td>
                <asp:TextBox ID="txtCompanyAddress" runat="server" Font-Bold="true" TextMode="MultiLine"
                    Height="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyAddress" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">Company Phone :
            </td>
            <td>
                <asp:TextBox ID="txtCompanyPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtCompanyPhoneFieldRequierd" runat="server" ControlToValidate="txtCompanyPhone" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Company Fax :
            </td>
            <td>
                <asp:TextBox ID="txtCompanyFax" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtCompanyFaxFieldRequierd" runat="server" ControlToValidate="txtCompanyFax" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">Company Email :
            </td>
            <td>
                <asp:TextBox ID="txtCompanyEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtCompanyEmailFieldRequierd" runat="server" ControlToValidate="txtCompanyEmail" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Web :
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtWebsiteFieldRequierd" runat="server" ControlToValidate="txtWebsite" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">Slogan :
            </td>
            <td>
                <asp:TextBox ID="txtSlogan" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Country :
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="false"></asp:DropDownList>                
            </td>
            <td class="LabelTD" align="left">City :
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="LabelTD" align="left">Description :
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtDescriptionFieldRequierd" runat="server" ControlToValidate="txtDescription" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">VAT Registration Number :
            </td>
            <td>
                <asp:TextBox ID="txtVATRegistrationNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtVATRegistrationNumberFieldRequierd" runat="server" ControlToValidate="txtVATRegistrationNumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="LabelTD" align="left">TIN Number :
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtTINNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtTINNumberFieldRequierd" runat="server" ControlToValidate="txtTINNumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
            <td class="LabelTD" align="left">Licenced Number :
            </td>
            <td>
                <asp:TextBox ID="txtLicencedNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtLicencedNumberFieldRequierd" runat="server" ControlToValidate="txtLicencedNumber" ErrorMessage="* *"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="LabelTD" align="left">Company Latitude :
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
            </td>
            <td class="LabelTD" align="left">Company Longitude :
            </td>
            <td>
                <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr style="margin-top: 20px" class="margintop">
            <td></td>
            <td style="margin-top: 20px">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <%--<table>
        <tr>
            <td>
                <asp:Label ID="lblLogoLocation" runat="server" Text="Logo Location"></asp:Label>
            </td>
            <td colspan="2" align="center">
                <iframe src="https://www.google.com/maps/embed?pb=!1m0!3m2!1sen!2s!4v1465110666588!6m8!1m7!1sAuo-Ap3_m0ibvCt2WCaPjQ!2m2!1d23.7553216032512!2d90.37577658563583!3f65.52!4f12.120000000000005!5f0.5970117501821992" width="600" height="300" frameborder="0" style="border: 0" allowfullscreen></iframe>
                
            </td>
        </tr>
    </table>--%>

    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>

    <%--  <asp:Repeater ID="rptMarkers" runat="server">
  
    </asp:Repeater>--%>
    <script type="text/javascript">
    var markers = [
    <asp:Repeater ID="rptMarkers" runat="server">
    <ItemTemplate>
                {
                    "title": '<%# Eval("Name") %>',
                    "description": '<%# Eval("Description") %>',
<%--                    "website": '<%# Eval("Website") %>',--%>
                    "lat": '<%# Eval("Latitude") %>',
                    "lng": '<%# Eval("Longitude") %>'
          
                }
    </ItemTemplate>
    <SeparatorTemplate>
        ,
    </SeparatorTemplate>
    </asp:Repeater>
        ];
    </script>
    <script type="text/javascript">
        window.onload = function () {             
            console.log(markers);
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var infoWindow = new google.maps.InfoWindow();
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
            for (i = 0; i < markers.length; i++) {
                var data = markers[i]
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });
                (function (marker, data) {
                    google.maps.event.addListener(marker, "click", function (e) {
                        infoWindow.setContent(data.description);
                        //infoWindow.setContent(data.website);
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
        }
    </script>
    <div id="dvMap" style="width: 800px; height: 350px;">
    </div>
</asp:Content>

