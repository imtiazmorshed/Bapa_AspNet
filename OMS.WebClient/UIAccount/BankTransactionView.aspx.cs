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
using OMS.DAL;
using OMS.Web.Helpers;
using OMS.Framework;
using System.Collections.Generic;
using OMS.Facade;

namespace OMS.WebClient.UIAccount
{
    public partial class BankTransactionView : System.Web.UI.Page
    {
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
                    //AccessHelper helper = new AccessHelper();
                    //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    //if (!hasAccess)
                    //{
                    //    Response.Redirect("~/NoPermission.aspx");
                    //}

                    LoadDDL();
                }
            }
        }

        private void LoadDDL()
        {
            LoadTransactionType();
        }

        private void LoadTransactionType()
        {
            
            DDLHelper.Bind(ddlTransationType, EnumHelper.EnumToList<EnumCollection.TransactionType>(), EnumCollection.ListItemType.TransactionType);

        }

        protected void lvTransaction_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_BankTransaction bankTransaction = (Acc_BankTransaction)((ListViewDataItem)(e.Item)).DataItem;
                Label lblTransactionDate = (Label)currentItem.FindControl("lblTransactionDate");
                Label lblJurnalCode = (Label)currentItem.FindControl("lblJurnalCode");
                Label lblChequeDate = (Label)currentItem.FindControl("lblChequeDate");
                Label lblChequeLeafNo = (Label)currentItem.FindControl("lblChequeLeafNo");
                Label lblAmount = (Label)currentItem.FindControl("lblAmount");
                DropDownList ddlChequeLeafStatus = (DropDownList)currentItem.FindControl("ddlChequeLeafStatus");
                CheckBox chkSelect = (CheckBox)currentItem.FindControl("chkSelect");

                lblTransactionDate.Text = bankTransaction.Acc_TransactionMaster.TransactionDate.ToShortDateString();
                lblJurnalCode.Text = bankTransaction.Acc_TransactionMaster.JournalCode;
                lblChequeDate.Text = bankTransaction.ChequeDate.ToShortDateString();
                if (bankTransaction.ReferenceType == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                {
                    lblChequeLeafNo.Text = bankTransaction.ChequeLeaf.LeafNumber;
                }
                else
                {
                    lblChequeLeafNo.Text = bankTransaction.ChequeLeafNumber;
                }
                lblAmount.Text = bankTransaction.Amount.ToString("0.00");
                if (bankTransaction.ReferenceType == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                {

                }
                DDLHelper.Bind(ddlChequeLeafStatus, EnumHelper.EnumToList<EnumCollection.ChequeLeafStatus>(), EnumCollection.ListItemType.ChequeLeafStatus);
                ddlChequeLeafStatus.SelectedValue = bankTransaction.ChequeLeaf.Status.ToString();
                if (bankTransaction.ReferenceType == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                {
                    ddlChequeLeafStatus.Enabled = true;
                }
                else
                {
                    ddlChequeLeafStatus.Enabled = false;
                }

            }
        }

        protected void lvTransaction_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

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
            if (ddlTransationType.SelectedValue != null)// && (!string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text)))
            {
                LoadTransactionMasterListView(Convert.ToInt32(ddlTransationType.SelectedValue), fromDate, toDate);
            }
            else
            {
                LoadListViewNull();
            }
        }

        private void LoadTransactionMasterListView(int status, DateTime fromDate, DateTime toDate)
        {
            List<Acc_BankTransaction> acc_BankTransactionList = new List<Acc_BankTransaction>();
            using (TheFacade _facade = new TheFacade())
            {
                acc_BankTransactionList = _facade.AccountsFacade.GetAcc_BankTransactionByParam(Convert.ToInt32(ddlTransationType.SelectedValue), fromDate, toDate).OrderByDescending(bt => bt.ChequeDate).ToList();
                if (acc_BankTransactionList.Count > 0)
                {
                    lvTransaction.DataSource = acc_BankTransactionList;
                    lvTransaction.DataBind();
                }
                else
                {
                    LoadListViewNull();
                }
            }
        }

        private void LoadListViewNull()
        {
            lvTransaction.DataSource = null;
            lvTransaction.DataBind();
        }
    }
}
