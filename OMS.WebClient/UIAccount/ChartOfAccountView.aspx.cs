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
using OMS.Web.Helpers;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class ChartOfAccountView : System.Web.UI.Page
    {
        public long CurrentChartOfAccountID
        {
            get
            {
                if (ViewState["CurrentChartOfAccountID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentChartOfAccountID"]);
                }
            }
            set { ViewState["CurrentChartOfAccountID"] = value; }
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
                    //rbTransactable.Checked = true;
                    //rbTransactable_CheckedChanged(null, null);
                    LoadDDL();
                    CreateTheTree();
                    if (Session["msg"] != null)
                    {
                        lblMsg.Text = Session["msg"].ToString();
                        lblMsg.Visible = true;
                        Session["msg"] = null;
                    }
                    //btnDelete.Enabled = false;
                }
                //if (CurrentChartOfAccountID>0)
                //{
                else
                {
                    //TreeView tv = (TreeView)accountTree1.FindControl("tvShartofAccount");
                    //string[] treeNodeArr = tv.SelectedValue.Split('-');
                    //string treeNode = treeNodeArr[0];
                    //if (!String.IsNullOrEmpty(treeNode))
                    //{
                    //    using (TheFacade _facade = new TheFacade())
                    //    {
                    //        Acc_ChartOfAccount coa = _facade.AccountsFacade.GetAcc_ChartOfAccountByName(treeNode);
                    //        if (coa.IID != 0)
                    //        {
                    //            CurrentChartOfAccountID = coa.IID;
                    //            ddlAccountClass.SelectedValue = coa.Acc_Class.IID.ToString();
                    //            ddlNonTransactableAccount.SelectedValue = coa.ParentID.ToString();
                    //            txtAccountNo.Text = coa.AccountNo;
                    //            txtAccountName.Text = coa.Name;
                    //            if (coa.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable))
                    //            {
                    //                rbTransactable.Checked = true;
                    //                rbNonTransactable.Checked = false;
                    //            }
                    //            else
                    //            {
                    //                rbTransactable.Checked = false;
                    //                rbNonTransactable.Checked = true;
                    //            }
                    //            if (coa.ParentID == -1)
                    //            {
                    //                rbTransactable.Enabled = false;
                    //                rbNonTransactable.Enabled = false;
                    //            }
                    //            else
                    //            {
                    //                rbTransactable.Enabled = true;
                    //                rbNonTransactable.Enabled = true;
                    //            }
                    //        }
                    //}
                    //}
                    //tv.c
                    //}
                    //accountTree1.sendNodeInfoHandler += delegate(string message)
                    //{
                    //    string tree = message;
                    //};
                }
            }
        }

        #region New Methods

        public List<Acc_ChartOfAccount> NodeList = new List<Acc_ChartOfAccount>();

        private void CreateTheTree()
        {
            using (TheFacade _facade = new TheFacade())
            {
                NodeList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll();
                List<Acc_ChartOfAccount> nEWNodeList = new List<Acc_ChartOfAccount>();//_facade.AccountsFacade.GetAcc_ChartOfAccountAll();
                List<Acc_Class> classList = _facade.AccountsFacade.GetAcc_ClassAll();
                Decimal balanceHead = 0;
                foreach (Acc_Class aclass in classList)
                {
                    balanceHead = 0;
                    TreeNode tr = new TreeNode();
                    tr.Value = aclass.Name;
                    tvShartofAccount.Nodes.Add(tr);
                    nEWNodeList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntAndParentID(aclass.IID, -1);
                    Decimal balanceControl = 0;
                    foreach (Acc_ChartOfAccount chacc in nEWNodeList)
                    {
                        balanceControl = 0;
                        AddNode(chacc, tr, chacc.Gparent);
                    }
                }
            }
        }

        private void AddNode(Acc_ChartOfAccount cacc, TreeNode tr, long Gparent)
        {
            using (TheFacade _facade = new TheFacade())
            {
                TreeNode trchild = new TreeNode();
                decimal bal = 0;
                List<Acc_ChartOfAccount> nEWNodeList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntAndParentID(Convert.ToInt32(Gparent), cacc.IID);
                if (nEWNodeList.Count > 0 || NodeList.Count >= 1)
                {

                    foreach (Acc_ChartOfAccount nacc in nEWNodeList)
                    {
                        Acc_ChartOfAccount balAcc = new Acc_ChartOfAccount();
                        if (nacc.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable))
                        {
                            balAcc = _facade.AccountsFacade.GetAcc_ChartOfAccountBalance(nacc.IID);
                            bal += balAcc.Balance;
                        }
                        else
                        {
                            nacc.Balance = bal;
                        }
                        AddNode(nacc, trchild, nacc.Gparent);
                        NodeList.Remove(nacc);
                    }

                }
                if (cacc.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.NonTransactable))
                {
                    cacc.Balance = bal;
                }

                NodeList.Remove(cacc);
                //trchild.Value = cacc.Name + "-" + cacc.AccountNo + "[" + cacc.Balance + "]";
                //trchild.Value = cacc.Name + "-" + cacc.AccountNo;
                trchild.Value = cacc.Name + "[" +cacc.AccountNo +"]";
                tr.ChildNodes.Add(trchild);
                bal = 0;
            }


        }

        #endregion

        private void LoadDDL()
        {
            List<Acc_Class> classList = new List<Acc_Class>();
            List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            //List<BalanceSheetItem> balanceSheetItemList = new List<BalanceSheetItem>();
            using (TheFacade _facade = new TheFacade())
            {
                classList = _facade.AccountsFacade.GetAcc_ClassAll();
                chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll().Where(ca => ca.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.NonTransactable)).ToList();
                //balanceSheetItemList = _facade.AccountsFacade.GetBalanceSheetItemAll();
            }

            DDLHelper.Bind<Acc_Class>(ddlAccountClass, classList, "Name", "IID", EnumCollection.ListItemType.ClassName);
            DDLHelper.Bind<Acc_ChartOfAccount>(ddlNonTransactableAccount, chartOfAccountList, "Name", "IID", EnumCollection.ListItemType.AccountName);
            //DDLHelper.Bind<BalanceSheetItem>(ddlBalanceSheetItem, balanceSheetItemList, "Name", "IID", EnumCollection.ListItemType.Select);
            ddlNonTransactableAccount.Enabled = false;
        }

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

        protected void btnSave_Click(object sender, EventArgs e)
        {    
            using (TheFacade _facade = new TheFacade())
            {
                    Acc_ChartOfAccount chartOfAccount = new Acc_ChartOfAccount();
                    if (CurrentChartOfAccountID == -1)
                    {
                        Acc_ChartOfAccount chartOfAccountOld = _facade.AccountsFacade.GetChartOfAccountByName(txtAccountName.Text.Trim());
                        if (chartOfAccountOld == null)
                        {
                            LoadChartOfAccount(chartOfAccount);
                            _facade.Insert<Acc_ChartOfAccount>(chartOfAccount);
                            Session["msg"] = "Data successfully saved";
                            Response.Redirect(Request.Url.ToString());
                        }
                        else
                        {
                            lblMsg.Text = "Account name already exist...";
                            lblMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Acc_ChartOfAccount chartOfAccountOld = _facade.AccountsFacade.GetAcc_ChartOfAccountByNameAndIID(txtAccountName.Text.Trim(), CurrentChartOfAccountID);
                        if (chartOfAccountOld == null)
                        {
                            chartOfAccount = _facade.AccountsFacade.GetAcc_ChartOfAccountByID(CurrentChartOfAccountID);
                            LoadChartOfAccount(chartOfAccount);
                            _facade.Update<Acc_ChartOfAccount>(chartOfAccount);
                            Session["msg"] = "Data successfully saved";
                            Response.Redirect(Request.Url.ToString());
                        }
                        else
                        {
                            lblMsg.Text = "Account name already exist...";
                            lblMsg.Visible = true;
                        }
                    }
                
            }
            //ddlNonTransactableAccount.Enabled = false;
            //Response.Redirect("~/UIAccount/ChartOfAccountView.aspx");
        }

        private void LoadChartOfAccount(Acc_ChartOfAccount chartOfAccount)
        {
            if (CurrentChartOfAccountID == -1)
            {
                chartOfAccount.AccountNo = GenerateAccountNo();
                chartOfAccount.CreateBy = Convert.ToInt64(Session["UserID"]);
                chartOfAccount.CreateDate = DateTime.Now;
            }
            chartOfAccount.Name = txtAccountName.Text;
            chartOfAccount.IsActive = 1;
            if (rbTransactable.Checked)
            {
                chartOfAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                if (string.IsNullOrEmpty(txtOpeningBalance.Text))
                {
                    chartOfAccount.OpeningBalance = 0;
                }
                else
                {
                    chartOfAccount.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text);
                }
            }
            else
            {
                chartOfAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.NonTransactable);
                chartOfAccount.OpeningBalance = 0;
            }
            chartOfAccount.ParentID = Convert.ToInt64(ddlNonTransactableAccount.SelectedValue);
            chartOfAccount.Gparent = Convert.ToInt32(ddlAccountClass.SelectedValue);
            chartOfAccount.UpdateBy = Convert.ToInt64(Session["UserID"]);
            chartOfAccount.UpdateDate = DateTime.Now;
            chartOfAccount.IsRemoved = 0;
            chartOfAccount.BranchID = Convert.ToInt32(Session["BranchID"]);
        }
        #region previous account no logic
        //private string GenerateAccountNo()
        //{
        //    string code = "";
        //    int count = 1;
        //    using (TheFacade facade = new TheFacade())
        //    {
                
        //         code = ddlAccountClass.SelectedValue + "-";
        //        if (ddlNonTransactableAccount.Items.Count == 0)
        //        {
        //            List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(ddlAccountClass.SelectedValue)).OrderBy(a => a.IID).ToList();
        //            int position = 1;
        //            foreach (Acc_ChartOfAccount acc in acclistAnother)
        //            {

        //                if (acc.IID == Convert.ToInt64(ddlNonTransactableAccount.SelectedValue))
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
        //        else if (ddlNonTransactableAccount.SelectedValue == "-1")
        //        {
        //            List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(ddlAccountClass.SelectedValue)).OrderBy(a => a.IID).ToList();
        //            int position = 1;
        //            foreach (Acc_ChartOfAccount acc in acclistAnother)
        //            {

        //                if (acc.IID == Convert.ToInt64(ddlNonTransactableAccount.SelectedValue))
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
        //            List<Acc_ChartOfAccount> acclist = facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(Convert.ToInt64(ddlNonTransactableAccount.SelectedValue));
        //            List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(ddlAccountClass.SelectedValue)).OrderBy(a=>a.IID).ToList();
        //            int position = 1;
        //            foreach (Acc_ChartOfAccount acc in acclistAnother)
        //            {

        //                if (acc.IID == Convert.ToInt64(ddlNonTransactableAccount.SelectedValue))
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    position++;
        //                }

        //            }
                   
        //                code = code + (position + 1).ToString()+"-" + (acclist.Count + 1).ToString().PadLeft(4, '0');
                    
        //        }
        //    }
        //    //code = code + "";
        //    return code;
        //}
        //int maincounter = 1;
        //private string CountAgain(int count, long parentID)
        //{
        //    string subCOde = "";
        //     List<Acc_ChartOfAccount> acclistNew =new List<Acc_ChartOfAccount>();
        //     int Thecount = 0;
        //    using (TheFacade facade = new TheFacade())
        //    {
        //        acclistNew = facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(parentID);

        //        Thecount = Thecount + acclistNew.Count;
                    
                
        //    }
        //    maincounter++;
        //    return subCOde = maincounter.ToString() + Thecount.ToString().PadLeft(3,'0');
        //}
        #endregion
        #region new logic
        private string GenerateAccountNo()
        {
            string code = "";

            code = ddlAccountClass.SelectedValue;
            int count = 0;
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(ddlAccountClass.SelectedValue)).OrderBy(a => a.IID).ToList();
                count = acclistAnother.Count + 1;
                code = code + count.ToString().PadLeft(5, '0');
            }
            return code;
        }
        #endregion
        protected void ddlAccountClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            using (TheFacade _facade = new TheFacade())
            {            
                chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll().Where(ca => ca.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.NonTransactable) && ca.Gparent == Convert.ToInt32(ddlAccountClass.SelectedValue)).ToList();
            }
            
            DDLHelper.Bind<Acc_ChartOfAccount>(ddlNonTransactableAccount, chartOfAccountList, "Name", "IID", EnumCollection.ListItemType.AccountName);
            ddlNonTransactableAccount.Enabled = true;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void tvShartofAccount_SelectedNodeChanged(object sender, EventArgs e)
        {
            string[] treeNodeArr = tvShartofAccount.SelectedValue.Split('[',']');
            string treeNode = treeNodeArr[0];
            //string treeNode = tvShartofAccount.SelectedValue;
            if (!String.IsNullOrEmpty(treeNode))
            {
                using (TheFacade _facade = new TheFacade())
                {
                    Acc_ChartOfAccount coa = _facade.AccountsFacade.GetChartOfAccountByName(treeNode);
                    //if (coa.IID != 0)
                    if (coa != null)
                    {
                        CurrentChartOfAccountID = coa.IID;
                        ddlAccountClass.SelectedValue = coa.Acc_Class.IID.ToString();
                        ddlNonTransactableAccount.SelectedValue = coa.ParentID.ToString();
                        txtAccountNo.Text = coa.AccountNo;
                        txtAccountName.Text = coa.Name;
                        string Op_bal = string.Empty;
                        if (string.IsNullOrEmpty(coa.OpeningBalance.ToString()))
                        {
                            Op_bal = "0.00";
                        }
                        else
                        {
                            Op_bal = coa.OpeningBalance.ToString();
                        }
                        if (coa.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable))
                        {
                            rbTransactable.Checked = true;
                            //rbTransactable_CheckedChanged(null, null);
                            rbNonTransactable.Checked = false;
                            //rbNonTransactable_CheckedChanged(null, null);
                            trOB.Visible = true;
                            
                            txtOpeningBalance.Text = Op_bal;
                        }
                        else
                        {
                            rbTransactable.Checked = false;
                            //rbTransactable_CheckedChanged(null, null);
                            rbNonTransactable.Checked = true;
                            //rbNonTransactable_CheckedChanged(null, null);
                            trOB.Visible = false;
                            
                        }
                        if (coa.ParentID == -1)
                        {
                            rbTransactable.Enabled = false;
                            rbNonTransactable.Enabled = false;
                        }
                        else
                        {
                            rbTransactable.Enabled = true;
                            rbNonTransactable.Enabled = true;
                        }

                        Acc_ChartOfAccount coatest = _facade.AccountsFacade.GetAcc_ChartOfAccountByParentID(coa.IID);
                        if (coatest != null)
                        {
                            rbTransactable.Enabled = false;
                            rbNonTransactable.Enabled = false;
                        }
                        else
                        {
                            rbTransactable.Enabled = true;
                            rbNonTransactable.Enabled = true;
                        }

                        
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (TheFacade _facade = new TheFacade())
            {
                
                // Delete logic here
                Acc_ChartOfAccount coaChild = _facade.AccountsFacade.GetAcc_ChartOfAccountByParentID(CurrentChartOfAccountID);
                List<Acc_TransactionDetail> tDetailsList = _facade.AccountsFacade.GetAcc_TransactionDetailListByChartOfAccountID(CurrentChartOfAccountID);
                if (coaChild != null || tDetailsList.Count > 0)
                {
                    lblMsg.Text = "The Account Can't be deleted, it is already used in Transaction or a as Group head that contains another Ledger.";
                    lblMsg.Visible = true;
                    //btnDelete.Enabled = false;
                }
                else
                {
                    Acc_ChartOfAccount chartOfAccount = new Acc_ChartOfAccount();
                    chartOfAccount = _facade.AccountsFacade.GetAcc_ChartOfAccountByID(CurrentChartOfAccountID);
                    chartOfAccount.IsRemoved = 1;
                    _facade.Update<Acc_ChartOfAccount>(chartOfAccount);
                    Session["msg"] = "Data successfully saved";
                    Response.Redirect(Request.Url.ToString());
                }

                
            }
        }

        protected void rbNonTransactable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNonTransactable.Checked)
            {
                trOB.Visible = false;
                //trBSI.Visible = false;
                rbTransactable.Checked = false;
            }
            else
            {
                trOB.Visible = true;
                //trBSI.Visible = true;
            }
        }

        protected void rbTransactable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransactable.Checked)
            {
                trOB.Visible = true;
                //trBSI.Visible = true;
                rbNonTransactable.Checked = false;
            }
            else
            {
                trOB.Visible = false;
                //trBSI.Visible = false;
                //rbNonTransactable.Checked = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //List<Acc_ChartOfAccount> coaParentList = new List<Acc_ChartOfAccount>();
            //List<Acc_ChartOfAccount> coaChildList = new List<Acc_ChartOfAccount>();
            //List<Acc_ChartOfAccount> coaGroupList = new List<Acc_ChartOfAccount>();
            //List<Acc_ChartOfAccount> coaGroupParentList = new List<Acc_ChartOfAccount>();
            //List<Acc_ChartOfAccount> coaLedgerList = new List<Acc_ChartOfAccount>();
            //using (TheFacade _facade = new TheFacade())
            //{
            //    coaParentList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll().Where(c => c.ParentID == -1 && c.Gparent != 3 && c.Gparent != 4).ToList();
            //    foreach (Acc_ChartOfAccount coa in coaParentList)
            //    {
            //        coaChildList = _facade.AccountsFacade.GetAcc_ChartOfAccountBalanceNew(coa.IID);
            //        coaGroupList = new List<Acc_ChartOfAccount>();
            //        coaGroupList = coaChildList.Where(c => c.ParentID == coa.IID).ToList();
            //        foreach (Acc_ChartOfAccount coaGP in coaGroupList)
            //        {
            //            coaGroupParentList.Add(coaGP);
            //        }
            //        coaLedgerList = coaChildList.Where(c => c.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable)).ToList();
            //    }
            //}
            decimal balance = 0;
            using (TheFacade _facade = new TheFacade())
            {
                balance = _facade.AccountsFacade.GetClassBalance(3);
            }
        }
    }
}
