<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterdMemberDashBoard.Master" AutoEventWireup="true" CodeBehind="InvoiceCreate.aspx.cs" Inherits="OMS.Incentive.InsMember.InvoiceCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
    <%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <%--<div class="form-group" style="margin-top: 30px">
        <div class="col-sm-6">
            <asp:HyperLink runat="server" CssClass="btn btn-success" ID="lnkAddNewInvoice" NavigateUrl="Invoice.aspx">Create New Invoice</asp:HyperLink>
        </div>
    </div>--%>
    <div runat="server" id="divInvoice">
        <div>
            <div class="text-center">
                <h2>Invoice </h2>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Member
            </label>
            <div class="col-sm-6">
                <asp:DropDownList CssClass="form-control" ID="ddlMember" runat="server" OnSelectedIndexChanged="ddlMember_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Invoice Date
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control EstablishmentDate"></asp:TextBox>
                <%--<cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>--%>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Invoice No
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Local Item Description
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtLocalItemDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Local Item Quantity
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtLoacItemQuantity" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Local Item Amount
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtLocalItemAmount" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Local Distrubuter Name And Address
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtLocalDistrubuterNameAndAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Country
            </label>
            <div class="col-sm-4">
                <asp:DropDownList CssClass="form-control" ID="ddlCountry" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Currency
            </label>
            <div class="col-sm-4">
                <asp:DropDownList CssClass="form-control" ID="ddlCurrency" AutoPostBack="True" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Dollar Conversion Rate
            </label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtConversionRate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Total Currency Amount
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="form-control" ID="txtTotalcurrency" ReadOnly="true" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Total Dollar Amount
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="form-control" ID="txtDollarAmount" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
        </div>

    </div>
    <div class="panel panel-primary" id="divEnclosedDoc" runat="server">
        <div class="panel-heading">Enclosed Documents</div>
  <div class="panel-body">
      <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-2 control-label">
                Document Name
            </label>
            <div class="col-sm-8 form-inline">
                <asp:TextBox CssClass="form-control" ID="txtDocumentName" runat="server"></asp:TextBox>
                <asp:FileUpload ID="fuEnclosedDoc" runat="server" CssClass="form-control" />
                <asp:Button Text="Upload" ID="btnUpload" CssClass="btn btn-primary" runat="server" OnClick="btnUpload_Click"></asp:Button>
            </div>
        </div>

  </div>
  <div class="panel-footer">
      
      <asp:ListView ID="lvDocumentList" runat="server" OnItemCommand="lvDocumentList_ItemCommand" OnItemDataBound="lvDocumentList_ItemDataBound">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">Document Name</th>                        
                        <th></th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>

            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-md-4">
                        
                        <asp:HyperLink ID="hLinkDocumentLink" runat="server" Target="_blank"><asp:Label ID="lblDocumentName" runat="server" Text="Label"></asp:Label></asp:HyperLink>
                    </td>
                    
                    <td>
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editDocument" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-md-4">
                       <asp:HyperLink ID="hLinkDocumentLink" runat="server" Target="_blank"><asp:Label ID="lblDocumentName" runat="server" Text="Label"></asp:Label></asp:HyperLink>
                    </td>
                    
                    <td>
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editDocument" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
  </div>
</div>
    <hr style="height: 20px" />
    <div runat="server" id="div1">
        <div>
            <div class="text-center">
                <h2>Invoice Items</h2>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Product
            </label>
            <div class="col-sm-6">
                <asp:DropDownList CssClass="form-control" ID="ddlItem" AutoPostBack="True" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                No of Carton
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="form-control" ID="txtQuantity" TextMode="Number" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Carton Size
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="form-control" ID="txtCartonSize" TextMode="Number" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group" style="margin-top: 30px">
            <label class="col-sm-3 control-label">
                Carton Price
            </label>
            <div class="col-sm-6">
                <asp:TextBox CssClass="form-control" ID="txtUnitPrice" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-offset-3 col-sm-9">
            <asp:Button Text="Save" CssClass="btn btn-success" ID="btnSave" runat="server" OnClick="btnSave_Click"></asp:Button>
            <asp:Label ID="lblMessage" runat="server" ></asp:Label>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlCategoryList">
        <asp:ListView ID="lvInvoiceDetail" runat="server" OnItemCommand="lvInvoiceDetail_ItemCommand" OnItemDataBound="lvInvoiceDetail_ItemDataBound">
            <LayoutTemplate>
                <table class="table table-responsive table-hover table-bordered text-center" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="text-center">Product Name</th>
                        <th class="text-center">No Of Carton</th>
                        <th class="text-center">Carton Size</th>
                        <th class="text-center">Total Product</th>
                        <th class="text-center">Carton Price</th>
                        <th class="text-center">Total Amount</th>
                        <th class="text-center">Net Weight</th>
                        <th class="text-center">Gross Weight</th>
                        <th></th>
                    </tr>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tr>

                </table>

            </LayoutTemplate>

            <ItemTemplate>
                <tr class="active">
                    <td class="col-md-4">
                        <asp:Label ID="lblMemberItemName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblQuantity" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblCartonSize" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblTotalProduct" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblCartonPrice" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblNetWeight" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblGrossWeight" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editMemberItem" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="success">
                    <td class="col-md-4">
                        <asp:Label ID="lblMemberItemName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblQuantity" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblCartonSize" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblTotalProduct" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblCartonPrice" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblNetWeight" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="col-md-4">
                        <asp:Label ID="lblGrossWeight" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnEdit" CommandName="editMemberItem" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </asp:Panel>

    <script type="text/javascript">
        $('.EstablishmentDate').datepicker({
            format: "mm/dd/yyyy",
        });
    </script>
</asp:Content>
