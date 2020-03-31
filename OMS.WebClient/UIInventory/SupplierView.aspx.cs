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
using OMS.Web.Helpers;

namespace OMS.WebClient.UIInventory
{
    public partial class SupplierView : System.Web.UI.Page
    {
        public long CurrentSupplierID
        {
            get
            {
                if (ViewState["SupplierID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["SupplierID"]);
                }
            }
            set { ViewState["SupplierID"] = value; }
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
                    //LoadDDL();
                    //LoadTicketClassListView();
                    AccessHelper helper = new AccessHelper();
                    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    if (!hasAccess)
                    {
                        Response.Redirect("~/NoPermission.aspx");
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
                            ShowMsg("Supplier name exist...");
                            Session["duplicate"] = null;
                        }
                    }
                }
            }
        }

        private void LoadTicketClassListView()
        {
            List<TicketClass> ticketClassList = new List<TicketClass>();
            using (TheFacade _facade = new TheFacade())
            {
                ticketClassList = _facade.TicketSaleFacade.GetTicketClassAll();
                lvTicketClass.DataSource = ticketClassList;
                lvTicketClass.DataBind();
            }
        }

        //private void LoadDDL()
        //{
        //    DDLHelper.Bind(ddlAirlinesType, EnumHelper.EnumToList<EnumCollection.AirlinesType>(),EnumCollection.ListItemType.Select);//, EnumCollection.ListItemType.TransactionMode);
        //}

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
                lvSupplier.DataSource = facade.CustomerFacade.GetSupplierAll();
                lvSupplier.DataBind();
            }
        }

        protected void lvSupplier_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Supplier supplier = new Supplier();
                    CurrentSupplierID = Convert.ToInt64(e.CommandArgument.ToString());
                    supplier = _facade.CustomerFacade.GetSupplierByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    supplier.IsRemoved = 1;
                    _facade.Update<Supplier>(supplier);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Supplier supplier = new Supplier();
                    CurrentSupplierID = Convert.ToInt64(e.CommandArgument.ToString());
                    supplier = _facade.CustomerFacade.GetSupplierByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    List<AirlinesCommission> airComList = new List<AirlinesCommission>();
                    if (supplier.AirlinesType == Convert.ToInt32(EnumCollection.AirlinesType.IATA))
                    {
                        List<TicketClass> ticketClassList = new List<TicketClass>();
                        List<TicketClass> ticketClassListNew = new List<TicketClass>();
                        ticketClassList = _facade.TicketSaleFacade.GetTicketClassAll();

                        foreach (TicketClass tc in ticketClassList)
                        {
                            AirlinesCommission ac = _facade.TicketSaleFacade.GetAirlinesCommission(supplier.IID, tc.IID);
                            if (ac != null)
                            {
                                tc.AirlinesCommissionSingle = ac;
                            }
                        }
                        //airComList = _facade.TicketSaleFacade.GetAirlinesCommissionList(supplier.IID);
                        //ticketClassList = new List<TicketClass>();
                        //foreach (AirlinesCommission ac in airComList)
                        //{
                        //    TicketClass tc = ac.TicketClass;
                        //    tc.AirlinesCommissionSingle = ac;

                        //    ticketClassList.Add(tc);
                        //}
                        if (ticketClassList.Count > 0)
                        {
                            lvTicketClass.DataSource = ticketClassList;
                            lvTicketClass.DataBind();
                        }
                        else
                        {
                            LoadTicketClassListView();
                        }
                    }
                    else
                    {
                        lvTicketClass.DataSource = null;
                        lvTicketClass.DataBind();
                    }

                    LoadSupplier(supplier);
                }
            }
        }

        private void LoadSupplier(Supplier supplier)
        {
            txtSAddress.Text = supplier.Address;
            txtSCAddress.Text = supplier.ContactPersonAddress;
            txtSCEmail.Text = supplier.ContactPersonEmail;
            txtSCMobile.Text = supplier.ContactPersonMobile;
            txtSCode.Text = supplier.Code;
            txtSContact.Text = supplier.ContactPerson;
            txtSCPhone.Text = supplier.ContactPersonPhone;
            txtSEmail.Text = supplier.Email;
            txtSFax.Text = supplier.Fax;
            txtSMobile.Text = supplier.Mobile;
            txtSname.Text = supplier.Name;
            txtSPhone.Text = supplier.Phone;
            txtSWeb.Text = supplier.Web;
            //ddlAirlinesType.SelectedValue = supplier.AirlinesType.ToString();
            //if (airCom.NormalCommission != null)
            //    txtNormalCommission.Text = airCom.NormalCommission.ToString();
            //else
            //    txtNormalCommission.Text = "0";
            //if (airCom.ExcessCommission != null)
            //    txtExcessCommission.Text = airCom.ExcessCommission.ToString();
            

        }

        protected void lvTicketClass_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                TicketClass ticketClass = (TicketClass)((ListViewDataItem)(e.Item)).DataItem;
                
                Label lblTicketClass = (Label)currentItem.FindControl("lblTicketClass");
                Label lblNormalCommission = (Label)currentItem.FindControl("lblNormalCommission");
                DropDownList ddlAmountType1 = (DropDownList)currentItem.FindControl("ddlAmountType1");
                TextBox txtAmount1 = (TextBox)currentItem.FindControl("txtAmount1");

                Label lblExcessCommission = (Label)currentItem.FindControl("lblExcessCommission");
                DropDownList ddlAmountType2 = (DropDownList)currentItem.FindControl("ddlAmountType2");
                TextBox txtAmount2 = (TextBox)currentItem.FindControl("txtAmount2");
                
                lblTicketClass.Text = ticketClass.Name;                
                DDLHelper.Bind(ddlAmountType1, EnumHelper.EnumToList<EnumCollection.AmountType>(), EnumCollection.ListItemType.Select);
                DDLHelper.Bind(ddlAmountType2, EnumHelper.EnumToList<EnumCollection.AmountType>(), EnumCollection.ListItemType.Select);
                if (ticketClass.AirlinesCommissionSingle != null)
                {
                    if (ticketClass.AirlinesCommissionSingle.NormalCommission != null)
                    {
                        txtAmount1.Text = ticketClass.AirlinesCommissionSingle.NormalCommission.ToString();
                        ddlAmountType1.SelectedValue = ticketClass.AirlinesCommissionSingle.NormalCommissionType.ToString();
                    }
                    if (ticketClass.AirlinesCommissionSingle.ExcessCommission != null)
                    {
                        txtAmount2.Text = ticketClass.AirlinesCommissionSingle.ExcessCommission.ToString();
                        ddlAmountType2.SelectedValue = ticketClass.AirlinesCommissionSingle.ExcessCommissionType.ToString();
                    }
                }
                else
                {
                    txtAmount1.Text = "0";
                    txtAmount2.Text = "0";
                }
                lblTicketClass.ToolTip = ticketClass.IID.ToString();
            }
        }

        protected void lvTicketClass_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //if (e.CommandName == "DoDelete")
            //{

            //    using (TheFacade _facade = new TheFacade())
            //    {
            //        Supplier supplier = new Supplier();
            //        CurrentSupplierID = Convert.ToInt64(e.CommandArgument.ToString());
            //        supplier = _facade.CustomerFacade.GetSupplierByIID(Convert.ToInt64(e.CommandArgument.ToString()));
            //        supplier.IsRemoved = 1;
            //        _facade.Update<Supplier>(supplier);
            //        Response.Redirect(Request.Url.ToString());
            //    }
            //}

            //else if (e.CommandName == "DoEdit")
            //{

            //    using (TheFacade _facade = new TheFacade())
            //    {

            //        Supplier supplier = new Supplier();
            //        CurrentSupplierID = Convert.ToInt64(e.CommandArgument.ToString());
            //        supplier = _facade.CustomerFacade.GetSupplierByIID(Convert.ToInt64(e.CommandArgument.ToString()));

            //        AirlinesCommission airCom = new AirlinesCommission();
            //        airCom = _facade.TicketSaleFacade.GetAirlinesCommission(supplier.IID);

            //        LoadSupplier(supplier, airCom);
            //    }
            //}
        }


        //private string GenerateAccountNo(long pid)
        //{
        //    string code = "";
        //    int count = 1;
        //    using (TheFacade facade = new TheFacade())
        //    {

        //        code =  "2-";
        //         if (pid <= -1)
        //        {
        //            List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(2).OrderBy(a => a.IID).ToList();
        //            int position = 1;
        //            foreach (Acc_ChartOfAccount acc in acclistAnother)
        //            {

        //                if (acc.IID ==pid)
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
        //        List<Acc_ChartOfAccount> acclist = facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(pid);
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

        protected void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {
                try
                {
                    if (CurrentSupplierID <= 0)
                    {

                        using (TheFacade facade = new TheFacade())
                        {
                            Supplier supplierOld = facade.CustomerFacade.GetSupplierByName(txtSname.Text.Trim());
                            if (supplierOld == null)
                            {
                                AirlinesCommission airCom = new AirlinesCommission();
                                Supplier supplier = new Supplier();  
                                supplier = CreateSupplier(supplier);
                                facade.Insert<Supplier>(supplier);
                                
                                //Commission

                                if (supplier.IID > 0)
                                {
                                    for (int i = 0; i < lvTicketClass.Items.Count; i++)
                                    {
                                        ListViewDataItem currentItem = (ListViewDataItem)lvTicketClass.Items[i];
                                        
                                        TicketClass ticketClass = new TicketClass();
                                        
                                        Label lblTicketClass = (Label)currentItem.FindControl("lblTicketClass");
                                        Label lblNormalCommission = (Label)currentItem.FindControl("lblNormalCommission");
                                        DropDownList ddlAmountType1 = (DropDownList)currentItem.FindControl("ddlAmountType1");
                                        TextBox txtAmount1 = (TextBox)currentItem.FindControl("txtAmount1");

                                        Label lblExcessCommission = (Label)currentItem.FindControl("lblExcessCommission");
                                        DropDownList ddlAmountType2 = (DropDownList)currentItem.FindControl("ddlAmountType2");
                                        TextBox txtAmount2 = (TextBox)currentItem.FindControl("txtAmount2");
                                        ticketClass = facade.TicketSaleFacade.GetTicketClassByID(Convert.ToInt32(lblTicketClass.ToolTip));
                                        airCom = new AirlinesCommission();
                                        if (Convert.ToDecimal(txtAmount1.Text) > 0)
                                        {
                                            airCom.SupplierID = supplier.IID;
                                            airCom.TicketClassID = ticketClass.IID;
                                            if (Convert.ToDecimal(txtAmount1.Text) > 0)
                                            {
                                                if (ddlAmountType1.SelectedValue != "-1")
                                                {
                                                    airCom.NormalCommissionType = Convert.ToInt32(ddlAmountType1.SelectedValue);
                                                    airCom.NormalCommission = Convert.ToDecimal(txtAmount1.Text);
                                                }
                                            }
                                            if (Convert.ToDecimal(txtAmount2.Text) > 0)
                                            {
                                                if (ddlAmountType2.SelectedValue != "-1")
                                                {
                                                    airCom.ExcessCommissionType = Convert.ToInt32(ddlAmountType2.SelectedValue);
                                                    airCom.ExcessCommission = Convert.ToDecimal(txtAmount2.Text);
                                                }
                                            }
                                            airCom.IsActive = true;
                                            if (airCom.IID <= 0)
                                            {
                                                airCom.CreateBy = Convert.ToInt64(Session["UserID"]);
                                                airCom.CreateDate = DateTime.Now;
                                            }
                                            airCom.UpdateBy = Convert.ToInt64(Session["UserID"]);
                                            airCom.UpdateDate = DateTime.Now;
                                            airCom.IsRemoved = 0;

                                            //airCom = LoadAirCom(airCom, supplier);
                                            facade.Insert<AirlinesCommission>(airCom);
                                        }
                                    }
                                }                                

                                if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
                                {
                                    if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
                                    {
                                        Acc_ChartOfAccount chartofAcc = facade.AccountsFacade.GetAcc_ChartOfAccountByName("Account Payable");

                                        #region acc
                                        Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                                        newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
                                        newAccount.Name = supplier.Name;
                                        newAccount.IsActive = 1;

                                        newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                                        newAccount.ParentID = chartofAcc.IID;
                                        newAccount.Gparent = chartofAcc.Gparent;

                                        newAccount.CreateBy = Convert.ToInt64(Session["uid"]);

                                        newAccount.UpdateBy = Convert.ToInt64(Session["uid"]);


                                        newAccount.CreateDate = DateTime.Now;

                                        newAccount.UpdateDate = DateTime.Now;
                                        newAccount.IsRemoved = 0;
                                        facade.Insert<Acc_ChartOfAccount>(newAccount);

                                        #endregion


                                        Acc_ChartOfAccountSupplier supplierAccount = new Acc_ChartOfAccountSupplier();
                                        supplierAccount.ChartOfAccountID = newAccount.IID;
                                        supplierAccount.SupplierID = supplier.IID;
                                        supplierAccount.UpdateDate = DateTime.Now;
                                        supplierAccount.UpdateBy = Convert.ToInt64(Session["UserID"]);


                                        supplierAccount.CreateDate = DateTime.Now;
                                        supplierAccount.CreateBy = Convert.ToInt64(Session["UserID"]);

                                        supplierAccount.IsRemoved = 0;
                                        facade.Insert<Acc_ChartOfAccountSupplier>(supplierAccount);
                                    }
                                }
                            }
                            else
                            {
                                Session["duplicate"] = true;
                            }
                        }
                    }
                    else if (CurrentSupplierID > 0)
                    {
                        using (TheFacade facade = new TheFacade())
                        {
                            AirlinesCommission airCom = new AirlinesCommission();
                            Supplier supplierOld = facade.CustomerFacade.GetSupplierByNameAndIID(txtSname.Text.Trim(), CurrentSupplierID);
                            if (supplierOld == null)
                            {
                                Supplier supplier = facade.CustomerFacade.GetSupplierByIID(CurrentSupplierID);
                                string supplierName = supplier.Name;
                                supplier = CreateSupplier(supplier);
                                facade.Update<Supplier>(supplier);

                                //Commission
                                if (supplier.IID > 0)
                                {
                                    for (int i = 0; i < lvTicketClass.Items.Count; i++)
                                    {
                                        ListViewDataItem currentItem = (ListViewDataItem)lvTicketClass.Items[i];

                                        TicketClass ticketClass = new TicketClass();

                                        Label lblTicketClass = (Label)currentItem.FindControl("lblTicketClass");
                                        Label lblNormalCommission = (Label)currentItem.FindControl("lblNormalCommission");
                                        DropDownList ddlAmountType1 = (DropDownList)currentItem.FindControl("ddlAmountType1");
                                        TextBox txtAmount1 = (TextBox)currentItem.FindControl("txtAmount1");

                                        Label lblExcessCommission = (Label)currentItem.FindControl("lblExcessCommission");
                                        DropDownList ddlAmountType2 = (DropDownList)currentItem.FindControl("ddlAmountType2");
                                        TextBox txtAmount2 = (TextBox)currentItem.FindControl("txtAmount2");
                                        ticketClass = facade.TicketSaleFacade.GetTicketClassByID(Convert.ToInt32(lblTicketClass.ToolTip));
                                        airCom = new AirlinesCommission();
                                        airCom = facade.TicketSaleFacade.GetAirlinesCommission(supplier.IID,ticketClass.IID);
                                        if (airCom != null)
                                        {
                                            airCom.IsActive = false;
                                            facade.Update<AirlinesCommission>(airCom);
                                        }
                                        airCom = new AirlinesCommission();
                                        if (Convert.ToDecimal(txtAmount1.Text) > 0)
                                        {
                                            airCom.SupplierID = supplier.IID;
                                            airCom.TicketClassID = ticketClass.IID;
                                            if (Convert.ToDecimal(txtAmount1.Text) > 0)
                                            {
                                                if (ddlAmountType1.SelectedValue != "-1")
                                                {
                                                    airCom.NormalCommissionType = Convert.ToInt32(ddlAmountType1.SelectedValue);
                                                    airCom.NormalCommission = Convert.ToDecimal(txtAmount1.Text);
                                                }
                                            }
                                            if (Convert.ToDecimal(txtAmount2.Text) > 0)
                                            {
                                                if (ddlAmountType2.SelectedValue != "-1")
                                                {
                                                    airCom.ExcessCommissionType = Convert.ToInt32(ddlAmountType2.SelectedValue);
                                                    airCom.ExcessCommission = Convert.ToDecimal(txtAmount2.Text);
                                                }
                                            }
                                            airCom.IsActive = true;
                                            if (airCom.IID <= 0)
                                            {
                                                airCom.CreateBy = Convert.ToInt64(Session["UserID"]);
                                                airCom.CreateDate = DateTime.Now;
                                            }
                                            airCom.UpdateBy = Convert.ToInt64(Session["UserID"]);
                                            airCom.UpdateDate = DateTime.Now;
                                            airCom.IsRemoved = 0;

                                            //airCom = LoadAirCom(airCom, supplier);
                                            facade.Insert<AirlinesCommission>(airCom);
                                        }
                                    }
                                    //Accounts
                                    if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
                                    {
                                        if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
                                        {
                                            Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                                            newAccount = facade.AccountsFacade.GetAcc_ChartOfAccountByName(supplierName);
                                            if (newAccount.IID > 0)
                                            {
                                                #region acc

                                                newAccount.Name = supplier.Name;
                                                newAccount.UpdateBy = Convert.ToInt64(Session["uid"]);
                                                newAccount.UpdateDate = DateTime.Now;

                                                facade.Update<Acc_ChartOfAccount>(newAccount);

                                                #endregion
                                            }
                                        }
                                    }
                                }                             

                                //airCom = facade.TicketSaleFacade.GetAirlinesCommission(supplier.IID);
                                //airCom.IsActive = false;
                                //facade.Update<AirlinesCommission>(airCom);
                                //airCom = new AirlinesCommission();
                                //airCom = LoadAirCom(airCom, supplier);
                                //facade.Insert<AirlinesCommission>(airCom);

                                
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

       
        private AirlinesCommission LoadAirCom(AirlinesCommission airCom, Supplier supplier)
        {
            airCom.SupplierID = supplier.IID;
            
            //if (!string.IsNullOrEmpty(txtNormalCommission.Text))
            //    airCom.NormalCommission = Convert.ToDecimal(txtNormalCommission.Text);
            //else
            //    airCom.NormalCommission = 0;
            //if(!string.IsNullOrEmpty(txtExcessCommission.Text))
            //    airCom.ExcessCommission= Convert.ToDecimal(txtExcessCommission.Text);
            
            airCom.IsActive= true;
            if (airCom.IID <= 0)
            {
                airCom.CreateBy = Convert.ToInt64(Session["UserID"]);
                airCom.CreateDate = DateTime.Now;
            }
            airCom.UpdateBy = Convert.ToInt64(Session["UserID"]);
            airCom.UpdateDate = DateTime.Now;
            airCom.IsRemoved = 0;

            return airCom;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        private Supplier CreateSupplier(Supplier supplier)
        {
            //Supplier supplier = new Supplier();

            supplier.Address = txtSAddress.Text;
            
            
            
            supplier.ContactPerson = txtSContact.Text;
            supplier.ContactPersonAddress = txtSCAddress.Text;
            supplier.ContactPersonEmail = txtSCEmail.Text;
            supplier.ContactPersonMobile = txtSCMobile.Text;
            supplier.ContactPersonPhone = txtSCPhone.Text;
            supplier.Email = txtSEmail.Text;
            supplier.Fax = txtSFax.Text;
            supplier.Mobile = txtSMobile.Text;
            supplier.Name = txtSname.Text;
            supplier.Phone = txtSPhone.Text;
            supplier.Web = txtSWeb.Text;
            supplier.UpdateDate = DateTime.Now;
            supplier.UpdateBy = Convert.ToInt64(Session["UserID"]);

            if (CurrentSupplierID <= 0)
            {
                supplier.Code = Helpers.CommonHelper.GenerateSupplierCode();
                supplier.CreateDate = DateTime.Now;
                supplier.CreateBy = Convert.ToInt64(Session["UserID"]);
            }
            supplier.IsRemoved = 0;
            supplier.SupplierType = Convert.ToInt32(EnumCollection.SupplierType.Airlines);
            //supplier.AirlinesType = Convert.ToInt32(ddlAirlinesType.SelectedValue);
            supplier.AirlinesType = 2;
            return supplier;
        }

        //protected void ddlAirlinesType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlAirlinesType.SelectedValue != "-1")
        //    {
        //        if (CurrentSupplierID <= 0)
        //        {
        //            if (Convert.ToInt32(ddlAirlinesType.SelectedValue) == Convert.ToInt32(EnumCollection.AirlinesType.IATA))
        //            {
        //                LoadTicketClassListView();
        //            }
        //            else
        //            {
        //                lvTicketClass.DataSource = null;
        //                lvTicketClass.DataBind();
        //            }
        //        }
        //    }
        //}

        int lvRowCount = 0;
        protected void lvSupplier_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Supplier supplier = (Supplier)((ListViewDataItem)(e.Item)).DataItem;
                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)currentItem.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();
                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");
                Label lblCode = (Label)currentItem.FindControl("lblCode");
                Label lblAddress = (Label)currentItem.FindControl("lblAddress");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkName.Text = supplier.Name;
                lnkName.CommandArgument = supplier.IID.ToString();
                lnkName.CommandName = "DoEdit";

                lblCode.Text = supplier.Code;
                lblAddress.Text = supplier.Address;
                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = supplier.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = supplier.IID.ToString();
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
