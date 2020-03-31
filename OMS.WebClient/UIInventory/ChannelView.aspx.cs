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
using OMS.DAL;
using OMS.Facade;
using OMS.Web.Helpers;
using OMS.Framework;

namespace OMS.WebClient.UIInventory
{
    public partial class ChannelView : System.Web.UI.Page
    {
        public int IsNew
        {
            get
            {
                if (ViewState["IsNew"] == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["IsNew"]);
                }
            }
            set { ViewState["IsNew"] = value; }
        }

        public long CurrentChannelID
        {
            get
            {
                if (ViewState["CurrentChannelID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentChannelID"]);
                }
            }
            set { ViewState["CurrentChannelID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsNew = 1;

                LoadChannelListView();
                LoadParent();
                LoadChannelType();
                LoadCity();
            }
        }

        

        private void LoadChannelListView()
        {
            List<Channel> channelList = new List<Channel>();
            using (TheFacade _facade = new TheFacade())
            {
                channelList = _facade.ChannelFacade.GetChannelAll();
            }
            lvChannel.DataSource = channelList;
            lvChannel.DataBind();
        }

        private void LoadCity()
        {
            List<City> cityList = new List<City>();
            using (TheFacade _facade = new TheFacade())
            {
                cityList = _facade.CommonFacade.GetCityAll();
            }
            DDLHelper.Bind<City>(ddlCity, cityList, "Name", "IID", EnumCollection.ListItemType.City);
        }

        private void LoadChannelType()
        {
            List<ChannelType> channelTypeList = new List<ChannelType>();
            using (TheFacade _facade = new TheFacade())
            {
                channelTypeList = _facade.ChannelFacade.GetChannelTypeAll();
            }
            DDLHelper.Bind<ChannelType>(ddlChannelType, channelTypeList, "Name", "IID", EnumCollection.ListItemType.ChannelType);
        }

        private void LoadParent()
        {
            List<Channel> channelList = new List<Channel>();
            Channel channel = new Channel();
            channel.IID = -2;
            channel.Name = "No Parent";
            using (TheFacade _facade = new TheFacade())
            {
                channelList = _facade.ChannelFacade.GetChannelAll();
                channelList.Add(channel);
            }
            if (channelList.Count > 0)
            {
                DDLHelper.Bind<Channel>(ddlParent, channelList, "Name", "IID",EnumCollection.ListItemType.ChannelParent);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Channel channel = new Channel();
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {

                LoadChannel(channel);
                using (TheFacade _facade = new TheFacade())
                {
                    _facade.Insert<Channel>(channel);
                }
            }
            else
            {
                using (TheFacade _facade = new TheFacade())
                {
                    channel = _facade.ChannelFacade.GetChannelByID(CurrentChannelID);
                    LoadChannel(channel);
                    _facade.Update<Channel>(channel);
                }
            }
            Response.Redirect("~/UIInventory/ChannelView.aspx");
        }

        private void LoadChannel(Channel channel)
        {
            channel.Name = txtName.Text;
            channel.Code = txtCode.Text;
            channel.Address = txtAddress.Text;
            if (ddlParent.SelectedValue == "" )
            {
                channel.ParentID = -1;
            }
            else
            {
                channel.ParentID = Convert.ToInt64(ddlParent.SelectedValue);
            }
            channel.ChannelTypeID = Convert.ToInt32(ddlChannelType.SelectedValue);
            channel.CityID = Convert.ToInt64(ddlCity.SelectedValue);
            channel.Phone = txtPhone.Text;
            channel.Mobile = txtMobile.Text;
            channel.Fax = txtFax.Text;
            channel.Email = txtEmail.Text;
            channel.Web = txtWeb.Text;
            channel.ContactPerson = txtContactPerson.Text;
            channel.ContactPersonAddress = txtContactPersonAddress.Text;
            channel.ContactPersonPhone = txtContactPersonPhone.Text;
            channel.ContactPersonMobile = txtContactPersonMobile.Text;
            channel.ContactPersonEmail = txtContactPersonEmail.Text;

            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                channel.CreateBy = 1;
            }

            channel.UpdateBy = 1;
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                channel.CreateDate = DateTime.Now;
            }
            channel.UpdateDate = DateTime.Now;
            channel.IsRemoved = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UIInventory/ChannelView.aspx");
        }

        protected void lvChannel_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Channel channel = (Channel)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");
                Label lblCode = (Label)currentItem.FindControl("lblCode");
                Label lblChannelType = (Label)currentItem.FindControl("lblChannelType");
                Label lblPhoneMobile = (Label)currentItem.FindControl("lblPhoneMobile");
                Label lblContactPerson = (Label)currentItem.FindControl("lblContactPerson");
                Label lblContactPersonPhoneMobile = (Label)currentItem.FindControl("lblContactPersonPhoneMobile");                
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkName.Text = channel.Name;
                lnkName.CommandArgument = channel.IID.ToString();
                lnkName.CommandName = "LoadChannel";

                lblCode.Text = channel.Code;
                lblChannelType.Text = channel.ChannelType.Name;
                lblPhoneMobile.Text = channel.Phone + ", " + channel.Mobile;
                lblContactPerson.Text = channel.ContactPerson;
                lblContactPersonPhoneMobile.Text = channel.ContactPersonPhone + ", " + channel.ContactPersonMobile;
                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = channel.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = channel.IID.ToString();
            }
        }

        protected void lvChannel_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Channel channel = new Channel();

                    channel = _facade.ChannelFacade.GetChannelByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentChannelID = channel.IID;
                    txtName.Text = channel.Name;
                    txtCode.Text = channel.Code;
                    txtAddress.Text = channel.Address;
                    ddlChannelType.SelectedValue = channel.ChannelTypeID.ToString();
                    if (channel.ParentID == -1)
                    {
                        ddlParent.SelectedIndex = -1;
                    }
                    else
                    {
                        ddlParent.SelectedValue = channel.ParentID.ToString();
                    }
                    ddlCity.SelectedValue = channel.CityID.ToString();
                    txtPhone.Text = channel.Phone;
                    txtMobile.Text = channel.Mobile;
                    txtFax.Text = channel.Fax;
                    txtEmail.Text = channel.Email;
                    txtWeb.Text = channel.Web;
                    txtContactPerson.Text = channel.ContactPerson;
                    txtContactPersonAddress.Text = channel.ContactPersonAddress;
                    txtContactPersonPhone.Text = channel.ContactPersonPhone;
                    txtContactPersonMobile.Text = channel.ContactPersonMobile;
                    txtContactPersonEmail.Text = channel.Email;                    
                    IsNew = -1;
                }
            }

            else
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Item item = new Item();

                    Channel channel = new Channel();

                    channel = _facade.ChannelFacade.GetChannelByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentChannelID = channel.IID;
                    txtName.Text = channel.Name;
                    txtCode.Text = channel.Code;
                    txtAddress.Text = channel.Address;
                    ddlChannelType.SelectedValue = channel.ChannelTypeID.ToString();
                    if (channel.ParentID == -1)
                    {
                        ddlParent.SelectedIndex = -1;
                    }
                    else
                    {
                        ddlParent.SelectedValue = channel.ParentID.ToString();
                    }
                    ddlCity.SelectedValue = channel.CityID.ToString();
                    txtPhone.Text = channel.Phone;
                    txtMobile.Text = channel.Mobile;
                    txtFax.Text = channel.Fax;
                    txtEmail.Text = channel.Email;
                    txtWeb.Text = channel.Web;
                    txtContactPerson.Text = channel.ContactPerson;
                    txtContactPersonAddress.Text = channel.ContactPersonAddress;
                    txtContactPersonPhone.Text = channel.ContactPersonPhone;
                    txtContactPersonMobile.Text = channel.ContactPersonMobile;
                    txtContactPersonEmail.Text = channel.Email; 
                    IsNew = 0;
                }
            }
        }

        protected void dpChannel_PreRender(object sender, EventArgs e)
        {
            LoadChannelListView();
        }
    }
}
