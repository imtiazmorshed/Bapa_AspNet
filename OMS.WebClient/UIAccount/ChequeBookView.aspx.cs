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
using System.Collections.Generic;
using OMS.Framework;
using OMS.Web.Helpers;
using OMS.WebClient.Helpers;

namespace OMS.WebClient.UIAccount
{
    public partial class ChequeBookView : System.Web.UI.Page
    {
        public long CurrentCheckBookID
        {
            get
            {
                if (ViewState["CheckBookID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CheckBookID"]);
                }
            }
            set { ViewState["CheckBookID"] = value; }
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
                    if (Convert.ToInt32(Session["RoleID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))//admin
                    {
                        CurrentBranchID = -1;
                    }
                    else
                    {
                        CurrentBranchID = Convert.ToInt32(Session["BranchID"].ToString());
                    }
                    AccessHelper helper = new AccessHelper();
                    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    if (!hasAccess)
                    {
                        Response.Redirect("~/NoPermission.aspx");
                    }

                    LoadListView();
                    LoadDDL();
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
                }
            }
        }

        private void LoadDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank, true);

                List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchAll().Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);

                List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountAll().Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
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
                lvCheckBook.DataSource = facade.AccountsFacade.GetChequeBookAll().Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                lvCheckBook.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //List<Acc_ChequeLeaf> leafList = new List<Acc_ChequeLeaf>();
            //using(TheFacade facade= new TheFacade())
            //{
            //    leafList = facade.AccountsFacade.GetChequeLeafByCriteria(Convert.ToInt64(txtStartLeafNumber.Text.Trim()), (Convert.ToInt64(txtStartLeafNumber.Text.Trim()) + Convert.ToInt64(txtNumberofLeaf.Text.Trim()))-1);
            //}
            //if (leafList.Count == 0)
            //{
                if (CurrentCheckBookID <= 0)
                {
                    try
                    {
                        Acc_ChequeBook cBook = new Acc_ChequeBook();
                        cBook = CreateChequeBook(cBook);
                        using (TheFacade facade = new TheFacade())
                        {
                            facade.Insert<Acc_ChequeBook>(cBook);
                            for (int i = 0; i < cBook.NumberofLeaf; i++)
                            {
                                Acc_ChequeLeaf leaf = new Acc_ChequeLeaf();
                                leaf.ChequeBookID = cBook.IID;
                                leaf.CreateBy = 1;
                                leaf.CreateDate = DateTime.Now;
                                leaf.UpdateBy = 1;
                                leaf.UpdateDate = DateTime.Now;
                                leaf.Status = 1;
                                //leaf.LeafNumber = (Convert.ToInt64(cBook.StartLeafNumber) + Convert.ToInt64(i) + 1).ToString();
                                leaf.LeafNumber = (Convert.ToInt64(cBook.StartLeafNumber) + Convert.ToInt64(i)).ToString();
                                leaf.IsRemoved = 0;
                                leaf.BranchID = Convert.ToInt32(Session["BranchID"]);
                                facade.Insert<Acc_ChequeLeaf>(leaf);
                            }
                        }
                        Session["IsSaved"] = true;
                        Response.Redirect(Request.Url.ToString());
                    }
                    catch
                    {
                        lblMsg.Text = "Data not saved...";
                        lblMsg.Visible = true;
                    }
                }
                else
                {
                    try
                    {
                        using (TheFacade facade = new TheFacade())
                        {
                            Acc_ChequeBook cBook = facade.AccountsFacade.GetChequeBookByIID(CurrentCheckBookID);
                            cBook = CreateChequeBook(cBook);
                            facade.Update<Acc_ChequeBook>(cBook);

                            List<Acc_ChequeLeaf> theleafList = facade.AccountsFacade.GetChequeLeafByCheckBookID(CurrentCheckBookID);
                            foreach (Acc_ChequeLeaf leaf in theleafList)
                            {
                                leaf.IsRemoved = 1;
                                facade.Update<Acc_ChequeLeaf>(leaf);
                            }
                            int leafNo = 0;
                            for (int i = 0; i < cBook.NumberofLeaf; i++)
                            {
                                Acc_ChequeLeaf leaf = new Acc_ChequeLeaf();
                                leafNo=Convert.ToInt32(cBook.StartLeafNumber) + leafNo;
                                leaf.ChequeBookID = cBook.IID;
                                leaf.CreateBy = 1;
                                leaf.CreateDate = DateTime.Now;
                                leaf.UpdateBy = 1;
                                leaf.UpdateDate = DateTime.Now;
                                leaf.Status = 1;
                                leaf.LeafNumber = leafNo.ToString();// (Convert.ToInt64(cBook.StartLeafNumber) + Convert.ToInt64(i) + 1).ToString();
                                leaf.IsRemoved = 0;
                                leaf.BranchID = Convert.ToInt32(Session["BranchID"]);
                                facade.Insert<Acc_ChequeLeaf>(leaf);
                                leafNo++;
                            }
                        }
                        Session["IsSaved"] = true;
                        Response.Redirect(Request.Url.ToString());
                    }
                    catch
                    {
                        lblMsg.Text = "Data not saved...";
                        lblMsg.Visible = true;
                    }
                }
            //}
            //else
            //{
            //    lblMsg.Text = "check no is not available...";
            //    lblMsg.Visible = true;
            //}
        }

        private Acc_ChequeBook CreateChequeBook(Acc_ChequeBook cBook)
        {
            cBook.NumberofLeaf =Convert.ToInt32(txtNumberofLeaf.Text.Trim());
            cBook.StartLeafNumber = txtStartLeafNumber.Text.Trim();
            cBook.IsActive = true;
            cBook.BankAccountID = Convert.ToInt64(ddlAccountName.SelectedValue);
            cBook.ChequeBookNumber = CommonHelper.GenerateChequeBookNo();//txtChequeBookNumber.Text.Trim();
            cBook.EndLeafNumber = (Convert.ToInt64(txtStartLeafNumber.Text.Trim()) + (Convert.ToInt64(txtNumberofLeaf.Text.Trim()))-1).ToString();
            if (CurrentCheckBookID <= 0)
            {
                cBook.CreateBy = 1;
                cBook.CreateDate = DateTime.Now;
            }
            cBook.UpdateBy = 1;
            cBook.UpdateDate = DateTime.Now;
            cBook.IsRemoved = 0;
            cBook.BranchID = Convert.ToInt32(Session["BranchID"]);

            return cBook;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lvCheckBook_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Acc_ChequeBook chkBook = new Acc_ChequeBook();
                    CurrentCheckBookID = Convert.ToInt64(e.CommandArgument.ToString());

                    List<Acc_ChequeLeaf> theleafList = _facade.AccountsFacade.GetChequeLeafByCheckBookID(CurrentCheckBookID);
                    foreach (Acc_ChequeLeaf leaf in theleafList)
                    {
                        leaf.IsRemoved = 1;
                        _facade.Update<Acc_ChequeLeaf>(leaf);
                    }

                    chkBook = _facade.AccountsFacade.GetChequeBookByIID(Convert.ToInt64(CurrentCheckBookID));
                    chkBook.IsRemoved = 1;
                    _facade.Update<Acc_ChequeBook>(chkBook);
                    
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {

                using (TheFacade _facade = new TheFacade())
                {

                    Acc_ChequeBook cBook = new Acc_ChequeBook();
                    CurrentCheckBookID = Convert.ToInt64(e.CommandArgument.ToString());
                    cBook = _facade.AccountsFacade.GetChequeBookByIID(CurrentCheckBookID);
                    LoadChequeBook(cBook);
                }
            }
        }

        private void LoadChequeBook(Acc_ChequeBook cBook)
        {
            txtNumberofLeaf.Text = cBook.NumberofLeaf.ToString();
            txtStartLeafNumber.Text = cBook.StartLeafNumber;
            txtStartLeafNumber_TextChanged(null, null);
            //txtChequeBookNumber.Text = cBook.ChequeBookNumber;
            //ddlAccountName.SelectedValue = cBook.BankAccountID.ToString();
            using (TheFacade facade = new TheFacade())
            {
                
                Acc_BankBranch branch = facade.AccountsFacade.GetBranchByIID(cBook.Acc_BankAccount.BankBranchID);
                Acc_Bank bank = facade.AccountsFacade.GetBankByIID(branch.BankID);
                
                ddlBank.SelectedValue = bank.IID.ToString();
                ddlBank_SelectedIndexChanged(null, null);
                ddlBranch.SelectedValue = branch.IID.ToString();
                ddlBranch_SelectedIndexChanged(null, null);
                ddlAccountName.SelectedValue = cBook.BankAccountID.ToString();
                
                
            }
        }

        protected void lvCheckBook_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_ChequeBook chkBook = (Acc_ChequeBook)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkChequeBookNumber = (LinkButton)currentItem.FindControl("lnkChequeBookNumber");

                Label lblAccountName = (Label)currentItem.FindControl("lblAccountName");
                Label lblNumberofLeaf = (Label)currentItem.FindControl("lblNumberofLeaf");
                Label lblStartLeafNumber = (Label)currentItem.FindControl("lblStartLeafNumber");
                Label lblEndLeafNumber = (Label)currentItem.FindControl("lblEndLeafNumber");

                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkChequeBookNumber.Text = chkBook.ChequeBookNumber;
                lnkChequeBookNumber.CommandArgument = chkBook.IID.ToString();
                lnkChequeBookNumber.CommandName = "DoEdit";

                lblAccountName.Text = chkBook.Acc_BankAccount.Name;
                lblNumberofLeaf.Text = chkBook.NumberofLeaf.ToString();
                lblStartLeafNumber.Text = chkBook.StartLeafNumber;
                lblEndLeafNumber.Text = chkBook.EndLeafNumber;

                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = chkBook.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = chkBook.IID.ToString();
            }
        }

        protected void dpList_PreRender(object sender, EventArgs e)
        {
            LoadListView();
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue != "-1")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlBranch.Items.Clear();
                    ddlAccountName.Items.Clear();
                    List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchByBankID(Convert.ToInt64(ddlBank.SelectedValue))
                        .Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                    DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "-1")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlAccountName.Items.Clear();
                    List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountByBranchID(Convert.ToInt64(ddlBranch.SelectedValue))
                        .Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                    DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void txtStartLeafNumber_TextChanged(object sender, EventArgs e)
        {
            long startNo = Convert.ToInt64(txtStartLeafNumber.Text.Trim());
            long noOfLeaf = Convert.ToInt64(txtNumberofLeaf.Text.Trim());
            lblEndLeafNumber.Text = "<b>To: </b>" + (startNo + noOfLeaf-1).ToString();
        }
    }
}
