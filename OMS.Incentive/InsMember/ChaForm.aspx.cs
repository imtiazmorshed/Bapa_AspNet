using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using OMS.Web.Helpers;

namespace OMS.Incentive.InsMember
{
    public partial class ChaForm : System.Web.UI.Page
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

        public long CurrentChaFormID
        {
            get
            {
                if (ViewState["CurrentChaFormID"] == null)
                    return 0;
                else
                    return Convert.ToInt64(ViewState["CurrentChaFormID"]);
            }
            set
            {
                ViewState["CurrentChaFormID"] = value;
            }
        }

        public int CurrentChaFormStatus
        {
            get
            {
                if (ViewState["CurrentChaFormStatus"] == null)
                    return 0;
                else
                    return Convert.ToInt32(ViewState["CurrentChaFormStatus"]);
            }
            set
            {
                ViewState["CurrentChaFormStatus"] = value;
            }
        }

        public bool IsForSubmit
        {
            get
            {
                if (ViewState["IsForSubmit"] == null)
                    return false;
                else
                    return Convert.ToBoolean(ViewState["IsForSubmit"].ToString());
            }
            set
            {
                ViewState["IsForSubmit"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CurrentChaFormID"] != null)
                {
                    CurrentChaFormID = Convert.ToInt64(Request.QueryString["CurrentChaFormID"]);
                }
                Session["InvoiceIds"] = null;

                //if (CurrentChaFormID <= 0)
                //{
                    if (Session["MemberID"] == null)
                    {
                        Session.Abandon();
                        //Response.Redirect("~/Login/login.aspx?returnurl="+Request.Url );
                        Response.Redirect("~/Login/login.aspx");
                    }
                    else
                    {
                        MemberID = Convert.ToInt64(Session["MemberID"].ToString());
                    }
                //}

                //using (TheFacade facade = new TheFacade())
                //{
                //    Ins_ChaForm chaForm = facade.InsentiveFacade.GetChaFormByID(CurrentChaFormID);
                //    MemberID = chaForm.MemberID;
                //}


                if (Request.QueryString["IsForSubmit"] != null)
                    {
                        IsForSubmit = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["IsForSubmit"].ToString()));
                    }
                    lblNowDate.Text = (DateTime.Now).ToString();
                    LoadCurrencyType();
                    LoadInvoice();
                    LoadChaFormDetails();
                    ChangeButtonStatus();
                

            }
        }

        private void ChangeButtonStatus()
        {
            if (IsForSubmit)
            {
                btnSubmited.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnSubmited.Visible = false;
                btnSave.Visible = true;

            }

            if (IsForSubmit)
            {
                
                divInvoiceAdd.Visible = false;
            }
            else
            {
                
                divInvoiceAdd.Visible = true;
            }

            if (CurrentChaFormStatus == (int)EnumCollection.ChaFormStatus.Submited || CurrentChaFormStatus == (int)EnumCollection.ChaFormStatus.ReSubmit || CurrentChaFormStatus == (int)EnumCollection.ChaFormStatus.Approved)
            {
                
                divInvoiceAdd.Visible = false;
            }
        }
        private void LoadCurrencyType()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Currency> currencyTypeList = facade.MemberFacade.GetAllCurrency();

                DDLHelper.Bind<Currency>(ddlCurrencyType, currencyTypeList, "CurrencyCode", "IID", EnumCollection.ListItemType.Currency, true);
            }
        }

        public void LoadChaFormDetails()
        {
            if (CurrentChaFormID <= 0)
            {
                using (TheFacade facade = new TheFacade())
                {
                    Member member = facade.MemberFacade.GetMemberById(MemberID);
                    if (member != null)
                    {
                        txtCompanyName.Text = member.NameBangla;
                        txtAddress.Text = member.AddressBangla;
                    }
                }
            }
            else
            {
                using (TheFacade facade = new TheFacade())
                {
                    Ins_ChaForm chaForm = new Ins_ChaForm();
                    chaForm = facade.InsentiveFacade.GetChaFormByID(CurrentChaFormID);
                    if (chaForm == null)
                        return;//should be shown a message that caanto find the Cha-Form

                    CurrentChaFormStatus = chaForm.Status;
                    txtCompanyName.Text = chaForm.Member.NameBangla;
                    txtAddress.Text = chaForm.Member.AddressBangla;
                    txtAggrementValue.Text = chaForm.ExportValuation.ToString();
                    txtForiegnBuyer.Text = chaForm.ForignCustomerName;
                    txtForignAddress.Text = chaForm.ForignCustomerAddress;
                    txtForiegnBankName.Text = chaForm.ForignCustomerBankName;
                    txtForiegnBankAddress.Text = chaForm.ForignCustomerBankAddress;

                    txtDestinationAddress.Text = chaForm.DestinationPort;
                    txtEXPINumber.Text = chaForm.EKIMPNumber;

                    txtEXPIValue.Text = chaForm.EKIMPAmount.ToString();
                    txtExportProductRate.Text = chaForm.ProposedExportedAmount.ToString();
                    txtExportPriceCertificateNumber.Text = chaForm.ProposedExportedCertificateNo;

                    txtNitFOBValue.Text = chaForm.NetFOBAmount.ToString();
                    //ddlCurrencyType.SelectedValue = member.CurrencyId.ToString();

                    txtEXPINumberDate.Text = chaForm.EKIMPDate.ToString();
                    txtAgrementDate.Text = chaForm.LCDate.ToString();
                    txtShippingDate.Text = chaForm.ShipmentDate.ToString();
                    txtExportPriceCertificateDate.Text = chaForm.ProposedExportedCertificateDate.ToString();

                    //member.MemberID = MemberID;
                    txtAgrementNumber.Text = chaForm.ExportLCNo;

                    //Invoice Loading
                    List<Ins_ChaFormInvoice> chaFormInvoices = facade.InsentiveFacade.GetchaFormInvoiceByChaFormID(chaForm.ID);
                    var invoiceIds = new List<long>();
                    if (Session["InvoiceIds"] != null)
                    {
                        var invoiceIdsFromSession = (List<long>)Session["InvoiceIds"];
                        invoiceIds.AddRange(invoiceIdsFromSession);

                    }
                    foreach (Ins_ChaFormInvoice item in chaFormInvoices)
                    {

                        invoiceIds.Add(item.InvoiceMasterId);
                    }

                    Session["InvoiceIds"] = invoiceIds;

                    LoadItemListView(invoiceIds);

                    //lvItem.DataSource = master;
                    //lvItem.DataBind();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        public void CreateChaForm(Ins_ChaForm chaForm)
        {
            chaForm.MemberID = MemberID;
            chaForm.ExportLCNo = txtAgrementNumber.Text.Trim();
            
            chaForm.ExportValuation = Convert.ToDecimal(txtAggrementValue.Text.Trim());
            chaForm.ForignCustomerName = txtForiegnBuyer.Text.Trim();
            chaForm.ForignCustomerAddress = txtForignAddress.Text.Trim();
            chaForm.ForignCustomerBankName = txtForiegnBankName.Text.Trim();
            chaForm.ForignCustomerBankAddress = txtForiegnBankAddress.Text.Trim();
            
            chaForm.DestinationPort = txtDestinationAddress.Text.Trim();
            chaForm.EKIMPNumber = txtEXPINumber.Text.Trim();
            
            chaForm.EKIMPAmount = Convert.ToDecimal(txtEXPIValue.Text.Trim());
            chaForm.ProposedExportedAmount = Convert.ToDecimal(txtExportProductRate.Text.Trim());
            chaForm.ProposedExportedCertificateNo = txtExportPriceCertificateNumber.Text.Trim();
            
            chaForm.NetFOBAmount = Convert.ToDecimal(txtNitFOBValue.Text.Trim());
            chaForm.CurrencyId = Convert.ToInt32(ddlCurrencyType.SelectedValue);
            chaForm.EKIMPDate = Convert.ToDateTime(txtEXPINumberDate.Text.Trim());
            chaForm.LCDate = Convert.ToDateTime(txtAgrementDate.Text.Trim());
            chaForm.ShipmentDate = Convert.ToDateTime(txtShippingDate.Text.Trim());
            chaForm.ProposedExportedCertificateDate = Convert.ToDateTime(txtExportPriceCertificateDate.Text.Trim());

            if (chaForm.ID <= 0)
            {
                chaForm.UpdateBy = 1;
                chaForm.UpdateDate = DateTime.Now;
            }
            chaForm.CreateBy = 1;
            chaForm.CreateDate = DateTime.Now;
            chaForm.IsRemoved = 0;

             
        }


        public void UpdateChaForm(Ins_ChaForm chaForm)
        {
            chaForm.MemberID = MemberID;
            chaForm.ExportLCNo = txtAgrementNumber.Text.Trim();

            chaForm.ExportValuation = Convert.ToDecimal(txtAggrementValue.Text.Trim());
            chaForm.ForignCustomerName = txtForiegnBuyer.Text.Trim();
            chaForm.ForignCustomerAddress = txtForignAddress.Text.Trim();
            chaForm.ForignCustomerBankName = txtForiegnBankName.Text.Trim();
            chaForm.ForignCustomerBankAddress = txtForiegnBankAddress.Text.Trim();

            chaForm.DestinationPort = txtDestinationAddress.Text.Trim();
            chaForm.EKIMPNumber = txtEXPINumber.Text.Trim();

            chaForm.EKIMPAmount = Convert.ToDecimal(txtEXPIValue.Text.Trim());
            chaForm.ProposedExportedAmount = Convert.ToDecimal(txtExportProductRate.Text.Trim());
            chaForm.ProposedExportedCertificateNo = txtExportPriceCertificateNumber.Text.Trim();

            chaForm.NetFOBAmount = Convert.ToDecimal(txtNitFOBValue.Text.Trim());
            chaForm.CurrencyId = Convert.ToInt32(ddlCurrencyType.SelectedValue);
            chaForm.EKIMPDate = Convert.ToDateTime(txtEXPINumberDate.Text.Trim());
            chaForm.LCDate = Convert.ToDateTime(txtAgrementDate.Text.Trim());
            chaForm.ShipmentDate = Convert.ToDateTime(txtShippingDate.Text.Trim());
            chaForm.ProposedExportedCertificateDate = Convert.ToDateTime(txtExportPriceCertificateDate.Text.Trim());

            if (chaForm.ID <= 0)
            {
                chaForm.UpdateBy = 1;
                chaForm.UpdateDate = DateTime.Now;
            }
            chaForm.CreateBy = 1;
            chaForm.CreateDate = DateTime.Now;
            chaForm.IsRemoved = 0;

        }


        private void LoadInvoice()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Inv_Master> invoiceList = facade.MemberFacade.GetInvoiceByMemberIDForChaForm(MemberID);

                DDLHelper.Bind<Inv_Master>(ddlInvoiceList, invoiceList, "Number", "IID", EnumCollection.ListItemType.Invoice, true);
            }
        }

        protected void lvItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Inv_Master item = (Inv_Master)((ListViewDataItem)(e.Item)).DataItem;

                Label txtInvoiceNumber = (Label)currentItem.FindControl("txtInvoiceNumber");
                Label txtInvoiceDate = (Label)currentItem.FindControl("txtInvoiceDate");
                Label txtInvoiceQuientity = (Label)currentItem.FindControl("txtInvoiceQuientity");
                Label txtInvoiceQuintityValue = (Label)currentItem.FindControl("txtInvoiceQuintityValue");
                Label txtExportProductUsedQuintity = (Label)currentItem.FindControl("txtExportProductUsedQuintity");
                Label txtUsedProductQuantity = (Label)currentItem.FindControl("txtUsedProductQuantity");
                Label txtUsedProductQuantityValue = (Label)currentItem.FindControl("txtUsedProductQuantityValue");
                Label txtSupplierNameAndAddress = (Label) currentItem.FindControl("txtSupplierNameAndAddress");

                LinkButton lnkRemove = (LinkButton)currentItem.FindControl("lnkRemove");
               

                var invoiceItemCount = item.InvoiceDetailList.Select(s => s.Quantity).Count();
                


                txtSupplierNameAndAddress.Text = item.ExportedLocalDistrubuterNameAndAddress;// item.; TODO: ADD this field to DB
                txtInvoiceQuientity.Text = invoiceItemCount.ToString();//item.
                txtInvoiceQuintityValue.Text = item.CurrencyAmount.HasValue? item.CurrencyAmount.Value.ToString("0.00"): string.Empty;

                txtExportProductUsedQuintity.Text = item.ExportedLocalItemQuantity;
                txtUsedProductQuantity.Text = item.ExportedLocalItemQuantity;
                txtUsedProductQuantityValue.Text = Convert.ToInt64(item.ExportedLocalItemAmount).ToString();

                txtInvoiceNumber.Text = Convert.ToInt64(item.IID).ToString();
                txtInvoiceDate.Text = Convert.ToDateTime(item.Date).ToString();



                lnkRemove.CommandName = "removeInvoice";
                lnkRemove.CommandArgument = item.IID.ToString();
                if (IsForSubmit)
                {
                    lnkRemove.Enabled = false;
                    lnkRemove.Visible = false;
                }
                else
                {
                    lnkRemove.Enabled = true;
                    lnkRemove.Visible = true;
                }

                if(CurrentChaFormStatus == (int)EnumCollection.ChaFormStatus.Submited || CurrentChaFormStatus == (int)EnumCollection.ChaFormStatus.ReSubmit || CurrentChaFormStatus == (int)EnumCollection.ChaFormStatus.Approved)
                {
                    lnkRemove.Enabled = false;
                    lnkRemove.Visible = false;
                }
                
            }
        }

        protected void lvItem_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "removeInvoice")
            {
                long invoiceID = Convert.ToInt64(e.CommandArgument.ToString());
                var invoiceIds = new List<long>();

                if (Session["InvoiceIds"] != null)
                {
                    var invoiceIdsFromSession = (List<long>)Session["InvoiceIds"];
                    invoiceIds.AddRange(invoiceIdsFromSession);

                }
                invoiceIds.Remove(invoiceID);
                Session["InvoiceIds"] = invoiceIds;

                LoadItemListView(invoiceIds);
            }

           
        }

        protected void btnInvoiceSave_Click(object sender, EventArgs e)
        {
            //TODO: Declare a list variable and add invoiceIDs to the list. Add List to the session.
            var invoiceIds = new List<long>();

            if (Session["InvoiceIds"] != null)
            {
                var invoiceIdsFromSession =  (List<long>)Session["InvoiceIds"];
                invoiceIds.AddRange(invoiceIdsFromSession);
                
            }

            invoiceIds.Add(Convert.ToInt32(ddlInvoiceList.SelectedValue));

            Session["InvoiceIds"] = invoiceIds;

            LoadItemListView(invoiceIds);
            //ddlInvoiceList.SelectedValue
        }

        private void LoadItemListView(List<long> invoiceIds)
        {
            List<Inv_Master> invoiceList = new List<Inv_Master>();
            using (TheFacade facade = new TheFacade())
            {
                invoiceList = facade.MemberFacade.GetAllInvoiceByIDList(invoiceIds);
            }

            lvItem.DataSource = invoiceList;
            lvItem.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ins_ChaForm chaForm = new Ins_ChaForm();
            using (TheFacade facade = new TheFacade())
            {
                if (CurrentChaFormID > 0)
                {
                    chaForm = facade.InsentiveFacade.GetChaFormByID(CurrentChaFormID);
                }
                CreateChaForm(chaForm);


                if (CurrentChaFormID > 0)
                {
                    facade.Update<Ins_ChaForm>(chaForm);
                }
                else
                {
                    chaForm.Status = Convert.ToInt32(EnumCollection.ChaFormStatus.Draft);
                    facade.Insert<Ins_ChaForm>(chaForm);
                }

                List<Ins_ChaFormInvoice> chaFormInvoices = facade.InsentiveFacade.GetchaFormInvoiceByChaFormID(chaForm.ID);
                //TODO: Get invoiceIds from Session["InvoiceIds"];
                foreach (Ins_ChaFormInvoice item in chaFormInvoices)
                {
                    facade.Delete<Ins_ChaFormInvoice>(item);
                }
                    var invoiceIds = new List<long>();
                //List<Ins_ChaFormInvoice> list = new List<Ins_ChaFormInvoice>();

                if (Session["InvoiceIds"] != null)
                {
                    var invoiceIdsFromSession = (List<long>)Session["InvoiceIds"];
                    invoiceIds.AddRange(invoiceIdsFromSession);

                }

                foreach (var invoiceId in invoiceIds)
                {
                    var chaInvoice = new Ins_ChaFormInvoice();
                    chaInvoice.InvoiceMasterId = invoiceId;
                    chaInvoice.ChaFormId = chaForm.ID;

                    facade.Insert<Ins_ChaFormInvoice>(chaInvoice);
                }




            }
            lblmessage.Text = "Data save successfully";
            lblmessage.Visible = true;


        }

        protected void btnSubmited_Click(object sender, EventArgs e)
        {
            if (CurrentChaFormID > 0)
            {
                using (TheFacade facade = new TheFacade())
                {
                    Ins_ChaForm chaForm = facade.InsentiveFacade.GetChaFormByID(CurrentChaFormID);
                    chaForm.Status = Convert.ToInt32(EnumCollection.ChaFormStatus.Submited);
                    facade.Update<Ins_ChaForm>(chaForm);
                }

                Response.Redirect("~/insMember/MemberChaFormListing.aspx");
            }
        }
    }
}