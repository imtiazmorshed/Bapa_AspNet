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
using OMS.Facade;
using OMS.DAL;
using OMS.Framework;
using System.Collections.Generic;

namespace OMS.WebClient.UIInventory
{
    public partial class CustomerView : System.Web.UI.Page
    {
        public long CurrentCustomerID
        {
            get
            {
                if (ViewState["CustomerID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CustomerID"]);
                }
            }
            set { ViewState["CustomerID"] = value; }
        }

        public int CurrentBranchID
        {
            get
            {
                if (ViewState["BranchID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["BranchID"]);
                }
            }
            set { ViewState["BranchID"] = value; }
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
                lblMsg.Visible = false;
                if (!IsPostBack)
                {
                    AccessHelper helper = new AccessHelper();
                    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    if (!hasAccess)
                    {
                        Response.Redirect("~/NoPermission.aspx");
                    }
                    if (Convert.ToInt32(Session["RoleID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))//admin
                    {
                        CurrentBranchID = -1;
                    }
                    else
                    {
                        CurrentBranchID = Convert.ToInt32(Session["BranchID"].ToString());

                    }
                    LoadListView();
                    if (Session["IsSaved"] != null)
                    {
                        if (Convert.ToBoolean(Session["IsSaved"]) == true)
                        {
                            ShowMsg("Data successfully saved...");
                        }
                        else
                        {
                            ShowMsg("Data not saved...");
                        }
                    }
                    if (Session["duplicate"] != null)
                    {
                        if (Convert.ToBoolean(Session["duplicate"]) == true)
                        {
                            ShowMsg("Customer name exist...");
                            Session["duplicate"] = null;
                        }
                    }
                }
            }
        }

        private void ShowMsg(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.Visible = true;
            Session["IsSaved"] = null;
        }

        private void LoadListView()
        {
            using (TheFacade facade = new TheFacade())
            {
                //list = list.Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();
                lvSupplier.DataSource = facade.CustomerFacade.GetCustomerAll().Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();
                lvSupplier.DataBind();
            }
        }

        protected void lvSupplier_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Customer customer = new Customer();
                    CurrentCustomerID = Convert.ToInt64(e.CommandArgument.ToString());
                    customer = _facade.CustomerFacade.GetCustomerByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    customer.IsRemoved = 1;
                    _facade.Update<Customer>(customer);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {

                using (TheFacade _facade = new TheFacade())
                {

                    Customer customer = new Customer();
                    CurrentCustomerID = Convert.ToInt64(e.CommandArgument.ToString());
                    customer = _facade.CustomerFacade.GetCustomerByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadCustomer(customer);
                }
            }
        }

        private void LoadCustomer(Customer customer)
        {
            txtSAddress.Text = customer.Address;
            txtSCAddress.Text = customer.ContactPersonAddress;
            txtSCEmail.Text = customer.ContactPersonEmail;
            txtSCMobile.Text = customer.ContactPersonMobile;
            txtSCode.Text = customer.Code;
            txtSContact.Text = customer.ContactPerson;
            txtSCPhone.Text = customer.ContactPersonPhone;
            txtSEmail.Text = customer.Email;
            txtSFax.Text = customer.Fax;
            txtSMobile.Text = customer.Mobile;
            txtSname.Text = customer.Name;
            txtSPhone.Text = customer.Phone;
            txtSWeb.Text = customer.Web;
            txtPassportNo.Text = customer.PassportNo;
            txtNationalID.Text = customer.NationalID;
            string date = customer.DateofBirth.ToString();
            if (date != "")
            {
                txtDateofBirth.Text = Convert.ToDateTime(date).ToShortDateString();
            }
            else
            {
                txtDateofBirth.Text = String.Empty;
            }
        }

        

        //private string GenerateAccountNo(long pid)
        //{
        //    string code = "";
        //    int count = 1;
        //    using (TheFacade facade = new TheFacade())
        //    {

        //        code = "1-";
        //        if (pid <= -1)
        //        {
        //            List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(2).OrderBy(a => a.IID).ToList();
        //            int position = 1;
        //            foreach (Acc_ChartOfAccount acc in acclistAnother)
        //            {

        //                if (acc.IID == pid)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    position++;
        //                }

        //            }

        //            code = code + (position + 1).ToString() + "-" + (1).ToString().PadLeft(4, '0');
        //        }
        //        else
        //        {
        //            List<Acc_ChartOfAccount> acclist = facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(pid);
        //            List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(2).OrderBy(a => a.IID).ToList();
        //            int position = 1;
        //            foreach (Acc_ChartOfAccount acc in acclistAnother)
        //            {

        //                if (acc.IID == pid)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    position++;
        //                }

        //            }

        //            code = code + (position + 1).ToString() + "-" + (acclist.Count + 1).ToString().PadLeft(4, '0');

        //        }
        //    }
        //    //code = code + "";
        //    return code;
        //}
        //int maincounter = 1;
        //private string CountAgain(int count, long parentID)
        //{
        //    string subCOde = "";
        //    List<Acc_ChartOfAccount> acclistNew = new List<Acc_ChartOfAccount>();
        //    int Thecount = 0;
        //    using (TheFacade facade = new TheFacade())
        //    {
        //        acclistNew = facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(parentID);

        //        Thecount = Thecount + acclistNew.Count;


        //    }
        //    maincounter++;
        //    return subCOde = maincounter.ToString() + Thecount.ToString().PadLeft(3, '0');
        //}

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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        private Customer CreateCustomer(Customer customer)
        {
            //Supplier supplier = new Supplier();

            customer.Address = txtSAddress.Text;            
            customer.ContactPerson = txtSContact.Text;
            customer.ContactPersonAddress = txtSCAddress.Text;
            customer.ContactPersonEmail = txtSCEmail.Text;
            customer.ContactPersonMobile = txtSCMobile.Text;
            customer.ContactPersonPhone = txtSCPhone.Text;
            customer.Email = txtSEmail.Text;
            customer.Fax = txtSFax.Text;
            customer.Mobile = txtSMobile.Text;
            customer.Name = txtSname.Text;
            customer.Phone = txtSPhone.Text;
            customer.Web = txtSWeb.Text;
            customer.NationalID = txtNationalID.Text;
            try
            {
                customer.DateofBirth = Convert.ToDateTime(txtDateofBirth.Text);
            }
            catch
            {
                customer.DateofBirth = null;
            }
            customer.PassportNo = txtPassportNo.Text;

            customer.UpdateDate = DateTime.Now;
            customer.UpdateBy = 1;

            if (CurrentCustomerID <= 0)
            {
                customer.Code = Helpers.CommonHelper.GenerateCustomerCode();
                customer.CreateDate = DateTime.Now;
                customer.CreateBy = 1;
            }
            customer.IsRemoved = 0;
            customer.BranchID = Convert.ToInt32(Session["BranchID"]);
            return customer;
        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {

                try
                {
                    if (CurrentCustomerID <= 0)
                    {

                        using (TheFacade facade = new TheFacade())
                        {
                            Customer customerOld = facade.CustomerFacade.GetCustomerByName(txtSname.Text.Trim());
                            if (customerOld == null)
                            {
                                Customer customer = new Customer();
                                customer = CreateCustomer(customer);
                                facade.Insert<Customer>(customer);
                                if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
                                {
                                    if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
                                    {
                                        Acc_ChartOfAccount chartofAcc = facade.AccountsFacade.GetAcc_ChartOfAccountByName("Account Receivable");
                                        Acc_ChartOfAccountCustomer customerAccount = new Acc_ChartOfAccountCustomer();

                                        #region acc
                                        Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                                        newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
                                        newAccount.Name = customer.Name;
                                        newAccount.IsActive = 1;

                                        newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                                        newAccount.ParentID = chartofAcc.IID;
                                        newAccount.Gparent = chartofAcc.Gparent;

                                        newAccount.CreateBy = 1;

                                        newAccount.UpdateBy = 1;


                                        newAccount.CreateDate = DateTime.Now;

                                        newAccount.UpdateDate = DateTime.Now;
                                        newAccount.IsRemoved = 0;
                                        facade.Insert<Acc_ChartOfAccount>(newAccount);

                                        #endregion

                                        customerAccount.ChartOfAccountID = newAccount.IID;
                                        customerAccount.CustomerID = customer.IID;
                                        customerAccount.UpdateDate = DateTime.Now;
                                        customerAccount.UpdateBy = 1;


                                        customerAccount.CreateDate = DateTime.Now;
                                        customerAccount.CreateBy = 1;

                                        customerAccount.IsRemoved = 0;
                                        facade.Insert<Acc_ChartOfAccountCustomer>(customerAccount);
                                    }
                                }
                            }
                            else
                            {
                                Session["duplicate"] = true;
                            }
                        }
                    }
                    else if (CurrentCustomerID > 0)
                    {
                        using (TheFacade facade = new TheFacade())
                        {
                            Customer customerOld = facade.CustomerFacade.GetCustomerByNameAndIID(txtSname.Text.Trim(), CurrentCustomerID);
                            if (customerOld == null)
                            {
                                Customer customer = facade.CustomerFacade.GetCustomerByID(CurrentCustomerID);
                                customer = CreateCustomer(customer);
                                facade.Update<Customer>(customer);
                            }
                            else
                            {
                                Session["duplicate"] = true;
                            }
                        }
                    }
                    Session["IsSaved"] = true;
                }
                catch
                {
                    Session["IsSaved"] = false;
                }
                finally
                {
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                Roles.DeleteCookie();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
        }

        int lvRowCount = 0;
        protected void lvSupplier_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Customer customer = (Customer)((ListViewDataItem)(e.Item)).DataItem;
                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)currentItem.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();

                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");
                Label lblCode = (Label)currentItem.FindControl("lblCode");
                Label lblAddress = (Label)currentItem.FindControl("lblAddress");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkName.Text = customer.Name;
                lnkName.CommandArgument = customer.IID.ToString();
                lnkName.CommandName = "DoEdit";

                lblCode.Text = customer.Code;
                lblAddress.Text = customer.Address;
                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = customer.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = customer.IID.ToString();
            }
        }

        int CurrentPage = 0; 
        protected void dpList_PreRender(object sender, EventArgs e)
        {
            lvRowCount = CurrentPage * 20;
            if (IsPostBack)
                LoadListView();
        }
       

        protected void lvSupplier_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
    }
}
