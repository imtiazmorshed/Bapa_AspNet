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
using OMS.Web.Helpers;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class accountReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserID"] != null)
                //{
                //    AccessHelper helper = new AccessHelper();
                //    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()),
                //                                      Convert.ToInt64(Session["RoleID"].ToString()),
                //                                      Convert.ToBoolean(Session["IsRoleBased"].ToString()),
                //                                      this.Page.Title.ToString());
                //    if (!hasAccess)
                //    {
                //        Response.Redirect("~/NoPermission.aspx");
                //    }
                //}
                //else
                //{
                //    Response.Redirect("~/login.aspx");
                //}

                LoadDDL();
                
                //CreateTree(-1);
            }
        }

        private void LoadDDL()
        {
            LoadChartOfAccount();
        }

        private void LoadChartOfAccount()
        {
            List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            using (TheFacade _facade = new TheFacade())
            {
                chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll(Convert.ToInt32(EnumCollection.AccountType.NonTransactable));
            }

            DDLHelper.Bind<Acc_ChartOfAccount>(ddlChartOfAccount, chartOfAccountList, "Name", "IID", EnumCollection.ListItemType.AccountName);
          
        }

        protected void ddlChartOfAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChartOfAccount.SelectedValue != "")
            {
                Decimal totalBalance = 0;
                List<Acc_ChartOfAccount> acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
 
            }
        }


        //private void CreateTree(long ParentID)
        //{
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        List<Acc_Class> classList = _facade.AccountsFacade.GetAcc_ClassAll();
        //        foreach (Acc_Class aclass in classList)
        //        {
        //            TreeNode tr = new TreeNode();
        //            tr.Value = aclass.Name;
        //            tvShartofAccount.Nodes.Add(tr);
        //            List<Acc_ChartOfAccount> achartListNew = _facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(aclass.IID));
        //            if (achartListNew.Count > 0)
        //            {
        //                foreach (Acc_ChartOfAccount accn in achartListNew)
        //                {
        //                    TreeNode trchild = new TreeNode();
        //                    trchild.Value = accn.Name;
        //                    tr.ChildNodes.Add(trchild);
        //                    CreateChildNode(accn, trchild);
        //                }
        //            }
        //        }

        //    }
        //}
        //private void CreateNode(Acc_ChartOfAccount acc)
        //{
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        TreeNode tr = new TreeNode();
        //        tr.Value = acc.Name;
        //        tvShartofAccount.Nodes.Add(tr);
        //        List<Acc_ChartOfAccount> achartList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(acc.IID);
        //        if (achartList.Count > 0)
        //        {
        //            foreach (Acc_ChartOfAccount accn in achartList)
        //            {
        //                TreeNode trchild = new TreeNode();
        //                trchild.Value = accn.Name;
        //                tr.ChildNodes.Add(trchild);
        //                CreateChildNode(accn, trchild);
        //            }
        //         }
        //    }
        //}

        //private void CreateChildNode(Acc_ChartOfAccount accn, TreeNode trchild)
        //{
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        List<Acc_ChartOfAccount> accnnewLsit = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(accn.IID);
        //        foreach (Acc_ChartOfAccount accnt in accnnewLsit)
        //        {
        //            TreeNode trnew = new TreeNode();
        //            trnew.Value = accnt.Name;
        //            trchild.ChildNodes.Add(trnew);
        //        }
        //    }
        //}


    }
}
