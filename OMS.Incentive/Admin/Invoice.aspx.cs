using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using OMS.Web.Helpers;
using System.IO;

namespace OMS.Incentive.Admin
{
    public partial class Invoice : System.Web.UI.Page
    {
        public long MemberID
        {
            get
            {
                if (ViewState["MemberID"] != null)
                {
                    return Convert.ToInt64(ViewState["MemberID"].ToString());
                }
                return 0;
            }
            set
            {
                ViewState["MemberID"] = value;
            }
        }
        public long InvoiceId
        {
            get
            {
                if (ViewState["InvoiceId"] != null)
                    return Convert.ToInt32(ViewState["InvoiceId"].ToString());
                else
                    return 0;
            }
            set
            {
                ViewState["InvoiceId"] = value;
            }
        }

        public long InvoiceDetailId
        {
            get
            {
                if (ViewState["InvoiceDetailId"] != null)
                    return Convert.ToInt32(ViewState["InvoiceDetailId"].ToString());
                else
                    return 0;
            }
            set
            {
                ViewState["InvoiceDetailId"] = value;
            }
        }

        public long CurrentDocumentID
        {
            get
            {
                if (ViewState["CurrentDocumentID"] != null)
                    return Convert.ToInt32(ViewState["CurrentDocumentID"].ToString());
                else
                    return 0;
            }
            set
            {
                ViewState["CurrentDocumentID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                InvoiceId = Convert.ToInt32( (!string.IsNullOrWhiteSpace(Request.QueryString["invId"]) ? Request.QueryString["invId"] : "0"));
            }
            catch (Exception)
            {
                // ignored
            }

            if (!IsPostBack)
            {
                //if (Session["MemberID"] != null)
                //{
                //    MemberID = Convert.ToInt64(Session["MemberID"].ToString());
                    
                //}
                LoadPageData();
                LoadInvoiceEnclosedDocument();

                if (MemberID > 0)
                {
                    ddlMember.SelectedValue = MemberID.ToString();
                    ddlMember.Enabled = false;
                    ddlMember_SelectedIndexChanged(null,null);
                }
            }
        }

        private void LoadInvoiceEnclosedDocument()
        {
            if (InvoiceId > 0)
            {
                using (TheFacade facade = new TheFacade())
                {
                    List<Ins_InvoiceEnclosedDocument> documentList = new List<Ins_InvoiceEnclosedDocument>();
                    documentList = facade.InsentiveFacade.GetInvoiceEnclosedDocumentByInvoiceID(InvoiceId);
                    lvDocumentList.DataSource = documentList;
                    lvDocumentList.DataBind();
                }
            }
        }

        private void LoadPageData()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Member> members = facade.InsentiveFacade.GetMemberAll();
                DDLHelper.Bind<Member>(ddlMember, members, "Name", "ID", EnumCollection.ListItemType.Select, true);

                List<Currency> currencies = facade.CommonFacade.GetCurrencyAll();
                DDLHelper.Bind<Currency>(ddlCurrency, currencies, "CurrencyCode", "IID", EnumCollection.ListItemType.Select, true);

                List<Country> countries = facade.CommonFacade.GetCountryAll();
                DDLHelper.Bind<Country>(ddlCountry, countries, "Name", "IID", EnumCollection.ListItemType.Select, true);

                LoadMemberItem();

                ////List<Ins_ItemCategory> categories = facade.InsentiveFacade.GetCategoryAll();
                ////DDLHelper.Bind<Ins_ItemCategory>(ddlCategory, categories, "Name", "IID", EnumCollection.ListItemType.Select, true);

                if (InvoiceId > 0)
                {
                    Inv_Master invoice = facade.InvoiceFacade.GetInvoiceByID(InvoiceId);
                    if(invoice.MemberId > 0)
                        MemberID = invoice.MemberId.Value;
                    ddlCurrency.SelectedValue = invoice.CurrencyId.ToString();
                    txtDate.Text = invoice.Date.ToString("dd/MM/yyyy");//, CultureInfo.InvariantCulture);
                    txtDollarAmount.Text = invoice.DollarAmount.ToString("#.##");
                    txtTotalcurrency.Text = invoice.CurrencyAmount.HasValue ? invoice.CurrencyAmount.Value.ToString("#.##") : string.Empty;
                    txtConversionRate.Text = invoice.DollarCounversionRate.ToString("#.##");
                    txtInvoiceNo.Text = invoice.Number;
                    txtLocalItemDescription.Text = invoice.ExportedLocalItemDescription;
                    txtLoacItemQuantity.Text = invoice.ExportedLocalItemQuantity  ;
                    txtLocalItemAmount.Text = invoice.ExportedLocalItemAmount.HasValue ? invoice.ExportedLocalItemAmount.Value.ToString("#.##") : string.Empty;
                    txtLocalDistrubuterNameAndAddress.Text = invoice.ExportedLocalDistrubuterNameAndAddress;
                    ddlCountry.SelectedValue = (invoice.CountryID > 0)?invoice.CountryID.ToString():"-1";
                    List<Inv_Detail> invoDetails = facade.InvoiceFacade.GetInvoiceDetailByInvoiceId(InvoiceId);
                    lvInvoiceDetail.DataSource = invoDetails;
                    lvInvoiceDetail.DataBind();
                }
            }
        }

        private void LoadMemberItem()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Ins_MemberItem> memberItems = facade.InsentiveFacade.GetMemberItemByMemberID(MemberID);
                DDLHelper.Bind<Ins_MemberItem>(ddlItem, memberItems, "Name", "IID", EnumCollection.ListItemType.Select, true);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuEnclosedDoc.HasFile && !string.IsNullOrEmpty(txtDocumentName.Text))
            {
                string fileExtention = Path.GetExtension(fuEnclosedDoc.FileName); 

                string path = string.Format("~/MemberData/InvoiceEnclosedDocument/{0}/", InvoiceId.ToString());
                string fileName = Server.MapPath(path) + txtDocumentName.Text  + fileExtention;
                if (CurrentDocumentID <= 0)
                {
                    try
                    {
                        
                        if (!Directory.Exists(Server.MapPath(path)))
                        {
                            Directory.CreateDirectory(Server.MapPath(path));
                        }
                        
                        fuEnclosedDoc.SaveAs(fileName);
                        using (TheFacade facade = new TheFacade())
                        {
                            Ins_InvoiceEnclosedDocument document = new Ins_InvoiceEnclosedDocument();
                            document.Name = txtDocumentName.Text;
                            document.FileName = txtDocumentName.Text + fileExtention;
                            document.Path = path + document.FileName;
                            document.InvoiceID = InvoiceId;
                            document.CreatedDate = DateTime.Now;
                            facade.Insert<Ins_InvoiceEnclosedDocument>(document);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    
                    using (TheFacade facade = new TheFacade())
                    {
                        Ins_InvoiceEnclosedDocument document = facade.InsentiveFacade.GetInvoiceEnclosedDocumentByID(CurrentDocumentID);
                        string existingFile = Server.MapPath(path) + document.FileName;
                        if (File.Exists(existingFile))
                        {
                            File.Delete(existingFile);
                        }
                        if (!Directory.Exists(Server.MapPath(path)))
                        {
                            Directory.CreateDirectory(Server.MapPath(path));
                        }
                        fuEnclosedDoc.SaveAs(fileName);
                        document.Name = txtDocumentName.Text;
                        document.FileName = txtDocumentName.Text  + fileExtention;
                        document.Path = path + document.FileName;
                        document.InvoiceID = InvoiceId;
                        document.CreatedDate = DateTime.Now;
                        facade.Update<Ins_InvoiceEnclosedDocument>(document);
                    }
                }

            }
            //CurrentDocumentID = 0;
            //txtDocumentName.Text = string.Empty;
            //LoadInvoiceEnclosedDocument();
            Response.Redirect(Request.Url.ToString());
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (IsDuplicateInvoiceNo())
            {
                lblMessage.Text = string.Format("The Invoice No {0} already exist. Please try with another Invoice No",txtInvoiceNo.Text);
                return;
            }
            
            using (TheFacade facade = new TheFacade())
            {

                if (InvoiceId <= 0)
                {
                    Inv_Master invoice = new Inv_Master();
                    invoice.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedValue);
                    //invoice.Date = Convert.ToDateTime(txtDate.Text);

                    //DateTime dt = DateTime.ParseExact(txtDate.Text, "dd/M/yyyy", CultureInfo.InvariantCulture);
                    //invoice.Date = dt;// 
                    invoice.Date = Convert.ToDateTime(txtDate.Text);

                    invoice.DollarAmount = 0;//will be updated later
                    invoice.DollarCounversionRate = Convert.ToDecimal(txtConversionRate.Text);
                    invoice.Number = txtInvoiceNo.Text;

                    invoice.CreateBy = 1;//sustemuserid
                    invoice.CreateDate = DateTime.Now;
                    invoice.IsRemoved = 0;
                    invoice.UpdateBy = 1;//sustemuserid
                    invoice.UpdateDate = DateTime.Now;
                    invoice.MemberId = MemberID;
                    invoice.ExportedLocalItemDescription = txtLocalItemDescription.Text;
                    invoice.ExportedLocalItemQuantity = txtLoacItemQuantity.Text;
                    invoice.ExportedLocalItemAmount = Convert.ToDecimal( txtLocalItemAmount.Text);
                    invoice.ExportedLocalDistrubuterNameAndAddress = txtLocalDistrubuterNameAndAddress.Text;
                    invoice.CountryID = Convert.ToInt64(ddlCountry.SelectedValue.ToString());
                    try {
                        facade.Insert<Inv_Master>(invoice);

                        SaveUpdateInvoiceDetail(invoice.IID, facade);
                        InvoiceId = invoice.IID;
                    }
                    catch(Exception ex)
                    {
                        if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                        {
                            lblMessage.Text = "Please Insert Unique Invoice Number";
                        }
                        else
                        {
                            lblMessage.Text = "Data Not Successfully Saved";
                        }
                    }
                }
                else
                {
                    Inv_Master invoice = facade.InvoiceFacade.GetInvoiceByIDForUpdate(InvoiceId);

                    invoice.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedValue);

                    //DateTime dt = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);                    
                    //invoice.Date = dt;// Convert.ToDateTime(txtDate.Text);
                    invoice.Date = Convert.ToDateTime(txtDate.Text);
                    invoice.DollarAmount = 0; ;//will be updated later
                    invoice.DollarCounversionRate = Convert.ToDecimal(txtConversionRate.Text);
                    invoice.Number = txtInvoiceNo.Text;

                    invoice.UpdateBy = 1;//sustemuserid
                    invoice.UpdateDate = DateTime.Now;
                    invoice.MemberId = MemberID;
                    invoice.ExportedLocalItemDescription = txtLocalItemDescription.Text;
                    invoice.ExportedLocalItemQuantity = txtLoacItemQuantity.Text;
                    invoice.ExportedLocalItemAmount = Convert.ToDecimal(txtLocalItemAmount.Text);
                    invoice.ExportedLocalDistrubuterNameAndAddress = txtLocalDistrubuterNameAndAddress.Text;
                    invoice.CountryID = Convert.ToInt64(ddlCountry.SelectedValue.ToString());
                    facade.Update<Inv_Master>(invoice);
                    SaveUpdateInvoiceDetail(invoice.IID, facade);

                }

                UpdateDollarAmount(facade, InvoiceId);
            }

            //Response.Redirect(Request.Url.ToString());
            //SHUVO
            string redirectUrl = Request.Url.GetLeftPart(UriPartial.Path).ToString() + "?invId=" + InvoiceId.ToString();
            Response.Redirect(redirectUrl);
        }

        private bool IsDuplicateInvoiceNo()
        {
            bool isExist = false;
            string invoiceNo = txtInvoiceNo.Text;
            using (TheFacade facade = new TheFacade())
            {
                 isExist = facade.InvoiceFacade.IsExistInvoiceNo(InvoiceId, invoiceNo);
            }
            return isExist;
        }

        private void UpdateDollarAmount(TheFacade facade2, long invoiceId)
        {
            using (TheFacade facade = new TheFacade())
            {
                
                Inv_Master invoice = facade.InvoiceFacade.GetInvoiceByID(InvoiceId);
                if (invoice.InvoiceDetailList?.Count > 0)
                {
                    invoice.CurrencyAmount = invoice.InvoiceDetailList.Sum(s => s.TotalPrice);
                    invoice.DollarAmount = invoice.InvoiceDetailList.Sum(s => s.TotalPrice)*
                                           invoice.DollarCounversionRate;

                    facade.Update<Inv_Master>(invoice);
                }
            }
        }

        private void SaveUpdateInvoiceDetail(long invoiceID,TheFacade facade)
        {
            Inv_Detail invoiceDetail;
            Ins_MemberItem item = facade.InsentiveFacade.GetMemberItemById(Convert.ToInt64(ddlItem.SelectedValue));
            if (InvoiceDetailId <= 0 )
            {
                if (!string.IsNullOrWhiteSpace(txtUnitPrice.Text) && !string.IsNullOrWhiteSpace(txtQuantity.Text) &&
                    Convert.ToInt32(ddlItem.SelectedValue) > 0)
                {
                    invoiceDetail = new Inv_Detail();
                    invoiceDetail.InvMasterId = invoiceID;
                    invoiceDetail.InsMemberItemId = Convert.ToInt64(ddlItem.SelectedValue);
                    invoiceDetail.Quantity = Convert.ToInt32(txtQuantity.Text);
                    //invoiceDetail.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
                    invoiceDetail.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                    invoiceDetail.CartonSize = Convert.ToInt32(txtCartonSize.Text);
                    invoiceDetail.TotalItemCount = invoiceDetail.Quantity * invoiceDetail.CartonSize;
                    invoiceDetail.TotalAmount = invoiceDetail.Quantity * invoiceDetail.UnitPrice;
                    invoiceDetail.TotalWeight = string.IsNullOrEmpty(txtNetWeight.Text)?0: Convert.ToDecimal(txtNetWeight.Text);//item.ItemWeight.Value * invoiceDetail.TotalItemCount;
                    invoiceDetail.GrossWeight = string.IsNullOrEmpty(txtGrossWeight.Text) ? 0 : Convert.ToDecimal(txtGrossWeight.Text);//invoiceDetail.TotalWeight + Convert.ToDecimal(invoiceDetail.CartonSize * 0.2);
                    invoiceDetail.CreateBy = 1; //sustemuserid
                    invoiceDetail.CreateDate = DateTime.Now;
                    invoiceDetail.IsRemoved = 0;
                    invoiceDetail.UpdateBy = 1; //sustemuserid
                    invoiceDetail.UpdateDate = DateTime.Now;
                    facade.Insert<Inv_Detail>(invoiceDetail);
                }
            }
            else
            {

                invoiceDetail = facade.InvoiceFacade.GetInvoiceDetailByID(InvoiceDetailId);
                invoiceDetail.InvMasterId = invoiceID;
                invoiceDetail.InsMemberItemId = Convert.ToInt32(ddlItem.SelectedValue);
                invoiceDetail.Quantity = Convert.ToInt32(txtQuantity.Text);
                invoiceDetail.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                invoiceDetail.CartonSize = Convert.ToInt32(txtCartonSize.Text);
                invoiceDetail.TotalItemCount = invoiceDetail.Quantity * invoiceDetail.CartonSize;
                invoiceDetail.TotalAmount = invoiceDetail.Quantity * invoiceDetail.UnitPrice;
                invoiceDetail.TotalWeight = string.IsNullOrEmpty(txtNetWeight.Text) ? 0 : Convert.ToDecimal(txtNetWeight.Text);//item.ItemWeight.Value * invoiceDetail.TotalItemCount;
                invoiceDetail.GrossWeight = string.IsNullOrEmpty(txtGrossWeight.Text) ? 0 : Convert.ToDecimal(txtGrossWeight.Text);//invoiceDetail.TotalWeight + Convert.ToDecimal(invoiceDetail.CartonSize * 0.2);
                //invoiceDetail.TotalWeight = item.ItemWeight.Value * invoiceDetail.TotalItemCount;
                //invoiceDetail.GrossWeight = invoiceDetail.TotalWeight + Convert.ToDecimal(invoiceDetail.CartonSize * 0.2);
                invoiceDetail.UpdateBy = 1;//sustemuserid
                invoiceDetail.UpdateDate = DateTime.Now;
                facade.Update<Inv_Detail>(invoiceDetail);

            }
        }

        protected void ddlMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            long memberID = Convert.ToInt32(ddlMember.SelectedValue);
            MemberID = memberID;
            LoadMemberItem();
            
        }

        protected void lvInvoiceDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                Label lblMemberItemName = (Label)e.Item.FindControl("lblMemberItemName");
                Label lblQuantity = (Label)e.Item.FindControl("lblQuantity");
                Label lblCartonSize = (Label)e.Item.FindControl("lblCartonSize");
                Label lblTotalProduct = (Label)e.Item.FindControl("lblTotalProduct");
                Label lblCartonPrice = (Label)e.Item.FindControl("lblCartonPrice");
                Label lblTotalAmount = (Label)e.Item.FindControl("lblTotalAmount");
                Label lblNetWeight = (Label)e.Item.FindControl("lblNetWeight");
                Label lblGrossWeight = (Label)e.Item.FindControl("lblGrossWeight");
                
                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");


                Inv_Detail item = dataItem.DataItem as Inv_Detail;


                
                lblMemberItemName.Text = item.Ins_MemberItem.Name;
                lblQuantity.Text = item.Quantity.ToString();
                lblCartonSize.Text = item.CartonSize.ToString();
                lblTotalProduct.Text = item.TotalItemCount.ToString();
                lblCartonPrice.Text = item.UnitPrice.ToString("0.00");
                lblTotalAmount.Text = item.TotalAmount.ToString("#.##");
                lblNetWeight.Text = item.TotalWeight.ToString("0.00");
                lblGrossWeight.Text = item.GrossWeight.ToString("0.00");
                
                lnkBtnEdit.CommandArgument = item.IID.ToString();
                lnkBtnEdit.CommandName = "editInvoiceDetail";
                lnkBtnEdit.Text = "Edit";
            }
        }

        protected void lvInvoiceDetail_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editInvoiceDetail")
            {
                InvoiceDetailId = Convert.ToInt32(e.CommandArgument.ToString());
                LoadInvoiceDetails();

            }
        }

        protected void lvDocumentList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                Label lblDocumentName = (Label)e.Item.FindControl("lblDocumentName");
                HyperLink hLinkDocumentLink = (HyperLink)e.Item.FindControl("hLinkDocumentLink");


                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");


                Ins_InvoiceEnclosedDocument item = dataItem.DataItem as Ins_InvoiceEnclosedDocument;



                lblDocumentName.Text = item.Name;

                hLinkDocumentLink.NavigateUrl = item.Path;
                lnkBtnEdit.CommandArgument = item.IID.ToString();
                lnkBtnEdit.CommandName = "editDocument";
                lnkBtnEdit.Text = "Edit";
            }
        }

        protected void lvDocumentList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editDocument")
            {
                CurrentDocumentID = Convert.ToInt32(e.CommandArgument.ToString());
                LoadDocument();
                

            }
        }

        private void LoadDocument()
        {
            using (TheFacade facade = new TheFacade())
            {
                Ins_InvoiceEnclosedDocument document = facade.InsentiveFacade.GetInvoiceEnclosedDocumentByID(CurrentDocumentID);
                txtDocumentName.Text = document.Name;
            }
        }

        private void LoadInvoiceDetails()
        {
            using (TheFacade facade =new TheFacade())
            {
               Inv_Detail invoiceDetail = facade.InvoiceFacade.GetInvoiceDetailByID(InvoiceDetailId);

                ddlItem.SelectedValue =  invoiceDetail.InsMemberItemId.ToString();
                txtQuantity.Text = invoiceDetail.Quantity.ToString();
                txtUnitPrice.Text = invoiceDetail.UnitPrice.ToString("#.##");
                txtCartonSize.Text= invoiceDetail.CartonSize.ToString();

            }
        }

        
    }
}