using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IInsentiveFacade
    {
        //Item
        List<Ins_Item> GetItemAll();
        Ins_Item GetItemByID(long id);
        List<Ins_Item> GetItemListByCategoryID(long categoryID);
        List<Ins_Item> GetItemListForMemberItemInsertByCategoryID(long categoryID, long memberID);
        List<Ins_Item> GetItemListForMemberItemUpdateByCategoryID(long categoryID, long memberID, long itemID);



        //Category
        List<Ins_ItemCategory> GetCategoryAll();
        
        Ins_ItemCategory GetCategoryByID(long id);
        bool HasCategoryNameAlreadyExist(string name, long categoryID);



        //MemberItem
        List<Ins_MemberItem> GetMemberItemAll();
        List<Ins_MemberItem> GetMemberItemByMemberID(long memberID);
        Ins_MemberItem GetMemberItemById(long id);
        Ins_MemberItem GetMemberItemByIdForUpdate(long id);

        List<Member> GetMemberAll();

        List<Ins_ChaForm> GetChaFormAll();
        List<Ins_ChaForm> GetChaFormAllByMemeberID(long memberID);
        Ins_ChaForm GetChaFormByID(long id);
        List<Ins_ChaFormInvoice> GetchaFormInvoiceByChaFormID(long chaFromID);

        void Dispose();
        Ins_InvoiceEnclosedDocument GetInvoiceEnclosedDocumentByID(long currentDocumentID);
        List<Ins_InvoiceEnclosedDocument> GetInvoiceEnclosedDocumentByInvoiceID(long invoiceID);
    }

    class InsentiveFacade : BaseFacade, IInsentiveFacade
    {
        public InsentiveFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IInsentiveFacade Members
        #region Item
        public List<Ins_Item> GetItemAll()
        {
            List<Ins_Item> itemList = new List<Ins_Item>();

            itemList = Database.Ins_Items.Where(i => i.IsRemoved == 0).ToList();
            foreach (Ins_Item item in itemList)
            {
                item.MeasurementUnit = item.MeasurementUnit;
                item.Ins_ItemCategory = item.Ins_ItemCategory;
                
            }
            return itemList;
        }

        public Ins_Item GetItemByID(long id)
        {
            Ins_Item item = new Ins_Item();
            item = Database.Ins_Items.FirstOrDefault(i => i.IID == id && i.IsRemoved == 0);
            if(item != null)
                item.MeasurementUnit = item.MeasurementUnit;
            return item;
        }

        public List<Ins_Item> GetItemListByCategoryID(long categoryID)
        {
            List<Ins_Item> itemList = new List<Ins_Item>();
            itemList = GetItemAll().Where(i => i.CategoryID == categoryID).ToList();
            foreach (Ins_Item item in itemList)
            {
                item.MeasurementUnit = item.MeasurementUnit;
                item.Ins_ItemCategory = item.Ins_ItemCategory;
            }
            return itemList;
        }

        public List<Ins_Item> GetItemListForMemberItemInsertByCategoryID(long categoryID, long memberID)
        {
            List<Ins_Item> itemList = new List<Ins_Item>();
            List<long> itemIDs = Database.Ins_MemberItems.Where(i => i.MemberID == memberID && i.IsRemoved == 0).Select(i => i.ItemID).ToList();
            itemList = GetItemAll().Where(i => i.CategoryID == categoryID && !itemIDs.Contains(i.IID)).ToList();
            foreach (Ins_Item item in itemList)
            {
                item.MeasurementUnit = item.MeasurementUnit;
                item.Ins_ItemCategory = item.Ins_ItemCategory;
            }
            return itemList;
        }

        public List<Ins_Item> GetItemListForMemberItemUpdateByCategoryID(long categoryID, long memberID, long itemID)
        {
            List<Ins_Item> itemList = new List<Ins_Item>();
            List<long> itemIDs = Database.Ins_MemberItems.Where(i => i.MemberID == memberID && i.IsRemoved == 0 && i.ItemID != itemID).Select(i => i.ItemID).ToList();
            itemList = GetItemAll().Where(i => i.CategoryID == categoryID && !itemIDs.Contains(i.IID)).ToList();
            foreach (Ins_Item item in itemList)
            {
                item.MeasurementUnit = item.MeasurementUnit;
                item.Ins_ItemCategory = item.Ins_ItemCategory;
            }
            return itemList;
        }

        #endregion

        #region Category

        public List<Ins_ItemCategory> GetCategoryAll()
        {
            List<Ins_ItemCategory> categoryList = new List<Ins_ItemCategory>();
            
            categoryList = Database.Ins_ItemCategories.Where(c => c.IsRemoved == 0).ToList();
            
            return categoryList;
        }

        public Ins_ItemCategory GetCategoryByID(long id)
        {
            Ins_ItemCategory category = new Ins_ItemCategory();
            category = Database.Ins_ItemCategories.Single(c => c.IID == id && c.IsRemoved == 0);
            
            return category;
        }

        public bool HasCategoryNameAlreadyExist(string name, long categoryID)
        {
            bool alreadyExist = false;
            Ins_ItemCategory category = new Ins_ItemCategory();
            if (categoryID <= 0)
            {
                category = Database.Ins_ItemCategories.FirstOrDefault(c => c.IsRemoved == 0 && c.Name.ToLower().Trim() == name.ToLower().Trim());
            }
            else
            {
                category = Database.Ins_ItemCategories.FirstOrDefault(c => c.IsRemoved == 0 && c.Name.ToLower().Trim() == name.ToLower().Trim() && c.IID != categoryID);
            }
            if (category != null && category.IID > 0)
            {
                alreadyExist = true;
            }
            return alreadyExist;
        }

        public List<Ins_MemberItem> GetMemberItemAll()
        {
            List<Ins_MemberItem> insMemberItems = new List<Ins_MemberItem>();

            insMemberItems = Database.Ins_MemberItems.Where(c => c.IsRemoved == 0).ToList();

            return insMemberItems;
        }

        public List<Ins_MemberItem> GetMemberItemByMemberID(long memberID)
        {
            List<Ins_MemberItem> insMemberItems = new List<Ins_MemberItem>();

            insMemberItems = Database.Ins_MemberItems.Where(c => c.IsRemoved == 0 && c.MemberID == memberID).ToList();

            return insMemberItems;
        }

        public Ins_MemberItem GetMemberItemById(long id)
        {
            Ins_MemberItem memberItem = new Ins_MemberItem();
            memberItem = Database.Ins_MemberItems.Single(c => c.IID == id && c.IsRemoved == 0);
            memberItem.Ins_Item = memberItem.Ins_Item;
            memberItem.Ins_Item.Ins_ItemCategory = memberItem.Ins_Item.Ins_ItemCategory;
            return memberItem;
        }

        public Ins_MemberItem GetMemberItemByIdForUpdate(long id)
        {
            Ins_MemberItem memberItem = new Ins_MemberItem();
            memberItem = Database.Ins_MemberItems.Single(c => c.IID == id && c.IsRemoved == 0);
            return memberItem;
        }

        

        public List<Member> GetMemberAll()
        {
            List<Member> members = Database.Members.Where(m => m.IsRemoved == 0).ToList();

            return members;
        }

        #endregion






        #endregion
        #region Cha-Form
        public List<Ins_ChaForm> GetChaFormAll()
        {
            return Database.Ins_ChaForms.Where(c => c.IsRemoved == 0).ToList();
        }
        public List<Ins_ChaForm> GetChaFormAllByMemeberID(long memberID)
        {
            List<Ins_ChaForm> chaforms = Database.Ins_ChaForms.Where(c => c.IsRemoved == 0 && c.MemberID == memberID).ToList();
            foreach (Ins_ChaForm item in chaforms)
            {
                item.Ins_ChaFormInvoices = item.Ins_ChaFormInvoices;
                item.Member = item.Member;
            }
            return chaforms;
        }
        public Ins_ChaForm GetChaFormByID(long id)
        {
            Ins_ChaForm chaform = Database.Ins_ChaForms.Where(c => c.ID == id).FirstOrDefault();
            if (chaform != null)
            {
                chaform.Ins_ChaFormInvoices = chaform.Ins_ChaFormInvoices;
                chaform.Member = chaform.Member;
            }
            return chaform;
        }
        public List<Ins_ChaFormInvoice> GetchaFormInvoiceByChaFormID(long chaFromID)
        {
            List<Ins_ChaFormInvoice> chaFormInvoiceList = Database.Ins_ChaFormInvoices.Where(c => c.ChaFormId == chaFromID).ToList();
            foreach (Ins_ChaFormInvoice item in chaFormInvoiceList)
            {
                item.Inv_Master = item.Inv_Master;
                
            }
            return chaFormInvoiceList;
        }
        #endregion

        public Ins_InvoiceEnclosedDocument GetInvoiceEnclosedDocumentByID(long currentDocumentID)
        {
            return Database.Ins_InvoiceEnclosedDocuments.FirstOrDefault(d => d.IID == currentDocumentID);
        }

        public List<Ins_InvoiceEnclosedDocument> GetInvoiceEnclosedDocumentByInvoiceID(long invoiceID)
        {
            return Database.Ins_InvoiceEnclosedDocuments.Where(d => d.InvoiceID == invoiceID).ToList();
        }
    }
}
