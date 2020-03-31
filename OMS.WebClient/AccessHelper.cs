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


namespace OMS.WebClient
{
    public class AccessHelper
    {
        public bool HasAccess(long userID,long roleID,bool IsRoleBased, string pageName)
        {
            bool hasAccess=false;
            SystemPage page = new SystemPage();
            try
            {
                using (TheFacade facade = new TheFacade())
                {
                    if (IsRoleBased)
                    {
                        page = facade.AdminFacade.GetPageByRoleAndPageName(roleID, pageName);
                    }
                    else
                    {
                        page = facade.AdminFacade.GetPageByUserAndPageName(userID, pageName);
                    }
                    if (page != null)
                    {
                        hasAccess = true;
                    }
                }
            }
            catch (Exception)
            {


                hasAccess = false;
            }
           
            return hasAccess;
        }
    }
}