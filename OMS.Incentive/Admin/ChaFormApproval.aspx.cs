using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.Admin
{
    public partial class ChaFormApproval : System.Web.UI.Page
    {
        public long CurrentChaFormID
        {
            get
            {
                if (ViewState["CurrentChaFormID"] == null)
                    return 0;
                else
                    return Convert.ToInt64(ViewState["CurrentChaFormID"]);
            }
            set
            {
                ViewState["CurrentChaFormID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CurrentChaFormID"] != null)
                {
                    CurrentChaFormID = Convert.ToInt64(Request.QueryString["CurrentChaFormID"]);
                }
                //Load other Bacic Data
            }
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            if (CurrentChaFormID <= 0)
                return;
            using (TheFacade facade = new TheFacade())
            {
                Ins_ChaForm chaForm = facade.InsentiveFacade.GetChaFormByID(CurrentChaFormID);
                chaForm.Status = (int)EnumCollection.ChaFormStatus.Approved;
                chaForm.ChaFormNo = txtChaFormNo.Text;

                facade.Update<Ins_ChaForm>(chaForm);
            }
            Response.Redirect("~/Admin/MemberChaForm.aspx");
        }
    }
}