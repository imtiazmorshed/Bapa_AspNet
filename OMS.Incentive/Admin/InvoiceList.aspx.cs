using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;

namespace OMS.Incentive.Admin
{
    public partial class InvoiceList : System.Web.UI.Page
    {
        public long MemberID
        {
            get
            {
                if (ViewState["MemberID"] != null)
                {
                    return Convert.ToInt64(ViewState["MemberID"].ToString());
                }
                return 0;
            }
            set
            {
                ViewState["MemberID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MemberID"] != null)
                {
                    MemberID = Convert.ToInt64(Session["MemberID"].ToString());

                }
                LoadPageData();

            }
        }

        private void LoadPageData()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Inv_Master> invoiceList = facade.MemberFacade.GetAllInvoice();
                lvInvoiceList.DataSource = invoiceList.OrderBy(m=>m.Member.Name);
                lvInvoiceList.DataBind();

            }
        }

        protected void lvInvoiceList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem) e.Item;

                Label lblMemberName = (Label)e.Item.FindControl("lblMemberName");
                Label lblInvoiceNo = (Label) e.Item.FindControl("lblInvoiceNo");
                Label lblInvoiceAmount = (Label) e.Item.FindControl("lblInvoiceAmount");
                Label lblInvoiceDate = (Label) e.Item.FindControl("lblInvoiceDate");
                HyperLink lnkBtnEdit = (HyperLink) e.Item.FindControl("lnkBtnEdit");


                Inv_Master item = dataItem.DataItem as Inv_Master;



                lblMemberName.Text = item.Member.Name;
                lblInvoiceNo.Text = item.Number.ToString();
                lblInvoiceAmount.Text = item.DollarAmount.ToString("#.##");
                lblInvoiceDate.Text = item.Date.ToString("dd/M/yyyy");
                lnkBtnEdit.NavigateUrl = "~/Admin/Invoice.aspx?invId=" + item.IID.ToString();

            }
        }
    }
}