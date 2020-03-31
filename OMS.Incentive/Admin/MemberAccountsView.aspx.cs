using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using OMS.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.Admin
{
    public partial class MemberAccountsView : System.Web.UI.Page
    {
        public long CurrentMemberID
        {
            get
            {
                if (ViewState["MemberID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["MemberID"]);
                }
            }
            set { ViewState["MemberID"] = value; }
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
                    //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    //if (!hasAccess)
                    //{
                    //    Response.Redirect("~/NoPermission.aspx");
                    //}
                    //if (Convert.ToInt32(Session["RoleID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))//admin
                    //{
                    //    CurrentBranchID = -1;
                    //}
                    //else
                    //{
                        //CurrentBranchID = Convert.ToInt32(Session["BranchID"].ToString());
                        CurrentMemberID = Convert.ToInt32(Request.QueryString["MemberID"].ToString());
                    //}
                    LoadControl();
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

        private void LoadControl()
        {
            using (TheFacade facade = new TheFacade())
            {
                Member member = facade.MemberFacade.GetMemberById(CurrentMemberID);
                txtMembershipCode.Text = member.MembershipCode;
                txtAccountName.Text = member.Name;
            }
        }

        private void ShowMsg(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.Visible = true;
            Session["IsSaved"] = null;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (Session["BranchID"] != null)
            //{

            try
            {
                if (CurrentMemberID >0)
                {

                    using (TheFacade facade = new TheFacade())
                    {
                        Member member = facade.MemberFacade.GetMemberById(CurrentMemberID);
                        if (member != null && member.MemberVerificationStatus == (int)EnumCollection.VerificationStatus.Approved_for_Committee_Meeting)
                        {
                            member.MemberVerificationStatus = (int)EnumCollection.VerificationStatus.Completed;
                            member.MembershipStatus = (int)EnumCollection.MembershipStatus.Approved;
                            DateTime expireDate = new DateTime(DateTime.Now.Year, 6, 30);
                            if (DateTime.Now.Date > expireDate)
                                expireDate = expireDate.AddYears(1);
                            try
                            {
                                expireDate = Convert.ToDateTime(txtExpireDate.Text);
                            }
                            catch (Exception ex)
                            {
                            }
                            member.MembershipCode = txtMembershipCode.Text;

                            facade.Update<Member>(member);
                            Ins_MembershipExpireInfo info = new Ins_MembershipExpireInfo();
                            info.MemberID = member.ID;
                            info.ExpireDate = expireDate.Date;
                            info.CreateBy = 1;
                            info.CreateDate = DateTime.Now;
                            info.UpdateBy = 1;
                            info.UpdateDate = DateTime.Now;
                            info.IsRemoved = 0;
                            facade.Insert<Ins_MembershipExpireInfo>(info);
                            Ins_MemberVerification memberVerification = facade.MemberFacade.GetMemberVerificationByMemberID(member.ID);
                            if (memberVerification != null)
                            {
                                memberVerification.Status = (int)EnumCollection.VerificationStatus.Completed;
                                facade.Update<Ins_MemberVerification>(memberVerification);
                            }

                            Acc_ChartOfAccount chartofAcc = facade.AccountsFacade.GetAcc_ChartOfAccountByName("Account Receivable");
                            Acc_ChartOfAccountMember customerAccount = new Acc_ChartOfAccountMember();

                            #region acc
                            Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                            newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
                            newAccount.Name = member.Name;
                            newAccount.IsActive = 1;

                            newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                            newAccount.ParentID = chartofAcc.IID;
                            newAccount.Gparent = chartofAcc.Gparent;
                            newAccount.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text);
                            newAccount.CreateBy = 1;

                            newAccount.UpdateBy = 1;


                            newAccount.CreateDate = DateTime.Now;

                            newAccount.UpdateDate = DateTime.Now;
                            newAccount.IsRemoved = 0;
                            facade.Insert<Acc_ChartOfAccount>(newAccount);

                            #endregion

                            customerAccount.ChartofAccountID = newAccount.IID;
                            customerAccount.MemberID = member.ID;
                            customerAccount.UpdateDate = DateTime.Now;
                            customerAccount.UpdateBy = 1;


                            customerAccount.CreateDate = DateTime.Now;
                            customerAccount.CreateBy = 1;

                            customerAccount.IsRemoved = 0;
                            facade.Insert<Acc_ChartOfAccountMember>(customerAccount);
                        }

                        else
                        {
                            Session["duplicate"] = true;
                        }
                    }
                }
                else 
                {
                    using (TheFacade facade = new TheFacade())
                    {

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
            //}
            //else
            //{
            //    FormsAuthentication.SignOut();
            //    Roles.DeleteCookie();
            //    Session.Abandon();
            //    Response.Redirect("~/login.aspx");
            //}
        }

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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}