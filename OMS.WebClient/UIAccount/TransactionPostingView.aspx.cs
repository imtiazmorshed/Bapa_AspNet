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
using System.Collections.Generic;
using OMS.Facade;
using OMS.Framework;
using OMS.Web.Helpers;

namespace OMS.WebClient.UIAccount
{
    public partial class TransactionPostingView : System.Web.UI.Page
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
                    AccessHelper helper = new AccessHelper();
                    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    if (!hasAccess)
                    {
                        Response.Redirect("~/NoPermission.aspx");
                    }


                    LoadDDL();
                    btnPost.Enabled = false;
                }
            }
        }

        private void LoadDDL()
        {
            DDLHelper.Bind(ddlTransactionStatus, EnumHelper.EnumToList<EnumCollection.TransactionStatus>());//, EnumCollection.ListItemType.TransactionMode);
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
                LoadListViewNull();
            }
        }

        private void LoadTransactionMasterListView(int status, DateTime fromDate, DateTime toDate)
        {
            //if (ddlTransactionStatus.SelectedValue != null)// && (!string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text)))
            //{
                List<Acc_TransactionMaster> acc_TransactionMasterList = new List<Acc_TransactionMaster>();
                using (TheFacade _facade = new TheFacade())
                {
                    acc_TransactionMasterList = _facade.AccountsFacade.GetAcc_TransactionMasterListViewByParam(status, fromDate, toDate).OrderByDescending(ac => ac.TransactionDate).ToList();
                    if (acc_TransactionMasterList.Count > 0)
                    {
                        lvTransactionPosting.DataSource = acc_TransactionMasterList;
                        lvTransactionPosting.DataBind();
                    }
                    else
                    {
                        LoadListViewNull();
                    }
                }
            //}
            //else
            //{
            //    LoadListViewNull();
            //}
        }

        private void LoadListViewNull()
        {
            lvTransactionPosting.DataSource = null;
            lvTransactionPosting.DataBind();
        }

        //private void LoadTransactionMasterListView()
        //{
        //    List<Acc_TransactionMaster> acc_TransactionMasterList = new List<Acc_TransactionMaster>();
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        acc_TransactionMasterList = _facade.AccountsFacade.GetAcc_TransactionMasterListView(Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted)).OrderByDescending(ac => ac.TransactionDate).ToList();
        //        if (acc_TransactionMasterList.Count > 0)
        //        {
        //            lvTransactionPosting.DataSource = acc_TransactionMasterList;
        //            lvTransactionPosting.DataBind();
        //        }
        //    }
        //}

        int slNo = 1;
        protected void lvTransactionPosting_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_TransactionMaster master = (Acc_TransactionMaster)((ListViewDataItem)(e.Item)).DataItem;

                Label lblSLNo = (Label)currentItem.FindControl("lblSLNo");
                Label lblDate = (Label)currentItem.FindControl("lblDate");
                LinkButton lnkbtnTransactionCode = (LinkButton)currentItem.FindControl("lnkbtnTransactionCode");
                Label lblPayReason = (Label)currentItem.FindControl("lblPayReason");
                CheckBox chkPost = (CheckBox)currentItem.FindControl("chkPost");
                ListView lvTransactionDetail = (ListView)currentItem.FindControl("lvTransactionDetail");

                lblSLNo.Text = slNo.ToString();
                slNo++;
                lblDate.Text = master.TransactionDate.ToString("dd/MM/yyyy");
                if (master.Status == Convert.ToInt32(EnumCollection.TransactionStatus.Posted))
                {
                    chkPost.Checked = true;
                    chkPost.Enabled = false;
                }
                else
                {
                    chkPost.Enabled = true;
                }
                lnkbtnTransactionCode.Text = master.JournalCode;
                lnkbtnTransactionCode.CommandArgument = master.IID.ToString();
                lnkbtnTransactionCode.CommandName = "ViewVoucher";

                lblPayReason.Text = master.PayReason + "("+ master.Particulars +")";
                using (TheFacade _facade = new TheFacade())
                {
                    List<Acc_TransactionDetail> acc_TransactionDetailList = new List<Acc_TransactionDetail>();
                    acc_TransactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(master.IID,Convert.ToInt32(ddlTransactionStatus.SelectedValue));
                    lvTransactionDetail.DataSource = acc_TransactionDetailList;
                    lvTransactionDetail.DataBind();
                }
            }
        }

        protected void lvTransactionDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_TransactionDetail detail = (Acc_TransactionDetail)((ListViewDataItem)(e.Item)).DataItem;

                Label lblAccountName = (Label)currentItem.FindControl("lblAccountName");
                Label lblDescription = (Label)currentItem.FindControl("lblDescription");
                Label lblDebit = (Label)currentItem.FindControl("lblDebit");
                Label lblCredit = (Label)currentItem.FindControl("lblCredit");

                lblAccountName.Text = detail.Acc_ChartOfAccount.Name + "(" + detail.Acc_ChartOfAccount.AccountNo + ")";
                lblDescription.Text = detail.Particulars;
                if (detail.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                {
                    lblDebit.Text = detail.Amount.ToString("0.00");
                }
                else
                {
                    lblDebit.Text = "--";
                }
                if (detail.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Credit))
                {
                    lblCredit.Text = detail.Amount.ToString("0.00");
                }
                else
                {
                    lblCredit.Text = "--";
                }
                
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {            
            foreach (ListViewDataItem currentItem in lvTransactionPosting.Items)
            {                
                

                Label lblSLNo = (Label)currentItem.FindControl("lblSLNo");
                Label lblDate = (Label)currentItem.FindControl("lblDate");
                LinkButton lnkbtnTransactionCode = (LinkButton)currentItem.FindControl("lnkbtnTransactionCode");
                Label lblPayReason = (Label)currentItem.FindControl("lblPayReason");
                CheckBox chkPost = (CheckBox)currentItem.FindControl("chkPost");
                ListView lvTransactionDetail = (ListView)currentItem.FindControl("lvTransactionDetail");
                if (chkPost.Checked)
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        Acc_TransactionMaster master = new Acc_TransactionMaster();
                        master = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionCode(lnkbtnTransactionCode.Text);
                        if (master.IID > 0)
                        {
                            master.Status = Convert.ToInt32(EnumCollection.TransactionStatus.Posted);
                            master.UpdateBy = 1;
                            master.UpdateDate = DateTime.Now;
                            _facade.Update<Acc_TransactionMaster>(master);
                        }
                    }
                }
                
            }
            
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;
            if (!string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text))
            {
                fromDate = Convert.ToDateTime(txtFromDate.Text + " 12:00:00 AM");
                toDate = Convert.ToDateTime(txtToDate.Text + " 11:59:59 PM");
            }
            else
            {
                fromDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
                toDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            LoadTransactionMasterListView(Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted), fromDate, toDate);
        }

        protected void lvTransactionPosting_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewVoucher")
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
        }

        protected void ddlTransactionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTransactionStatus.SelectedValue != "-1")
            {
                if (ddlTransactionStatus.SelectedValue == Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted).ToString())
                {
                    btnPost.Enabled = true;
                }
                else
                {
                    btnPost.Enabled = false;
                }
            }
            else
            {
                btnPost.Enabled = false;
            }
        }
    }
}
