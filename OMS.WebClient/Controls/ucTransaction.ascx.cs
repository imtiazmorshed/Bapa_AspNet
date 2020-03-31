using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using OMS.DAL;
using OMS.Facade;
using OMS.Web.Helpers;
using OMS.Framework;
using System.IO;

namespace OMS.WebClient.Controls
{
    public partial class ucTransaction : System.Web.UI.UserControl
    {
        public int CurrentTransactionType
        {
            get
            {
                if (ViewState["TransactionTypeID"] == null)
                    return -1;
                else
                    return Convert.ToInt32(ViewState["TransactionTypeID"].ToString());
            }
            set
            {
                ViewState["TransactionTypeID"] = value;
            }
        }

        public long CurrentTransactionMasterID
        {
            get
            {
                if (ViewState["TransactionMasterID"] == null)
                    return -1;
                else
                    return Convert.ToInt64(ViewState["TransactionMasterID"].ToString());
            }
            set
            {
                ViewState["TransactionMasterID"] = value;
            }
        }

        public DataTable dtDetail;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["DetailTable"] = dtDetail;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("../Login.aspx?" + "&msgSessionOut=1");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadDDL();
                    dvChequePayment.Visible = false;
                    dvChequeReceipt.Visible = false;
                    dvChequeDate.Visible = false;
                    CreateGridTable();
                    //ViewState["DetailTable"] = dtDetail;

                    string page = this.Parent.BindingContainer.Page.ToString();
                    CurrentTransactionType = LoadTransactionType(page);
                    VoucherListShowHide(false);
                    //LoadTransactionMasterListView();
                }
                else
                {
                    dtDetail = (DataTable)ViewState["DetailTable"];
                }
                //legendMain.te
            }
        }

        #region DDL

        private void LoadDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                //List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                //DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank, true);
                //List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchAll();
                //DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                //List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountAll();
                //DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                //List<Acc_ChequeLeaf> chequeLeafList = facade.AccountsFacade.GetChequeLeafAll(Convert.ToInt32(EnumCollection.ChequeLeafStatus.UnUsed));
                //DDLHelper.Bind<Acc_ChequeLeaf>(ddlChequeLeaf, chequeLeafList, "LeafNumber", "IID", EnumCollection.ListItemType.Select, true);

                List<ReferenceType> ReferenceTypeList = new List<ReferenceType>();
                ReferenceTypeList = facade.AccountsFacade.GetReferenceAll();
                DDLHelper.Bind<ReferenceType>(ddlReferenceType, ReferenceTypeList, "Name", "IID", EnumCollection.ListItemType.ReferenceType);
                ddlReferenceType.SelectedIndex = -1;

                DDLHelper.Bind(ddlTransactionStatus, EnumHelper.EnumToList<EnumCollection.TransactionStatus>());//, EnumCollection.ListItemType.TransactionMode);

                DDLHelper.Bind(ddlTransactionMode, EnumHelper.EnumToList<EnumCollection.TransactionMode>(), EnumCollection.ListItemType.TransactionMode);
                ddlTransactionMode.SelectedIndex = -1;

                List<Supplier> SupplierList = new List<Supplier>();
                SupplierList = facade.CustomerFacade.GetSupplierAll();
                DDLHelper.Bind<Supplier>(ddlSupplier, SupplierList, "Name", "IID", EnumCollection.ListItemType.Supplier);
                ddlSupplier.SelectedIndex = -1;

                List<Customer> CustomerList = new List<Customer>();

                CustomerList = facade.CustomerFacade.GetCustomerAll();
                DDLHelper.Bind<Customer>(ddlCustomer, CustomerList, "Name", "IID", EnumCollection.ListItemType.Customer);
                ddlCustomer.SelectedIndex = -1;

                List<Acc_ChartOfAccount> chatList = new List<Acc_ChartOfAccount>();
                chatList = facade.AccountsFacade.GetAcc_ChartOfAccountTransactableAll();
                DDLHelper.Bind<Acc_ChartOfAccount>(ddlAccount, chatList, "Name", "IID", EnumCollection.ListItemType.AccountType);
            }
        }
        
        private void LoadBankDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank, true);
                List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchAll();
                DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountAll();
                DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                List<Acc_ChequeLeaf> chequeLeafList = facade.AccountsFacade.GetChequeLeafAll(Convert.ToInt32(EnumCollection.ChequeLeafStatus.UnUsed));
                DDLHelper.Bind<Acc_ChequeLeaf>(ddlChequeLeaf, chequeLeafList, "LeafNumber", "IID", EnumCollection.ListItemType.Select, true);
            }
        }

        private void LoadAccount()
        {
            List<Acc_ChartOfAccount> chatList = new List<Acc_ChartOfAccount>();
            using (TheFacade _facade = new TheFacade())
            {
                chatList = _facade.AccountsFacade.GetAcc_ChartOfAccountTransactableAll();
            }
            DDLHelper.Bind<Acc_ChartOfAccount>(ddlAccount, chatList, "Name", "IID", EnumCollection.ListItemType.AccountType);
        }

        private void LoadReferenceType()
        {
            List<ReferenceType> ReferenceTypeList = new List<ReferenceType>();
            using (TheFacade _facade = new TheFacade())
            {
                ReferenceTypeList = _facade.AccountsFacade.GetReferenceAll();
            }
            DDLHelper.Bind<ReferenceType>(ddlReferenceType, ReferenceTypeList, "Name", "IID", EnumCollection.ListItemType.ReferenceType);
            ddlReferenceType.SelectedIndex = -1;
        }

        private void LoadTransactionStatus()
        {
            DDLHelper.Bind(ddlTransactionStatus, EnumHelper.EnumToList<EnumCollection.TransactionStatus>());//, EnumCollection.ListItemType.TransactionMode);
        }

        private void LoadTransactionMode()
        {
            DDLHelper.Bind(ddlTransactionMode, EnumHelper.EnumToList<EnumCollection.TransactionMode>(), EnumCollection.ListItemType.TransactionMode);
            ddlTransactionMode.SelectedIndex = -1;
            //ddlTransactionMode.Enabled = false;

        }

        private void LoadSupplier()
        {
            List<Supplier> SupplierList = new List<Supplier>();
            using (TheFacade _facade = new TheFacade())
            {
                SupplierList = _facade.CustomerFacade.GetSupplierAll();
            }
            //int i = ddlReferenceID.Items.Count;
            //while (ddlReferenceID.Items.Count != 0)
            //{
            //    ddlReferenceID.Items.Remove(ddlReferenceID.Items[i - 1]);
            //    i--;
            //}
            DDLHelper.Bind<Supplier>(ddlSupplier, SupplierList, "Name", "IID", EnumCollection.ListItemType.Supplier);
            ddlSupplier.SelectedIndex = -1;
        }

        private void LoadCustomer()
        {
            List<Customer> CustomerList = new List<Customer>();
            using (TheFacade _facade = new TheFacade())
            {
                CustomerList = _facade.CustomerFacade.GetCustomerAll();
            }
            //int i = ddlReferenceID.Items.Count;
            //while (ddlReferenceID.Items.Count != 0)
            //{
            //    ddlReferenceID.Items.Remove(ddlReferenceID.Items[i - 1]);
            //    i--;
            //}
            DDLHelper.Bind<Customer>(ddlCustomer, CustomerList, "Name", "IID", EnumCollection.ListItemType.Customer);
            ddlCustomer.SelectedIndex = -1;
        }

        #endregion

        private void CreateGridTable()
        {
            dtDetail = new DataTable();
            dtDetail.Columns.Add(new DataColumn("AccountID", typeof(Int64)));
            dtDetail.Columns.Add(new DataColumn("Account", typeof(string)));
            dtDetail.Columns.Add(new DataColumn("Particulars", typeof(string)));
            dtDetail.Columns.Add(new DataColumn("Debit", typeof(decimal)));
            dtDetail.Columns.Add(new DataColumn("Credit", typeof(decimal)));
            dtDetail.Columns.Add(new DataColumn("IsDebit", typeof(bool)));
            dtDetail.Columns.Add(new DataColumn("IsCredit", typeof(bool)));
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Acc_TransactionMaster master = new Acc_TransactionMaster();

            //if (master.ReferenceID != null)
            //{
            if (gvTransactionDetails.Rows.Count > 0)
            {
                if (BalanceCalculation() == 0)
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        if (CurrentTransactionMasterID <= 0)
                        {
                            master = CrtateTransaction(master, 0);
                            _facade.Insert<Acc_TransactionMaster>(master);

                            Acc_TransactionMaster transactionMasterUpdate = new Acc_TransactionMaster();
                            CurrentTransactionMasterID = master.IID;
                            transactionMasterUpdate = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(CurrentTransactionMasterID);

                            if (fuMap.HasFile && transactionMasterUpdate.IID > 0)
                                transactionMasterUpdate.TransactionReference = SaveFile(fuMap, transactionMasterUpdate.IID);

                            _facade.Update(transactionMasterUpdate);
                        }
                        else
                        {
                            master = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(CurrentTransactionMasterID);
                            master = CrtateTransaction(master, 0);
                            _facade.Update<Acc_TransactionMaster>(master);
                            List<Acc_TransactionDetail> detailList = new List<Acc_TransactionDetail>();
                            detailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(master.IID, Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted));
                            if (detailList.Count > 0)
                            {
                                foreach (Acc_TransactionDetail detail in detailList)
                                {
                                    detail.IsRemoved = 1;
                                    _facade.Update<Acc_TransactionDetail>(detail);
                                }
                            }
                        }
                        decimal amount = 0;
                        if (master.IID > 0)
                        {
                            for (int i = 0; i < dtDetail.Rows.Count; i++)
                            {
                                Acc_TransactionDetail details = new Acc_TransactionDetail();
                                details.TransactionMasterID = master.IID;
                                details.AccountID = Convert.ToInt64(dtDetail.Rows[i].ItemArray[0].ToString());
                                if (Convert.ToBoolean(dtDetail.Rows[i].ItemArray[5].ToString()))
                                {
                                    details.Amount = Convert.ToDecimal(dtDetail.Rows[i].ItemArray[3].ToString());
                                    amount += details.Amount;
                                    details.TransactionNature = 1;
                                }
                                else
                                {
                                    details.Amount = Convert.ToDecimal(dtDetail.Rows[i].ItemArray[4].ToString());
                                    details.TransactionNature = 2;
                                }
                                details.Particulars = dtDetail.Rows[i].ItemArray[2].ToString();

                                details.CreateBy = Convert.ToInt64(Session["UserID"]);
                                details.CreateDate = DateTime.Now;
                                details.UpdateBy = Convert.ToInt64(Session["UserID"]);
                                details.UpdateDate = DateTime.Now;
                                details.IsRemoved = 0;
                                details.BranchID = Convert.ToInt32(Session["BranchID"]);
                                _facade.Insert<Acc_TransactionDetail>(details);

                            }


                            if (ddlTransactionMode.SelectedValue == "2")
                            {

                                Acc_BankTransaction bankTransaction = new Acc_BankTransaction();
                                bankTransaction = LoadBankTransaction(bankTransaction, master.IID, amount);
                                if (CurrentTransactionType == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                                {
                                    bankTransaction.ChequeLeafID = Convert.ToInt64(ddlChequeLeaf.SelectedValue);

                                    Acc_ChequeLeaf chequeLeaf = new Acc_ChequeLeaf();
                                    chequeLeaf = _facade.AccountsFacade.GetChequeLeafByIID(Convert.ToInt64(ddlChequeLeaf.SelectedValue));
                                    chequeLeaf.Status = Convert.ToInt32(EnumCollection.ChequeLeafStatus.Issued);
                                    _facade.Update<Acc_ChequeLeaf>(chequeLeaf);
                                }
                                else
                                {
                                    bankTransaction.BankName = txtBankName.Text;
                                    bankTransaction.BranchName = txtBranchName.Text;
                                    bankTransaction.BankAccount = txtBankAccount.Text;
                                    bankTransaction.ChequeLeafNumber = txtChequeLeafNo.Text;
                                }

                                _facade.Insert<Acc_BankTransaction>(bankTransaction);
                            }

                        }
                        lblMsgAll.Text = "Data Saved Successfully";
                        lblMsgAll.ForeColor = System.Drawing.Color.Red;
                        CurrentTransactionMasterID = 0;
                        ClearControl();
                        //string data = string.Format("<script language=javascript>window.open('rptVoucher.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "transactionMasterID=" + master.IID.ToString());
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                        //Page.RegisterStartupScript("Print Voucher", data);

                        string data = string.Format("<script language=javascript>window.open('rptVoucher.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "transactionMasterID=" + master.IID.ToString());
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                        ViewState["DetailTable"] = null;
                        dtDetail = null;
                    }
                }
                else
                {
                    lblMsgAll.Text = "Debit and Credit Ammount must be equal";
                    lblMsgAll.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsgAll.Text = "Details Information missing";
                lblMsgAll.ForeColor = System.Drawing.Color.Red;
            }
            //}
            //else
            //{
            //    lblMsgAll.Text = "Please Select Reference According your Reference Type";
            //    lblMsgAll.ForeColor = System.Drawing.Color.Red;
            //}
            VoucherListShowHide(false);
            LoadTransactionMasterListView();
            //Response.Redirect("~/UIAccount/VoucherTransactionFrom.aspx");
        }

        private Acc_BankTransaction LoadBankTransaction(Acc_BankTransaction bankTransaction, long transactionMasterID, decimal amount)
        {
            bankTransaction.TransactionMasterID = transactionMasterID;
            bankTransaction.ReferenceType = CurrentTransactionType;  
            bankTransaction.Amount = amount;
            if (bankTransaction.IID <= 0)
            {
                bankTransaction.CreateBy = Convert.ToInt64(Session["UserID"]);
                bankTransaction.CreateDate = DateTime.Now;
            }
            bankTransaction.UpdateBy = Convert.ToInt64(Session["UserID"]);
            bankTransaction.UpdateDate = DateTime.Now;
            bankTransaction.IsRemoved = 0;
            bankTransaction.ChequeDate = Convert.ToDateTime(txtChequeDate.Text);
            bankTransaction.BranchID = Convert.ToInt32(Session["BranchID"]);
            return bankTransaction;
        }

        private void ClearControl()
        {
            txtTransactionDate.Text = string.Empty;
            txtToFrom.Text = string.Empty;
            txtToFromName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtParticulars.Text = string.Empty;
            txtPayReason.Text = string.Empty;

            ddlReferenceType.SelectedIndex = -1;
            ddlReferenceType_SelectedIndexChanged(null, null);

            ddlTransactionMode.SelectedIndex = -1;
            ddlTransactionMode_SelectedIndexChanged(null, null);
            
            ddlBank.SelectedIndex = -1;
            ddlBank_SelectedIndexChanged(null, null);
            
            ddlBranch.SelectedIndex = -1;
            ddlBranch_SelectedIndexChanged(null, null);
            
            ddlAccountName.SelectedIndex = -1;
            ddlAccountName_SelectedIndexChanged(null, null);
            
            ddlChequeLeaf.SelectedIndex = -1;
            
            lvTransaction.DataSource = null;
            lvTransaction.DataBind();

            gvTransactionDetails.DataSource = null;
            gvTransactionDetails.DataBind();

            dvChequePayment.Visible = false;
            dvChequeReceipt.Visible = false;
            dvChequeDate.Visible = false;

        }

        private Acc_TransactionMaster CrtateTransaction(Acc_TransactionMaster master,int IsEditorDelete)
        {
            //Acc_TransactionMaster master = new Acc_TransactionMaster();

            //if (IsEditorDelete != 0)
            //{
            //    master.IID = Convert.ToInt64(hdTransactionID.Value.ToString());
            //}
            if (CurrentTransactionMasterID > 0)
            {
                master.IID = CurrentTransactionMasterID;

            }

            string time = Convert.ToString(DateTime.Now.TimeOfDay);

            master.TransactionDate = Convert.ToDateTime(txtTransactionDate.Text + " " + time);

            string page = this.Parent.BindingContainer.Page.ToString();



            
            master.Particulars = txtParticulars.Text;
            master.PayReason = txtPayReason.Text;
            master.ReferenceType = Convert.ToInt32(ddlReferenceType.SelectedValue);

            if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
            {
                master.ReferenceID = Convert.ToInt64(ddlCustomer.SelectedValue);                
            }
            else if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
            {
                master.ReferenceID = Convert.ToInt64(ddlSupplier.SelectedValue);
            }
            else
            {
                master.ReferenceID = -1;
            }
           
            master.Status = Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted);
            master.ToFrom = txtToFrom.Text;
            master.ToFromAddress = txtAddress.Text;
            master.ToFromName = txtToFromName.Text;
            master.TransactionModeID = Convert.ToInt32(ddlTransactionMode.SelectedValue);
            master.TransactionReference = "N/A";
            master.TransactionTypeID =CurrentTransactionType;

            master.UpdateBy = Convert.ToInt64(Session["UserID"]);
            master.UpdateDate = DateTime.Now;
            if (CurrentTransactionMasterID <= 0)
            {
                master.JournalCode = CreateJurnalCode(page, master.TransactionDate);
                master.CreateBy = Convert.ToInt64(Session["UserID"]);
                master.CreateDate = DateTime.Now;
            }
            if (IsEditorDelete == 3)
            {
                master.IsRemoved = 1;
            }
            else
            {
                master.IsRemoved = 0;
            }
            master.BranchID = Convert.ToInt32(Session["BranchID"]);
            if (fuMap.HasFile && master.IID >0)
                master.TransactionReference = SaveFile(fuMap, master.IID);

            return master;
        }

        private string SaveFile(FileUpload fuTender, long masterID)
        {
            string pathMap = string.Empty;
            if (fuMap.HasFile)
            {
                try
                {
                    pathMap = CreateMapPath(fuMap, masterID);
                    string saveLocH = Request.PhysicalApplicationPath + pathMap;
                    if (File.Exists(saveLocH))
                        File.Delete(saveLocH);
                    fuMap.SaveAs(saveLocH);




                }
                catch (Exception ex)
                {
                    
                }
            }

            return pathMap;
        }

        private string CreateMapPath(FileUpload fuMap, long masterID)
        {
            string pathMap = string.Empty;

            pathMap = ConfigurationManager.AppSettings["UploadedReferenceLocation"].ToString() + masterID + "/" + fuMap.FileName;

            if (!Directory.Exists(Request.PhysicalApplicationPath + pathMap.Substring(0, pathMap.LastIndexOf('/'))))
            {
                Directory.CreateDirectory(Request.PhysicalApplicationPath + pathMap.Substring(0, pathMap.LastIndexOf('/')));
            }


            pathMap = pathMap.Replace("\\", "/");

            return pathMap;
        }

        protected void lvTransaction_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteTransactionMaster")
            {
                using (TheFacade _facade = new TheFacade())
                {


                    Acc_TransactionMaster master = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(Convert.ToInt64(e.CommandArgument));
                    if (master.IID > 0)
                    {
                        try
                        {
                            List<Acc_TransactionDetail> detailList = new List<Acc_TransactionDetail>();
                            detailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(master.IID, Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted));
                            if (detailList.Count > 0)
                            {
                                foreach (Acc_TransactionDetail detail in detailList)
                                {
                                    detail.IsRemoved = 1;
                                    _facade.Update<Acc_TransactionDetail>(detail);
                                }
                            }

                            master.IsRemoved = 1;
                            _facade.Update<Acc_TransactionMaster>(master);
                            lblMsgAll.Text = "Data Deleted Successfully";
                            LoadTransactionMasterListView();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }
            }
            else if (e.CommandName == "PrintReport")
            {
                Acc_TransactionMaster acc_TransactionMaster = new Acc_TransactionMaster();
                Int64 transactionMasterID = Convert.ToInt64(e.CommandArgument);
                using (TheFacade _facade = new TheFacade())
                {
                    acc_TransactionMaster = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(transactionMasterID);
                    if (acc_TransactionMaster.IID > 0) // && Convert.ToInt32(ddlTransactionStatus.SelectedValue)>0)
                    {
                        string data = string.Format("<script language=javascript>window.open('rptVoucher.aspx?{0}{1}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "transactionMasterID=" + acc_TransactionMaster.IID.ToString(), "&status=" + Convert.ToInt32(ddlTransactionStatus.SelectedValue));
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                    }
                }
            }
            else
            {
                lblMsgAll.Text = string.Empty;
                using (TheFacade _facade = new TheFacade())
                {
                    Acc_TransactionMaster master = new Acc_TransactionMaster();

                    master = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentTransactionMasterID = master.IID;
                    FillTransactionMaster(master);

                    List<Acc_TransactionDetail> detailsList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(master.IID, master.Status);
                    CreateGridTable();
                    foreach (Acc_TransactionDetail details in detailsList)
                    {
                        DataRow row = dtDetail.NewRow();
                        row["AccountID"] = details.AccountID;
                        row["Account"] = details.Acc_ChartOfAccount.Name;
                        row["Particulars"] = details.Particulars;
                        if (details.TransactionNature == 1)
                        {
                            row["Debit"] = details.Amount;
                            row["Credit"] = 0;
                            row["IsDebit"] = true;
                            row["IsCredit"] = false;
                        }
                        else
                        {
                            row["Debit"] = 0;
                            row["Credit"] = details.Amount;
                            row["IsDebit"] = false;
                            row["IsCredit"] = true;
                        }
                        dtDetail.Rows.Add(row);
                    }
                    gvTransactionDetails.DataSource = dtDetail;
                    gvTransactionDetails.DataBind();
                }
            }
        }

        private void FillTransactionMaster(Acc_TransactionMaster master)
        {
            txtTransactionDate.Text = master.TransactionDate.ToShortDateString();
            ddlReferenceType.SelectedValue = master.ReferenceType.ToString();
            ddlReferenceType_SelectedIndexChanged(null, null);
            if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
            {
                ddlCustomer.SelectedValue = master.ReferenceID.ToString();
            }
            else if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
            {
                ddlSupplier.SelectedValue = master.ReferenceID.ToString();
            }
            else
            {
 
            }
            txtToFrom.Text = master.ToFrom;
            txtToFromName.Text = master.ToFromName;
            txtAddress.Text = master.ToFromAddress;
            txtParticulars.Text = master.Particulars;
            txtPayReason.Text = master.PayReason;
            ddlTransactionMode.SelectedValue = master.TransactionModeID.ToString();
        }

        protected void lvTransaction_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_TransactionMaster master = (Acc_TransactionMaster)((ListViewDataItem)(e.Item)).DataItem;
                Label lblDate = (Label)currentItem.FindControl("lblDate");
                Label lblJurnalCode = (Label)currentItem.FindControl("lblJurnalCode");
                Label lblPayReason = (Label)currentItem.FindControl("lblPayReason");
                LinkButton lnkbtnPrint = (LinkButton)currentItem.FindControl("lnkbtnPrint");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");                
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");
                
                lblDate.Text = master.TransactionDate.ToShortDateString();                
                lblJurnalCode.Text = master.JournalCode;
                lblPayReason.Text = master.PayReason;

                lnkbtnPrint.CommandArgument = master.IID.ToString();
                lnkbtnPrint.CommandName = "PrintReport";

                lnkEdit.CommandArgument = master.IID.ToString();
                lnkEdit.CommandName = "LoadTransactionMaster";

                lnkDelete.CommandArgument = master.IID.ToString();
                lnkDelete.CommandName = "DeleteTransactionMaster";


                
            }
        }

        protected void dpTransaction_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactionMasterListView();
            }
        }


        private string CreateJurnalCode(string page,DateTime date)
        {
            string code = string.Empty;
            int number = 0;
            string day = string.Empty;
            string month = "";
            string newCode = string.Empty;
            string branchName = Session["BranchName"].ToString();
            branchName = branchName.Substring(0, 3);
            newCode += "-" + branchName + "-";

            using (TheFacade _facade = new TheFacade())
            {
                day = GetDate(date, day);
                month = GetMonth(date, month);

                switch (page)
                {
                    case "ASP.uiaccount_paymenttransactionview_aspx":
                                               
                        //code = "CD" + date.Year.ToString().Substring(2, 2) + month + date.Day.ToString() + "9";
                        code = "CD"+ newCode + date.Year.ToString().Substring(2, 2) + month + day + "9";
                        number = _facade.AccountsFacade.GetJurnalNumber("CD-" +branchName, date);
                        if (number <= 8)
                        {
                            code = code + "00" + (number + 1);
                        }
                        else if (number <= 98)
                        {
                            code = code + "0" + (number + 1);
                        }
                        else if (number > 98)
                        {
                            code = code + (number + 1);
                        }
                        break;

                    case "ASP.uiaccount_receivetransactionview_aspx":
                        
                        //code = "CR" + date.Year.ToString().Substring(2, 2) + month + date.Day.ToString() + "9";
                        code = "CR" + newCode + date.Year.ToString().Substring(2, 2) + month + day+ "9";
                        number = _facade.AccountsFacade.GetJurnalNumber("CR-" + branchName, date);
                        if (number <= 8)
                        {
                            code = code + "00" + (number + 1);
                        }
                        else if (number <= 98)
                        {
                            code = code + "0" + (number + 1);
                        }
                        else if (number > 98)
                        {
                            code = code + (number + 1);
                        }
                        break;

                    case "ASP.uiaccount_vouchertransactionfrom_aspx":
                        
                        //code = "JV" + date.Year.ToString().Substring(2, 2) + month + date.Day.ToString() + "9";
                        code = "JV" + newCode + date.Year.ToString().Substring(2, 2) + month + day+ "9";
                        number = _facade.AccountsFacade.GetJurnalNumber("Jv-" + branchName, date);
                        if (number <= 8)
                        {
                            code = code + "00" + (number + 1);
                        }
                        else if (number <= 98)
                        {
                            code = code + "0" + (number + 1);
                        }
                        else if (number > 98)
                        {
                            code = code + (number + 1);
                        }
                        break;
                    default:
                        code = "";
                        break;
                }
            }
            return code;
        }

        private static string GetDate(DateTime date, string day)
        {
            if (date.Day <= 9)
            {
                day = "0" + date.Day.ToString();
            }
            else
            {
                day = date.Day.ToString();
            }
            return day;
        }

        private static string GetMonth(DateTime date, string month)
        {
            if (date.Month <= 9)
            {
                month = "0" + date.Month.ToString();
            }
            else
            {
                month = date.Month.ToString();
            }
            return month;
        }


        private int LoadTransactionType(string page)
        {
            int type = 0;
            switch (page)
            {
                case "ASP.uiaccount_paymenttransactionview_aspx":
                    type = 1;
                    lblTransactionType.Text = "Transaction[Payment Voucher]";
                    break;
                case "ASP.uiaccount_receivetransactionview_aspx":
                    type = 2;
                    lblTransactionType.Text = "Transaction[Receive Voucher]";
                    break;
                case "ASP.uiaccount_vouchertransactionfrom_aspx":
                    type = 3;
                    lblTransactionType.Text = "Transaction[Journal Voucher]";
                    break;
                default:
                    type = 0;
                    break;
            }
            return type;
        }

        private void LoadTransactionMasterListView()
        {
            List<Acc_TransactionMaster> masterList = new List<Acc_TransactionMaster>();
            using (TheFacade _facade = new TheFacade())
            {
                masterList = _facade.AccountsFacade.GetAcc_TransactionMasterListView(Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted));
                masterList = masterList.Where(tm => tm.TransactionTypeID == CurrentTransactionType).ToList();
                lvTransaction.DataSource = masterList;
                lvTransaction.DataBind();
            }
        }

        private void LoadTransactionMasterListView(int status, DateTime fromDate, DateTime toDate)
        {
            List<Acc_TransactionMaster> masterList = new List<Acc_TransactionMaster>();
            using (TheFacade _facade = new TheFacade())
            {
                masterList = _facade.AccountsFacade.GetAcc_TransactionMasterListViewByParam(status, fromDate, toDate).OrderByDescending(ac => ac.TransactionDate).ToList();
                masterList = masterList.Where(tm => tm.TransactionTypeID == CurrentTransactionType).ToList();
                lvTransaction.DataSource = masterList;
                lvTransaction.DataBind();
            }
        }

        #region Transaction Details

        protected void gvTransactionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblDetailsErrorMsg.Text = "";
            if (e.CommandName == "DoDelete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int noOfRows = dtDetail.Rows.Count;
                dtDetail.Rows.RemoveAt(index);
                gvTransactionDetails.DataSource = dtDetail;
                gvTransactionDetails.DataBind();
            }
        }

        protected void gvTransactionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int index = Convert.ToInt32(e.Row.DataItemIndex);

                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                btnDelete.CommandArgument = Convert.ToString(index);
                e.Row.Attributes["onmouseover"] =
                    "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] =
                    "javascript:setMouseOutColor(this);";

            }
        }

        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            if (dtDetail == null)
            {
                CreateGridTable();
               
            }
            AddNewGridRow();
            
        }

        private void AddNewGridRow()
        {
            if (dtDetail.Rows.Count == 0)
            {
                if (txtDebit.Text == string.Empty || txtCredit.Text == string.Empty)
                {
                    if (ddlAccount.SelectedValue != "-1")
                    {
                        AddToGrid();
                    }
                    else
                    {
                        lblDetailsErrorMsg.Text = "Please Select Account to Add";
                    }
                }
                else
                {
                    lblDetailsErrorMsg.Text = "You have to enter Debit or Credit once at a time";
                }
            }
            else
            {
                if (txtDebit.Text == string.Empty || txtCredit.Text == string.Empty)
                {
                    if (ddlAccount.SelectedValue != "-1")
                    {
                        int numofDebit = 0;
                        int numofCredit = 0;
                        decimal DebitAmount = 0;
                        decimal CreditAmount = 0;
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dtDetail.Rows[i].ItemArray[5].ToString()))
                            {
                                numofDebit++;
                            }
                            else
                            {
                                numofCredit++;
                            }
                        }

                        if (numofDebit <= 1 && txtDebit.Text == string.Empty)
                        {
                            AddToGrid();
                        }
                        else if (numofCredit <= 1 && txtCredit.Text == string.Empty)
                        {
                            AddToGrid();
                        }

                        //SHUVO
                        else if (numofDebit <= 100 && txtDebit.Text == string.Empty)
                        {
                            AddToGrid();
                        }
                        else if (numofCredit <= 100 && txtCredit.Text == string.Empty)
                        {
                            AddToGrid();
                        }
                        //SHUVO

                        else
                        {
                            lblDetailsErrorMsg.Text = "Either Debit or Cridit input must be single";
                        }
                    }
                    else
                    {
                        lblDetailsErrorMsg.Text = "Please Select Account to Add";
                    }
                }
                else
                {
                    lblDetailsErrorMsg.Text = "You have to enter Debit or Credit once at a time";
                }
            }
        }

        private void AddToGrid()
        {

            DataRow row = dtDetail.NewRow();

            row["AccountID"] = ddlAccount.SelectedValue;
            using (TheFacade _facade = new TheFacade())
            {
                Acc_ChartOfAccount cacc = _facade.AccountsFacade.GetAcc_ChartOfAccountByID(Convert.ToInt64(ddlAccount.SelectedValue));
                //row["Account"] = ddlProductName.SelectedItem.Value;
                row["Account"] = cacc.Name;
            }
            row["Particulars"] = txtParticularsDetails.Text;
            if (txtDebit.Text != string.Empty)
            {
                row["Debit"] = Convert.ToDecimal(txtDebit.Text);
                row["IsDebit"] = true;
            }
            else
            {
                row["Debit"] = 0;
                row["IsDebit"] = false;
            }
            if (txtCredit.Text != string.Empty)
            {
                row["Credit"] = Convert.ToDecimal(txtCredit.Text);
                row["IsCredit"] = true;
            }
            else
            {
                row["Credit"] = 0;
                row["IsCredit"] = false;
            }
            dtDetail.Rows.Add(row);
            gvTransactionDetails.DataSource = dtDetail;
            gvTransactionDetails.DataBind();

            ddlAccount.SelectedValue = "-1";
            txtParticularsDetails.Text = "";
            txtDebit.Text = "";
            txtCredit.Text = "";

            decimal DrCrBalance = BalanceCalculation();
            lblDrCrBalanceMsg.Text = "Difference between Debit and Credit: " + DrCrBalance.ToString();
        }

        private decimal BalanceCalculation()
        {
            decimal DebitAmount = 0;
            decimal CreditAmount = 0;
            decimal DrCrBalance = 0;

            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtDetail.Rows[i].ItemArray[5].ToString()))
                {
                    DebitAmount = DebitAmount + Convert.ToDecimal(dtDetail.Rows[i].ItemArray[3].ToString());
                }
                else
                {
                    CreditAmount = CreditAmount + Convert.ToDecimal(dtDetail.Rows[i].ItemArray[4].ToString());
                }
            }
            if (DebitAmount > CreditAmount)
            {
                DrCrBalance = DebitAmount - CreditAmount;
            }
            else
            {
                DrCrBalance = CreditAmount - DebitAmount;
            }
            return DrCrBalance;
        }

        

        #endregion


        #region new logic
        private string GenerateAccountNo(string gParent)
        {
            string code = "";

            code = gParent;
            int count = 0;
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(gParent)).OrderBy(a => a.IID).ToList();
                count = acclistAnother.Count + 1;
                code = code + count.ToString().PadLeft(5, '0');
            }
            return code;
        }
        #endregion

        #region Reference Type (Customer & Suppler) 

        //protected void btnSaveCustomer_Click(object sender, EventArgs e)
        //{
        //    Customer customer= CreateCustomer();
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        if (txtCName.Text != string.Empty && txtCCode.Text!=string.Empty)
        //        {
        //            List<Customer> custList = _facade.CustomerFacade.GetCustomerByNameAndCode(txtCName.Text, txtCCode.Text);
        //            if (custList.Count == 0)
        //            {
        //                Customer customerOld = _facade.CustomerFacade.GetCustomerByName(txtSname.Text.Trim());
        //                if (customerOld == null)
        //                {
        //                    _facade.Insert<Customer>(customer);
                            
        //                    if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
        //                    {
        //                        if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
        //                        {
        //                            Acc_ChartOfAccount chartofAcc = _facade.AccountsFacade.GetAcc_ChartOfAccountByName("Account Receivable");
        //                            Acc_ChartOfAccountCustomer customerAccount = new Acc_ChartOfAccountCustomer();

        //                            #region acc
        //                            Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
        //                            newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
        //                            newAccount.Name = customer.Name;
        //                            newAccount.IsActive = 1;

        //                            newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
        //                            newAccount.ParentID = chartofAcc.IID;
        //                            newAccount.Gparent = chartofAcc.Gparent;

        //                            newAccount.CreateBy = Convert.ToInt64(Session["uid"]);

        //                            newAccount.UpdateBy = Convert.ToInt64(Session["uid"]);


        //                            newAccount.CreateDate = DateTime.Now;

        //                            newAccount.UpdateDate = DateTime.Now;
        //                            newAccount.IsRemoved = 0;
        //                            _facade.Insert<Acc_ChartOfAccount>(newAccount);

        //                            #endregion

        //                            customerAccount.ChartOfAccountID = newAccount.IID;
        //                            customerAccount.CustomerID = customer.IID;
        //                            customerAccount.UpdateDate = DateTime.Now;
        //                            customerAccount.UpdateBy = Convert.ToInt64(Session["uid"]);


        //                            customerAccount.CreateDate = DateTime.Now;
        //                            customerAccount.CreateBy = Convert.ToInt64(Session["uid"]);

        //                            customerAccount.IsRemoved = 0;
        //                            _facade.Insert<Acc_ChartOfAccountCustomer>(customerAccount);
        //                        }
        //                        ddlAccount.Items.Clear();
        //                        LoadAccount();
        //                    }
        //                }
        //                if (customer.IID > 0)
        //                {
        //                    LoadCustomer();
        //                    dvCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                    ddlCustomer.SelectedValue = customer.IID.ToString();
        //                }
        //                else
        //                {
        //                    faceboxCustomer.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        //                    faceboxCustomer.Style.Add(HtmlTextWriterStyle.Top, "240px");
        //                    faceboxCustomer.Style.Add(HtmlTextWriterStyle.Left, "500px");
        //                    faceboxCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                    dvCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                }
        //            }
        //            else
        //            {
        //                lblCMsg.Text = "Same Customer Already Exists";
        //                faceboxCustomer.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        //                faceboxCustomer.Style.Add(HtmlTextWriterStyle.Top, "240px");
        //                faceboxCustomer.Style.Add(HtmlTextWriterStyle.Left, "500px");
        //                faceboxCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                dvCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //            }
        //        }
        //        else
        //        {
        //            lblCMsg.Text = "Please Enter Customer Name and Code";
        //            faceboxCustomer.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        //            faceboxCustomer.Style.Add(HtmlTextWriterStyle.Top, "240px");
        //            faceboxCustomer.Style.Add(HtmlTextWriterStyle.Left, "500px");
        //            faceboxCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //            dvCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        //        }
        //    }
        //}

        //private Customer CreateCustomer()
        //{
        //    Customer customer = new Customer();

        //    customer.Address = txtCAddress.Text;
        //    customer.Code = txtCCode.Text;
        //    customer.ContactPerson = txtCContactPerson.Text;
        //    customer.ContactPersonAddress = txtCContactAddress.Text;
        //    customer.ContactPersonEmail = txtCContactEmail.Text;
        //    customer.ContactPersonMobile = txtCContactMobile.Text;
        //    customer.ContactPersonPhone = txtCContactPhone.Text;
        //    customer.Email = txtCEmail.Text;
        //    customer.Fax = txtCFax.Text;
        //    customer.Mobile = txtCMobile.Text;
        //    customer.Name = txtCName.Text;
        //    customer.Phone = txtCPhone.Text;
        //    customer.Web = txtCWeb.Text;

        //    customer.UpdateDate = DateTime.Now;
        //    customer.UpdateBy = Convert.ToInt64(Session["uid"]);
        //    customer.CreateDate = DateTime.Now;
        //    customer.CreateBy = Convert.ToInt64(Session["uid"]);
        //    customer.IsRemoved = 0;

        //    return customer;
        //}

        //protected void lnkbtnSaveSupplier_Click(object sender, EventArgs e)
        //{
        //    Supplier supplier = CreateSupplier();
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        if (txtSname.Text != string.Empty && txtSCode.Text != string.Empty)
        //        {
        //            List<Supplier> supptList = _facade.CustomerFacade.GetSupplierByNameAndCode(txtSname.Text, txtSCode.Text);
        //            if (supptList.Count == 0)
        //            {
        //                Supplier supplierOld = _facade.CustomerFacade.GetSupplierByName(txtSname.Text.Trim());
        //                if (supplierOld == null)
        //                {
                            


        //                    _facade.Insert<Supplier>(supplier);
                           
        //                    if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
        //                    {
        //                        if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
        //                        {
        //                            Acc_ChartOfAccount chartofAcc = _facade.AccountsFacade.GetAcc_ChartOfAccountByName("Account Payable");

        //                            #region acc
        //                            Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
        //                            newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
        //                            newAccount.Name = supplier.Name;
        //                            newAccount.IsActive = 1;

        //                            newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
        //                            newAccount.ParentID = chartofAcc.IID;
        //                            newAccount.Gparent = chartofAcc.Gparent;

        //                            newAccount.CreateBy = Convert.ToInt64(Session["uid"]);

        //                            newAccount.UpdateBy = Convert.ToInt64(Session["uid"]);


        //                            newAccount.CreateDate = DateTime.Now;

        //                            newAccount.UpdateDate = DateTime.Now;
        //                            newAccount.IsRemoved = 0;
        //                            _facade.Insert<Acc_ChartOfAccount>(newAccount);

        //                            #endregion


        //                            Acc_ChartOfAccountSupplier supplierAccount = new Acc_ChartOfAccountSupplier();
        //                            supplierAccount.ChartOfAccountID = newAccount.IID;
        //                            supplierAccount.SupplierID = supplier.IID;
        //                            supplierAccount.UpdateDate = DateTime.Now;
        //                            supplierAccount.UpdateBy = Convert.ToInt64(Session["uid"]);


        //                            supplierAccount.CreateDate = DateTime.Now;
        //                            supplierAccount.CreateBy = Convert.ToInt64(Session["uid"]);

        //                            supplierAccount.IsRemoved = 0;
        //                            _facade.Insert<Acc_ChartOfAccountSupplier>(supplierAccount);
        //                        }
        //                        ddlAccount.Items.Clear();
        //                        LoadAccount();
        //                    }
        //                }
        //                if (supplier.IID > 0)
        //                {
        //                    LoadSupplier();
        //                    dvSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                    ddlSupplier.SelectedValue = supplier.IID.ToString();
        //                }
        //                else
        //                {
        //                    faceboxSupplier.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        //                    faceboxSupplier.Style.Add(HtmlTextWriterStyle.Top, "240px");
        //                    faceboxSupplier.Style.Add(HtmlTextWriterStyle.Left, "500px");
        //                    faceboxSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                    dvSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                }
        //            }
        //            else
        //            {
        //                lblCMsg.Text = "Same Supplier Already Exists";
        //                faceboxSupplier.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        //                faceboxSupplier.Style.Add(HtmlTextWriterStyle.Top, "240px");
        //                faceboxSupplier.Style.Add(HtmlTextWriterStyle.Left, "500px");
        //                faceboxSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //                dvSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //            }
        //        }
        //        else
        //        {
        //            lblCMsg.Text = "Please Enter Supplier Name and Code";
        //            faceboxSupplier.Style.Add(HtmlTextWriterStyle.Position, "absolute");
        //            faceboxSupplier.Style.Add(HtmlTextWriterStyle.Top, "240px");
        //            faceboxSupplier.Style.Add(HtmlTextWriterStyle.Left, "500px");
        //            faceboxSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //            dvSupplier.Style.Add(HtmlTextWriterStyle.Display, "block");
        //        }
        //    }
        //}

        //private Supplier CreateSupplier()
        //{
        //    Supplier supplier = new Supplier();

        //    supplier.Address = txtSAddress.Text;
        //    supplier.Code = txtSCode.Text;
        //    supplier.ContactPerson = txtSContact.Text;
        //    supplier.ContactPersonAddress = txtSCAddress.Text;
        //    supplier.ContactPersonEmail = txtSCEmail.Text;
        //    supplier.ContactPersonMobile = txtSCMobile.Text;
        //    supplier.ContactPersonPhone = txtSCPhone.Text;
        //    supplier.Email = txtSEmail.Text;
        //    supplier.Fax = txtSFax.Text;
        //    supplier.Mobile = txtSMobile.Text;
        //    supplier.Name = txtSname.Text;
        //    supplier.Phone = txtSPhone.Text;
        //    supplier.Web = txtSWeb.Text;

        //    supplier.UpdateDate = DateTime.Now;
        //    supplier.UpdateBy = Convert.ToInt64(Session["uid"]);
        //    supplier.CreateDate = DateTime.Now;
        //    supplier.CreateBy = Convert.ToInt64(Session["uid"]);
        //    supplier.IsRemoved = 0;

        //    return supplier;
        //}

        #endregion

        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UIAccount/PaymentTransactionView.aspx");
        }

        protected void ddlReferenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReferenceType.SelectedValue == "1")
            {
                dvSupplier.Visible = true;
                dvCustomer.Visible = false;
                //LoadSupplier();
            }
            else if (ddlReferenceType.SelectedValue == "2")
            {
                dvSupplier.Visible = false;
                dvCustomer.Visible = true;
                //LoadCustomer();
            }
            else
            {
                dvSupplier.Visible = false;
                dvCustomer.Visible = false;
            }
        }

        protected void ddlTransactionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTransactionMode.SelectedValue != "")
            {
                int mode = Convert.ToInt32(ddlTransactionMode.SelectedValue);
                if (CurrentTransactionType == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                {
                    
                    switch (mode)
                    {
                        case 2:
                            dvChequePayment.Visible = true;
                            dvChequeReceipt.Visible = false;
                            dvChequeDate.Visible = true;
                            LoadBankDDL();
                            break;
                        default:
                            dvChequePayment.Visible = false;
                            dvChequeReceipt.Visible = false;
                            dvChequeDate.Visible = false;
                            break;
                    }

                }
                else
                {
                    switch (mode)
                    {
                        case 2:
                            dvChequePayment.Visible = false;
                            dvChequeReceipt.Visible = true;
                            dvChequeDate.Visible = true;
                            break;
                        default:
                            dvChequePayment.Visible = false;
                            dvChequeReceipt.Visible = false;
                            dvChequeDate.Visible = false;
                            break;
                    }

                }
            }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue != "-1" && ddlBank.SelectedValue != "")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlBranch.Items.Clear();
                    ddlAccountName.Items.Clear();
                    ddlChequeLeaf.Items.Clear();
                    List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchByBankID(Convert.ToInt64(ddlBank.SelectedValue));
                    DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "-1" && ddlBranch.SelectedValue != "")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlAccountName.Items.Clear();
                    ddlChequeLeaf.Items.Clear();
                    List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountByBranchID(Convert.ToInt64(ddlBranch.SelectedValue));
                    DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void ddlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccountName.SelectedValue != "-1" && ddlAccountName.SelectedValue != "")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlChequeLeaf.Items.Clear();
                    List<Acc_ChequeLeaf> chequeLeafList = facade.AccountsFacade.GetChequeLeafByBankAccountID(Convert.ToInt32(EnumCollection.ChequeLeafStatus.UnUsed), Convert.ToInt64(ddlAccountName.SelectedValue));
                    DDLHelper.Bind<Acc_ChequeLeaf>(ddlChequeLeaf, chequeLeafList, "LeafNumber", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            try
            {
                fromDate = Convert.ToDateTime(txtFromDate.Text + " 12:00:00 AM");
                toDate = Convert.ToDateTime(txtToDate.Text + " 11:59:59 PM");
                //fromDate = Convert.ToDateTime(txtFromDate.Text);
                //toDate = Convert.ToDateTime(txtToDate.Text);
            }
            catch (Exception)
            {
                fromDate = DateTime.MinValue;
                toDate = DateTime.MinValue;
            }
            //if (string.IsNullOrEmpty(txtFromDate.Text) && string.IsNullOrEmpty(txtToDate.Text))
            //    LoadTransactionMasterListView();
            //else
            if (ddlTransactionStatus.SelectedValue != null)// && (!string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text)))
            {
                LoadTransactionMasterListView(Convert.ToInt32(ddlTransactionStatus.SelectedValue), fromDate, toDate);
            }
            else
            {
                LoadTransactionMasterListView();
            }
        }

        protected void btnSearchShow_Click(object sender, EventArgs e)
        {
            if (btnSearchShow.Text == "Show Voucher")
            {
                VoucherListShowHide(true);
                btnSearchShow.Text = "Hide Voucher";
            }
            else
            {
                VoucherListShowHide(false);
                btnSearchShow.Text = "Show Voucher";
            }
        }

        private void VoucherListShowHide(bool value)
        {
            dvSearchVoucher.Visible = value;
            dvVoucherList.Visible = value;
        }

    }
}