using OMS.DAL;
using OMS.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.Admin
{
    public partial class ItemCategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPageData();
            }
        }

        private void LoadPageData()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Ins_ItemCategory> itemCategoryList = facade.InsentiveFacade.GetCategoryAll();

                lvItemCategory.DataSource = itemCategoryList;
                lvItemCategory.DataBind();
            }
            lblMsg.Text = string.Empty;
        }

        public int SelectedItemId
        {
            get
            {
                if (ViewState["SelectedItemId"] != null)
                    return Convert.ToInt32(ViewState["SelectedItemId"].ToString());
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedItemId"] = value;
            }
        }
        protected void lvItemCategory_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editItem")
            {
                SelectedItemId = Convert.ToInt32(e.CommandArgument.ToString());
                LoadCetagoryItemDetails();
                lblMsg.Text = string.Empty;
            }
        }

        private void LoadCetagoryItemDetails()
        {
            using (TheFacade facade = new TheFacade())
            {
                Ins_ItemCategory item = facade.InsentiveFacade.GetCategoryByID(SelectedItemId);
                if (item != null)
                {
                    txtName.Text = item.Name;
                    txtCode.Text = item.Code;
                }
            }
        }

        protected void lvItemCategory_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblName = (Label)e.Item.FindControl("lblName");
                Label lblCode = (Label)e.Item.FindControl("lblCode");

                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");


                Ins_ItemCategory category = dataItem.DataItem as Ins_ItemCategory;

                lblName.Text = category.Name;
                lblCode.Text = category.Code;

                lnkBtnEdit.CommandArgument = category.IID.ToString();
                lnkBtnEdit.CommandName = "editItem";
                lnkBtnEdit.Text = "Edit";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (TheFacade facade = new TheFacade())
            {
                if (!IsValidData())
                {
                    //Error msg
                    lblMsg.Text = "Category Name already exist";
                    return;
                }
                Ins_ItemCategory item = new Ins_ItemCategory();
                if (SelectedItemId > 0)
                {
                    item = facade.InsentiveFacade.GetCategoryByID(SelectedItemId);
                    item.Name = txtName.Text;
                    item.Code = txtCode.Text;
                    item.IsRemoved = 0;
                    item.UpdateBy = 1;
                    item.UpdateDate = DateTime.Now;
                    facade.Update<Ins_ItemCategory>(item);
                }
                else
                {
                    item.Name = txtName.Text;
                    item.Code = txtCode.Text;
                    item.IsRemoved = 0;
                    item.UpdateBy = 1;
                    item.UpdateDate = DateTime.Now;
                    item.CreateBy = 1;//sustemuserid
                    item.CreateDate = DateTime.Now;
                    facade.Insert<Ins_ItemCategory>(item);
                }
                


               
            }
                Response.Redirect(Request.Url.ToString());
           
        }

        private bool IsValidData()
        {
            bool isValid = false;
            using (TheFacade facade = new TheFacade())
            {
                bool alreadyExist = facade.InsentiveFacade.HasCategoryNameAlreadyExist(txtName.Text, SelectedItemId);
                isValid = !alreadyExist;
            }
            return isValid;
        }
    }
}