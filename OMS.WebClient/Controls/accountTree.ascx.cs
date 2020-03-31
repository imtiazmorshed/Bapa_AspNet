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
using OMS.Facade;
using OMS.DAL;
using System.ComponentModel;
using OMS.Framework;

namespace OMS.WebClient.Controls
{
    public partial class accountTree : System.Web.UI.UserControl
    {
        //public event SendNodeInfoHandler sendNodeInfoHandler;
        //public bool isClickNode = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CreateTree(-1);
               CreateTheTree();
            }
        }

        #region Previous Methods

        private void CreateTree(long ParentID)
        {
            using (TheFacade _facade = new TheFacade())
            {
                List<Acc_Class> classList = _facade.AccountsFacade.GetAcc_ClassAll();
                foreach (Acc_Class aclass in classList)
                {
                    TreeNode tr = new TreeNode();
                    tr.Value = aclass.Name;
                    tvShartofAccount.Nodes.Add(tr);
                    List<Acc_ChartOfAccount> achartListNew = _facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntAndParentID(Convert.ToInt32(aclass.IID),-1);
                    if (achartListNew.Count > 0)
                    {
                        foreach (Acc_ChartOfAccount accn in achartListNew)
                        {
                            TreeNode trchild = new TreeNode();
                            trchild.Value = accn.Name;
                            tr.ChildNodes.Add(trchild);
                            CreateChildNode(accn, trchild);
                        }
                    }
                }

            }
        }

        private void CreateNode(Acc_ChartOfAccount acc)
        {
            using (TheFacade _facade = new TheFacade())
            {
                TreeNode tr = new TreeNode();
                tr.Value = acc.Name;
                tvShartofAccount.Nodes.Add(tr);
                List<Acc_ChartOfAccount> achartList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(acc.IID);
                if (achartList.Count > 0)
                {
                    foreach (Acc_ChartOfAccount accn in achartList)
                    {
                        TreeNode trchild = new TreeNode();
                        trchild.Value = accn.Name;
                        tr.ChildNodes.Add(trchild);
                        CreateChildNode(accn, trchild);
                    }
                }
            }
        }

        private void CreateChildNode(Acc_ChartOfAccount accn, TreeNode trchild)
        {
            using (TheFacade _facade = new TheFacade())
            {
                List<Acc_ChartOfAccount> accnnewLsit = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(accn.IID);
                foreach (Acc_ChartOfAccount accnt in accnnewLsit)
                {
                    TreeNode trnew = new TreeNode();
                    trnew.Value = accnt.Name;
                    trchild.ChildNodes.Add(trnew);
                    
                }
            }
        }

        #endregion

        #region New Methods

        public List<Acc_ChartOfAccount> NodeList = new List<Acc_ChartOfAccount>();
        Decimal balanceControl = 0;
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
                    
                    foreach (Acc_ChartOfAccount chacc in nEWNodeList)
                    {
                        balanceControl = 0;
                        AddNode(chacc, tr, chacc.Gparent);
                    }
                }
            }
        }

        private void AddNode(Acc_ChartOfAccount cacc, TreeNode tr,long Gparent)
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
                        //else
                        //{
                        //    nacc.Balance = bal;
                        //}
                        AddNode(nacc, trchild, nacc.Gparent);
                        
                        NodeList.Remove(nacc);
                    }

                }
                if (cacc.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.NonTransactable))
                {
                    balanceControl += bal;
                    if (cacc.ParentID == -1)
                    {
                        cacc.Balance = balanceControl;
                    }
                    else
                    {
                        cacc.Balance = bal;
                    }
                }     
                trchild.Value = cacc.Name +"-"+ cacc.AccountNo + "[" + cacc.Balance + "]";
                //trchild.Value = cacc.Name + "-" + cacc.AccountNo;
                tr.ChildNodes.Add(trchild);                
                bal = 0;
                NodeList.Remove(cacc);
            }
        }

        #endregion

        protected void tvShartofAccount_SelectedNodeChanged(object sender, EventArgs e)
        {
            //if (tvShartofAccount.SelectedNode != null)
            //    isClickNode = true;
            //else
            //    isClickNode = false;
            //if (sendNodeInfoHandler != null)
            //{
            //    sendNodeInfoHandler(tvShartofAccount.SelectedValue);
            //}
        }
    }
}