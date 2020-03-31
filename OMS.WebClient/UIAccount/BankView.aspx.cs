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

namespace OMS.WebClient.UIAccount
{
    public partial class BankView : System.Web.UI.Page
    {
        public long CurrentBankID
        {
            get
            {
                if (ViewState["BankID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["BankID"]);
                }
            }
            set { ViewState["BankID"] = value; }
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

                    //AccessHelper helper = new AccessHelper();
                    //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    //if (!hasAccess)
                    //{
                    //    Response.Redirect("~/NoPermission.aspx");
                    //}

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
                lvBank.DataSource = facade.AccountsFacade.GetBankAll();
                lvBank.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {
                if (CurrentBankID <= 0)
                {
                    try
                    {
                        Acc_Bank bank = new Acc_Bank();
                        bank = CreateBank(bank);
                        using (TheFacade facade = new TheFacade())
                        {
                            facade.Insert<Acc_Bank>(bank);
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
                            Acc_Bank bank = facade.AccountsFacade.GetBankByIID(CurrentBankID);
                            bank = CreateBank(bank);
                            facade.Update<Acc_Bank>(bank);
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
            }
            else
            {
                FormsAuthentication.SignOut();
                Roles.DeleteCookie();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
        }

        private Acc_Bank CreateBank(Acc_Bank bank)
        {
            bank.Name = txtName.Text.Trim();
            bank.ShortName = txtShortName.Text.Trim();

            if (CurrentBankID <= 0)
            {
                bank.CreateBy = 1;
                bank.CreateDate = DateTime.Now;
            }
            bank.UpdateBy = 1;
            bank.UpdateDate = DateTime.Now;
            bank.IsRemoved = 0;
            //bank.BranchID = Convert.ToInt32(Session["BranchID"]);
            return bank;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lvBank_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Acc_Bank bank = new Acc_Bank();
                    CurrentBankID = Convert.ToInt64(e.CommandArgument.ToString());
                    bank = _facade.AccountsFacade.GetBankByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    bank.IsRemoved = 1;
                    _facade.Update<Acc_Bank>(bank);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {
                using (TheFacade _facade = new TheFacade())
                {

                    Acc_Bank bank = new Acc_Bank();
                    CurrentBankID = Convert.ToInt64(e.CommandArgument.ToString());
                    bank = _facade.AccountsFacade.GetBankByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadBank(bank);
                }
            }
        }

        private void LoadBank(Acc_Bank bank)
        {
            txtName.Text = bank.Name;
            txtShortName.Text = bank.ShortName;
        }

        int lvRowCount = 0;
        protected void lvBank_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_Bank bank = (Acc_Bank)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");
                Label lblShortName = (Label)currentItem.FindControl("lblShortName");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)currentItem.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();

                lnkName.Text = bank.Name;
                lnkName.CommandArgument = bank.IID.ToString();
                lnkName.CommandName = "DoEdit";

                lblShortName.Text = bank.ShortName;

                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = bank.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = bank.IID.ToString();
            }
        }

        int CurrentPage = 0; 
        protected void dpList_PreRender(object sender, EventArgs e)
        {
            lvRowCount = CurrentPage * 20;
            if (IsPostBack)
                LoadListView();
        }

        protected void lvBank_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

    }
}
